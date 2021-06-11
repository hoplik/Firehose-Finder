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
        public Dictionary<string, long> WFiles(string WorkDir, bool allFiles)
        {
            Dictionary<string, long> WorkFiles = new Dictionary<string, long>();
            var workF = new DirectoryInfo(WorkDir).EnumerateFiles("*.*", (SearchOption)Convert.ToInt32(allFiles));
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
            string HWID = "3F3F3F3F3F3F3F3F3F3F3F3F3F3F3F3F"; // Для неопределённого HWID ставим ??
            string SWID = "3F3F3F3F3F3F3F3F3F3F3F3F3F3F3F3F"; // Для неопределённого SWID ставим ??
            //Выбираем новый или старый способ поиска идентификаторов
            if (dumpfile.Length > 8600 && dumpfile.Substring(8200, 2).Equals("06")) //Новый шланг
            {
                StringBuilder hw_res = new StringBuilder(string.Empty);
                for (int i = 0; i < 4; i++)
                {
                    hw_res.Insert(0, dumpfile.Substring(8312 + i * 2, 2)); //103C, 4byte, HW_ID -идентификатор процессора
                }
                certarray[0] = hw_res.ToString();
                certarray[1] = dumpfile.Substring(8322, 2) + dumpfile.Substring(8320, 2); //1040, 2byte, OEM_ID -идентификатор OEM
                certarray[2] = dumpfile.Substring(8330, 2) + dumpfile.Substring(8328, 2); //1043 (1044 корректно), 2byte, MODEL_ID -идентификатор модели
                if (string.IsNullOrEmpty(CertExtr(dumpfile))) certarray[3] = "?"; else certarray[3] = CertExtr(dumpfile);  //хеш
                certarray[4] = dumpfile.Substring(8304, 2).TrimStart('0'); //1038, 1byte, SW_ID -идентификатор образа
                if (dumpfile.Substring(8520, 2) == "00") certarray[5] = string.Empty;
                else certarray[5] = "(" + dumpfile.Substring(8520, 2).TrimStart('0') + ")"; //10A4, 1byte, SW_VER -версия образа
            }
            else //Старый шланг 5 или 3 или ещё что-то
            {
                if (HWIDstrInd >= 32 && SWIDstrInd >= 32)
                {
                    HWID = dumpfile.Substring(HWIDstrInd - 32, 32);
                    SWID = dumpfile.Substring(SWIDstrInd - 32, 32);
                }
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
                            if (string.IsNullOrEmpty(CertExtr(dumpfile))) certarray[i] = "?"; else certarray[i] = CertExtr(dumpfile);
                            break;
                        case 4: // Формируем тип софтвера
                            string[] SNStr = new string[8];
                            int countn = 0;
                            for (int j = 16; j < 32; j += 2)
                            {
                                SNStr[countn] = Convert.ToString((char)int.Parse(SWID.Substring(j, 2), NumberStyles.HexNumber));
                                countn++;
                            }
                            string nstr = String.Join(string.Empty, SNStr);
                            string nend;
                            switch (nstr)
                            {
                                case "????????":
                                    nend = "?";
                                    break;
                                case "00000000":
                                    nend = "0";
                                    break;
                                default:
                                    nend = nstr.TrimStart('0');
                                    break;
                            }
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
                            string verend;
                            switch (verstr)
                            {
                                case "????????":
                                    verend = string.Empty;
                                    break;
                                case "00000000":
                                    verend = string.Empty;
                                    break;
                                default:
                                    verend = "(" + verstr.TrimStart('0') + ")";
                                    break;
                            }
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
            int rootcert = 0; //Расположение корневого сертификата в файле (второй или третий)
            string pattern = "3082.{4}3082"; //Бинарный признак сертификата с его длиной в середине (3082-4 знака-3082)
            MatchCollection matchs = Regex.Matches(SFDump, pattern);
            List<string> certs = new List<string>();
            StringBuilder SHAstr = new StringBuilder(string.Empty);
            SHA256 mysha256 = SHA256.Create();
            SHA384 rsaPSS = SHA384.Create();
            byte[] hashbytes = null;
            if (matchs.Count >= 2)
            {
                //Проверяем, реально ли сертификат по длине между 1 и 2
                string certl = SFDump.Substring(matchs[0].Index + 4, 4); // Получили длину сертификата в строке хекс
                int certlen = Int32.Parse(certl, NumberStyles.HexNumber); // Перевели её в 10 инт
                if ((matchs[0].Index + certlen * 2 + 8) == matchs[1].Index)
                {
                    rootcert = 2;
                    if (matchs.Count >= 3) rootcert = 3;
                }
            }
            if (rootcert > 0)
            {
                for (int i = 0; i < rootcert; i++)
                {
                    string certl = SFDump.Substring(matchs[i].Index + 4, 4); // Получили длину сертификата в строке хекс
                    int certlen = Int32.Parse(certl, NumberStyles.HexNumber); // Перевели её в 10 инт
                    certs.Insert(i, matchs[i].Value + SFDump.Substring(matchs[i].Index + 12, certlen * 2 - 4));
                }
                Guide guide = new Guide();
                foreach (KeyValuePair<string, int> correct_SHA in guide.SHA_magic_numbers)
                {
                    if (certs[rootcert - 1].Contains(correct_SHA.Key))
                    {
                        switch (correct_SHA.Value)
                        {
                            case 0://SHA384 - старые серты
                                hashbytes = rsaPSS.ComputeHash(StringToByteArray(certs[rootcert - 1]));
                                break;
                            case 1://SHA256 - старые серты
                                hashbytes = mysha256.ComputeHash(StringToByteArray(certs[rootcert - 1]));
                                break;
                            case 2://SHA256 - нормальные серты
                                hashbytes = mysha256.ComputeHash(StringToByteArray(certs[rootcert - 1]));
                                break;
                            case 3://SHA384 - новые серты
                                hashbytes = rsaPSS.ComputeHash(StringToByteArray(certs[rootcert - 1]));
                                break;
                            case 4://SHA384 - паченый старый программер
                                hashbytes = rsaPSS.ComputeHash(StringToByteArray(certs[rootcert - 1]));
                                break;
                            default:
                                hashbytes = null;
                                break;
                        }
                    }
                }
                if (hashbytes != null)
                {
                    SHAstr.Append(BitConverter.ToString(hashbytes));
                    SHAstr.Replace("-", string.Empty);
                    while (SHAstr.Length < 64) SHAstr.Insert(0, "0");
                }
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

        /// <summary>
        /// Парсинг результата работы команды Сахары 02
        /// </summary>
        /// <returns>Проверенная строка идентификаторов HWID_OEMID_MODELID</returns>
        internal string SaharaCommand2()
        {
            StringBuilder SC2 = new StringBuilder();
            byte[] comfilebytes = { };
            string[] compareresult = { string.Empty, string.Empty, string.Empty };
            if (File.Exists("commandop02.bin"))
            {
                comfilebytes = File.ReadAllBytes("commandop02.bin");
                File.Delete("commandop02.bin");
            }
            string backstr = BitConverter.ToString(comfilebytes).Replace("-", "");
            for (int i = backstr.Length - 1; i > 0; i -= 2)
            {
                SC2.Append(backstr.Substring(i - 1, 2));
            }
            int strlen = SC2.Length / 3;
            for (int i = 0; i < 3; i++) compareresult[i] = SC2.ToString().Substring(i * strlen, strlen);
            if (compareresult[0].Equals(compareresult[1]) && compareresult[1].Equals(compareresult[2])) return compareresult[0];
            else return SC2.ToString();
        }

        /// <summary>
        /// Парсинг результата работы команды Сахары 03
        /// </summary>
        /// <returns>Проверенная строка идентификатора OEM_HASH</returns>
        internal string SaharaCommand3()
        {
            StringBuilder SC3 = new StringBuilder();
            string[] compareresult = { string.Empty, string.Empty, string.Empty };
            if (File.Exists("commandop03.bin"))
            {
                SC3.Append(BitConverter.ToString(File.ReadAllBytes("commandop03.bin")).Replace("-", ""));
                File.Delete("commandop03.bin");
            }
            int strlen = SC3.Length / 3;
            for (int i = 0; i < 3; i++) compareresult[i] = SC3.ToString().Substring(i * strlen, strlen);
            return compareresult[0];
            //if (compareresult[0].Equals(compareresult[1]) && compareresult[1].Equals(compareresult[2])) return compareresult[0];
            //else return SC3.ToString(); //Всё равно возвращаем только первое значение, понимая, что различаются.
            //NOTE From revision 2.4, PK Hash returns three hashes for APPS, MBA, and MSS code segments for B - family chips.
        }

        /// <summary>
        /// Парсинг результата работы команды Сахары 07
        /// </summary>
        /// <returns>Строка идентификатора SW SBL1 в little endian</returns>
        internal string SaharaCommand7()
        {
            StringBuilder SC7 = new StringBuilder();
            if (File.Exists("commandop07.bin"))
            {
                string strbyte = BitConverter.ToString(File.ReadAllBytes("commandop07.bin")).Replace("-", "");
                byte count = (byte)strbyte.Length;
                while (count > 0)
                {
                    SC7.Append(strbyte.Substring(count - 2, 2));
                    count -= 2;
                }
                File.Delete("commandop07.bin");
            }
            return SC7.ToString();
        }

        internal int[] StorageInfo(string storage_info)
        {
            //"total_blocks":122142720, "block_size":512, "page_size":512, "num_physical":3, "mfr_id":21, "serial_num":710139074, 
            //"fw_version":"7","mem_type":"eMMC", "prod_name":"RC14MB"
            int[] SI = new int[4];
            //Стартуем с " и до ": - это поле для свича
            //От конца поля для свича до , - значение
            //Если значение в "", то это стринг, иначе инт
            //Сначала разбиваем массив на части по символу ,
            string[] tempSI = storage_info.Split(',');
            for (int i = 0; i < tempSI.Length; i++)
            {
                int startindex = tempSI[i].IndexOf('"') + 1;
                int endindex = tempSI[i].IndexOf("\":");
                string str_links = tempSI[i].Substring(startindex, endindex - startindex);
                string str_link_value = tempSI[i].Substring(endindex + 2).Trim('\"');
                switch (str_links)
                {
                    case "total_blocks":
                        SI[0] = Convert.ToInt32(str_link_value);
                        break;
                    case "block_size":
                        SI[1] = Convert.ToInt32(str_link_value);
                        break;
                    case "num_physical":
                        SI[2] = Convert.ToInt32(str_link_value);
                        break;
                    case "mem_type":
                        if (str_link_value.Equals("UFS")) SI[3] = (int)Guide.MEM_TYPE.UFS;
                        else SI[3] = (int)Guide.MEM_TYPE.eMMC;
                        break;
                    default:
                        break;
                }
            }
            return SI;
        }
    }
}

