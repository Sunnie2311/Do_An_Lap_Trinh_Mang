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
using System.Threading;

namespace Client_Side2
{
    public partial class frmConnect : Form
    {
        Socket socket;
        string strIP = "";
        public frmConnect()
        {
            InitializeComponent();
        }
        private void frmConnect_Load(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            strIP = tbIP.Texts;
            Thread threadTryToConnect = new Thread(TryToConnect);
            threadTryToConnect.Start(strIP);
        }
        private void TryToConnect(object obj)
        {
            var remoteHost = new IPEndPoint(IPAddress.Parse(strIP), 9093);
            try
            {
                socket.Connect(remoteHost);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => {
                        this.Hide();
                    }));
                }
                frmLogin frmLogin = new frmLogin();
                frmLogin.PassData(strIP);
                frmLogin.ShowDialog();
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => {
                        this.Close();
                    }));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check again ip address.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
