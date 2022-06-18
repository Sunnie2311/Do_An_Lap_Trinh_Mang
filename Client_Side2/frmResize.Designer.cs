
namespace Client_Side2
{
    partial class frmResize
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new CustomControls.RJControls.RJButton();
            this.btnResize = new CustomControls.RJControls.RJButton();
            this.tbWidth = new CustomControls.RJControls.RJTextBox();
            this.tbHeight = new CustomControls.RJControls.RJTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(71, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "Resize Image";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnExit.Location = new System.Drawing.Point(191, 213);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Cancel";
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResize
            // 
            this.btnResize.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnResize.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.btnResize.BorderColor = System.Drawing.Color.Black;
            this.btnResize.BorderRadius = 10;
            this.btnResize.BorderSize = 3;
            this.btnResize.FlatAppearance.BorderSize = 0;
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResize.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.ForeColor = System.Drawing.Color.White;
            this.btnResize.Location = new System.Drawing.Point(25, 213);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(130, 50);
            this.btnResize.TabIndex = 2;
            this.btnResize.Text = "Resize";
            this.btnResize.TextColor = System.Drawing.Color.White;
            this.btnResize.UseVisualStyleBackColor = false;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // tbWidth
            // 
            this.tbWidth.BackColor = System.Drawing.SystemColors.Window;
            this.tbWidth.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.tbWidth.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbWidth.BorderRadius = 0;
            this.tbWidth.BorderSize = 3;
            this.tbWidth.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWidth.ForeColor = System.Drawing.Color.Black;
            this.tbWidth.Location = new System.Drawing.Point(55, 90);
            this.tbWidth.Margin = new System.Windows.Forms.Padding(4);
            this.tbWidth.Multiline = false;
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbWidth.PasswordChar = false;
            this.tbWidth.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbWidth.PlaceholderText = "New width";
            this.tbWidth.Size = new System.Drawing.Size(238, 37);
            this.tbWidth.TabIndex = 0;
            this.tbWidth.Texts = "";
            this.tbWidth.UnderlinedStyle = true;
            // 
            // tbHeight
            // 
            this.tbHeight.BackColor = System.Drawing.SystemColors.Window;
            this.tbHeight.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.tbHeight.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbHeight.BorderRadius = 0;
            this.tbHeight.BorderSize = 3;
            this.tbHeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHeight.ForeColor = System.Drawing.Color.Black;
            this.tbHeight.Location = new System.Drawing.Point(55, 145);
            this.tbHeight.Margin = new System.Windows.Forms.Padding(4);
            this.tbHeight.Multiline = false;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbHeight.PasswordChar = false;
            this.tbHeight.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbHeight.PlaceholderText = "New height";
            this.tbHeight.Size = new System.Drawing.Size(238, 37);
            this.tbHeight.TabIndex = 1;
            this.tbHeight.Texts = "";
            this.tbHeight.UnderlinedStyle = true;
            // 
            // frmResize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.Name = "frmResize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resize dialog";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJButton btnExit;
        private CustomControls.RJControls.RJButton btnResize;
        public CustomControls.RJControls.RJTextBox tbWidth;
        public CustomControls.RJControls.RJTextBox tbHeight;
    }
}