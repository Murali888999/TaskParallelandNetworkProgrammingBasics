using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
namespace client1
{
    class Client1
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 2211);
            Console.WriteLine("trying to conect....");
            NetworkStream n = client.GetStream();
            Console.WriteLine("conected....");
            while (true)
            {
                String s = Console.ReadLine();
                byte[] msg = Encoding.Unicode.GetBytes(s);
                n.Write(msg, 0, msg.Length);

            }         
        }
    }
}