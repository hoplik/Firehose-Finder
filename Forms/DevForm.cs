using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace FirehoseFinder.Forms
{
    public partial class DevForm : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);
        string watermark = "Тут вы можете оставить свой комментарий к комментариям выше.";

        public DevForm()
        {
            InitializeComponent();
            textBox_dev_comcom.Text = watermark;
            textBox_dev_comcom.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Загрузить текст из текстового файла на выбранном языке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevForm_Shown(object sender, EventArgs e)
        {
            richTextBox_comm.Text = LocRes.GetObject("Dev_comm").ToString();
        }

        /// <summary>
        /// Отправили или не отправили комментарий в канал
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(textBox_dev_comcom.Text, "Потом доделаю отправку комментария в канал", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "Отправили комментарий в канал";
                textBox_fh_log.AppendText("Отправили комментарий в канал" + Environment.NewLine);
            }
            else
            {
                toolStripStatusLabel1.Text = "Отправка отменена пользователем";
                textBox_fh_log.AppendText("Отправка отменена пользователем" + Environment.NewLine);
            }
        }

        private void Button_select_fh_Click(object sender, EventArgs e)
        {
            if (openFileDialog_load_fh.ShowDialog() == DialogResult.OK)
            {
                button_select_fh.Text = openFileDialog_load_fh.FileName;
                toolStripStatusLabel1.Text = "Загрузили программер. Начинаем анализ.";
                textBox_fh_log.AppendText(string.Format("Загрузили программер {0}. Начинаем анализ." + Environment.NewLine, openFileDialog_load_fh.FileName));
                Analys_Step1();
            }
            else
            {
                button_select_fh.Text = "Выбрать программер для анализа";
            }
        }

        /// <summary>
        /// Первый этап анализа программера
        /// </summary>
        private void Analys_Step1()
        {
            toolStripStatusLabel1.Text = "Этап #1 - Старт";
            textBox_fh_log.AppendText("Этап #1 - Старт" + Environment.NewLine);
            if (true)
            {
                textBox_fh_res.AppendText("Этап #1 - OK" + Environment.NewLine);
                toolStripStatusLabel1.Text = "Этап #1 - ОК";
                textBox_fh_log.AppendText("Этап #1 - ОК" + Environment.NewLine);
            }
            else
            {
                textBox_fh_res.AppendText("Этап #1 - Bad" + Environment.NewLine);
                toolStripStatusLabel1.Text = "Этап #1 - неудачно";
                textBox_fh_log.AppendText("Этап #1 - неудачно1" + Environment.NewLine);
            }

        }

        /// <summary>
        /// Очищаем результаты анализа и лог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_fh_res.Text = string.Empty;
            textBox_fh_log.Text = string.Empty;
            toolStripStatusLabel1.Text = "Очистили результаты анализа и лог";
        }
        #region Вотермарк для комментария
        private void TextBox_dev_comcom_Enter(object sender, EventArgs e)
        {
            if (textBox_dev_comcom.Text == watermark)
            {
                textBox_dev_comcom.Text = string.Empty;
                textBox_dev_comcom.ForeColor = SystemColors.WindowText;
            }
        }

        private void TextBox_dev_comcom_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_dev_comcom.Text))
            {
                textBox_dev_comcom.Text = watermark;
                textBox_dev_comcom.ForeColor = Color.Gray;
            }
        }
        #endregion
    }
}
