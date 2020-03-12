using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlinFlon_Airlines
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Loop until we have a reason to exit.
            while (true)
            {
                // Check if we can log the user in.
                if (UserManager.Login())
                {
                    // Show the main form.
                    var form = new FormMain();
                    if (form.ShowDialog() == DialogResult.Cancel)
                        break;
                }
                else // If we didn't log in, exit.
                    break;
            }
        }
    }
}
