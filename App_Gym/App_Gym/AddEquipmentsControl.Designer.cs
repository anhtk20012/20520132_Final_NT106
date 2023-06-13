namespace App_Gym
{
    partial class AddEquipmentsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEquipmentsControl));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.EquipmentTypeBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EquipmentCostTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EquipmentQuantityTextbox = new System.Windows.Forms.TextBox();
            this.EquipmentWeightTextbox = new System.Windows.Forms.TextBox();
            this.EquipmentNameTextbox = new System.Windows.Forms.TextBox();
            this.clearallbtn = new CustomControls.RJControls.RJButton();
            this.AddEquipmentButton = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(514, 300);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(153, 22);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.UseWaitCursor = true;
            // 
            // EquipmentTypeBox
            // 
            this.EquipmentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquipmentTypeBox.FormattingEnabled = true;
            this.EquipmentTypeBox.Items.AddRange(new object[] {
            "Machines",
            "Weights",
            "Bars",
            "Others"});
            this.EquipmentTypeBox.Location = new System.Drawing.Point(514, 139);
            this.EquipmentTypeBox.Name = "EquipmentTypeBox";
            this.EquipmentTypeBox.Size = new System.Drawing.Size(153, 24);
            this.EquipmentTypeBox.TabIndex = 12;
            this.EquipmentTypeBox.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(511, 276);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Purchased On";
            this.label7.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(511, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Equipment Weight";
            this.label5.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(262, 276);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Equipment Cost";
            this.label6.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(262, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Equipment Quantity";
            this.label4.UseWaitCursor = true;
            // 
            // EquipmentCostTextbox
            // 
            this.EquipmentCostTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.EquipmentCostTextbox.Location = new System.Drawing.Point(265, 300);
            this.EquipmentCostTextbox.Name = "EquipmentCostTextbox";
            this.EquipmentCostTextbox.Size = new System.Drawing.Size(153, 22);
            this.EquipmentCostTextbox.TabIndex = 15;
            this.EquipmentCostTextbox.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(511, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Equipment Type";
            this.label3.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Equipment Name";
            this.label2.UseWaitCursor = true;
            // 
            // EquipmentQuantityTextbox
            // 
            this.EquipmentQuantityTextbox.Location = new System.Drawing.Point(265, 221);
            this.EquipmentQuantityTextbox.MaxLength = 6;
            this.EquipmentQuantityTextbox.Name = "EquipmentQuantityTextbox";
            this.EquipmentQuantityTextbox.Size = new System.Drawing.Size(153, 22);
            this.EquipmentQuantityTextbox.TabIndex = 13;
            this.EquipmentQuantityTextbox.UseWaitCursor = true;
            this.EquipmentQuantityTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentQuantityTextbox_KeyPress);
            // 
            // EquipmentWeightTextbox
            // 
            this.EquipmentWeightTextbox.Location = new System.Drawing.Point(514, 221);
            this.EquipmentWeightTextbox.Name = "EquipmentWeightTextbox";
            this.EquipmentWeightTextbox.Size = new System.Drawing.Size(153, 22);
            this.EquipmentWeightTextbox.TabIndex = 14;
            this.EquipmentWeightTextbox.UseWaitCursor = true;
            this.EquipmentWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentWeightTextbox_KeyPress);
            // 
            // EquipmentNameTextbox
            // 
            this.EquipmentNameTextbox.Location = new System.Drawing.Point(265, 139);
            this.EquipmentNameTextbox.Name = "EquipmentNameTextbox";
            this.EquipmentNameTextbox.Size = new System.Drawing.Size(153, 22);
            this.EquipmentNameTextbox.TabIndex = 11;
            this.EquipmentNameTextbox.UseWaitCursor = true;
            this.EquipmentNameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentNameTextbox_KeyPress);
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
            this.clearallbtn.Location = new System.Drawing.Point(487, 372);
            this.clearallbtn.Name = "clearallbtn";
            this.clearallbtn.Size = new System.Drawing.Size(230, 51);
            this.clearallbtn.TabIndex = 18;
            this.clearallbtn.Text = "Cancel";
            this.clearallbtn.TextColor = System.Drawing.Color.White;
            this.clearallbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clearallbtn.UseVisualStyleBackColor = false;
            this.clearallbtn.UseWaitCursor = true;
            this.clearallbtn.Click += new System.EventHandler(this.clearallbtn_Click);
            // 
            // AddEquipmentButton
            // 
            this.AddEquipmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(190)))), ((int)(((byte)(49)))));
            this.AddEquipmentButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(190)))), ((int)(((byte)(49)))));
            this.AddEquipmentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddEquipmentButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AddEquipmentButton.BorderRadius = 7;
            this.AddEquipmentButton.BorderSize = 0;
            this.AddEquipmentButton.FlatAppearance.BorderSize = 0;
            this.AddEquipmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEquipmentButton.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.AddEquipmentButton.ForeColor = System.Drawing.Color.White;
            this.AddEquipmentButton.Image = ((System.Drawing.Image)(resources.GetObject("AddEquipmentButton.Image")));
            this.AddEquipmentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddEquipmentButton.Location = new System.Drawing.Point(225, 372);
            this.AddEquipmentButton.Name = "AddEquipmentButton";
            this.AddEquipmentButton.Size = new System.Drawing.Size(230, 51);
            this.AddEquipmentButton.TabIndex = 19;
            this.AddEquipmentButton.Text = "Add Equipment";
            this.AddEquipmentButton.TextColor = System.Drawing.Color.White;
            this.AddEquipmentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddEquipmentButton.UseVisualStyleBackColor = false;
            this.AddEquipmentButton.UseWaitCursor = true;
            this.AddEquipmentButton.Click += new System.EventHandler(this.AddEquipmentButton_Click);
            // 
            // AddEquipmentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearallbtn);
            this.Controls.Add(this.AddEquipmentButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.EquipmentTypeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EquipmentCostTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EquipmentQuantityTextbox);
            this.Controls.Add(this.EquipmentWeightTextbox);
            this.Controls.Add(this.EquipmentNameTextbox);
            this.Name = "AddEquipmentsControl";
            this.Size = new System.Drawing.Size(941, 588);
            this.UseWaitCursor = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddEquipmentsControl_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox EquipmentTypeBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EquipmentCostTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EquipmentQuantityTextbox;
        private System.Windows.Forms.TextBox EquipmentWeightTextbox;
        private System.Windows.Forms.TextBox EquipmentNameTextbox;
        private CustomControls.RJControls.RJButton clearallbtn;
        private CustomControls.RJControls.RJButton AddEquipmentButton;
    }
}
