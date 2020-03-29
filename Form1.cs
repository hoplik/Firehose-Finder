using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

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
        Func func = new Func();
        private void Algoritm()
        {
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
                Currvol += countfiles.Value;
                toolStripStatusLabel_filescompleted.Text = "Обработано " + Currnum.ToString() + " файлов из " + numFiles.ToString();
                toolStripProgressBar_filescompleted.Maximum = volFiles;
                toolStripProgressBar_filescompleted.Value = Convert.ToInt32(Currvol);
                toolStripStatusLabel_vol.Text = Currvol.ToString() + " байт";
            }
            dataGridView_final.Sort(dataGridViewColumn: Column_rate, ListSortDirection.Descending);

        }
        private void Button_startscan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока ещё не придумал.");
        }
        /// <summary>
        /// Выполнение инструкций при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_Load(object sender, EventArgs e)
        {
            func.ListingUSBDic(); // Однократный запрос всех USB устройств для записи в глобальную переменную
            EnablePorts();  // Если после автоподключения в листвью есть доступные устройства, то пробуем открыть порты
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
        /// Обработка выбранной строки с программером
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
                MessageBox.Show("Стоит сначала выбрать рабочую директорию" + Environment.NewLine + ex.Message);
            }
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
                case 0x8000://новое usb подключено
                    tabControl1.SelectedTab = tabPage_phone;
                    EnablePorts();  // Если после автоподключения в листвью есть доступные устройства, то пробуем открыть порты
                    break;
                case 0x8004: // usb отключено
                    tabControl1.SelectedTab = tabPage_phone;
                    EnablePorts();  // Если после автоподключения в листвью есть доступные устройства, то пробуем открыть порты
                    break;
                case 0x0007: // Любое изменение конфигурации оборудования
                    tabControl1.SelectedTab = tabPage_phone;
                    func.ListingUSBDic(); // Однократный запрос всех USB устройств для записи в глобальную переменную
                    EnablePorts();  // Если после автоподключения в листвью есть доступные устройства, то пробуем открыть порты
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Проверяем все доступные порты
        /// </summary>
        private void EnablePorts()
        {
            comboBox_phone_connect.Items.Clear();
            comboBox_phone_connect.Text = "Автовыбор при подключении";
            toolStripStatusLabel_phone.Text = string.Empty;
            string[] ports = SerialPort.GetPortNames();
            Dictionary<string, string> activports = new Dictionary<string, string>(); // Счётчик/список активных портов
            foreach (KeyValuePair<string, string> device in func.allUSBDev)
            {
                if (!string.IsNullOrEmpty(device.Value)) // Убираем не ком и устройства
                {
                    if (device.Value.Contains("COM"))
                    {
                        foreach (string port in ports) // Зарегистрированы ли в системе ком
                        {
                            if (port == device.Value)
                            {
                                comboBox_phone_connect.Items.Add(device.Key);
                                activports.Add(device.Key, device.Value);
                            }
                        }
                    }
                    if (device.Value.Contains("устройство")) // Тут потом надо будет сделать проверку подключённого USB устройства, но не на ком-порт
                    {
                        comboBox_phone_connect.Items.Add(device.Key);
                        //toolStripStatusLabel_phone.Text = "Устройство подключено.";
                    }
                }
            }
            if (serialPort_phone.IsOpen) serialPort_phone.Close();
            switch (activports.Count)
            {
                case 0:
                    comboBox_phone_connect.Text = "Автовыбор при подключении";
                    toolStripStatusLabel_phone.Text = "Активные порты не обнаружены.";
                    break;
                case 1:
                    foreach (KeyValuePair<string, string> ap in activports)
                    {
                        comboBox_phone_connect.Text = ap.Key;
                        serialPort_phone.PortName = ap.Value;
                        if (TryToOpenPort())
                        {
                            serialPort_phone.Open();
                            toolStripStatusLabel_phone.Text = "Порт открыт.";
                        }
                        else toolStripStatusLabel_phone.Text = "Не удалось открыть порт.";
                    }
                    break;
                default:
                    comboBox_phone_connect.Text = "Выберите порт вручную";
                    toolStripStatusLabel_phone.Text = "В системе несколько доступных портов, выберите вручную.";
                    break;
            }
        }
        /// <summary>
        /// Выбираем активный порт из списка вручную (нежелательно!)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_phone_connect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_phone_connect.Text.Contains("COM"))
            {
                if (serialPort_phone.IsOpen) serialPort_phone.Close();
                if (func.allUSBDev.TryGetValue(comboBox_phone_connect.Text, out string comportnew))
                {
                    serialPort_phone.PortName = comportnew;
                    if (TryToOpenPort())
                    {
                        serialPort_phone.Open();
                        toolStripStatusLabel_phone.Text = "Порт изменён и открыт.";
                    }
                    else toolStripStatusLabel_phone.Text = "Не удалось изменить порт.";
                }
                else toolStripStatusLabel_phone.Text = "Не удалось изменить порт. Попробуйте выбрать другой порт из списка.";
            }
            else toolStripStatusLabel_phone.Text = "Этот выбор не подразумевает изменение порта.";
        }
        /// <summary>
        /// Пробуем открыть выбранный порт
        /// </summary>
        /// <param name="comport"></param>
        private bool TryToOpenPort()
        {
            if (serialPort_phone.IsOpen)
            {
                serialPort_phone.Dispose();
                return true;
            }
            try
            {
                serialPort_phone.Open();
                serialPort_phone.Dispose();
                return true;
            }
            catch (IOException ex)
            {
                toolStripStatusLabel_phone.Text = "Ошибка открытия порта. " + ex.Message;
            }
            return false;
        }

        private void CheckBox_ava_ports_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_phone_connect.Items.Clear();
            if (checkBox_ava_ports.Checked)
            {
                foreach (KeyValuePair<string, string> device in func.allUSBDev)
                {
                    if (!string.IsNullOrEmpty(device.Value)) // Убираем не ком и устройства
                    {
                        comboBox_phone_connect.Items.Add(device.Key);
                    }
                }
            }
            else EnablePorts();
        }
    }
}


