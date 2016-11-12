using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace MemoryMappedCache
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
using System; 
using System.Net.Sockets; 
using System.Net; 
using System.Text; 
using System.Threading ; 
using System.IO; 
using System.Diagnostics ; 
using System.Runtime.Serialization.Formatters.Binary ; 
using MemoryMappedCache; 
namespace MemoryMappedCache 
{ 
    public class AsyncListener 
    { 
        public Socket s=null; 
        public bool isLogging=Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings["isLogging"]); 
        public void StartListening(int port) 
        { 
            try { // Resolve local name to get IP address 
                IPHostEntry entry = Dns.Resolve(Dns.GetHostName()); 
                IPAddress ip = entry.AddressList[0]; 
                // Create an end-point for local IP and port 
                IPEndPoint ep = new IPEndPoint(ip, port); 
                if(isLogging)
                    TraceLog.myWriter.WriteLine ("Address: " + ep.Address.ToString() +" : " + ep.Port.ToString(),"StartListening"); 
                EventLog.WriteEntry("MMFCache Async Listener","Listener started on IP: " + 
                        ip.ToString() + " and Port: " +port.ToString()+ "."); 
                // Create our socket for listening 
                s = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp); 
                // Bind and listen with a queue of 100 
                s.Bind(ep); 
                s.Listen(100); 
                // Setup our delegates for performing callbacks 
                acceptCallback = new AsyncCallback(AcceptCallback); 
                receiveCallback = new AsyncCallback(ReceiveCallback); 
                sendCallback = new AsyncCallback(SendCallback); 
                // Set the "Accept" process in motion 
                s.BeginAccept(acceptCallback, s); 
            } 
            catch(SocketException e) { 
                Console.Write("SocketException: "+ e.Message); 
            } 
        } 
        AsyncCallback acceptCallback; 
        AsyncCallback sendCallback ; 
        void AcceptCallback(IAsyncResult ar) 
        { 
            try { 
                // Cast the user data back to a socket object 
                Socket s = ar.AsyncState as Socket; 
                // End the accept and get the resulting client socket 
                Socket s2 = s.EndAccept(ar); 
                // Keep the "Accept" process in motion 
                s.BeginAccept(acceptCallback, s); 
                // Create a state object for client (real apps may cache these) 
                StateObject state = new StateObject(); 
                state.workerSocket = s2; 
                // Start an async receive 
                state.workerSocket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, receiveCallback, state); 
            } 
            catch(SocketException e) { 
                Debug.WriteLine(e.Message); 
                if(isLogging)
                    TraceLog.myWriter.WriteLine( "SocketException:"+ e.Message+e.StackTrace,"AcceptCallback"); 
            } 
            return; // Return the thread to the pool 
        } // Async receive method + matching delegate variable 
        AsyncCallback receiveCallback; 
        void ReceiveCallback(IAsyncResult ar) 
        { 
            int i=0; 
            string data=String.Empty; 
            try { 
                StateObject state = ar.AsyncState as StateObject; 
                i = state.workerSocket.EndReceive(ar); 
                if(i==0) { 
                    if(isLogging)TraceLog.myWriter.WriteLine("Shutting down socket.","ReceiveCallback"); 
                    state.workerSocket.Shutdown(SocketShutdown.Both); 
                    state.workerSocket.Close(); 
                } else { 
                    state.ms.Write(state.buffer ,0 ,i); 
                    state.workerSocket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, receiveCallback, state); 
                    if(i <state.buffer.Length) { 
                        byte[] result=HandleMessage(state); 
                        state.workerSocket.BeginSend(result, 0, result.Length, 0, sendCallback, state); 
                    } 
                } 
            } 
            catch(SocketException e) { 
                if(isLogging)
                    TraceLog.myWriter.WriteLine("SocketException: "+ e.Message,"ReceiveCallback"); 
            } 
            return; 
            // Return the thread to the pool 
        } // Async send method + matching delegate variable 
        void SendCallback(IAsyncResult ar) 
        { 
            int i=0; 
            try { // Cast the state to an object 
                StateObject state = ar.AsyncState as StateObject; 
                i = state.workerSocket.EndSend(ar); 
                // Begin another receive on the thread 
                state.workerSocket.BeginReceive(state.buffer, 0, state.buffer.Length, 0, receiveCallback, state); 
            } 
            catch(SocketException e) { 
                Debug.WriteLine(e.Message); 
                if(isLogging)
                    TraceLog.myWriter.WriteLine("SocketException: "+ e.Message,"SendCallback"); 
            } 
            return; 
            // Return the thread to the pool 
        } 
        private static byte[] HandleMessage(StateObject state) 
        { 
            byte[] bytResponse=null; 
            BinaryFormatter b= new BinaryFormatter(); 
            state.ms.Position =0; 
            CacheProxy proxy = (CacheProxy) b.Deserialize(state.ms); 
            if(proxy.Action ==ActionType.Get) 
            { 
                string key=proxy.Key ; 
                string cacheName=proxy.CacheName ; 
                MemoryMappedCache.Cache c= new MemoryMappedCache.Cache(cacheName); 
                object payload =c[key]; 
                // get the cache item from the key, package into a new Cache proxy, 
                // serialize and send out 
                CacheProxy proxyResult = new CacheProxy(cacheName,ActionType.Result ,key,payload); 
				MemoryStream ms = new MemoryStream(); 
                b.Serialize(ms, proxyResult); 
                bytResponse=ms.ToArray(); 
            } else 
                if(proxy.Action ==ActionType.Add) { 
                    string key=proxy.Key ; 
                    string cacheName=proxy.CacheName ; 
                    MemoryMappedCache.Cache c= new MemoryMappedCache.Cache(cacheName); 
                    c[key]=proxy.Payload ; 
                    byte[] bytTemp=System.Text.Encoding.UTF8.GetBytes("true"); 
                    CacheProxy returnProxy = new CacheProxy(cacheName,ActionType.Result,key,bytTemp); 
                    BinaryFormatter bResp=new BinaryFormatter(); 
                    MemoryStream memResp=new MemoryStream(); 
                    bResp.Serialize(memResp,returnProxy); 
                    bytResponse=memResp.ToArray(); 
                } else 
                    if (proxy.Action ==ActionType.Remove) 
                    { 
                        string key=proxy.Key ; 
                        string cacheName=proxy.CacheName ; 
                        MemoryMappedCache.Cache c= new MemoryMappedCache.Cache(cacheName); 
                        c.Remove(key); 
                        byte[] bytTemp=System.Text.Encoding.UTF8.GetBytes("true"); 
                        CacheProxy returnProxy = new CacheProxy(cacheName,ActionType.Result,key,bytTemp); 
                        BinaryFormatter bResp=new BinaryFormatter(); 
                        MemoryStream memResp=new MemoryStream(); 
                        bResp.Serialize(memResp,returnProxy); 
                        bytResponse=memResp.ToArray(); 
                    } 
            return bytResponse; 
        } 
    } // end class } // end namespace
