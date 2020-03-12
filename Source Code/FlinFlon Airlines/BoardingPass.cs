using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlinFlon_Airlines
{
    public class BoardingPass
    {

        /// <summary>
        /// BoardingPass constructor
        /// </summary>
        /// <param name="id"> The boarding pass identification number.</param>
        /// <param name="flightID">The flight identification number.</param>
        /// <param name="passengerID">The passenger identification number.</param>
        /// <param name="seatID">The seat identification number.</param>
        /// <param name="Class">The seating class for this boarding pass.</param>
        /// <param name="issued">Holds if the boarding pass was issued.</param>
        public BoardingPass(int id, int flightID, int passengerID, int seatID, string Class, bool issued)
        {
            ID = id;
            FlightID = flightID;
            PassengerID = passengerID;
            SeatID = seatID;
            this.Class = Class;
            Issued = issued;
        }

        /// <summary>
        /// The boarding pass identification number.
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// The flight identification number.
        /// </summary>
        public int FlightID { get; set; } = 0;

        /// <summary>
        /// The passenger identification number.
        /// </summary>
        public int PassengerID { get; set; } = 0;

        /// <summary>
        /// The seat identification number.
        /// </summary>
        public int SeatID { get; set; } = 0;

        /// <summary>
        /// Returns an instance of the flight based on the flight identification number.
        /// </summary>
        public Flight Flight
        {
            get => Database.GetFlight(FlightID);
        }

        /// <summary>
        /// Returns an instance of the passenger based on the passenger identification number.
        /// </summary>
        public Passenger Passenger
        {
            get => Database.GetPassenger(PassengerID);
        }

        /// <summary>
        /// Returns an instance of the seat based on the seat identification number.
        /// </summary>
        public Seat Seat
        {
            get => Database.GetSeat(SeatID);
        }

        /// <summary>
        /// Get or set whether the boarding pass was issued.
        /// </summary>
        public bool Issued { get; set; }

        /// <summary>
        /// Get or set the seating class connected with the boarding pass.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Creates a bitmap and draws the boarding pass information to it.
        /// </summary>
        /// <returns>Returns the bitmap that was created.</returns>
        public Bitmap ToBitmap()
        {
            #region BoardingPassDrawCode

            Bitmap bitmap = new Bitmap(910, 310);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.FillRectangle(Brushes.LightGray, 2, 2, 900, 300);//draw white screen
                graphics.DrawRectangle(new Pen(Color.Black, 2), 2, 2, 900, 300);//draw a rectangle to the bitmap
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 4, 29, 142)), 4, 4, 896, 86);//draw a rectangle to the bitmap
                graphics.DrawString("Flin Flon Airlines", new Font("Magneto", 36), Brushes.Black, 150, 2);


                // passenger name
                graphics.DrawString("Boarding Pass", new Font("Tahoma", 16, FontStyle.Bold), Brushes.Black, 360, 60);

                graphics.DrawLine(new Pen(Color.Black, 4), 2, 90, 902, 90);

                // passenger name
                graphics.DrawString("Passenger", new Font("Tahoma", 16), Brushes.Black, 10, 110);//20 inc
                graphics.DrawString(Seat.Passenger.Name, new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 13, 140);

                // from
                graphics.DrawString("From", new Font("Tahoma", 16), Brushes.Black, 10, 160);
                graphics.DrawString(string.Format("{0}, {1}, {2}, {3}", Flight.StartDestination.AirportName,
                                                      Flight.StartDestination.Province,
                                                      Flight.StartDestination.City,
                                                      Flight.StartDestination.Country),
                                                    new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 13, 190);

                // to
                graphics.DrawString("To", new Font("Tahoma", 16), Brushes.Black, 10, 210);
                graphics.DrawString(string.Format("{0}, {1}, {2}, {3}", Flight.EndDestination.AirportName,
                                                      Flight.EndDestination.Province,
                                                      Flight.EndDestination.City,
                                                      Flight.EndDestination.Country),
                                                    new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 13, 240);

                // Flight ID
                graphics.DrawString("Flight Number", new Font("Tahoma", 16), Brushes.Black, 380, 110);
                graphics.DrawString(Flight.ID.ToString(), new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 383, 140);

                // Class
                graphics.DrawString("Class", new Font("Tahoma", 16), Brushes.Black, 680, 110);// 80
                graphics.DrawString(Seat.Class, new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 683, 140);

                // Seat
                graphics.DrawString("Seat", new Font("Tahoma", 16), Brushes.Black, 840, 110);
                graphics.DrawString(Seat.SeatNumber, new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 840, 140);

                // Departure Time
                graphics.DrawString("Departure Time", new Font("Tahoma", 16), Brushes.Black, 680, 160);
                graphics.DrawString(Flight.DepartureTime.ToString("MM/dd/yyyy hh:mm tt"), new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 683, 190);

                // Arrival Time
                graphics.DrawString("Arrival Time", new Font("Tahoma", 16), Brushes.Black, 680, 210);
                graphics.DrawString(Flight.ArrivalTime.ToString("MM/dd/yyyy hh:mm tt"), new Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, 683, 240);

            }
            return bitmap;

            #endregion Draw boarding pass
        }
    }
}
