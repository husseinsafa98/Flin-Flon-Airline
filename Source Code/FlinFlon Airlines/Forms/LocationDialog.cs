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
    public partial class LocationDialog : Form
    {
        public LocationDialog(int id = 0)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            // if the id isn't 0 then we are editing.
            if (id != 0)
            {
                Text = "Edit Location";
                Location location = Database.GetLocation(id);
                textBox_AirportName.Text = location.AirportName;
                textBox_City.Text = location.City;
                textBox_Country.Text = location.Country;
                textBox_Province.Text = location.Province;
            }
        }
    }
}
