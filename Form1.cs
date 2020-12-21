using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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
            richTextBox_about.Text = FirehoseFinder.Properties.Resources.String_about + Environment.NewLine
                + "Ссылка на базовую тему <<Общие принципы восстановления загрузчиков на Qualcomm | HS - USB QDLoader 9008, HS - USB Diagnostics 9006, QHUSB_DLOAD и т.д.>>: " + FirehoseFinder.Properties.Resources.String_theme_link + Environment.NewLine
                + Environment.NewLine
                + "Версия сборки: " + Assembly.GetExecutingAssembly().GetName().Version + Environment.NewLine
                + Environment.NewLine
                + "По вопросам поддержки, пожалуйста, обращайтесь: " + FirehoseFinder.Properties.Resources.String_help + Environment.NewLine
                + Environment.NewLine
                + "Часто задаваемые вопросы: " + Environment.NewLine + FirehoseFinder.Properties.Resources.String_faq1
                + Environment.NewLine + FirehoseFinder.Properties.Resources.String_faq2;
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
            button_startscan.Visible = false;
            toolStripStatusLabel_filescompleted.Text = string.Empty;
            toolStripStatusLabel_vol.Text = string.Empty;
            toolStripProgressBar_filescompleted.Value = 0;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_path.Text = folderBrowserDialog1.SelectedPath;
                Algoritm();
            }
        }

        /// <summary>
        /// Заглушка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_startscan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока ещё не придумал.");
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
                    if (Convert.ToBoolean(dataGridView_final.Rows[e.RowIndex].Cells[0].Value))
                    {
                        dataGridView_final.Rows[e.RowIndex].Cells[0].Value = false;
                        button_startscan.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView_final.Rows.Count; i++)
                        {
                            dataGridView_final.Rows[i].Cells[0].Value = false;
                        }
                        dataGridView_final.Rows[e.RowIndex].Cells[0].Value = true;
                        button_startscan.Visible = true;
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
                DialogResult dr = MessageBox.Show(dataGridView_final.Rows[e.RowIndex].Cells[4].Value.ToString(), "Сохранить данные в буфер обмена?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(dataGridView_final.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
        }

        #endregion

        #region Функции самостоятельных команд
        /// <summary>
        /// Алгоритм расчёта количества файлов в папке и их суммарный размер
        /// </summary>
        private void Algoritm()
        {
            ulong volFiles = 0;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text);
            foreach (KeyValuePair<string, long> WL in Resfiles)
            {
                volFiles += Convert.ToUInt64(WL.Value); // суммарный объём файлов для анализа
            }
            int numFiles = Resfiles.Count; // количество файлов для обработки
            int Currnum = 0; // текущий номер файла
            ulong Currvol = 0; // текущий объём
            dataGridView_final.Rows.Clear();
            foreach (KeyValuePair<string, long> countfiles in Resfiles)
            {
                int currrating = func.Rating(countfiles.Key);
                dataGridView_final.Rows.Add();
                dataGridView_final.Rows[Currnum].Cells[1].Value = Path.GetFileName(countfiles.Key);
                if (currrating != 0)
                {
                    if (Func.ElfReader(button_path.Text + "\\" + dataGridView_final.Rows[Currnum].Cells[1].Value, 8).StartsWith("7F454C45"))
                    {
                        dataGridView_final.Rows[Currnum].Cells[1].Style.BackColor = Color.Yellow;
                        dataGridView_final.Rows[Currnum].Cells[1].ToolTipText = "Файл не является ELF!";
                    }
                    string[] id = func.IDs(countfiles.Key);
                    string oemhash = string.Empty;
                    if (id[3].Length < 64)
                    {
                        oemhash = id[3];
                    }
                    else
                    {
                        oemhash = id[3].Substring(56);
                    }
                    dataGridView_final.Rows[Currnum].Cells[2].Value = id[0] + "-" + id[1] + "-" + id[2] + "-" + oemhash + "-" + id[4] + id[5];
                    dataGridView_final.Rows[Currnum].Cells[4].Value = "HW_ID (процессор) - " + id[0] + Environment.NewLine +
                        "OEM_ID (производитель) - " + id[1] + Environment.NewLine + "MODEL_ID (модель) - " + id[2] + Environment.NewLine +
                        "OEM_HASH (хеш корневого сертификата) - " + id[3] + Environment.NewLine + "SW_ID (тип программы (версия)) - " + id[4] + id[5];

                    if (guide.SW_ID_type.ContainsKey(id[4])) dataGridView_final.Rows[Currnum].Cells[5].Value = guide.SW_ID_type[id[4]];

                    if (String.Compare(textBox_hwid.Text, id[0]) == 0) // Процессор такой же
                    {
                        textBox_hwid.BackColor = Color.LawnGreen;
                        currrating += 2;
                    }
                    if (String.Compare(textBox_oemid.Text, id[1]) == 0) // Производитель один и тот же
                    {
                        textBox_oemid.BackColor = Color.LawnGreen;
                        currrating += 2;
                    }
                    if (String.Compare(textBox_modelid.Text, id[2]) == 0) // Модели равны
                    {
                        textBox_modelid.BackColor = Color.LawnGreen;
                        currrating++;
                    }
                    if (id[3].Length >= 64)
                    {
                        if (String.Compare(textBox_oemhash.Text, id[3].Substring(0, 64)) == 0) // Хеши равны
                        {
                            textBox_oemhash.BackColor = Color.LawnGreen;
                            currrating += 2;
                        }
                    }
                    if (id[4].StartsWith("3")) // SWID начинается с 3
                    {
                        currrating++;
                    }
                }
                else
                {
                    dataGridView_final.Rows[Currnum].ReadOnly = true; // Рейтинг 0 не обрабатываем
                    dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.LightGray;
                }
                dataGridView_final.Rows[Currnum].Cells[3].Value = currrating;
                dataGridView_final.Rows[Currnum].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Currnum++;
                Currvol += Convert.ToUInt64(countfiles.Value);
                toolStripStatusLabel_filescompleted.Text = "Обработано " + Currnum.ToString() + " файлов из " + numFiles.ToString();
                toolStripProgressBar_filescompleted.Maximum = Convert.ToInt32(volFiles);
                toolStripProgressBar_filescompleted.Value = Convert.ToInt32(Currvol);
                toolStripStatusLabel_vol.Text = Currvol.ToString("### ### ### ###") + " байт";
            }
            dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);
        }
        #endregion
    }
}


