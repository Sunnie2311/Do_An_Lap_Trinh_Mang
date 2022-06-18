
namespace Client_Side2
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new CustomControls.RJControls.RJButton();
            this.btnRegister = new CustomControls.RJControls.RJButton();
            this.tbRepeatPassword = new CustomControls.RJControls.RJTextBox();
            this.tbPassword = new CustomControls.RJControls.RJTextBox();
            this.tbName = new CustomControls.RJControls.RJTextBox();
            this.tbAccount = new CustomControls.RJControls.RJTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.tbRepeatPassword);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.tbAccount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(65, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 370);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnBack.BackgroundColor = System.Drawing.Color.MediumVioletRed;
            this.btnBack.BorderColor = System.Drawing.Color.Black;
            this.btnBack.BorderRadius = 5;
            this.btnBack.BorderSize = 2;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(135, 315);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 40);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.TextColor = System.Drawing.Color.White;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnRegister.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnRegister.BorderColor = System.Drawing.Color.Black;
            this.btnRegister.BorderRadius = 5;
            this.btnRegister.BorderSize = 2;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(15, 315);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 40);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.TextColor = System.Drawing.Color.White;
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tbRepeatPassword
            // 
            this.tbRepeatPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbRepeatPassword.BorderColor = System.Drawing.Color.RoyalBlue;
            this.tbRepeatPassword.BorderFocusColor = System.Drawing.Color.DarkGreen;
            this.tbRepeatPassword.BorderRadius = 5;
            this.tbRepeatPassword.BorderSize = 2;
            this.tbRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRepeatPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbRepeatPassword.Location = new System.Drawing.Point(32, 260);
            this.tbRepeatPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbRepeatPassword.Multiline = false;
            this.tbRepeatPassword.Name = "tbRepeatPassword";
            this.tbRepeatPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbRepeatPassword.PasswordChar = true;
            this.tbRepeatPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.tbRepeatPassword.PlaceholderText = " Repeat Password";
            this.tbRepeatPassword.Size = new System.Drawing.Size(187, 39);
            this.tbRepeatPassword.TabIndex = 4;
            this.tbRepeatPassword.Texts = "";
            this.tbRepeatPassword.UnderlinedStyle = false;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbPassword.BorderColor = System.Drawing.Color.RoyalBlue;
            this.tbPassword.BorderFocusColor = System.Drawing.Color.DarkGreen;
            this.tbPassword.BorderRadius = 5;
            this.tbPassword.BorderSize = 2;
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbPassword.Location = new System.Drawing.Point(32, 210);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Multiline = false;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbPassword.PasswordChar = true;
            this.tbPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.tbPassword.PlaceholderText = " Password";
            this.tbPassword.Size = new System.Drawing.Size(187, 39);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Texts = "";
            this.tbPassword.UnderlinedStyle = false;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.BorderColor = System.Drawing.Color.RoyalBlue;
            this.tbName.BorderFocusColor = System.Drawing.Color.DarkGreen;
            this.tbName.BorderRadius = 5;
            this.tbName.BorderSize = 2;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.ForeColor = System.Drawing.Color.DimGray;
            this.tbName.Location = new System.Drawing.Point(31, 160);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Multiline = false;
            this.tbName.Name = "tbName";
            this.tbName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbName.PasswordChar = false;
            this.tbName.PlaceholderColor = System.Drawing.Color.DimGray;
            this.tbName.PlaceholderText = " Your Name";
            this.tbName.Size = new System.Drawing.Size(187, 39);
            this.tbName.TabIndex = 2;
            this.tbName.Texts = "";
            this.tbName.UnderlinedStyle = false;
            // 
            // tbAccount
            // 
            this.tbAccount.BackColor = System.Drawing.SystemColors.Window;
            this.tbAccount.BorderColor = System.Drawing.Color.RoyalBlue;
            this.tbAccount.BorderFocusColor = System.Drawing.Color.DarkGreen;
            this.tbAccount.BorderRadius = 5;
            this.tbAccount.BorderSize = 2;
            this.tbAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccount.ForeColor = System.Drawing.Color.DimGray;
            this.tbAccount.Location = new System.Drawing.Point(32, 110);
            this.tbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.tbAccount.Multiline = false;
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbAccount.PasswordChar = false;
            this.tbAccount.PlaceholderColor = System.Drawing.Color.DimGray;
            this.tbAccount.PlaceholderText = " Account";
            this.tbAccount.Size = new System.Drawing.Size(187, 39);
            this.tbAccount.TabIndex = 1;
            this.tbAccount.Texts = "";
            this.tbAccount.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.Image = global::Client_Side2.Properties.Resources.resume__1_;
            this.label1.Location = new System.Drawing.Point(74, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 100);
            this.label1.TabIndex = 0;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client_Side2.Properties.Resources.pngwing_com;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(378, 526);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox tbAccount;
        private CustomControls.RJControls.RJButton btnRegister;
        private CustomControls.RJControls.RJTextBox tbRepeatPassword;
        private CustomControls.RJControls.RJTextBox tbPassword;
        private CustomControls.RJControls.RJTextBox tbName;
        private CustomControls.RJControls.RJButton btnBack;
    }
}