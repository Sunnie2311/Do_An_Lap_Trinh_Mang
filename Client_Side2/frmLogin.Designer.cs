
namespace Client_Side2
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbPassword = new CustomControls.RJControls.RJTextBox();
            this.tbUser = new CustomControls.RJControls.RJTextBox();
            this.btnLogin = new CustomControls.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MintCream;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbUser);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(74, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 324);
            this.panel1.TabIndex = 3;
            // 
            // btnRegister
            // 
            this.btnRegister.AutoSize = true;
            this.btnRegister.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(0, 291);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(232, 31);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register for an account ";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbPassword.BorderColor = System.Drawing.Color.RoyalBlue;
            this.tbPassword.BorderFocusColor = System.Drawing.Color.DarkGreen;
            this.tbPassword.BorderRadius = 5;
            this.tbPassword.BorderSize = 2;
            this.tbPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.ForeColor = System.Drawing.Color.Black;
            this.tbPassword.Location = new System.Drawing.Point(20, 170);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Multiline = false;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbPassword.PasswordChar = true;
            this.tbPassword.PlaceholderColor = System.Drawing.Color.DimGray;
            this.tbPassword.PlaceholderText = " Password";
            this.tbPassword.Size = new System.Drawing.Size(187, 37);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Texts = "";
            this.tbPassword.UnderlinedStyle = false;
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.SystemColors.Window;
            this.tbUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tbUser.BorderColor = System.Drawing.Color.RoyalBlue;
            this.tbUser.BorderFocusColor = System.Drawing.Color.DarkGreen;
            this.tbUser.BorderRadius = 5;
            this.tbUser.BorderSize = 2;
            this.tbUser.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.ForeColor = System.Drawing.Color.Black;
            this.tbUser.Location = new System.Drawing.Point(20, 112);
            this.tbUser.Margin = new System.Windows.Forms.Padding(4);
            this.tbUser.Multiline = false;
            this.tbUser.Name = "tbUser";
            this.tbUser.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbUser.PasswordChar = false;
            this.tbUser.PlaceholderColor = System.Drawing.Color.DimGray;
            this.tbUser.PlaceholderText = " Username";
            this.tbUser.Size = new System.Drawing.Size(187, 37);
            this.tbUser.TabIndex = 0;
            this.tbUser.Texts = "";
            this.tbUser.UnderlinedStyle = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnLogin.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.BorderRadius = 5;
            this.btnLogin.BorderSize = 2;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(49, 230);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 41);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Log in";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.Image = global::Client_Side2.Properties.Resources.login__1_;
            this.label1.Location = new System.Drawing.Point(45, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 96);
            this.label1.TabIndex = 3;
            // 
            // frmLogin
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
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RJTextBox tbPassword;
        private CustomControls.RJControls.RJTextBox tbUser;
        private CustomControls.RJControls.RJButton btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegister;
    }
}