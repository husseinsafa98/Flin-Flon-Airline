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

namespace FlinFlon_Airlines
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        public User User
        {
            get;
            private set;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Database.OpenConnection();

            using (
                SqlCommand cmd = sqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT Users.Username, Users.PasswordSalt, Users.PasswordHash, Users.PasswordSalt, Users.PrivilegeLevel, Persons.ID AS PID, Persons.Name, Persons.Number, Persons.DateOfBirth, Persons.Address, Persons.Email FROM Users JOIN Persons ON Users.Person = Persons.ID WHERE Username=@Username;";
                cmd.Parameters.AddWithValue("@Username", textBox_Username.Text);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string passwordSalt = (string)reader["PasswordSalt"];
                        string passwordHash = (string)reader["PasswordHash"];
                        if (UserManager.GeneratePasswordHash(textBox_Username.Text, textBox_Password.Text, passwordSalt) == passwordHash)
                        {
                            //Login success
                            User = new User(
                                            (int)reader["PID"],
                                            (string)reader["Name"],
                                            (string)reader["Number"],
                                            (DateTime)reader["DateOfBirth"],
                                            (string)reader["Address"],
                                            (string)reader["Email"],
                                            (string)reader["Username"],
                                            (string)reader["PasswordHash"],
                                            (string)reader["PasswordSalt"],
                                            (PrivilegeLevel)reader["PrivilegeLevel"]);

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                    }
                    label_Error.Visible = true;
                }
            }
        }
    }
}
