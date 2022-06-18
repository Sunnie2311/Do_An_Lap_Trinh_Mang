using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Side2
{
    public partial class frmOnline : Form
    {
        #region stuff
        List<string> lstUser = new List<string>();
        public frmOnline()
        {
            InitializeComponent();
        }
        
        private void frmOnline_Load(object sender, EventArgs e)
        {
            foreach (var user in lstUser)
            {
                string nameUser = user;
                lstbUser.Items.Add(nameUser);
            }
        }
        public void PassData(List<string> lstUser)
        {
            this.lstUser = lstUser;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
