namespace FlinFlon_Airlines
{
    partial class AddPassengerDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPassengerDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_DOB = new System.Windows.Forms.DateTimePicker();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Number = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_SpecialAccommodations = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_Preference = new System.Windows.Forms.ComboBox();
            this.textBox_Cost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView_Reservations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_Reservations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.issueBoardingPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_Reservations.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(6, 44);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(209, 22);
            this.textBox_Name.TabIndex = 1;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(6, 113);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(350, 22);
            this.textBox_Address.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(221, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date Of Birth";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dateTimePicker_DOB
            // 
            this.dateTimePicker_DOB.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker_DOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DOB.Location = new System.Drawing.Point(221, 44);
            this.dateTimePicker_DOB.Name = "dateTimePicker_DOB";
            this.dateTimePicker_DOB.Size = new System.Drawing.Size(135, 22);
            this.dateTimePicker_DOB.TabIndex = 2;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(6, 183);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(209, 22);
            this.textBox_Email.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email Address";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_Number
            // 
            this.textBox_Number.Location = new System.Drawing.Point(221, 183);
            this.textBox_Number.Name = "textBox_Number";
            this.textBox_Number.Size = new System.Drawing.Size(135, 22);
            this.textBox_Number.TabIndex = 5;
            this.textBox_Number.TextChanged += new System.EventHandler(this.TextBox_Number_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(221, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone Number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_SpecialAccommodations
            // 
            this.textBox_SpecialAccommodations.Location = new System.Drawing.Point(6, 330);
            this.textBox_SpecialAccommodations.Name = "textBox_SpecialAccommodations";
            this.textBox_SpecialAccommodations.Size = new System.Drawing.Size(350, 22);
            this.textBox_SpecialAccommodations.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(350, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Special Accommodations";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Seating Preference";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // comboBox_Preference
            // 
            this.comboBox_Preference.FormattingEnabled = true;
            this.comboBox_Preference.Items.AddRange(new object[] {
            "None",
            "Isle",
            "Window",
            "Middle"});
            this.comboBox_Preference.Location = new System.Drawing.Point(6, 257);
            this.comboBox_Preference.Name = "comboBox_Preference";
            this.comboBox_Preference.Size = new System.Drawing.Size(146, 24);
            this.comboBox_Preference.TabIndex = 6;
            // 
            // textBox_Cost
            // 
            this.textBox_Cost.Location = new System.Drawing.Point(221, 257);
            this.textBox_Cost.Name = "textBox_Cost";
            this.textBox_Cost.Size = new System.Drawing.Size(135, 22);
            this.textBox_Cost.TabIndex = 7;
            this.textBox_Cost.Text = "0";
            this.textBox_Cost.TextChanged += new System.EventHandler(this.TextBox_Cost_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(221, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cost";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Cost);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_Preference);
            this.groupBox1.Controls.Add(this.textBox_Address);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_SpecialAccommodations);
            this.groupBox1.Controls.Add(this.dateTimePicker_DOB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_Number);
            this.groupBox1.Controls.Add(this.textBox_Email);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 372);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_Reservations);
            this.groupBox2.Controls.Add(this.button_Remove);
            this.groupBox2.Controls.Add(this.button_Add);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(375, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 372);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flight Reservations";
            // 
            // listView_Reservations
            // 
            this.listView_Reservations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Reservations.ContextMenuStrip = this.contextMenuStrip_Reservations;
            this.listView_Reservations.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView_Reservations.FullRowSelect = true;
            this.listView_Reservations.GridLines = true;
            this.listView_Reservations.Location = new System.Drawing.Point(3, 18);
            this.listView_Reservations.Name = "listView_Reservations";
            this.listView_Reservations.Size = new System.Drawing.Size(407, 306);
            this.listView_Reservations.TabIndex = 6;
            this.listView_Reservations.UseCompatibleStateImageBehavior = false;
            this.listView_Reservations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Flight Number";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Class";
            this.columnHeader2.Width = 159;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Seat";
            this.columnHeader3.Width = 131;
            // 
            // contextMenuStrip_Reservations
            // 
            this.contextMenuStrip_Reservations.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Reservations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueBoardingPassToolStripMenuItem});
            this.contextMenuStrip_Reservations.Name = "contextMenuStrip_Reservations";
            this.contextMenuStrip_Reservations.Size = new System.Drawing.Size(207, 28);
            this.contextMenuStrip_Reservations.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Reservations_Opening);
            // 
            // issueBoardingPassToolStripMenuItem
            // 
            this.issueBoardingPassToolStripMenuItem.Name = "issueBoardingPassToolStripMenuItem";
            this.issueBoardingPassToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.issueBoardingPassToolStripMenuItem.Text = "Issue Boarding Pass";
            this.issueBoardingPassToolStripMenuItem.Click += new System.EventHandler(this.IssueBoardingPassToolStripMenuItem_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.ForeColor = System.Drawing.Color.Black;
            this.button_Remove.Location = new System.Drawing.Point(6, 330);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 36);
            this.button_Remove.TabIndex = 11;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // button_Add
            // 
            this.button_Add.ForeColor = System.Drawing.Color.Black;
            this.button_Add.Location = new System.Drawing.Point(338, 330);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(69, 36);
            this.button_Add.TabIndex = 9;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.ForeColor = System.Drawing.Color.Black;
            this.button_OK.Location = new System.Drawing.Point(713, 380);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 27);
            this.button_OK.TabIndex = 10;
            this.button_OK.Text = "Ok";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // AddPassengerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(29)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPassengerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Passenger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip_Reservations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DOB;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Number;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_SpecialAccommodations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_Preference;
        private System.Windows.Forms.TextBox textBox_Cost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.ListView listView_Reservations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Reservations;
        private System.Windows.Forms.ToolStripMenuItem issueBoardingPassToolStripMenuItem;
    }
}