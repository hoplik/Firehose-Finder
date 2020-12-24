using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FirehoseFinder
{
    class Func
    {
        /// <summary>
        /// Создаём список файлов с размером из указанной директории
        /// </summary>
        public Dictionary<string, long> WFiles(string WorkDir)
        {
            Dictionary<string, long> WorkFiles = new Dictionary<string, long>();
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
                MessageBox.Show(e.Message + Environment.NewLine + "Ошибка в функции WFiles");
            }
            return WorkFiles;
        }

        /// <summary>
        /// Вытаскиваем идентификаторы из считанного файла
        /// </summary>
        /// <param name="dumpfile">Полный путь к файлу</param>
        /// <returns>Массив идентификаторов в строках</returns>
        public string[] IDs(string dumpfile)
        {
            string[] certarray = new string[6] { "-", "-", "-", "-", "-", "-" };
            int HWIDstrInd = dumpfile.IndexOf("2048575F4944"); // HW_ID
            int SWIDstrInd = dumpfile.IndexOf("2053575F4944"); // SW_ID
            if (HWIDstrInd >= 32 && SWIDstrInd >= 32)
            {
                string HWID = dumpfile.Substring(HWIDstrInd - 32, 32);
                string SWID = dumpfile.Substring(SWIDstrInd - 32, 32);
                for (int i = 0; i < certarray.Length; i++)
                {
                    switch (i)
                    {
                        case 0: // Вытягиваем процессор
                            string[] HStr = new string[8];
                            int counth = 0;
                            for (int j = 0; j < 16; j += 2)
                            {
                                HStr[counth] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                counth++;
                            }
                            certarray[i] = String.Join(string.Empty, HStr);
                            break;
                        case 1: // Вытягиваем производителя
                            string[] OStr = new string[4];
                            int counto = 0;
                            for (int j = 16; j < 24; j += 2)
                            {
                                OStr[counto] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                counto++;
                            }
                            certarray[i] = String.Join(string.Empty, OStr);
                            break;
                        case 2: // Вытягиваем номер модели
                            string[] MStr = new string[4];
                            int countm = 0;
                            for (int j = 24; j < 32; j += 2)
                            {
                                MStr[countm] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                countm++;
                            }
                            certarray[i] = String.Join(string.Empty, MStr);
                            break;
                        case 3: // Расчитываем хеш
                            certarray[i] = CertExtr(dumpfile);
                            break;
                        case 4: // Формируем тип софтвера
                            string[] SNStr = new string[8];
                            int countn = 0;
                            for (int j = 16; j < 32; j += 2)
                            {
                                SNStr[countn] = Convert.ToString((char)int.Parse(SWID.Substring(j, 2), NumberStyles.HexNumber));
                                countn++;
                            }
                            string nstr = String.Join("", SNStr);
                            string nend;
                            if (String.Compare("00000000", nstr) != 0) nend = nstr.TrimStart('0');
                            else nend = "0";
                            certarray[i] = nend;
                            break;
                        case 5: //  Формируем версию софтвера
                            string[] SWStr = new string[8];
                            int countv = 0;
                            for (int j = 0; j < 16; j += 2)
                            {
                                SWStr[countv] = Convert.ToString((char)int.Parse(SWID.Substring(j, 2), NumberStyles.HexNumber));
                                countv++;
                            }
                            string verstr = String.Join(string.Empty, SWStr);
                            string verend = string.Empty;
                            if (String.Compare("00000000", verstr) != 0) verend = "(" + verstr.TrimStart('0') + ")";
                            certarray[i] = verend;
                            break;
                        default:
                            break;
                    }
                }
            }
            return certarray;
        }

        /// <summary>
        /// Рассчитываем хеш корневого сертификата
        /// </summary>
        /// <param name="SFDump">Считанная строка</param>
        /// <returns>Строка хеша</returns>
        private static string CertExtr(string SFDump)
        {
            string pattern = "(3082.{4}3082)"; //Признак сертификата с его длиной в середине 4 байта
            MatchCollection matchs = Regex.Matches(SFDump, pattern);
            Dictionary<int, string> certs = new Dictionary<int, string>();
            int countcert = 1;
            StringBuilder SHAstr = new StringBuilder();
            foreach (Match match in matchs)
            {
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
                SHAstr.Replace("-", string.Empty);
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

        /// <summary>
        /// Переводим строку хекс символов в байты
        /// </summary>
        /// <param name="hex">Строка хекс символов</param>
        /// <returns>Массив байт</returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}

