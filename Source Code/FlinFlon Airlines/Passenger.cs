using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlinFlon_Airlines
{
    /// <summary>
    /// Passenger seating preference.
    /// </summary>
    public enum SeatingPreference
    {
        None,
        Isle,
        Window,
        Middle
    }
    public class Passenger : Person
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Passenger()
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
        /// <param name="specialAccomodations">The passengers accommodations.</param>
        /// <param name="cost">The amount the passenger owes.</param>
        /// <param name="seatingPreference">The passengers seating preference.</param>
        public Passenger(int id, string name, string number, DateTime dateOfBirth, string address, string email, string specialAccomodations, decimal cost, SeatingPreference seatingPreference) :
            base(id, name, number, dateOfBirth, address, email)
        {
            SpecialAccommodations = specialAccomodations;
            SeatingPreference = seatingPreference;
            Cost = cost;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="person">Person class instance.</param>
        /// <param name="specialAccomodations">The passengers accommodations.</param>
        /// <param name="cost">The amount the passenger owes.</param>
        /// <param name="seatingPreference">The passengers seating preference.</param>
        public Passenger(Person person, string specialAccomodations, decimal cost, SeatingPreference seatingPreference) :
            base(person)
        {
            SpecialAccommodations = specialAccomodations;
            Cost = cost;
            SeatingPreference = seatingPreference;
        }

        /// <summary>
        /// The passengers seating preference.
        /// </summary>
        public SeatingPreference SeatingPreference { get; set; } = SeatingPreference.None;

        /// <summary>
        /// The passengers accommodations.
        /// </summary>
        public string SpecialAccommodations { get; set; } = "";

        /// <summary>
        /// The amount the passenger owes.
        /// </summary>
        public decimal Cost { get; set; } = 0.0M;

        /// <summary>
        /// The boarding passes associated with the passenger.
        /// </summary>
        public List<BoardingPass> BoardingPasses
        {
            get => Database.GetBoardingPasses(ID);
        }
    }
}
