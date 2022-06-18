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
    public partial class frmRegister : Form
    {
        IPAddress serverIP;
        Socket client;
        public frmRegister()
        {
            InitializeComponent();
        }
        public void PassData(IPAddress address)
        {
            this.serverIP = address;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbAccount.Texts == "" || tbName.Texts == "" || tbPassword.Texts == ""
                || tbRepeatPassword.Texts == "")
            {
                MessageBox.Show("Information cannot be vacate !", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(tbPassword.Texts != tbRepeatPassword.Texts)
            {
                MessageBox.Show("Please check password again !", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string message = "register|";
            message += tbAccount.Texts + "|" + tbName.Texts + "|" + tbPassword.Texts;
            using (var stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, message);
                client.Send(stream.ToArray());
            }
        }

        private void ReceiveFromServer()
        {
            while (true)
            {
                string message = "";
                byte[] bytesReceive = new byte[1024 * 5000];
                int num = client.Receive(bytesReceive);
                using (var stream = new MemoryStream(bytesReceive, 0, num))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    message = bf.Deserialize(stream) + "";
                }
                if(message == "registersuccess")
                {
                    MessageBox.Show("Register Success !", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show("Account already exists", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(serverIP, 9090);
            client.Connect(endPoint);
            ThreadStart start = new ThreadStart(ReceiveFromServer);
            Thread receiveThread = new Thread(start);
            receiveThread.Start();
        }
    }
}
