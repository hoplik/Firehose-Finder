using FirehoseFinder.Properties;
using System;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Greeting : Form
    {
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
            label_greeting.Text = Resources.Greeting;
        }
    }
}
