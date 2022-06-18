using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Server_Side
{
    class server
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[2];
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            Socket listener = new Socket(AddressFamily.InterNetwork , SocketType.Stream,
                ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            //listener.Listen(10);
            //NetworkStream stream = new NetworkStream(listener.Accept());
            //Thread listenerThread = new Thread(ListenerHandle);
            //listenerThread.Start(listener);
            //while (true)
            //{
            //    string message = Console.ReadLine();
            //    byte[] bytesSend = Encoding.UTF8.GetBytes(message);
            //    stream.Write(bytesSend, 0, bytesSend.Length);
            //}
            Console.ReadKey();
        }

        private static void ListenerHandle(object obj)
        {
            NetworkStream stream = obj as NetworkStream;
            while (true)
            {
                byte[] bytesReceive = new byte[1024];
                int num;
                string message = "";
                while (true)
                {
                    num = stream.Read(bytesReceive, 0, 1024);
                    message += Encoding.UTF8.GetString(bytesReceive, 0, num);
                    if (num == 0)
                        break;
                }
                Console.WriteLine("client : " + message);
            }
        }
    }
}
