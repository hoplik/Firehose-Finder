using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

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

        internal string SaharaCommand1()
        {
            StringBuilder SC1 = new StringBuilder();
            byte[] comfilebytes = { };
            if (File.Exists("commandop01.bin"))
            {
                comfilebytes = File.ReadAllBytes("commandop01.bin");
                //File.Delete("commandop01.bin");
            }
            string backstr = BitConverter.ToString(comfilebytes).Replace("-", "");
            //Читаем с конца  в начало
            for (int i = backstr.Length - 1; i > 0; i -= 2)
            {
                SC1.Append(backstr.Substring(i - 1, 2));
            }
            return SC1.ToString();
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
            //Читаем с конца в начало
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
            //Читаем с начала до конца
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
                //Читаем с конца в начало
                while (count > 0)
                {
                    SC7.Append(strbyte.Substring(count - 2, 2));
                    count -= 2;
                }
                File.Delete("commandop07.bin");
            }
            return SC7.ToString();
        }

        /// <summary>
        /// Парсинг таблицы GPT
        /// </summary>
        /// <param name="GPT_File">Файл таблицы для парсинга</param>
        /// <param name="block_size">Размер блока</param>
        /// <returns>Массив структуры данных таблицы GPT</returns>
        internal List<GPT_Table> Parsing_GPT_main(string GPT_File, int block_size)
        {
            List<GPT_Table> GPT = new List<GPT_Table>();
            GPT_Struct magic_number = new GPT_Struct(0x00, 8, string.Empty); //0x00    8 байт  45 46 49 20 50 41 52 54 Сигнатура заголовка.Используется для идентификации всех EFI - совместимых GPT - заголовков.Должно содержать значение 45 46 49 20 50 41 52 54, что в виде текста расшифровывается как "EFI PART".
            //GPT_Struct format_version = new GPT_Struct(0x08, 4, string.Empty); //0x08	4 байта 00 00 01 00	Версия формата заголовка (не спецификации UEFI). Сейчас используется версия заголовка 1.0
            //GPT_Struct header_length = new GPT_Struct(0x0C, 4, string.Empty); //0x0C	4 байта	5C 00 00 00	Размер заголовка GPT в байтах.Имеет значение 0x5C (92 байта)
            //GPT_Struct header_crc32 = new GPT_Struct(0x10, 4, string.Empty); //0x10	4 байта	27 6D 9F C9 Контрольная сумма GPT-заголовка(по адресам от 0x00 до 0x5C). Алгоритм контрольной суммы — CRC32.При подсчёте контрольной суммы начальное значение этого поля принимается равным нулю.
            //GPT_Struct reserved1 = new GPT_Struct(0x14, 4, string.Empty); //0x14	4 байта	00 00 00 00	Зарезервировано.Должно иметь значение 0
            //GPT_Struct header_adress = new GPT_Struct(0x18, 8, string.Empty); //0x18	8 байт	01 00 00 00 00 00 00 00	Адрес сектора, содержащего первичный GPT-заголовок.Всегда имеет значение LBA 1.
            //GPT_Struct bak_header_adress = new GPT_Struct(0x20, 8, string.Empty); //0x20	8 байт	37 C8 11 01 00 00 00 00	Адрес сектора, содержащего копию GPT-заголовка.Всегда имеет значение адреса последнего сектора на диске.
            //GPT_Struct data_startadress = new GPT_Struct(0x28, 8, string.Empty); //0x28	8 байт	22 00 00 00 00 00 00 00	Адрес сектора с которого начинаются разделы на диске.Иными словами — адрес первого раздела диска
            //GPT_Struct data_endadress = new GPT_Struct(0x30, 8, string.Empty); //0x30	8 байт  17 C8 11 01 00 00 00 00	Адрес последнего сектора диска, отведенного под разделы
            //GPT_Struct disk_id = new GPT_Struct(0x38, 16, string.Empty); //0x38	16 байт 00 A2 DA 98 9F 79 C0 01 A1 F4 04 62 2F D5 EC 6D	GUID диска. Содержит уникальный идентификатор, выданный диску и GPT-заголовку при разметке
            GPT_Struct gpt_startadress = new GPT_Struct(0x48, 8, string.Empty); //0x48	8 байт  02 00 00 00 00 00 00 00	Адрес начала таблицы разделов
            GPT_Struct max_gpt_blocks = new GPT_Struct(0x50, 4, string.Empty); //0x50	4 байта 80 00 00 00	Максимальное число разделов, которое может содержать таблица
            GPT_Struct record_length = new GPT_Struct(0x54, 4, string.Empty); //0x54	4 байта 80 00 00 00	Размер записи для раздела
                                                                              //GPT_Struct gpt_crc32 = new GPT_Struct(0x58, 4, string.Empty); //0x58	4 байта 27 C3 F3 85	Контрольная сумма таблицы разделов. Алгоритм контрольной суммы — CRC32
                                                                              //GPT_Struct reserved2 = new GPT_Struct(0x5C, 420, string.Empty); //0x5C	420 байт    0	Зарезервировано.Должно быть заполнено нулями
            string Full_GPT = BitConverter.ToString(File.ReadAllBytes(GPT_File)).Replace("-", ""); //Сначала считываем весь файл
            string GPT_Header = Full_GPT.Remove(0, block_size * 2); //Удалили MBR
            //Обрабатываем заголовок
            string gpt_header = GPT_Header.Remove(block_size * 2); //Удалили хвост
            magic_number.ValueString = gpt_header.Substring(magic_number.StartAdress * 2, magic_number.Length * 2);
            //Если не хедер, прекращаем обработку таблицы
            if (!magic_number.ValueString.Equals("4546492050415254"))
            {
                GPT_Table GPT_Items = new GPT_Table()
                {
                    StartLBA = "Отсутствует признак хедера таблицы"
                };
                GPT.Add(GPT_Items);
                return GPT;
            }
            //Адрес начала таблицы
            gpt_startadress.ValueString = gpt_header.Substring(gpt_startadress.StartAdress * 2, gpt_startadress.Length * 2);
            string gsa = gpt_startadress.ValueString;
            while (gsa.EndsWith("00"))
            {
                gsa = gsa.Remove(gsa.Length - 2, 2);
            }
            gsa = gsa.TrimStart('0');
            //Максимальное количество блоков
            max_gpt_blocks.ValueString = gpt_header.Substring(max_gpt_blocks.StartAdress * 2, max_gpt_blocks.Length * 2);
            string mgb = string.Empty;
            for (int i = 0; i < max_gpt_blocks.Length; i++)
            {
                mgb = mgb.Insert(0, max_gpt_blocks.ValueString.Substring(i * 2, 2));
            }
            mgb = mgb.TrimStart('0');
            //Размер записи для раздела
            record_length.ValueString = gpt_header.Substring(record_length.StartAdress * 2, record_length.Length * 2);
            string rl = record_length.ValueString;
            while (rl.EndsWith("00"))
            {
                rl = rl.Remove(rl.Length - 2, 2);
            }
            rl = rl.TrimStart('0');
            int rlint = Convert.ToInt32(rl, 16);
            //Обрабатываем данные самой таблицы
            string GPT_Values = Full_GPT.Remove(0, block_size * 2 * Convert.ToInt32(gsa, 16)); //Удалили MBR и хедер
            //GPT_Struct block_idtype = new GPT_Struct(0x00, 16, string.Empty); //0x00    16 байт 28 73 2A C1 1F F8 D2 11 BA 4B 00 A0 C9 3E C9 3B GUID типа раздела. В примере приведен тип раздела "EFI System partition".Список всех типов можно посмотреть https://en.wikipedia.org/wiki/GUID_Partition_Table#Partition_type_GUIDs
            //GPT_Struct block_id = new GPT_Struct(0x10, 16, string.Empty); //0x10    16 байт C0 94 77 FC 43 86 C0 01 92 E0 3C 77 2E 43 AC 40 Уникальный GUID раздела.Генерируется при создании раздела
            GPT_Struct block_startadress = new GPT_Struct(0x20, 8, string.Empty); //0x20    8 байт  3F 00 00 00 00 00 00 00 Начальный LBA-адрес раздела
            GPT_Struct block_endadress = new GPT_Struct(0x28, 8, string.Empty); //0x28    8 байт CC 2F 03 00 00 00 00 00 Последний LBA-адрес раздела
            //GPT_Struct block_attr = new GPT_Struct(0x30, 8, string.Empty); //0x30    8 байт  00 00 00 00 00 00 00 00 Атрибуты раздела в виде битовой маски
            GPT_Struct block_name = new GPT_Struct(0x38, 72, string.Empty); //0x38    72 байта EFI system partition    Название раздела. Unicode - строка длиной 36 - символов
            //Анализируем каждый блок из 128 и при ненулевом значении добавляем в список
            string[] blocks_array = new string[Convert.ToInt32(mgb, 16)];
            for (int i = 0; i < blocks_array.Length; i++)
            {
                blocks_array[i] = GPT_Values.Substring(i * rlint * 2, rlint * 2);
            }
            foreach (string block_string in blocks_array)
            {
                //Парсим стартовый адрес блока
                block_startadress.ValueString = block_string.Substring(block_startadress.StartAdress * 2, block_startadress.Length * 2);
                string bsa = string.Empty;
                for (int k = 0; k < block_startadress.Length; k++)
                {
                    bsa = bsa.Insert(0, block_startadress.ValueString.Substring(k * 2, 2));
                }
                //Парсим последний адрес блока
                block_endadress.ValueString = block_string.Substring(block_endadress.StartAdress * 2, block_endadress.Length * 2);
                string bea = string.Empty;
                for (int m = 0; m < block_endadress.Length; m++)
                {
                    bea = bea.Insert(0, block_endadress.ValueString.Substring(m * 2, 2));
                }
                //Парсим название блока
                block_name.ValueString = block_string.Substring(block_name.StartAdress * 2, block_name.Length * 2);
                StringBuilder bn = new StringBuilder();
                for (int p = 0; p < block_name.Length; p += 4)
                {
                    string unichar = (block_name.ValueString.Substring(p + 2, 2) + block_name.ValueString.Substring(p, 2)).TrimStart('0');
                    if (!string.IsNullOrEmpty(unichar)) bn.Append(Convert.ToChar(Convert.ToInt32(unichar, 16)));
                }
                GPT_Table GPT_Items = new GPT_Table()
                {
                    StartLBA = bsa.TrimStart('0'),
                    EndLBA = bea.TrimStart('0'),
                    BlockName = bn.ToString()
                };
                if (!string.IsNullOrEmpty(GPT_Items.StartLBA) && !string.IsNullOrEmpty(GPT_Items.EndLBA))
                {
                    uint blocks_count = Convert.ToUInt32(GPT_Items.EndLBA, 16) - Convert.ToUInt32(GPT_Items.StartLBA, 16) + 1;
                    GPT_Items.BlockBytes = (blocks_count * block_size).ToString();
                    GPT_Items.BlockLength = blocks_count.ToString() + " (" + Bytes_KB_MB(GPT_Items.BlockBytes) + ")";
                    GPT.Add(GPT_Items);
                }
            }
            return GPT;
        }

        /// <summary>
        /// Конвертируем строковое значение байт в килобайты, мегабайты и гигабайты
        /// </summary>
        /// <param name="bytestoconvert">Строковое значение байт</param>
        /// <returns>Строковое значение в килобайтах, мегабайтах и гигабайтах</returns>
        internal string Bytes_KB_MB(string bytestoconvert)
        {
            string byte_type = "b";
            double total_size = Convert.ToDouble(bytestoconvert);
            if (total_size >= 1024)
            {
                total_size /= 1024.00;
                byte_type = "Kb";
                if (total_size >= 1024)
                {
                    total_size /= 1024.00;
                    byte_type = "Mb";
                    if (total_size >= 1024)
                    {
                        total_size /= 1024.00;
                        byte_type = "Gb";
                    }
                }
            }
            return string.Format("{0} {1}", total_size.ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE")), byte_type);
        }

        /// <summary>
        /// Выполнение FH_Loader с указанными параметрами
        /// </summary>
        /// <param name="com_args">Аргументы команды лоадеру</param>
        /// <returns>Ответ лоадера по результатам исполнения команды</returns>
        internal string FH_Commands(string com_args)
        {
            string output = string.Empty;
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "fh_loader.exe";
            process.StartInfo.Arguments = com_args;
            try
            {
                process.Start();
                StreamReader reader = process.StandardOutput;
                output = reader.ReadToEnd();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить fh_loader с указанными параметрами" + Environment.NewLine + ex.Message);
            }
            return output;
        }

        /// <summary>
        /// Создаём xml-файл стирания секторов
        /// </summary>
        internal void FhXmltoErase(string StartLBA, string EndLBA)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", string.Empty, null);
            uint blocks_count = Convert.ToUInt32(EndLBA, 16) - Convert.ToUInt32(StartLBA, 16) + 1;
            doc.LoadXml(string.Format("<data>" +
                "<erase start_sector=\"0x{0}\" num_partition_sectors=\"{1}\"/>" +
                "</data>", StartLBA, blocks_count.ToString()));
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            try
            {
                doc.Save("erase.xml");
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Не удалось создать xml-файл стирания разделов" + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Создаём файл чтения/записи
        /// </summary>
        /// <param name="reading">Чтение - true, запись - false</param>
        /// <param name="SECTOR_SIZE">Размер сектора (512 или 4096)</param>
        /// <param name="filename">Имя итогового файла чтения/записи (*.bin)</param>
        /// <param name="physical_partition">Номер диска</param>
        /// <param name="StartLBA">Хекс стартового адреса сектора</param>
        /// <param name="EndLBA">Хекс последнего адреса сектора</param>
        internal void FhXmltoRW(bool reading, string SECTOR_SIZE, string filename, string physical_partition, string StartLBA, string EndLBA)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldecl;
            StringBuilder xmlloadargs = new StringBuilder("<data>");
            xmldecl = doc.CreateXmlDeclaration("1.0", string.Empty, null);
            uint blocks_count = Convert.ToUInt32(EndLBA, 16) - Convert.ToUInt32(StartLBA, 16) + 1;
            if (reading) xmlloadargs.Append("<read"); //Готовим файл для чтения
            else xmlloadargs.Append("<program"); //Готовим файл для записи
            xmlloadargs.Append(string.Format(" SECTOR_SIZE_IN_BYTES=\"{0}\" filename=\"{1}\" num_partition_sectors=\"{2}\" physical_partition_number=\"{3}\" start_sector=\"0x{4}\"/>",
                SECTOR_SIZE, filename, blocks_count.ToString(), physical_partition, StartLBA));
            xmlloadargs.Append("</data>");
            doc.LoadXml(xmlloadargs.ToString());
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            try
            {
                doc.Save("p_r.xml");
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Не удалось создать xml-файл чтения/записи разделов" + Environment.NewLine + ex.Message);
            }
        }
    }
}

