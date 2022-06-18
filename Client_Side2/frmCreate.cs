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
    public partial class frmCreate : Form
    {
        #region construct
        public frmCreate()
        {
            InitializeComponent();
        }
        #endregion
        #region button event
        private void btnCreate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
