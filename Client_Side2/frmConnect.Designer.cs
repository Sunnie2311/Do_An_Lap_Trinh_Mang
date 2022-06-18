
namespace Client_Side2
{
    partial class frmConnect
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
            this.tbIP = new CustomControls.RJControls.RJTextBox();
            this.btnConnect = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(79, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Ip Of Server";
            // 
            // tbIP
            // 
            this.tbIP.BackColor = System.Drawing.SystemColors.Window;
            this.tbIP.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.tbIP.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbIP.BorderRadius = 0;
            this.tbIP.BorderSize = 3;
            this.tbIP.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIP.ForeColor = System.Drawing.Color.Black;
            this.tbIP.Location = new System.Drawing.Point(52, 113);
            this.tbIP.Margin = new System.Windows.Forms.Padding(4);
            this.tbIP.Multiline = false;
            this.tbIP.Name = "tbIP";
            this.tbIP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbIP.PasswordChar = false;
            this.tbIP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbIP.PlaceholderText = "IP Address";
            this.tbIP.Size = new System.Drawing.Size(311, 37);
            this.tbIP.TabIndex = 5;
            this.tbIP.Texts = "";
            this.tbIP.UnderlinedStyle = true;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnConnect.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnConnect.BorderColor = System.Drawing.Color.Black;
            this.btnConnect.BorderRadius = 10;
            this.btnConnect.BorderSize = 3;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(126, 203);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(150, 50);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextColor = System.Drawing.Color.White;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(417, 294);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public CustomControls.RJControls.RJTextBox tbIP;
        private CustomControls.RJControls.RJButton btnConnect;
    }
}