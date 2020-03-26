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
        public Formfhf()
        {
            InitializeComponent();
        }

        private void Button_path_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_path.Text = folderBrowserDialog1.SelectedPath;
                Algoritm();
            }
        }
        private void Algoritm()
        {
            Func func = new Func();
            _ = new Dictionary<string, long>();
            int volFiles = 0;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text);
            foreach (KeyValuePair<string, long> WL in Resfiles)
            {
                volFiles += Convert.ToInt32(WL.Value);//суммарный объём файлов для анализа
            }
            int numFiles = Resfiles.Count;//количество файлов для обработки
            /*запускаем индикатор выполнения*/
            int Currnum = 0;//текущий номер файла
            long Currvol = 0;//текущий объём
            dataGridView_final.Rows.Clear();
            foreach (KeyValuePair<string, long> countfiles in Resfiles)
            {
                int currrating = func.Rating(countfiles.Key);
                dataGridView_final.Rows.Add();
                dataGridView_final.Rows[Currnum].Cells[1].Value = Path.GetFileName(countfiles.Key);
                if (currrating != 0)
                {
                    string[] id = func.IDs(countfiles.Key);
                    dataGridView_final.Rows[Currnum].Cells[2].Value = id[0] + "-" + id[1] + "-" + id[2] + "-" + id[3] + "-" + id[4];
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
                    if (String.Compare(textBox_oemhash.Text, id[3]) == 0) // Хеши равны
                    {
                        textBox_oemhash.BackColor = Color.LawnGreen;
                        currrating += 2;
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
                Currnum++;
                Currvol += countfiles.Value;
                toolStripStatusLabel_filescompleted.Text = "Обработано " + Currnum.ToString() + " файлов из " + numFiles.ToString();
                toolStripProgressBar_filescompleted.Maximum = volFiles;
                toolStripProgressBar_filescompleted.Value = Convert.ToInt32(Currvol);
                toolStripStatusLabel_vol.Text = Currvol.ToString() + " байт";
            }
            dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);

        }
        private void Button_startscan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока ещё не придумал.");
        }
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
                + "По вопросам поддержки, пожалуйста, обращайтесь: " + FirehoseFinder.Properties.Resources.String_help;
        }

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
                MessageBox.Show("Стоит сначала выбрать рабочую директорию" + Environment.NewLine + ex.Message);
            }
        }
    }
}

