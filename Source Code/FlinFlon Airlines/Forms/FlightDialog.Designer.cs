namespace FlinFlon_Airlines
{
    partial class FlightDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Cost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_ArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_DepartureTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_AddLocation = new System.Windows.Forms.Button();
            this.comboBox_EndDestination = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip_Location = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_StartDestination = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_EconomyClassRows = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_BusinessClassRows = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_FirstClassRows = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_Location.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Departure Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Cost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker_ArrivalTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker_DepartureTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Information";
            // 
            // textBox_Cost
            // 
            this.textBox_Cost.Location = new System.Drawing.Point(9, 113);
            this.textBox_Cost.Name = "textBox_Cost";
            this.textBox_Cost.Size = new System.Drawing.Size(76, 22);
            this.textBox_Cost.TabIndex = 3;
            this.textBox_Cost.Text = "0";
            this.textBox_Cost.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cost";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dateTimePicker_ArrivalTime
            // 
            this.dateTimePicker_ArrivalTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dateTimePicker_ArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ArrivalTime.Location = new System.Drawing.Point(231, 44);
            this.dateTimePicker_ArrivalTime.Name = "dateTimePicker_ArrivalTime";
            this.dateTimePicker_ArrivalTime.Size = new System.Drawing.Size(177, 22);
            this.dateTimePicker_ArrivalTime.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arrival Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dateTimePicker_DepartureTime
            // 
            this.dateTimePicker_DepartureTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dateTimePicker_DepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DepartureTime.Location = new System.Drawing.Point(9, 44);
            this.dateTimePicker_DepartureTime.Name = "dateTimePicker_DepartureTime";
            this.dateTimePicker_DepartureTime.Size = new System.Drawing.Size(177, 22);
            this.dateTimePicker_DepartureTime.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_AddLocation);
            this.groupBox2.Controls.Add(this.comboBox_EndDestination);
            this.groupBox2.Controls.Add(this.comboBox_StartDestination);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 128);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location Information";
            // 
            // button_AddLocation
            // 
            this.button_AddLocation.ForeColor = System.Drawing.Color.Black;
            this.button_AddLocation.Location = new System.Drawing.Point(275, 85);
            this.button_AddLocation.Name = "button_AddLocation";
            this.button_AddLocation.Size = new System.Drawing.Size(133, 31);
            this.button_AddLocation.TabIndex = 11;
            this.button_AddLocation.Text = "Add New Location";
            this.button_AddLocation.UseVisualStyleBackColor = true;
            this.button_AddLocation.Click += new System.EventHandler(this.Button_AddLocation_Click);
            // 
            // comboBox_EndDestination
            // 
            this.comboBox_EndDestination.ContextMenuStrip = this.contextMenuStrip_Location;
            this.comboBox_EndDestination.FormattingEnabled = true;
            this.comboBox_EndDestination.Location = new System.Drawing.Point(231, 44);
            this.comboBox_EndDestination.Name = "comboBox_EndDestination";
            this.comboBox_EndDestination.Size = new System.Drawing.Size(177, 24);
            this.comboBox_EndDestination.TabIndex = 5;
            // 
            // contextMenuStrip_Location
            // 
            this.contextMenuStrip_Location.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_Location.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLocationToolStripMenuItem});
            this.contextMenuStrip_Location.Name = "contextMenuStrip_Location";
            this.contextMenuStrip_Location.Size = new System.Drawing.Size(211, 56);
            this.contextMenuStrip_Location.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_Location_Opening);
            // 
            // editLocationToolStripMenuItem
            // 
            this.editLocationToolStripMenuItem.Name = "editLocationToolStripMenuItem";
            this.editLocationToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.editLocationToolStripMenuItem.Text = "Edit Location";
            this.editLocationToolStripMenuItem.Click += new System.EventHandler(this.EditLocationToolStripMenuItem_Click);
            // 
            // comboBox_StartDestination
            // 
            this.comboBox_StartDestination.ContextMenuStrip = this.contextMenuStrip_Location;
            this.comboBox_StartDestination.FormattingEnabled = true;
            this.comboBox_StartDestination.Location = new System.Drawing.Point(9, 44);
            this.comboBox_StartDestination.Name = "comboBox_StartDestination";
            this.comboBox_StartDestination.Size = new System.Drawing.Size(177, 24);
            this.comboBox_StartDestination.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(228, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "To";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "From";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.ForeColor = System.Drawing.Color.Black;
            this.button_OK.Location = new System.Drawing.Point(521, 294);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(67, 31);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "Ok";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.ForeColor = System.Drawing.Color.Black;
            this.button_Cancel.Location = new System.Drawing.Point(396, 294);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(67, 31);
            this.button_Cancel.TabIndex = 10;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_EconomyClassRows);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBox_BusinessClassRows);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_FirstClassRows);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(423, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(165, 282);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seat Information";
            // 
            // textBox_EconomyClassRows
            // 
            this.textBox_EconomyClassRows.Location = new System.Drawing.Point(9, 234);
            this.textBox_EconomyClassRows.Name = "textBox_EconomyClassRows";
            this.textBox_EconomyClassRows.Size = new System.Drawing.Size(145, 22);
            this.textBox_EconomyClassRows.TabIndex = 8;
            this.textBox_EconomyClassRows.Text = "0";
            this.textBox_EconomyClassRows.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Economy Class Rows";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_BusinessClassRows
            // 
            this.textBox_BusinessClassRows.Location = new System.Drawing.Point(9, 136);
            this.textBox_BusinessClassRows.Name = "textBox_BusinessClassRows";
            this.textBox_BusinessClassRows.Size = new System.Drawing.Size(145, 22);
            this.textBox_BusinessClassRows.TabIndex = 7;
            this.textBox_BusinessClassRows.Text = "0";
            this.textBox_BusinessClassRows.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Business Class Rows";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_FirstClassRows
            // 
            this.textBox_FirstClassRows.Location = new System.Drawing.Point(9, 44);
            this.textBox_FirstClassRows.Name = "textBox_FirstClassRows";
            this.textBox_FirstClassRows.Size = new System.Drawing.Size(145, 22);
            this.textBox_FirstClassRows.TabIndex = 6;
            this.textBox_FirstClassRows.Text = "0";
            this.textBox_FirstClassRows.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "First Class Rows";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FlightDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(29)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(591, 337);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlightDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Flight";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip_Location.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_AddLocation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Location;
        private System.Windows.Forms.ToolStripMenuItem editLocationToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox_Cost;
        public System.Windows.Forms.DateTimePicker dateTimePicker_ArrivalTime;
        public System.Windows.Forms.DateTimePicker dateTimePicker_DepartureTime;
        public System.Windows.Forms.ComboBox comboBox_EndDestination;
        public System.Windows.Forms.ComboBox comboBox_StartDestination;
        public System.Windows.Forms.TextBox textBox_EconomyClassRows;
        public System.Windows.Forms.TextBox textBox_BusinessClassRows;
        public System.Windows.Forms.TextBox textBox_FirstClassRows;
    }
}