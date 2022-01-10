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
    public partial class AGMRepacker : Form
    {
        readonly Func func = new Func();
        internal string ROM_File_Path = string.Empty;   // Полный путь к файлу прошивки для распаковки
        internal string Decode_ROM_Path = string.Empty; // Полный путь к директории, в которую будет распакована прошивка
        //internal List<byte> bin_head_bytes = new List<byte>(8); // Байты, считанные с прошивки
        //internal List<byte> decode_head_bytes = new List<byte>(8); // Декодированные байты прошивки
        static readonly int last_header_byte = 1048576; // Размер шапки прошивки, заканчивая адресом 0х100000 (1 048 576)
        internal byte[] bin_header_bytes = new byte[last_header_byte]; //Байты шапки прошивки

        byte[] key_decode = new byte[8]; // Ключ расшифровки 64 бит/8 байт/16 знаков
        Header_Info H_I = new Header_Info();
        File_info_bytes[] F_I_B = Array.Empty<File_info_bytes>();

        public AGMRepacker()
        {
            InitializeComponent();
        }
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
        /// Считываем шапку прошивки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_rampath_Click(object sender, EventArgs e)
        {
            textBox_orig.Text=string.Empty;
            textBox_decode.Text=string.Empty;
            textBox_parse.Text=string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ROM_File_Path = openFileDialog1.FileName;
                button_rampath.Text = ROM_File_Path;
                if (!backgroundWorker_readheader.IsBusy) backgroundWorker_readheader.RunWorkerAsync();
            }
            else
            {
                ROM_File_Path = string.Empty;
                button_rampath.Text = "Путь к файлу прошивки";
                toolStripStatusLabel1.Text = "Выберите путь к прошивке и директорию для распаковки";
            }
        }



        private void BackgroundWorker_readheader_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(ROM_File_Path);
            int bytes_to_read = last_header_byte;
            if (bytes_to_read>fileInfo.Length) _ = Convert.ToInt32(fileInfo.Length);
            byte[] br = new byte[bytes_to_read];
            using (BinaryReader reader = new BinaryReader(File.OpenRead(ROM_File_Path)))
            {
                br=reader.ReadBytes(bytes_to_read);
            }
            e.Result = br;
        }

        private void BackgroundWorker_readheader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value =0;
            if (e.Error!=null) toolStripStatusLabel1.Text = e.Error.Message;
            else
            {
                //string charsinstr = comboBox_charsinrow.Text;
                //if (!string.IsNullOrEmpty(comboBox_charsinrow.SelectedText)) charsinstr = comboBox_charsinrow.SelectedText;
                toolStripStatusLabel1.Text="Заголовок прошивки считан успешно.";
                button_decode.Enabled = true;
                (byte[])e.Result.ToString.
                for (int i = 0; i < length; i++)
                {

                }
                int countelem = (byte[])e.Result.
                Array.Copy((byte[])e.Result, bin_header_bytes, );
                textBox_orig.Text="Что-то в отчёте - " + bin_header_bytes.Count().ToString();//func.ByEight(bin_header_bytes, 16);

            }
        }
        private void Button_decode_Click(object sender, EventArgs e)
        {
            button_decode.Enabled = false;
        }
    }
}
