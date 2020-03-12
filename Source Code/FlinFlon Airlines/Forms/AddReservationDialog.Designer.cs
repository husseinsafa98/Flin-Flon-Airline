namespace FlinFlon_Airlines
{
    partial class AddReservationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReservationDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Flight = new System.Windows.Forms.ComboBox();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // comboBox_Flight
            // 
            this.comboBox_Flight.FormattingEnabled = true;
            this.comboBox_Flight.Location = new System.Drawing.Point(12, 40);
            this.comboBox_Flight.Name = "comboBox_Flight";
            this.comboBox_Flight.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Flight.TabIndex = 1;
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Items.AddRange(new object[] {
            "First Class",
            "Business Class",
            "Economy Class"});
            this.comboBox_Class.Location = new System.Drawing.Point(160, 40);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Class.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_OK
            // 
            this.button_OK.ForeColor = System.Drawing.Color.Black;
            this.button_OK.Location = new System.Drawing.Point(206, 97);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 32);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "Ok";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.ForeColor = System.Drawing.Color.Black;
            this.button_Cancel.Location = new System.Drawing.Point(94, 97);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 32);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // AddReservationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(29)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(294, 140);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_Class);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Flight);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddReservationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Reservation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        public System.Windows.Forms.ComboBox comboBox_Flight;
        public System.Windows.Forms.ComboBox comboBox_Class;
    }
}