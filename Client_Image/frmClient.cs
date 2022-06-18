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

namespace Client_Image
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }
        Socket client;
        private void CreateConnection()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            IPEndPoint remoteHost = new IPEndPoint(IPAddress.Loopback, 8081);
            client.Connect(remoteHost);
            //System.Threading.Thread.Sleep(300);
            Image image = Image.FromFile("riven.jpg");
            using (var memory = new MemoryStream())
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(memory, image);
                byte[] bytesSend = memory.ToArray();
                client.Send(bytesSend);
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            CreateConnection();
        }
    }
}
