using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
                foreach (KeyValuePair<string, long> filename in filestosearch)
                {
                    //Передаём имя файла и строку поиска в паралельный поток
                    string[] inputsearch = new string[2] { filename.Key, textBox_hexsearch.Text };
                    if (!backgroundWorker_hex_search.IsBusy) backgroundWorker_hex_search.RunWorkerAsync(inputsearch);
                }
            }
        }

        private void BackgroundWorker_hex_search_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] hex_search = (string[])e.Argument;
            FileInfo fi = new FileInfo(hex_search[0]);
            List<string> addr_value_file = new List<string>();
            addr_value_file.Add(fi.Name);
            if (fi.Length >= hex_search[1].Length / 2) //Длина файла должна быть не менее длины строки поиска
            {
                byte[] chunk = new byte[hex_search[1].Length / 2];
                using (var stream = File.OpenRead(hex_search[0]))
                {
                    //int byteschunk = stream.Read(chunk, 0, 4);
                    //for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                    //if (Enum.IsDefined(typeof(Guide.FH_magic_numbers), Convert.ToUInt32(dumptext.ToString(), 16)))
                    //{
                    //    dumptext.Clear();
                    //    stream.Position = 0;
                    //    byteschunk = stream.Read(chunk, 0, len);
                    //    for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                    //}
                }
            }
            e.Result = addr_value_file;
        }

        private void BackgroundWorker_hex_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> result = (List<string>)e.Result;
            if (result.Count > 1)
            {
                //По исполнению заполняем листвью списком совпадений
                //ListViewGroup group = new ListViewGroup(filesafename);
                ListViewItem hsearchres = new ListViewItem(new string[] { "0x10000", "****" + textBox_hexsearch.Text + "****", result[0] }); //Потом тут будет результат поиска
                listView_hex_search.Items.Add(hsearchres);
            }
            else
            {
                toolStripStatusLabel_search.Text = "Совпадения не найдены";
            }
        }
    }
}
