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

namespace Server_Image
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
        }
        Socket listener;
        Socket socketReceive;
        private void CreateConnection()
        {
            listener = new Socket(AddressFamily.InterNetwork,
                 SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localHost = new IPEndPoint(IPAddress.Loopback, 8081);
            listener.Bind(localHost);
            listener.Listen(-1);
            socketReceive = listener.Accept();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            listener = new Socket(AddressFamily.InterNetwork,
                 SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localHost = new IPEndPoint(IPAddress.Loopback, 8081);
            listener.Bind(localHost);
            listener.Listen(-1);
            socketReceive = listener.Accept();
            byte[] bytesReceive = new byte[1024 * 5000];
            socketReceive.Receive(bytesReceive);
            using (var memory = new MemoryStream(bytesReceive))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Image image = (Image)binaryFormatter.Deserialize(memory);
                pictureBox1.Image = image;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
