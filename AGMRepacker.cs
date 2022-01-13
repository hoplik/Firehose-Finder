using NuGet.Packaging.Signing;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class AGMRepacker : Form
    {
        readonly Func func = new Func();
        static readonly int last_header_byte = 1048576; // Размер шапки прошивки, заканчивая адресом 0х100000 (1 048 576)
        static readonly int blocksize = 20480; //Размер блока для удобства чтения
        internal string ROM_File_Path = string.Empty;   // Полный путь к файлу прошивки для распаковки
        internal string Decode_ROM_Path = string.Empty; // Полный путь к директории, в которую будет распакована прошивка
        internal byte[] decode_header_bytes = new byte[last_header_byte]; // Декодированные байты прошивки
        internal byte[] bin_head_bytes = new byte[last_header_byte]; //Байты шапки прошивки
        byte[] key_decode = new byte[8]; // Ключ расшифровки 64 бит/8 байт/16 знаков
        Header_Info H_I = new Header_Info(); //Информация хедера прошивки

        public AGMRepacker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Данные о шапке прошивки
        /// </summary>
        public struct Header_Info
        {
            public Header_Info(string packer_Ver, string phone_Ver, string image_Ver, string author, uint conf_Files, uint bin_Files, uint bin_Nym, string header_Len)
            {
                Packer_Ver = packer_Ver;
                Phone_Ver = phone_Ver;
                Image_Ver = image_Ver;
                Author = author;
                Conf_Files = conf_Files;
                Bin_Files = bin_Files;
                Bin_Nym = bin_Nym;
                Header_Len = header_Len;
            }
            public string Packer_Ver;
            public string Phone_Ver;
            public string Image_Ver;
            public string Author;
            public uint Conf_Files;
            public uint Bin_Files;
            public uint Bin_Nym;
            public string Header_Len;
        }

        /// <summary>
        /// Данные о файлах, включённых в прошивку
        /// </summary>
        public struct File_info_bytes
        {
            public File_info_bytes(string rom_Name, string file_Name, long offset, long size, long crc, long res)
            {
                ROM_Name = rom_Name;
                File_Name = file_Name;
                Offset = offset;
                Size = size;
                CRC = crc;
                Res = res;
            }
            public string ROM_Name;
            public string File_Name;
            public long Offset;
            public long Size;
            public long CRC;
            public long Res;
        }

        /// <summary>
        /// Инициализируем всплывающие подсказки при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AGMRepacker_Load(object sender, EventArgs e)
        {
            toolTip_Dir.SetToolTip(button_rampath, "Для сброса нажмите кнопку и выберите \"Отмена\"");
            toolTip_Dir.SetToolTip(button_dirrepack, "Для сброса нажмите кнопку и выберите \"Отмена\"");
            toolTip_Dir.SetToolTip(comboBox_charsinrow, "Выберите из списка или введите вручную");
            toolTip_Dir.SetToolTip(textBox_keycode, "Система дешифровки - только DES. Количество знаков в ключе меньше 16 будет дополнено '0' в начале.");
        }

        /// <summary>
        /// При изменении кода оставляем только хекс-символы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_keycode_TextChanged(object sender, EventArgs e)
        {
            textBox_keycode.Text=func.DelUnknownChars(textBox_keycode.Text, Func.System_Count.hex);
            textBox_keycode.SelectionStart = textBox_keycode.TextLength;
        }

        /// <summary>
        /// Запускаем процедуру считывания шапки прошивки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_rampath_Click(object sender, EventArgs e)
        {
            //Выводим лист на печать строками по настройкам
            string charsinstr = comboBox_charsinrow.Text;
            if (!string.IsNullOrEmpty(comboBox_charsinrow.SelectedText)) charsinstr = comboBox_charsinrow.SelectedText;
            int charsint = Convert.ToInt32(charsinstr);
            textBox_orig.Text=string.Empty;
            textBox_decode.Text=string.Empty;
            textBox_parse.Text=string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ROM_File_Path = openFileDialog1.FileName;
                button_rampath.Text = ROM_File_Path;
                toolStripStatusLabel1.Text="Читаем ...";
                if (!backgroundWorker_readheader.IsBusy) backgroundWorker_readheader.RunWorkerAsync(charsint);
            }
            else
            {
                ROM_File_Path = string.Empty;
                button_rampath.Text = "Путь к файлу прошивки";
                toolStripStatusLabel1.Text = "Выберите путь к прошивке и директорию для распаковки";
            }
        }

        /// <summary>
        /// Считываем шапку прошивки в параллельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_readheader_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            FileInfo fileInfo = new FileInfo(ROM_File_Path);
            int bytes_to_read = last_header_byte; //Может быть либо 1мБ, либо длина файла
            if (bytes_to_read>fileInfo.Length) _ = Convert.ToInt32(fileInfo.Length);
            bin_head_bytes=Array.Empty<byte>();
            Array.Resize(ref bin_head_bytes, bytes_to_read);
            byte[] bs = new byte[blocksize];
            string us = "Отображаем блок первых символов ...";
            using (BinaryReader reader = new BinaryReader(File.OpenRead(ROM_File_Path)))
            {
                bin_head_bytes =  reader.ReadBytes(bytes_to_read);
            }
            worker.ReportProgress(50, us);
            Array.Copy(bin_head_bytes, 0, bs, 0, blocksize);
            e.Result = func.ByEight(bs, (int)e.Argument);
        }

        private void BackgroundWorker_readheader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value=e.ProgressPercentage;
            toolStripStatusLabel1.Text=(string)e.UserState;
        }

        private void BackgroundWorker_readheader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value=0;
            if (e.Error!=null) toolStripStatusLabel1.Text = e.Error.Message;
            else
            {
                toolStripStatusLabel1.Text="Заголовок прошивки считан успешно.";
                string toshow = (string)e.Result;
                toshow = toshow.TrimStart('\u000D');
                if (toshow.Length>textBox_orig.MaxLength) toshow = toshow.Substring(0, textBox_orig.MaxLength);
                textBox_orig.Text = toshow;
                textBox_orig.SelectionStart = 0;
                textBox_orig.ScrollToCaret();
                button_decode.Enabled = true;
            }
        }
        private void Button_decode_Click(object sender, EventArgs e)
        {
            //Выводим лист на печать строками по настройкам
            string charsinstr = comboBox_charsinrow.Text;
            if (!string.IsNullOrEmpty(comboBox_charsinrow.SelectedText)) charsinstr = comboBox_charsinrow.SelectedText;
            int charsint = Convert.ToInt32(charsinstr);
            StringBuilder key_string = new StringBuilder(textBox_keycode.Text);
            while (key_string.Length < 16) key_string.Insert(0, '\u0030');
            button_decode.Enabled = false;
            key_decode=Func.StringToByteArray(key_string.ToString());
            toolStripStatusLabel1.Text="Декодируем ...";
            if (!backgroundWorker_decodeheader.IsBusy) backgroundWorker_decodeheader.RunWorkerAsync(charsint);
        }

        private void BackgroundWorker_decodeheader_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //Отправляем на декодировку массив кратный 8
            while (bin_head_bytes.Length%8!=0) Array.Resize(ref bin_head_bytes, bin_head_bytes.Length-1);
            //Отправляем на декодировку стандарт DES-ECB
            decode_header_bytes = Array.Empty<byte>();
            Array.Resize(ref decode_header_bytes, bin_head_bytes.Length);
            byte[] bs = new byte[blocksize];
            string us = "Отображаем блок первых символов ...";
            func.Decoder(bin_head_bytes, key_decode).CopyTo(decode_header_bytes, 0);
            worker.ReportProgress(50, us);
            Array.Copy(decode_header_bytes, 0, bs, 0, blocksize);
            e.Result = func.ByEight(bs, (int)e.Argument);
        }

        private void BackgroundWorker_decodeheader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text=(string)e.UserState;
            toolStripProgressBar1.Value=e.ProgressPercentage;
        }

        private void BackgroundWorker_decodeheader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            if (e.Error!=null) toolStripStatusLabel1.Text = e.Error.Message;
            else
            {
                toolStripStatusLabel1.Text="Заголовок прошивки декодирован";
                string toshow = (string)e.Result;
                toshow = toshow.TrimStart('\u000D');
                if (toshow.Length>textBox_decode.MaxLength) toshow = toshow.Substring(0, textBox_decode.MaxLength);
                textBox_decode.Text = toshow;
                textBox_decode.SelectionStart = 0;
                textBox_decode.ScrollToCaret();
                textBox_parse.Text = Parsing_Header(decode_header_bytes);
                textBox_parse.SelectionStart=0;
                textBox_parse.ScrollToCaret();
                button_repack.Enabled=true;
            }
        }

        /// <summary>
        /// Разбираем декодированную шапку прошивки
        /// </summary>
        private string Parsing_Header(byte[] res_bytes)
        {
            StringBuilder ParsingHeader = new StringBuilder("\t\t\t<-=Параметры прошивки=->" + Environment.NewLine + Environment.NewLine);
            //Заполняем хедер прошивки
            H_I.Bin_Nym = BitConverter.ToUInt32(res_bytes, (int)Func.Parsing_Header_Four_Bytes.Bin_Number);
            try
            {
                if (H_I.Bin_Nym == 1)
                {
                    H_I.Conf_Files = BitConverter.ToUInt32(res_bytes, (int)Func.Parsing_Header_Four_Bytes.Config_Files);
                    H_I.Bin_Files = BitConverter.ToUInt32(res_bytes, (int)Func.Parsing_Header_Four_Bytes.Bin_Files);
                    ParsingHeader.AppendLine($"Количество bin файлов прошивки - {H_I.Bin_Nym}" + Environment.NewLine +
                        $"Количество bin файлов внутри прошивки - {H_I.Bin_Files}" + Environment.NewLine +
                        $"Количество конфигурационных файлов внутри прошивки - {H_I.Conf_Files}");
                    try
                    {
                        H_I.Header_Len = BitConverter.ToString(res_bytes, (int)Func.Parsing_Header_String_Bytes.Header_Len, 4).Replace("-", "");
                        H_I.Author = new ASCIIEncoding().GetString(res_bytes, (int)Func.Parsing_Header_String_Bytes.Author, (int)Func.Parsing_Bytes.Long_number).TrimEnd('\0');
                        H_I.Packer_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Func.Parsing_Header_String_Bytes.Packer_Version, (int)Func.Parsing_Bytes.String_parse).TrimEnd('\0');
                        H_I.Phone_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Func.Parsing_Header_String_Bytes.Phone_Version, (int)Func.Parsing_Bytes.String_parse).TrimEnd('\0');
                        H_I.Image_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Func.Parsing_Header_String_Bytes.Image_Version, (int)Func.Parsing_Bytes.String_parse).TrimEnd('\0');
                        ParsingHeader.AppendLine($"Что-то непонятное - {H_I.Header_Len}" + Environment.NewLine+
                            $"Подписант прошивки - {H_I.Author}" + Environment.NewLine+
                            $"Версия упаковщика - {H_I.Packer_Ver}" + Environment.NewLine+
                            $"Версия телефона - {H_I.Phone_Ver}" + Environment.NewLine+
                            $"Версия прошивки - {H_I.Image_Ver}");
                        toolStripStatusLabel1.Text = "Парсинг шапки прошивки завершился удачно.";
                    }
                    catch (ArgumentOutOfRangeException Ex)
                    {
                        ParsingHeader.AppendLine("Парсинг оставшейся части шапки прошивки завершился неудачно. " +
                                "Прошивка будет распакована, но возможны ошибки. Стоит проверить параметры в настройках!");
                        toolStripStatusLabel1.Text = Ex.Message;
                    }
                }
                else
                {
                    ParsingHeader.Clear();
                    ParsingHeader.AppendLine("Данная прошивка не может быть распакована, так как состоит не из одного файла, либо некорректно декодирована!");
                    toolStripStatusLabel1.Text = "Парсинг шапки прошивки завершился с ошибками.";
                }
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                ParsingHeader.Clear();
                ParsingHeader.AppendLine("Парсинг шапки прошивки завершился неудачно, возможно из-за маленького размера считываемых данных. " +
                    "Прошивка не может быть распакована с такими параметрами в настройках!");
                toolStripStatusLabel1.Text = Ex.Message;
            }
            return ParsingHeader.ToString();
        }

        /// <summary>
        /// Вибираем директорию для распаковки. При отказе всё сбрасываем на начальные данные.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_dirrepack_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Decode_ROM_Path = folderBrowserDialog1.SelectedPath;
                button_dirrepack.Text = Decode_ROM_Path;
                button_repack.Visible=true;
            }
            else
            {
                button_dirrepack.Text = "Директория для распаковки";
                toolStripStatusLabel1.Text = "Выберите путь к прошивке и директорию для распаковки";
                Decode_ROM_Path = string.Empty;
                button_repack.Visible=false;
            }
        }

        /// <summary>
        /// Распаковываем в отдельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_repack_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Начали распаковку ...";
            if (!backgroundWorker_unpacker.IsBusy) backgroundWorker_unpacker.RunWorkerAsync();
        }

        private void BackgroundWorker_unpacker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker unpacker = sender as BackgroundWorker;
            File_info_bytes[] F_I_B = new File_info_bytes[(int)(H_I.Conf_Files + H_I.Bin_Files)]; //Информация для одиночного файла
            int start_adress = 0x2800; //Адрес начала списка файлов
            for (int i = 0; i < H_I.Conf_Files + H_I.Bin_Files; i++) // Первый цикл из всех файлов, запакованных в прошивку
            {
                F_I_B[i].ROM_Name = new ASCIIEncoding().GetString(decode_header_bytes, i * (int)Func.Parsing_Bytes.File_info + start_adress, (int)Func.Parsing_Bytes.String_parse).TrimEnd('\0'); // 0х40 (64) Имя файла прошивки
                F_I_B[i].File_Name = new ASCIIEncoding().GetString(decode_header_bytes, i * (int)Func.Parsing_Bytes.File_info + 64 + start_adress, (int)Func.Parsing_Bytes.String_parse).TrimEnd('\0');  // 0х40 (64) Имя файла
                F_I_B[i].Offset = BitConverter.ToInt64(decode_header_bytes, i * (int)Func.Parsing_Bytes.File_info + 128 + start_adress) * 512; // 0х8 (2х4) Начальный адрес блока
                F_I_B[i].Size = BitConverter.ToInt64(decode_header_bytes, i * (int)Func.Parsing_Bytes.File_info + 136 + start_adress); // 0х8 (2х4) Размер
                F_I_B[i].CRC = BitConverter.ToInt64(decode_header_bytes, i * (int)Func.Parsing_Bytes.File_info + 144 + start_adress); // 0х8 (2х4) CRC32 Контрольная сумма
                F_I_B[i].Res = BitConverter.ToInt64(decode_header_bytes, i * (int)Func.Parsing_Bytes.File_info + 152 + start_adress); // 0х8 Резерв
                long size_for_decode = F_I_B[i].Size;
                string path_file = Decode_ROM_Path + "\\" + F_I_B[i].File_Name;
                while (size_for_decode % 512 != 0) // Читаем блоками по 512 байт
                    size_for_decode++;
                byte[] convert_bytes = new byte[size_for_decode];
                using (BinaryReader br = new BinaryReader(File.OpenRead(ROM_File_Path)))
                {
                    br.BaseStream.Position = F_I_B[i].Offset; // Смещение позиции чтения на начальный адрес
                    byte[] file_bytes = br.ReadBytes((int)size_for_decode);
                    if (i < H_I.Conf_Files) // Обрабатываем тут конфигурационные файлы, требующие расшифровки (идут в начале)
                    {
                        convert_bytes = func.Decoder(file_bytes, key_decode);
                    }
                    else // За ними бинарные файлы в чистом виде.
                    {
                        convert_bytes = file_bytes;
                    }
                }
                if (convert_bytes.Length > F_I_B[i].Size) Array.Resize(ref convert_bytes, (int)F_I_B[i].Size);
                if (unpacker.CancellationPending || Convert.ToUInt32(F_I_B[i].CRC) != Crc32.CalculateCrc(convert_bytes)) // Проверяем контрольную сумму
                {
                    e.Cancel = true;
                    break;
                }
                using (BinaryWriter writer = new BinaryWriter(File.Open(path_file, FileMode.Create), new ASCIIEncoding()))
                {
                    writer.Write(convert_bytes);
                }
                unpacker.ReportProgress(i * 100 / (int)(H_I.Conf_Files + H_I.Bin_Files), F_I_B[i]);
                Thread.Sleep(1);
            }
        }

        private void BackgroundWorker_unpacker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = $"Распаковка файлов прошивки выполнена на {e.ProgressPercentage}%";
            if (e.ProgressPercentage > 5) toolStripSplitButton_explorer.Visible = true;
            File_info_bytes F_I_B = (File_info_bytes)e.UserState;
            textBox_parse.AppendText(string.Format(
                Environment.NewLine + "Файл {0}, адрес {1}, размер {2}, контрольная сумма {3}",
                F_I_B.File_Name, F_I_B.Offset, F_I_B.Size, F_I_B.CRC));
        }

        private void BackgroundWorker_unpacker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = "Операция распаковки файлов прошивки прервана пользователем или завершилась с ошибкой.";
                toolStripSplitButton_explorer.Visible = false;
            }
            else
            {
                if (e.Error != null)
                {
                    toolStripStatusLabel1.Text = $"Операция распаковки файлов прошивки завершена с ошибкой {e.Error.Message}";
                    toolStripSplitButton_explorer.Visible = false;
                }
                else
                {
                    toolStripStatusLabel1.Text = "Прошивка успешно распакована в указанную директорию.";
                    toolStripSplitButton_explorer.Text = "Открыть папку в Проводнике";
                    toolStripSplitButton_explorer.Visible = true;
                }
            }
        }

        /// <summary>
        /// Открываем папку с распакованной прошивкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripSplitButton_explorer_Click(object sender, EventArgs e)
        {
            if (backgroundWorker_unpacker.IsBusy) backgroundWorker_unpacker.CancelAsync();
            if (toolStripSplitButton_explorer.Text.Contains("Проводник")) Process.Start("explorer.exe", Decode_ROM_Path);
        }
    }
}
