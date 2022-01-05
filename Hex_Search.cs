using System;
using System.Collections;
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
        Hashtable TableGroups = new Hashtable();
        public Hex_Search()
        {
            InitializeComponent();
        }

        private void TextBox_byte_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_byte_search.Text)) button_start_search.Enabled = false;
            else
            {
                textBox_byte_search.Text = func.DelUnknownChars(textBox_byte_search.Text, Func.System_Count.hex);
                textBox_byte_search.SelectionStart = textBox_byte_search.Text.Length;
                button_start_search.Enabled = true;
            }
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
                textBox_hexsearch.Text=string.Empty;
            }
        }

        private void RadioButton_byte_search_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_byte_search.Checked == true)
            {
                textBox_byte_search.Enabled = true;
                textBox_byte_search.Text=string.Empty;
                textBox_hexsearch.Enabled = false;
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
            listView_search.Items.Clear(); //Очищаем элементы
            listView_search.Groups.Clear(); //Очищаем группы элементов
            TableGroups.Clear();//Очищаем таблицу групп
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
                    FileInfo fileInfo = new FileInfo(filename.Key);
                    inputsearch.Add(filename.Key);
                    //Создаём группы по именам файлов
                    CreateTableGroups(fileInfo.Name);
                }
                //Создаём сущность Словарь+поиск и её отправляем в поток
                toolStripStatusLabel_search.Text = "Обработка запроса ...";
                backgroundWorker_hex_search.RunWorkerAsync(new Search_Hex(inputsearch, textBox_byte_search.Text));
            }
        }

        private void BackgroundWorker_hex_search_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Search_Hex hex_search = (Search_Hex)e.Argument;
            int countfile = 1; //Счётчик обработанных файлов
            int currfiles = hex_search.FullFileNames.Count; //Всего файлов для обработки
            //Перебираем всю коллекцию файлов для поиска по очереди
            foreach (string fullfilename in hex_search.FullFileNames)
            {
                FileInfo fi = new FileInfo(fullfilename);
                List<Search_Result> addr_value_file = new List<Search_Result>(); //Результат выполнения потока (адрес, строка поиска, имя файла)
                int maxbytes = 268435456;//536870912;
                if (fi.Length >= hex_search.SearchString.Length / 2) //Длина файла не менее длины строки поиска, иначе вываливаемся
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fullfilename, FileMode.Open)))
                    {
                        //Перегнали файл в отсортированный список массивов байт
                        if (fi.Length <= maxbytes) maxbytes = Convert.ToInt32(fi.Length);
                        int countarray = Convert.ToInt32(fi.Length / maxbytes); //Размер двумерного массива для больших файлов
                        byte[] chunk = new byte[maxbytes];
                        SortedList<int, byte[]> chunkarray = new SortedList<int, byte[]>();
                        for (int i = 0; i < countarray; i++)
                        {
                            chunk = reader.ReadBytes(maxbytes);
                            chunkarray[i] = chunk;
                            if (countarray!=0&&hex_search.FullFileNames.Count==1) worker.ReportProgress(i*100/countarray);
                        }
                        //Ищем совпадения и фиксируем адрес и значение
                        addr_value_file.AddRange(CompareBytes(maxbytes, chunkarray, fi.Name));
                    }
                }
                //Завершающие процедуры для одного файла из списка
                worker.ReportProgress(countfile * 100 / currfiles, addr_value_file);
                countfile++;
            }
        }

        private void BackgroundWorker_hex_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) toolStripStatusLabel_search.Text = e.Error.Message;
            else
            {
                toolStripProgressBar_search.Value = 0;
                if (listView_search.Items.Count==0) toolStripStatusLabel_search.Text = "Совпадений не найдено";
                else toolStripStatusLabel_search.Text =string.Format("Найдено {0} совпадений в {1} из {2} файлах.", listView_search.Items.Count, listView_search.Groups.Count, TableGroups.Count);
            }
        }

        private void BackgroundWorker_hex_search_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState!=null)
            {
                List<Search_Result> result = (List<Search_Result>)e.UserState;
                //Заполняем листвью списком совпадений
                if (result.Count == 1) toolStripStatusLabel_search.Text =string.Format("Совпадений в файле {0} не найдено - {1}% обработано.", result[0].File_Name, e.ProgressPercentage);
                else
                {
                    foreach (Search_Result sr in result)
                    {
                        if (!string.IsNullOrEmpty(sr.Adress_hex))
                        {
                            //Проверяем наличие группы
                            if (!listView_search.Groups.Contains((ListViewGroup)TableGroups[sr.File_Name]))
                            {
                                listView_search.Groups.Add((ListViewGroup)TableGroups[sr.File_Name]);
                            }
                            ListViewItem hsearchres = new ListViewItem("0x" + sr.Adress_hex.ToUpper());
                            hsearchres.SubItems.Add(sr.Result_String);
                            hsearchres.SubItems.Add(sr.File_Name);
                            hsearchres.Group=(ListViewGroup)TableGroups[sr.File_Name];
                            listView_search.Items.Add(hsearchres);
                            toolStripStatusLabel_search.Text = string.Format("Обработан файл {0}, найдено {1} совпадений.", sr.File_Name, listView_search.Items.Count);
                        }
                    }
                    for (int i = 0; i < listView_search.Columns.Count; i++) listView_search.Columns[i].Width = -1;
                }
            }
            toolStripProgressBar_search.Value = e.ProgressPercentage;
        }

        private List<Search_Result> CompareBytes(int maxbytes, SortedList<int, byte[]> dumpbytes, string filename)
        {
            List<Search_Result> search_Results = new List<Search_Result>
            {
                new Search_Result(string.Empty, string.Empty, filename)
            };
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
                            int addr = i - (searchstringinbytes.Length - 1);
                            Search_Result sr = new Search_Result(Convert.ToString((item.Key * maxbytes)+addr, 16), string.Empty, filename);
                            //Меняем количество символов для чтения пред и после поиска
                            if (addr - frontdump < 0) frontdump = addr;
                            if (addr + searchstringinbytes.Length + reardump > item.Value.Count()) reardump = Convert.ToInt32(item.Value.Count() - (addr + searchstringinbytes.Length));
                            int reslen = frontdump + searchstringinbytes.Length + reardump;
                            byte[] bytetores = new byte[reslen];
                            for (int br = 0; br < reslen; br++)
                            {
                                bytetores[br] = item.Value[addr-frontdump+br];
                            }
                            sr.Result_String = func.ByEight(bytetores, reslen);//BitConverter.ToString(item.Value, addr-frontdump, reslen);
                            //Сбросили счётчик совпадений
                            comparecount = 0;
                            search_Results.Add(sr);
                        }
                    }
                    else comparecount = 0;
                }
            }
            return search_Results;
        }

        private Hashtable CreateTableGroups(string subitemstr)
        {
            Hashtable groups = new Hashtable();
            if (!TableGroups.ContainsKey(subitemstr))
            {
                ListViewGroup group = new ListViewGroup(subitemstr, HorizontalAlignment.Left);
                TableGroups.Add(subitemstr, group);
            }
            return groups;
        }
    }
}
