using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        Func func = new Func(); // Подключили функции
        internal bool sp_closed = true; // Глобальная переменная статуса ком-порта
        private delegate void SetDelegateText(string text); // Делегат для записи текста из одного потока в другой

        /// <summary>
        /// Сообщения системы об изменении конфигурации оборудования
        /// </summary>
        [Flags]
        enum WindowsMessage
        {
            AnyConfigChanges = 0x0007,
            NewUSBDevice = 0x8000,
            USBDeviceDisabled = 0x8004
        }

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public Formfhf()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выполнение инструкций при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_Load(object sender, EventArgs e)
        {
            func.ListingUSBDic(); // Однократный запрос всех USB устройств для записи в глобальную переменную
            foreach (USBPort ap in ActivePorts()) //  Добавили в комбобокс список активных портов
            {
                comboBox_phone_connect.Items.Add(ap.USBName);
            }
            OpenEDLPort();  // Если есть 9008, то пробуем открыть порт
            richTextBox_about.Text = FirehoseFinder.Properties.Resources.String_about + Environment.NewLine
                + "Ссылка на базовую тему <<Общие принципы восстановления загрузчиков на Qualcomm | HS - USB QDLoader 9008, HS - USB Diagnostics 9006, QHUSB_DLOAD и т.д.>>: " + FirehoseFinder.Properties.Resources.String_theme_link + Environment.NewLine
                + Environment.NewLine
                + "Версия сборки: " + Assembly.GetExecutingAssembly().GetName().Version + Environment.NewLine
                + Environment.NewLine
                + "По вопросам поддержки, пожалуйста, обращайтесь: " + FirehoseFinder.Properties.Resources.String_help + Environment.NewLine
                + Environment.NewLine
                + "Часто задаваемые вопросы: " + FirehoseFinder.Properties.Resources.String_faq;
        }

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
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button_path.Text = folderBrowserDialog1.SelectedPath;
                Algoritm();
            }
        }

        /// <summary>
        /// Заглушка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_startscan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока ещё не придумал.");
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
                    if (Convert.ToBoolean(dataGridView_final.Rows[e.RowIndex].Cells[0].Value))
                    {
                        dataGridView_final.Rows[e.RowIndex].Cells[0].Value = false;
                        button_startscan.Visible = false;
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView_final.Rows.Count; i++)
                        {
                            dataGridView_final.Rows[i].Cells[0].Value = false;
                        }
                        dataGridView_final.Rows[e.RowIndex].Cells[0].Value = true;
                        button_startscan.Visible = true;
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
                DialogResult dr = MessageBox.Show(dataGridView_final.Rows[e.RowIndex].Cells[4].Value.ToString(), "Сохранить данные в буфер обмена?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.OK)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(dataGridView_final.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
        }

        /// <summary>
        /// При начале ввода текста отображаем кнопку отправки сообщения в порт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// Отправка строки в порт мышкой на кнопке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_tx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_tx.Text)) Tx(textBox_tx.Text);
            else toolStripStatusLabel_phone.Text = "Невозможно отправить в порт пустую строку.";
        }

        /// <summary>
        /// Отправляем данные в порт по нажатию клавиши Энтер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_tx_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (!string.IsNullOrEmpty(textBox_tx.Text))) Tx(textBox_tx.Text);
            if (String.IsNullOrEmpty(textBox_tx.Text)) button_tx.Visible = true;
        }

        /// <summary>
        /// Алгоритм расчёта количества файлов в папке и их суммарный размер
        /// </summary>
        private void Algoritm()
        {
            ulong volFiles = 0;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text);
            foreach (KeyValuePair<string, long> WL in Resfiles)
            {
                volFiles += Convert.ToUInt64(WL.Value); // суммарный объём файлов для анализа
            }
            int numFiles = Resfiles.Count; // количество файлов для обработки
            int Currnum = 0; // текущий номер файла
            ulong Currvol = 0; // текущий объём
            dataGridView_final.Rows.Clear();
            foreach (KeyValuePair<string, long> countfiles in Resfiles)
            {
                int currrating = func.Rating(countfiles.Key);
                dataGridView_final.Rows.Add();
                dataGridView_final.Rows[Currnum].Cells[1].Value = Path.GetFileName(countfiles.Key);
                if (currrating != 0)
                {
                    string[] id = func.IDs(countfiles.Key);
                    string oemhash = string.Empty;
                    if (id[3].Length < 64)
                    {
                        oemhash = id[3];
                    }
                    else
                    {
                        oemhash = id[3].Substring(56);
                    }
                    dataGridView_final.Rows[Currnum].Cells[2].Value = id[0] + "-" + id[1] + "-" + id[2] + "-" + oemhash + "-" + id[4];
                    dataGridView_final.Rows[Currnum].Cells[4].Value = "HW_ID (процессор) - " + id[0] + Environment.NewLine +
                        "OEM_ID (производитель) - " + id[1] + Environment.NewLine + "MODEL_ID (модель) - " + id[2] + Environment.NewLine +
                        "OEM_HASH (хеш корневого сертификата) - " + id[3] + Environment.NewLine + "SW_ID (возможность прошивки) - " + id[4];
                    if (String.Compare(textBox_hwid.Text, id[0]) == 0) // Процессор такой же
                    {
                        textBox_hwid.BackColor = Color.LawnGreen;
                        currrating += 2;
                    }
                    if (String.Compare(textBox_oemid.Text, id[1]) == 0) // Производитель один и тот же
                    {
                        textBox_oemid.BackColor = Color.LawnGreen;
                        currrating += 2;
                    }
                    if (String.Compare(textBox_modelid.Text, id[2]) == 0) // Модели равны
                    {
                        textBox_modelid.BackColor = Color.LawnGreen;
                        currrating++;
                    }
                    if (id[3].Length >= 64)
                    {
                        if (String.Compare(textBox_oemhash.Text, id[3].Substring(0, 64)) == 0) // Хеши равны
                        {
                            textBox_oemhash.BackColor = Color.LawnGreen;
                            currrating += 2;
                        }
                    }
                    if (id[4].StartsWith("3")) // SWID начинается с 3
                    {
                        currrating++;
                    }
                }
                else
                {
                    dataGridView_final.Rows[Currnum].ReadOnly = true; // Рейтинг 0 не обрабатываем
                    dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.LightGray;
                }
                dataGridView_final.Rows[Currnum].Cells[3].Value = currrating;
                Currnum++;
                Currvol += Convert.ToUInt64(countfiles.Value);
                toolStripStatusLabel_filescompleted.Text = "Обработано " + Currnum.ToString() + " файлов из " + numFiles.ToString();
                toolStripProgressBar_filescompleted.Maximum = Convert.ToInt32(volFiles);
                toolStripProgressBar_filescompleted.Value = Convert.ToInt32(Currvol);
                toolStripStatusLabel_vol.Text = Currvol.ToString("### ### ### ###") + " байт";
            }
            dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);

        }

        /// <summary>
        /// Проверяем все доступные порты
        /// </summary>
        /// <returns>Пара название, порт</returns>
        private List<USBPort> EnablePorts()
        {
            toolStripStatusLabel_phone.Text = string.Empty;
            List<USBPort> eports = new List<USBPort>(); // Список доступных портов
            foreach (USBPort item in func.AllUSB)
            {
                if (!string.IsNullOrEmpty(item.USBName) && !string.IsNullOrEmpty(item.USBPortNumber)) // Убираем не ком и не устройства
                {
                    eports.Add(new USBPort() { USBName = item.USBName, USBPortNumber = item.USBPortNumber });
                }
            }
            return eports;
        }

        /// <summary>
        /// Готовим список активных в системе ком-портов
        /// </summary>
        /// <returns>Пара название, порт</returns>
        private List<USBPort> ActivePorts()
        {
            List<USBPort> APorts = new List<USBPort>();
            string[] ports = SerialPort.GetPortNames();
            foreach (USBPort eport in EnablePorts())
            {
                foreach (string port in ports) // Зарегистрированы в системе ком
                {
                    if (port == eport.USBPortNumber)
                    {
                        APorts.Add(new USBPort() { USBName = eport.USBName, USBPortNumber = eport.USBPortNumber });
                    }
                }
                if (eport.USBPortNumber.Contains("устройство")) // Тут потом надо будет сделать проверку подключённого USB устройства, но не на ком-порт
                {
                    APorts.Add(new USBPort() { USBName = eport.USBName, USBPortNumber = eport.USBPortNumber });
                }
            }
            return APorts;
        }

        /// <summary>
        /// Пробуем открыть EDL порт, если он есть и один
        /// </summary>
        private void OpenEDLPort()
        {
            List<USBPort> edlports = new List<USBPort>();
            foreach (USBPort ap in ActivePorts())
            {
                if (ap.USBName.Contains("9008")) edlports.Add(new USBPort() { USBName = ap.USBName, USBPortNumber = ap.USBPortNumber });
            }
            switch (edlports.Count)
            {
                case 0:
                    comboBox_phone_connect.Text = "Автовыбор при подключении в EDL-Mode";
                    toolStripStatusLabel_phone.Text = "Активные порты можно выбрать вручную.";
                    break;
                case 1:
                    comboBox_phone_connect.Text = edlports[0].USBName;
                    if (serialPort_phone.IsOpen)
                    {
                        sp_closed = true;
                        serialPort_phone.DiscardInBuffer();
                        serialPort_phone.DiscardOutBuffer();
                        serialPort_phone.Close();
                    }
                    try
                    {
                        serialPort_phone.PortName = edlports[0].USBPortNumber;
                        serialPort_phone.Open();
                        sp_closed = false;
                        toolStripStatusLabel_phone.Text = "Порт " + serialPort_phone.PortName + " открыт.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "Ошибка открытия порта в функции OpenEDLPort");
                    }
                    break;
                default:
                    comboBox_phone_connect.Text = "Выберите порт вручную";
                    toolStripStatusLabel_phone.Text = "В системе несколько доступных EDL портов, выберите вручную.";
                    break;
            }
        }

        /// <summary>
        /// Выбирается активный порт при любом изменении комбобокса
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_phone_connect_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<USBPort> newportenable = new List<USBPort>(); // Наличие вновь выбранного порта в списках
            foreach (USBPort aport in ActivePorts())
            {
                if (aport.USBName.Equals(comboBox_phone_connect.Text)) newportenable.Add(new USBPort() { USBName = aport.USBName, USBPortNumber = aport.USBPortNumber });
            }
            switch (newportenable.Count)
            {
                case 0:
                    foreach (USBPort eport in EnablePorts())
                    {
                        if (eport.USBName.Equals(comboBox_phone_connect.Text))
                        {
                            if (serialPort_phone.IsOpen)
                            {
                                sp_closed = true;
                                serialPort_phone.DiscardInBuffer();
                                serialPort_phone.DiscardOutBuffer();
                                serialPort_phone.Close();
                            }
                            try
                            {
                                serialPort_phone.PortName = eport.USBPortNumber;
                                toolStripStatusLabel_phone.Text = "Порт изменён, но не открыт.";
                            }
                            catch (Exception ex)
                            {
                                toolStripStatusLabel_phone.Text = "-" + ex.Message + "-";
                            }
                            break;
                        }
                    }
                    toolStripStatusLabel_phone.Text = "Порт изменить не удалось.";
                    break;
                case 1:
                    if (serialPort_phone.IsOpen)
                    {
                        sp_closed = true;
                        serialPort_phone.DiscardInBuffer();
                        serialPort_phone.DiscardOutBuffer();
                        serialPort_phone.Close();
                    }
                    if (!newportenable[0].USBPortNumber.Contains("устройство"))
                    {
                        try
                        {
                            sp_closed = false;
                            serialPort_phone.PortName = newportenable[0].USBPortNumber;
                            serialPort_phone.Open();
                            toolStripStatusLabel_phone.Text = "Порт изменён на " + serialPort_phone.PortName + " и открыт.";
                        }
                        catch (Exception ex)
                        {
                            toolStripStatusLabel_phone.Text = "--" + ex.Message + "--";
                        }
                    }
                    else toolStripStatusLabel_phone.Text = "Данный выбор не предусматривает изменения порта";
                    break;
                default:
                    toolStripStatusLabel_phone.Text = "Порт изменить не удалось. Попробуйте выбрать другой.";
                    break;
            }
        }

        /// <summary>
        /// Выводим полный или сокращённый список портов в зависимости от галки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_ava_ports_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_phone_connect.Items.Clear();
            List<USBPort> comboports = new List<USBPort>();
            if (checkBox_ava_ports.Checked) comboports = EnablePorts();
            else comboports = ActivePorts();
            foreach (USBPort item in comboports) comboBox_phone_connect.Items.Add(item.USBName);
        }

        /// <summary>
        /// Отправляем строку в порт
        /// </summary>
        /// <param name="trstr">СТрока для отправки</param>
        private void Tx(string trstr)
        {
            if (serialPort_phone.IsOpen)
            {
                textBox_phone.Text += DateTime.Now.ToString() + " Отправили: " + textBox_tx.Text + Environment.NewLine;
                textBox_tx.Text = string.Empty;
                button_tx.Visible = false;
                serialPort_phone.WriteLine(trstr);
                toolStripStatusLabel_phone.Text = "Данные отправлены в порт";
            }
            else toolStripStatusLabel_phone.Text = "Не отправлено. Проверьте настройки порта.";
        }

        /// <summary>
        /// Читаем пришедшие в порт данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_phone_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!sp_closed)
            {
                Thread.Sleep(200);   // Сделаем небольшую задержку, чтоб всё успело в порт свалиться.
                StringBuilder portstr = new StringBuilder();
                try
                {
                    while (serialPort_phone.BytesToRead > 0)
                    {
                        portstr.Append((char)serialPort_phone.ReadChar());
                    }
                    this.BeginInvoke(new SetDelegateText(AfterReadPort), new object[] { portstr.ToString() });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + "Ошибка чтения порта");
                }
            }
        }

        /// <summary>
        /// Отображаем полученные данные на текстовом поле
        /// </summary>
        /// <param name="instr">Входящая строка из порта</param>
        private void AfterReadPort(string instr)
        {
            textBox_phone.Text += DateTime.Now.ToString() + " Получили: " + instr + Environment.NewLine;
        }

        /// <summary>
        /// Происходит при изменении контакта порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_phone_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            MessageBox.Show("Пин изменение");
            /*
            if (serialPort_phone.IsOpen)
            {
                serialPort_phone.Close();
                sp_closed = true;
            }
            else
            {
                EnablePorts();
            }
            */
        }

        /// <summary>
        /// Отлавливаем подключение/отключение USB устройств. Открываем закладку Настройки
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            try { base.WndProc(ref m); }
            catch (TargetInvocationException) { }
            switch (m.WParam.ToInt32())
            {
                case (int)WindowsMessage.NewUSBDevice://новое usb подключено
                    tabControl1.SelectedTab = tabPage_phone;
                    func.ListingUSBDic(); // Однократный запрос всех USB устройств для записи в глобальную переменную
                    comboBox_phone_connect.Items.Clear();
                    foreach (USBPort ap in ActivePorts()) //  Добавили в комбобокс список активных портов
                    {
                        comboBox_phone_connect.Items.Add(ap.USBName);
                    }
                    OpenEDLPort();  // Если после автоподключения в листвью есть доступные устройства, то пробуем открыть порты
                    break;
                case (int)WindowsMessage.USBDeviceDisabled: // usb отключено - перезапуск программы
                    MessageBox.Show("Винпрок устройство отключено");
                    //Application.Restart();
                    break;
                /*  case (int)WindowsMessage.AnyConfigChanges: // Любое изменение конфигурации оборудования
                      tabControl1.SelectedTab = tabPage_phone;
                      func.ListingUSBDic(); // Однократный запрос всех USB устройств для записи в глобальную переменную
                      EnablePorts();  // Если после автоподключения в листвью есть доступные устройства, то пробуем открыть порты
                      break;*/
                default:
                    break;
            }
        }
    }
}


