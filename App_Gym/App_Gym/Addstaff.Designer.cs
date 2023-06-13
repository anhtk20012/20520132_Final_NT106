namespace App_Gym
{
    partial class Addstaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addstaff));
            this.StaffPanel = new System.Windows.Forms.Panel();
            this.PicLabel = new System.Windows.Forms.Label();
            this.StaffDesigBox = new System.Windows.Forms.ComboBox();
            this.ShiftTimeBox = new System.Windows.Forms.ComboBox();
            this.IDTypeBox = new System.Windows.Forms.ComboBox();
            this.genderbox = new System.Windows.Forms.ComboBox();
            this.staffjoinedDate = new System.Windows.Forms.DateTimePicker();
            this.StaffAgeBox = new System.Windows.Forms.TextBox();
            this.StaffSalary = new System.Windows.Forms.TextBox();
            this.StaffFatherName = new System.Windows.Forms.TextBox();
            this.StaffNameBox = new System.Windows.Forms.TextBox();
            this.StaffIdentityProof = new System.Windows.Forms.TextBox();
            this.StaffEmailID = new System.Windows.Forms.TextBox();
            this.staffage = new System.Windows.Forms.Label();
            this.StaffAddressBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.StaffPhoneNo = new System.Windows.Forms.TextBox();
            this.DynamicIDLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.UserProfileImage = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.clearallbtn = new CustomControls.RJControls.RJButton();
            this.Addmemberbutton = new CustomControls.RJControls.RJButton();
            this.StaffPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // StaffPanel
            // 
            this.StaffPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.StaffPanel.Controls.Add(this.PicLabel);
            this.StaffPanel.Controls.Add(this.StaffDesigBox);
            this.StaffPanel.Controls.Add(this.ShiftTimeBox);
            this.StaffPanel.Controls.Add(this.IDTypeBox);
            this.StaffPanel.Controls.Add(this.genderbox);
            this.StaffPanel.Controls.Add(this.staffjoinedDate);
            this.StaffPanel.Controls.Add(this.StaffAgeBox);
            this.StaffPanel.Controls.Add(this.StaffSalary);
            this.StaffPanel.Controls.Add(this.StaffFatherName);
            this.StaffPanel.Controls.Add(this.StaffNameBox);
            this.StaffPanel.Controls.Add(this.StaffIdentityProof);
            this.StaffPanel.Controls.Add(this.StaffEmailID);
            this.StaffPanel.Controls.Add(this.staffage);
            this.StaffPanel.Controls.Add(this.StaffAddressBox);
            this.StaffPanel.Controls.Add(this.label14);
            this.StaffPanel.Controls.Add(this.label1);
            this.StaffPanel.Controls.Add(this.label3);
            this.StaffPanel.Controls.Add(this.label4);
            this.StaffPanel.Controls.Add(this.label23);
            this.StaffPanel.Controls.Add(this.label15);
            this.StaffPanel.Controls.Add(this.label16);
            this.StaffPanel.Controls.Add(this.StaffPhoneNo);
            this.StaffPanel.Controls.Add(this.DynamicIDLabel);
            this.StaffPanel.Controls.Add(this.label18);
            this.StaffPanel.Controls.Add(this.label20);
            this.StaffPanel.Controls.Add(this.UserProfileImage);
            this.StaffPanel.Controls.Add(this.label22);
            this.StaffPanel.Controls.Add(this.label21);
            this.StaffPanel.Location = new System.Drawing.Point(21, 91);
            this.StaffPanel.Margin = new System.Windows.Forms.Padding(4);
            this.StaffPanel.Name = "StaffPanel";
            this.StaffPanel.Size = new System.Drawing.Size(884, 340);
            this.StaffPanel.TabIndex = 49;
            // 
            // PicLabel
            // 
            this.PicLabel.AutoSize = true;
            this.PicLabel.Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PicLabel.Location = new System.Drawing.Point(1, 154);
            this.PicLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PicLabel.Name = "PicLabel";
            this.PicLabel.Size = new System.Drawing.Size(135, 14);
            this.PicLabel.TabIndex = 13;
            this.PicLabel.Text = "Click to add profile picture";
            // 
            // StaffDesigBox
            // 
            this.StaffDesigBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StaffDesigBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StaffDesigBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffDesigBox.FormattingEnabled = true;
            this.StaffDesigBox.Items.AddRange(new object[] {
            "Operations Manager",
            "Group Fitness Instructor",
            "Certified Personal Trainer",
            "Maintenance Personnel",
            "Service Technician",
            "Front-Desk Staff"});
            this.StaffDesigBox.Location = new System.Drawing.Point(45, 290);
            this.StaffDesigBox.Margin = new System.Windows.Forms.Padding(4);
            this.StaffDesigBox.Name = "StaffDesigBox";
            this.StaffDesigBox.Size = new System.Drawing.Size(224, 25);
            this.StaffDesigBox.TabIndex = 10;
            // 
            // ShiftTimeBox
            // 
            this.ShiftTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShiftTimeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShiftTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShiftTimeBox.FormattingEnabled = true;
            this.ShiftTimeBox.Items.AddRange(new object[] {
            "Morning Shift",
            "Evening Shift"});
            this.ShiftTimeBox.Location = new System.Drawing.Point(695, 208);
            this.ShiftTimeBox.Margin = new System.Windows.Forms.Padding(4);
            this.ShiftTimeBox.Name = "ShiftTimeBox";
            this.ShiftTimeBox.Size = new System.Drawing.Size(167, 25);
            this.ShiftTimeBox.TabIndex = 9;
            // 
            // IDTypeBox
            // 
            this.IDTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.IDTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTypeBox.FormattingEnabled = true;
            this.IDTypeBox.Items.AddRange(new object[] {
            "Driving Licence",
            "Voter ID",
            "Passport",
            "Adhaar Card"});
            this.IDTypeBox.Location = new System.Drawing.Point(337, 290);
            this.IDTypeBox.Margin = new System.Windows.Forms.Padding(4);
            this.IDTypeBox.Name = "IDTypeBox";
            this.IDTypeBox.Size = new System.Drawing.Size(167, 25);
            this.IDTypeBox.TabIndex = 11;
            this.IDTypeBox.SelectedIndexChanged += new System.EventHandler(this.IDTypeBox_SelectedIndexChanged);
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
            this.genderbox.Location = new System.Drawing.Point(132, 208);
            this.genderbox.Margin = new System.Windows.Forms.Padding(4);
            this.genderbox.Name = "genderbox";
            this.genderbox.Size = new System.Drawing.Size(125, 25);
            this.genderbox.TabIndex = 6;
            // 
            // staffjoinedDate
            // 
            this.staffjoinedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.staffjoinedDate.Location = new System.Drawing.Point(692, 39);
            this.staffjoinedDate.Margin = new System.Windows.Forms.Padding(4);
            this.staffjoinedDate.Name = "staffjoinedDate";
            this.staffjoinedDate.Size = new System.Drawing.Size(169, 22);
            this.staffjoinedDate.TabIndex = 4;
            // 
            // StaffAgeBox
            // 
            this.StaffAgeBox.Location = new System.Drawing.Point(520, 208);
            this.StaffAgeBox.Margin = new System.Windows.Forms.Padding(4);
            this.StaffAgeBox.Name = "StaffAgeBox";
            this.StaffAgeBox.Size = new System.Drawing.Size(71, 22);
            this.StaffAgeBox.TabIndex = 8;
            // 
            // StaffSalary
            // 
            this.StaffSalary.Location = new System.Drawing.Point(329, 208);
            this.StaffSalary.Margin = new System.Windows.Forms.Padding(4);
            this.StaffSalary.Name = "StaffSalary";
            this.StaffSalary.Size = new System.Drawing.Size(111, 22);
            this.StaffSalary.TabIndex = 7;
            // 
            // StaffFatherName
            // 
            this.StaffFatherName.Location = new System.Drawing.Point(191, 126);
            this.StaffFatherName.Margin = new System.Windows.Forms.Padding(4);
            this.StaffFatherName.Name = "StaffFatherName";
            this.StaffFatherName.Size = new System.Drawing.Size(163, 22);
            this.StaffFatherName.TabIndex = 1;
            // 
            // StaffNameBox
            // 
            this.StaffNameBox.Location = new System.Drawing.Point(191, 43);
            this.StaffNameBox.Margin = new System.Windows.Forms.Padding(4);
            this.StaffNameBox.Name = "StaffNameBox";
            this.StaffNameBox.Size = new System.Drawing.Size(163, 22);
            this.StaffNameBox.TabIndex = 0;
            this.StaffNameBox.TextChanged += new System.EventHandler(this.StaffNameBox_TextChanged);
            // 
            // StaffIdentityProof
            // 
            this.StaffIdentityProof.ForeColor = System.Drawing.Color.DimGray;
            this.StaffIdentityProof.Location = new System.Drawing.Point(567, 293);
            this.StaffIdentityProof.Margin = new System.Windows.Forms.Padding(4);
            this.StaffIdentityProof.Name = "StaffIdentityProof";
            this.StaffIdentityProof.Size = new System.Drawing.Size(295, 22);
            this.StaffIdentityProof.TabIndex = 12;
            this.StaffIdentityProof.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StaffIdentityProof_KeyPress);
            // 
            // StaffEmailID
            // 
            this.StaffEmailID.Location = new System.Drawing.Point(432, 126);
            this.StaffEmailID.Margin = new System.Windows.Forms.Padding(4);
            this.StaffEmailID.Name = "StaffEmailID";
            this.StaffEmailID.Size = new System.Drawing.Size(163, 22);
            this.StaffEmailID.TabIndex = 3;
            // 
            // staffage
            // 
            this.staffage.AutoSize = true;
            this.staffage.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffage.Location = new System.Drawing.Point(516, 188);
            this.staffage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.staffage.Name = "staffage";
            this.staffage.Size = new System.Drawing.Size(51, 17);
            this.staffage.TabIndex = 1;
            this.staffage.Text = "Age  :";
            // 
            // StaffAddressBox
            // 
            this.StaffAddressBox.Location = new System.Drawing.Point(691, 110);
            this.StaffAddressBox.Margin = new System.Windows.Forms.Padding(4);
            this.StaffAddressBox.Multiline = true;
            this.StaffAddressBox.Name = "StaffAddressBox";
            this.StaffAddressBox.Size = new System.Drawing.Size(161, 48);
            this.StaffAddressBox.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(325, 186);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "Salary  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(691, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shift Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Staff Designation :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(337, 268);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "ID Type :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(688, 90);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 17);
            this.label23.TabIndex = 2;
            this.label23.Text = "Address :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(132, 186);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Gender :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(191, 103);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 17);
            this.label16.TabIndex = 1;
            this.label16.Text = "Father Name :";
            // 
            // StaffPhoneNo
            // 
            this.StaffPhoneNo.Location = new System.Drawing.Point(432, 43);
            this.StaffPhoneNo.Margin = new System.Windows.Forms.Padding(4);
            this.StaffPhoneNo.MaxLength = 14;
            this.StaffPhoneNo.Name = "StaffPhoneNo";
            this.StaffPhoneNo.Size = new System.Drawing.Size(163, 22);
            this.StaffPhoneNo.TabIndex = 2;
            // 
            // DynamicIDLabel
            // 
            this.DynamicIDLabel.AutoSize = true;
            this.DynamicIDLabel.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DynamicIDLabel.Location = new System.Drawing.Point(563, 271);
            this.DynamicIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DynamicIDLabel.Name = "DynamicIDLabel";
            this.DynamicIDLabel.Size = new System.Drawing.Size(280, 17);
            this.DynamicIDLabel.TabIndex = 2;
            this.DynamicIDLabel.Text = "ID Proof (Driving/PanCard/Adhaar):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(187, 18);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 17);
            this.label18.TabIndex = 1;
            this.label18.Text = "Name :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(428, 103);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 17);
            this.label20.TabIndex = 2;
            this.label20.Text = "Email ID :";
            // 
            // UserProfileImage
            // 
            this.UserProfileImage.Image = global::App_Gym.Properties.Resources.user;
            this.UserProfileImage.Location = new System.Drawing.Point(4, 4);
            this.UserProfileImage.Margin = new System.Windows.Forms.Padding(4);
            this.UserProfileImage.Name = "UserProfileImage";
            this.UserProfileImage.Size = new System.Drawing.Size(133, 146);
            this.UserProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserProfileImage.TabIndex = 0;
            this.UserProfileImage.TabStop = false;
            this.UserProfileImage.Click += new System.EventHandler(this.UserProfileImage_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(428, 21);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 17);
            this.label22.TabIndex = 2;
            this.label22.Text = "Phone No :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(688, 18);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 17);
            this.label21.TabIndex = 2;
            this.label21.Text = "Joining Date :";
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
            this.clearallbtn.Location = new System.Drawing.Point(494, 450);
            this.clearallbtn.Name = "clearallbtn";
            this.clearallbtn.Size = new System.Drawing.Size(200, 51);
            this.clearallbtn.TabIndex = 17;
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
            this.Addmemberbutton.Location = new System.Drawing.Point(262, 450);
            this.Addmemberbutton.Name = "Addmemberbutton";
            this.Addmemberbutton.Size = new System.Drawing.Size(200, 51);
            this.Addmemberbutton.TabIndex = 18;
            this.Addmemberbutton.Text = "Add Member";
            this.Addmemberbutton.TextColor = System.Drawing.Color.White;
            this.Addmemberbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Addmemberbutton.UseVisualStyleBackColor = false;
            this.Addmemberbutton.Click += new System.EventHandler(this.Addmemberbutton_Click);
            // 
            // Addstaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearallbtn);
            this.Controls.Add(this.StaffPanel);
            this.Controls.Add(this.Addmemberbutton);
            this.Name = "Addstaff";
            this.Size = new System.Drawing.Size(941, 588);
            this.StaffPanel.ResumeLayout(false);
            this.StaffPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserProfileImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StaffPanel;
        private System.Windows.Forms.Label PicLabel;
        private System.Windows.Forms.ComboBox StaffDesigBox;
        private System.Windows.Forms.ComboBox ShiftTimeBox;
        private System.Windows.Forms.ComboBox IDTypeBox;
        private System.Windows.Forms.ComboBox genderbox;
        private System.Windows.Forms.DateTimePicker staffjoinedDate;
        private System.Windows.Forms.TextBox StaffAgeBox;
        private System.Windows.Forms.TextBox StaffSalary;
        private System.Windows.Forms.TextBox StaffFatherName;
        private System.Windows.Forms.TextBox StaffNameBox;
        private System.Windows.Forms.TextBox StaffIdentityProof;
        private System.Windows.Forms.TextBox StaffEmailID;
        private System.Windows.Forms.Label staffage;
        private System.Windows.Forms.TextBox StaffAddressBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox StaffPhoneNo;
        private System.Windows.Forms.Label DynamicIDLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox UserProfileImage;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private CustomControls.RJControls.RJButton clearallbtn;
        private CustomControls.RJControls.RJButton Addmemberbutton;
    }
}
