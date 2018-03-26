using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class server1
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 2211);

            try
            {
                server.Start();
                Console.WriteLine("server started........");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Accepted client....");
                while(true)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] recivedBytes = new byte[client.ReceiveBufferSize];

                    int data = stream.Read(recivedBytes, 0, client.ReceiveBufferSize);

                    String s = Encoding.Unicode.GetString(recivedBytes, 0, data);
                    Console.WriteLine(s);
                }
            }
       
        }
    }
}
