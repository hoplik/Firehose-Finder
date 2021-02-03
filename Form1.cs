using FirehoseFinder.Properties;
using Microsoft.Win32;
using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        Func func = new Func(); // Подключили функции
        Guide guide = new Guide();
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
            //Загружаем Справочник устройств
            dataSet1.ReadXml("ForFilter.xml", XmlReadMode.ReadSchema);
            bindingSource_collection.DataSource = dataSet1.Tables[1];
            dataGridView_collection.DataSource = bindingSource_collection;
            bindingNavigator_collection.BindingSource = bindingSource_collection;
            dataGridView_collection.Columns["Proof"].Visible = false;
            //Закрываем специализированные закладки
            tabControl1.TabPages.Remove(tabPage_collection);
            tabControl1.TabPages.Remove(tabPage_phone);
            //Всплывающие подсказки к разным контролам
            toolTip1.SetToolTip(button_findIDs, "Подключите устройство и нажмите для получения идентификаторов");
            toolTip1.SetToolTip(button_path, "Укажите путь к коллекции firehose");
            toolTip1.SetToolTip(button_useSahara_fhf, "Нажмите для проверки выбранного программера");
            CheckListPorts();
        }

        /// <summary>
        /// При закрытии приложения подчищаем за собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (File.Exists("commandop02.bin")) File.Delete("commandop02.bin");
                if (File.Exists("commandop03.bin")) File.Delete("commandop03.bin");
                if (File.Exists("commandop07.bin")) File.Delete("commandop07.bin");
                if (File.Exists("port_trace.txt")) File.Delete("port_trace.txt");
            }
            catch (Exception)
            {
            }
        }

        #region Функции команд контролов меню программы

        /// <summary>
        /// Закрытие приложения из меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        /// <summary>
        /// Окно "Приветствие" при старте программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void приветствиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В стадии разработки");
        }

        /// <summary>
        /// Отображаем/скрываем вкладку Справочник устройств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СправочникУстройствToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (справочникУстройствToolStripMenuItem.Checked)
            {
                tabControl1.TabPages.Insert(tabControl1.TabPages.Count, tabPage_collection);
                if (!неподтверждённыеДанныеToolStripMenuItem.Checked)
                {
                    //Отображаем только подтверждённые данные
                    bindingSource_collection.Filter = "Proof = true";
                }
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage_collection);
                неподтверждённыеДанныеToolStripMenuItem.Checked = false;
            }
        }

        /// <summary>
        /// Применяем фильтр к Справочнику для неподтверждённых данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void НеподтверждённыеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (неподтверждённыеДанныеToolStripMenuItem.Checked)
            {
                справочникУстройствToolStripMenuItem.Checked = true;
                //отображаем все данные справочника. Пруфы красим бледно-зелёным
                bindingSource_collection.Filter = null;
            }
            else
            {
                //Отображаем только подтверждённые данные
                bindingSource_collection.Filter = "Proof = true";
            }
        }

        /// <summary>
        /// Скрываем/отображаем вкладку Работа с устройством из меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void РаботаСУстройствомToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (работаСУстройствомToolStripMenuItem.Checked)
            {
                tabControl1.TabPages.Insert(0, tabPage_phone);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage_phone);
            }
        }

        /// <summary>
        /// Окно "Внести производителя, модель" для ручного ввода данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ВнестиПроизводителяМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertModelForm imf = new InsertModelForm();
            imf.ShowDialog();
            label_tm.Text = "\"" + imf.comboBox_tm_insert.Text + "\""; //Если Производитель пришёл в кавычках, значит вводили вручную
            label_model.Text = imf.textBox_model_insert.Text;
            label_altname.Text = imf.textBox_alt_insert.Text;
        }

        /// <summary>
        /// Просмотр Справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ПросмотрСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psin = new ProcessStartInfo("help_ru.pdf");
            Process.Start(psin);
        }

        /// <summary>
        /// О Программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        #endregion

        #region Функции команд контролов вкладки Работа с устройством

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
                        GetADBIDs(false);
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
                comboBox_fh_command.Enabled = true;
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
        /// Выполняем команды программера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sahara_CommandStart_Click(object sender, EventArgs e)
        {
            Process process1 = new Process();
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.RedirectStandardOutput = true;
            process1.StartInfo.CreateNoWindow = true;
            StringBuilder sahara_command_args = new StringBuilder("-p \\\\.\\" + serialPort1.PortName + " -s 13:");
            StringBuilder fh_command_args = new StringBuilder("--port=\\\\.\\");
            if (!File.Exists(label_Sahara_fhf.Text))
            {
                DialogResult dr = MessageBox.Show("Выберете программер на вкладке \"Работа с файлами\"",
                    "Требуется указать корректный путь к файлу",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.OK) tabControl1.SelectedTab = tabPage_firehose;
                return;
            }
            sahara_command_args.Append(label_Sahara_fhf.Text);
            if (radioButton_shortlog.Checked) sahara_command_args.Append(" -v 0");
            if (radioButton_fulllog.Checked) sahara_command_args.Append(" -v 1");
            {

            }
            try
            {
                process1.StartInfo.FileName = "QSaharaServer.exe";
                process1.StartInfo.Arguments = sahara_command_args.ToString();
                process1.Start();
                StreamReader reader1 = process1.StandardOutput;
                textBox_ADB.AppendText(reader1.ReadToEnd());
                process1.WaitForExit();
                process1.Close();
                fh_command_args.Append(serialPort1.PortName);
                if (comboBox_mem_type.SelectedIndex == (int)Guide.MEM_TYPE.eMMC) fh_command_args.Append(" --memoryname=emmc");
                if (checkBox_reset.Checked) fh_command_args.Append(" --reset");
                if (radioButton_shortlog.Checked) fh_command_args.Append(" --loglevel=1");
                if (radioButton_fulllog.Checked) fh_command_args.Append(" --loglevel=2");
                fh_command_args.Append(" --noprompt");// --dontsorttags - выдаёт предупреждение!
                switch (comboBox_fh_command.SelectedIndex)
                {
                    case 0:
                        Process process2 = new Process();
                        process2.StartInfo.UseShellExecute = false;
                        process2.StartInfo.RedirectStandardOutput = true;
                        process2.StartInfo.CreateNoWindow = true;
                        process2.StartInfo.FileName = "fh_loader.exe";
                        process2.StartInfo.Arguments = fh_command_args.ToString();
                        process2.Start();
                        StreamReader reader2 = process2.StandardOutput;
                        textBox_ADB.AppendText(reader2.ReadToEnd());
                        process2.WaitForExit();
                        process2.Close();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Если выбрали команду, активировали кнопку исполнения команды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_fh_command_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Sahara_CommandStart.Enabled = true;
        }

        /// <summary>
        /// Поиск по всем полям
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_find_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toolStripTextBox_find.Text))
            {
                if (!неподтверждённыеДанныеToolStripMenuItem.Checked) bindingSource_collection.Filter = "Proof = true";
                else bindingSource_collection.Filter = null;
            }
            else bindingSource_collection.Filter = string.Format("HWID LIKE '%{0}%' OR FullName LIKE '%{0}%' OR OEMID LIKE '%{0}%' OR Names LIKE '%{0}%' OR MODELID LIKE '%{0}%' OR HASHID LIKE '%{0}%' OR Trademark LIKE '%{0}%' OR Model LIKE '%{0}%' OR AltName LIKE '%{0}%'", toolStripTextBox_find.Text);
        }

        #endregion

        #region Функции команд контролов вкладки Работа с файлами

        /// <summary>
        /// Автозапуск получения идентификаторов и сверки их со Справочником
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_findIDs_Click(object sender, EventArgs e)
        {
            if (listView_comport.CheckedItems.Count > 0)
            {
                GetSaharaIDs();
                return;
            }
            if (!ADB_Check())
            {
                MessageBox.Show("Проверка корректности работы с устройством через ADB закончилась неудачно." + Environment.NewLine +
                    "Пожалуйста, исправьте ошибки по данным лога и/или подключите устройство в режиме 9008 после перезагрузки вручную", "Ошибка ADB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton_adb_reset.Checked) GetADBIDs(true);
            if (radioButton_man_reset.Checked)
            {
                GetADBIDs(false);
                if (label_model.Text.StartsWith("---")) MessageBox.Show("Идентификаторы не получены. Пожалуйста, перезагрузите устройство в аварийный режим вручную.", "Ожидание перезагрузки");
                else MessageBox.Show("Идентификаторы получены частично. Пожалуйста, перезагрузите устройство в аварийный режим вручную.", "Ожидание перезагрузки");
            }
            waitSahara = true; //Ждём подключения в аварийном режиме
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
            MessageBox.Show("Пожалуйста, для дальнейшей работы используйте вкладку \"Работа с устройством\". Активировать вкладку можно в меню \"Вид\"" + Environment.NewLine +
                "Для проверки программера после запроса идентификаторов, устройство должно быть обязательно отключено от компьютера и перезагружено в аварийный режим (9008)." + Environment.NewLine +
                "Перезагрузку устройства в аварийный режим можно будет осуществить на вкладке \"Работа с устройством\" средствами ADB либо вручную. Команды протокола \"Сахара\" станут доступны после определения устройства на com-порту." + Environment.NewLine +
                "Из-за особенностей протокола \"Сахара\" попытка загрузки программера в память устройства без его перезагрузки вызовет зависание программы.", "Важная информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        label_Sahara_fhf.Text = button_path.Text + "\\" + dataGridView_final.SelectedRows[0].Cells[1].Value.ToString();
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
            StringBuilder dumptext = new StringBuilder(len);
            byte[] chunk = new byte[len];
            using (var stream = File.OpenRead(FileToRead.Key))
            {
                int byteschunk = stream.Read(chunk, 0, 4);
                for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                if (dumptext.ToString().Equals("D1DC4B84") || dumptext.ToString().StartsWith("7F454C4"))
                {
                    dumptext.Clear();
                    stream.Position = 0;
                    byteschunk = stream.Read(chunk, 0, len);
                    for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                }
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
                        dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        dataGridView_final["Column_Name", Currnum].ToolTipText = "Файл не является ELF!";
                        break;
                    case "D1DC4B84": //Старый программер
                        curfilerating++;
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

        #region Функции команд контролов вкладки Справочник устройств

        /// <summary>
        /// Заполняем форму поиска программера из Справочника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_collection_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel_row = e.RowIndex;
            textBox_hwid.Text = dataGridView_collection["HWID", sel_row].Value.ToString();
            textBox_oemid.Text = dataGridView_collection["OEMID", sel_row].Value.ToString();
            textBox_modelid.Text = dataGridView_collection["MODELID", sel_row].Value.ToString();
            textBox_oemhash.Text = dataGridView_collection["HASHID", sel_row].Value.ToString();
            label_tm.Text = dataGridView_collection["Trademark", sel_row].Value.ToString();
            label_altname.Text = dataGridView_collection["Model", sel_row].Value.ToString();
            label_model.Text = dataGridView_collection["AltName", sel_row].Value.ToString();
            tabControl1.SelectedTab = tabPage_firehose;
        }

        #endregion

        #region Функции самостоятельных команд

        /// <summary>
        /// Вносим в листвью список активных портов
        /// </summary>
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

        /// <summary>
        /// Останавливаем сервер, очищаем поле, восстанавливаем доступы к контролам
        /// </summary>
        private void StopAdb()
        {
            AdbClient client = new AdbClient();
            textBox_ADB.Text = "Сеанс ADB завершён" + Environment.NewLine;
            textBox_main_term.Text = "Сеанс ADB завершён" + Environment.NewLine;
            try
            {
                client.KillAdb();
            }
            catch (Exception)
            {
            }
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
            dataGridView_final["Column_Full", Currnum].Value = "Jtag_ID (процессор) - " + id[0] + Environment.NewLine +
                "OEM_ID (производитель) - " + id[1] + Environment.NewLine +
                "MODEL_ID (модель) - " + id[2] + Environment.NewLine +
                "OEM_PK_HASH (хеш корневого сертификата) - " + id[3] + Environment.NewLine +
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
                if (textBox_oemhash.Text.Equals(id[3])) // Хеши равны
                {
                    textBox_oemhash.BackColor = Color.LawnGreen;
                    gross += 2;
                }
            }
            if (id[4].Equals("3")) gross += 2; // SWID начинается с 3 (альтернативная проверка: есть fh@0x%08 - Contains("6668403078253038"))
            return gross;
        }

        /// <summary>
        /// Проверяем корректность подключения устройства через запуск ADB
        /// </summary>
        /// <returns>true - всё хорошо, false - есть ошибки</returns>
        private bool ADB_Check()
        {
            //Стартуем сервер
            textBox_ADB.AppendText("Запускаем сервер ADB ..." + Environment.NewLine);
            textBox_main_term.AppendText("Запускаем сервер ADB ..." + Environment.NewLine);
            AdbServer server = new AdbServer();
            var result = server.StartServer("adb.exe", restartServerIfNewer: false);
            //Подключаем клиента (устройства)
            AdbClient client = new AdbClient();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            textBox_ADB.AppendText(result.ToString() + Environment.NewLine);
            textBox_main_term.AppendText(result.ToString() + Environment.NewLine);
            button_ADB_start.Enabled = false;
            foreach (var device in devices)
            {
                textBox_ADB.AppendText("Подключено устройство: " + device + Environment.NewLine);
                textBox_main_term.AppendText("Подключено устройство: " + device + Environment.NewLine);
            }
            if (devices.Count > 1)
            {
                textBox_ADB.AppendText("Подключено более одного андройд-устройства. Пожалуйста, оставьте подключённым только то устройство, с которым планируется дальнейшая работа." + Environment.NewLine);
                textBox_main_term.AppendText("Подключено более одного андройд-устройства. Пожалуйста, оставьте подключённым только то устройство, с которым планируется дальнейшая работа." + Environment.NewLine);
                return false;
            }
            else if (devices.Count == 0)
            {
                textBox_ADB.AppendText("Подключённых устройств не найдено. Пожалуйста, проверьте в настройках устройства разрешена ли \"Отладка по USB\" в разделе \"Система\" - \"Для разработчиков\"" + Environment.NewLine);
                textBox_main_term.AppendText("Подключённых устройств не найдено. Пожалуйста, проверьте в настройках устройства разрешена ли \"Отладка по USB\" в разделе \"Система\" - \"Для разработчиков\"" + Environment.NewLine);
                return false;
            }
            else
            {
                comboBox_ADB_commands.Enabled = true;
                return true;
            }
        }

        /// <summary>
        /// Получаем пакетно идентификаторы и сверяем их со справочником (с последующей перезагрузкой или без)
        /// </summary>
        /// <param name="reset">true - если перегружаем после получения ID, false - если перезагрузка не нужна</param>
        private void GetADBIDs(bool reset)
        {
            AdbClient client = new AdbClient();
            var receiver = new ConsoleOutputReceiver();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            var device = devices[0];
            string mem_type = "не определена (возможно UFS)";
            List<string> adbcommands = new List<string>() {
                "getprop | grep ro.emmc_size",
                "getprop | grep ro.product.name",
                "getprop | grep ro.product.manufacturer",
                "getprop | grep ro.product.model"};
            string[] results = new string[adbcommands.Count];
            for (int i = 0; i < adbcommands.Count; i++)
            {
                try
                {
                    client.ExecuteRemoteCommand(adbcommands[i], device, receiver);
                }
                catch (SharpAdbClient.Exceptions.AdbException ex)
                {
                    textBox_ADB.AppendText(ex.AdbError + Environment.NewLine);
                    textBox_main_term.AppendText(ex.AdbError + Environment.NewLine);
                }
                string[] adbstr = receiver.ToString().Split('[');
                foreach (string item in adbstr)
                {
                    if (!item.StartsWith("ro.product.m") || !item.StartsWith("ro.emmc"))
                    {
                        if (item.Contains("]")) results[i] = item.Remove(item.IndexOf(']'));
                    }
                }
                if (string.IsNullOrEmpty(results[i])) results[i] = string.Empty;
                receiver.Flush();
            }
            label_altname.Text = results[1];
            label_tm.Text = results[2];
            label_model.Text = results[3];
            if (!string.IsNullOrEmpty(results[0]))
            {
                mem_type = "eMMC : " + results[0];
                comboBox_mem_type.Text = comboBox_mem_type.Items[(int)Guide.MEM_TYPE.eMMC].ToString();
                comboBox_mem_type.SelectedIndex = (int)Guide.MEM_TYPE.eMMC;
            }
            textBox_ADB.AppendText("Производитель: " + label_tm.Text + Environment.NewLine +
                "Модель: " + label_model.Text + Environment.NewLine +
                "Альтернативное наименование: " + label_altname.Text + Environment.NewLine +
                "Тип памяти: " + mem_type + Environment.NewLine);
            textBox_main_term.AppendText("Производитель: " + label_tm.Text + Environment.NewLine +
                "Модель: " + label_model.Text + Environment.NewLine +
                "Альтернативное наименование: " + label_altname.Text + Environment.NewLine +
                "Тип памяти: " + mem_type + Environment.NewLine);
            if (reset)
            {
                textBox_ADB.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                textBox_main_term.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                try
                {
                    client.Reboot("edl", device);
                }
                catch (Exception ex)
                {
                    textBox_ADB.AppendText(ex.Message + Environment.NewLine + "Автоматическая перезагрузка в аварийный режим 9008 из ADB закончилась неудачно. Попробуйте вручную." + Environment.NewLine);
                    textBox_main_term.AppendText(ex.Message + Environment.NewLine + "Автоматическая перезагрузка в аварийный режим 9008 из ADB закончилась неудачно. Попробуйте вручную." + Environment.NewLine);
                }
                Thread.Sleep(2000);
                StopAdb();
            }
        }

        /// <summary>
        /// Получаем идентификаторы из Сахары
        /// </summary>
        private void GetSaharaIDs()
        {
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
            textBox_main_term.AppendText(output);
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
            toolStripStatusLabel_filescompleted.Text = "Идентификаторы получены, устройство можно отключить и перезагрузить";
            if (checkBox_Log.Checked || checkBox_send.Checked)
            {
                if (label_tm.Text.StartsWith("---") || label_model.Text.StartsWith("---"))
                {
                    InsertModelForm fr = new InsertModelForm();
                    fr.ShowDialog();
                    label_tm.Text = "\"" + fr.comboBox_tm_insert.Text + "\""; //Если Производитель пришёл в кавычках, значит вводили вручную
                    label_model.Text = fr.textBox_model_insert.Text;
                    label_altname.Text = fr.textBox_alt_insert.Text;
                }
            }
            string logstr = textBox_hwid.Text + textBox_oemid.Text + textBox_modelid.Text + "-" + textBox_oemhash.Text + "-" + label_SW_Ver.Text + "-" + label_tm.Text + "-" + label_model.Text + "-" + label_altname.Text;
            if (checkBox_Log.Checked)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(label_log.Text + "\\" + label_model.Text + "_Report.txt", false)) sw.Write(logstr);
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel_filescompleted.Text = "Ошибка записи файла отчёта: " + ex.Message;
                }
            }
            if (checkBox_send.Checked) _ = CheckIDs(logstr);
            waitSahara = false;
        }

        /// <summary>
        /// Проверяем все идентификаторы на наличие в Справочнике.
        /// </summary>
        async Task CheckIDs(string send_string)
        {
            //Проводим две проверки: 
            //Все четыре идентификатора Сахары совпадают 
            bindingSource_collection.Filter = string.Format(
                 "HWID LIKE '{0}' AND OEMID LIKE '{1}' AND MODELID LIKE '{2}' AND HASHID LIKE '{3}'",
                 textBox_hwid.Text, textBox_oemid.Text, textBox_modelid.Text, textBox_oemhash.Text);
            if (dataGridView_collection.Rows.Count > 0) //Есть устройство с такими идентификаторами
            {
                for (int i = 0; i < dataGridView_collection.Rows.Count; i++)
                {
                    if (dataGridView_collection["Model", i].Value.ToString().Equals(label_model.Text) && (bool)dataGridView_collection["Proof", i].Value) //Проверяем модель на наличие
                    {
                        return;
                    }
                }
                //Исправить/добавить название/модель если 1 совпадает, а 2 нет
                await BotSendMes("Пожалуйста, добавьте или исправьте в Справочнике название/модель устройства" + Environment.NewLine + send_string);
            }
            //Устройства нет, надо добавить в автосообщение
            else await BotSendMes("Пожалуйста, добавьте в Справочник устройство" + Environment.NewLine + send_string);
        }

        /// <summary>
        /// Асинхронная операция отправки сообщения боту телеграма
        /// </summary>
        /// <param name="send_message"></param>
        /// <returns></returns>
        async static Task BotSendMes(string send_message)
        {
            try
            {
                var mybot = new TelegramBotClient(Resources.bot);
                Telegram.Bot.Types.ChatId chat = -1001227261414; //string chat = "@firehosefinder";
                _ = await mybot.SendTextMessageAsync(chat, send_message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
 