namespace MemberMaint
{
    partial class StartDispAll
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
            this.cmbPstatus = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFirstName = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelBday = new System.Windows.Forms.Panel();
            this.btnSearchDate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlastSearch = new System.Windows.Forms.Button();
            this.btnInport = new System.Windows.Forms.Button();
            this.btnSkill = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMilitary = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRecrdCount = new System.Windows.Forms.TextBox();
            this.cmbdate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panDispClients = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4.SuspendLayout();
            this.panelBday.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPstatus
            // 
            this.cmbPstatus.CausesValidation = false;
            this.cmbPstatus.FormattingEnabled = true;
            this.cmbPstatus.Location = new System.Drawing.Point(3, 53);
            this.cmbPstatus.MaxDropDownItems = 16;
            this.cmbPstatus.Name = "cmbPstatus";
            this.cmbPstatus.Size = new System.Drawing.Size(141, 21);
            this.cmbPstatus.TabIndex = 8;
            this.cmbPstatus.SelectedIndexChanged += new System.EventHandler(this.cmbPstatus_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(752, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(142, 20);
            this.txtSearch.TabIndex = 11;
            // 
            // btnFirstName
            // 
            this.btnFirstName.Location = new System.Drawing.Point(752, 6);
            this.btnFirstName.Name = "btnFirstName";
            this.btnFirstName.Size = new System.Drawing.Size(69, 41);
            this.btnFirstName.TabIndex = 12;
            this.btnFirstName.Text = " first name\r\n Search";
            this.btnFirstName.UseVisualStyleBackColor = true;
            this.btnFirstName.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(612, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(51, 27);
            this.btnExport.TabIndex = 64;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button2_Export);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.panelBday);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnlastSearch);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Controls.Add(this.btnInport);
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.btnSkill);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.cmbMilitary);
            this.panel4.Controls.Add(this.txtTitle);
            this.panel4.Controls.Add(this.txtRecrdCount);
            this.panel4.Controls.Add(this.cmbdate);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cmbGroup);
            this.panel4.Controls.Add(this.cmbStatus);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cmbPstatus);
            this.panel4.Controls.Add(this.btnFirstName);
            this.panel4.Location = new System.Drawing.Point(29, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(907, 78);
            this.panel4.TabIndex = 0;
            // 
            // panelBday
            // 
            this.panelBday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelBday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBday.Controls.Add(this.btnSearchDate);
            this.panelBday.Controls.Add(this.label8);
            this.panelBday.Controls.Add(this.dateTimePicker2);
            this.panelBday.Controls.Add(this.label7);
            this.panelBday.Controls.Add(this.dateTimePicker1);
            this.panelBday.Location = new System.Drawing.Point(253, 6);
            this.panelBday.Name = "panelBday";
            this.panelBday.Size = new System.Drawing.Size(211, 64);
            this.panelBday.TabIndex = 66;
            this.panelBday.Visible = false;
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.Location = new System.Drawing.Point(62, 38);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDate.TabIndex = 2;
            this.btnSearchDate.Text = "Start Search";
            this.btnSearchDate.UseVisualStyleBackColor = true;
            this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "to date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM/dd/";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(158, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(49, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "from date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(57, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(49, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Number of members";
            // 
            // btnlastSearch
            // 
            this.btnlastSearch.Location = new System.Drawing.Point(825, 6);
            this.btnlastSearch.Name = "btnlastSearch";
            this.btnlastSearch.Size = new System.Drawing.Size(69, 41);
            this.btnlastSearch.TabIndex = 79;
            this.btnlastSearch.Text = " last name\r\nSearch";
            this.btnlastSearch.UseVisualStyleBackColor = true;
            this.btnlastSearch.Click += new System.EventHandler(this.btnlastSearch_Click);
            // 
            // btnInport
            // 
            this.btnInport.Location = new System.Drawing.Point(664, 0);
            this.btnInport.Name = "btnInport";
            this.btnInport.Size = new System.Drawing.Size(51, 27);
            this.btnInport.TabIndex = 78;
            this.btnInport.Text = "Import";
            this.btnInport.UseVisualStyleBackColor = true;
            this.btnInport.Click += new System.EventHandler(this.btnInport_Click);
            // 
            // btnSkill
            // 
            this.btnSkill.Location = new System.Drawing.Point(662, 52);
            this.btnSkill.Name = "btnSkill";
            this.btnSkill.Size = new System.Drawing.Size(84, 23);
            this.btnSkill.TabIndex = 77;
            this.btnSkill.Text = "Skill search";
            this.btnSkill.UseVisualStyleBackColor = true;
            this.btnSkill.Click += new System.EventHandler(this.btnSkill_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(564, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Military Service";
            // 
            // cmbMilitary
            // 
            this.cmbMilitary.CausesValidation = false;
            this.cmbMilitary.FormattingEnabled = true;
            this.cmbMilitary.Items.AddRange(new object[] {
            "Anniversary",
            "Birth Date",
            "Member Since"});
            this.cmbMilitary.Location = new System.Drawing.Point(560, 53);
            this.cmbMilitary.MaxDropDownItems = 16;
            this.cmbMilitary.Name = "cmbMilitary";
            this.cmbMilitary.Size = new System.Drawing.Size(98, 21);
            this.cmbMilitary.TabIndex = 74;
            this.cmbMilitary.SelectedIndexChanged += new System.EventHandler(this.cmbMilitary_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(144, 1);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(462, 20);
            this.txtTitle.TabIndex = 73;
            this.txtTitle.TabStop = false;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRecrdCount
            // 
            this.txtRecrdCount.Location = new System.Drawing.Point(6, 4);
            this.txtRecrdCount.Name = "txtRecrdCount";
            this.txtRecrdCount.Size = new System.Drawing.Size(32, 20);
            this.txtRecrdCount.TabIndex = 2;
            // 
            // cmbdate
            // 
            this.cmbdate.CausesValidation = false;
            this.cmbdate.FormattingEnabled = true;
            this.cmbdate.Items.AddRange(new object[] {
            "Anniversary",
            "Birth Date",
            "Member Since"});
            this.cmbdate.Location = new System.Drawing.Point(445, 53);
            this.cmbdate.MaxDropDownItems = 16;
            this.cmbdate.Name = "cmbdate";
            this.cmbdate.Size = new System.Drawing.Size(109, 21);
            this.cmbdate.TabIndex = 72;
            this.cmbdate.SelectedIndexChanged += new System.EventHandler(this.cmbdate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(459, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Date Searches";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Select Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Select Member Status";
            // 
            // cmbGroup
            // 
            this.cmbGroup.CausesValidation = false;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(297, 53);
            this.cmbGroup.MaxDropDownItems = 16;
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(141, 21);
            this.cmbGroup.TabIndex = 68;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.CausesValidation = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(150, 53);
            this.cmbStatus.MaxDropDownItems = 16;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(141, 21);
            this.cmbStatus.TabIndex = 67;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Personal Status";
            // 
            // panDispClients
            // 
            this.panDispClients.AutoScroll = true;
            this.panDispClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panDispClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDispClients.Location = new System.Drawing.Point(12, 129);
            this.panDispClients.Name = "panDispClients";
            this.panDispClients.Size = new System.Drawing.Size(948, 452);
            this.panDispClients.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(284, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(403, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // StartDispAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 578);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panDispClients);
            this.Controls.Add(this.panel4);
            this.Name = "StartDispAll";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.StartDispAll_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelBday.ResumeLayout(false);
            this.panelBday.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbPstatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFirstName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panelBday;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRecrdCount;
        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cmbMilitary;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSkill;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnInport;
        private System.Windows.Forms.Button btnlastSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panDispClients;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}