using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace FirehoseFinder
{
    public partial class Hex_Search : Form
    {
        Func func = new Func();
        List<File_Struct> orig_list = new List<File_Struct>(); //Основной список (полный путь к файлу - хеш)
        List<File_Struct> dubl_list = new List<File_Struct>(); //Дубликаты (полный путь к файлу - хеш)
        Hashtable TableGroups = new Hashtable();
        readonly ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);
        public Hex_Search()
        {
            InitializeComponent();
        }
        #region Вкладка "Поиск по маске
        private void TextBox_byte_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_byte_search.Text)) button_start_search.Enabled = false;
            else
            {
                textBox_byte_search.Text = func.DelUnknownChars(textBox_byte_search.Text, Func.System_Count.hex);
                textBox_byte_search.SelectionStart = textBox_byte_search.TextLength;
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
            toolStripStatusLabel_search.Text = LocRes.GetString("hex_note_copyoffset");
        }

        private void RadioButton_search_text_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_search_text.Checked == true)
            {
                textBox_byte_search.Enabled = false;
                textBox_hexsearch.Enabled = true;
                textBox_hexsearch.Text = string.Empty;
            }
        }

        private void RadioButton_byte_search_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_byte_search.Checked == true)
            {
                textBox_byte_search.Enabled = true;
                textBox_byte_search.Text = string.Empty;
                textBox_hexsearch.Enabled = false;
            }
        }

        private void Button_start_search_Click(object sender, EventArgs e)
        {
            Dictionary<string, long> filestosearch = new Dictionary<string, long>();
            if (backgroundWorker_hex_search.IsBusy)
            {
                //Если паралельный поток ещё выполняется, предлагаем остановить
                if (MessageBox.Show(LocRes.GetString("hex_mess_stopoper"),
                    LocRes.GetString("hex_warn_stopoper"),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {

                    backgroundWorker_hex_search.CancelAsync();
                    toolStripStatusLabel_search.Text = LocRes.GetString("hex_note_cancelsearch");
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
                toolStripStatusLabel_search.Text = LocRes.GetString("hex_note_process");
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
                if (listView_search.Items.Count==0) toolStripStatusLabel_search.Text = LocRes.GetString("hex_matches") + '\u0020' +
                        LocRes.GetString("hex_not") + '\u0020' +
                        LocRes.GetString("hex_found");
                else toolStripStatusLabel_search.Text = LocRes.GetString("hex_found") + '\u0020' +
                        listView_search.Items.Count.ToString() + '\u0020' +
                        LocRes.GetString("hex_matches") + '\u0020' +
                        LocRes.GetString("hex_in") + '\u0020' +
                        listView_search.Groups.Count.ToString() + '\u0020' +
                        LocRes.GetString("hex_from") + '\u0020' +
                        TableGroups.Count.ToString() + '\u0020' +
                        LocRes.GetString("hex_files");
            }
        }

        private void BackgroundWorker_hex_search_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState!=null)
            {
                List<Search_Result> result = (List<Search_Result>)e.UserState;
                //Заполняем листвью списком совпадений
                if (result.Count == 1) toolStripStatusLabel_search.Text = LocRes.GetString("hex_matches") + '\u0020' +
                        LocRes.GetString("hex_in") + '\u0020' +
                        LocRes.GetString("file") + '\u0020' +
                        result[0].File_Name + '\u0020' +
                        LocRes.GetString("hex_not") + '\u0020' +
                        LocRes.GetString("hex_found") + '\u0020' + '\u002D' + '\u0020' +
                        e.ProgressPercentage.ToString() + '\u0025' + '\u0020' +
                        LocRes.GetString("hex_processed");
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
                            toolStripStatusLabel_search.Text = LocRes.GetString("hex_processed") + '\u0020' +
                                LocRes.GetString("file") + '\u0020' +
                                sr.File_Name + '\u002C' + '\u0020' +
                                LocRes.GetString("hex_found") + '\u0020' +
                                listView_search.Items.Count.ToString() + '\u0020' +
                                LocRes.GetString("hex_matches");
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
                            sr.Result_String = func.ByEight(bytetores, reslen);
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
        /// <summary>
        /// Создаём таблицу групп
        /// </summary>
        /// <param name="subitemstr"></param>
        /// <returns></returns>
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
        #endregion
        #region Вкладка Сравнить файлы
        private void Button_of_Click(object sender, EventArgs e)
        {
            if (openFileDialog_of.ShowDialog() == DialogResult.OK)
            {
                button_of.Text = openFileDialog_of.FileName;
                toolStripStatusLabel_search.Text = $"Выбрали оригинальный файл {openFileDialog_of.FileName}";
                comboBox_raw_secsize.SelectedIndex = CheckSecSize(openFileDialog_of.FileName);
            }
            else
            {
                button_of.Text = "Выберите оригинальный файл";
                toolStripStatusLabel_search.Text = "Отказались от выбора оригинального файла";
            }
        }
        private void Button_df_Click(object sender, EventArgs e)
        {
            if (openFileDialog_df.ShowDialog() == DialogResult.OK)
            {
                button_df.Text = openFileDialog_df.FileName;
                toolStripStatusLabel_search.Text = $"Выбрали файл для сравнения {openFileDialog_df.FileName}";
                comboBox_raw_secsize.SelectedIndex = CheckSecSize(openFileDialog_df.FileName);
                label_newdir.Text = MakeNewDir(openFileDialog_df.FileName);
            }
            else
            {
                button_df.Text = "Выберите файл для сравнения";
                toolStripStatusLabel_search.Text = "Отказались от выбора файла для сравнения";
            }
        }
        private void CheckBox_difraw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_difraw.Checked)
            {
                toolStripStatusLabel_search.Text = "Выбрали \"Сформировать rawprogram.xml для пакетной записи\"";
                groupBox_raw.Enabled = true;
                checkBox_difbin.Checked = true;
                button_comp.Enabled = true;
            }
            else
            {
                groupBox_raw.Enabled = false;
                toolStripStatusLabel_search.Text = "Отменили выбор \"Сформировать rawprogram.xml для пакетной записи\"";
                if (!checkBox_diftxt.Checked && !checkBox_difbin.Checked) button_comp.Enabled = false;
            }
        }
        private void CheckBox_difbin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_difbin.Checked)
            {
                toolStripStatusLabel_search.Text = "Выбрали \"Сохранить различающиеся данные в bin-формате\"";
                button_comp.Enabled = true;
            }
            else
            {
                toolStripStatusLabel_search.Text = "Отменили выбор \"Сохранить различающиеся данные в bin-формате\"";
                checkBox_difraw.Checked = false;
                if (!checkBox_diftxt.Checked && !checkBox_difraw.Checked) button_comp.Enabled = false;
            }
        }

        private void CheckBox_diftxt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_diftxt.Checked)
            {
                toolStripStatusLabel_search.Text = "Выбрали \"Сохранить различающиеся данные в txt-файл\"";
                button_comp.Enabled = true;
            }
            else
            {
                toolStripStatusLabel_search.Text = "Отменили выбор \"Сохранить различающиеся данные в txt-файл\"";
                if (!checkBox_difbin.Checked && !checkBox_difraw.Checked) button_comp.Enabled = false;
            }
        }
        private void Button_comp_Click(object sender, EventArgs e)
        {
            switch (button_comp.Text)
            {
                case "Сравнить":
                    if (checkBox_difraw.Checked && string.IsNullOrEmpty(textBox_raw_lun.Text))
                    {
                        MessageBox.Show("Необходимо указать номер диска (lun)");
                        break;
                    }
                    int secsize = 512;
                    if (comboBox_raw_secsize.SelectedIndex == 2) secsize = 4096;
                    if (!string.IsNullOrEmpty(comboBox_raw_secsize.Text)) secsize = Convert.ToInt32(comboBox_raw_secsize.Text);
                    FileInfo of = new FileInfo(openFileDialog_of.FileName);
                    FileInfo df = new FileInfo(openFileDialog_df.FileName);
                    CompareFiles_Struct comp_files = new CompareFiles_Struct(
                        checkBox_diftxt.Checked,
                        checkBox_difbin.Checked,
                        secsize,
                        of.FullName,
                        of.Length,
                        df.FullName,
                        df.Length,
                        label_newdir.Text
                        );
                    if (!backgroundWorker_comp.IsBusy)
                    {
                        button_of.Enabled = false;
                        button_df.Enabled = false;
                        button_comp.Text = "Остановить сравнение";
                        backgroundWorker_comp.RunWorkerAsync(comp_files);
                    }
                    break;
                case "Остановить сравнение":
                    toolStripStatusLabel_search.Text = "Останавливаем процедуру сравнения секторов";
                    if (backgroundWorker_comp.IsBusy) backgroundWorker_comp.CancelAsync();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Пытаемся автоматически определить размер сектора
        /// </summary>
        /// <param name="fullfilename"></param>
        /// <returns></returns>
        private int CheckSecSize(string fullfilename)
        {
            int secsizeindex;
            int bytestoread = 4104;
            byte[] gpt_bytes = new byte[bytestoread];
            string byte_mask = "4546492050415254"; //EFI PART
            using (FileStream fs_gpt = File.OpenRead(fullfilename))
            {
                fs_gpt.Position = 0;
                fs_gpt.Read(gpt_bytes, 0, bytestoread);
            }
            string sec = BitConverter.ToString(gpt_bytes).Replace("-", "");
            int sec_len = sec.IndexOf(byte_mask) / 2;
            switch (sec_len)
            {
                case 512:
                    secsizeindex = 1;
                    toolStripStatusLabel_search.Text = $"Размер сектора {sec_len} байт";
                    break;
                case 4096:
                    secsizeindex = 2;
                    toolStripStatusLabel_search.Text = $"Размер сектора {sec_len} байт";
                    break;
                default:
                    secsizeindex = 0;
                    toolStripStatusLabel_search.Text = "Размер сектора автоматически определить не удалось";
                    break;
            }
            return secsizeindex;
        }
        /// <summary>
        /// Создаём новую директорию для добавления в неё результатов сравнения
        /// </summary>
        private string MakeNewDir(string fullfilename)
        {
            FileInfo fi = new FileInfo(fullfilename);
            string newdir = fi.Name.Remove(fi.Name.IndexOf(fi.Extension));
            string newpath = fi.DirectoryName + "\\" + newdir;
            Directory.CreateDirectory(newpath);
            toolStripStatusLabel_search.Text = "Создали новую папку для хранения результатов сравнения " + newpath;
            return newpath;
        }
        /// <summary>
        /// Создаём файл записи
        /// </summary>
        /// <param name="SECTOR_SIZE">Размер сектора (512 или 4096)</param>
        /// <param name="filename">Имя итогового файла записи (*.bin)</param>
        /// <param name="physical_partition">Номер диска</param>
        /// <param name="HexStartLBA">Хекс стартового адреса сектора</param>
        /// <param name="sectors_count">Количество секторов для записи</param>
        internal void FhXml(string workDir, List<RawProg_Data> rawProg_Datas, string lunnum)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldecl;
            StringBuilder xmlloadargs = new StringBuilder("<data>");
            xmldecl = doc.CreateXmlDeclaration("1.0", string.Empty, null);
            //Примечание
            xmlloadargs.Append("<!--NOTE: This is an **Autogenerated file **-->");
            xmlloadargs.Append("<!--NOTE: For use with FhF only-->");
            //Готовим файл для записи
            foreach (RawProg_Data item in rawProg_Datas)
            {
                long si_kb = Convert.ToInt64(item.NumSectors) * Convert.ToInt32(item.SectorSize) / 1024;
                long sb_hex = Convert.ToInt64(item.StartSector_Hex, 16) * Convert.ToInt32(item.SectorSize);
                xmlloadargs.Append("<program" + '\u0020' +
                    $"SECTOR_SIZE_IN_BYTES=\"{item.SectorSize}\"" + '\u0020' +
                    "file_sector_offset=\"0\"" + '\u0020' +
                    $"filename=\"{item.FileName}\"" +'\u0020' +
                    $"num_partition_sectors=\"{item.NumSectors}\"" + '\u0020' +
                    "partofsingleimage=\"false\"" + '\u0020' +
                    $"physical_partition_number=\"{lunnum}\"" + '\u0020' +
                    "readbackverify=\"false\"" + '\u0020' +
                    $"size_in_KB=\"{si_kb}.0\"" + '\u0020' +
                    "sparse=\"false\"" + '\u0020' +
                    $"start_byte_hex=\"0x{Convert.ToString(sb_hex, 16).ToUpper()}\"" + '\u0020' +
                    $"start_sector=\"{Convert.ToInt64(item.StartSector_Hex, 16)}\"/>");
            }
            xmlloadargs.Append("</data>");
            doc.LoadXml(xmlloadargs.ToString());
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            try
            {
                doc.Save($"{workDir}\\rawprogram{lunnum}.xml");
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message, LocRes.GetString("er_func_xml"));
            }
        }
        private void BackgroundWorker_comp_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            CompareFiles_Struct compareFiles = (CompareFiles_Struct)e.Argument;
            int secsize = compareFiles.SecSize;
            long ofparts = compareFiles.OrigFileLen / secsize;
            int lastofpart = (int)(compareFiles.OrigFileLen % secsize);
            long dfparts = compareFiles.CompFileLen / secsize;
            int lastdfpart = (int)(compareFiles.CompFileLen % secsize);
            long lastdifsec = -2; //Последний несовпадающий сектор в цикле
            string newfile = string.Empty; //Новый файл для записи различающихся секторов
            long calcdifsec = 0; //Считаем различающиеся сектора в одном файле
            List<RawProg_Data> raw_res_list = new List<RawProg_Data>();
            RawProg_Data raw_res = new RawProg_Data();
            //Сначала обрабатываем в цикле все полные части
            if (ofparts - dfparts == 0) //Размер полных частей файлов одинаковый
            {
                for (long i = 0; i < ofparts; i++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        raw_res = new RawProg_Data();
                        int percentProgress = (int)(i * 100 / ofparts);
                        worker.ReportProgress(percentProgress);
                        byte[] bytesofread = new byte[secsize];
                        byte[] bytesdfread = new byte[secsize];
                        using (FileStream fs_of = File.OpenRead(compareFiles.OrigFullFileName))
                        {
                            fs_of.Position = i * secsize;
                            fs_of.Read(bytesofread, 0, secsize);
                        }
                        using (FileStream fs_df = File.OpenRead(compareFiles.CompFullFileName))
                        {
                            fs_df.Position = i * secsize;
                            fs_df.Read(bytesdfread, 0, secsize);
                        }
                        if (!bytesofread.SequenceEqual(bytesdfread)) //Сравниваем сектора и если различаются, то записываем второй в файл
                        {
                            if (i == lastdifsec + 1) //Если текущий сектор и предыдущий +1 равны, то дописываем в имеющийся файл
                            {
                                using (FileStream fs_write = new FileStream(newfile, FileMode.Append, FileAccess.Write))
                                {
                                    fs_write.Write(bytesdfread, 0, secsize);
                                }
                            }
                            else //Если текущий сектор и предыдущий +1 не равны, то начинаем писать с нового файла
                            {
                                newfile = $"{compareFiles.NewDir}\\0x{Convert.ToString(i, 16).ToUpper()}_.bin";
                                using (FileStream fs_write = File.OpenWrite(newfile))
                                {
                                    fs_write.Write(bytesdfread, 0, secsize);
                                }
                            }
                            lastdifsec = i;
                            calcdifsec++;
                        }
                        else //Сектора одинаковые. Надо переименовать предыдущий файл.
                        {
                            if (File.Exists(newfile))
                            {
                                FileInfo fileInfo = new FileInfo(newfile);
                                int insstr = fileInfo.Name.IndexOf("_.bin");
                                string fn = fileInfo.Name.Insert(insstr + 1, calcdifsec.ToString());
                                string renewfile = fileInfo.DirectoryName + "\\" + fn;
                                if (File.Exists(renewfile)) File.Delete(renewfile);
                                File.Move(newfile, renewfile);
                                raw_res.FileName = fn;
                                raw_res.StartSector_Hex = fileInfo.Name.Remove(fileInfo.Name.IndexOf("_.bin"));
                                raw_res.NumSectors = calcdifsec.ToString();
                                raw_res.SectorSize = secsize.ToString();
                                raw_res_list.Add(raw_res);
                                newfile = string.Empty;
                                calcdifsec = 0;
                            }
                        }
                    }
                }
                //Если различия в последнем секторе, то завершаем цикл проверкой
                if (File.Exists(newfile))
                {
                    FileInfo fileInfo = new FileInfo(newfile);
                    int insstr = fileInfo.Name.IndexOf("_.bin");
                    string fn = fileInfo.Name.Insert(insstr + 1, calcdifsec.ToString());
                    string renewfile = fileInfo.DirectoryName + "\\" + fn;
                    if (File.Exists(renewfile)) File.Delete(renewfile);
                    File.Move(newfile, renewfile);
                    raw_res.FileName = fn;
                    raw_res.StartSector_Hex = fileInfo.Name.Remove(fileInfo.Name.IndexOf("_.bin"));
                    raw_res.NumSectors = calcdifsec.ToString();
                    raw_res.SectorSize = secsize.ToString();
                    raw_res_list.Add(raw_res);
                }
                e.Result = raw_res_list;//Формируем список для xml
            }
            else //TODO Размер полных частей файлов различается. Условно считаем, что нет.
            {
                e.Result = null;
            }
            //TODO В конце дописываем остаток, если есть. Концы различаются или не равны 0. Условно считаем, что нет.
            if (lastofpart - lastdfpart != 0)
            {
                e.Result = null;
            }
        }

        private void BackgroundWorker_comp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            toolStripStatusLabel_search.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void BackgroundWorker_comp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) //При отмене операции
            {
                toolStripStatusLabel_search.Text = "Процедура сравнения секторов отменена пользователем";
            }
            else
            {
                if (e.Error != null) //При завершении с ошибкой
                {
                    toolStripStatusLabel_search.Text = $"Ошибка: {e.Error.Message}";
                }
                else //Успешно
                {
                    toolStripStatusLabel_search.Text = "Готово";
                    if (checkBox_difraw.Checked)
                    {
                        List<RawProg_Data> rawProg_Data = (List<RawProg_Data>)e.Result;
                        if (rawProg_Data != null)
                        {
                            FhXml(label_newdir.Text, rawProg_Data, textBox_raw_lun.Text); //Создаём xml
                            toolStripStatusLabel_search.Text = "Файл rawprogram.xml для пакетной записи различающихся секторов сформирован";
                        }
                    }
                }
            }
            toolStripProgressBar_search.Value = 0;
            button_of.Enabled = true;
            button_df.Enabled = true;
            button_comp.Text = "Сравнить";
        }
        #endregion
        #region Вкладка "Дубликаты файлов"
        private byte[] HashFile(string filename)
        {
            byte[] hashfile = null;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        fileStream.Position = 0;
                        hashfile = mySHA256.ComputeHash(fileStream);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return hashfile;
        }
        private void CheckDubs_SinglePath(List<File_Struct> worklist)
        {
            listView_dubl_files.Items.Clear(); //Очистили элементы листвью
            listView_dubl_files.Groups.Clear(); //Очистили группы листвью
            TableGroups.Clear(); //Очистили таблицу групп
            if (worklist.Count > 1)
            {
                for (int i = 0; i < worklist.Count - 1; i++)
                {
                    for (int k = i + 1; k < worklist.Count; k++)
                    {
                        if (worklist[i].HashCodeFile.Equals(worklist[k].HashCodeFile) && !worklist[k].Dubl) //Найден дубликат
                        {
                            CreateTableGroups(worklist[i].FullFileName); //Создаём группу, если не была раньше создана
                            //Проверяем на наличие группы в листвью
                            if (!listView_dubl_files.Groups.Contains((ListViewGroup)TableGroups[worklist[i].FullFileName]))
                                listView_dubl_files.Groups.Add((ListViewGroup)TableGroups[worklist[i].FullFileName]);
                            worklist[k].Dubl = true;
                            ListViewItem dublfile = new ListViewItem(worklist[k].FullFileName);
                            dublfile.SubItems.Add(worklist[k].FiLen.ToString("### ### ### ##0"));
                            dublfile.Group = (ListViewGroup)TableGroups[worklist[i].FullFileName];
                            listView_dubl_files.Items.Add(dublfile);
                            listView_dubl_files.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                        }
                    }
                }
            }
        }
        private void CheckDubs()
        {
            listView_dubl_files.Items.Clear(); //Очистили элементы листвью
            listView_dubl_files.Groups.Clear(); //Очистили группы листвью
            TableGroups.Clear(); //Очистили таблицу групп
            if (orig_list.Count > 0 && dubl_list.Count > 0)
            {
                switch (radioButton_nameandhash.Checked)
                {
                    case true:
                        for (int i = 0; i < orig_list.Count; i++)
                        {
                            FileInfo ofn = new FileInfo(orig_list[i].FullFileName);
                            for (int j = 0; j < dubl_list.Count; j++)
                            {
                                FileInfo dfn = new FileInfo(dubl_list[j].FullFileName);
                                if (ofn.Name.Equals(dfn.Name))
                                {
                                    if (orig_list[i].HashCodeFile.Equals(dubl_list[j].HashCodeFile) && !dubl_list[j].Dubl) //Найден дубликат
                                    {
                                        CreateTableGroups(orig_list[i].FullFileName); //Создаём группу, если не была раньше создана
                                                                                      //Проверяем на наличие группы в листвью
                                        if (!listView_dubl_files.Groups.Contains((ListViewGroup)TableGroups[orig_list[i].FullFileName]))
                                            listView_dubl_files.Groups.Add((ListViewGroup)TableGroups[orig_list[i].FullFileName]);
                                        dubl_list[j].Dubl = true;
                                        ListViewItem dublfile = new ListViewItem(dubl_list[j].FullFileName);
                                        dublfile.SubItems.Add(dubl_list[j].FiLen.ToString("### ### ### ##0"));
                                        dublfile.Group = (ListViewGroup)TableGroups[orig_list[i].FullFileName];
                                        listView_dubl_files.Items.Add(dublfile);
                                        listView_dubl_files.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        for (int i = 0; i < orig_list.Count; i++)
                        {
                            for (int k = 0; k < dubl_list.Count; k++)
                            {
                                if (orig_list[i].HashCodeFile.Equals(dubl_list[k].HashCodeFile) && !dubl_list[k].Dubl) //Найден дубликат
                                {
                                    CreateTableGroups(orig_list[i].FullFileName); //Создаём группу, если не была раньше создана
                                                                                  //Проверяем на наличие группы в листвью
                                    if (!listView_dubl_files.Groups.Contains((ListViewGroup)TableGroups[orig_list[i].FullFileName]))
                                        listView_dubl_files.Groups.Add((ListViewGroup)TableGroups[orig_list[i].FullFileName]);
                                    dubl_list[k].Dubl = true;
                                    ListViewItem dublfile = new ListViewItem(dubl_list[k].FullFileName);
                                    dublfile.SubItems.Add(dubl_list[k].FiLen.ToString("### ### ### ##0"));
                                    dublfile.Group = (ListViewGroup)TableGroups[orig_list[i].FullFileName];
                                    listView_dubl_files.Items.Add(dublfile);
                                    listView_dubl_files.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                                }
                            }
                        }
                        break;
                }
            }
        }
        private void ListView_dubl_files_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView_dubl_files.CheckedItems.Count > 0) button_del.Enabled = true;
            else button_del.Enabled = false;
        }
        private void BackgroundWorker_orig_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            IEnumerable<FileInfo> workfiles = (IEnumerable<FileInfo>)e.Argument;
            int readyfiles = 1; //Обработанных файлов
            try //Заполнили всеми файлами оригинал
            {
                foreach (FileInfo WF in workfiles)
                {
                    worker.ReportProgress(readyfiles * 100 / workfiles.Count(), "Обрабатывается " + readyfiles.ToString() + " файл из " + workfiles.Count().ToString() + " -> " + WF.Name);
                    File_Struct file = new File_Struct
                    {
                        Dubl = false,
                        FullFileName = WF.FullName,
                        HashCodeFile = BitConverter.ToString(HashFile(WF.FullName)),
                        FiLen = WF.Length
                    };
                    orig_list.Add(file);
                    readyfiles++;
                    Thread.Sleep(5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackgroundWorker_orig_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            toolStripStatusLabel_search.Text = e.UserState.ToString();
        }

        private void BackgroundWorker_orig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button_orig.Enabled = true;
            button_dubl.Enabled = true;
            button_exe.Enabled = true;
            toolStripProgressBar_search.Value = 0;
            if (radioButton_od_yes.Checked) CheckDubs_SinglePath(orig_list); //Проверяем на дублинаты оригинал
            toolStripStatusLabel_search.Text = $"Обработано {orig_list.Count} файлов. Найдено {listView_dubl_files.Items.Count} дублей.";
        }

        private void BackgroundWorker_dubl_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            IEnumerable<FileInfo> workfiles = (IEnumerable<FileInfo>)e.Argument;
            int readyfiles = 1; //Обработанных файлов
            try //Заполнили всеми файлами дублями
            {
                foreach (FileInfo WF in workfiles)
                {
                    worker.ReportProgress(readyfiles * 100 / workfiles.Count(), "Обрабатывается " + readyfiles.ToString() + " файл из " + workfiles.Count().ToString() + " -> " + WF.Name);
                    File_Struct file = new File_Struct
                    {
                        Dubl = false,
                        FullFileName = WF.FullName,
                        HashCodeFile = BitConverter.ToString(HashFile(WF.FullName)),
                        FiLen = WF.Length
                    };
                    dubl_list.Add(file);
                    readyfiles++;
                    Thread.Sleep(5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackgroundWorker_dubl_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            toolStripStatusLabel_search.Text = e.UserState.ToString();
        }

        private void BackgroundWorker_dubl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button_orig.Enabled = true;
            button_dubl.Enabled = true;
            button_exe.Enabled = true;
            toolStripProgressBar_search.Value = 0;
            if (radioButton_dd_yes.Checked) CheckDubs_SinglePath(dubl_list); //Проверяем на дублинаты дубликаты
            toolStripStatusLabel_search.Text = $"Обработано {dubl_list.Count} файлов. Найдено {listView_dubl_files.Items.Count} дублей.";
        }

        private void Button_orig_Click(object sender, EventArgs e)
        {
            orig_list.Clear();
            if (folderBrowserDialog_orig.ShowDialog() == DialogResult.OK)
            {
                button_orig.Text = folderBrowserDialog_orig.SelectedPath;
                IEnumerable<FileInfo> workF = new DirectoryInfo(folderBrowserDialog_orig.SelectedPath).EnumerateFiles("*.*", SearchOption.AllDirectories);
                if (!backgroundWorker_orig.IsBusy)
                {
                    button_orig.Enabled = false;
                    button_dubl.Enabled = false;
                    button_exe.Enabled = false;
                    backgroundWorker_orig.RunWorkerAsync(workF);
                }
            }
            else
            {
                button_orig.Text = "Выберите папку-оригинал";
                folderBrowserDialog_orig.SelectedPath = string.Empty;
            }
        }

        private void Button_dubl_Click(object sender, EventArgs e)
        {
            dubl_list.Clear();
            if (folderBrowserDialog_dubl.ShowDialog() == DialogResult.OK)
            {
                button_dubl.Text = folderBrowserDialog_dubl.SelectedPath;
                IEnumerable<FileInfo> workF = new DirectoryInfo(folderBrowserDialog_dubl.SelectedPath).EnumerateFiles("*.*", SearchOption.AllDirectories);
                if (!backgroundWorker_dubl.IsBusy)
                {
                    button_orig.Enabled = false;
                    button_dubl.Enabled = false;
                    button_exe.Enabled = false;
                    backgroundWorker_dubl.RunWorkerAsync(workF);
                }
            }
            else
            {
                button_dubl.Text = "Выберите папку-дубликаты";
                folderBrowserDialog_dubl.SelectedPath = string.Empty;
            }
        }

        private void Button_exe_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel_search.Text = "Обрабатываем ...";
            CheckDubs();
            toolStripStatusLabel_search.Text = $"Обработано {orig_list.Count + dubl_list.Count} файлов. Найдено {listView_dubl_files.Items.Count} дублей.";
        }

        private void Button_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удаляем отмеченные файлы",
                "Подтверждение удаления файлов!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                foreach (ListViewItem item in listView_dubl_files.CheckedItems)
                {
                    try
                    {
                        File.Delete(item.Text);
                        listView_dubl_files.Items.RemoveAt(item.Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                button_del.Enabled = false;
            }
            else foreach (ListViewItem item in listView_dubl_files.CheckedItems)
                {
                    item.Checked = false;
                }
        }

        private void ПоменятьМестамиОригиналИДубликатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_dubl_files.SelectedItems.Count > 0)
            {
                string conversion = listView_dubl_files.SelectedItems[0].Text;
                CreateTableGroups(conversion);
                listView_dubl_files.SelectedItems[0].Text = listView_dubl_files.SelectedItems[0].Group.Header;
                listView_dubl_files.SelectedItems[0].Group.Header = conversion;
            }
        }

        private void ContextMenuStrip_dubl_files_Opening(object sender, CancelEventArgs e)
        {
            if (listView_dubl_files.Items.Count > 0) поменятьМестамиОригиналИДубликатToolStripMenuItem.Enabled = true;
            else поменятьМестамиОригиналИДубликатToolStripMenuItem.Enabled = false;
        }
        #endregion
        #region Вкладка "Разобрать дамп диска"
        private void Button_dd_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button_dd.Text = openFileDialog1.FileName;
                int maxfilelen = 0x6000;
                int minfilelen = 0x800;
                FileInfo gpt = new FileInfo(openFileDialog1.FileName);
                if (gpt.Length >= minfilelen)
                {
                    if (gpt.Length >= maxfilelen) Fill_ListDD(maxfilelen);
                    else Fill_ListDD((int)gpt.Length);
                }
                else
                {
                    MessageBox.Show("Маленький размер файла");
                    button_dd.Text = "Выбрать дамп диска";
                }
            }
            else button_dd.Text = "Выбрать дамп диска";
        }
        private void Fill_ListDD(int bytestoread)
        {
            byte[] gpt_bytes = new byte[bytestoread];
            string byte_mask = "4546492050415254"; //EFI PART
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            string newdir = fi.Name.Remove(fi.Name.IndexOf(fi.Extension));
            label_path.Text = $"{fi.DirectoryName}\\{newdir}";
            Directory.CreateDirectory(label_path.Text);
            string newgptfile = $"{label_path.Text}\\gpt_main.bin";
            using (FileStream fs_gpt = File.OpenRead(openFileDialog1.FileName))
            {
                fs_gpt.Read(gpt_bytes, 0, bytestoread);
            }
            string sec = BitConverter.ToString(gpt_bytes).Replace("-", "");
            int sec_len = sec.IndexOf(byte_mask) / 2;
            using (FileStream fs_write = File.OpenWrite(newgptfile))
            {
                switch (sec_len)
                {
                    case 512:
                        fs_write.Write(gpt_bytes, 0, 512 * 34);
                        break;
                    case 4096:
                        fs_write.Write(gpt_bytes, 0, 4096 * 6);
                        break;
                    default:
                        MessageBox.Show("Что-то пошло не так");
                        break;
                }
            }
            textBox_sector.Text = sec_len.ToString();
            if (File.Exists(newgptfile))
            {
                if (listView_dd.Items.Count > 0) listView_dd.Items.Clear();
                List<GPT_Table> gpt_array = func.Parsing_GPT_main(newgptfile, sec_len);
                if (string.IsNullOrEmpty(gpt_array[0].EndLBA)) MessageBox.Show(gpt_array[0].StartLBA, LocRes.GetString("mb_body_er_gpt"));
                else //Заполняем листвью массивом итемов(разделов таблицы GPT)
                {
                    for (int i = 0; i < gpt_array.Count; i++)
                    {
                        ListViewItem gpt_item = new ListViewItem(gpt_array[i].StartLBA); //Это итем и сабитем0
                        gpt_item.SubItems.Add(gpt_array[i].EndLBA); //сабитем1
                        gpt_item.SubItems.Add(gpt_array[i].BlockName); //сабитем2
                        gpt_item.SubItems.Add(gpt_array[i].BlockLength); //сабитем3
                        gpt_item.SubItems.Add(gpt_array[i].BlockBytes); //сабитем4
                        listView_dd.Items.Add(gpt_item);
                    }
                }
            }
            else MessageBox.Show(LocRes.GetString("mb_body_gpt_not_formed"));
        }

        private void Button_destr_Click(object sender, EventArgs e)
        {
            List<GPT_Table> items = new List<GPT_Table>();
            foreach (ListViewItem lvi in listView_dd.Items)
            {
                GPT_Table item = new GPT_Table()
                {
                    StartLBA = lvi.Text,
                    EndLBA = lvi.SubItems[1].Text,
                    BlockName = lvi.SubItems[2].Text,
                    BlockLength = button_dd.Text, //Вместо длины передаём путь к файлу
                    BlockBytes = label_path.Text, //Вместо байт передаём путь к папке
                    SectorSize = textBox_sector.Text
                };
                items.Add(item);
            }
            if (!backgroundWorker_destr.IsBusy) backgroundWorker_destr.RunWorkerAsync(items);
        }

        private void BackgroundWorker_destr_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<GPT_Table> items = (List<GPT_Table>)e.Argument;
            int countitem = 1;
            FileInfo fi = new FileInfo(items[0].BlockLength);
            long longbytes;
            int cutbase = 2147479552; //Ограничения на размер 2гб
            long offset;
            foreach (GPT_Table item in items)
            {
                worker.ReportProgress(countitem * 100 / items.Count, $"Обрабатывается {countitem} раздел из {items.Count} -> {item.BlockName}");
                string newfile = $"{items[0].BlockBytes}\\{item.BlockName}.bin";
                offset = Convert.ToInt64(item.StartLBA, 16) * Convert.ToInt32(item.SectorSize);
                if (Convert.ToInt64(item.EndLBA, 16) + 1 - Convert.ToInt64(item.StartLBA, 16) > 0)
                {
                    longbytes = (Convert.ToInt64(item.EndLBA, 16) + 1 - Convert.ToInt64(item.StartLBA, 16)) * Convert.ToInt32(item.SectorSize);
                }
                else longbytes = 0;
                if (longbytes > cutbase) //Для раздела больше 2 гб
                {
                    //Определяем размер нарезки для лонга
                    byte cutbyte = Convert.ToByte(longbytes / cutbase);
                    int lastbytes = Convert.ToInt32(longbytes % cutbase);
                    byte[] bytestoread = new byte[cutbase];
                    byte[] lastbytestoread = new byte[lastbytes];
                    for (byte i = 0; i < cutbyte; i++)
                    {
                        worker.ReportProgress(countitem * 100 / items.Count, $"Обрабатывается {i + 1} часть раздела из {cutbyte} -> {item.BlockName}");
                        using (FileStream fs_gpt = File.OpenRead(fi.FullName))
                        {
                            fs_gpt.Position = offset + (i * cutbase);
                            fs_gpt.Read(bytestoread, 0, cutbase);
                        }
                        using (FileStream fs_write = new FileStream(newfile, FileMode.Append, FileAccess.Write))
                        {
                            fs_write.Write(bytestoread, 0, cutbase);
                        }
                    }
                    if (lastbytes > 0) //Дописываем хвост
                    {
                        using (FileStream fs_gpt = File.OpenRead(fi.FullName))
                        {
                            fs_gpt.Position = offset + (cutbyte * cutbase);
                            fs_gpt.Read(lastbytestoread, 0, lastbytes);
                        }
                        using (FileStream fs_write = new FileStream(newfile, FileMode.Append, FileAccess.Write))
                        {
                            fs_write.Write(lastbytestoread, 0, lastbytes);
                        }
                    }
                }
                else //Для размеров разделов меньше 2 гб
                {
                    byte[] bytestoread = new byte[longbytes];
                    using (FileStream fs_gpt = File.OpenRead(fi.FullName))
                    {
                        fs_gpt.Position = offset;
                        fs_gpt.Read(bytestoread, 0, (int)longbytes);
                    }
                    using (FileStream fs_write = File.OpenWrite(newfile))
                    {
                        fs_write.Write(bytestoread, 0, (int)longbytes);
                    }
                }
                countitem++;
            }
        }

        private void BackgroundWorker_destr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar_search.Value = e.ProgressPercentage;
            toolStripStatusLabel_search.Text = e.UserState.ToString();
        }

        private void BackgroundWorker_destr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar_search.Value = 0;
            toolStripStatusLabel_search.Text = $"Обработано {listView_dd.Items.Count} разделов.";
        }

        private void ВыбратьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_dubl_files.Items)
            {
                if (!item.Checked) item.Checked = true;
            }
        }

        private void СнятьВесьВыборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_dubl_files.Items)
            {
                if (item.Checked) item.Checked = false;
            }
        }
        #endregion
    }

    /// <summary>
    /// Структура файла
    /// </summary>
    class File_Struct
    {
        public bool Dubl { get; set; }
        public string FullFileName { get; set; }
        public string HashCodeFile { get; set; }
        public long FiLen { get; set; }
        public File_Struct(bool dubl, string fullfilename, string hashcodefile, long filen)
        {
            Dubl = dubl;
            FullFileName = fullfilename;
            HashCodeFile = hashcodefile;
            FiLen = filen;
        }
        public File_Struct() { }
    }
    /// <summary>
    /// Структура класса для сравнения двух файлов
    /// </summary>
    class CompareFiles_Struct
    {
        public bool CompTxtFile { get; set; }
        public bool CompBinFile { get; set; }
        public int SecSize { get; set; }
        public string OrigFullFileName { get; set; }
        public long OrigFileLen { get; set; }
        public string CompFullFileName { get; set; }
        public long CompFileLen { get; set; }
        public string NewDir { get; set; }
        public CompareFiles_Struct(bool comptxtfile, bool compbinfile, int secsize, string origfullfilename, long origfilelen, string compfullfilename, long compfilelen, string newdir)
        {
            CompTxtFile = comptxtfile;
            CompBinFile = compbinfile;
            SecSize = secsize;
            OrigFullFileName = origfullfilename;
            OrigFileLen = origfilelen;
            CompFullFileName = compfullfilename;
            CompFileLen = compfilelen;
            NewDir = newdir;
        }
        public CompareFiles_Struct() { }
    }
    /// <summary>
    /// Структура класса для формирования rawprogram.xml
    /// </summary>
    class RawProg_Data
    {
        public string FileName { get; set; }
        public string StartSector_Hex { get; set; }
        public string NumSectors { get; set; }
        public string SectorSize { get; set; }
        public RawProg_Data(string fileName, string startSector_Hex, string numSectors, string sectorSize)
        {
            FileName = fileName;
            StartSector_Hex = startSector_Hex;
            NumSectors = numSectors;
            SectorSize = sectorSize;
        }
        public RawProg_Data() { }
    }
}