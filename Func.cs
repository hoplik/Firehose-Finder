using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Telegram.Bot.Types.Enums;

namespace FirehoseFinder
{
    class Func
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        /// <summary>
        /// Система исчисления, применяемая к строке знаков
        /// </summary>
        internal enum System_Count
        {
            dex,
            hex
        }

        /// <summary>
        /// Строка из 0x40 символов (64 байт)
        /// </summary>
        internal enum Parsing_Header_String_Bytes
        {
            Packer_Version = 0, // 0х0 Версия упаковщика
            Phone_Version = 64, // 0x40 Версия телефона
            Image_Version = 576, // 0x240 Версия прошивки
            Author = 1096, // 0x448 Автор прошивки (8 байт)
            Header_Len = 1612 // 0x64c Возможно размер шапки (2 байта)
        }

        /// <summary>
        /// Четыре байта на цифру
        /// </summary>
        internal enum Parsing_Header_Four_Bytes
        {
            Config_Files = 1088, // 0x440 Количество конфигурационных файлов внутри прошивки в хекс (кодируются)
            Bin_Files = 1092, // 0x444 Количество bin файлов внутри прошивки в хекс (не кодируются)
            Bin_Number = 1608 // 0x648 Количество bin файлов прошивки (должен быть 1, иначе аварийное завершение)
        }

        /// <summary>
        /// Количество байт для чтения при разных режимах
        /// </summary>
        internal enum Parsing_Bytes
        {
            String_parse = 64, // 0x40 Количество знаков для строковых значений
            Long_number = 8, // Количество знаков для длинных цифр в информации о файле
            File_info = 160 // Суммарное количество знаков для описания файла
        }

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
                MessageBox.Show(e.Message, LocRes.GetString("er_func_wfiles"));
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
                            certarray[i] = string.Join(string.Empty, HStr);
                            break;
                        case 1: // Вытягиваем производителя
                            string[] OStr = new string[4];
                            int counto = 0;
                            for (int j = 16; j < 24; j += 2)
                            {
                                OStr[counto] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                counto++;
                            }
                            certarray[i] = string.Join(string.Empty, OStr);
                            break;
                        case 2: // Вытягиваем номер модели
                            string[] MStr = new string[4];
                            int countm = 0;
                            for (int j = 24; j < 32; j += 2)
                            {
                                MStr[countm] = Convert.ToString((char)int.Parse(HWID.Substring(j, 2), NumberStyles.HexNumber));
                                countm++;
                            }
                            certarray[i] = string.Join(string.Empty, MStr);
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
                            string nstr = string.Join(string.Empty, SNStr);
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
                            string verstr = string.Join(string.Empty, SWStr);
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
                int certlen = int.Parse(certl, NumberStyles.HexNumber); // Перевели её в 10 инт
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
                                //hashbytes = mysha256.ComputeHash(StringToByteArray(certs[rootcert - 1]));
                                hashbytes = null;
                                break;
                        }
                    }
                }
                if (hashbytes != null)
                {
                    SHAstr.Append(BitConverter.ToString(hashbytes));
                    SHAstr.Replace("-", string.Empty);
                    while (SHAstr.Length < 64) SHAstr.Insert(0, '0');
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
        /// Парсинг результата работы команды Сахары 01
        /// </summary>
        /// <returns></returns>
        internal string SaharaCommand1()
        {
            if (File.Exists("commandop01.bin"))
            {
                StringBuilder SC1 = new StringBuilder();
                byte[] comfilebytes = File.ReadAllBytes("commandop01.bin");
                string backstr = BitConverter.ToString(comfilebytes).Replace("-", "");
                //Читаем с конца  в начало
                for (int i = backstr.Length - 1; i > 0; i -= 2) SC1.Append(backstr.Substring(i - 1, 2));
                File.Delete("commandop01.bin");
                return SC1.ToString();
            }
            else return LocRes.GetString("file") + " commandop01.bin " + LocRes.GetString("hex_not") + '\u0020' + LocRes.GetString("hex_processed");
        }

        /// <summary>
        /// Парсинг результата работы команды Сахары 02
        /// </summary>
        /// <returns>Проверенная строка идентификаторов HWID_OEMID_MODELID</returns>
        internal string SaharaCommand2()
        {
            if (File.Exists("commandop02.bin"))
            {
                StringBuilder SC2 = new StringBuilder();
                string[] compareresult = { string.Empty, string.Empty, string.Empty };
                byte[] comfilebytes = File.ReadAllBytes("commandop02.bin");
                string backstr = BitConverter.ToString(comfilebytes).Replace("-", "");
                //Читаем с конца в начало
                for (int i = backstr.Length - 1; i > 0; i -= 2)
                {
                    SC2.Append(backstr.Substring(i - 1, 2));
                }
                int strlen = SC2.Length / 3; //Базово должно быть 16 знаков
                for (int i = 0; i < 3; i++) compareresult[i] = SC2.ToString().Substring(i * strlen, strlen); //Заполняем строковым значением
                File.Delete("commandop02.bin");
                if (compareresult[2].Equals(compareresult[0]) || compareresult[0].Equals("0000000000000000"))
                {
                    if (compareresult[2].Equals(compareresult[1]) || compareresult[1].Equals("0000000000000000")) return compareresult[2];
                    else return SC2.ToString();
                }
                else return SC2.ToString();
            }
            else return LocRes.GetString("file") + " commandop02.bin " + LocRes.GetString("hex_not") + '\u0020' + LocRes.GetString("hex_processed");
        }

        /// <summary>
        /// Парсинг результата работы команды Сахары 03
        /// </summary>
        /// <returns>Проверенная строка идентификатора OEM_HASH</returns>
        internal string SaharaCommand3()
        {
            if (File.Exists("commandop03.bin"))
            {
                StringBuilder SC3 = new StringBuilder();
                string[] compareresult = { string.Empty, string.Empty, string.Empty };
                SC3.Append(BitConverter.ToString(File.ReadAllBytes("commandop03.bin")).Replace("-", ""));
                //Читаем с начала до конца
                int strlen = SC3.Length / 3;
                for (int i = 0; i < 3; i++) compareresult[i] = SC3.ToString().Substring(i * strlen, strlen);
                File.Delete("commandop03.bin");
                return compareresult[0];
                //NOTE From revision 2.4, PK Hash returns three hashes for APPS, MBA, and MSS code segments for B - family chips.
            }
            else return LocRes.GetString("file") + " commandop03.bin " + LocRes.GetString("hex_not") + '\u0020' + LocRes.GetString("hex_processed");
        }

        /// <summary>
        /// Парсинг результата работы команды Сахары 07
        /// </summary>
        /// <returns>Строка идентификатора SW SBL1 в little endian</returns>
        internal string SaharaCommand7()
        {
            if (File.Exists("commandop07.bin"))
            {
                StringBuilder SC7 = new StringBuilder();
                string strbyte = BitConverter.ToString(File.ReadAllBytes("commandop07.bin")).Replace("-", "");
                byte count = (byte)strbyte.Length;
                //Читаем с конца в начало
                while (count > 0)
                {
                    SC7.Append(strbyte.Substring(count - 2, 2));
                    count -= 2;
                }
                File.Delete("commandop07.bin");
                return SC7.ToString();
            }
            else return LocRes.GetString("file") + " commandop07.bin " + LocRes.GetString("hex_not") + '\u0020' + LocRes.GetString("hex_processed");
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
                    StartLBA = LocRes.GetString("not_gpt_header")
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
        /// Создаём файл чтения/записи
        /// </summary>
        /// <param name="reading">Чтение - true, запись - false</param>
        /// <param name="SECTOR_SIZE">Размер сектора (512 или 4096)</param>
        /// <param name="filename">Имя итогового файла чтения/записи (*.bin)</param>
        /// <param name="physical_partition">Номер диска</param>
        /// <param name="HexStartLBA">Хекс стартового адреса сектора</param>
        /// <param name="HexEndLBA">Хекс последнего адреса сектора</param>
        internal void FhXmltoRW(bool reading, string SECTOR_SIZE, string filename, string physical_partition, string HexStartLBA, string HexEndLBA)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldecl;
            StringBuilder xmlloadargs = new StringBuilder("<data>");
            xmldecl = doc.CreateXmlDeclaration("1.0", string.Empty, null);
            uint blocks_count = Convert.ToUInt32(HexEndLBA, 16) - Convert.ToUInt32(HexStartLBA, 16) + 1;
            if (reading) xmlloadargs.Append("<read"); //Готовим файл для чтения
            else xmlloadargs.Append("<program"); //Готовим файл для записи
            xmlloadargs.Append(string.Format(" SECTOR_SIZE_IN_BYTES=\"{0}\" filename=\"{1}\" num_partition_sectors=\"{2}\" physical_partition_number=\"{3}\" start_sector=\"{4}\"/>",
                SECTOR_SIZE, filename, blocks_count.ToString(), physical_partition, Convert.ToUInt32(HexStartLBA, 16).ToString()));
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
                MessageBox.Show(ex.Message, LocRes.GetString("er_func_xml"));
            }
        }

        /// <summary>
        /// Удаляем некорректные символы из строки в зависимости от системы исчисления
        /// </summary>
        /// <param name="value">Исходное значение анализируемой строки</param>
        /// <param name="sys_count">Система исчисления (10, 16)</param>
        /// <returns>Возвращаем строку с изменёнными или удалёнными некорректными символами</returns>
        internal string DelUnknownChars(string value, System_Count sys_count)
        {
            StringBuilder GoodStr = new StringBuilder(value);
            char[] Dex_str = { '\u0030', '\u0031', '\u0032', '\u0033', '\u0034', '\u0035', '\u0036', '\u0037', '\u0038', '\u0039' };
            for (int i = 0; i < GoodStr.Length; i++)
            {
                if (sys_count == System_Count.dex)
                {
                    if (!Dex_str.Contains(GoodStr[i])) GoodStr.Remove(i, 1);
                }
                else
                {
                    switch (GoodStr[i])
                    {
                        case '\u0030': break;
                        case '\u0031': break;
                        case '\u0032': break;
                        case '\u0033': break;
                        case '\u0034': break;
                        case '\u0035': break;
                        case '\u0036': break;
                        case '\u0037': break;
                        case '\u0038': break;
                        case '\u0039': break;
                        case '\u0041': break; //A
                        case '\u0061': //a
                            GoodStr.Replace('\u0061', '\u0041');
                            break;
                        case '\u0424': //Ф
                            GoodStr.Replace('\u0424', '\u0041');
                            break;
                        case '\u0444': //ф
                            GoodStr.Replace('\u0444', '\u0041');
                            break;
                        case '\u0042': break; //B
                        case '\u0062': //b
                            GoodStr.Replace('\u0062', '\u0042');
                            break;
                        case '\u0418': //И
                            GoodStr.Replace('\u0418', '\u0042');
                            break;
                        case '\u0438': //и
                            GoodStr.Replace('\u0438', '\u0042');
                            break;
                        case '\u0043': break; //C
                        case '\u0063': //c
                            GoodStr.Replace('\u0063', '\u0043');
                            break;
                        case '\u0421': //С
                            GoodStr.Replace('\u0421', '\u0043');
                            break;
                        case '\u0441': //с
                            GoodStr.Replace('\u0441', '\u0043');
                            break;
                        case '\u0044': break; //D
                        case '\u0064': //d
                            GoodStr.Replace('\u0064', '\u0044');
                            break;
                        case '\u0412': //В
                            GoodStr.Replace('\u0412', '\u0044');
                            break;
                        case '\u0432': //в
                            GoodStr.Replace('\u0432', '\u0044');
                            break;
                        case '\u0045': break; //E
                        case '\u0065': //e
                            GoodStr.Replace('\u0065', '\u0045');
                            break;
                        case '\u0423': //У
                            GoodStr.Replace('\u0423', '\u0045');
                            break;
                        case '\u0443': //у
                            GoodStr.Replace('\u0443', '\u0045');
                            break;
                        case '\u0046': break; //F
                        case '\u0066': //f
                            GoodStr.Replace('\u0066', '\u0046');
                            break;
                        case '\u0410': //А
                            GoodStr.Replace('\u0410', '\u0046');
                            break;
                        case '\u0430': //а
                            GoodStr.Replace('\u0430', '\u0046');
                            break;
                        default:
                            GoodStr.Remove(i, 1);
                            break;
                    }
                }
            }
            return GoodStr.ToString();
        }

        /// <summary>
        /// Преобразовываем строку байт в список символов в байтах и ASCII
        /// </summary>
        /// <param name="charbyte">Массив байт, считанных из шапки прошивки</param>
        /// <param name="all_read_chars">Количество байт для анализа</param>
        /// <param name="chars_to_string">Количество символов в строке для разбора массива</param>
        /// <returns></returns>
        internal string ByEight(byte[] charbyte, int chars_to_string)
        {
            int all_read_chars = charbyte.Length;
            int full_str = ((all_read_chars / chars_to_string) * (chars_to_string * 5 + 2)) + ((chars_to_string * 5) + 2);
            StringBuilder str_by_eight = new StringBuilder(full_str);
            int count_char_place = 0;
            int count_full_char_string = 0;
            for (int i = 0; i < all_read_chars; i++)
            {
                if (str_by_eight.Length < (count_char_place * 3) + count_full_char_string)
                {
                    str_by_eight.Append(string.Format("{0:X2} ", charbyte[i]));
                }
                else
                {
                    str_by_eight.Insert((count_char_place * 3) + count_full_char_string, string.Format("{0:X2} ", charbyte[i]));
                }
                char prt_char = (char)charbyte[i];
                if (char.IsWhiteSpace(prt_char) || char.IsControl(prt_char))
                {
                    prt_char = '.'; // Заменяем нечитаемые символы точкой
                }
                str_by_eight.Append(string.Format(" {0}", prt_char));
                count_char_place++;
                if (count_char_place == chars_to_string) // Достигли конца полной строки
                {
                    str_by_eight.Insert(count_char_place * 3 + count_full_char_string, "\t|");
                    count_char_place = 0;
                    count_full_char_string += chars_to_string * 5 + 2; // 24 - hex+" ", 2 - "tab|", 16 - " "+ascii - это для 8 знаков в строке
                }
            }
            if (count_char_place > 0) // Последняя неполная строка. Добиваем пробелами до полной.
            {
                for (int i = count_char_place; i < chars_to_string; i++)
                {
                    str_by_eight.Insert(i * 3 + count_full_char_string, "   ");
                }
                str_by_eight.Insert(chars_to_string * 3 + count_full_char_string, "\t|");
            }
            while ((count_full_char_string / chars_to_string * 5 + 2) > 1) // Расставляем переносы для удобства чтения
            {
                //count_string++;
                str_by_eight.Insert(count_full_char_string, Environment.NewLine);
                count_full_char_string -= chars_to_string * 5 + 2;
            }
            return str_by_eight.ToString();
        }

        /// <summary>
        /// Расшифровываем из потока памяти массив байт синхронно ключом и выводим результат массивом байт.
        /// </summary>
        /// <param name="value">Массив зашифрованных байт</param>
        /// <param name="key">Код шифрования в виде массива байт</param>
        /// <returns>Массив байт в расшифрованном виде</returns>
        internal byte[] Decoder(byte[] value, byte[] key)
        {
            MemoryStream mStream = new MemoryStream(value);
            DES DESalg = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Key = key,
                Padding = PaddingMode.None
            };
            ICryptoTransform transform = DESalg.CreateDecryptor();
            byte[] decode_bytes = new byte[value.Length];
            CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Read);
            try
            {
                int db = cStream.Read(decode_bytes, 0, decode_bytes.Length);
                if (db > 0) return decode_bytes;
                else return null;
            }
            catch (CryptographicException Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Парсим строковый ответ в массив байт
        /// </summary>
        /// <param name="outputres">Вывод строки отчёта</param>
        /// <param name="bytescontrol">Количество символов (байт)</param>
        /// <returns>Массив байт для записи в файл</returns>
        internal byte[] Parse_peek_res(string outputres, uint bytescontrol)
        {
            byte[] PPR = new byte[bytescontrol];
            string pattern = "0x.{2} "; //Бинарный признак сертификата с его длиной в середине (3082-4 знака-3082)
            MatchCollection matchs = Regex.Matches(outputres, pattern);
            for (int i = 0; i < matchs.Count; i++)
            {
                PPR[i] = StringToByteArray(matchs[i].Value.Substring(2, 2))[0];
            }
            return PPR;
        }

        /// <summary>
        /// Парсим ответ лодыря по проценту загрузки
        /// </summary>
        /// <param name="outputstr"></param>
        /// <returns></returns>
        internal int ProcessPersent(string outputstr)
        {
            int persentcomplited = 0;
            if (!string.IsNullOrEmpty(outputstr) && outputstr.Contains("percent files transferred"))
            {
                string intoutput = outputstr.Remove(outputstr.LastIndexOf('\u0025') - 3); //Обрезали конец до целых по знаку %
                persentcomplited = Convert.ToInt32(intoutput.Substring(intoutput.LastIndexOf('\u0020'))); //Обрезали спереди по пробелу
            }
            return persentcomplited;
        }

        /// <summary>
        /// Разбираем свойства отдельно взятого устройства.
        /// </summary>
        /// <param name="DevProps"></param>
        /// <returns>Возвращаем массив строк: 0-ком-порт, 1-его описание</returns>
        internal string[] ParsingPortsProps(ManagementObject DevProps)
        {
            string[] portprops = new string[2] { string.Empty, string.Empty };
            string status = string.Empty;
            if (!string.IsNullOrEmpty(DevProps.Properties["Status"].Value.ToString())) status = DevProps.Properties["Status"].Value.ToString();
            switch (status)
            {
                case "Error": //Ошибка. Смотрим номер
                    if ((uint)DevProps.Properties["ConfigManagerErrorCode"].Value == 28) portprops[1] = LocRes.GetString("mb_body_port_driver");
                    else portprops[1] = LocRes.GetString("mb_body_dev_mist") + '\u0020' + DevProps.Properties["ConfigManagerErrorCode"].Value.ToString();
                    break;
                case "OK": //Нормально, парсим
                    string portname = string.Empty;
                    if (!string.IsNullOrEmpty(DevProps.Properties["Description"].Value.ToString())) portprops[1] = DevProps.Properties["Description"].Value.ToString();
                    if (!string.IsNullOrEmpty(DevProps.Properties["Caption"].Value.ToString())) portname = DevProps.Properties["Caption"].Value.ToString();
                    if (portname.Length > portprops[1].Length) portprops[0] = portname.Substring(portprops[1].Length).Trim('(', ')', ' ');
                    break;
                default:
                    break;
            }
            return portprops;
        }
    }
}

