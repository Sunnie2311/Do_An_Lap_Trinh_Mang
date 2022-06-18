using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server_Side1
{
    class server
    {
        static void Main(string[] args)
        {
            #region Tcp code
            //TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8081);
            //listener.Start();
            //Console.WriteLine("Waiting for connection ....");
            //NetworkStream stream = listener.AcceptTcpClient().GetStream();
            //Console.WriteLine("Connected !");
            //byte[] bytesReceive = new byte[1024];
            //stream.Read(bytesReceive, 0, 1024);
            //Console.WriteLine(Encoding.UTF8.GetString(bytesReceive));
            //byte[] bytesSend = Encoding.UTF8.GetBytes("Hello client !");
            //stream.Write(bytesSend, 0, (int)bytesSend.Length);
            #endregion
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 8081);
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(iPEndPoint);
            listener.Listen(-1);
            Console.WriteLine("Waiting for connection ....");
            Socket socket = listener.Accept();
            Console.WriteLine("Connected !");

            Thread thdReceive = new Thread(ReceiveHandle);
            thdReceive.Start(socket);

            //byte[] bytesSend;
            //while (true)
            //{
            //    Console.Write("Server : ");
            //    string message = Console.ReadLine();
            //    bytesSend = Encoding.UTF8.GetBytes(message);
            //    socket.Send(bytesSend);
            //}
            Console.ReadKey();
        }

        private static void ReceiveHandle(object obj)
        {
            Socket socketReceive = obj as Socket;
            NetworkStream stream = new NetworkStream(socketReceive);
            byte[] bytesReceive = new byte[1024];
            int bytesNumber;
            string message = "";
            while (true)
            {
                bytesNumber = stream.Read(bytesReceive, 0, 1024);
                if (bytesNumber == 0)
                    break;
                message += Encoding.UTF8.GetString(bytesReceive);
            }
            Console.WriteLine(message);
        }
    }
}
