using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
            _ = new Mutex(true, Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString(), out bool onlyone);
            if (onlyone)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Formfhf());
            }
            else MessageBox.Show("One instance of the application is already running (en)" + Environment.NewLine +
                "Один экземпляр приложения уже запущен (ru)");
        }
    }
}
