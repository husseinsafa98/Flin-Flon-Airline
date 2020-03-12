using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlinFlon_Airlines
{
    public partial class AddPassengerDialog : Form
    {
        public AddPassengerDialog(int id = 0)
        {
            InitializeComponent();

            // Make column titles bold.
            for (int i = 0; i < listView_Reservations.Columns.Count; i++)
                listView_Reservations.Columns[i].ListView.Font = new Font(listView_Reservations.Font, FontStyle.Bold);

            DialogResult = DialogResult.Cancel;

            // if the id isnt 0, then we are editing an existing passenger.
            if(id == 0)
            {
                Text = "Add Passenger";
                Passenger = new Passenger();
            }
            else
            {
                Text = "Edit Passenger";

                //retrieve passenger information from the database.
                Passenger = Database.GetPassenger(id);

                // populate form with passenger data.
                dateTimePicker_DOB.Value = Passenger.DateOfBirth;
                textBox_Name.Text = Passenger.Name;
                textBox_Address.Text = Passenger.Address;
                textBox_Cost.Text = Passenger.Cost.ToString();
                textBox_Email.Text = Passenger.Email;
                textBox_Number.Text = Passenger.Number;
                textBox_SpecialAccommodations.Text = Passenger.SpecialAccommodations;
                comboBox_Preference.SelectedIndex = (int)Passenger.SeatingPreference;

                // add all boarding passes associated with the passenger to the list.
                foreach (var boardingPass in Passenger.BoardingPasses.FindAll(x => x.Issued == false))
                {
                    BoardingPasses.Add(boardingPass);
                }

                LoadFormData(); // load form data.
            }
        }

        /// <summary>
        /// The passenger instance we are adding/editing.
        /// </summary>
        private Passenger Passenger { get; set; }

        /// <summary>
        /// Boarding passes to be removed.
        /// </summary>
        private List<BoardingPass> RemovedBoardingPasses { get; set; } = new List<BoardingPass>();

        /// <summary>
        /// Boarding passes to be added.
        /// </summary>
        private List<BoardingPass> BoardingPasses { get; set; } = new List<BoardingPass>();

        /// <summary>
        /// Boarding passes to be issued.
        /// </summary>
        public List<BoardingPass> IssuedBoardingPasses { get; private set; } = new List<BoardingPass>();

        /// <summary>
        /// Populate the list view with boarding pass information.
        /// </summary>
        private void LoadFormData()
        {
            listView_Reservations.Items.Clear();
            foreach (var boardingPass in BoardingPasses)
            {
                var item = new ListViewItem()
                {
                    Tag = boardingPass.ID,
                    Text = boardingPass.Flight.ID.ToString(),
                    Font = new Font(listView_Reservations.Font, FontStyle.Regular)
                };
                item.SubItems.Add(boardingPass.Class);
                item.SubItems.Add(boardingPass.Seat.SeatNumber);
                listView_Reservations.Items.Add(item);
            }
        }

        private void TextBox_Cost_TextChanged(object sender, EventArgs e)
        {
            // only allow numbers and no blanks.
            if (textBox_Cost.Text.StartsWith("0") && textBox_Cost.Text != "0")
                textBox_Cost.Text = textBox_Cost.Text.TrimStart('0');
            if (textBox_Cost.Text == "")
                textBox_Cost.Text = "0";
            textBox_Cost.Text = Regex.Replace(textBox_Cost.Text, "[^0-9.]", "");
            textBox_Cost.SelectionStart = textBox_Cost.Text.Length;
        }

        private void TextBox_Number_TextChanged(object sender, EventArgs e)
        {
            // phone number format.
            if (textBox_Number.Text.Length > 12)
                textBox_Number.Text = textBox_Number.Text.Substring(0, 12);

            textBox_Number.Text = Regex.Replace(textBox_Number.Text, "[^0-9-]", "");
            textBox_Number.Text = Regex.Replace(textBox_Number.Text, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

            textBox_Number.SelectionStart = textBox_Number.Text.Length;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            // Populate passenger with data from the form.
            Passenger.DateOfBirth = dateTimePicker_DOB.Value;
            Passenger.Name = textBox_Name.Text;
            Passenger.Address = textBox_Address.Text;
            Passenger.Cost = Convert.ToDecimal(textBox_Cost.Text);
            Passenger.Email = textBox_Email.Text;
            Passenger.Number = textBox_Number.Text.Replace("-","");
            Passenger.SpecialAccommodations = textBox_SpecialAccommodations.Text;
            if (comboBox_Preference.SelectedIndex != -1)
                Passenger.SeatingPreference = (SeatingPreference)comboBox_Preference.SelectedIndex;
            else
                Passenger.SeatingPreference = SeatingPreference.None;


            // save passenger in the database.
            Database.SavePassenger(Passenger);

            // remove boarding passes.
            foreach (var pass in RemovedBoardingPasses)
            {
                //Passenger.Cost -= pass.Flight.Price;
                //textBox_Cost.Text = Passenger.Cost.ToString();
                Database.RemoveBoardingPass(pass);
            }

            // add new boarding passes.
            foreach (var boardingPass in BoardingPasses)
            {
                boardingPass.PassengerID = Passenger.ID;
                Database.SaveBoardingPass(boardingPass);
            }

            // save passenger again
            Database.SavePassenger(Passenger);
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            // add new reservation.
            var reservationDialog = new AddReservationDialog(Passenger);
            if (reservationDialog.ShowDialog() == DialogResult.OK)
            {
                BoardingPasses.Add(new BoardingPass(0, Convert.ToInt32(reservationDialog.comboBox_Flight.Text),Passenger.ID,0, reservationDialog.comboBox_Class.Text, false));
                LoadFormData();
            }
            
        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if (listView_Reservations.SelectedItems.Count > 0)
            {
                // find the boarding pass in the database.
                var pass =  BoardingPasses.Find(x => x.ID == Convert.ToInt32(listView_Reservations.SelectedItems[0].Tag));

                // Get the price of the seat.
                int seatPrice = 0;
                if (pass.Class == "First Class")
                    seatPrice = 300;
                else if (pass.Class == "Business Class")
                    seatPrice = 200;

                // update the passenger cost with the seat cost.
                Passenger.Cost -= (pass.Flight.Price + seatPrice);
                textBox_Cost.Text = Passenger.Cost.ToString();
                if ((int)listView_Reservations.SelectedItems[0].Tag == 0)
                {
                    BoardingPasses.RemoveAt(listView_Reservations.SelectedItems[0].Index);
                }
                else
                {
                    RemovedBoardingPasses.Add(BoardingPasses.Find(x => x.ID == Convert.ToInt32(listView_Reservations.SelectedItems[0].Tag)));
                    BoardingPasses.Remove(BoardingPasses.Find(x => x.ID == Convert.ToInt32(listView_Reservations.SelectedItems[0].Tag)));
                }
                
                listView_Reservations.Items.Remove(listView_Reservations.SelectedItems[0]);

                LoadFormData();
            }
            
        }

        private void IssueBoardingPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool discount = false;
            if (listView_Reservations.SelectedItems.Count > 0)
            {
                label1:

                BoardingPass boardingPass = BoardingPasses[listView_Reservations.SelectedItems[0].Index];

                List<Seat> seats = boardingPass.Flight.Seats.FindAll(x => x.Class == boardingPass.Class && x.PassengerID == 0);

                if (seats.Count == 0)
                {
                    MessageBox.Show("The flight is now full. This passenger will be rebooked on the next available flight.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Flight f = new Flight();
                    foreach(var flight in Database.GetFlights().FindAll(x => x.ID != boardingPass.FlightID && x.EndDestination.ToString() == boardingPass.Flight.EndDestination.ToString()))
                    {
                        f = flight;
                        break;
                    }
                    if (f.ID != 0)
                    {
                        discount = true;
                        boardingPass.FlightID = f.ID;
                        boardingPass.SeatID = 0;
                        goto label1;
                    }
                    else
                    {
                        MessageBox.Show("Failed to reschedule, please manually reschedule passenger.");
                        return;
                    }
                }

                SeatingPreference preference = (SeatingPreference)comboBox_Preference.SelectedIndex;
                Seat selectedSeat = null;
            Begin:
                // find a passengers seat.
                foreach (var seat in seats)
                {
                    string seatColumn = Regex.Replace(seat.SeatNumber, "[^A-Z]", "");
                    if (seat.PassengerID == 0 && preference == SeatingPreference.Window && (seatColumn == "A" || seatColumn == "J"))
                    {
                        selectedSeat = seat;
                        break;
                    }
                    else if (seat.PassengerID == 0 && preference == SeatingPreference.Isle && (seatColumn == "C" || seatColumn == "D" || seatColumn == "G" || seatColumn == "H"))
                    {
                        selectedSeat = seat;
                        break;
                    }
                    else if (seat.PassengerID == 0 && preference == SeatingPreference.Middle && (seatColumn == "B" || seatColumn == "E" || seatColumn == "F" || seatColumn == "I"))
                    {
                        selectedSeat = seat;
                        break;
                    }
                    else if (seat.PassengerID == 0 && preference == SeatingPreference.None)
                    {
                        selectedSeat = seat;
                        break;
                    }
                }
                if (selectedSeat == null) // seating preference could not be fufiled.
                {
                    if (MessageBox.Show("The seating preference for this passenger cannot be fulfilled. Would you like to put passenger in any seat? ", "Cant Issue Seat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        preference = SeatingPreference.None;
                        goto Begin;
                    }
                    else return;
                }

                boardingPass.SeatID = selectedSeat.ID;
                boardingPass.Issued = true;

                int seatPrice = 0;
                if (boardingPass.Class == "First Class")
                    seatPrice = 300;
                else if (boardingPass.Class == "Business Class")
                    seatPrice = 200;
                Passenger.Cost += (boardingPass.Flight.Price + seatPrice);

                if(discount)
                {
                    Passenger.Cost -= ((boardingPass.Flight.Price + seatPrice) * (decimal)0.10);
                }

                textBox_Cost.Text = Passenger.Cost.ToString();
                BoardingPasses[listView_Reservations.SelectedItems[0].Index] = boardingPass;
                IssuedBoardingPasses.Add(boardingPass);
                LoadFormData();
            }
        }

        private void ContextMenuStrip_Reservations_Opening(object sender, CancelEventArgs e)
        {
            if (listView_Reservations.SelectedItems.Count == 0)
                e.Cancel = true;
            else
            {
                // dont open context menu if the boarding pass is already issued.
                BoardingPass boardingPass = BoardingPasses[listView_Reservations.SelectedItems[0].Index];
                if (boardingPass.Issued)
                    e.Cancel = true;
            }
        }
    }
}
