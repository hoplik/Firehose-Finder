using System;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace FirehoseFinder
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Formfhf());
        }
    }
}
