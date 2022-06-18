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
using System.IO;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client_Side2
{
    public partial class frmLogin : Form
    {
        #region declare
        Socket client;
        IPAddress address;
        string nameUser;
        string account;
        string strIP;
        #endregion
        public void PassData(string strIP)
        {
            this.strIP = strIP;
            address = IPAddress.Parse(strIP);
        }
        #region construct
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CreateConnection();
            Thread thread = new Thread(ReceiveFromServer);
            thread.Start();
        }
        #endregion
        #region create connection
        private void CreateConnection()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var remoteHost = new IPEndPoint(address, 9090);
            client.Connect(remoteHost);
        }
        #endregion
        #region receive
        private void ReceiveFromServer()
        {
            byte[] bytesReceive = new byte[1024 * 500];
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
                    string[] arrStr = message.Split('|');
                    if(arrStr[0] == "yes")
                    {
                        account = tbUser.Texts;
                        nameUser = arrStr[1];
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Account or password is wrong", "Warning !", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(()=>{
                    this.Hide();
                }));
            }
            frmBackGround backGround = new frmBackGround();
            backGround.PassData(client, nameUser, strIP, account);
            backGround.ShowDialog();
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => {
                    this.Close();
                }));
            }
        }
        #endregion
        #region button event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string message = tbUser.Texts + "|" + tbPassword.Texts;
            using(var stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, message);
                client.Send(stream.ToArray());
            }
        }
        #endregion

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister register = new frmRegister();
            register.PassData(address);
            register.ShowDialog();
            this.Show();
        }
    }
}
