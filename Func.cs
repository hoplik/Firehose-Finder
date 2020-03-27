using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Linq;

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
                // Тест 3 - у программера есть fh@0x%08, у xbl этого нет.
                if (ElfReader(Filepath).Contains("6668403078253038"))
                {
                    Rat++;
                }
            }
            return Rat;
        }

        public static string ElfReader(string Filepath)
        {
            FileInfo exfile = new FileInfo(Filepath);
            int len = Convert.ToInt32(exfile.Length);
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

        public string[] IDs(string Filepath)
        {
            string str = ElfReader(Filepath);
            string[] certarray = new string[5] { "-", "-", "-", "-", "-" };
            int HWIDstrInd = str.IndexOf("2048575F4944"); // HW_ID
            int SWIDstrInd = str.IndexOf("2053575F4944"); // SW_ID
            if (HWIDstrInd >= 32 && SWIDstrInd >= 32)
            {
                string HWID = str.Substring(HWIDstrInd - 32, 32);
                string SWID = str.Substring(SWIDstrInd - 32, 32);
                for (int i = 0; i < certarray.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            // Вытягиваем процессор
                            string[] HStr = new string[8];
                            int counth = 0;
                            for (int j = 0; j < 16; j += 2)
                            {
                                HStr[counth] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                counth++;
                            }
                            certarray[i] = String.Join("", HStr);
                            break;
                        case 1:
                            // Вытягиваем производителя
                            string[] OStr = new string[4];
                            int counto = 0;
                            for (int j = 16; j < 24; j += 2)
                            {
                                OStr[counto] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                counto++;
                            }
                            certarray[i] = String.Join("", OStr);
                            break;
                        case 2:
                            // Вытягиваем номер модели
                            string[] MStr = new string[4];
                            int countm = 0;
                            for (int j = 24; j < 32; j += 2)
                            {
                                MStr[countm] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                countm++;
                            }
                            certarray[i] = String.Join("", MStr);
                            break;
                        case 3:
                            // Расчитываем хеш
                            certarray[i] = CertExtr(str, Filepath);
                            break;
                        case 4:
                            //  Формируем версию софтвера
                            string[] SWStr = new string[8];
                            int countv = 0;
                            for (int j = 0; j < 16; j += 2)
                            {
                                SWStr[countv] = Convert.ToString((char)int.Parse(SWID.Substring(j, 2), NumberStyles.HexNumber));
                                countv++;
                            }
                            string verstr = String.Join("", SWStr);
                            string verend = string.Empty;
                            if (String.Compare("00000000", verstr) != 0)
                            {
                                verend = "(" + verstr.TrimStart('0') + ")";
                            }
                            // Формируем номер софтвера
                            string[] SNStr = new string[8];
                            int countn = 0;
                            for (int j = 16; j < 32; j += 2)
                            {
                                SNStr[countn] = Convert.ToString((char)int.Parse(SWID.Substring(j, 2), NumberStyles.HexNumber));
                                countn++;
                            }
                            string nstr = String.Join("", SNStr);
                            string nend;
                            if (String.Compare("00000000", nstr) != 0)
                            {
                                nend = nstr.TrimStart('0');
                            }
                            else
                            {
                                nend = "0";
                            }
                            certarray[i] = nend + verend;
                            break;
                        default:
                            break;
                    }
                }
            }
            return certarray;
        }
        private static string CertExtr(string SFDump, string file)
        {
            string pattern = "(3082.{4}3082)";
            MatchCollection matchs = Regex.Matches(SFDump, pattern);
            Dictionary<int, string> certs = new Dictionary<int, string>();
            int countcert = 1;
            StringBuilder SHAstr = new StringBuilder();
            FileInfo fi = new FileInfo(file);
            foreach (Match match in matchs)
            {
                if (countcert > 3)
                {
                    MessageBox.Show("В текущем файле " + fi.Name + " более 3 сертификатов." + Environment.NewLine + "Будут обработаны первые 3.");
                    break;
                }
                string certl = SFDump.Substring(match.Index + 4, 4); // Получили длину сертификата в строке хекс
                int certlen = Int32.Parse(certl, NumberStyles.HexNumber); // Перевели её в 10 инт
                certs.Add(countcert, match.Value + SFDump.Substring(match.Index + 12, certlen * 2 - 4));
                countcert++;
            }
            SHA256 mysha256 = SHA256.Create();
            if (certs.ContainsKey(3))
            {
                byte[] hashbytes = mysha256.ComputeHash(StringToByteArray(certs[3]));
                SHAstr.Append(BitConverter.ToString(hashbytes));
                SHAstr.Replace("-", "");
            }
            if (SHAstr.Length < 64)
            {
                int morechar = 64 - SHAstr.Length;
                SHAstr.Insert(0, "0", morechar);
            }
            if (certs[1].Contains("534841323536")) // SHA256
            {
                SHAstr.Append("(SHA256)");
            }
            return SHAstr.ToString();
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
