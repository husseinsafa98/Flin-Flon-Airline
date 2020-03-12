using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FlinFlon_Airlines
{
    public static class Database
    {
        /// <summary>
        /// Creates and opens a connection to the SQL database.
        /// </summary>
        /// <returns>Returns a connection to the SQL database.</returns>
        public static SqlConnection OpenConnection()
        {
            // create SqlConnection instance and pass in the database connection string.
            var sqlConnection = new SqlConnection(Properties.Settings.Default.FlinFlonConnectionString);

            // open the database connection if its not already open.
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            // return instance of the connection.
            return sqlConnection;
        }

        /// <summary>
        /// Checks if a specific entry exists in the database.
        /// </summary>
        /// <param name="table">The name of the sql table</param>
        /// <param name="paramName">The name of the sql column</param>
        /// <param name="value">The value to check for in the given table and column</param>
        /// <returns>Returns true if the entry exists in the database.</returns>
        public static bool EntryExists(string table, string paramName, string value)
        {
            bool ret = false;
            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = string.Format("SELECT {1} FROM {0} WHERE {1}='{2}';", table, paramName, value);

            // Execute command and create instance of SqlDataReader.
            if (command.ExecuteReader().Read())
                ret = true;

            sqlConnection.Close();
            return ret;
        }

        #region GetFunctions

        /// <summary>
        /// Gets all the stored locations in the database.
        /// </summary>
        /// <returns>Returns a list containing all the locations.</returns>
        public static List<Location> GetLocations()
        {
            var locations = new List<Location>();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Locations;";

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read all entries in Locations table and add them to the list of locations.
            while (reader.Read())
            {
                locations.Add(new Location((int)reader["ID"], (string)reader["City"], (string)reader["Province"], (string)reader["Country"], (string)reader["AirportName"]));
            }

            // Close the reader and sql connection then return the list.
            reader.Close();
            sqlConnection.Close();
            return locations;
        }

        /// <summary>
        /// Gets a specific location from the database.
        /// </summary>
        /// <param name="id">The identification number of the location.</param>
        /// <returns></returns>
        public static Location GetLocation(int id)
        {
            var location = new Location();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Locations WHERE ID=@ID;";
            command.Parameters.AddWithValue("@ID", id);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read the entry from the Locations table.
            if (reader.Read())
            {
                location = new Location((int)reader["ID"], (string)reader["City"], (string)reader["Province"], (string)reader["Country"], (string)reader["AirportName"]);
            }

            // Close the reader and sql connection then return the location.
            reader.Close();
            sqlConnection.Close();
            return location;
        }

        /// <summary>
        /// Reads all the flights from the database.
        /// </summary>
        /// <returns>Returns a list containing all the flights in the database.</returns>
        public static List<Flight> GetFlights()
        {
            var flights = new List<Flight>();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();

            // This command will select all flights and their start/end destinations.
            command.CommandText = "SELECT Flights.ID AS FID, Flights.DepartureTime, Flights.ArrivalTime, Flights.StartDestination, Flights.EndDestination, Flights.Price, Locations.ID AS LID, Locations.City, Locations.Province, Locations.Country, Locations.AirportName FROM Flights JOIN Locations ON Flights.StartDestination = Locations.ID OR Flights.EndDestination = Locations.ID;";

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read all entries in Flights table and add them to the list of flights.
            while (reader.Read())
            {
                // Check if the flight already exists in the list. If it exists, we will remove it then add it back with the updated information.
                var flight = flights.FirstOrDefault(x => x.ID == (uint)(int)reader["FID"]);
                if (flight == null)
                {
                    // Read the flight information from the database.
                    flight = new Flight()
                    {
                        ID = (int)reader["FID"], // flight identification.
                        DepartureTime = (DateTime)reader["DepartureTime"],
                        ArrivalTime = (DateTime)reader["ArrivalTime"],
                        Price = (decimal)reader["Price"]
                    };
                }
                else
                    flights.Remove(flight); // Remove flight from the database.

                // Check if the location being read in is the start or end destination.
                if ((uint)(int)reader["LID"] == (int)reader["StartDestination"])
                {
                    flight.StartDestination = new Location((int)reader["LID"], (string)reader["City"], (string)reader["Province"], (string)reader["Country"], (string)reader["AirportName"]);
                }
                else if ((uint)(int)reader["LID"] == (int)reader["EndDestination"])
                {
                    flight.EndDestination = new Location((int)reader["LID"], (string)reader["City"], (string)reader["Province"], (string)reader["Country"], (string)reader["AirportName"]);
                }

                // add flight to the list.
                flights.Add(flight);
            }

            // Close the reader and sql connection then return the list.
            reader.Close();
            sqlConnection.Close();
            return flights;
        }

        /// <summary>
        /// Reads the specified flight from the database.
        /// </summary>
        /// <param name="flightID">The identification number of the flight to read.</param>
        /// <returns>Returns the flight if successful, otherwise a default flight instance with an empty id will be created.</returns>
        public static Flight GetFlight(int flightID)
        {
            Flight flight = null;

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();

            // This command will select all flights and their start/end destinations.
            command.CommandText = "SELECT Flights.ID AS FID, Flights.DepartureTime, Flights.ArrivalTime, Flights.StartDestination, Flights.EndDestination, Flights.Price, Locations.ID AS LID, Locations.City, Locations.Province, Locations.Country, Locations.AirportName FROM Flights JOIN Locations ON Flights.StartDestination = Locations.ID OR Flights.EndDestination = Locations.ID WHERE Flights.ID = @ID;";
            command.Parameters.AddWithValue("@ID", flightID);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read the flight and both locations from the database.
            while (reader.Read())
            {
                if (flight == null)
                {
                    flight = new Flight()
                    {
                        // Read the flight information from the database.
                        ID = (int)reader["FID"],
                        DepartureTime = (DateTime)reader["DepartureTime"],
                        ArrivalTime = (DateTime)reader["ArrivalTime"],
                        Price = (decimal)reader["Price"]
                    };
                }

                // Check if the location being read in is the start or end destination.
                if ((uint)(int)reader["LID"] == (int)reader["StartDestination"])
                {
                    flight.StartDestination = new Location((int)reader["LID"], (string)reader["City"], (string)reader["Province"], (string)reader["Country"], (string)reader["AirportName"]);
                }
                else if ((uint)(int)reader["LID"] == (int)reader["EndDestination"])
                {
                    flight.EndDestination = new Location((int)reader["LID"], (string)reader["City"], (string)reader["Province"], (string)reader["Country"], (string)reader["AirportName"]);
                }
            }

            // Close the reader and sql connection then return the flight.
            reader.Close();
            sqlConnection.Close();
            return flight;
        }

        /// <summary>
        /// Reads all the passengers from the database.
        /// </summary>
        /// <returns>Returns a list populated with all the passengers in the database.</returns>
        public static List<Passenger> GetPassengers()
        {
            var passengers = new List<Passenger>();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT Persons.ID AS PID, Persons.Name, Persons.Number, Persons.DateOfBirth, Persons.Address, Persons.Email, Passengers.SpecialAccommodations, Passengers.Cost, Passengers.SeatingPreference FROM Passengers JOIN Persons ON Persons.ID=Passengers.Person;";

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read all entries in Passengers table and add them to the list of passengers.
            while (reader.Read())
            {
                passengers.Add(new Passenger((int)reader["PID"], 
                    (string)reader["Name"], 
                    (string)reader["Number"], 
                    (DateTime)reader["DateOfBirth"],
                    (string)reader["Address"],
                    (string)reader["Email"],
                    (string)reader["SpecialAccommodations"],
                    (decimal)reader["Cost"],
                    (SeatingPreference)reader["SeatingPreference"]));
            }

            // Close the reader and sql connection then return the list.
            reader.Close();
            sqlConnection.Close();
            return passengers;
        }

        /// <summary>
        /// Reads all the seats connected to a specific flight.
        /// </summary>
        /// <param name="flightID">The flight identification number connected with the seats.</param>
        /// <returns>Returns all the seats connected to the specified flight.</returns>
        public static List<Seat> GetSeats(int flightID)
        {
            List<Seat> seats = new List<Seat>();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Seats WHERE Seats.Flight=@ID;";
            command.Parameters.AddWithValue("@ID", flightID);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read all the seats then add them to the database.
            while (reader.Read())
            {
                seats.Add(new Seat((int)reader["ID"], (string)reader["SeatNumber"], (string)reader["Class"], (int)reader["Passenger"], (int)reader["Flight"]));
            }

            // Close the reader and sql connection then return the list.
            reader.Close();
            sqlConnection.Close();
            return seats;
        }

        /// <summary>
        /// Reads all boarding passes from the database satisfying the given condition or all if no condition is specified.
        /// </summary>
        /// <param name="condition">A sql condition to be added to the sql command.</param>
        /// <returns></returns>
        public static List<BoardingPass> GetBoardingPasses(string condition = "")
        {
            List<BoardingPass> boardingPasses = new List<BoardingPass>();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = string.Format("SELECT * FROM BoardingPasses{0};", condition);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read all entries in boarding passes from the database.
            while (reader.Read())
            {
                boardingPasses.Add(new BoardingPass((int)reader["ID"], (int)reader["Flight"], (int)reader["Passenger"], (int)reader["Seat"], (string)reader["Class"], (bool)reader["Issued"]));
            }

            // Close the reader and sql connection then return the list.
            reader.Close();
            sqlConnection.Close();
            return boardingPasses;
        }

        /// <summary>
        /// Reads passenger from the database according to the specified identification number.
        /// </summary>
        /// <param name="id">The passenger identification number.</param>
        /// <returns></returns>
        public static Passenger GetPassenger(int id)
        {
            Passenger passenger = new Passenger();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Passengers JOIN Persons ON Persons.ID=Passengers.Person WHERE Persons.ID=@ID;";
            command.Parameters.AddWithValue("@ID", id);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read passenger from the database.
            if (reader.Read())
            {
                passenger = new Passenger((int)reader["Person"],
                    (string)reader["Name"],
                    (string)reader["Number"],
                    (DateTime)reader["DateOfBirth"],
                    (string)reader["Address"],
                    (string)reader["Email"],
                    (string)reader["SpecialAccommodations"],
                    (decimal)reader["Cost"],
                    (SeatingPreference)reader["SeatingPreference"]);
            }

            // Close the reader and sql connection then return the passenger.
            reader.Close();
            sqlConnection.Close();
            return passenger;
        }

        /// <summary>
        /// Reads all the boarding passes associated with the passenger identification number from the database.
        /// </summary>
        /// <param name="passengerID">The passenger identification number.</param>
        /// <returns>Returns all boarding passes associated with the passenger.</returns>
        public static List<BoardingPass> GetBoardingPasses(int passengerID)
        {
            var boardingPasses = new List<BoardingPass>();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM BoardingPasses WHERE BoardingPasses.Passenger=@ID";
            command.Parameters.AddWithValue("@ID", passengerID);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read all of the boarding passes from the database.
            while (reader.Read())
            {
                boardingPasses.Add(new BoardingPass((int)reader["ID"], (int)reader["Flight"], (int)reader["Passenger"], (int)reader["Seat"], (string)reader["Class"], (bool)reader["Issued"]));
            }

            // Close the reader and sql connection then return the list.
            reader.Close();
            sqlConnection.Close();
            return boardingPasses;
        }

        /// <summary>
        /// Read a seat from the database according to the specified id number.
        /// </summary>
        /// <param name="id">The identification number of the seat.</param>
        /// <returns>Returns an instance of the seat if successful. Otherwise, returns a new seat instance.</returns>
        public static Seat GetSeat(int id)
        {
            var seat = new Seat();

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Seats WHERE ID=@ID";
            command.Parameters.AddWithValue("@ID", id);

            // Execute command and create instance of SqlDataReader.
            SqlDataReader reader = command.ExecuteReader();

            // Read seat from the database.
            if (reader.Read())
            {
                seat = new Seat((int)reader["ID"], (string)reader["SeatNumber"], (string)reader["Class"], (int)reader["Passenger"], (int)reader["Flight"]);
            }

            // Close the reader and sql connection then return the seat.
            reader.Close();
            sqlConnection.Close();
            return seat;
        }

        #endregion Get Functions

        #region SetFunctions

        /// <summary>
        /// Writes the given boarding pass to the database.
        /// </summary>
        /// <param name="boardingPass">The boarding pass instance to write to the database.</param>
        /// <returns>Returns true if the operation was successful.</returns>
        public static bool SaveBoardingPass(BoardingPass boardingPass)
        {
            string cmd;
            // check if the seat associated with the boarding pass exists. If so, save the seat.
            if (boardingPass.SeatID != 0)
            {
                // Get seat instance.
                Seat seat = boardingPass.Seat;
                
                // Set the passenger id of the seat to the passenger referenced in the boarding pass.
                seat.PassengerID = boardingPass.PassengerID;

                // Save seat to the database.
                Database.SaveSeat(Database.OpenConnection(), seat);
            }

            // Check if the boarding pass already exists. If so, we will update the entry. Otherwise, we will create a new entry.
            if(EntryExists("BoardingPasses","ID",boardingPass.ID.ToString()))
            {
                cmd = "UPDATE BoardingPasses SET Flight=@Flight, Passenger=@Passenger, Seat=@Seat, Class=@Class, Issued=@Issued WHERE ID=@ID";
            }
            else
            {
                cmd = "INSERT INTO BoardingPasses (Flight, Passenger, Seat, Class, Issued) VALUES (@Flight, @Passenger, @Seat, @Class, @Issued);";
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = cmd;
            
            // If we are updating the entry, we will need the ID number as a parameter.
            if(cmd.StartsWith("UPDATE"))
                command.Parameters.AddWithValue("@ID", boardingPass.ID);

            command.Parameters.AddWithValue("@Flight", boardingPass.FlightID);
            command.Parameters.AddWithValue("@Passenger", boardingPass.PassengerID);
            command.Parameters.AddWithValue("@Seat", boardingPass.SeatID);
            command.Parameters.AddWithValue("@Class", boardingPass.Class);
            command.Parameters.AddWithValue("@Issued", boardingPass.Issued);

            // Execute command and get result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Writes the given seat to the database.
        /// </summary>
        /// <param name="sqlConnection">The sql database connection.</param>
        /// <param name="seat">The seat to be written to the database.</param>
        /// <returns>Returns true if the operation was successful.</returns>
        public static bool SaveSeat(SqlConnection sqlConnection, Seat seat)
        {
            string cmd;

            // Check if the seat already exists. If so, we will update the entry. Otherwise, we will create a new entry.
            if (EntryExists("Seats", "ID", seat.ID.ToString()))
            {
                cmd = "UPDATE Seats SET SeatNumber=@SeatNumber, Passenger=@Passenger, Flight=@Flight, Class=@Class WHERE ID=@ID";
            }
            else
            {
                cmd = "INSERT INTO Seats (SeatNumber, Passenger, Flight, Class) VALUES (@SeatNumber, @Passenger, @Flight, @Class);";
            }

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = cmd;

            // If we are updating the entry, we will need the ID number as a parameter.
            if (cmd.StartsWith("UPDATE"))
                command.Parameters.AddWithValue("@ID", seat.ID);

            command.Parameters.AddWithValue("@SeatNumber", seat.SeatNumber);
            command.Parameters.AddWithValue("@Passenger", seat.PassengerID);
            command.Parameters.AddWithValue("@Flight", seat.FlightID);
            command.Parameters.AddWithValue("@Class", seat.Class);

            // Execute command and get result.
            bool result = command.ExecuteNonQuery() > 0;

            // return the result.
            return result;
        }

        /// <summary>
        /// Writes the person to the database.
        /// </summary>
        /// <param name="person">The person to store in the database.</param>
        /// <returns>Returns true if the operation was successful.</returns>
        public static bool SavePerson(Person person)
        {
            string cmd;

            // Check if the person exists. If so, we will update the entry. Otherwise, we will create a new entry.
            if (EntryExists("Persons", "ID", person.ID.ToString()))
            {
                cmd = "UPDATE Persons SET Name=@Name, Number=@Number, DateOfBirth=@DateOfBirth, Address=@Address, Email=@Email WHERE ID=@ID";
            }
            else
            {
                cmd = "INSERT INTO Persons (Name, Number, DateOfBirth, Address, Email) OUTPUT INSERTED.ID VALUES (@Name, @Number, @DateOfBirth, @Address, @Email);";
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = cmd;
            command.Parameters.AddWithValue("@ID", person.ID);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Number", person.Number);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Email", person.Email);

            bool result;

            // If we are updating the entry, just update.
            if (cmd.StartsWith("UPDATE"))
            {
                result = command.ExecuteNonQuery() > 0;
            }
            else
            {
                // Insert the entry into the database and get the outputted identification number.
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    person.ID = (int)reader["ID"];
                    result = true;
                }
                else
                    result = false;

                // Close sql reader
                reader.Close();
            }

            // Close sql connection and return the result of the operation.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Write the specified pasenger to the database.
        /// </summary>
        /// <param name="passenger">The passenger to save.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool SavePassenger(Passenger passenger)
        {
            // Save the person to the database.
            SavePerson(passenger);

            string cmd;

            // Check if the passenger exists. If so, we will update the entry. Otherwise, we will create a new entry.
            if (EntryExists("Passengers", "Person", passenger.ID.ToString()))
            {
                cmd = "UPDATE Passengers SET SpecialAccommodations=@SpecialAccommodations, Cost=@Cost, SeatingPreference=@SeatingPreference WHERE Person=@ID";
            }
            else
            {
                cmd = "INSERT INTO Passengers (SpecialAccommodations, Cost, SeatingPreference, Person) VALUES (@SpecialAccommodations, @Cost, @SeatingPreference, @ID);";
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = cmd;
            command.Parameters.AddWithValue("@ID", passenger.ID);
            command.Parameters.AddWithValue("@SpecialAccommodations", passenger.SpecialAccommodations);
            command.Parameters.AddWithValue("@Cost", passenger.Cost);
            command.Parameters.AddWithValue("@SeatingPreference", (int)passenger.SeatingPreference);

            // Execute command and get result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Writes the specified location to the database.
        /// </summary>
        /// <param name="location">The location to save.</param>
        /// <returns>Returns true if operation was successful. Otherwise, returns false.</returns>
        public static bool SaveLocation(Location location)
        {
            string cmd;

            // Check if the location exists. If so, we will update the entry. Otherwise, we will create a new entry.
            if (EntryExists("Locations", "ID", location.ID.ToString()))
            {
                cmd = "UPDATE Locations SET City=@City, Province=@Province, Country=@Country, AirportName=@AirportName WHERE ID=@ID";
            }
            else
            {
                cmd = "INSERT INTO Locations (City, Province, Country, AirportName) VALUES (@City, @Province, @Country, @AirportName);";
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = cmd;

            // If we are updating the entry, we will need the ID as a parameter.
            if(cmd.StartsWith("UPDATE"))
                command.Parameters.AddWithValue("@ID", location.ID);
            command.Parameters.AddWithValue("@City", location.City);
            command.Parameters.AddWithValue("@Province", location.Province);
            command.Parameters.AddWithValue("@Country", location.Country);
            command.Parameters.AddWithValue("@AirportName", location.AirportName);

            // Execute command and get result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Writes the specified flight to the database.
        /// </summary>
        /// <param name="flight">The flight to store.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool SaveFlight(ref Flight flight)
        {
            string cmd;

            // Check if the flight exists. If so, we will update the entry. Otherwise, we will create a new entry.
            if (EntryExists("Flights", "ID", flight.ID.ToString()))
            {
                cmd = "UPDATE Flights SET DepartureTime=@DepartureTime, ArrivalTime=@ArrivalTime, StartDestination=@StartDestination, EndDestination=@EndDestination, Price=@Price WHERE ID=@ID";
            }
            else
            {
                cmd = "INSERT INTO Flights (DepartureTime, ArrivalTime, StartDestination, EndDestination, Price) OUTPUT INSERTED.ID VALUES (@DepartureTime, @ArrivalTime, @StartDestination, @EndDestination, @Price);";
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = cmd;
            command.Parameters.AddWithValue("@DepartureTime", flight.DepartureTime);
            command.Parameters.AddWithValue("@ArrivalTime", flight.ArrivalTime);
            command.Parameters.AddWithValue("@StartDestination", flight.StartDestination.ID);
            command.Parameters.AddWithValue("@EndDestination", flight.EndDestination.ID);
            command.Parameters.AddWithValue("@Price", flight.Price);

            bool result = false;

            // If we are updating the entry, we will need the ID as a parameter.
            if (cmd.StartsWith("UPDATE"))
            {
                command.Parameters.AddWithValue("@ID", flight.ID);
                result = command.ExecuteNonQuery() > 0;
            }
            else
            {
                // Insert the new entry to the database then get the outputted identification number.
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    flight.ID = (int)reader["ID"];
                    result = true;
                }
                else
                    result = false;

                reader.Close();
            }

            // Close the sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        #endregion Set Functions

        #region RemoveFunctions

        /// <summary>
        /// Removes the specified boarding pass from the database.
        /// </summary>
        /// <param name="boardingPass">The boarding pass to remove.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool RemoveBoardingPass(BoardingPass boardingPass)
        {
            // check if the boarding pass has a seat associated with it. If so, remove the passenger from it.
            if (boardingPass.SeatID > 0)
            {
                Seat seat = boardingPass.Seat;
                seat.PassengerID = 0;

                // Save the seat.
                SaveSeat(Database.OpenConnection(), seat);
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM BoardingPasses WHERE ID=@ID;";
            command.Parameters.AddWithValue("@ID", boardingPass.ID);

            // Execute the sql command then store the result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close the sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Removes the specified person from the database.
        /// </summary>
        /// <param name="person">The person to remove from the database.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool RemovePerson(Person person)
        {
            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Persons WHERE ID=@ID;";
            command.Parameters.AddWithValue("@ID", person.ID);

            // Execute the sql command then store the result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close the sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Removes the specified passenger from the database.
        /// </summary>
        /// <param name="passenger">The passenger to remove.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool RemovePassenger(Passenger passenger)
        {
            // Remove the person from the database.
            RemovePerson(passenger);

            // Check if the passenger has any boarding passes associated with them. If so, then remove the boarding pass.
            var boardingPasses = passenger.BoardingPasses;
            if (boardingPasses.Count > 0)
            {
                foreach (var boardingPass in boardingPasses)
                {
                    RemoveBoardingPass(boardingPass);
                }
            }

            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Passengers WHERE Person=@ID;";
            command.Parameters.AddWithValue("@ID", passenger.ID);

            // Execute the sql command then store the result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close the sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Remove the specified seat from the database.
        /// </summary>
        /// <param name="seat">The seat to remove.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool RemoveSeat(Seat seat)
        {
            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Seats WHERE ID=@ID;";
            command.Parameters.AddWithValue("@ID", seat.ID);

            // Execute the sql command then store the result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close the sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        /// <summary>
        /// Clears all seats associated with the specified flight.
        /// </summary>
        /// <param name="flightID">The flight identification number.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool ClearSeats(SqlConnection sqlConnection, int flightID)
        {
            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Seats WHERE Flight=@ID;";
            command.Parameters.AddWithValue("@ID", flightID);

            // Execute the sql command then store the result.
            bool result = command.ExecuteNonQuery() > 0;

            // return the result.
            return result;
        }

        /// <summary>
        /// Removes the specified person from the database.
        /// </summary>
        /// <param name="person">The person to remove from the database.</param>
        /// <returns>Returns true if the operation was successful. Otherwise, returns false.</returns>
        public static bool RemoveFlight(Flight flight)
        {
            foreach (var bp in GetBoardingPasses(" WHERE Flight=" + flight.ID))
                RemoveBoardingPass(bp);
            // Open database connection.
            SqlConnection sqlConnection = OpenConnection();

            // Create database command.
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Flights WHERE ID=@ID;";
            command.Parameters.AddWithValue("@ID", flight.ID);

            // Execute the sql command then store the result.
            bool result = command.ExecuteNonQuery() > 0;

            // Close the sql connection then return the result.
            sqlConnection.Close();
            return result;
        }

        #endregion Remove Functions
    }
}