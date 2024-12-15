using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mydatabase
{
    public class StudentInfo
    {
        public static int BSIT = 31500;
        public static string checkcourse = String.Empty;
        public static int checkfees = 0;
        public static string checkname = String.Empty;

          

    }
    

    

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
