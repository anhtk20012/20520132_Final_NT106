namespace App_Gym
{
    partial class AddMemberControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMemberControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PicLabel = new System.Windows.Forms.Label();
            this.profilepicbox = new System.Windows.Forms.PictureBox();
            this.fullnametxtbox = new System.Windows.Forms.TextBox();
            this.Membershipbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GymTimingBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.genderbox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.todaysDatepicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.renewalDatepicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.feebox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dobbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.phonebox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Emailbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fathernametxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.clearallbtn = new CustomControls.RJControls.RJButton();
            this.Addmemberbutton = new CustomControls.RJControls.RJButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilepicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PicLabel);
            this.panel1.Controls.Add(this.profilepicbox);
            this.panel1.Controls.Add(this.fullnametxtbox);
            this.panel1.Controls.Add(this.Membershipbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.GymTimingBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.genderbox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.todaysDatepicker);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.renewalDatepicker);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.feebox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dobbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.phonebox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Emailbox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.fathernametxtbox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.AddressBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(112, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 350);
            this.panel1.TabIndex = 15;
            // 
            // PicLabel
            // 
            this.PicLabel.AutoSize = true;
            this.PicLabel.Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PicLabel.Location = new System.Drawing.Point(14, 167);
            this.PicLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PicLabel.Name = "PicLabel";
            this.PicLabel.Size = new System.Drawing.Size(140, 15);
            this.PicLabel.TabIndex = 12;
            this.PicLabel.Text = "Click to add profile picture";
            // 
            // profilepicbox
            // 
            this.profilepicbox.BackColor = System.Drawing.Color.Transparent;
            this.profilepicbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.profilepicbox.Image = global::App_Gym.Properties.Resources.user;
            this.profilepicbox.Location = new System.Drawing.Point(16, 25);
            this.profilepicbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.profilepicbox.Name = "profilepicbox";
            this.profilepicbox.Size = new System.Drawing.Size(118, 139);
            this.profilepicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilepicbox.TabIndex = 5;
            this.profilepicbox.TabStop = false;
            this.profilepicbox.Click += new System.EventHandler(this.profilepicbox_Click);
            // 
            // fullnametxtbox
            // 
            this.fullnametxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullnametxtbox.Location = new System.Drawing.Point(166, 43);
            this.fullnametxtbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fullnametxtbox.Name = "fullnametxtbox";
            this.fullnametxtbox.Size = new System.Drawing.Size(148, 23);
            this.fullnametxtbox.TabIndex = 0;
            this.fullnametxtbox.TextChanged += new System.EventHandler(this.fullnametxtbox_TextChanged);
            // 
            // Membershipbox
            // 
            this.Membershipbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Membershipbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Membershipbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Membershipbox.Items.AddRange(new object[] {
            "Bronze - Monthly",
            "Silver - Quarterly",
            "Gold - Halfyearly",
            "Platinum - Yearly"});
            this.Membershipbox.Location = new System.Drawing.Point(333, 265);
            this.Membershipbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Membershipbox.Name = "Membershipbox";
            this.Membershipbox.Size = new System.Drawing.Size(149, 25);
            this.Membershipbox.TabIndex = 10;
            this.Membershipbox.SelectedIndexChanged += new System.EventHandler(this.Membershipbox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // GymTimingBox
            // 
            this.GymTimingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GymTimingBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GymTimingBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GymTimingBox.FormattingEnabled = true;
            this.GymTimingBox.Items.AddRange(new object[] {
            "Morning Hours",
            "Evening Hours"});
            this.GymTimingBox.Location = new System.Drawing.Point(333, 189);
            this.GymTimingBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GymTimingBox.Name = "GymTimingBox";
            this.GymTimingBox.Size = new System.Drawing.Size(149, 25);
            this.GymTimingBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Age";
            // 
            // genderbox
            // 
            this.genderbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.genderbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderbox.FormattingEnabled = true;
            this.genderbox.Items.AddRange(new object[] {
            "Prefer not to say",
            "Male",
            "Female"});
            this.genderbox.Location = new System.Drawing.Point(504, 43);
            this.genderbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.genderbox.Name = "genderbox";
            this.genderbox.Size = new System.Drawing.Size(149, 25);
            this.genderbox.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(504, 243);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Renewal on";
            // 
            // todaysDatepicker
            // 
            this.todaysDatepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todaysDatepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.todaysDatepicker.Location = new System.Drawing.Point(164, 266);
            this.todaysDatepicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.todaysDatepicker.Name = "todaysDatepicker";
            this.todaysDatepicker.Size = new System.Drawing.Size(150, 23);
            this.todaysDatepicker.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(504, 168);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fee Paid:";
            // 
            // renewalDatepicker
            // 
            this.renewalDatepicker.Enabled = false;
            this.renewalDatepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renewalDatepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.renewalDatepicker.Location = new System.Drawing.Point(504, 265);
            this.renewalDatepicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.renewalDatepicker.Name = "renewalDatepicker";
            this.renewalDatepicker.Size = new System.Drawing.Size(149, 23);
            this.renewalDatepicker.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(501, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gender";
            // 
            // feebox
            // 
            this.feebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feebox.Location = new System.Drawing.Point(504, 189);
            this.feebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.feebox.MaxLength = 5;
            this.feebox.Name = "feebox";
            this.feebox.Size = new System.Drawing.Size(149, 23);
            this.feebox.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(161, 244);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Joining Date\r\n";
            // 
            // dobbox
            // 
            this.dobbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobbox.Location = new System.Drawing.Point(166, 191);
            this.dobbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dobbox.MaxLength = 2;
            this.dobbox.Name = "dobbox";
            this.dobbox.Size = new System.Drawing.Size(148, 23);
            this.dobbox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Timings";
            // 
            // phonebox
            // 
            this.phonebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonebox.Location = new System.Drawing.Point(166, 113);
            this.phonebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.phonebox.MaxLength = 14;
            this.phonebox.Name = "phonebox";
            this.phonebox.Size = new System.Drawing.Size(148, 23);
            this.phonebox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(505, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Address";
            // 
            // Emailbox
            // 
            this.Emailbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emailbox.Location = new System.Drawing.Point(332, 112);
            this.Emailbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Emailbox.Name = "Emailbox";
            this.Emailbox.Size = new System.Drawing.Size(150, 23);
            this.Emailbox.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(330, 243);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Membership Type";
            // 
            // fathernametxtbox
            // 
            this.fathernametxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fathernametxtbox.Location = new System.Drawing.Point(332, 43);
            this.fathernametxtbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fathernametxtbox.Name = "fathernametxtbox";
            this.fathernametxtbox.Size = new System.Drawing.Size(150, 23);
            this.fathernametxtbox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(163, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Phone No.";
            // 
            // AddressBox
            // 
            this.AddressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBox.Location = new System.Drawing.Point(504, 112);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddressBox.Multiline = true;
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(149, 40);
            this.AddressBox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(330, 90);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Email ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(329, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Father\'s Name";
            // 
            // clearallbtn
            // 
            this.clearallbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.clearallbtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.clearallbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.clearallbtn.BorderRadius = 7;
            this.clearallbtn.BorderSize = 0;
            this.clearallbtn.FlatAppearance.BorderSize = 0;
            this.clearallbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearallbtn.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.clearallbtn.ForeColor = System.Drawing.Color.White;
            this.clearallbtn.Image = ((System.Drawing.Image)(resources.GetObject("clearallbtn.Image")));
            this.clearallbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clearallbtn.Location = new System.Drawing.Point(466, 454);
            this.clearallbtn.Name = "clearallbtn";
            this.clearallbtn.Size = new System.Drawing.Size(200, 51);
            this.clearallbtn.TabIndex = 16;
            this.clearallbtn.Text = "Cancel";
            this.clearallbtn.TextColor = System.Drawing.Color.White;
            this.clearallbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clearallbtn.UseVisualStyleBackColor = false;
            this.clearallbtn.Click += new System.EventHandler(this.clearallbtn_Click);
            // 
            // Addmemberbutton
            // 
            this.Addmemberbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(190)))), ((int)(((byte)(49)))));
            this.Addmemberbutton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(190)))), ((int)(((byte)(49)))));
            this.Addmemberbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Addmemberbutton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Addmemberbutton.BorderRadius = 7;
            this.Addmemberbutton.BorderSize = 0;
            this.Addmemberbutton.FlatAppearance.BorderSize = 0;
            this.Addmemberbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Addmemberbutton.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.Addmemberbutton.ForeColor = System.Drawing.Color.White;
            this.Addmemberbutton.Image = ((System.Drawing.Image)(resources.GetObject("Addmemberbutton.Image")));
            this.Addmemberbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Addmemberbutton.Location = new System.Drawing.Point(234, 454);
            this.Addmemberbutton.Name = "Addmemberbutton";
            this.Addmemberbutton.Size = new System.Drawing.Size(200, 51);
            this.Addmemberbutton.TabIndex = 16;
            this.Addmemberbutton.Text = "Add Member";
            this.Addmemberbutton.TextColor = System.Drawing.Color.White;
            this.Addmemberbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Addmemberbutton.UseVisualStyleBackColor = false;
            this.Addmemberbutton.Click += new System.EventHandler(this.Addmemberbutton_Click);
            // 
            // AddMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearallbtn);
            this.Controls.Add(this.Addmemberbutton);
            this.Controls.Add(this.panel1);
            this.Name = "AddMemberControl";
            this.Size = new System.Drawing.Size(941, 588);
            this.Load += new System.EventHandler(this.AddMemberControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilepicbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PicLabel;
        private System.Windows.Forms.PictureBox profilepicbox;
        private System.Windows.Forms.TextBox fullnametxtbox;
        private System.Windows.Forms.ComboBox Membershipbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GymTimingBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox genderbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker todaysDatepicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker renewalDatepicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox feebox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox dobbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox phonebox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Emailbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox fathernametxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private CustomControls.RJControls.RJButton Addmemberbutton;
        private CustomControls.RJControls.RJButton clearallbtn;
    }
}
