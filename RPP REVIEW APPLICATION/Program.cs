using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPP_REVIEW_APPLICATION
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
           // Application.Run(new Minimum_Tax());
           //Application.Run(new General_Template());
            //Application.Run(new Permanent_Note_Jacket_Information());
            Application.Run(new General_Templat6());
           //Application.Run(new General_Template3());
            //Application.Run(new CIT_EDT_Computation());
            
        }
    }
}
