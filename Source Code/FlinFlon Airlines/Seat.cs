using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlinFlon_Airlines
{
    public class Seat
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Seat()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The seat identification number.</param>
        /// <param name="seatNumber">The seat number.</param>
        /// <param name="seatingClass">The seat's class.</param>
        /// <param name="passengerID">The passenger associated with the seat.</param>
        /// <param name="flightID">The flight associated with the seat.</param>
        public Seat(int id, string seatNumber, string seatingClass, int passengerID, int flightID)
        {
            ID = id;
            SeatNumber = seatNumber;
            Class = seatingClass;
            PassengerID = passengerID;
            FlightID = flightID;
        }

        /// <summary>
        /// The seat identification number.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// The seat number.
        /// </summary>
        public string SeatNumber { get; set; } = "";

        /// <summary>
        /// The seat's class.
        /// </summary>
        public string Class { get; set; } = "";

        /// <summary>
        /// The passenger associated with the seat.
        /// </summary>
        public int PassengerID { get; set; } = 0;

        /// <summary>
        /// The flight associated with the seat.
        /// </summary>
        public int FlightID { get; set; } = 0;

        /// <summary>
        /// The passenger associated with the seat.
        /// </summary>
        public Passenger Passenger
        {
            get => Database.GetPassenger(PassengerID);
        }

        /// <summary>
        /// The flight associated with the seat.
        /// </summary>
        public Flight Flight
        {
            get => Database.GetFlight(PassengerID);
        }

        /// <summary>
        /// ToString override.
        /// </summary>
        /// <returns>The seat number of this seat instance.</returns>
        public override string ToString()
        {
            return SeatNumber;
        }
    }
}