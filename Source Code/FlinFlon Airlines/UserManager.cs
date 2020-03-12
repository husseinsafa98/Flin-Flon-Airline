using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FlinFlon_Airlines
{
    public static class UserManager
    {
        /// <summary>
        /// The current logged in user profile.
        /// </summary>
        public static User User { get; set; } = null;

        /// <summary>
        /// Shows the login dialog and sets the User property on success.
        /// </summary>
        /// <returns>Returns true if the user successfully logged in.</returns>
        public static bool Login()
        {
            // if User is not null, a user is already logged in.
            if (User == null)
            {
                // display login dialog and attempt to log user in.
                using (LoginDialog ld = new LoginDialog())
                {
                    if (ld.ShowDialog() == DialogResult.OK)
                    {
                        User = ld.User;
                        return true;
                    }
                    else
                    {
                        User = null;
                        return false;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Logs the current user out.
        /// </summary>
        public static void Logout()
        {
            User = null;
        }

        /// <summary>
        /// Generates a password hash based on the username, password and password salt.
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The user's password.</param>
        /// <param name="passwordSalt">The password salt. This value has to be 1024 characters long.</param>
        /// <returns>Returns the generated password hash if successful otherwise, returns empty string.</returns>
        public static string GeneratePasswordHash(string username, string password, string passwordSalt)
        {
            if (passwordSalt.Length == 1024)
            {
                // build the password string to hash.
                string compiledPasswordString = string.Format("{0}{1}{2}{3}", passwordSalt.Substring(0, 512), username, password, passwordSalt.Substring(512));
                SHA512 sha512 = SHA512Managed.Create(); // create instance of sha512 hash alogorithm class.
                sha512.ComputeHash(Encoding.Default.GetBytes(compiledPasswordString)); // Hash the password string.

                return BitConverter.ToString(sha512.Hash).Replace("-", ""); // return the bytes as a hex string.
            }

            throw new Exception("Password salt must be 1024 characters long.");
        }
    }
}
