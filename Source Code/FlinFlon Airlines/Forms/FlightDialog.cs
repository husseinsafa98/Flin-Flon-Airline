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
    public partial class FlightDialog : Form
    {
        public FlightDialog(int id = 0)
        {
            InitializeComponent();

            //load form information.
            LoadFormData();

            // if the id isn't 0, then we are editing a flight.
            if(id != 0)
            {
                Text = "Edit Flight";

                // get flight from the database.
                Flight flight = Database.GetFlight(id);
                dateTimePicker_DepartureTime.Value = flight.DepartureTime;
                dateTimePicker_ArrivalTime.Value = flight.ArrivalTime;
                textBox_Cost.Text = flight.Price.ToString();
                var seats = flight.Seats;
                textBox_FirstClassRows.Text = (seats.Count(x => x.Class == "First Class")/10).ToString();
                textBox_BusinessClassRows.Text = (seats.Count(x => x.Class == "Business Class") / 10).ToString();
                textBox_EconomyClassRows.Text = (seats.Count(x => x.Class == "Economy Class") / 10).ToString();
                comboBox_StartDestination.Text = flight.StartDestination.ToString();
                comboBox_EndDestination.Text = flight.EndDestination.ToString();
            }
        }

        /// <summary>
        /// The start location.
        /// </summary>
        public Location StartLocation { get; set; }

        /// <summary>
        /// The end location.
        /// </summary>
        public Location EndLocation { get; set; }

        private void LoadFormData()
        {
            // get all locations from the database.
            comboBox_StartDestination.Items.Clear();
            comboBox_EndDestination.Items.Clear();
            foreach (var location in Database.GetLocations())
            {
                comboBox_StartDestination.Items.Add(location.ToString());
                comboBox_EndDestination.Items.Add(location.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // only allow numbers and no blank spaces.
            if (((TextBox)sender).Text.StartsWith("0") && ((TextBox)sender).Text != "0")
                ((TextBox)sender).Text = ((TextBox)sender).Text.TrimStart('0');
            if (((TextBox)sender).Text == "")
                ((TextBox)sender).Text = "0";
            ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text, "[^0-9.]", "");
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }

        private void Button_AddLocation_Click(object sender, EventArgs e)
        {
            // Add location to the database.
            var lc = new LocationDialog();
            if(lc.ShowDialog() == DialogResult.OK)
            {
                // save the location to the database.
                Database.SaveLocation(new Location(0, lc.textBox_City.Text, lc.textBox_Province.Text, lc.textBox_Country.Text, lc.textBox_AirportName.Text));
                LoadFormData();
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            var locations = Database.GetLocations();
            StartLocation = locations.Find(x => x.ToString() == comboBox_StartDestination.Text);
            EndLocation = locations.Find(x => x.ToString() == comboBox_EndDestination.Text);
        }

        private void EditLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // edit a specific location.
            ComboBox control = (ComboBox)((ContextMenuStrip)((ToolStripItem)sender).Owner).SourceControl;
            if (control.SelectedIndex == -1)
                return;
            Location location = Database.GetLocations().Find(x => x.ToString() == control.Text);
            var lc = new LocationDialog(location.ID);
            if (lc.ShowDialog() == DialogResult.OK)
            {
                // save location to the database.
                location = new Location(location.ID, lc.textBox_City.Text, lc.textBox_Province.Text, lc.textBox_Country.Text, lc.textBox_AirportName.Text);
                Database.SaveLocation(location);
                LoadFormData();
                control.Text = location.ToString();
            }
        }

        private void ContextMenuStrip_Location_Opening(object sender, CancelEventArgs e)
        {
            ComboBox control = (ComboBox)((ContextMenuStrip)(sender)).SourceControl;
            if (control.SelectedIndex == -1)
                e.Cancel = true;
        }
    }
}
