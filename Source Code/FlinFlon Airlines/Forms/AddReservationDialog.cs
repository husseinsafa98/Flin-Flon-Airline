using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlinFlon_Airlines
{
    public partial class AddReservationDialog : Form
    {
        public AddReservationDialog(Passenger passenger, int boardingPassID = 0)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            
            // if the id isn't 0, then we are editing a reservation.
            if (boardingPassID != 0)
            {
                Text = "Edit Reservation";
                // find boarding pass from passenger.
                BoardingPass pass = passenger.BoardingPasses.Find(x => x.Issued == false && x.ID == boardingPassID);
                comboBox_Class.Text = pass.Seat.Class;
                comboBox_Flight.Text = pass.Flight.ID.ToString();
            }
            // get all available flights.
            foreach (var flight in Database.GetFlights())
            {
                var seats = flight.Seats;
                int overbookedCount = (int)(seats.Count * 0.15);
                if(Database.GetBoardingPasses(" WHERE Flight=" + flight.ID.ToString()).Count <= (overbookedCount+ seats.Count))
                {
                    comboBox_Flight.Items.Add(flight.ID.ToString());
                }
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if(comboBox_Flight.SelectedIndex == -1 || comboBox_Class.SelectedIndex == -1)
            {
                MessageBox.Show("Fields cant be blank.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
