
namespace Client_Side2
{
    partial class frmCreate
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
            this.tbCreate = new CustomControls.RJControls.RJTextBox();
            this.btnCreate = new CustomControls.RJControls.RJButton();
            this.btnExit = new CustomControls.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbCreate
            // 
            this.tbCreate.BackColor = System.Drawing.SystemColors.Window;
            this.tbCreate.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.tbCreate.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbCreate.BorderRadius = 0;
            this.tbCreate.BorderSize = 3;
            this.tbCreate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCreate.ForeColor = System.Drawing.Color.Black;
            this.tbCreate.Location = new System.Drawing.Point(53, 101);
            this.tbCreate.Margin = new System.Windows.Forms.Padding(4);
            this.tbCreate.Multiline = false;
            this.tbCreate.Name = "tbCreate";
            this.tbCreate.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbCreate.PasswordChar = false;
            this.tbCreate.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbCreate.PlaceholderText = "Name Room";
            this.tbCreate.Size = new System.Drawing.Size(311, 37);
            this.tbCreate.TabIndex = 0;
            this.tbCreate.Texts = "";
            this.tbCreate.UnderlinedStyle = true;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreate.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnCreate.BorderColor = System.Drawing.Color.Black;
            this.btnCreate.BorderRadius = 10;
            this.btnCreate.BorderSize = 3;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(30, 191);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(150, 50);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextColor = System.Drawing.Color.White;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            this.btnExit.Location = new System.Drawing.Point(238, 191);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 50);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Cancel";
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(65, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "  Create New Room";
            // 
            // frmCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(417, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateBox";
            this.ResumeLayout(false);

        }

        #endregion

        public CustomControls.RJControls.RJTextBox tbCreate;
        private CustomControls.RJControls.RJButton btnCreate;
        private CustomControls.RJControls.RJButton btnExit;
        private System.Windows.Forms.Label label1;
    }
}