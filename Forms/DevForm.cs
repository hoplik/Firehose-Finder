using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
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
            string file_path = e.Argument as string;
            if (string.IsNullOrEmpty(file_path) || !File.Exists(file_path))
            {
                e.Result = false;
                return;
            }
            FileInfo fileInfo = new FileInfo(file_path);
            long file_bytes = fileInfo.Length; //Количество байт для чтения
            long bytes_read = 0; //Количество прочтённых байт
            e.Result = true; //По умолчанию результат удачный
            byte[] real_elf = new byte[4] { 0x7F, 0x45, 0x4C, 0x46 }; //Magic numder для эльфа
            byte[] temp_read_arr = new byte[real_elf.Length];
            string user_state = string.Empty;
            byte count_elf = 1; //Считаем количество эльфов
            byte correct_byte = 0; //Счётчик корректных байт в последовательности
            //TODO Все операции проверок
            using (BinaryReader br = new BinaryReader(File.OpenRead(file_path)))
            {
                while (bytes_read < file_bytes)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        e.Result = false;
                        break;
                    }
                    else
                    {
                        //Первая проверка на эльф/не эльф (считаем их количество в контейнере)
                        if (correct_byte < real_elf.Length)
                        {
                            temp_read_arr[correct_byte] = br.ReadByte();
                            if (temp_read_arr[correct_byte] == real_elf[correct_byte]) correct_byte++;
                            else correct_byte = 0; //Если последовательность неправильная, сбрасываем на 0
                        }
                        else
                        {
                            if (temp_read_arr.SequenceEqual(real_elf))
                            {
                                user_state = string.Format("Это {0} эльф", count_elf) + Environment.NewLine;
                                //Вторая проверка - читаем шапку эльфа
                                byte elf_class = br.ReadByte(); //32 или 64 бита архитектура
                                byte elf_data = br.ReadByte(); //Литл или биг дата 
                                int bytes_to_read = 2; //Для 32 бит минимальное значение
                                if ((Guide.ELF_Class)elf_class == Guide.ELF_Class.ELF64) bytes_to_read = 4;
                                br.BaseStream.Position += 18 + (bytes_to_read * 2); //Пропускаем, что не нужно
                                byte[] ph_offset = br.ReadBytes(bytes_to_read * 2); //4 или 8 байт заголовок программ
                                /*пропускаем смещение заголовков 4(8)
                                пропускаем флаги 4
                                пропускаем заголовок 2*/
                                br.BaseStream.Position += bytes_to_read * 2 + 6; //Пропускаем, что не нужно
                                byte[] ph_size = br.ReadBytes(2); //2 байта размер программ
                                byte[] ph_number = br.ReadBytes(2); //2 байта количество программ
                                if ((Guide.ELF_Data)elf_data == Guide.ELF_Data.Big_endian)
                                {
                                    Array.Reverse(ph_offset);
                                    Array.Reverse(ph_size);
                                    Array.Reverse(ph_number);
                                }
                                switch ((Guide.ELF_Class)elf_class)
                                {
                                    case Guide.ELF_Class.ELF32:
                                        user_state += string.Format("Обнаружен сдвиг для программных заголовков {0}", BitConverter.ToUInt32(ph_offset, 0)) + Environment.NewLine;
                                        break;
                                    case Guide.ELF_Class.ELF64:
                                        user_state += string.Format("Обнаружен сдвиг для программных заголовков {0}", BitConverter.ToUInt64(ph_offset, 0)) + Environment.NewLine;
                                        break;
                                }
                                user_state += string.Format("Обнаружен размер программных заголовков {0}", BitConverter.ToUInt16(ph_size, 0)) + Environment.NewLine;
                                user_state += string.Format("Обнаружено {0} программных заголовков", BitConverter.ToUInt16(ph_number, 0)) + Environment.NewLine;
                                count_elf++;
                                for (int i = 0; i < temp_read_arr.Length; i++) temp_read_arr[i] = 0;
                            }
                            correct_byte = 0;
                        }
                        bytes_read = br.BaseStream.Position;
                        long repprog = bytes_read * 100 / file_bytes;
                        worker.ReportProgress((int)repprog, userState: user_state);
                    }
                    user_state = string.Empty;
                }
            }
        }

        /// <summary>
        /// Отображение промежуточных значений выполнения анализа в параллельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_analyse_fh_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format("Выполнено {0}%", e.ProgressPercentage);
            toolStripProgressBar1.Value = e.ProgressPercentage;
            string str_rep = e.UserState.ToString();
            if (!string.IsNullOrEmpty(str_rep)) textBox_fh_log.AppendText(str_rep + Environment.NewLine);
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
