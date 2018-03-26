using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace client1
{

    class Client2
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2211);
            sck.Connect(endPoint);
            Console.WriteLine("Connected.");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Enter Message");
                string msg = Console.ReadLine();
                byte[] msgBuffer = Encoding.Default.GetBytes(msg);
                sck.Send(msgBuffer);
                Console.WriteLine("msg sent");
            }
            Console.Read();
            sck.Close();
        }
    }
}
