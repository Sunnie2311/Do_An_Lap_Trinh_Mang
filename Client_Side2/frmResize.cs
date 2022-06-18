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
    public partial class frmResize : Form
    {
        public frmResize()
        {
            InitializeComponent();
        }
        public int maxWidth = 0, maxHeight = 0;
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            bool check1 = Int32.TryParse(tbWidth.Texts, out maxWidth);
            bool check2 = Int32.TryParse(tbHeight.Texts, out maxHeight);
            if (check1 && check2)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please check width or height again !", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
