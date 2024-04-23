using FirehoseFinder.Properties;
using System;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Greeting : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);
        public Greeting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// При изменении бокса сохраняем значение в системных настройках
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_start_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_start.Checked) Settings.Default.CheckBox_start_Checked = true;
            else Settings.Default.CheckBox_start_Checked = false;
        }

        /// <summary>
        /// Закрываем форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ok_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// При запуске формы восстанавливаем сохранённые параметры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Greeting_Load(object sender, EventArgs e)
        {
            checkBox_start.Checked = Settings.Default.CheckBox_start_Checked;
            textBox_greeting.Text = LocRes.GetObject("Greeting").ToString();
        }
        private string Utf8tounicode(string utf8str)
        {
            Encoding unicode = Encoding.Unicode;
            Encoding utf8 = Encoding.UTF8;
            byte[] utf8Bytes = utf8.GetBytes(utf8str);
            byte[] unicodeBytes = Encoding.Convert(utf8, unicode, utf8Bytes);
            return Encoding.Unicode.GetString(unicodeBytes);
        }
    }
}
