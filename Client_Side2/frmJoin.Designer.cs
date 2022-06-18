
namespace Client_Side2
{
    partial class frmJoin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new CustomControls.RJControls.RJButton();
            this.btnJoin = new CustomControls.RJControls.RJButton();
            this.tbJoin = new CustomControls.RJControls.RJTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(52, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "        Join Room";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnExit.BackgroundColor = System.Drawing.Color.MediumVioletRed;
            this.btnExit.BorderColor = System.Drawing.Color.Black;
            this.btnExit.BorderRadius = 10;
            this.btnExit.BorderSize = 3;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(226, 164);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Cancel";
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnJoin.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnJoin.BorderColor = System.Drawing.Color.Black;
            this.btnJoin.BorderRadius = 10;
            this.btnJoin.BorderSize = 3;
            this.btnJoin.FlatAppearance.BorderSize = 0;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoin.ForeColor = System.Drawing.Color.White;
            this.btnJoin.Location = new System.Drawing.Point(18, 164);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(150, 50);
            this.btnJoin.TabIndex = 1;
            this.btnJoin.Text = "Join";
            this.btnJoin.TextColor = System.Drawing.Color.White;
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // tbJoin
            // 
            this.tbJoin.BackColor = System.Drawing.SystemColors.Window;
            this.tbJoin.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.tbJoin.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbJoin.BorderRadius = 0;
            this.tbJoin.BorderSize = 3;
            this.tbJoin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJoin.ForeColor = System.Drawing.Color.Black;
            this.tbJoin.Location = new System.Drawing.Point(41, 74);
            this.tbJoin.Margin = new System.Windows.Forms.Padding(4);
            this.tbJoin.Multiline = false;
            this.tbJoin.Name = "tbJoin";
            this.tbJoin.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbJoin.PasswordChar = false;
            this.tbJoin.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbJoin.PlaceholderText = "Name Room";
            this.tbJoin.Size = new System.Drawing.Size(311, 37);
            this.tbJoin.TabIndex = 0;
            this.tbJoin.Texts = "";
            this.tbJoin.UnderlinedStyle = true;
            // 
            // frmJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(395, 238);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.tbJoin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmJoin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJoin";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJButton btnExit;
        private CustomControls.RJControls.RJButton btnJoin;
        public CustomControls.RJControls.RJTextBox tbJoin;
    }
}