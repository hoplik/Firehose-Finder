using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FirehoseFinder.Forms
{
    public partial class ExSert : Form
    {
        readonly ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);
        internal string filestring = string.Empty; //Глобальная строка для обработки извлечённая из указанного файла

        public ExSert()
        {
            InitializeComponent();
        }

        private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {
                button2.Enabled = true;
                button2.Focus();
            }
            else button2.Enabled = false;
            toolStripStatusLabel1.Text = "Выбрано " + listView1.CheckedItems.Count.ToString() + " сертификатов";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            filestring = string.Empty;
            if (listView1.Items.Count > 0) listView1.Items.Clear(); //Очищаем листвью перед запросом
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                label2.Text = Path.GetDirectoryName(label1.Text);
                folderBrowserDialog1.SelectedPath = label2.Text;
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync(label1.Text); //Запускаем в параллельном потоке подсчёт сертификатов
            }
            else
            {
                label1.Text = string.Empty;
                label2.Text = string.Empty;
                button2.Enabled = false;
                toolStripStatusLabel1.Text = string.Empty;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = false;
                label2.Text = folderBrowserDialog1.SelectedPath;
                //Записываем сертификаты в указанную папку
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    int startadress = Convert.ToInt32(item.Text);
                    int sertlen = Convert.ToInt32(item.SubItems[1].Text);
                    string newfilename = startadress.ToString() + "-" + (startadress + 4 + sertlen).ToString() + ".der";
                    string newsert = filestring.Substring(startadress * 2, (4 * 2) + (sertlen * 2));
                    using (var stream = File.OpenWrite(label2.Text + "\\" + newfilename))
                    {
                        using (var writer = new BinaryWriter(stream))
                        {
                            writer.Write(Func.StringToByteArray(newsert));
                        }
                    }
                }
                //Обнуляем выбор сертификатов для скачивания
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Checked) item.Checked = false;
                }
                //Открываем папку для просмотра сертификатов
                Process.Start("explorer.exe", label2.Text);
            }
            else
            {
                button2.Enabled = true;
                button2.Focus();
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Считаем сертификаты в файле от 6 до 2 147 483 647 байт
            string FileToRead = (string)e.Argument;
            FileInfo fileInfo = new FileInfo(FileToRead);
            long filelength = fileInfo.Length;
            StringBuilder dumptext = new StringBuilder(string.Empty);
            if (filelength > 6 && filelength < 2147483647)
            {
                int len = Convert.ToInt32(filelength);
                byte[] chunk = new byte[len];
                using (var stream = File.OpenRead(FileToRead))
                {
                    int byteschunk = stream.Read(chunk, 0, len);
                    for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                }
            }
            e.Result = dumptext;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            filestring = e.Result.ToString();
            string pattern = "3082(.{4})3082"; //Бинарный признак сертификата с его длиной в середине (3082-4 знака-3082)
            byte countsert = 0; //Количество сертификатов в файле
            Regex regex = new Regex(pattern);
            MatchCollection matchs = regex.Matches(filestring);
            if (matchs.Count > 0)
            {
                foreach (Match match in matchs)
                {
                    countsert++;
                    int cslen = Convert.ToInt32(match.Groups[1].Value, 16);
                    if (cslen > 100 && cslen < 2000)
                    {
                        int startsert = match.Index / 2;
                        //Заполняем листбокс
                        ListViewItem item = new ListViewItem(startsert.ToString());
                        item.SubItems.Add(cslen.ToString());
                        item.SubItems.Add("Сертификат формата DER (X.509)");
                        listView1.Items.Add(item);
                    }
                    else countsert--;
                }
                toolStripStatusLabel1.Text = "Найдено " + countsert.ToString() + " сертификатов";
            }
        }

        private void ОтменитьВыборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items) if (item.Checked) item.Checked = false;
        }

        private void ВыбратьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items) if (!item.Checked) item.Checked = true;
        }
    }
}
