namespace App_Gym
{
    partial class ForgotPasswordPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPasswordPage));
            this.OTPTextbox = new System.Windows.Forms.TextBox();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Head = new System.Windows.Forms.Panel();
            this.closebox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SendOtpBtn = new CustomControls.RJControls.RJButton();
            this.VerifyOTPBtn = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebox)).BeginInit();
            this.SuspendLayout();
            // 
            // OTPTextbox
            // 
            this.OTPTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTPTextbox.Location = new System.Drawing.Point(285, 330);
            this.OTPTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.OTPTextbox.Name = "OTPTextbox";
            this.OTPTextbox.Size = new System.Drawing.Size(233, 27);
            this.OTPTextbox.TabIndex = 2;
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(285, 259);
            this.EmailTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(233, 27);
            this.EmailTextbox.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(332, 112);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter OTP Code :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter Your Email ID :";
            // 
            // Head
            // 
            this.Head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.Head.Controls.Add(this.closebox);
            this.Head.Controls.Add(this.label6);
            this.Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head.Location = new System.Drawing.Point(0, 0);
            this.Head.Margin = new System.Windows.Forms.Padding(4);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(784, 68);
            this.Head.TabIndex = 9;
            this.Head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Head_MouseDown);
            // 
            // closebox
            // 
            this.closebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebox.Image = ((System.Drawing.Image)(resources.GetObject("closebox.Image")));
            this.closebox.Location = new System.Drawing.Point(732, 12);
            this.closebox.Margin = new System.Windows.Forms.Padding(4);
            this.closebox.Name = "closebox";
            this.closebox.Size = new System.Drawing.Size(36, 32);
            this.closebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closebox.TabIndex = 0;
            this.closebox.TabStop = false;
            this.closebox.Click += new System.EventHandler(this.closebox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "Recover Password";
            // 
            // SendOtpBtn
            // 
            this.SendOtpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.SendOtpBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.SendOtpBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.SendOtpBtn.BorderRadius = 7;
            this.SendOtpBtn.BorderSize = 0;
            this.SendOtpBtn.FlatAppearance.BorderSize = 0;
            this.SendOtpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendOtpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.SendOtpBtn.ForeColor = System.Drawing.Color.White;
            this.SendOtpBtn.Location = new System.Drawing.Point(571, 257);
            this.SendOtpBtn.Name = "SendOtpBtn";
            this.SendOtpBtn.Size = new System.Drawing.Size(160, 32);
            this.SendOtpBtn.TabIndex = 1;
            this.SendOtpBtn.Text = "Send OTP Code";
            this.SendOtpBtn.TextColor = System.Drawing.Color.White;
            this.SendOtpBtn.UseVisualStyleBackColor = false;
            this.SendOtpBtn.Click += new System.EventHandler(this.SendOtpBtn_Click);
            // 
            // VerifyOTPBtn
            // 
            this.VerifyOTPBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.VerifyOTPBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.VerifyOTPBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.VerifyOTPBtn.BorderRadius = 7;
            this.VerifyOTPBtn.BorderSize = 0;
            this.VerifyOTPBtn.FlatAppearance.BorderSize = 0;
            this.VerifyOTPBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyOTPBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.VerifyOTPBtn.ForeColor = System.Drawing.Color.White;
            this.VerifyOTPBtn.Location = new System.Drawing.Point(571, 329);
            this.VerifyOTPBtn.Name = "VerifyOTPBtn";
            this.VerifyOTPBtn.Size = new System.Drawing.Size(160, 32);
            this.VerifyOTPBtn.TabIndex = 3;
            this.VerifyOTPBtn.Text = "Verify OTP Code";
            this.VerifyOTPBtn.TextColor = System.Drawing.Color.White;
            this.VerifyOTPBtn.UseVisualStyleBackColor = false;
            this.VerifyOTPBtn.Click += new System.EventHandler(this.VerifyOTPBtn_Click);
            // 
            // ForgotPasswordPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(784, 394);
            this.Controls.Add(this.VerifyOTPBtn);
            this.Controls.Add(this.SendOtpBtn);
            this.Controls.Add(this.OTPTextbox);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgotPasswordPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPasswordPage";
            this.Load += new System.EventHandler(this.ForgotPasswordPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Head.ResumeLayout(false);
            this.Head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OTPTextbox;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Head;
        private System.Windows.Forms.PictureBox closebox;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJButton SendOtpBtn;
        private CustomControls.RJControls.RJButton VerifyOTPBtn;
    }
}