using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class Server2
    {
        static byte[] Buffer { get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2211));
            sck.Listen(5);

            Socket accepted = sck.Accept();  //The accept function permits an incoming connection attempt on a socket.
            Console.WriteLine("Connected");
            for (int k = 0; k < 100; k++)
            {
                Buffer = new byte[accepted.SendBufferSize];//Gets or sets a value that specifies the size of the send buffer of the Socket.
                int bytesRead = accepted.Receive(Buffer);//Receives data from a bound Socket into a receive buffer.
                byte[] formatted = new byte[bytesRead];
                for (int i = 0; i < bytesRead; i++)
                {
                    formatted[i] = Buffer[i];
                }
                string strData = Encoding.ASCII.GetString(formatted); //Decodes a range of bytes from a byte array into a string.
                Console.WriteLine(strData);
            }
            Console.Read();
            sck.Close();
            accepted.Close();
        }
    }
}