using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlinFlon_Airlines
{
    public class Location
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The location identification number.</param>
        /// <param name="city">The name of the city.</param>
        /// <param name="province">The name of the state/province.</param>
        /// <param name="country">The country origin.</param>
        /// <param name="airportName">The name of the airport.</param>
        public Location(int id, string city, string province, string country, string airportName)
        {
            ID = id;
            City = city;
            Province = province;
            Country = country;
            AirportName = airportName;
        }

        /// <summary>
        /// Location identification number.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// The name of the city.
        /// </summary>
        public string City { get; set; } = "";

        /// <summary>
        /// The name of the state/province.
        /// </summary>
        public string Province { get; set; } = "";

        /// <summary>
        /// The country origin.
        /// </summary>
        public string Country { get; set; } = "";

        /// <summary>
        /// The name of the airport.
        /// </summary>
        public string AirportName { get; set; } = "";

        /// <summary>
        /// Overrided ToString method.
        /// </summary>
        /// <returns>Returns the city information in the form of a string.</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", AirportName, City, Province, Country);
        }
    }
}
