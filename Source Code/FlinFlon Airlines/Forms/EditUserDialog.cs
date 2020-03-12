using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace FlinFlon_Airlines
{
    public partial class EditUserDialog : Form
    {
        public EditUserDialog()
        {
            InitializeComponent();

            // get current user information.
            textBox_Username.Text = UserManager.User.Username;
            textBox_Name.Text = UserManager.User.Name;
            dateTimePicker_DOB.Value = UserManager.User.DateOfBirth;
            textBox_Address.Text = UserManager.User.Address;
            textBox_PhoneNumber.Text = UserManager.User.Number;
            textBox_Email.Text = UserManager.User.Email;
            DialogResult = DialogResult.Cancel;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            // attempt to verify user and log them in.

            // Open database connection.
            SqlConnection sqlCon = Database.OpenConnection();

            // check if username or password are blank and if the passwords are the same.
            if (textBox_Username.Text == "")
            {
                MessageBox.Show("Username cant be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBox_Password.Text != textBox_ConfirmPassword.Text)
            {
                MessageBox.Show("Passwords must match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand cmd = sqlCon.CreateCommand();

            // check if user changed the password.
            if (textBox_Password.Text != "************" && textBox_Password.Text != "")
            {
                // generate new password hash and salt.
                byte[] bytes = new byte[512];
                new Random().NextBytes(bytes);

                string passwordSalt = BitConverter.ToString(bytes).Replace("-", "");
                string passwordHash = UserManager.GeneratePasswordHash(textBox_Username.Text, textBox_Password.Text, passwordSalt);

                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@PasswordSalt", passwordSalt);
                UserManager.User.PasswordHash = passwordHash;
                UserManager.User.PasswordSalt = passwordSalt;
            }

            // update user information.
            cmd.CommandText = "UPDATE Users SET Username=@Username"+ ((textBox_Password.Text != "************" && textBox_Password.Text != "") ? ", PasswordHash=@PasswordHash, PasswordSalt=@PasswordSalt" : "") + " WHERE Person=@ID;" +
                              "UPDATE Persons SET Name=@Name, Number=@Number, DateOfBirth=@DateOfBirth, Address=@Address, Email=@Email WHERE ID=@ID;";

            cmd.Parameters.AddWithValue("@ID", (int)UserManager.User.ID);
            cmd.Parameters.AddWithValue("@Username", textBox_Username.Text);

            cmd.Parameters.AddWithValue("@Name", textBox_Name.Text);
            cmd.Parameters.AddWithValue("@Number", textBox_PhoneNumber.Text.Replace("-", ""));
            cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker_DOB.Value);
            cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
            cmd.Parameters.AddWithValue("@Email", textBox_Email.Text);

            UserManager.User.Username = textBox_Username.Text;
            UserManager.User.Name = textBox_Name.Text;
            UserManager.User.DateOfBirth = dateTimePicker_DOB.Value;
            UserManager.User.Address = textBox_Address.Text;
            UserManager.User.Number = textBox_PhoneNumber.Text.Replace("-", "");
            UserManager.User.Email = textBox_Email.Text;

            // execute command and get result.
            var result = cmd.ExecuteNonQuery();
            if (result > 0)
                DialogResult = DialogResult.OK;

            Close();
        }

        private void TextBox_PhoneNumber_TextChanged(object sender, EventArgs e)
        {
            // format number
            if (textBox_PhoneNumber.Text.Length > 12)
                textBox_PhoneNumber.Text = textBox_PhoneNumber.Text.Substring(0, 12);

            textBox_PhoneNumber.Text = Regex.Replace(textBox_PhoneNumber.Text, "[^0-9-]", "");
            textBox_PhoneNumber.Text = Regex.Replace(textBox_PhoneNumber.Text, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

            textBox_PhoneNumber.SelectionStart = textBox_PhoneNumber.Text.Length;
        }
    }
}
