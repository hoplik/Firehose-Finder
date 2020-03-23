using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

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
                button_startscan.Visible = true;
            }
        }
        private void Button_startscan_Click(object sender, EventArgs e)
        {
            button_startscan.Visible = false;
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
                dataGridView_final.Rows[Currnum].Cells[3].Value = currrating;
                if (currrating != 0)
                {
                    string id1 = func.HWID(countfiles.Key);
                    string id2 = func.OEMID(countfiles.Key);
                    string id3 = func.MODELID(countfiles.Key);
                    string id4 = func.HASH(countfiles.Key);
                    dataGridView_final.Rows[Currnum].Cells[2].Value = id1 + "-" + id2 + "-" + id3 + "-" + id4;
                    //Tests(countfiles.Key);
                }
                Currnum++;
                Currvol += countfiles.Value;
                toolStripStatusLabel_filescompleted.Text = "Обработано " + Currnum.ToString() + " файлов из " + numFiles.ToString();
                toolStripProgressBar_filescompleted.Maximum = volFiles;
                toolStripProgressBar_filescompleted.Value = Convert.ToInt32(Currvol);
                toolStripStatusLabel_vol.Text = Currvol.ToString() + " байт";
            }
            dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);
        }
        /*
                /// <summary>
                /// Запуск подпрограммы обработки файла. Чтение байт в хекс.
                /// </summary>
                /// <param name="fullpathfile">Полный путь к текущему файлу для обработки</param>
                private void Tests(string fullpathfile)
                {
                    byte[] chunk = new byte[64];
                    using (var stream = File.OpenRead(fullpathfile))
                    {
                        int byteschunk = stream.Read(chunk, 0, 64);
                        DumpBytes(chunk, byteschunk);
                    }
                }
                /// <summary>
                /// Временная команда отображения хекс-байт для каждого из файлов. После будет заменена на анализ.
                /// </summary>
                /// <param name="bdata">Массив байт для анализа</param>
                /// <param name="len">Размер массива байт</param>
                public static void DumpBytes(byte[] bdata, int len)
                {
                    int i;
                    int j = 0;
                    char dchar;
                    if (bdata != null)
                    {
                        // 3 * 16 знаков для хекс отображения (00 ) в начале, 8 знаков - пробелы в середине и 16 знаков на текст
                        StringBuilder dumptext = new StringBuilder("        ", 16 * 4 + 8);
                        for (i = 0; i < len; i++)
                        {
                            dumptext.Insert(j * 3, String.Format("{0:X2} ", (int)bdata[i]));
                            dchar = (char)bdata[i];
                            // заменяем непечатные символы точкой
                            if (Char.IsWhiteSpace(dchar) || Char.IsControl(dchar))
                            {
                                dchar = '.';
                            }
                            dumptext.Append(dchar);
                            j++;
                            if (j == 16)
                            {
                                MessageBox.Show("Обработано " + (i + 1).ToString() + " записей" + Environment.NewLine + dumptext.ToString());
                                dumptext.Length = 0;
                                dumptext.Append("        ");
                                j = 0;
                            }
                        }
                        // добиваем до 16 символов пробелами последнюю неполную строку
                        if (j > 0)
                        {
                            for (i = j; i < 16; i++)
                            {
                                dumptext.Insert(j * 3, "   ");
                            }
                            MessageBox.Show("Это последняя неполная строка" + Environment.NewLine + dumptext.ToString());
                        }
                    }
                }*/
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
    }
}

