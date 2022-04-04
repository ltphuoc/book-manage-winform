using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp3.Models;

namespace WinFormsApp3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            login = new LoginForm();
            login.ShowDialog();
            Application.Run();
        }

        public static LoginForm login;
        public static ManagerForm manager;
        public static AccountUser currentUser;
    }
}
