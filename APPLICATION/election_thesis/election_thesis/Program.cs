using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using election_thesis.Properties;

namespace election_thesis
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

            
            
            Settings.Default.configured = false;

            if (Settings.Default.configured)
            {
                Application.Run(new VoterLogin());
            }
            else
            {
                Application.Run(new VotingConfig());
            }

            
            
            //Application.Run(new loginForm());
        }
    }
}
