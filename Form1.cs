using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Text;
using FirehoseFinder.Properties;
using System.Diagnostics;
using SharpAdbClient;
using System.Threading;
using Microsoft.Win32;
using Telegram.Bot;
using System.Threading.Tasks;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        Func func = new Func(); // Подключили функции
        Guide guide = new Guide();
        StringBuilder sent_issue = new StringBuilder(string.Empty); //Отправлять на Гитхаб сообщение об изменении Справочника
        bool waitSahara = false; //Ждём ли мы автоперезагрузку с получением ID Sahara

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public Formfhf()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отлавливаем подключение USB устройств. Перезапускаем скан доступных портов
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);
            }
            catch (TargetInvocationException)
            {
            }
            try
            {
                switch (m.WParam.ToInt32())
                {
                    case 0x8000://новое usb подключено
                        CheckListPorts();
                        break;
                    case 0x0007: // Любое изменение конфигурации оборудования
                        CheckListPorts();
                        break;
                    default:
                        break;
                }
            }
            catch (OverflowException)
            {
            }
        }

        /// <summary>
        /// Выполнение инструкций при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_Load(object sender, EventArgs e)
        {
            this.forFilterTableAdapter.Fill(this.qcom_phonesDataSet.ForFilter);
            richTextBox_about.Text = Resources.String_about + Environment.NewLine +
                "Ссылка на базовую тему <<Общие принципы восстановления загрузчиков на Qualcomm | HS - USB QDLoader 9008, HS - USB Diagnostics 9006, QHUSB_DLOAD и т.д.>>: " +
                Resources.String_theme_link + Environment.NewLine
                + Environment.NewLine +
                "Версия сборки: " + Assembly.GetExecutingAssembly().GetName().Version + Environment.NewLine
                + Environment.NewLine +
                "Часто задаваемые вопросы: " + Environment.NewLine + Resources.String_faq1 +
                Environment.NewLine + Environment.NewLine + Resources.String_faq2 +
                Environment.NewLine + Environment.NewLine + Resources.String_faq3 +
                Environment.NewLine + Environment.NewLine +
                "Есть вопросы, предложения, замечания? Открывайте ишью (вопрос) на Гитхабе: " + Resources.String_issues;
            toolTip1.SetToolTip(button_path, "Укажите путь к коллекции firehose");
            toolTip1.SetToolTip(button_useSahara_fhf, "При нажатии произойдёт переименование выбранного файла по идентификаторам, указанным в таблице");
            CheckListPorts(); //Вносим в листвью список активных портов
        }

        /// <summary>
        /// При закрытии приложения подчищаем за собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("adb.exe")) File.Delete("adb.exe");
            if (File.Exists("QSaharaServer.exe")) File.Delete("QSaharaServer.exe");
            if (File.Exists("fh_loader.exe")) File.Delete("fh_loader.exe");
            if (File.Exists("commandop02.bin")) File.Delete("commandop02.bin");
            if (File.Exists("commandop03.bin")) File.Delete("commandop03.bin");
            if (File.Exists("commandop07.bin")) File.Delete("commandop07.bin");
            if (File.Exists("port_trace.txt")) File.Delete("port_trace.txt");
            if (!string.IsNullOrEmpty(sent_issue.ToString())) Sent_Issue(sent_issue.ToString());
        }

        #region Функции команд контролов закладки Работа с файлами

        /// <summary>
        /// Выбираем директорию для работы с программерами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_path_Click(object sender, EventArgs e)
        {
            textBox_hwid.BackColor = Color.Empty;
            textBox_oemid.BackColor = Color.Empty;
            textBox_modelid.BackColor = Color.Empty;
            textBox_oemhash.BackColor = Color.Empty;
            dataGridView_final.Rows.Clear();
            button_useSahara_fhf.Visible = false;
            toolStripStatusLabel_filescompleted.Text = string.Empty;
            toolStripStatusLabel_vol.Text = string.Empty;
            toolStripProgressBar_filescompleted.Value = 0;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_path.Text = folderBrowserDialog1.SelectedPath;
                Check_Unread_Files();
            }
        }

        /// <summary>
        /// Выбираем программер для работы с устройством
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button__useSahara_fhf_Click(object sender, EventArgs e)
        {
            label_Sahara_fhf.Text = button_path.Text + "\\" + dataGridView_final.SelectedRows[0].Cells[1].Value.ToString();
            tabControl1.SelectedTab = tabPage_phone;
        }

        /// <summary>
        /// Ставим галку на выбранной строке с программером
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_final_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!dataGridView_final.Rows[e.RowIndex].ReadOnly)
                {
                    if (Convert.ToBoolean(dataGridView_final["Column_Sel", e.RowIndex].Value))
                    {
                        dataGridView_final["Column_Sel", e.RowIndex].Value = false;
                        button_useSahara_fhf.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView_final.Rows.Count; i++)
                        {
                            dataGridView_final["Column_Sel", i].Value = false;
                        }
                        dataGridView_final["Column_Sel", e.RowIndex].Value = true;
                        button_useSahara_fhf.Visible = true;
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Стоит сначала выбрать рабочую директорию." + Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// Выводим подробную информацию в отдельное окно с копированием в буфер обмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_final_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataGridView_final.Rows[e.RowIndex].ReadOnly)
            {
                DialogResult dr = MessageBox.Show(dataGridView_final["Column_Full", e.RowIndex].Value.ToString(), "Сохранить данные в буфер обмена?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(dataGridView_final["Column_Full", e.RowIndex].Value.ToString());
                }
            }
        }

        /// <summary>
        /// Побайтное чтение файла в параллельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Read_File_DoWork(object sender, DoWorkEventArgs e)
        {
            KeyValuePair<string, long> FileToRead = (KeyValuePair<string, long>)e.Argument;
            int len = Convert.ToInt32(FileToRead.Value);
            if (len > 12288) len = 12288; //Нам нужно только до 0х3000, где есть первые три сертификата
            StringBuilder dumptext = new StringBuilder(len);
            byte[] chunk = new byte[len];
            using (var stream = File.OpenRead(FileToRead.Key))
            {
                int byteschunk = stream.Read(chunk, 0, len);
                for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, String.Format("{0:X2}", (int)chunk[i]));
            }
            e.Result = dumptext.ToString();
        }

        /// <summary>
        /// Всё, что нужно доделать после завершения длительной операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Read_File_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) MessageBox.Show(e.Error.Message);
            else
            {
                string dumpfile = e.Result.ToString();
                byte curfilerating = 0;
                int Currnum = dataGridView_final.Rows.Count - 1; //Номер последней, "пустой" строки грида
                switch (dumpfile.Substring(0, 8))
                {
                    case "7F454C46": //ELF
                        curfilerating++;
                        break;
                    case "7F454C45": //не совсем ELF
                        curfilerating++;
                        dataGridView_final["Column_Name", Currnum].Style.BackColor = Color.Yellow;
                        dataGridView_final["Column_Name", Currnum].ToolTipText = "Файл не является ELF!";
                        break;
                    default: //совсем не ELF
                        break;
                }
                if (curfilerating != 0) //Увеличиваем рейтинг совпадениями поиска файла
                {
                    dataGridView_final["Column_rate", Currnum].Value = curfilerating + Rating(dumpfile, Currnum);
                    dataGridView_final["Column_rate", Currnum].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else //Рейтинг 0 не обрабатываем
                {
                    dataGridView_final.Rows[Currnum].ReadOnly = true;
                    dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.LightGray;
                }
                dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);
                Check_Unread_Files(); //Проверяем, не осталось ли необработанных файлов
            }
        }
        #endregion

        #region Функции самостоятельных команд закладки Работа с файлами
        /// <summary>
        /// Проверка заполнения грида прочтёнными файлами и запуск параллельного потока для непрочтённых
        /// </summary>
        private void Check_Unread_Files()
        {
            button_path.Enabled = false;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text); //Полный путь с именем файла и его объём для каждого файла в выбраной папке
            int currreadfiles = dataGridView_final.Rows.Count;
            int totalreadfiles = Resfiles.Count;
            toolStripStatusLabel_filescompleted.Text = "Обработано " + currreadfiles.ToString() + " файлов из " + totalreadfiles.ToString();
            //Либо 0, либо чтение всех файлов закончено, в грид всё добавлено - уходим
            if (currreadfiles == totalreadfiles)
            {
                button_path.Enabled = true;
                toolStripStatusLabel_vol.Text = string.Empty;
                toolStripProgressBar_filescompleted.Value = 0;
                return;
            }
            //Есть необработанные файлы - обрабатываем первый отсутствующий в цикле
            List<string> ReadedFiles = new List<string>(); //Создаём массив под список уже обработанных файлов
            //Заполняем массив короткими именами файлов из грида (если они есть)
            for (int i = 0; i < currreadfiles; i++) ReadedFiles.Add(dataGridView_final["Column_Name", i].Value.ToString().Trim());
            toolStripProgressBar_filescompleted.Value = currreadfiles * 100 / totalreadfiles; //Количество обработанных файлов в прогрессбаре
            dataGridView_final.Rows.Add();
            foreach (KeyValuePair<string, long> unreadfiles in Resfiles)
            {
                string shortfilename = Path.GetFileName(unreadfiles.Key); //Получили название файла
                if (!ReadedFiles.Contains(shortfilename))
                {
                    toolStripStatusLabel_vol.Text = "Сейчас обрабатывается файл - " + shortfilename;
                    statusStrip_firehose.Refresh();
                    dataGridView_final[1, currreadfiles].Value = shortfilename;
                    backgroundWorker_Read_File.RunWorkerAsync(unreadfiles); //Запускаем цикл обработки отдельно каждого необработанного файла в папке
                    break;
                }
            }
        }

        /// <summary>
        /// Список проверок для увеличения рейтинга файла и заполнения грида идентификаторами
        /// </summary>
        /// <param name="dumpfile">Строковый массив байт обрабатываемого файла</param>
        /// <param name="Currnum">Номер текущей строки грида для добавления идентификаторов</param>
        private byte Rating(string dumpfile, int Currnum)
        {
            byte gross = 0;
            string[] id = func.IDs(dumpfile);
            string oemhash;
            string sw_type = string.Empty;
            if (id[3].Length < 64) oemhash = id[3];
            else oemhash = id[3].Substring(56);
            dataGridView_final["Column_id", Currnum].Value = id[0] + "-" + id[1] + "-" + id[2] + "-" + oemhash + "-" + id[4] + id[5];
            if (guide.SW_ID_type.ContainsKey(id[4])) sw_type = guide.SW_ID_type[id[4]];
            dataGridView_final["Column_SW_type", Currnum].Value = sw_type;
            dataGridView_final["Column_Full", Currnum].Value = "HW_ID (процессор) - " + id[0] + Environment.NewLine +
                "OEM_ID (производитель) - " + id[1] + Environment.NewLine +
                "MODEL_ID (модель) - " + id[2] + Environment.NewLine +
                "OEM_HASH (хеш корневого сертификата) - " + id[3] + Environment.NewLine +
                "SW_ID (тип программы (версия)) - " + id[4] + id[5] + " - " + sw_type;
            //!!!!Добавить проверку на все процессоры, в т.ч. и переходные по единому ID!!!!
            if (textBox_hwid.Text.Equals(id[0])) //Процессор такой же
            {
                textBox_hwid.BackColor = Color.LawnGreen;
                gross += 2;
            }
            if (textBox_oemid.Text.Equals(id[1])) // Производитель один и тот же
            {
                textBox_oemid.BackColor = Color.LawnGreen;
                gross += 2;
            }
            if (textBox_modelid.Text.Equals(id[2])) // Модели равны
            {
                textBox_modelid.BackColor = Color.LawnGreen;
                gross++;
            }
            if (id[3].Length >= 64)
            {
                if (textBox_oemhash.Text.Equals(id[3].Substring(0, 64))) // Хеши равны
                {
                    textBox_oemhash.BackColor = Color.LawnGreen;
                    gross += 2;
                }
            }
            if (id[4].Equals("3")) gross += 2; // SWID начинается с 3 (альтернативная проверка: есть fh@0x%08 - Contains("6668403078253038"))
            return gross;
        }
        #endregion

        #region Функции команд контролов закладки Работа с устройством

        /// <summary>
        /// Стартуем сервер ADB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ADB_start_Click(object sender, EventArgs e)
        {
            ADB_Check();
        }

        /// <summary>
        /// Останавливаем сервер ADB, всё очищаем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ADB_clear_Click(object sender, EventArgs e)
        {
            StopAdb();
        }

        /// <summary>
        /// При выборе команды на исполнение делаем доступным кнопку старта выполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_ADB_commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_ADB_comstart.Enabled = true;
            if (comboBox_ADB_commands.SelectedIndex == 2) textBox_ADB_commandstring.Visible = true;
            else textBox_ADB_commandstring.Visible = false;
        }

        /// <summary>
        /// Запуск на выполнение выбранной в комбобоксе команды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ADB_comstart_Click(object sender, EventArgs e)
        {
            AdbClient client = new AdbClient();
            var receiver = new ConsoleOutputReceiver();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            var device = devices[0];
            string Com_String = textBox_ADB_commandstring.Text;
            try
            {
                switch (comboBox_ADB_commands.SelectedIndex)
                {
                    case 0:
                        textBox_ADB.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                        client.Reboot("edl", device);
                        Thread.Sleep(1000);
                        StopAdb();
                        break;
                    case 1:
                        client.ExecuteRemoteCommand("getprop", device, receiver);
                        textBox_ADB.AppendText(receiver.ToString() + Environment.NewLine);
                        break;
                    case 2:
                        if (!string.IsNullOrEmpty(Com_String)) Adb_Comm_String(Com_String);
                        break;
                    default:
                        break;
                }
            }
            catch (SharpAdbClient.Exceptions.AdbException ex)
            {
                textBox_ADB.AppendText(ex.AdbError + Environment.NewLine);
            }
            button_ADB_comstart.Enabled = false;
        }

        /// <summary>
        /// Запуск выполнения команды по нажатию клавиши Ввод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_ADB_commandstring_KeyUp(object sender, KeyEventArgs e)
        {
            string Com_String = textBox_ADB_commandstring.Text;
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(Com_String)) Adb_Comm_String(Com_String);
        }

        /// <summary>
        /// При наличии порта с аварийным устройством активируем кнопку запроса идентификаторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_comport_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                serialPort1.PortName = e.Item.Text;
                button_Sahara_Ids.Enabled = true;
                if (waitSahara)
                {
                    GetSaharaIDs();
                    button_Sahara_Ids.Enabled = false;
                }
            }
            else
            {
                button_Sahara_Ids.Enabled = false;
            }
        }

        /// <summary>
        /// Получаем идентификаторы устройства, переносим их на вкладку Работа с файлами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sahara_Ids_Click(object sender, EventArgs e)
        {
            button_Sahara_Ids.Enabled = false;
            GetSaharaIDs();
        }

        /// <summary>
        /// Перегружаем устройство из режима 9008 в нормальное состояние при помощи команды программера reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sahara_Reset_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        if (!File.Exists("QSaharaServer.exe"))
                        {
                            byte[] LocalQSS = Resources.QSaharaServer;
                            FileStream fs = new FileStream("QSaharaServer.exe", System.IO.FileMode.Create);
                            fs.Write(LocalQSS, 0, LocalQSS.Length);
                            fs.Close();
                        }
                        process.StartInfo.FileName = "QSaharaServer.exe";
                        process.StartInfo.Arguments = "-p \\\\.\\" + serialPort1.PortName + " -s 13:" + label_Sahara_fhf.Text;
                        break;
                    case 1:
                        if (!File.Exists("fh_loader.exe"))
                        {
                            byte[] LocalFHL = Resources.fh_loader;
                            FileStream fs = new FileStream("fh_loader.exe", System.IO.FileMode.Create);
                            fs.Write(LocalFHL, 0, LocalFHL.Length);
                            fs.Close();
                        }
                        process.StartInfo.FileName = "powershell";
                        process.StartInfo.Arguments = ".\\fh_loader --port=\\\\.\\" + serialPort1.PortName + " --loglevel=0 --dontsorttags --reset";
                        break;
                    default:
                        break;
                }
                process.Start();
                StreamReader reader = process.StandardOutput;
                textBox_ADB.AppendText(reader.ReadToEnd());
                process.WaitForExit();
            }
            process.Close();
        }

        /// <summary>
        /// Выбрали программер - активировали перезагрузку устройства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Sahara_fhf_TextChanged(object sender, EventArgs e)
        {
            //button_Sahara_Reset.Enabled = true;
        }
        #endregion

        #region Функции самостоятельных команд закладки Работа с устройством

        /// <summary>
        /// Останавливаем сервер, очищаем поле, восстанавливаем доступы к контролам
        /// </summary>
        private void StopAdb()
        {
            textBox_ADB.Text = "Сеанс ADB завершён" + Environment.NewLine;
            AdbClient client = new AdbClient();
            client.KillAdb();
            button_ADB_start.Enabled = true;
            comboBox_ADB_commands.Enabled = false;
            button_ADB_comstart.Enabled = false;
        }

        /// <summary>
        /// Выполнение ADB команды из командной строки
        /// </summary>
        /// <param name="Com_String"></param>
        private void Adb_Comm_String(string Com_String)
        {
            AdbClient client = new AdbClient();
            var receiver = new ConsoleOutputReceiver();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            var device = devices[0];
            textBox_ADB.AppendText(Com_String + Environment.NewLine);
            textBox_ADB_commandstring.Text = string.Empty;
            try
            {
                client.ExecuteRemoteCommand(Com_String, device, receiver);
                textBox_ADB.AppendText(receiver.ToString() + Environment.NewLine);
            }
            catch (SharpAdbClient.Exceptions.AdbException ex)
            {
                textBox_ADB.AppendText(ex.AdbError + Environment.NewLine);
            }
        }

        private void CheckListPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            if (listView_comport.Items.Count > 0) listView_comport.Items.Clear();
            if (ports.Length == 0) return;
            for (int item = 0; item < ports.Length; item++)
            {
                listView_comport.Items.Add(ports[item]);
                try
                {
                    RegistryKey rk = Registry.LocalMachine; // Зашли в локал машин
                    RegistryKey openRK = rk.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\USB"); // Открыли на чтение папку USB устройств
                    string[] USBDevices = openRK.GetSubKeyNames();  // Получили имена всех, когда-либо подключаемых устройств
                    foreach (string stepOne in USBDevices)  // Для каждого производителя устройства проверяем подпапки, т.к. бывает несколько устройств на одном ВИД/ПИД
                    {
                        RegistryKey stepOneReg = openRK.OpenSubKey(stepOne);    // Открываем каждого производителя на чтение
                        string[] stepTwo = stepOneReg.GetSubKeyNames(); // Получили список всех устройств для каждого производителя
                        foreach (string friendName in stepTwo)
                        {
                            RegistryKey friendRegName = stepOneReg.OpenSubKey(friendName);
                            string[] fn = friendRegName.GetValueNames();
                            foreach (string currentName in fn)
                            {
                                if (currentName == "FriendlyName")
                                {
                                    object frn = friendRegName.GetValue("FriendlyName");
                                    RegistryKey devPar = friendRegName.OpenSubKey("Device Parameters");
                                    object dp = devPar.GetValue("PortName");
                                    if (dp != null && listView_comport.Items[item].Text.Equals(dp.ToString()))
                                    {
                                        listView_comport.Items[item].SubItems.Add(frn.ToString());
                                        if (stepOne.Equals("VID_05C6&PID_9008")) listView_comport.Items[item].Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Внимание! Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Функции команд контролов закладки Справочник

        /// <summary>
        /// Права на идею Справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel_copyrights_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://4pda.ru/forum/index.php?showuser=4712700");
        }

        /// <summary>
        /// Пользователь вручную выбрал устройство из Справочника для поиска по идентификаторам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForFilterDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Заполняем контролы для поиска шланга
            textBox_hwid.Text = forFilterDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            textBox_oemid.Text = forFilterDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox_modelid.Text = forFilterDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox_oemhash.Text = forFilterDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            label_tm.Text = forFilterDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            label_model.Text = forFilterDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            toolStripStatusLabel_guide.Text = string.Empty;
            //Переходим на вкладку поиска
            dataGridView_final.Rows.Clear();
            tabControl1.SelectedTab = tabPage_firehose;
        }

        /// <summary>
        /// Включаем возможность выбора данных из Справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_manualfilter_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_manualfilter.Checked)
            {
                forFilterDataGridView.Enabled = true;
                button_findIDs.Enabled = false;
            }
        }

        /// <summary>
        /// Отключаем Справочник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_autofilter_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_autofilter.Checked)
            {
                forFilterDataGridView.Enabled = false;
                button_findIDs.Enabled = true;
            }
        }

        /// <summary>
        /// Набираем данные для фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForFilterDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Меняем название столбца на значение ячейки для применения фильтра
                try
                {
                    forFilterDataGridView.Columns[e.ColumnIndex].HeaderText = forFilterDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
                    forFilterDataGridView.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.GreenYellow;
                    toolStripStatusLabel_guide.Text = "Отобрано " + MakeFilter().ToString() + " записей";
                }
                catch (ArgumentOutOfRangeException)
                {
                    toolStripStatusLabel_guide.Text = "Кликнули вне области таблицы";
                }
            }
        }

        /// <summary>
        /// Сбрасываем фильтр с названия столбца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForFilterDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Меняем название столбца на значение ячейки для применения фильтра 
                forFilterDataGridView.Columns[e.ColumnIndex].HeaderText = forFilterDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                forFilterDataGridView.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.Empty;
                toolStripStatusLabel_guide.Text = "Отобрано " + MakeFilter().ToString() + " записей";
            }
        }

        /// <summary>
        /// Автозапуск получения идентификаторов и сверки их со Справочником
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_findIDs_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Нажимая \"Ок\", вы соглашаетесь с автоматическим получением программой идентификаторов устройства." + Environment.NewLine +
                "Никакая другая (персональная) информация с аппарата скопирована не будет. Аппарат будет автоматически перегружен в аварийный режим при условии, что он поддерживает такой функционал на программном уровне." + Environment.NewLine +
                "После получения идентификаторов данные будут сверены со Справочником ID. Если полученные в автоматическом режиме данные будут отсутствовать или отличаться от данных Справочника, то разработчикам будет отправлено сообщение о включении/редактировании Справочника после завершения работы программы.",
                "Подключите устройство в обычном режиме (в режиме зарядки)!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                tabControl1.SelectedTab = tabPage_phone;
                if (listView_comport.CheckedItems.Count > 0)
                {
                    GetSaharaIDs();
                    return;
                }
                if (!ADB_Check()) return;
                GetADBIDs();
                waitSahara = true; //Ждём подключения в аварийном режиме
            }
            else radioButton_manualfilter.Checked = true;
        }

        /// <summary>
        /// Если нужно сохранить лог работы автоопределения идентификаторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Log_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Log.Checked)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    label_log.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            else label_log.Text = string.Empty;
        }

        #endregion

        #region Функции самостоятельных команд Справочника

        /// <summary>
        /// Подготавливаем фильтр для грида Справочника
        /// </summary>
        private int MakeFilter()
        {
            StringBuilder fullfilter = new StringBuilder(string.Empty);
            int countfilters = 0;
            foreach (DataGridViewColumn ColoumnHeaderText in forFilterDataGridView.Columns)
            {
                if (ColoumnHeaderText.HeaderText != ColoumnHeaderText.DataPropertyName)
                {
                    //Применяем фильтр
                    if (countfilters > 0) fullfilter.Append(" AND ");
                    fullfilter.Append(string.Format("{0} LIKE '{1}'", ColoumnHeaderText.DataPropertyName, ColoumnHeaderText.HeaderText));
                    countfilters++;
                }
            }
            forFilterBindingSource.Filter = fullfilter.ToString();
            return forFilterDataGridView.Rows.Count;
        }

        /// <summary>
        /// Проверяем корректность подключения устройства через запуск ADB
        /// </summary>
        /// <returns>true - всё хорошо, false - есть ошибки</returns>
        private bool ADB_Check()
        {
            //Создаём ADB из ресурсов в рабочую папку, если его там ещё нет
            if (!File.Exists("adb.exe"))
            {
                byte[] LocalADB = Resources.adb;
                FileStream fs = new FileStream("adb.exe", System.IO.FileMode.Create);
                fs.Write(LocalADB, 0, LocalADB.Length);
                fs.Close();
            }
            //Стартуем сервер
            textBox_ADB.AppendText("Запускаем сервер ADB ..." + Environment.NewLine);
            AdbServer server = new AdbServer();
            var result = server.StartServer("adb.exe", restartServerIfNewer: false);
            //Подключаем клиента (устройства)
            AdbClient client = new AdbClient();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            textBox_ADB.AppendText(result.ToString() + Environment.NewLine);
            button_ADB_start.Enabled = false;
            foreach (var device in devices) textBox_ADB.AppendText("Подключено устройство: " + device + Environment.NewLine);
            if (devices.Count > 1)
            {
                textBox_ADB.AppendText("Подключено более одного андройд-устройства. Пожалуйста, оставьте подключённым только то устройство, с которым планируется дальнейшая работа." + Environment.NewLine);
                return false;
            }
            else if (devices.Count == 0)
            {
                textBox_ADB.AppendText("Подключённых устройств не найдено. Пожалуйста, проверьте в настройках устройства разрешена ли \"Отладка по USB\" в разделе \"Система\" - \"Для разработчиков\"" + Environment.NewLine);
                return false;
            }
            else
            {
                comboBox_ADB_commands.Enabled = true;
                return true;
            }
        }

        /// <summary>
        /// Получаем пакетно идентификаторы и сверяем их со справочником
        /// </summary>
        private void GetADBIDs()
        {
            AdbClient client = new AdbClient();
            var receiver = new ConsoleOutputReceiver();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            var device = devices[0];
            List<string> adbcommands = new List<string>() {
                "getprop | grep ro.product.manufacturer",
                "getprop | grep ro.product.model"};
            string[] results = new string[adbcommands.Count];
            try
            {
                for (int i = 0; i < adbcommands.Count; i++)
                {
                    client.ExecuteRemoteCommand(adbcommands[i], device, receiver);
                    string[] adbstr = receiver.ToString().Split('[');
                    foreach (string item in adbstr)
                    {
                        if (!item.StartsWith("ro.product.m"))
                        {
                            if (item.Contains("]")) results[i] = item.Remove(item.IndexOf(']'));
                        }
                    }
                    if (results[i] == null) results[i] = string.Empty;
                    receiver.Flush();
                }
                label_tm.Text = results[0];
                label_model.Text = results[1];
                textBox_ADB.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                client.Reboot("edl", device);
            }
            catch (SharpAdbClient.Exceptions.AdbException ex)
            {
                textBox_ADB.AppendText(ex.AdbError + Environment.NewLine);
            }
            Thread.Sleep(1000);
            StopAdb();
        }

        /// <summary>
        /// Получаем идентификаторы из Сахары
        /// </summary>
        private void GetSaharaIDs()
        {
            //Создаём SaharaServer из ресурсов в рабочую папку, если его там ещё нет
            if (!File.Exists("QSaharaServer.exe"))
            {
                byte[] LocalQSS = Resources.QSaharaServer;
                FileStream fs = new FileStream("QSaharaServer.exe", System.IO.FileMode.Create);
                fs.Write(LocalQSS, 0, LocalQSS.Length);
                fs.Close();
            }
            //Выполняем запрос HWID-OEMID (command02)
            Process process = new Process();
            process.StartInfo.FileName = "QSaharaServer.exe";
            process.StartInfo.Arguments = "-p \\\\.\\" + serialPort1.PortName + " -c 2 -c 3 -c 7";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();
            textBox_ADB.AppendText(output);
            process.WaitForExit();
            process.Close();
            //Обрабатываем запрос идентификаторов
            string HWOEMIDs = func.SaharaCommand2();
            if (HWOEMIDs.Length == 16)
            {
                textBox_hwid.Text = HWOEMIDs.Substring(0, 8);
                textBox_oemid.Text = HWOEMIDs.Substring(8, 4);
                textBox_modelid.Text = HWOEMIDs.Substring(12, 4);
            }
            textBox_oemhash.Text = func.SaharaCommand3();
            label_SW_Ver.Text = func.SaharaCommand7();
            //Переходим на вкладку Работа с файлами
            tabControl1.SelectedTab = tabPage_firehose;
            toolStripStatusLabel_filescompleted.Text = "Все идентификаторы получены, устройство можно отключить и перезагрузить";
            string logstr = textBox_hwid.Text + "-" + textBox_oemid.Text + "-" + textBox_modelid.Text + "-" + textBox_oemhash.Text + "-" + label_tm.Text + "-" + label_model.Text;
            if (checkBox_Log.Checked)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(label_log.Text + "\\CPU_Info.log", false)) sw.Write(logstr);
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel_filescompleted.Text = "Ошибка записи лог-файла " + ex.Message;
                }
            }
            if (waitSahara)
            {
                sent_issue.Append(logstr);
                CheckIDs();
            }
            waitSahara = false;
        }

        /// <summary>
        /// Проверяем все идентификаторы на наличие в Справочнике.
        /// </summary>
        private void CheckIDs()
        {
            //Проводим две проверки: 
            //Все четыре идентификатора Сахары совпадают 
            forFilterBindingSource.Filter = string.Format(
                "HWID LIKE '{0}' AND OEMID LIKE '{1}' AND MODELID LIKE '{2}' AND HASHID LIKE '{3}'",
                textBox_hwid.Text, textBox_oemid.Text, textBox_modelid.Text, textBox_oemhash.Text);
            if (forFilterDataGridView.Rows.Count > 0) //Есть устройство с такими идентификаторами
            {
                for (int i = 0; i < forFilterDataGridView.Rows.Count; i++)
                {
                    if (forFilterDataGridView[6, i].Value.ToString().Equals(label_tm.Text) && forFilterDataGridView[7, i].Value.ToString().Equals(label_model.Text)) //Проверяем ТМ и модель на наличие
                    {
                        sent_issue.Clear();
                        return;
                    }
                }
                sent_issue.Insert(0, "2-"); //Исправить/добавить название/модель если 1 совпадает, а 2 нет
            }
            else sent_issue.Insert(0, "1-"); //Устройства нет, надо добавить в автосообщение
        }

        /// <summary>
        /// Пакет идентификаторов для отправки в Телеграмм
        /// </summary>
        /// <param name="SaharaIDs">Текст для отправки</param>
        private void Sent_Issue(string SaharaIDs)
        {
            switch (SaharaIDs.Substring(0, 2))
            {
                case "1-":
                    _ = BotSendMes("Пожалуйста, добавьте в Справочник устройство" + Environment.NewLine + SaharaIDs);
                    break;
                case "2-":
                    _ = BotSendMes("Пожалуйста, добавьте или исправьте в Справочнике название/модель устройства" + Environment.NewLine + SaharaIDs);
                    break;
                default:
                    _ = BotSendMes("Некорректно составлена строка отправки" + Environment.NewLine + SaharaIDs);
                    break;
            }
        }

        /// <summary>
        /// Асинхронная операция отправки сообщения боту телеграма
        /// </summary>
        /// <param name="send_message"></param>
        /// <returns></returns>
        async static Task BotSendMes(string send_message)
        {
            var mybot = new TelegramBotClient(Resources.bot);
            string chat = "@firehosefinder";
            _ = await mybot.SendTextMessageAsync(chat, send_message);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            _ = BotSendMes("Еще разок попробуем");
        }
    }
}
