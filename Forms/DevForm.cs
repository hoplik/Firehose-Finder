using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
                if (!backgroundWorker_analyse_fh.IsBusy)
                {
                    Cancel_bgw_ToolStripMenuItem.Enabled = true;
                    backgroundWorker_analyse_fh.RunWorkerAsync(button_select_fh.Text);
                    toolStripStatusLabel1.Text = "Загрузили программер. Начинаем анализ.";
                    textBox_fh_log.AppendText(string.Format("Загрузили программер {0}. Начинаем анализ." + Environment.NewLine, openFileDialog_load_fh.FileName));
                }
            }
            else
            {
                button_select_fh.Text = "Выбрать программер для анализа";
                openFileDialog_load_fh.FileName = string.Empty;
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

        /// <summary>
        /// Запускаем отмену асинхронной операции в параллельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_bgw_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker_analyse_fh.IsBusy) backgroundWorker_analyse_fh.CancelAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка для кнопки отмены операции");
            }
        }

        /// <summary>
        /// Асинхронная операция в параллельном потоке (несколько проверок)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_analyse_fh_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string file_path = e.Argument.ToString();
            if (!File.Exists(file_path))
            {
                e.Result = false;
                return;
            }
            FileInfo fileInfo = new FileInfo(file_path);
            long file_bytes = fileInfo.Length; //Количество байт для чтения
            long bytes_read = 0; //Количество прочтённых байт
            e.Result = true; //По умолчанию результат удачный
                             //TODO Все операции проверок
            while (file_bytes - bytes_read > 0)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    e.Result = false;
                    break;
                }
                else
                {
                    long repprog = bytes_read * 100 / file_bytes;
                    worker.ReportProgress((int)repprog, string.Format("Выполнено {0}%", repprog));
                    bytes_read ++;
                }
                Thread.Sleep(1); //Притормозим поток для отрисовки промежуточных данных
            }
        }

        /// <summary>
        /// Отображение промежуточных значений выполнения анализа в параллельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_analyse_fh_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = e.UserState.ToString();
        }

        /// <summary>
        /// Отображение результата выполнения анализа в параллельном потоке (нескольких проверок)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_analyse_fh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            Cancel_bgw_ToolStripMenuItem.Enabled = false;
            if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = "Операция отменена пользователем";
                textBox_fh_log.AppendText("Операция отменена пользователем" + Environment.NewLine);
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel1.Text = "Операция завершилась с ошибкой " + e.Error.Message;
                textBox_fh_log.AppendText("Операция завершилась с ошибкой " + e.Error.Message + Environment.NewLine);
            }
            else
            {
                if ((bool)e.Result)
                {
                    toolStripStatusLabel1.Text = "Операция завершилась удачно";
                    textBox_fh_log.AppendText("Операция завершилась удачно" + Environment.NewLine);
                }
                else
                {
                    toolStripStatusLabel1.Text = "Операция завершилась неудачно";
                    textBox_fh_log.AppendText("Операция завершилась неудачно" + Environment.NewLine);
                }
            }
        }
    }
}
