using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FirehoseFinder
{
    class Func
    {
        /// <summary>
        /// Создаём список файлов с размером из указанной директории
        /// </summary>
        private Dictionary<string, long> WorkFiles = new Dictionary<string, long>();
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
    }
}
