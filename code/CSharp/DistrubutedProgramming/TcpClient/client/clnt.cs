using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;


public class clnt {
     public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = string.Empty;
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localIP = ip.ToString();
            }
        }
        return localIP;
    }
	public static void Main() {
		
		try {
            string localip = "fe80::653c:b2b9:870c:ff94";
            TcpClient tcpclnt = new TcpClient(Dns.GetHostName().ToString(), 8001);
			Console.WriteLine("Connecting.....");

            tcpclnt.Connect(localip, 8001); // use the ipaddress as in the server program
			
			Console.WriteLine("Connected");
			Console.Write("Enter the string to be transmitted : ");
			
			String str=Console.ReadLine();
			Stream stm = tcpclnt.GetStream();
						
			ASCIIEncoding asen= new ASCIIEncoding();
			byte[] ba=asen.GetBytes(str);
			Console.WriteLine("Transmitting.....");
			
			stm.Write(ba,0,ba.Length);
			
			byte[] bb=new byte[100];
			int k=stm.Read(bb,0,100);
			
			for (int i=0;i<k;i++)
				Console.Write(Convert.ToChar(bb[i]));
			
			tcpclnt.Close();
		}
		
		catch (Exception e) {
			Console.WriteLine("Error..... " + e.StackTrace);
		}
	}

}