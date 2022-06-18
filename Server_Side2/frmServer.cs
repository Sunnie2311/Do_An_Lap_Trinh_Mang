using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server_Side2
{
    public partial class frmServer : Form
    {
        #region stuff
        Socket listener;
        Socket listenerSignal;
        Socket trySocket;
        List<Socket> lstSocket;
        Dictionary<string, Thread> lstSignalThread;
        Dictionary<String, Dictionary<string, Socket>> lstRoom;
        Dictionary<String, Dictionary<string, Socket>> lstRoomSignal;
        Dictionary<string, List<string>> lstUser;
        MongoCRUD crud;
        IPAddress address = IPAddress.Loopback;
        public frmServer()
        {
            InitializeComponent();
        }
        private void frmServer_Load(object sender, EventArgs e)
        {
            lstSocket = new List<Socket>();
            lstUser = new Dictionary<string, List<string>>();
            lstRoom = new Dictionary<string, Dictionary<string, Socket>>();
            lstSignalThread = new Dictionary<string, Thread>();
            lstRoomSignal = new Dictionary<string, Dictionary<string, Socket>>();
            crud = new MongoCRUD("WhiteBoard-DB");
            InitialData();
            var threadListenSignal = new Thread(StartListenSignal);
            threadListenSignal.Start();
            var threadListenConnection = new Thread(StartListenConnection);
            threadListenConnection.Start();
            var threadTryConnect = new Thread(ListenTryConnect);
            threadTryConnect.Start();
        }
        private void ResponeMessage(Socket server, string message)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, message);
                server.Send(stream.ToArray());
            }
        }
        #endregion
        #region initial data
        private void InitialData()
        {
            List<Room> lst = crud.LoadAllRecord<Room>("Room");
            foreach (var item in lst)
            {
                lstRoom.Add(item.Name, new Dictionary<string, Socket>());
                lstRoomSignal.Add(item.Name, new Dictionary<string, Socket>());
            }
        }
        #endregion
        #region try connect handle
        private void ListenTryConnect()
        {
            trySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            var localHost = new IPEndPoint(address, 9093);
            trySocket.Bind(localHost);
            trySocket.Listen(-1);
            while (true)
            {
                Socket server = trySocket.Accept();
            }
        }
        #endregion
        #region signal
        private void StartListenSignal()
        {
            listenerSignal = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            var localHost = new IPEndPoint(address, 9091);
            listenerSignal.Bind(localHost);
            listenerSignal.Listen(-1);
            string[] arrStr;
            while (true)
            {
                var socket = listenerSignal.Accept();
                byte[] bytesReceive = new byte[1024 * 5000];
                socket.Receive(bytesReceive);
                string message = "";
                using (var stream = new MemoryStream(bytesReceive))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    message = bf.Deserialize(stream) + "";
                    arrStr = message.Split('|');
                    lstRoomSignal[arrStr[0]].Add(arrStr[1], socket);
                }
                var pair = new KeyValuePair<string, Socket>(message, socket);
                var thread = new Thread(ReceiveSignal);
                lstSignalThread.Add(arrStr[1], thread);
                thread.Start(pair);
            }
        }
        private void ReceiveSignal(object obj)
        {
            KeyValuePair<string, Socket> pair = (KeyValuePair<string, Socket>)obj;
            string[] arrStr = pair.Key.Split('|');
            string nameRoom = arrStr[0];
            string nameUser = arrStr[1];
            Socket socket = pair.Value;
            while (true)
            {
                byte[] bytesReceive = new byte[1024 * 500];
                int num = socket.Receive(bytesReceive);
                foreach (var keyValue in lstRoomSignal[nameRoom])
                {
                    keyValue.Value.Send(bytesReceive);
                }
            }
        }

        #endregion
        #region listen connection
        private void StartListenConnection()
        {
            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localHost = new IPEndPoint(address, 9090);
            listener.Bind(localHost);
            listener.Listen(-1);
            while (true)
            {
                Socket clientSocket = listener.Accept();
                lstSocket.Add(clientSocket);
                Thread threadReceive = new Thread(ReceiveFromClient);
                threadReceive.Start(lstSocket.Count - 1);
            }
        }
        #endregion
        #region receive message
        private void ReceiveFromClient(object obj)
        {
            int index = (int)obj;
            Socket server = lstSocket[index];

            #region login process
            while (true)
            {
                byte[] bytesReceive = new byte[1024 * 5000];
                server.Receive(bytesReceive);
                using (var stream = new MemoryStream(bytesReceive))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    string message = bf.Deserialize(stream) + "";
                    string[] arrStr = message.Split('|'); 
                    if(arrStr[0] == "register")
                    {
                        string account = arrStr[1];
                        string name = arrStr[2];
                        string password = arrStr[3];
                        if(crud.CountRecord<User>("User", "Account", arrStr[1]) == 0)
                        {
                            User user = new User()
                            {
                                Account = account,
                                Name = name,
                                Password = password
                            };
                            crud.InsertOneRecord<User>("User", user);
                            ResponeMessage(server, "registersuccess");
                            server.Close();
                            return;
                        }
                        else
                        {
                            ResponeMessage(server, "registerfail");
                            continue;
                        }
                    }
                    else if (crud.CountRecord<User>("User", "Account", arrStr[0]) != 0)
                    {
                        User user = crud.LoadOneRecord<User>("User", "Account", arrStr[0]);
                        if (user.Password == arrStr[1])
                        {
                            using (var streamSend = new MemoryStream())
                            {
                                bf.Serialize(streamSend, "yes|" + user.Name);
                                server.Send(streamSend.ToArray());
                                break;
                            }
                        }
                        else
                        {
                            using (var streamSend = new MemoryStream())
                            {
                                bf.Serialize(streamSend, "no|" + user.Name);
                                server.Send(streamSend.ToArray());
                                break;
                            }
                        }
                    }
                    else if(arrStr[0] == "restart")
                    {
                        break;
                    }
                    else
                    {
                        using (var streamSend = new MemoryStream())
                        {
                            bf.Serialize(streamSend, "no");
                            server.Send(streamSend.ToArray());
                        }
                    }
                }
            }
            #endregion
            BackGroundProcess(server);
       }
        #endregion

        private void BackGroundProcess(object obj)
        {
            Socket server = obj as Socket;
            while (true)
            {
                string[] arrStr;
                byte[] bytesReceive = new byte[1024 * 5000];
                try
                {
                    server.Receive(bytesReceive);
                }
                catch (Exception)
                {

                }
                using (var stream = new MemoryStream(bytesReceive))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    string message = bf.Deserialize(stream) + "";
                    arrStr = message.Split('|');
                    if (arrStr[0] == "join")
                    {
                        if (crud.CountRecord<Room>("Room", "Name", arrStr[1]) == 0)
                        {
                            using (var streamSend = new MemoryStream())
                            {
                                bf.Serialize(streamSend, "no");
                                server.Send(streamSend.ToArray());
                            }
                            continue;
                        }
                        if (!lstUser.ContainsKey(arrStr[1]))
                        {
                            lstUser.Add(arrStr[1], new List<string>());   
                        }
                        lstUser[arrStr[1]].Add(arrStr[3]);
                        lstRoom[arrStr[1]].Add(arrStr[2], server);
                        using (var streamSend = new MemoryStream())
                        {
                            bf.Serialize(streamSend, "yes");
                            server.Send(streamSend.ToArray());
                        }
                    }
                    else if (arrStr[0] == "create")
                    {
                        if (crud.CountRecord<Room>("Room", "Name", arrStr[1]) != 0)
                        {
                            using (var streamSend = new MemoryStream())
                            {
                                bf.Serialize(streamSend, "no");
                                server.Send(streamSend.ToArray());
                            }
                            continue;
                        }
                        using (var streamSend = new MemoryStream())
                        {
                            bf.Serialize(streamSend, "yes");
                            server.Send(streamSend.ToArray());
                        }
                        #region create new room
                        Bitmap bitmap = new Bitmap(1920, 1072);
                        Graphics g = Graphics.FromImage(bitmap);
                        g.Clear(Color.White);
                        using (var stream1 = new MemoryStream())
                        {
                            bf.Serialize(stream1, bitmap);
                            Room room = new Room()
                            {
                                Name = arrStr[1],
                                Board = stream1.ToArray()
                            };
                            lstRoom.Add(room.Name, new Dictionary<string, Socket>());
                            lstRoom[room.Name].Add(arrStr[2], server);
                            lstUser.Add(room.Name, new List<string>());
                            lstUser[room.Name].Add(arrStr[3]);
                            lstRoomSignal.Add(room.Name, new Dictionary<string, Socket>());
                            crud.InsertOneRecord<Room>("Room", room);
                        }
                        #endregion
                    }
                    string format = arrStr[1] + "|" + arrStr[2] + "|" + arrStr[3];
                    Thread thread = new Thread(ReceiveImageFromClient);
                    thread.Start(format);
                    break;
                }
            }
        }
        #region receive image
        private void ReceiveImageFromClient(object obj)
        {
            string format = obj + "";
            string[] arrStr = format.Split('|');
            SendInfoUsers(arrStr[0]);
            Socket server = lstRoom[arrStr[0]][arrStr[1]];
            Room room = crud.LoadOneRecord<Room>("Room", "Name", arrStr[0]);
            using (var stream = new MemoryStream(room.Board))
            {
                server.Send(stream.ToArray());
            }
            byte[] bytesReceive = new byte[1024 * 5000];
            while (true)
            {
                using (var stream = new MemoryStream())
                {
                    int num = 0;
                    try
                    {
                        num = server.Receive(bytesReceive);
                    }
                    catch (Exception)
                    {
                        lstSignalThread[arrStr[1]].Abort();
                        lstSignalThread.Remove(arrStr[1]);
                        lstRoom[arrStr[0]].Remove(arrStr[1]);
                        lstRoomSignal[arrStr[0]].Remove(arrStr[1]);
                        lstUser[arrStr[0]].Remove(arrStr[2]);
                        SendInfoUsers(arrStr[0]);
                        return;
                    }
                    stream.Write(bytesReceive, 0, num);
                    byte[] bytesSend = stream.ToArray();
                    Room roomUpdate = new Room()
                    {
                        Name = arrStr[0],
                        Board = bytesSend
                    };
                    crud.UpdateRecord("Room", roomUpdate.Name, roomUpdate);
                    foreach (var socket in lstRoom[arrStr[0]])
                    {
                        socket.Value.Send(bytesSend);
                    }
                }
            }
        }
        #endregion
        #region send info users
        private void SendInfoUsers(String nameRoom)
        {
            string message = "update|";
            foreach (var user in lstUser[nameRoom])
            {
                message += user + "|";
            }
            Thread.Sleep(200);
            foreach (var socket in lstRoomSignal[nameRoom])
            {
                using (var stream = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, message);
                    socket.Value.Send(stream.ToArray());
                }
            }
        }
        #endregion
    }
}
