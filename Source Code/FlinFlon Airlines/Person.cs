using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlinFlon_Airlines
{
    public class Person
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Person()
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The passenger identification number.</param>
        /// <param name="name">The name of the passenger.</param>
        /// <param name="number">The passengers phone number.</param>
        /// <param name="dateOfBirth">The passengers date of birth.</param>
        /// <param name="address">The passengers address.</param>
        /// <param name="email">The passengers email.</param>
        public Person(int id, string name, string number, DateTime dateOfBirth, string address, string email)
        {
            ID = id;
            Name = name;
            Number = number;
            DateOfBirth = dateOfBirth;
            Address = address;
            Email = email;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="person">The person to copy.</param>
        public Person(Person person)
        {
            Name = person.Name;
            ID = person.ID;
            Number = person.Number;
            DateOfBirth = person.DateOfBirth;
            Address = person.Address;
            Email = person.Email;
        }

        /// <summary>
        /// The passenger identification number.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// The name of the passenger.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The passengers phone number.
        /// </summary>
        public string Number { get; set; } = "";

        /// <summary>
        /// The passengers date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; } = new DateTime();

        /// <summary>
        /// The passengers address.
        /// </summary>
        public string Address { get; set; } = "";

        /// <summary>
        /// The passengers email.
        /// </summary>
        public string Email { get; set; } = "";
    }
}
