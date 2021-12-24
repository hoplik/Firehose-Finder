using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Hex_Search : Form
    {
        Func func = new Func();

        public Hex_Search()
        {
            InitializeComponent();
        }

        private void TextBox_hexsearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_hexsearch.Text)) button_start_search.Enabled = false;
            else button_start_search.Enabled = true;
        }

        private void Button_start_search_Click(object sender, EventArgs e)
        {
            Dictionary<string, long> filestosearch = new Dictionary<string, long>();
            if (backgroundWorker_hex_search.IsBusy)
            {
                //Если паралельный поток ещё выполняется, предлагаем остановить
                if (MessageBox.Show("Осторожно, вы предпринимаете попытку остановить длительную процедуру поиска" +
                    " Нажимая кнопку \"Ok\", вы подтверждаете выполнение операции.",
                    "Внимание, остановка длительной операции!",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {

                    backgroundWorker_hex_search.CancelAsync();
                    toolStripStatusLabel_search.Text = "Текущий поиск отменён пользователем.";
                    toolStripProgressBar_search.Value = 0;
                }
            }
            listView_search.Items.Clear();
            toolStripStatusLabel_search.Text = string.Empty;
            if (textBox_hexsearch.Text.Length % 2 != 0) textBox_hexsearch.Text = "0" + textBox_hexsearch.Text;
            if (radioButton_file.Checked)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(openFileDialog1.FileName);
                    button_start_search.Text = fi.FullName;
                    filestosearch.Add(fi.FullName, fi.Length);
                }
            }
            if (radioButton_dir.Checked)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    button_start_search.Text = folderBrowserDialog1.SelectedPath;
                    filestosearch = func.WFiles(folderBrowserDialog1.SelectedPath, false);
                }
            }
            if (filestosearch.Count > 0)
            {
                List<string> inputsearch = new List<string>();
                foreach (KeyValuePair<string, long> filename in filestosearch)
                {
                    inputsearch.Add(filename.Key);
                }
                //Создаём сущность Словарь+поиск и её отправляем в поток
                backgroundWorker_hex_search.RunWorkerAsync(new Search_Hex(inputsearch, textBox_hexsearch.Text));
            }
        }

        private void BackgroundWorker_hex_search_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Search_Hex hex_search = (Search_Hex)e.Argument;
            List<Search_Result> addr_value_file = new List<Search_Result>(); //Результат выполнения потока (адрес, строка поиска, имя файла)
            int countfile = 1; //Счётчик обработанных файлов
            int currfiles = hex_search.FullFileNames.Count; //Всего файлов для обработки
            //Перебираем всю коллекцию файлов для поиска по очереди
            foreach (string fullfilename in hex_search.FullFileNames)
            {
                FileInfo fi = new FileInfo(fullfilename);
                Dictionary<long, string> start_adress_file = new Dictionary<long, string>(); //Список адресов с совпадениями поиска
                if (fi.Length >= hex_search.SearchString.Length / 2) //Длина файла не менее длины строки поиска, иначе вываливаемся
                {
                    using (FileStream stream = File.OpenRead(fullfilename))
                    {
                        //Перегнали файл в массив байт
                        byte[] bytes = new byte[fi.Length];
                        int numBytesToRead = (int)fi.Length;
                        int sector = 512;
                        int numBytesRead = 0;
                        do
                        {
                            if (numBytesToRead < sector) sector = numBytesToRead;
                            int n = stream.Read(bytes, numBytesRead, sector);
                            numBytesRead += n;
                            numBytesToRead -= n;
                        } while (numBytesToRead > 0);
                        //Перегоним массив байт в стрингбилдер
                        StringBuilder tempstringsearch = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            tempstringsearch.Append(string.Format("{0:X2}", (int)bytes[i]));
                        }
                        //Ищем совпадения и фиксируем адрес и значение
                        do
                        {
                            Search_Result sr = new Search_Result(string.Empty, string.Empty, fi.Name);
                            int frontdump = 4; //Количество байт перед строкой поиска (потом поменять на динамические)
                            int reardump = 4; //Количество байт после строки поиска (потом поменять на динамические)
                            int addr = tempstringsearch.ToString().LastIndexOf(hex_search.SearchString);
                            if (addr == -1) tempstringsearch.Clear();
                            else
                            {
                                if (addr % 2 != 0)
                                {
                                    tempstringsearch.Remove(addr + 1, tempstringsearch.Length - (addr + 1));
                                }
                                sr.Adress_hex = Convert.ToString(addr / 2, 16);
                                //Меняем количество символов для чтения пред и после поиска
                                if (addr - (2 * frontdump) < 0) frontdump = addr / 2;
                                if (addr + hex_search.SearchString.Length + (2 * reardump) > fi.Length * 2) reardump = Convert.ToInt32(fi.Length - (addr / 2)) - (hex_search.SearchString.Length / 2);
                                int reslen = (2 * frontdump) + hex_search.SearchString.Length + (2 * reardump);
                                sr.Result_String = tempstringsearch.ToString().Substring(addr - (2 * frontdump), reslen);
                                if (tempstringsearch.Length >= reslen - (2 * frontdump)) tempstringsearch.Remove(addr, tempstringsearch.Length - addr);
                                else tempstringsearch.Clear();
                                addr_value_file.Insert(0, sr);
                            }
                        } while (tempstringsearch.Length > hex_search.SearchString.Length);
                    }
                }
                //Завершающие процедуры для одного файла из списка
                worker.ReportProgress(countfile * 100 / currfiles, string.Format("{0} - {1} из {2}", fi.Name, countfile, currfiles));
                countfile++;
            }
            e.Result = addr_value_file;
        }

        private void BackgroundWorker_hex_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) toolStripStatusLabel_search.Text = e.Error.Message;
            else
            {
                toolStripProgressBar_search.Value = 0;
                List<Search_Result> result = (List<Search_Result>)e.Result;
                //По исполнению заполняем листвью списком совпадений
                //ListViewGroup group = new ListViewGroup(filesafename);
                if (result.Count == 0) toolStripStatusLabel_search.Text = "Совпадений не найдено";
                else
                {
                    foreach (Search_Result sr in result)
                    {
                        ListViewItem hsearchres = new ListViewItem("0x" + sr.Adress_hex.ToUpper());
                        hsearchres.SubItems.Add(sr.Result_String);
                        hsearchres.SubItems.Add(sr.File_Name);
                        listView_search.Items.Add(hsearchres);
                        toolStripStatusLabel_search.Text = string.Format("Найдено {0} совпадений в {1} файлах", result.Count, "счётчик группы");
                    }
                }
            }
        }

        private void BackgroundWorker_hex_search_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            toolStripStatusLabel_search.Text = "Последний обработанный файл " + e.UserState.ToString();
        }

        private void TextBox_hexsearch_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_hexsearch.Text = textBox_hexsearch.Text.ToUpper();
            textBox_hexsearch.SelectionStart = textBox_hexsearch.Text.Length;
        }
    }
}
