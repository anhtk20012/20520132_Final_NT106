namespace App_Gym
{
    partial class ViewEquipmentControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewEquipmentControls));
            this.EquipmentDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchbynameBtn = new System.Windows.Forms.PictureBox();
            this.SearchbyIdBtn = new System.Windows.Forms.PictureBox();
            this.SearchbyEquipName = new System.Windows.Forms.TextBox();
            this.SearchbyID = new System.Windows.Forms.TextBox();
            this.EquipmentPanel = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.Updatebtn = new System.Windows.Forms.Button();
            this.PurchasedPicked = new System.Windows.Forms.DateTimePicker();
            this.EquipmentTypeBox = new System.Windows.Forms.ComboBox();
            this.EquipCostbox = new System.Windows.Forms.TextBox();
            this.EquipQuantityBox = new System.Windows.Forms.TextBox();
            this.EquipWeightBox = new System.Windows.Forms.TextBox();
            this.EquipName = new System.Windows.Forms.TextBox();
            this.EquipID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.totalequiplabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.totalspentlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchbynameBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchbyIdBtn)).BeginInit();
            this.EquipmentPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EquipmentDataGridView
            // 
            this.EquipmentDataGridView.AllowUserToAddRows = false;
            this.EquipmentDataGridView.AllowUserToDeleteRows = false;
            this.EquipmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.EquipmentDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.EquipmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EquipmentDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.EquipmentDataGridView.Location = new System.Drawing.Point(4, 297);
            this.EquipmentDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.EquipmentDataGridView.Name = "EquipmentDataGridView";
            this.EquipmentDataGridView.ReadOnly = true;
            this.EquipmentDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.EquipmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.EquipmentDataGridView.RowTemplate.Height = 25;
            this.EquipmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentDataGridView.Size = new System.Drawing.Size(933, 255);
            this.EquipmentDataGridView.TabIndex = 25;
            this.EquipmentDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentDataGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(721, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Refresh";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(724, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // searchbynameBtn
            // 
            this.searchbynameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.searchbynameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchbynameBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchbynameBtn.Image")));
            this.searchbynameBtn.Location = new System.Drawing.Point(623, 11);
            this.searchbynameBtn.Margin = new System.Windows.Forms.Padding(4);
            this.searchbynameBtn.Name = "searchbynameBtn";
            this.searchbynameBtn.Size = new System.Drawing.Size(53, 28);
            this.searchbynameBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchbynameBtn.TabIndex = 21;
            this.searchbynameBtn.TabStop = false;
            this.searchbynameBtn.Click += new System.EventHandler(this.searchbynameBtn_Click);
            // 
            // SearchbyIdBtn
            // 
            this.SearchbyIdBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.SearchbyIdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchbyIdBtn.Image = ((System.Drawing.Image)(resources.GetObject("SearchbyIdBtn.Image")));
            this.SearchbyIdBtn.Location = new System.Drawing.Point(284, 11);
            this.SearchbyIdBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SearchbyIdBtn.Name = "SearchbyIdBtn";
            this.SearchbyIdBtn.Size = new System.Drawing.Size(53, 28);
            this.SearchbyIdBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SearchbyIdBtn.TabIndex = 22;
            this.SearchbyIdBtn.TabStop = false;
            this.SearchbyIdBtn.Click += new System.EventHandler(this.SearchbyIdBtn_Click);
            // 
            // SearchbyEquipName
            // 
            this.SearchbyEquipName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchbyEquipName.ForeColor = System.Drawing.Color.DarkGray;
            this.SearchbyEquipName.Location = new System.Drawing.Point(401, 11);
            this.SearchbyEquipName.Margin = new System.Windows.Forms.Padding(4);
            this.SearchbyEquipName.Name = "SearchbyEquipName";
            this.SearchbyEquipName.Size = new System.Drawing.Size(214, 32);
            this.SearchbyEquipName.TabIndex = 19;
            this.SearchbyEquipName.Text = "Search by Name";
            this.SearchbyEquipName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchbyEquipName_KeyPress);
            // 
            // SearchbyID
            // 
            this.SearchbyID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchbyID.ForeColor = System.Drawing.Color.DarkGray;
            this.SearchbyID.Location = new System.Drawing.Point(63, 11);
            this.SearchbyID.Margin = new System.Windows.Forms.Padding(4);
            this.SearchbyID.Name = "SearchbyID";
            this.SearchbyID.Size = new System.Drawing.Size(214, 32);
            this.SearchbyID.TabIndex = 20;
            this.SearchbyID.Text = "Search by ID";
            this.SearchbyID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchbyID_KeyPress);
            // 
            // EquipmentPanel
            // 
            this.EquipmentPanel.Controls.Add(this.DeleteBtn);
            this.EquipmentPanel.Controls.Add(this.Updatebtn);
            this.EquipmentPanel.Controls.Add(this.PurchasedPicked);
            this.EquipmentPanel.Controls.Add(this.EquipmentTypeBox);
            this.EquipmentPanel.Controls.Add(this.EquipCostbox);
            this.EquipmentPanel.Controls.Add(this.EquipQuantityBox);
            this.EquipmentPanel.Controls.Add(this.EquipWeightBox);
            this.EquipmentPanel.Controls.Add(this.EquipName);
            this.EquipmentPanel.Controls.Add(this.EquipID);
            this.EquipmentPanel.Controls.Add(this.label8);
            this.EquipmentPanel.Controls.Add(this.label3);
            this.EquipmentPanel.Controls.Add(this.label7);
            this.EquipmentPanel.Controls.Add(this.label10);
            this.EquipmentPanel.Controls.Add(this.label2);
            this.EquipmentPanel.Controls.Add(this.label5);
            this.EquipmentPanel.Controls.Add(this.label4);
            this.EquipmentPanel.Controls.Add(this.label6);
            this.EquipmentPanel.Location = new System.Drawing.Point(4, 62);
            this.EquipmentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.EquipmentPanel.Name = "EquipmentPanel";
            this.EquipmentPanel.Size = new System.Drawing.Size(933, 227);
            this.EquipmentPanel.TabIndex = 18;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(508, 180);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(139, 42);
            this.DeleteBtn.TabIndex = 7;
            this.DeleteBtn.Text = "&DELETE";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // Updatebtn
            // 
            this.Updatebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(41)))), ((int)(((byte)(11)))));
            this.Updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebtn.ForeColor = System.Drawing.Color.White;
            this.Updatebtn.Location = new System.Drawing.Point(317, 180);
            this.Updatebtn.Margin = new System.Windows.Forms.Padding(4);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(139, 42);
            this.Updatebtn.TabIndex = 6;
            this.Updatebtn.Text = "&UPDATE";
            this.Updatebtn.UseVisualStyleBackColor = false;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // PurchasedPicked
            // 
            this.PurchasedPicked.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PurchasedPicked.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PurchasedPicked.Location = new System.Drawing.Point(747, 123);
            this.PurchasedPicked.Margin = new System.Windows.Forms.Padding(4);
            this.PurchasedPicked.Name = "PurchasedPicked";
            this.PurchasedPicked.Size = new System.Drawing.Size(157, 27);
            this.PurchasedPicked.TabIndex = 5;
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
            this.EquipmentTypeBox.Location = new System.Drawing.Point(219, 128);
            this.EquipmentTypeBox.Margin = new System.Windows.Forms.Padding(4);
            this.EquipmentTypeBox.Name = "EquipmentTypeBox";
            this.EquipmentTypeBox.Size = new System.Drawing.Size(123, 24);
            this.EquipmentTypeBox.TabIndex = 1;
            // 
            // EquipCostbox
            // 
            this.EquipCostbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipCostbox.Location = new System.Drawing.Point(637, 123);
            this.EquipCostbox.Margin = new System.Windows.Forms.Padding(4);
            this.EquipCostbox.Name = "EquipCostbox";
            this.EquipCostbox.Size = new System.Drawing.Size(88, 26);
            this.EquipCostbox.TabIndex = 4;
            // 
            // EquipQuantityBox
            // 
            this.EquipQuantityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipQuantityBox.Location = new System.Drawing.Point(379, 123);
            this.EquipQuantityBox.Margin = new System.Windows.Forms.Padding(4);
            this.EquipQuantityBox.Name = "EquipQuantityBox";
            this.EquipQuantityBox.Size = new System.Drawing.Size(88, 26);
            this.EquipQuantityBox.TabIndex = 2;
            // 
            // EquipWeightBox
            // 
            this.EquipWeightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipWeightBox.Location = new System.Drawing.Point(505, 123);
            this.EquipWeightBox.Margin = new System.Windows.Forms.Padding(4);
            this.EquipWeightBox.Name = "EquipWeightBox";
            this.EquipWeightBox.Size = new System.Drawing.Size(104, 26);
            this.EquipWeightBox.TabIndex = 3;
            // 
            // EquipName
            // 
            this.EquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipName.Location = new System.Drawing.Point(17, 128);
            this.EquipName.Margin = new System.Windows.Forms.Padding(4);
            this.EquipName.Name = "EquipName";
            this.EquipName.Size = new System.Drawing.Size(173, 26);
            this.EquipName.TabIndex = 0;
            // 
            // EquipID
            // 
            this.EquipID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipID.Location = new System.Drawing.Point(17, 55);
            this.EquipID.Margin = new System.Windows.Forms.Padding(4);
            this.EquipID.Name = "EquipID";
            this.EquipID.ReadOnly = true;
            this.EquipID.Size = new System.Drawing.Size(57, 26);
            this.EquipID.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(332, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 29);
            this.label8.TabIndex = 9;
            this.label8.Text = "Equipment Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(215, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(743, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Purchased Date :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Weight :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantity :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(633, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cost :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.totalequiplabel);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.totalspentlabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 556);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 32);
            this.panel1.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(19, 4);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Total Equipments";
            // 
            // totalequiplabel
            // 
            this.totalequiplabel.AutoSize = true;
            this.totalequiplabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalequiplabel.ForeColor = System.Drawing.Color.White;
            this.totalequiplabel.Location = new System.Drawing.Point(212, 4);
            this.totalequiplabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalequiplabel.Name = "totalequiplabel";
            this.totalequiplabel.Size = new System.Drawing.Size(54, 23);
            this.totalequiplabel.TabIndex = 0;
            this.totalequiplabel.Text = "0000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(300, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(286, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Total Spent On Equipments =";
            // 
            // totalspentlabel
            // 
            this.totalspentlabel.AutoSize = true;
            this.totalspentlabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalspentlabel.ForeColor = System.Drawing.Color.White;
            this.totalspentlabel.Location = new System.Drawing.Point(616, 4);
            this.totalspentlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalspentlabel.Name = "totalspentlabel";
            this.totalspentlabel.Size = new System.Drawing.Size(54, 23);
            this.totalspentlabel.TabIndex = 0;
            this.totalspentlabel.Text = "0000";
            // 
            // ViewEquipmentControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EquipmentDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.searchbynameBtn);
            this.Controls.Add(this.SearchbyIdBtn);
            this.Controls.Add(this.SearchbyEquipName);
            this.Controls.Add(this.SearchbyID);
            this.Controls.Add(this.EquipmentPanel);
            this.Name = "ViewEquipmentControls";
            this.Size = new System.Drawing.Size(941, 588);
            this.Load += new System.EventHandler(this.ViewEquipmentControls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchbynameBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchbyIdBtn)).EndInit();
            this.EquipmentPanel.ResumeLayout(false);
            this.EquipmentPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EquipmentDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox searchbynameBtn;
        private System.Windows.Forms.PictureBox SearchbyIdBtn;
        private System.Windows.Forms.TextBox SearchbyEquipName;
        private System.Windows.Forms.TextBox SearchbyID;
        private System.Windows.Forms.Panel EquipmentPanel;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button Updatebtn;
        private System.Windows.Forms.DateTimePicker PurchasedPicked;
        private System.Windows.Forms.ComboBox EquipmentTypeBox;
        private System.Windows.Forms.TextBox EquipCostbox;
        private System.Windows.Forms.TextBox EquipQuantityBox;
        private System.Windows.Forms.TextBox EquipWeightBox;
        private System.Windows.Forms.TextBox EquipName;
        private System.Windows.Forms.TextBox EquipID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalequiplabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label totalspentlabel;
    }
}
