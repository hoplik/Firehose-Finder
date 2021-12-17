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
            listView_hex_search.Items.Clear();
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
            List<Search_Result> addr_value_file = new List<Search_Result>();
            int countfile = 1;
            int currfiles = hex_search.FullFileNames.Count;
            foreach (string fullfilename in hex_search.FullFileNames)
            {
                FileInfo fi = new FileInfo(fullfilename);
                Search_Result sr = new Search_Result(string.Empty, string.Empty, fi.Name);
                if (fi.Length >= hex_search.SearchString.Length / 2) //Длина файла должна быть не менее длины строки поиска
                {
                    int frontdump = 4; //Количество байт перед строкой поиска (потом поменять на динамические)
                    int reardump = 4; //Количество байт после строки поиска (потом поменять на динамические)
                    var chunk = new byte[hex_search.SearchString.Length / 2];
                    using (var stream = File.OpenRead(fullfilename))
                    {
                        for (int i = 0; i < fullfilename.Length; i++)
                        {
                            if (string.Format("{0:X2}", stream.ReadByte()).Equals(hex_search.SearchString.Substring(0, 2)))
                            {
                                sr.Adress_hex = i.ToString();
                            }
                            else
                            {

                            }
                        }
                        int byteschunk = stream.Read(chunk, 0, 4);
                        //for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                        //if (Enum.IsDefined(typeof(Guide.FH_magic_numbers), Convert.ToUInt32(dumptext.ToString(), 16)))
                        //{
                        //    dumptext.Clear();
                        //    stream.Position = 0;
                        //    byteschunk = stream.Read(chunk, 0, len);
                        //    for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                        //}
                    }
                    sr.Result_String = "****" + hex_search.SearchString + "****";
                    addr_value_file.Add(sr);
                    worker.ReportProgress(countfile * 100 / currfiles, string.Format("{0} из {1}", countfile, currfiles));
                    countfile++;
                }
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
                if (result.Count > 1)
                {
                    //По исполнению заполняем листвью списком совпадений
                    //ListViewGroup group = new ListViewGroup(filesafename);
                    foreach (Search_Result sr in result)
                    {
                        ListViewItem hsearchres = new ListViewItem(sr.Adress_hex);
                        hsearchres.SubItems.Add(sr.Result_String);
                        hsearchres.SubItems.Add(sr.File_Name);
                        listView_hex_search.Items.Add(hsearchres);
                    }
                    toolStripStatusLabel_search.Text = string.Format("Найдено {0} совпадений в {1} файлах", result.Count, "всех");
                }
                else
                {
                    toolStripStatusLabel_search.Text = "Совпадения не найдены";
                }
            }
        }

        private void BackgroundWorker_hex_search_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            toolStripStatusLabel_search.Text = "Обрабатывается файл " + e.UserState.ToString();
        }
    }
}
