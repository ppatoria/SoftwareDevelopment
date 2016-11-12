class Server implements Runnable {
    public void run() {
	try {
	    ServerSocket ss = new ServerSocket(PORT);
	    while (!Thread.interrupted())
		new Thread(new Handler(ss.accept())).start();
	    // or, single-threaded, or a thread pool
	} catch (IOException ex) { }
    }
}

class Handler implements Runnable {
    final Socket socket;
    Handler(Socket s) { socket = s; }
    public void run() {
	try {
	    byte[] input = new byte[MAX_INPUT];
	    socket.getInputStream().read(input);
	    byte[] output = process(input);
	    socket.getOutputStream().write(output);
	} catch (IOException ex) { }
    }
    private byte[] process(byte[] cmd) { }
}
public class Client {
    String hostIp;
    int hostPort;

    public Client(String hostIp, int hostPort) {
        this.hostIp = hostIp;
        this.hostPort = hostPort;
    }

    public void runClient() throws IOException {
        Socket clientSocket = null;
        PrintWriter out = null;
        BufferedReader in = null;

        try {
            clientSocket = new Socket(hostIp, hostPort);
            out = new PrintWriter(clientSocket.getOutputStream(), true);
            in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
        } catch (UnknownHostException e) {
            System.err.println("Unknown host: " + hostIp);
            System.exit(1);
        } catch (IOException e) {
            System.err.println("Couldn't connect to: " + hostIp);
            System.exit(1);
        }

        BufferedReader stdIn = new BufferedReader(new InputStreamReader(System.in));
        String userInput;

        System.out.println("Client connected to host : " + hostIp + " port: " + hostPort);
        System.out.println("Type (\"Bye\" to quit)");
        System.out.println("Tell what your name is to the Server.....");

        while ((userInput = stdIn.readLine()) != null) {

            out.println(userInput);
	    // Break when client says Bye.
	    if (userInput.equalsIgnoreCase("Bye"))
		break;

	    System.out.println("Server says: " + in.readLine());
	}

	out.close();
	in.close();
	stdIn.close();
	clientSocket.close();
    }

    public static void main(String[] args) throws IOException {

	Client client = new Client("127.0.0.1", 9900);
	client.runClient();
    }
}

public class Reactor implements Runnable 
{

    final Selector selector;
    final ServerSocketChannel serverSocketChannel;
    final boolean isWithThreadPool;

    Reactor(int port, boolean isWithThreadPool) throws IOException {

	this.isWithThreadPool = isWithThreadPool;
	selector = Selector.open();
	serverSocketChannel = ServerSocketChannel.open();
	serverSocketChannel.socket().bind(new InetSocketAddress(port));
	serverSocketChannel.configureBlocking(false);
	SelectionKey selectionKey0 = serverSocketChannel.register(selector, SelectionKey.OP_ACCEPT);
	selectionKey0.attach(new Acceptor());
    }


    public void run() {
	System.out.println("Server listening to port: " + serverSocketChannel.socket().getLocalPort());
	try {
	    while (!Thread.interrupted()) {
		selector.select();
		Set selected = selector.selectedKeys();
		Iterator it = selected.iterator();
		while (it.hasNext()) {
		    dispatch((SelectionKey) (it.next()));
		}
		selected.clear();
	    }
	} catch (IOException ex) {
	    ex.printStackTrace();                                                                      
	}
    }

    void dispatch(SelectionKey k) {
	Runnable r = (Runnable) (k.attachment());
	if (r != null) {
	    r.run();
	}
    }

    class Acceptor implements Runnable {
	public void run() {
	    try {
		SocketChannel socketChannel = serverSocketChannel.accept();
		if (socketChannel != null) {                        
		    if (isWithThreadPool)
			new HandlerWithThreadPool(selector, socketChannel); 
		    else
			new Handler(selector, socketChannel);
    
		}
		System.out.println("Connection Accepted by Reactor");
	    } catch (IOException ex) {
		ex.printStackTrace();                                      
	    }
	}
    }
}
public class Handler implements Runnable {

    final SocketChannel socketChannel;
    final SelectionKey selectionKey;
    ByteBuffer input = ByteBuffer.allocate(1024);
    static final int READING = 0, SENDING = 1;
    int state = READING;
    String clientName = "";

    Handler(Selector selector, SocketChannel c) throws IOException {
        socketChannel = c;
        c.configureBlocking(false);
        selectionKey = socketChannel.register(selector, 0);
        selectionKey.attach(this);
        selectionKey.interestOps(SelectionKey.OP_READ);
        selector.wakeup();
    }


    public void run() {
        try {
            if (state == READING) {
                read();
            } else if (state == SENDING) {
                send();
            }
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }

    void read() throws IOException {
        int readCount = socketChannel.read(input);
        if (readCount > 0) {
            readProcess(readCount);
        }
        state = SENDING;
        // Interested in writing
        selectionKey.interestOps(SelectionKey.OP_WRITE);
    }

    /**
     * Processing of the read message. This only prints the message to stdOut.
     *
     * @param readCount
     */
    synchronized void readProcess(int readCount) {
        StringBuilder sb = new StringBuilder();
        input.flip();
        byte[] subStringBytes = new byte[readCount];
        byte[] array = input.array();
        System.arraycopy(array, 0, subStringBytes, 0, readCount);
        // Assuming ASCII (bad assumption but simplifies the example)
        sb.append(new String(subStringBytes));
	input.clear();
	clientName = sb.toString().trim();                       
    }

    void send() throws IOException {
	System.out.println("Saying hello to " + clientName);
	ByteBuffer output = ByteBuffer.wrap(("Hello " + clientName + "\n").getBytes());
	socketChannel.write(output);
	selectionKey.interestOps(SelectionKey.OP_READ);
	state = READING;
    }
}                
public static void main(String[] args) throws IOException{

    Reactor reactor  = new Reactor(9900, false);
    new Thread(reactor).start();
}

public class HandlerWithThreadPool extends Handler {       
    static ExecutorService pool = Executors.newFixedThreadPool(2);     
    static final int PROCESSING = 2;       
    public HandlerWithThreadPool(Selector sel, SocketChannel c) throws IOException {         
	super(sel, c);     
    }       
    void read() throws IOException {         
	int readCount = socketChannel.read(input);         
	if (readCount > 0) {             
	    state = PROCESSING;             
	    pool.execute(new Processer(readCount));         
	}         //We are interested in writing back to the client soon after read processing is done.         
	selectionKey.interestOps(SelectionKey.OP_WRITE);     
    }       //Start processing in a new Processer Thread and Hand off to the reactor thread.     
    synchronized void processAndHandOff(int readCount) {         
	readProcess(readCount); //Read processing done. Now the server is ready to send a message to the client.         
	state = SENDING;     
    }       
    class Processer implements Runnable {         
	int readCount;         
	Processer(int readCount) {             
	    this.readCount =  readCount;         
	}         
	public void run() {             
	    processAndHandOff(readCount);         
	}     
    } 
}                                               

public static void main(String[] args) throws IOException{       
    Reactor reactor  = new Reactor(9900, true);     
    new Thread(reactor).start(); 
}


public class Client {     
    String hostIp;     
    int hostPort;       
    public Client(String hostIp, int hostPort) {         
	this.hostIp = hostIp;         
	this.hostPort = hostPort;     
    }       
    public void runClient() throws IOException {         
	Socket clientSocket = null;         
	PrintWriter out = null;         
	BufferedReader in = null;           
	try {             
	    clientSocket = new Socket(hostIp, hostPort);             
	    out = new PrintWriter(clientSocket.getOutputStream(), true);             
	    in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));         
	} catch (UnknownHostException e) {             
	    System.err.println("Unknown host: " + hostIp);             
	    System.exit(1);         
	} catch (IOException e) {             
	    System.err.println("Couldn't connect to: " + hostIp);             
	    System.exit(1);         
	}           
	BufferedReader stdIn = new BufferedReader(new InputStreamReader(System.in));         
	String userInput;           
	System.out.println("Client connected to host : " + hostIp + " port: " + hostPort);         
	System.out.println("Type (\"Bye\" to quit)");         
	System.out.println("Tell what your name is to the Server.....");           
	while ((userInput = stdIn.readLine()) != null) {               
	    out.println(userInput);               
             // Break when client says Bye.             
	    if (userInput.equalsIgnoreCase("Bye"))                 
		break;               
	    System.out.println("Server says: " + in.readLine());         }           
	out.close();         
	in.close();         
	stdIn.close();         
	clientSocket.close();     
    }       
    public static void main(String[] args) throws IOException {           
	Client client = new Client("127.0.0.1", 9900);         
	client.runClient();     
    } 
}