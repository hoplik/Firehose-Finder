using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        public Formfhf()
        {
            InitializeComponent();
        }

        private void Button_path_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_path.Text = folderBrowserDialog1.SelectedPath;
                button_startscan.Visible = true;
            }
        }

        private void Button_startscan_Click(object sender, EventArgs e)
        {
            button_startscan.Visible = false;
            Func func = new Func();
            _ = new Dictionary<string, long>();
            int volFiles = 0;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text);
            foreach (KeyValuePair<string, long> WL in Resfiles)
            {
                volFiles += Convert.ToInt32(WL.Value);//суммарный объём файлов для анализа
            }
            int numFiles = Resfiles.Count;//количество файлов для обработки
            /*запускаем индикатор выполнения*/
            int Currnum = 0;//текущий номер файла
            long Currvol = 0;//текущий объём
            foreach (KeyValuePair<string, long> countfiles in Resfiles)
            {
                Currnum += 1;
                Currvol += countfiles.Value;
                //Hexanal(countfiles.Key);
                Tests(countfiles.Key);
                toolStripStatusLabel_filescompleted.Text = "Обработано " + Currnum.ToString() + " файлов из " + numFiles.ToString();
                toolStripProgressBar_filescompleted.Maximum = volFiles;
                toolStripProgressBar_filescompleted.Value = Convert.ToInt32(Currvol);
                label_ind.Text = Currvol.ToString() + " байт";
            }
        }
        private void Tests(string fullpathfile)
        {
            byte[] chunk = new byte[64];
            using (var stream = File.OpenRead(fullpathfile))
            {
                int byteschunk = stream.Read(chunk, 0, 64);
                DumpBytes(chunk, byteschunk);
            }
        }
        public static void DumpBytes(byte[] bdata, int len)
        {
            int i;
            int j = 0;
            char dchar;
            if (bdata != null)
            {
                // 3 * 16 chars for hex display, 16 chars for text and 8 chars
                // for the 'gutter' int the middle.
                StringBuilder dumptext = new StringBuilder("        ", 16 * 4 + 8);
                for (i = 0; i < len; i++)
                {
                    dumptext.Insert(j * 3, String.Format("{0:X2} ", (int)bdata[i]));
                    dchar = (char)bdata[i];
                    //' replace 'non-printable' chars with a '.'.
                    if (Char.IsWhiteSpace(dchar) || Char.IsControl(dchar))
                    {
                        dchar = '.';
                    }
                    dumptext.Append(dchar);
                    j++;
                    if (j == 16)
                    {
                        MessageBox.Show("Обработано " + (i + 1).ToString() + " записей" + Environment.NewLine + dumptext.ToString());
                        dumptext.Length = 0;
                        dumptext.Append("        ");
                        j = 0;
                    }
                }
                // display the remaining line
                if (j > 0)
                {
                    for (i = j; i < 16; i++)
                    {
                        dumptext.Insert(j * 3, "   ");
                    }
                    MessageBox.Show("Это последняя неполная строка" + Environment.NewLine + dumptext.ToString());
                }
            }
        }

        private void Formfhf_Load(object sender, EventArgs e)
        {
            label_about.Text = FirehoseFinder.Properties.Resources.String_about + Environment.NewLine
                + "Версия сборки: " + Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}

