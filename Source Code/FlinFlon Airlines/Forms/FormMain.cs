using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlinFlon_Airlines
{
    public partial class FormMain : Form
    {
        private bool m_searchTime = false;
        public FormMain()
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;

            // make column headers bold.
            for (int i = 0; i < listView_Flights.Columns.Count; i++)
                listView_Flights.Columns[i].ListView.Font = new Font(listView_Flights.Font, FontStyle.Bold);
            for (int i = 0; i < listView_Passengers.Columns.Count; i++)
                listView_Passengers.Columns[i].ListView.Font = new Font(listView_Passengers.Font, FontStyle.Bold);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(UserManager.User.PrivilegeLevel == PrivilegeLevel.Admin)
            {
                // add extra titles if the user is administrator.
                listView_Flights.Columns.AddRange(new ColumnHeader[] {columnHeader4,
                    columnHeader5,
                    columnHeader6,
                    columnHeader7 });
                toolStripButton_AddFlight.Visible = true;
                
            }
            toolStripDropDownButton1.Text = UserManager.User.Username;

            LoadFormData();
        }

        void LoadFormData()
        {
            // clear all flights from the database.
            listView_Flights.Items.Clear();
            listView_Passengers.Items.Clear();
            comboBox_Destination.Items.Clear();

            // Get all locations.
            comboBox_Destination.Items.Add("(none)");
            foreach (Location location in Database.GetLocations())
            {
                comboBox_Destination.Items.Add(location.ToString());
            }

            List<Flight> flights;

            // get all flights.
            if (comboBox_Destination.Text != "" && comboBox_Destination.Text != "(none)")
                flights = Database.GetFlights().FindAll(x => x.EndDestination.ToString() == comboBox_Destination.Text);
            else
                flights = Database.GetFlights();

            // if searching specific time, get that.
            if(m_searchTime)
            {
                flights = flights.FindAll(x => x.DepartureTime >= dateTimePicker_Begin.Value && x.DepartureTime < dateTimePicker_End.Value);
            }

            // add flights to the list view.
            foreach (var flight in flights)
            {
                var item = new ListViewItem(flight.ID.ToString())
                {
                    Font = new Font(listView_Flights.Font, FontStyle.Regular),
                    Tag = flight.ID
                    
                };
                item.SubItems.Add(flight.EndDestination.ToString());
                item.SubItems.Add(flight.DepartureTime.ToString("MM/dd/yyyy"));
                item.SubItems.Add(flight.DepartureTime.ToString("hh:mm tt"));
                var seats = flight.Seats;
                item.SubItems.Add(seats.Count(x => x.Class == "First Class" && x.Passenger.ID == 0).ToString());
                item.SubItems.Add(seats.Count(x => x.Class == "Business Class" && x.Passenger.ID == 0).ToString());
                item.SubItems.Add(seats.Count(x => x.Class == "Economy Class" && x.Passenger.ID == 0).ToString());
                item.SubItems.Add(seats.Count.ToString());
                listView_Flights.Items.Add(item);
            }

            // get all passengers.
            List<Passenger> passengers = Database.GetPassengers();
            if (textBox_FlightNumber.Text != "")
            {
                passengers = passengers.FindAll(x => x.BoardingPasses.Any(y => y.Flight.ID.ToString().StartsWith(textBox_FlightNumber.Text)));
            }

            if (textBox_Name.Text != "")
            {
                passengers = passengers.FindAll(x => x.Name.StartsWith(textBox_Name.Text));
            }

            // put all passengers into the database.
            foreach (var passenger in passengers)
            {
                var item = new ListViewItem(passenger.Name)
                {
                    Font = new Font(listView_Flights.Font, FontStyle.Regular),
                    Tag = passenger.ID
                };
                item.SubItems.Add(Regex.Replace(passenger.Number, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3"));
                item.SubItems.Add(passenger.DateOfBirth.ToString("MM/dd/yyyy"));
                item.SubItems.Add(passenger.Address);
                item.SubItems.Add(passenger.Email);
                item.SubItems.Add(passenger.SpecialAccommodations);
                item.SubItems.Add(passenger.SeatingPreference.ToString());
                item.SubItems.Add(string.Format("{0:C}",passenger.Cost.ToString()));
                listView_Passengers.Items.Add(item);
            }
        }

        private void ToolStripDropDownButton1_DropDownOpened(object sender, EventArgs e)
        {
            toolStripDropDownButton1.ForeColor = Color.Black;
        }

        private void ToolStripDropDownButton1_DropDownClosed(object sender, EventArgs e)
        {
            toolStripDropDownButton1.ForeColor = Color.White;
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManager.Logout();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void EditProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditUserDialog().ShowDialog();
        }

        private void ComboBox_Destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Destination.Text == "(none)")
                comboBox_Destination.Text = "";
            LoadFormData();
        }

        private void PrintBoardingPasses(List<BoardingPass> boardingPasses)
        {
            // print each boarding pass.
            foreach (var boardingPass in boardingPasses)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printDialog.PrinterSettings;
                    pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                    pd.OriginAtMargins = false;
                    pd.DefaultPageSettings.Landscape = true;

                    pd.PrintPage += new PrintPageEventHandler((x, y) => y.Graphics.DrawImage(boardingPass.ToBitmap(), 10, 10));

                    ppd.Document = pd;

                    ppd.ShowDialog();
                }
            }
        }

        private void EditPassengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Passengers.SelectedItems.Count > 0)
            {
                var apd = new AddPassengerDialog((int)listView_Passengers.SelectedItems[0].Tag);
                if (apd.ShowDialog() == DialogResult.OK)
                {
                    PrintBoardingPasses(apd.IssuedBoardingPasses);
                    LoadFormData();
                }
            }
        }

        private void Button_SearchFlight_Click(object sender, EventArgs e)
        {
            m_searchTime = true;
            LoadFormData();

        }

        private void TextBox_FlightNumber_TextChanged(object sender, EventArgs e)
        {
            textBox_FlightNumber.Text = Regex.Replace(textBox_FlightNumber.Text, "[^0-9]", "");

            textBox_FlightNumber.SelectionStart = textBox_FlightNumber.Text.Length;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadFormData();
            }
        }

        private void Button_SearchPassenger_Click_1(object sender, EventArgs e)
        {
            LoadFormData();
        }

        private void Button_ClearPassenger_Click_1(object sender, EventArgs e)
        {
            textBox_Name.Text = "";
            textBox_FlightNumber.Text = "";
            LoadFormData();
        }

        private void ToolStripButton_AddPassenger_Click(object sender, EventArgs e)
        {
            var apd = new AddPassengerDialog();
            if (apd.ShowDialog() == DialogResult.OK)
            {
                PrintBoardingPasses(apd.IssuedBoardingPasses);
                LoadFormData();
            }
        }

        private void ContextMenuStrip_Passengers_Opening(object sender, CancelEventArgs e)
        {
            if (listView_Passengers.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void SaveFlight(FlightDialog fd, int flightID=0)
        {
            var flight = new Flight(flightID, fd.dateTimePicker_DepartureTime.Value,
                    fd.dateTimePicker_ArrivalTime.Value, fd.StartLocation, fd.EndLocation, Convert.ToDecimal(fd.textBox_Cost.Text));

            Database.SaveFlight(ref flight);

            var boardingPasses = flight.Reservations;
            foreach (var boardingPass in boardingPasses)
            {
                if (boardingPass.Issued)
                {
                    boardingPass.Issued = false;
                    boardingPass.SeatID = 0;
                    Database.SaveBoardingPass(boardingPass);
                }
            }
            var connection = Database.OpenConnection();

            var seats = flight.Seats;

            Database.ClearSeats(connection, flight.ID);

            for (int i = 0; i < Convert.ToInt32(fd.textBox_FirstClassRows.Text); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Database.SaveSeat(connection, new Seat(0, string.Format("{0}{1}", i + 1, Convert.ToChar(j + 65)), "First Class", 0, flight.ID));
                }
            }
            for (int i = 0; i < Convert.ToInt32(fd.textBox_BusinessClassRows.Text); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Database.SaveSeat(connection, new Seat(0, string.Format("{0}{1}", i + 1, Convert.ToChar(j + 65)), "Business Class", 0, flight.ID));
                }
            }
            for (int i = 0; i < Convert.ToInt32(fd.textBox_EconomyClassRows.Text); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Database.SaveSeat(connection, new Seat(0, string.Format("{0}{1}", i + 1, Convert.ToChar(j + 65)), "Economy Class", 0, flight.ID));
                }
            }
            connection.Close();
        }

        private void ToolStripButton_AddFlight_Click(object sender, EventArgs e)
        {
            FlightDialog fd = new FlightDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                SaveFlight(fd);

                LoadFormData();
            }
        }

        private void ManageFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView_Flights.SelectedItems.Count > 0)
            {
                int flightID = (int)listView_Flights.SelectedItems[0].Tag;
                FlightDialog fd = new FlightDialog((int)listView_Flights.SelectedItems[0].Tag);
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    SaveFlight(fd, flightID);

                    LoadFormData();
                }
            }
        }

        private void ContextMenuStrip_Flights_Opening(object sender, CancelEventArgs e)
        {
            if (UserManager.User.PrivilegeLevel != PrivilegeLevel.Admin || listView_Flights.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void RemovePassengerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView_Passengers.SelectedItems.Count > 0)
            {
                Database.RemovePassenger(Database.GetPassenger((int)listView_Passengers.SelectedItems[0].Tag));
                LoadFormData();
            }
        }

        private void Button_ClearFlight_Click(object sender, EventArgs e)
        {
            m_searchTime = false;
            LoadFormData();
        }

        private void RemoveFlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_Flights.SelectedItems.Count > 0)
            {
                Database.RemoveFlight(Database.GetFlight((int)listView_Flights.SelectedItems[0].Tag));
                LoadFormData();
            }
        }
    }
}
