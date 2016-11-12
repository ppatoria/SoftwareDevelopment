using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class serv 
{
    public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = string.Empty;
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork" )
            {
                localIP = ip.ToString();
            }
        }
        return localIP;
    }
	public static void Main() {
	try {
        string localip = "fe80::653c:b2b9:870c:ff94";
        IPAddress ipAd = IPAddress.Parse(localip); //use local m/c IP address, and use the same in the client
        

/* Initializes the Listener */
        TcpListener myList = new TcpListener(ipAd, 8001);

/* Start Listeneting at the specified port */		
		myList.Start();
		
		Console.WriteLine("The server is running at port 8001...");	
		Console.WriteLine("The local End point is  :" + myList.LocalEndpoint );
		Console.WriteLine("Waiting for a connection.....");
		
		Socket s=myList.AcceptSocket();
		Console.WriteLine("Connection accepted from "+s.RemoteEndPoint);
		
		byte[] b=new byte[100];
		int k=s.Receive(b);
		Console.WriteLine("Recieved...");
		for (int i=0;i<k;i++)
			Console.Write(Convert.ToChar(b[i]));

		ASCIIEncoding asen=new ASCIIEncoding();
		s.Send(asen.GetBytes("The string was recieved by the server."));
		Console.WriteLine("\nSent Acknowledgement");
/* clean up */    		
		s.Close();
		myList.Stop();
			
	}
	catch (Exception e) {
		Console.WriteLine("Error..... " + e.ToString());
	}	
	}
	
}