namespace FlinFlon_Airlines
{
    partial class LocationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_AirportName = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Province = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Country = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Airport Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_AirportName
            // 
            this.textBox_AirportName.Location = new System.Drawing.Point(15, 35);
            this.textBox_AirportName.Name = "textBox_AirportName";
            this.textBox_AirportName.Size = new System.Drawing.Size(327, 22);
            this.textBox_AirportName.TabIndex = 1;
            // 
            // textBox_City
            // 
            this.textBox_City.Location = new System.Drawing.Point(351, 35);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.Size = new System.Drawing.Size(199, 22);
            this.textBox_City.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(348, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "City";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_Province
            // 
            this.textBox_Province.Location = new System.Drawing.Point(15, 109);
            this.textBox_Province.Name = "textBox_Province";
            this.textBox_Province.Size = new System.Drawing.Size(153, 22);
            this.textBox_Province.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "State/Province";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_Country
            // 
            this.textBox_Country.Location = new System.Drawing.Point(189, 109);
            this.textBox_Country.Name = "textBox_Country";
            this.textBox_Country.Size = new System.Drawing.Size(105, 22);
            this.textBox_Country.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(186, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Country";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.ForeColor = System.Drawing.Color.Black;
            this.button_OK.Location = new System.Drawing.Point(475, 104);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 30);
            this.button_OK.TabIndex = 8;
            this.button_OK.Text = "Ok";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.ForeColor = System.Drawing.Color.Black;
            this.button_Cancel.Location = new System.Drawing.Point(351, 105);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 30);
            this.button_Cancel.TabIndex = 9;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // LocationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(29)))), ((int)(((byte)(142)))));
            this.ClientSize = new System.Drawing.Size(565, 146);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Country);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Province);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_City);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_AirportName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Location";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        public System.Windows.Forms.TextBox textBox_AirportName;
        public System.Windows.Forms.TextBox textBox_City;
        public System.Windows.Forms.TextBox textBox_Province;
        public System.Windows.Forms.TextBox textBox_Country;
    }
}