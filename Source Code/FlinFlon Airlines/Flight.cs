using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlinFlon_Airlines
{
    public class Flight
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Flight()
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ID">The flight identification number.</param>
        /// <param name="departureTime">The time of depature.</param>
        /// <param name="arrivalTime">The estimated arrival time.</param>
        /// <param name="startDestination">The start destination.</param>
        /// <param name="endDestination">The end destination.</param>
        /// <param name="price">The price of the flight</param>
        public Flight(int ID, DateTime departureTime, DateTime arrivalTime, Location startDestination, Location endDestination, decimal price)
        {
            this.ID = ID;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            StartDestination = startDestination;
            EndDestination = endDestination;
            Price = price;
        }

        /// <summary>
        /// The flight idetification number.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// The price of the flight.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// A list of all flight reservations.
        /// </summary>
        public List<BoardingPass> Reservations
        {
            get => Database.GetBoardingPasses(" WHERE BoardingPasses.Flight="+ID.ToString());
            //get
            //{
            //    return Database.GetBoardingPasses().FindAll(x => x.Flight.ID == ID);
            //}
        }

        /// <summary>
        /// A list of all seats associated with the flight.
        /// </summary>
        public List<Seat> Seats
        {
            get => Database.GetSeats(ID);
        }

        /// <summary>
        /// The departure time of the flight.
        /// </summary>
        public DateTime DepartureTime { get; set; } = new DateTime(1,1,1);

        /// <summary>
        /// The estimated arrival time of the flight.
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// The start destination of the flight.
        /// </summary>
        public Location StartDestination { get; set; }

        /// <summary>
        /// The end destination of the flight.
        /// </summary>
        public Location EndDestination { get; set; }

    }
}
