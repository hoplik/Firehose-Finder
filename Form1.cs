using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Text;
using FirehoseFinder.Properties;
using System.Diagnostics;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        Func func = new Func(); // Подключили функции
        Guide guide = new Guide();
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public Formfhf()
        {
            InitializeComponent();
        }

        #region Функции контролов формы

        /// <summary>
        /// Выполнение инструкций при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_Load(object sender, EventArgs e)
        {
            richTextBox_about.Text = Resources.String_about + Environment.NewLine +
                "Ссылка на базовую тему <<Общие принципы восстановления загрузчиков на Qualcomm | HS - USB QDLoader 9008, HS - USB Diagnostics 9006, QHUSB_DLOAD и т.д.>>: " +
                Resources.String_theme_link + Environment.NewLine
                + Environment.NewLine +
                "Версия сборки: " + Assembly.GetExecutingAssembly().GetName().Version + Environment.NewLine
                + Environment.NewLine +
                "Часто задаваемые вопросы: " + Environment.NewLine + Resources.String_faq1 + Environment.NewLine +
                Resources.String_faq2 + Environment.NewLine + Resources.String_faq3 + Environment.NewLine
                + Environment.NewLine +
                "Есть вопросы, предложения, замечания? Открывайте ишью (вопрос) на Гитхабе: " + Resources.String_issues;
            toolTip1.SetToolTip(button_path, "Укажите путь к коллекции firehose");
            toolTip1.SetToolTip(button_rename_fhf, "При нажатии произойдёт переименование выбранного файла по идентификаторам, указанным в таблице");
        }

        /// <summary>
        /// Выбираем директорию для работы с программерами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_path_Click(object sender, EventArgs e)
        {
            textBox_hwid.BackColor = Color.Empty;
            textBox_oemid.BackColor = Color.Empty;
            textBox_modelid.BackColor = Color.Empty;
            textBox_oemhash.BackColor = Color.Empty;
            dataGridView_final.Rows.Clear();
            button_rename_fhf.Visible = false;
            toolStripStatusLabel_filescompleted.Text = string.Empty;
            toolStripStatusLabel_vol.Text = string.Empty;
            toolStripProgressBar_filescompleted.Value = 0;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_path.Text = folderBrowserDialog1.SelectedPath;
                Check_Unread_Files();
            }
        }

        /// <summary>
        /// Заглушка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button__rename_fhf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Скоро это действие будет вызывать операцию переименования выбранного файла (группы файлов) по идентификаторам из их сертификатов.", "Пока не работает");
        }

        /// <summary>
        /// Ставим галку на выбранной строке с программером
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_final_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!dataGridView_final.Rows[e.RowIndex].ReadOnly)
                {
                    if (Convert.ToBoolean(dataGridView_final["Column_Sel", e.RowIndex].Value))
                    {
                        dataGridView_final["Column_Sel", e.RowIndex].Value = false;
                        button_rename_fhf.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView_final.Rows.Count; i++)
                        {
                            dataGridView_final["Column_Sel", i].Value = false;
                        }
                        dataGridView_final["Column_Sel", e.RowIndex].Value = true;
                        button_rename_fhf.Visible = true;
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Стоит сначала выбрать рабочую директорию." + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Выводим подробную информацию в отдельное окно с копированием в буфер обмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_final_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataGridView_final.Rows[e.RowIndex].ReadOnly)
            {
                DialogResult dr = MessageBox.Show(dataGridView_final["Column_Full", e.RowIndex].Value.ToString(), "Сохранить данные в буфер обмена?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(dataGridView_final["Column_Full", e.RowIndex].Value.ToString());
                }
            }
        }

        /// <summary>
        /// Побайтное чтение файла в параллельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Read_File_DoWork(object sender, DoWorkEventArgs e)
        {
            KeyValuePair<string, long> FileToRead = (KeyValuePair<string, long>)e.Argument;
            int len = Convert.ToInt32(FileToRead.Value);
            if (len > 12288) len = 12288; //Нам нужно только до 0х3000, где есть первые три сертификата
            StringBuilder dumptext = new StringBuilder(len);
            byte[] chunk = new byte[len];
            using (var stream = File.OpenRead(FileToRead.Key))
            {
                int byteschunk = stream.Read(chunk, 0, len);
                for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, String.Format("{0:X2}", (int)chunk[i]));
            }
            e.Result = dumptext.ToString();
        }

        /// <summary>
        /// Всё, что нужно доделать после завершения длительной операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Read_File_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) MessageBox.Show(e.Error.Message);
            else
            {
                string dumpfile = e.Result.ToString();
                byte curfilerating = 0;
                int Currnum = dataGridView_final.Rows.Count - 1; //Номер последней, "пустой" строки грида
                switch (dumpfile.Substring(0, 8))
                {
                    case "7F454C46": //ELF
                        curfilerating++;
                        break;
                    case "7F454C45": //не совсем ELF
                        curfilerating++;
                        dataGridView_final["Column_Name", Currnum].Style.BackColor = Color.Yellow;
                        dataGridView_final["Column_Name", Currnum].ToolTipText = "Файл не является ELF!";
                        break;
                    default: //совсем не ELF
                        break;
                }
                if (curfilerating != 0) //Увеличиваем рейтинг совпадениями поиска файла
                {
                    dataGridView_final["Column_rate", Currnum].Value = curfilerating + Rating(dumpfile, Currnum);
                    dataGridView_final["Column_rate", Currnum].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else //Рейтинг 0 не обрабатываем
                {
                    dataGridView_final.Rows[Currnum].ReadOnly = true;
                    dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.LightGray;
                }
                dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);
                Check_Unread_Files(); //Проверяем, не осталось ли необработанных файлов
            }
        }
        #endregion

        #region Функции самостоятельных команд
        /// <summary>
        /// Проверка заполнения грида прочтёнными файлами и запуск параллельного потока для непрочтённых
        /// </summary>
        private void Check_Unread_Files()
        {
            button_path.Enabled = false;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text); //Полный путь с именем файла и его объём для каждого файла в выбраной папке
            int currreadfiles = dataGridView_final.Rows.Count;
            int totalreadfiles = Resfiles.Count;
            toolStripStatusLabel_filescompleted.Text = "Обработано " + currreadfiles.ToString() + " файлов из " + totalreadfiles.ToString();
            //Либо 0, либо чтение всех файлов закончено, в грид всё добавлено - уходим
            if (currreadfiles == totalreadfiles)
            {
                button_path.Enabled = true;
                toolStripStatusLabel_vol.Text = string.Empty;
                toolStripProgressBar_filescompleted.Value = 0;
                return;
            }
            //Есть необработанные файлы - обрабатываем первый отсутствующий в цикле
            List<string> ReadedFiles = new List<string>(); //Создаём массив под список уже обработанных файлов
            //Заполняем массив короткими именами файлов из грида (если они есть)
            for (int i = 0; i < currreadfiles; i++) ReadedFiles.Add(dataGridView_final["Column_Name", i].Value.ToString().Trim());
            toolStripProgressBar_filescompleted.Value = currreadfiles * 100 / totalreadfiles; //Количество обработанных файлов в прогрессбаре
            dataGridView_final.Rows.Add();
            foreach (KeyValuePair<string, long> unreadfiles in Resfiles)
            {
                string shortfilename = Path.GetFileName(unreadfiles.Key); //Получили название файла
                if (!ReadedFiles.Contains(shortfilename))
                {
                    toolStripStatusLabel_vol.Text = "Сейчас обрабатывается файл - " + shortfilename;
                    statusStrip_firehose.Refresh();
                    dataGridView_final[1, currreadfiles].Value = shortfilename;
                    backgroundWorker_Read_File.RunWorkerAsync(unreadfiles); //Запускаем цикл обработки отдельно каждого необработанного файла в папке
                    break;
                }
            }
        }

        /// <summary>
        /// Список проверок для увеличения рейтинга файла и заполнения грида идентификаторами
        /// </summary>
        /// <param name="dumpfile">Строковый массив байт обрабатываемого файла</param>
        /// <param name="Currnum">Номер текущей строки грида для добавления идентификаторов</param>
        private byte Rating(string dumpfile, int Currnum)
        {
            byte gross = 0;
            string[] id = func.IDs(dumpfile);
            string oemhash;
            string sw_type = string.Empty;
            if (id[3].Length < 64) oemhash = id[3];
            else oemhash = id[3].Substring(56);
            dataGridView_final["Column_id", Currnum].Value = id[0] + "-" + id[1] + "-" + id[2] + "-" + oemhash + "-" + id[4] + id[5];
            if (guide.SW_ID_type.ContainsKey(id[4])) sw_type = guide.SW_ID_type[id[4]];
            dataGridView_final["Column_SW_type", Currnum].Value = sw_type;
            dataGridView_final["Column_Full", Currnum].Value = "HW_ID (процессор) - " + id[0] + Environment.NewLine +
                "OEM_ID (производитель) - " + id[1] + Environment.NewLine +
                "MODEL_ID (модель) - " + id[2] + Environment.NewLine +
                "OEM_HASH (хеш корневого сертификата) - " + id[3] + Environment.NewLine +
                "SW_ID (тип программы (версия)) - " + id[4] + id[5] + " - " + sw_type;
            if (textBox_hwid.Text.Equals(id[0])) //Процессор такой же
            {
                textBox_hwid.BackColor = Color.LawnGreen;
                gross += 2;
            }
            if (textBox_oemid.Text.Equals(id[1])) // Производитель один и тот же
            {
                textBox_oemid.BackColor = Color.LawnGreen;
                gross += 2;
            }
            if (textBox_modelid.Text.Equals(id[2])) // Модели равны
            {
                textBox_modelid.BackColor = Color.LawnGreen;
                gross++;
            }
            if (id[3].Length >= 64)
            {
                if (textBox_oemhash.Text.Equals(id[3].Substring(0, 64))) // Хеши равны
                {
                    textBox_oemhash.BackColor = Color.LawnGreen;
                    gross += 2;
                }
            }
            if (id[4].Equals("3")) gross += 2; // SWID начинается с 3 (альтернативная проверка: есть fh@0x%08 - Contains("6668403078253038"))
            return gross;
        }
        #endregion
        #region Команды контролов закладки Справочник

        /// <summary>
        /// Переход на сайт для открытия нового вопроса по добавлению устройства в Справочник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel_issues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/hoplik/Firehose-Finder/issues");
        }
        #endregion
    }
}
