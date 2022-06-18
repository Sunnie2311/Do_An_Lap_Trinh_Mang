using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client_Side
{
    class client
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteHost = new IPEndPoint(IPAddress.Loopback, 8080);
            Console.WriteLine("Connecting ....");
            client.Connect(remoteHost);
            Console.WriteLine("Connected !");
            NetworkStream networkStream = new NetworkStream(client);
            Thread threadReceive = new Thread(ReceiveHandle);
            threadReceive.Start(networkStream);
            while (true)
            {
                string message = Console.ReadLine();
                byte[] bytesSend = Encoding.UTF8.GetBytes(message);
                networkStream.Write(bytesSend, 0, bytesSend.Length);
            }
            Console.ReadKey();
        }

        private static void ReceiveHandle(object obj)
        {
            NetworkStream networkStream = obj as NetworkStream;
            byte[] bytesReceive = new byte[1024];
            string message = "";
            int num;
            while (true)
            {
                num = networkStream.Read(bytesReceive, 0, 1024);
                message += Encoding.UTF8.GetString(bytesReceive, 0, num);
                if (num == 0)
                {
                    break;
                }
            }
            Console.WriteLine(message);
        }
    }
}
