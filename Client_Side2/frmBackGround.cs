using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace Client_Side2
{
    public partial class frmBackGround : Form
    {
        #region declare
        object objj = new object();
        public Socket client;
        public string nameRoom;
        public string nameUser;
        public string account;
        public string strIP;
        IPAddress address;
        bool flagCreate = false;
        bool flagJoin = false;
        #endregion
        #region construct
        public frmBackGround()
        {
            InitializeComponent();
        }
        private void frmBackGround_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(ReceiveFromServer);
            thread.Start();
        }
        #endregion
        #region pass data
        public void PassData(Socket socket, string nameUser, string strIP, string account)
        {
            client = socket;
            this.nameUser = nameUser;
            this.account = account;
            this.strIP = strIP;
            address = IPAddress.Parse(strIP);
        }
        #endregion
        #region button event
        private void btnCreate_Click(object sender, EventArgs e)
        {
            flagCreate = true;
            frmCreate create = new frmCreate();
            if(create.ShowDialog() == DialogResult.OK)
            {
                nameRoom = create.tbCreate.Texts;
                string message = "create|" + nameRoom + "|" + account + "|" + nameUser;
                Thread thread = new Thread(SendToServer);
                thread.Start(message);
            }
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            flagJoin = true;
            frmJoin join = new frmJoin();
            if (join.ShowDialog() == DialogResult.OK)
            {
                nameRoom = join.tbJoin.Texts;
                string message = "join|" + nameRoom + "|" + account + "|" + nameUser;
                Thread thread = new Thread(SendToServer);
                thread.Start(message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region sent
        private void SendToServer(object obj)
        {
            string message = obj + "";
            using (var stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, message);
                client.Send(stream.ToArray());
            }
        }
        #endregion
        #region receive
        private void ReceiveFromServer()
        {
            byte[] bytesReceive = new byte[1024 * 5000];
            while (true)
            {
                try
                {
                    client.Receive(bytesReceive);
                }
                catch (Exception)
                {
                    return;
                }
                using (var stream = new MemoryStream(bytesReceive))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    string message = bf.Deserialize(stream) + "";
                    if(message == "yes")
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.FormBorderStyle = FormBorderStyle.None;
                                this.Size = new Size(1, 1);
                            }));
                        }
                        frmWorkSpace workSpace = new frmWorkSpace();
                        workSpace.PassData(client, nameUser, nameRoom, strIP, account);
                        workSpace.ShowDialog();
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                                this.Size = new Size(900, 700);
                            }));
                        }
                        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
                        var remoteHost = new IPEndPoint(address, 9090);
                        socket.Connect(remoteHost);
                        client = socket;
                        string message2 = "restart" + "|" + nameRoom + "|" + account + "|" + nameUser;
                        using (var stream2 = new MemoryStream())
                        {
                            BinaryFormatter bf2 = new BinaryFormatter();
                            bf2.Serialize(stream2, message2);
                            client.Send(stream2.ToArray());
                        }
                    }
                    else
                    {
                        if(flagCreate)
                        {
                            MessageBox.Show("The name was exitsed", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            flagCreate = false;
                        }
                        else if (flagJoin)
                        {
                            MessageBox.Show("The name was not exitsed", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            flagJoin = false;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
