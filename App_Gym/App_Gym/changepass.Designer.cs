namespace App_Gym
{
    partial class changepass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changepass));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dragpanel = new System.Windows.Forms.Panel();
            this.closebox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.confirmtextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passtextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UserNameTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.changepassbtn = new CustomControls.RJControls.RJButton();
            this.dragpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.panel2.Location = new System.Drawing.Point(400, 56);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 245);
            this.panel2.TabIndex = 25;
            // 
            // dragpanel
            // 
            this.dragpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.dragpanel.Controls.Add(this.closebox);
            this.dragpanel.Controls.Add(this.label6);
            this.dragpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dragpanel.Location = new System.Drawing.Point(0, 0);
            this.dragpanel.Margin = new System.Windows.Forms.Padding(4);
            this.dragpanel.Name = "dragpanel";
            this.dragpanel.Size = new System.Drawing.Size(807, 41);
            this.dragpanel.TabIndex = 24;
            this.dragpanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragpanel_MouseDown);
            // 
            // closebox
            // 
            this.closebox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebox.Image = ((System.Drawing.Image)(resources.GetObject("closebox.Image")));
            this.closebox.Location = new System.Drawing.Point(767, 5);
            this.closebox.Margin = new System.Windows.Forms.Padding(4);
            this.closebox.Name = "closebox";
            this.closebox.Size = new System.Drawing.Size(36, 32);
            this.closebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closebox.TabIndex = 14;
            this.closebox.TabStop = false;
            this.closebox.Click += new System.EventHandler(this.closebox_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Change Your Password";
            // 
            // confirmtextbox
            // 
            this.confirmtextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmtextbox.Location = new System.Drawing.Point(17, 214);
            this.confirmtextbox.Margin = new System.Windows.Forms.Padding(4);
            this.confirmtextbox.Name = "confirmtextbox";
            this.confirmtextbox.Size = new System.Drawing.Size(259, 27);
            this.confirmtextbox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Confirm Password:";
            // 
            // passtextbox
            // 
            this.passtextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passtextbox.Location = new System.Drawing.Point(17, 105);
            this.passtextbox.Margin = new System.Windows.Forms.Padding(4);
            this.passtextbox.Name = "passtextbox";
            this.passtextbox.Size = new System.Drawing.Size(259, 27);
            this.passtextbox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "New Password :";
            // 
            // UserType
            // 
            this.UserType.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserType.Location = new System.Drawing.Point(477, 93);
            this.UserType.Margin = new System.Windows.Forms.Padding(4);
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.Size = new System.Drawing.Size(196, 27);
            this.UserType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(473, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "User Type :";
            // 
            // UserNameTextbox
            // 
            this.UserNameTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextbox.Location = new System.Drawing.Point(480, 265);
            this.UserNameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.UserNameTextbox.Name = "UserNameTextbox";
            this.UserNameTextbox.ReadOnly = true;
            this.UserNameTextbox.Size = new System.Drawing.Size(196, 27);
            this.UserNameTextbox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(477, 241);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "User Name :";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(481, 179);
            this.EmailTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.ReadOnly = true;
            this.EmailTextbox.Size = new System.Drawing.Size(196, 27);
            this.EmailTextbox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(477, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "User Email ID :";
            // 
            // changepassbtn
            // 
            this.changepassbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.changepassbtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.changepassbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.changepassbtn.BorderRadius = 7;
            this.changepassbtn.BorderSize = 0;
            this.changepassbtn.FlatAppearance.BorderSize = 0;
            this.changepassbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changepassbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.changepassbtn.ForeColor = System.Drawing.Color.White;
            this.changepassbtn.Location = new System.Drawing.Point(296, 321);
            this.changepassbtn.Name = "changepassbtn";
            this.changepassbtn.Size = new System.Drawing.Size(209, 44);
            this.changepassbtn.TabIndex = 2;
            this.changepassbtn.Text = "Change password";
            this.changepassbtn.TextColor = System.Drawing.Color.White;
            this.changepassbtn.UseVisualStyleBackColor = false;
            this.changepassbtn.Click += new System.EventHandler(this.changepassbtn_Click);
            // 
            // changepass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(807, 391);
            this.Controls.Add(this.changepassbtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dragpanel);
            this.Controls.Add(this.confirmtextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passtextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UserNameTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "changepass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "changepass";
            this.Load += new System.EventHandler(this.changepass_Load);
            this.dragpanel.ResumeLayout(false);
            this.dragpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel dragpanel;
        private System.Windows.Forms.PictureBox closebox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox confirmtextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passtextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UserNameTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJButton changepassbtn;
    }
}