using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client_Side1
{
    class client
    {
        static void Main(string[] args)
        {
            #region tcp code
            //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 8081);
            //TcpClient tcpClient = new TcpClient();

            //Console.WriteLine("Connecting ....");
            //tcpClient.Connect(iPEndPoint);
            //Console.WriteLine("Connected !");

            //NetworkStream stream = tcpClient.GetStream();
            //byte[] bytesSend = Encoding.UTF8.GetBytes("Hello server !");
            //stream.Write(bytesSend, 0, bytesSend.Length);

            //byte[] bytesReceive = new byte[1024];
            //stream.Read(bytesReceive, 0, 1024);
            //string message = Encoding.UTF8.GetString(bytesReceive);
            //Console.WriteLine(message);
            #endregion
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 8081);
            Console.WriteLine("Connecting ....");
            client.Connect(iPEndPoint);
            Console.WriteLine("Connected !");

            //Thread threadReceive = new Thread(ReceiveHandle);
            //threadReceive.Start(client);
            Console.ReadKey(); 
            byte[] bytesSend;
            while (true)
            {
                string message = "le nhut hoang";
                Console.WriteLine(message);
                bytesSend = Encoding.UTF8.GetBytes(message);
                client.Send(bytesSend);
            }
        }

        private static void ReceiveHandle(object obj)
        {
            Socket socket = obj as Socket;
            byte[] bytesReceive = new byte[1024];
            int bytesNum;
            string message = "";
            bytesNum = socket.Receive(bytesReceive);
            message = Encoding.UTF8.GetString(bytesReceive, 0, bytesNum);
            Console.WriteLine("Server : " + message);
        }
    }
}
