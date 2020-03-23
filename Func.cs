using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FirehoseFinder
{
    class Func
    {
        /// <summary>
        /// Создаём список файлов с размером из указанной директории
        /// </summary>
        private readonly Dictionary<string, long> WorkFiles = new Dictionary<string, long>();
        public Dictionary<string, long> WFiles(string WorkDir)
        {
            var workF = new DirectoryInfo(WorkDir).EnumerateFiles("*.*", SearchOption.TopDirectoryOnly);
            try
            {
                foreach (var WF in workF)
                {
                    WorkFiles.Add(WF.FullName, WF.Length);
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + "Попались дубли файлов, но это не страшно");
            }
            return WorkFiles;
        }
        /// <summary>
        /// Список проверок для формирования рейтинга программера
        /// </summary>
        /// <param name="Filepath">Ссылка на файл программера</param>
        /// <returns>Увеличивает рейтинг на 1 при удачном прохождении теста</returns>
        public int Rating(string Filepath)
        {
            FileInfo fi = new FileInfo(Filepath);
            int Rat = 0;
            //Тест 1 - Файл должен быть больше 0х3000 байт
            if (fi.Length >= 12288)// Это 0х3000 в хекс
            {
                // Тест 2 - Файл должен быть ELF
                if (ElfReader(Filepath).StartsWith("7F454C46"))
                {
                    Rat++;
                }
            }
            return Rat;
        }

        public string ElfReader(string Filepath)
        {
            int len = 12288;
            StringBuilder dumptext = new StringBuilder(len);
            byte[] chunk = new byte[len];
            using (var stream = File.OpenRead(Filepath))
            {
                int byteschunk = stream.Read(chunk, 0, len);
                for (int i = 0; i < byteschunk; i++)
                {
                    dumptext.Insert(i * 2, String.Format("{0:X2}", (int)chunk[i]));
                }
            }
            return dumptext.ToString();
        }

        public string HWID()
        {
            string str = "00000000";
            return str;
        }
        public string OEMID()
        {
            string str = "0000";
            return str;
        }
        public string MODELID()
        {
            string str = "0000";
            return str;
        }
        public string HASH()
        {
            string str = "00000000";
            return str;
        }

    }
}
