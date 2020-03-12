using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlinFlon_Airlines
{
    /// <summary>
    /// The User's privilege level.
    /// </summary>
    public enum PrivilegeLevel
    {
        Admin,
        BookingAgent
    }
    public class User : Person
    {
        // property backing
        private string m_PasswordSalt;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The user's identification number.</param>
        /// <param name="name">The user's name.</param>
        /// <param name="number">The user's number.</param>
        /// <param name="dateOfBirth">The user's date of birth.</param>
        /// <param name="address">The user's address.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="username">The user's username.</param>
        /// <param name="passwordHash">The user's password hash.</param>
        /// <param name="passwordSalt">The user's password salt.</param>
        /// <param name="privilegeLevel">The user's privilege level.</param>
        public User(int id, string name, string number, DateTime dateOfBirth, string address, string email, string username, string passwordHash, string passwordSalt, PrivilegeLevel privilegeLevel) :
            base(id, name, number, dateOfBirth, address, email)
        {
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            PrivilegeLevel = privilegeLevel;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="person">The person instance of the user.</param>
        /// <param name="username">The user's username.</param>
        /// <param name="passwordHash">The user's password hash.</param>
        /// <param name="passwordSalt">The user's password salt.</param>
        /// <param name="privilegeLevel">The user's privilege level.</param>
        public User(Person person, string username, string passwordHash, string passwordSalt, PrivilegeLevel privilegeLevel) :
            base(person)
        {
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            PrivilegeLevel = privilegeLevel;
        }

        /// <summary>
        /// The user's username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's password hash.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// The user's password salt.
        /// </summary>
        public string PasswordSalt
        {
            get => m_PasswordSalt;
            set
            {
                if (value.Length == 1024)
                    m_PasswordSalt = value;
                else
                    throw new Exception("Password salt must be 1024 characters in length.");
            }
        }

        /// <summary>
        /// The user's privilege level.
        /// </summary>
        public PrivilegeLevel PrivilegeLevel { get; set; }
    }
}
