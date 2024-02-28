using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace FirehoseFinder
{
    partial class AboutBox1 : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public AboutBox1()
        {
            InitializeComponent();
            Text = string.Format("{0} {1}", LocRes.GetString("about"), AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format("{0} {1}", LocRes.GetString("version"), AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            textBoxDescription.Text = LocRes.GetString("about_deck");//AssemblyDescription;
        }

        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void OkButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void LinkLabel_forum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psinfo = new ProcessStartInfo("http://4pda.ru/forum/index.php?showtopic=643084");
            Process.Start(psinfo);
        }

        private void LinkLabel_telega_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psinfo = new ProcessStartInfo("https://t.me/firehosefinder");
            Process.Start(psinfo);
        }

        private void Button_donate_ymoney_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psinfo = new ProcessStartInfo("https://yoomoney.ru/to/410011108517314");
            Process.Start(psinfo);
        }

        private void Button_donate_pp_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psinfo = new ProcessStartInfo("https://paypal.me/hoplik?country.x=RU&locale.x=ru_RU");
            Process.Start(psinfo);
        }

        /// <summary>
        /// Путь к расположению программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoPictureBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LocRes.GetString("copy_clip") + Environment.NewLine + Application.StartupPath, LocRes.GetString("app_path"));
            Clipboard.Clear();
            Clipboard.SetText(Application.StartupPath);
        }
    }
}
