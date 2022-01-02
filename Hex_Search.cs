using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        private void TextBox_byte_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_byte_search.Text)) button_start_search.Enabled = false;
            else button_start_search.Enabled = true;
        }

        private void TextBox_byte_search_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_byte_search.Text = textBox_byte_search.Text.ToUpper();
            textBox_byte_search.SelectionStart = textBox_byte_search.Text.Length;
        }
        private void TextBox_hexsearch_TextChanged(object sender, EventArgs e)
        {
            textBox_byte_search.Text = string.Empty;
            byte[] convstrtobyte = new byte[textBox_hexsearch.Text.Count()];
            for (int i = 0; i < convstrtobyte.Length; i++)
            {
                convstrtobyte[i] = (byte)textBox_hexsearch.Text[i];
                textBox_byte_search.Text += string.Format("{0:X2}", convstrtobyte[i]);
            }
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
            if (textBox_byte_search.Text.Length % 2 != 0) textBox_byte_search.Text = "0" + textBox_byte_search.Text;
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
                backgroundWorker_hex_search.RunWorkerAsync(new Search_Hex(inputsearch, textBox_byte_search.Text));
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
                int maxbytes = 536870912;
                if (fi.Length >= hex_search.SearchString.Length / 2) //Длина файла не менее длины строки поиска, иначе вываливаемся
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fullfilename, FileMode.Open)))
                    {
                        //Перегнали файл в отсортированный список массивов байт
                        if (fi.Length < maxbytes) maxbytes = Convert.ToInt32(fi.Length);
                        int countarray = Convert.ToInt32(fi.Length / maxbytes); //Размер двумерного массива для больших файлов
                        byte[] chunk = new byte[maxbytes];
                        SortedList<int, byte[]> chunkarray = new SortedList<int, byte[]>();
                        for (int i = 0; i < countarray; i++)
                        {
                            chunk = reader.ReadBytes(maxbytes);
                            chunkarray[i] = chunk;
                        }
                        //Ищем совпадения и фиксируем адрес и значение
                        foreach (Search_Result sr in CompareBytes(maxbytes, chunkarray, fi.Name)) addr_value_file.Add(sr);
                    }
                }
                //Завершающие процедуры для одного файла из списка
                worker.ReportProgress(countfile * 100 / currfiles, addr_value_file);//string.Format("{0} - {1} из {2}", fi.Name, countfile, currfiles)
                countfile++;
            }
            //e.Result = addr_value_file;
        }

        private void BackgroundWorker_hex_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) toolStripStatusLabel_search.Text = e.Error.Message;
            else
            {
                toolStripProgressBar_search.Value = 0;
                //По исполнению группируем
                //ListViewGroup group = new ListViewGroup(filesafename);
            }
        }

        private void BackgroundWorker_hex_search_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            //toolStripStatusLabel_search.Text = "Последний обработанный файл " + e.UserState.ToString();
            List<Search_Result> result = (List<Search_Result>)e.UserState;
            //Заполняем листвью списком совпадений
            if (result.Count == 0) toolStripStatusLabel_search.Text = "Совпадений не найдено";
            else
            {
                foreach (Search_Result sr in result)
                {
                    ListViewItem hsearchres = new ListViewItem("0x" + sr.Adress_hex.ToUpper());
                    hsearchres.SubItems.Add(sr.Result_String);
                    hsearchres.SubItems.Add(sr.File_Name);
                    listView_search.Items.Add(hsearchres);
                    toolStripStatusLabel_search.Text = string.Format("Найдено {0} совпадений в файле {1}.", result.Count, sr.File_Name);
                }
                for (int i = 0; i < listView_search.Columns.Count; i++) listView_search.Columns[i].Width = -1;
            }
        }


        private List<Search_Result> CompareBytes(int maxbytes, SortedList<int, byte[]> dumpbytes, string filename)
        {
            List<Search_Result> search_Results = new List<Search_Result>();
            byte[] searchstringinbytes = new byte[textBox_byte_search.Text.Length / 2];
            int comparecount = 0; //Счётчик для положения байт строки поиска
            for (int i = 0; i < textBox_byte_search.Text.Length / 2; i++)
            {
                searchstringinbytes[i] = Convert.ToByte(textBox_byte_search.Text.Substring(i * 2, 2), 16);
            }
            //Цикл для совпадений
            foreach (KeyValuePair<int, byte[]> item in dumpbytes)
            {
                //Выполняется для одиночного массива из списка массивов
                for (int i = 0; i < item.Value.Count(); i++)
                {
                    if (item.Value[i].Equals(searchstringinbytes[comparecount]))
                    {
                        comparecount++;
                        if (comparecount >= searchstringinbytes.Length)
                        {
                            //Получили совпадение
                            int frontdump = Convert.ToInt32(textBox_addfirst.Text); //Количество байт перед строкой поиска
                            int reardump = Convert.ToInt32(textBox_addlast.Text); //Количество байт после строки поиска
                            int addr = (item.Key * maxbytes) + (i - (searchstringinbytes.Length - 1));
                            Search_Result sr = new Search_Result(Convert.ToString(addr, 16), string.Empty, filename);
                            //Меняем количество символов для чтения пред и после поиска
                            if (addr - frontdump < 0) frontdump = addr;
                            if (addr + searchstringinbytes.Length + reardump > item.Value.Count()) reardump = Convert.ToInt32(item.Value.Count() - (addr + searchstringinbytes.Length));
                            int reslen = frontdump + searchstringinbytes.Length + reardump;
                            sr.Result_String = (addr-frontdump).ToString() + "_"+reslen.ToString();
                            //Сбросили счётчик совпадений
                            comparecount = 0;
                            search_Results.Add(sr);
                        }
                    }
                    else comparecount = 0;
                }
                if (search_Results.Count>0)
                {
                    //Преобразуем сдвиг_длина в строку данных
                    foreach (Search_Result sri in search_Results)
                    {
                        string[] resarray = sri.Result_String.Split('\u005F');
                        for (int i = Convert.ToInt32(resarray[0]); i < Convert.ToInt32(resarray[1]); i++)
                        {
                            sri.Result_String += item.Value[i];
                        }
                    }
                }
            }
            return search_Results;
        }

        private void ListView_search_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(listView_search.SelectedItems[0].Text);
            toolStripStatusLabel_search.Text = "Адрес скопирован в буфер обмена";
        }

        private void RadioButton_search_text_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_search_text.Checked == true)
            {
                textBox_byte_search.Enabled = false;
                textBox_hexsearch.Enabled = true;
            }
        }

        private void RadioButton_byte_search_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_byte_search.Checked == true)
            {
                textBox_byte_search.Enabled = true;
                textBox_hexsearch.Enabled = false;
            }
        }
    }
}
