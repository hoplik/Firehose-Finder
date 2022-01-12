using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
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
        //Header_Info H_I = new Header_Info();
        //File_info_bytes[] F_I_B = Array.Empty<File_info_bytes>();

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
            Array.Clear(bin_head_bytes, 0, bytes_to_read);
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
            Array.Resize(ref decode_header_bytes, bin_head_bytes.Length);
            Array.Clear(decode_header_bytes, 0, decode_header_bytes.Length);
            byte[] bs = new byte[blocksize];
            string us = "Отображаем блок первых символов ...";
            func.Decoder(bin_head_bytes, key_decode).CopyTo(decode_header_bytes, 0);
            worker.ReportProgress(50, us);
            //Оптимизируем массив, убирая последние нули
            int offset = decode_header_bytes.Length-1;
            while (offset >= 0 && string.Format("{0:X2}", decode_header_bytes[offset]).Equals("00"))
                offset--;
            Array.Resize(ref decode_header_bytes, offset + 1);
            if (blocksize > offset + 1)
            {
                Array.Resize(ref bs, decode_header_bytes.Length);
                Array.Copy(decode_header_bytes, 0, bs, 0, decode_header_bytes.Length);
            }
            else
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
                Parsing_Header();
            }
        }

        /// <summary>
        /// Разбираем декодированную шапку прошивки
        /// </summary>
        private void Parsing_Header()
        {

            textBox_parse.Text = "\t\t\t<-=Параметры прошивки=->" + Environment.NewLine + Environment.NewLine;
            textBox_parse.AppendText(decode_header_bytes.Length.ToString() + " - " + BitConverter.ToString(decode_header_bytes, decode_header_bytes.Length-8, 8));

            /*H_I.Bin_Nym = BitConverter.ToUInt32(res_bytes, (int)Functions.Parsing_Header_Four_Bytes.Bin_Number - Start_Adress);
            try
            {
                if (H_I.Bin_Nym == 1)
                {
                    H_I.Conf_Files = BitConverter.ToUInt32(res_bytes, (int)Functions.Parsing_Header_Four_Bytes.Config_Files - Start_Adress);
                    H_I.Bin_Files = BitConverter.ToUInt32(res_bytes, (int)Functions.Parsing_Header_Four_Bytes.Bin_Files - Start_Adress);
                    richTextBox_Parse.Text += $"Количество bin файлов прошивки - {H_I.Bin_Nym}" + Environment.NewLine +
                        $"Количество bin файлов внутри прошивки - {H_I.Bin_Files}" + Environment.NewLine +
                        $"Количество конфигурационных файлов внутри прошивки - {H_I.Conf_Files}" + Environment.NewLine;
                    try
                    {
                        char[] trim_char = { '\0' };
                        H_I.Header_Len = BitConverter.ToString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Header_Len, 4).Replace("-", "");
                        H_I.Author = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Author - Start_Adress, (int)Functions.Parsing_Bytes.Long_number).TrimEnd(trim_char);
                        H_I.Packer_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Packer_Version - Start_Adress, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_char);
                        H_I.Phone_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Phone_Version - Start_Adress, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_char);
                        H_I.Image_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Image_Version, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_char);
                        richTextBox_Parse.Text += $"Что-то непонятное - {H_I.Header_Len}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Подписант прошивки - {H_I.Author}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Версия упаковщика - {H_I.Packer_Ver}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Версия телефона - {H_I.Phone_Ver}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Версия прошивки - {H_I.Image_Ver}" + Environment.NewLine;
                        toolStripStatusLabel1.Text = "Парсинг шапки прошивки завершился удачно.";
                    }
                    catch (ArgumentOutOfRangeException Ex)
                    {
                        richTextBox_Parse.Text += "Парсинг оставшейся части шапки прошивки завершился неудачно, вероятно, из-за указания ненулевого стартового адреса. " +
                                "Прошивка будет распакована, но возможны ошибки. Стоит проверить параметры в настройках!";
                        toolStripStatusLabel1.Text = Ex.Message;
                    }
                }
                else
                {
                    richTextBox_Parse.Text = "Данная прошивка не может быть распакована, так как состоит не из одного файла, либо некорректно декодирована!";
                    toolStripStatusLabel1.Text = "Парсинг шапки прошивки завершился с ошибками.";
                    return;
                }
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                richTextBox_Parse.Text = "Парсинг шапки прошивки завершился неудачно, вероятно, из-за указания ненулевого стартового адреса или маленького размера считываемых данных. " +
                    "Прошивка не может быть распакована с такими параметрами в настройках!";
                toolStripStatusLabel1.Text = Ex.Message;
                return;
            }
            richTextBox_Parse.SelectionStart = richTextBox_Parse.Text.Length;
            if (radioButton_Dec_Unpack.Checked) backgroundWorker_Unpacker.RunWorkerAsync(openFileDialog1.FileName);*/
        }
    }
}
