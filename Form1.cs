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
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        Func func = new Func(); // Подключили функции
        Guide guide = new Guide();
        bool waitSahara = false; //Ждём ли мы автоперезагрузку с получением ID Sahara
        bool FHAlreadyLoaded = false; //Был ли успешно загружен программер (не надо грузить повторно)
        bool NeedReset = false; //Требуется ли перезагрузка устройства после работы с Сахарой
        Flash_Disk flash_start = new Flash_Disk(0, 0, 1);
        internal Flash_Disk[] Flash_Params = new Flash_Disk[1];
        internal DeviceData Global_ADB_Device = new DeviceData();
        internal string Global_FB_Device = string.Empty;
        internal Dictionary<string, string> Connected_Devices = new Dictionary<string, string>();//Список подключённых ADB устройств

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
                    case 0x8000: //Новое usb подключено
                        NeedReset = false;
                        CheckListPorts();
                        ClearListViewDevices();
                        break;
                    case 0x0007: //Любое изменение конфигурации оборудования
                        CheckListPorts();
                        ClearListViewDevices();
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
            //Загружаем список программеров с сервера
            dataSet_Find.ReadXml("ForFound.xml", XmlReadMode.ReadSchema);
            bindingSource_firehose.DataSource = dataSet_Find.Tables[1];
            dataGridView_FInd_Server.DataSource = bindingSource_firehose;
            //Настройки отображения справочника
            dataGridView_collection.Columns["HASHID"].HeaderText = "OEM Private Key Hash";
            dataGridView_collection.Columns["OEMID"].HeaderText = "OEM";
            dataGridView_collection.Columns["MODELID"].HeaderText = "Model";
            //Закрываем специализированные закладки
            tabControl1.TabPages.Remove(tabPage_collection);
            tabControl1.TabPages.Remove(tabPage_phone);
            //Обнуляем глобальные переменные
            Flash_Params.SetValue(flash_start, 0);
            //Всплывающие подсказки к разным контролам
            toolTip1.SetToolTip(button_findIDs, "Подключите устройство и нажмите для получения идентификаторов");
            toolTip1.SetToolTip(button_path, "Укажите путь к коллекции firehose");
            toolTip1.SetToolTip(button_useSahara_fhf, "Нажмите для проверки выбранного программера");
            CheckListPorts();
            //Открываем приветствие если новое или отмечено в настройках
            if (Settings.Default.CheckBox_start_Checked)
            {
                Greeting greeting = new Greeting();
                greeting.ShowDialog();
            }
            //Закрываем запущенные процессы, если есть
            foreach (Process adb_proc in Process.GetProcessesByName("adb"))
            {
                adb_proc.Kill();
            }
            foreach (Process fb_proc in Process.GetProcessesByName("fastboot"))
            {
                fb_proc.Kill();
            }
        }

        /// <summary>
        /// При закрытии приложения подчищаем за собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save(); //Сохраняем настройки
            try
            {
                foreach (string cleanfile in guide.FilesToClean)
                {
                    if (File.Exists(cleanfile)) File.Delete(cleanfile);
                }
                foreach (Process adb_proc in Process.GetProcessesByName("adb"))
                {
                    adb_proc.Kill();
                }
                foreach (Process fb_proc in Process.GetProcessesByName("fastboot"))
                {
                    fb_proc.Kill();
                }
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
        private void ПриветствиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Greeting greeting = new Greeting();
            greeting.Show();
        }

        /// <summary>
        /// Отображаем/скрываем вкладку Справочник устройств
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СправочникУстройствToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (CollectionToolStripMenuItem.Checked)
            {
                tabControl1.TabPages.Insert(tabControl1.TabPages.Count, tabPage_collection);
                tabControl1.SelectedTab = tabPage_collection;
                if (!ProofAllToolStripMenuItem.Checked)
                {
                    //Отображаем только подтверждённые данные
                    bindingSource_collection.Filter = "Url is Not Null";
                }
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage_collection);
                ProofAllToolStripMenuItem.Checked = false;
            }
        }

        /// <summary>
        /// Применяем фильтр к Справочнику для неподтверждённых данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void НеподтверждённыеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProofAllToolStripMenuItem.Checked)
            {
                CollectionToolStripMenuItem.Checked = true;
                //отображаем все данные справочника. Пруфы красим бледно-зелёным
                bindingSource_collection.Filter = null;
            }
            else
            {
                //Отображаем только подтверждённые данные
                bindingSource_collection.Filter = "Url is Not Null";
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
                tabControl1.SelectedTab = tabPage_phone;
            }
            else tabControl1.TabPages.Remove(tabPage_phone);
        }

        /// <summary>
        /// Окно "Внести производителя, модель" для ручного ввода данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ВнестиПроизводителяМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertModelForm imf = new InsertModelForm();
            switch (imf.ShowDialog())
            {
                case DialogResult.Cancel:
                    label_tm.Text = "---";
                    label_model.Text = "---";
                    label_altname.Text = "---";
                    break;
                default:
                    label_tm.Text = "\"" + imf.comboBox_tm_insert.Text + "\""; //Если Производитель пришёл в кавычках, значит вводили вручную
                    label_model.Text = imf.textBox_model_insert.Text;
                    label_altname.Text = imf.textBox_alt_insert.Text;
                    break;
            }
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
        /// Запуск на выполнение выбранной в комбобоксе команды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ADB_comstart_Click(object sender, EventArgs e)
        {
            AdbClient client = new AdbClient();
            DeviceData device = Global_ADB_Device;
            string Com_String = textBox_ADB_commandstring.Text;
            try
            {
                if (radioButton_adb_IDs.Checked) GetADBIDs(false);
                if (radioButton_reboot_edl.Checked)
                {
                    textBox_soft_term.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                    client.Reboot("edl", device);
                    Thread.Sleep(500);
                    StopAdb();
                    tabControl_soft.SelectedTab = tabPage_sahara;
                }
                if (radioButton_adb_com.Checked && !string.IsNullOrEmpty(Com_String)) Adb_Comm_String(Com_String);
                if (radioButton_reboot_fastboot.Checked)
                {
                    textBox_soft_term.AppendText("Устройство перегружается в режим загрузчика" + Environment.NewLine);
                    client.Reboot("bootloader", device);
                    Thread.Sleep(500);
                    StopAdb();
                    tabControl_soft.SelectedTab = tabPage_fb;
                }
            }
            catch (SharpAdbClient.Exceptions.AdbException ex)
            {
                textBox_soft_term.AppendText(ex.AdbError + Environment.NewLine);
            }
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
                button_Sahara_CommandStart.Enabled = true;
                if (waitSahara)
                {
                    button_Sahara_Ids.Enabled = false;
                    GetSaharaIDs();
                }
            }
            else StartStatus();
        }

        /// <summary>
        /// Получаем идентификаторы устройства, переносим их на вкладку Работа с файлами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Sahara_Ids_Click(object sender, EventArgs e)
        {
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
            bool need_parsing_lun = false; //Необходимо ли парсить данные хранилища
            bool getgpt = false; //Необходимо ли получить таблицу GPT
            button_Sahara_Ids.Enabled = false;
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
            if (!FHAlreadyLoaded)
            {
                if (NeedReset)
                {
                    MessageBox.Show("Для получения идентификаторов устройство должно быть переподключено!" + Environment.NewLine +
                        "Пожалуйста, отключите устройство от компьютера, перезагрузите в аварийный режим (9008) и подключите повторно.", "Внимание!");

                    button_Sahara_Ids.Enabled = false;
                    button_Sahara_CommandStart.Enabled = false;
                    return;
                }
                process1.StartInfo.FileName = "QSaharaServer.exe";
                process1.StartInfo.Arguments = sahara_command_args.ToString();
                try
                {
                    process1.Start();
                    StreamReader reader1 = process1.StandardOutput;
                    textBox_soft_term.AppendText(reader1.ReadToEnd());
                    process1.WaitForExit();
                    process1.Close();
                    FHAlreadyLoaded = true;
                    NeedReset = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //После первой выполненной команды по получению инфо хранилища делаем доступным выбор других команд
            comboBox_fh_commands.Enabled = true;
            comboBox_lun_count.Enabled = true;
            groupBox_mem_type.Enabled = true;
            fh_command_args.Append(serialPort1.PortName);
            if (radioButton_mem_ufs.Checked) fh_command_args.Append(" --memoryname=ufs");
            else fh_command_args.Append(" --memoryname=emmc");
            if (radioButton_shortlog.Checked) fh_command_args.Append(" --loglevel=1");
            if (radioButton_fulllog.Checked) fh_command_args.Append(" --loglevel=2");
            int lun_int = 0;
            if (comboBox_lun_count.SelectedIndex != -1) lun_int = comboBox_lun_count.SelectedIndex;
            groupBox_LUN.Text = "Диск " + lun_int.ToString();
            switch (comboBox_fh_commands.SelectedIndex)
            {
                case 0:
                    textBox_soft_term.AppendText("Получаем информацию о запоминающем устройстве" + Environment.NewLine);
                    fh_command_args.Append(" --getstorageinfo=" + lun_int.ToString());
                    need_parsing_lun = true;
                    break;
                case 1:
                    textBox_soft_term.AppendText("Получаем таблицу разметки (GPT)" + Environment.NewLine);
                    fh_command_args.Append(string.Format(" --getgptmainbackup=gpt_main{0}.bin --lun={0}", lun_int.ToString()));
                    getgpt = true;
                    break;
                case 2:
                    textBox_soft_term.AppendText("Пишем/читаем байты по определённому адресу (peek&poke)" + Environment.NewLine);
                    Peekpoke pp = new Peekpoke(this);
                    switch (pp.ShowDialog())
                    {
                        case DialogResult.OK:
                            textBox_soft_term.AppendText("Работа с формой чтения/записи байт завершена." + Environment.NewLine);
                            if (File.Exists("work.xml"))
                            {
                                fh_command_args.Append(string.Format(" --sendxml=work.xml --search_path={0} --convertprogram2read --noprompt --showpercentagecomplete", Directory.GetCurrentDirectory()));
                            }
                            else textBox_soft_term.AppendText("XML-файл для работы не сформирован" + Environment.NewLine);
                            break;
                        case DialogResult.Cancel:
                            textBox_soft_term.AppendText("Форма чтения/записи байт закрыта без изменений." + Environment.NewLine);
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    textBox_soft_term.AppendText("Перегружаем устройство в нормальный режим" + Environment.NewLine);
                    fh_command_args.Append(" --noprompt --reset");
                    StartStatus();
                    break;
                default:
                    textBox_soft_term.AppendText("Получаем информацию о запоминающем устройстве" + Environment.NewLine);
                    fh_command_args.Append(" --getstorageinfo=" + lun_int.ToString());
                    need_parsing_lun = true;
                    break;
            }
            string output_FH = func.FH_Commands(fh_command_args.ToString());
            textBox_soft_term.AppendText(output_FH + Environment.NewLine);
            if (need_parsing_lun) NeedParsingLun(output_FH, lun_int);
            if (getgpt) GetGPT(lun_int);
        }

        private void NeedParsingLun(string output_FH, int lun_numder)
        {
            if (output_FH.Contains("TARGET SAID: '"))
            {
                string[] splitstr = { "TARGET SAID: '", "\n" };
                string[] parLun = output_FH.Split(splitstr, StringSplitOptions.RemoveEmptyEntries);
                int[] parsLUN_int = new int[] { 0, 0, 1, 0 }; //Значения по-умолчанию в случае некорректного парсинга
                List<string> goodparLun = new List<string>();
                //Обрезаем с конца все данные массива ответов таргет сэд
                foreach (string strparLun in parLun)
                {
                    if (strparLun.Contains("'")) goodparLun.Add(strparLun.Substring(0, strparLun.IndexOf("'")));
                }
                //Парсим ответ и раскидываем результат в массив
                foreach (string item in goodparLun)
                {
                    if (item.Length > 16)
                    {
                        string parstr;
                        string correct_pars_str = item;
                        if (item.StartsWith("INFO: ")) correct_pars_str = item.Substring(6);
                        switch (correct_pars_str.Substring(0, 16))
                        {
                            case "Device Total Log":
                                parstr = item.Substring(item.IndexOf(": ") + 2);
                                parsLUN_int.SetValue(Convert.ToInt32(parstr, 16), 0);
                                break;
                            case "num_partition_se":
                                parstr = item.Substring(item.IndexOf('=') + 1);
                                parsLUN_int.SetValue(Convert.ToInt32(parstr, 10), 0);
                                break;
                            case "Device Block Siz":
                                parstr = item.Substring(item.IndexOf(": ") + 2);
                                parsLUN_int.SetValue(Convert.ToInt32(parstr, 16), 1);
                                break;
                            case "SECTOR_SIZE_IN_B":
                                parstr = item.Substring(item.IndexOf('=') + 1);
                                parsLUN_int.SetValue(Convert.ToInt32(parstr, 10), 1);
                                break;
                            case "Device Total Phy":
                                parstr = item.Substring(item.IndexOf(": ") + 2);
                                int dtp = Convert.ToInt32(parstr, 16);
                                if (dtp <= 0) dtp = 1;
                                parsLUN_int.SetValue(dtp, 2);
                                break;
                            case "num_physical_par":
                                parstr = item.Substring(item.IndexOf('=') + 1);
                                parsLUN_int.SetValue(Convert.ToInt32(parstr, 10), 2);
                                break;
                            case "eMMC_RAW_DATA [0":
                                parsLUN_int.SetValue((int)Guide.MEM_TYPE.eMMC, 3);
                                break;
                            case "{\"storage_info\":":
                                parsLUN_int.SetValue((int)Guide.MEM_TYPE.eMMC, 3);
                                parstr = item.Substring(item.IndexOf("mem_type\":\"") + 11);
                                string m_type = parstr.Substring(0, parstr.IndexOf("\","));
                                if (m_type.Equals("UFS")) parsLUN_int.SetValue((int)Guide.MEM_TYPE.UFS, 3);
                                break;
                            default:
                                break;
                        }
                    }
                }
                //Заполняем данными глобальный массив дисков хранилища
                if (Flash_Params.Length < parsLUN_int[2]) Array.Resize<Flash_Disk>(ref Flash_Params, parsLUN_int[2]);
                for (int i = 0; i < Flash_Params.Length; i++)
                {
                    if (Flash_Params[i] == null) Flash_Params.SetValue(flash_start, i);
                }
                Flash_Disk disk = new Flash_Disk(parsLUN_int[0], parsLUN_int[1], parsLUN_int[2]);
                Flash_Params.SetValue(disk, lun_numder);
                if (comboBox_lun_count.Items.Count != Flash_Params[lun_numder].Count_Lun)
                {
                    comboBox_lun_count.Items.Clear();
                    for (int i = 0; i < Flash_Params[lun_numder].Count_Lun; i++)
                    {
                        comboBox_lun_count.Items.Add("Диск " + i.ToString());
                    }
                }
                //Переключаем выбор типа памяти
                switch (parsLUN_int[3])
                {
                    case (int)Guide.MEM_TYPE.eMMC:
                        radioButton_mem_emmc.Checked = true;
                        break;
                    case (int)Guide.MEM_TYPE.UFS:
                        radioButton_mem_ufs.Checked = true;
                        break;
                    default:
                        radioButton_mem_emmc.Checked = true;
                        break;
                }
                //При неправильном парсинге отправляем лог в канал при согласии пользователя.
                if (Flash_Params[lun_numder].Sector_Size == 0 && Flash_Params[lun_numder].Total_Sectors == 0)
                {
                    Flash_Params[lun_numder].Sector_Size = 512; //Чтоб отрабатывал парсинг GPT
                    DialogResult dr = MessageBox.Show("Ответ телефона на запрос данных хранилища обработан некорректно. " +
                        "Нажимая кнопку \"Ok\", вы разрешаете отправить в публичный телеграм-канал разрабтчикам лог ответа телефона для исправления этой ошибки. " +
                        "Кнопка \"Отмена\" просто закроет это окно, без отправки данных.",
                        "Внимание! Ошибка! Можно отправить данные?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.OK)
                    {
                        textBox_soft_term.AppendText("Отправка лога подтверждена пользователем." + Environment.NewLine);
                        BotSendMes(textBox_soft_term.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                    }
                }
                if (comboBox_lun_count.SelectedIndex != lun_numder) comboBox_lun_count.SelectedIndex = lun_numder;
                else
                {
                    label_total_blocks.Text = Flash_Params[lun_numder].Total_Sectors.ToString("### ### ### ##0");
                    label_block_size.Text = Flash_Params[lun_numder].Sector_Size.ToString();
                }
            }
        }

        private void GetGPT(int lun_number)
        {
            string gptmain = string.Format("gpt_main{0}.bin", lun_number.ToString());
            if (listView_GPT.Items.Count > 0) listView_GPT.Items.Clear();
            if (File.Exists(gptmain))
            {
                List<GPT_Table> gpt_array = func.Parsing_GPT_main(gptmain, Convert.ToInt32(label_block_size.Text));
                if (string.IsNullOrEmpty(gpt_array[0].EndLBA)) MessageBox.Show(gpt_array[0].StartLBA, "Ошибка обработки таблицы GPT");
                else //Заполняем листвью массивом итемов(разделов таблицы GPT)
                {
                    for (int i = 0; i < gpt_array.Count; i++)
                    {
                        ListViewItem gpt_item = new ListViewItem(gpt_array[i].StartLBA); //Это итем и сабитем0
                        gpt_item.SubItems.Add(gpt_array[i].EndLBA); //сабитем1
                        gpt_item.SubItems.Add(gpt_array[i].BlockName); //сабитем2
                        gpt_item.SubItems.Add(gpt_array[i].BlockLength); //сабитем3
                        gpt_item.SubItems.Add(gpt_array[i].BlockBytes); //сабитем4
                        listView_GPT.Items.Add(gpt_item);
                    }
                    label_total_gpt.Text = gpt_array.Count.ToString();
                }
            }
            else MessageBox.Show("Таблица GPT не сформирована");
        }

        /// <summary>
        /// Подсвечиваем/тушим кнопки терминала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_soft_term_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_soft_term.Text))
            {
                button_term_clear.Enabled = false;
                button_term_save.Enabled = false;
            }
            else
            {
                button_term_clear.Enabled = true;
                button_term_save.Enabled = true;
            }
        }

        /// <summary>
        /// Очищаем поле терминала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_term_clear_Click(object sender, EventArgs e)
        {
            textBox_soft_term.Text = string.Empty;
        }

        /// <summary>
        /// Сохраняем лог терминала в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_term_save_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(folderBrowserDialog1.SelectedPath + "\\log_terminal_soft_" + DateTime.Now.ToString("mm_ss") + ".txt", false)) sw.Write(textBox_soft_term.Text + "Сохранение лога прошло успешно" + Environment.NewLine);
                    textBox_soft_term.AppendText("Сохранение лога прошло успешно" + Environment.NewLine);
                    button_term_save.Enabled = false;
                }
                catch (Exception ex)
                {
                    textBox_soft_term.AppendText("Ошибка записи файла лога" + ex.Message + Environment.NewLine);
                }
            }
            else textBox_soft_term.AppendText("Сохранение отменено" + Environment.NewLine);
        }

        /// <summary>
        /// Отображаем/скрываем поле ввода команд ADB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_adb_com_CheckedChanged(object sender, EventArgs e)
        {
            button_ADB_comstart.Enabled = true;
            if (radioButton_adb_com.Checked) textBox_ADB_commandstring.Enabled = true;
            else textBox_ADB_commandstring.Enabled = false;
        }

        /// <summary>
        /// Активируем кнопку "Выполнить команду" при изменении переключателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_adb_IDs_CheckedChanged(object sender, EventArgs e)
        {
            button_ADB_comstart.Enabled = true;
        }

        /// <summary>
        /// Активируем кнопку "Выполнить команду" при изменении переключателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_reboot_edl_CheckedChanged(object sender, EventArgs e)
        {
            button_ADB_comstart.Enabled = true;
        }

        /// <summary>
        /// Выбор другого диска для операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_lun_count_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Sahara_Ids.Enabled = false;
            groupBox_LUN.Text = comboBox_lun_count.SelectedItem.ToString();
            label_block_size.Text = Flash_Params[comboBox_lun_count.SelectedIndex].Sector_Size.ToString();
            label_total_blocks.Text = Flash_Params[comboBox_lun_count.SelectedIndex].Total_Sectors.ToString("### ### ### ##0");
            label_total_gpt.Text = "0";
            label_select_gpt.Text = "0";
            listView_GPT.Items.Clear();
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
            button_useSahara_fhf.Enabled = false;
            toolStripStatusLabel_filescompleted.Text = string.Empty;
            toolStripStatusLabel_vol.Text = string.Empty;
            toolStripProgressBar_filescompleted.Value = 0;
            //Ищем локально или на сервере
            if (checkBox_Find_Local.Checked)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    button_path.Text = folderBrowserDialog1.SelectedPath;
                    Check_Unread_Files();
                }
            }
            if (checkBox_Find_Server.Checked)
            {
                object[] somerec = { false, "На сервере не нашлось", null, 0, null, null, null };
                //Делаем фильтр
                char[] filter_chr = { '0', '0', '0', '0' };
                if (!string.IsNullOrEmpty(textBox_hwid.Text)) filter_chr[0] = '1';
                if (!string.IsNullOrEmpty(textBox_oemid.Text)) filter_chr[1] = '1';
                if (!string.IsNullOrEmpty(textBox_modelid.Text)) filter_chr[2] = '1';
                if (!string.IsNullOrEmpty(textBox_oemhash.Text)) filter_chr[3] = '1';
                string filter_str = new string(filter_chr);
                switch (Convert.ToInt32(filter_str, 2))
                {
                    case 0:
                        bindingSource_firehose.Filter = null;
                        break;
                    case 1:
                        bindingSource_firehose.Filter = string.Format("HASH_FH LIKE '%{0}%'", textBox_oemhash.Text);
                        break;
                    case 2:
                        bindingSource_firehose.Filter = string.Format("MODEL_FH LIKE '%{0}%'", textBox_modelid.Text);
                        break;
                    case 3:
                        bindingSource_firehose.Filter = string.Format("MODEL_FH LIKE '%{0}%' AND HASH_FH LIKE '%{1}%'", textBox_modelid.Text, textBox_oemhash.Text);
                        break;
                    case 4:
                        bindingSource_firehose.Filter = string.Format("OEM_FH LIKE '%{0}%'", textBox_oemid.Text);
                        break;
                    case 5:
                        bindingSource_firehose.Filter = string.Format("OEM_FH LIKE '%{0}%' AND HASH_FH LIKE '%{1}%'", textBox_oemid.Text, textBox_oemhash.Text);
                        break;
                    case 6:
                        bindingSource_firehose.Filter = string.Format("OEM_FH LIKE '%{0}%' AND MODEL_FH LIKE '%{1}%'", textBox_oemid.Text, textBox_modelid.Text);
                        break;
                    case 7:
                        bindingSource_firehose.Filter = string.Format("OEM_FH LIKE '%{0}%' AND MODEL_FH LIKE '%{1}%' AND HASH_FH LIKE '%{2}%'", textBox_oemid.Text, textBox_modelid.Text, textBox_oemhash.Text);
                        break;
                    case 8:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%'", textBox_hwid.Text);
                        break;
                    case 9:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND HASH_FH LIKE '%{1}%'", textBox_hwid.Text, textBox_oemhash.Text);
                        break;
                    case 10:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND MODEL_FH LIKE '%{1}%'", textBox_hwid.Text, textBox_modelid.Text);
                        break;
                    case 11:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND MODEL_FH LIKE '%{1}%' AND HASH_FH LIKE '%{2}%'", textBox_hwid.Text, textBox_modelid.Text, textBox_oemhash.Text);
                        break;
                    case 12:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND OEM_FH LIKE '%{1}%'", textBox_hwid.Text, textBox_oemid.Text);
                        break;
                    case 13:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND OEM_FH LIKE '%{1}%' AND HASH_FH LIKE '%{2}%'", textBox_hwid.Text, textBox_oemid.Text, textBox_oemhash.Text);
                        break;
                    case 14:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND OEM_FH LIKE '%{1}%' AND MODEL_FH LIKE '%{2}%'", textBox_hwid.Text, textBox_oemid.Text, textBox_modelid.Text);
                        break;
                    case 15:
                        bindingSource_firehose.Filter = string.Format("HW_FH LIKE '%{0}%' AND OEM_FH LIKE '%{1}%' AND MODEL_FH LIKE '%{2}%' AND HASH_FH LIKE '%{3}%'", textBox_hwid.Text, textBox_oemid.Text, textBox_modelid.Text, textBox_oemhash.Text);
                        break;
                    default:
                        bindingSource_firehose.Filter = null;
                        break;
                }
                if (dataGridView_FInd_Server.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView_FInd_Server.Rows.Count; i++)
                    {
                        somerec[1] = dataGridView_FInd_Server["Url", i].Value.ToString();
                        somerec[2] = string.Format("{0}-{1}-{2}-{3}", dataGridView_FInd_Server["HW_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["OEM_FH", i].Value.ToString(), dataGridView_FInd_Server["MODEL_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["HASH_FH", i].Value.ToString().Substring(dataGridView_FInd_Server["HASH_FH", i].Value.ToString().Length - 8));
                        string[] id_str = {
                            dataGridView_FInd_Server["HW_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["OEM_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["MODEL_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["HASH_FH", i].Value.ToString(),
                            "3",
                            string.Empty
                        };
                        dataGridView_final.Rows.Insert(0, somerec);
                        dataGridView_final["Column_rate", 0].Value = 1 + Rating(id_str, 0);
                        dataGridView_final["Column_rate", 0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    toolStripStatusLabel_filescompleted.Text = "Обработано " + dataGridView_final.Rows.Count.ToString() + " файлов из " + dataGridView_final.Rows.Count.ToString();
                }
                else dataGridView_final.Rows.Insert(0, somerec);
            }
        }

        /// <summary>
        /// Выбираем программер для работы с устройством
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button__useSahara_fhf_Click(object sender, EventArgs e)
        {
            if (label_Sahara_fhf.Text.StartsWith("#"))
            {
                DialogResult dr = MessageBox.Show("При подтверждении, с сервера будет загружен программер. " +
                    "Это не гарантирует того, что у вас с этим программером всё получится. Просто " +
                    "это, с высокой долей вероятности, подходящий к выбранной вами модели файл.",
                    "Загрузка файла с сервера",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK) Process.Start(string.Format(label_Sahara_fhf.Text.Trim('#')));
            }
            else
            {
                работаСУстройствомToolStripMenuItem.Checked = true;
                tabControl1.SelectedTab = tabPage_phone;
                tabControl_soft.SelectedTab = tabPage_sahara;
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
            StringBuilder dumptext = new StringBuilder(string.Empty);
            if (FileToRead.Value > 4 && FileToRead.Value < 2000000000)
            {
                int len = Convert.ToInt32(FileToRead.Value);
                byte[] chunk = new byte[len];
                using (var stream = File.OpenRead(FileToRead.Key))
                {
                    int byteschunk = stream.Read(chunk, 0, 4);
                    for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                    if (Enum.IsDefined(typeof(Guide.FH_magic_numbers), Convert.ToUInt32(dumptext.ToString(), 16)))
                    {
                        dumptext.Clear();
                        stream.Position = 0;
                        byteschunk = stream.Read(chunk, 0, len);
                        for (int i = 0; i < byteschunk; i++) dumptext.Insert(i * 2, string.Format("{0:X2}", (int)chunk[i]));
                    }
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
                if (dumpfile.Length > 8)
                {
                    uint fh_type = Convert.ToUInt32(dumpfile.Substring(0, 8), 16);
                    switch ((Guide.FH_magic_numbers)fh_type)
                    {
                        case Guide.FH_magic_numbers.ELF: //ELF
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ELE: //не совсем ELF
                            curfilerating++;
                            dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                            dataGridView_final["Column_Name", Currnum].ToolTipText = "Файл не является ELF!";
                            break;
                        case Guide.FH_magic_numbers.OLD: //Старый программер
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.PATCHEDOLD: //Патченый старый программер
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ZTEEncode: //ZTE программер зашифрованный
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ARMPRG: //самый старый программер
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ARM9: //ARMPRG 9
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ARM412: //ARMPRG 0412
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ARM12: //ARMPRG 120001
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.ARM14: //ARMPRG 140000
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.UFSEncoding: //Закодированный UFS программер
                            curfilerating++;
                            dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                            dataGridView_final["Column_Name", Currnum].ToolTipText = "Файл закодирован!";
                            break;
                        case Guide.FH_magic_numbers.XiUFSEnc: //Xiaomi закодированный UFS программер
                            curfilerating++;
                            dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                            dataGridView_final["Column_Name", Currnum].ToolTipText = "Файл закодирован!";
                            break;
                        case Guide.FH_magic_numbers.OLDasus: //Старый Асус программер
                            curfilerating++;
                            break;
                        case Guide.FH_magic_numbers.OLDESTasus: //Ещё один старый Асус программер
                            curfilerating++;
                            break;
                        default: //совсем не шланг
                            break;
                    }
                }
                if (curfilerating != 0) //Увеличиваем рейтинг совпадениями поиска файла
                {
                    dataGridView_final["Column_rate", Currnum].Value = curfilerating + Rating(func.IDs(dumpfile), Currnum);
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

        /// <summary>
        /// При вводе хеша считаем количество символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_oemhash_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_oemhash.Text)) label_oemhash.Text = "OEM_PK" + Environment.NewLine + "_HASH";
            else label_oemhash.Text = "OEM_PK" + Environment.NewLine + "_HASH" + Environment.NewLine + "(" + textBox_oemhash.Text.Length.ToString() + " знаков)";
        }

        /// <summary>
        /// Ищем на локальном диске
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Find_Local_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Find_Local.Checked)
            {
                radioButton_topdir.Enabled = true;
                radioButton_alldir.Enabled = true;
                button_path.Enabled = true;
                if (checkBox_Find_Server.Checked) checkBox_Find_Server.Checked = false;
            }
            else
            {
                radioButton_topdir.Enabled = false;
                radioButton_alldir.Enabled = false;
                if (!checkBox_Find_Server.Checked) button_path.Enabled = false;
            }
        }

        /// <summary>
        /// Ищем на сервере (в файле XML)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Find_Server_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Find_Server.Checked)
            {
                button_path.Enabled = true;
                if (checkBox_Find_Local.Checked) checkBox_Find_Local.Checked = false;
            }
            else if (!checkBox_Find_Local.Checked) button_path.Enabled = false;
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
            label_model.Text = dataGridView_collection["Model", sel_row].Value.ToString();
            label_altname.Text = dataGridView_collection["AltName", sel_row].Value.ToString();
            tabControl1.SelectedTab = tabPage_firehose;
            //Загружаем программер с сервера
            if (!string.IsNullOrEmpty(dataGridView_collection["Url", sel_row].Value.ToString()))
            {
                DialogResult dr = MessageBox.Show("При подтверждении, с сервера будет загружен программер, который другие пользователи " +
                    "смогли успешно использовать. Это не гарантирует того, что у вас с этим программером всё получится. Просто " +
                    "это, с высокой долей вероятности, подходящий к выбранной вами модели файл.",
                    "Загрузка файла с сервера",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK) Process.Start(string.Format(dataGridView_collection["Url", sel_row].Value.ToString()).Trim('#'));
            }
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
                if (!ProofAllToolStripMenuItem.Checked) bindingSource_collection.Filter = "Url is Not Null";
                else bindingSource_collection.Filter = null;
            }
            else bindingSource_collection.Filter = string.Format("HWID LIKE '%{0}%' OR FullName LIKE '%{0}%' OR OEMID LIKE '%{0}%' OR MODELID LIKE '%{0}%' OR HASHID LIKE '%{0}%' OR Trademark LIKE '%{0}%' OR Model LIKE '%{0}%' OR AltName LIKE '%{0}%'", toolStripTextBox_find.Text);
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
            работаСУстройствомToolStripMenuItem.Checked = true;
            tabControl1.SelectedTab = tabPage_phone;
            tabControl_soft.SelectedTab = tabPage_sahara;
            работаСУстройствомToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Останавливаем сервер, очищаем поле, восстанавливаем доступы к контролам
        /// </summary>
        private void StopAdb()
        {
            AdbClient client = new AdbClient();
            button_ADB_start.Enabled = true;
            button_ADB_clear.Enabled = false;
            groupBox_adb_commands.Enabled = false;
            button_ADB_comstart.Enabled = false;
            if (listView_ADB_devices.Items.Count > 0)
            {
                listView_ADB_devices.Items.Clear();
                listView_ADB_devices.Enabled = false;
            }
            try
            {
                client.KillAdb();
                textBox_soft_term.AppendText("Сеанс ADB завершён" + Environment.NewLine);
                textBox_main_term.AppendText("Сеанс ADB завершён" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText("Неудачное завершение сеанса ADB" + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }

        /// <summary>
        /// Выполнение ADB команды из командной строки
        /// </summary>
        /// <param name="Com_String"></param>
        private void Adb_Comm_String(string Com_String)
        {
            AdbClient client = new AdbClient();
            var receiver = new ConsoleOutputReceiver();
            DeviceData device = Global_ADB_Device;
            textBox_soft_term.AppendText(Com_String + Environment.NewLine);
            textBox_ADB_commandstring.Text = string.Empty;
            try
            {
                client.ExecuteRemoteCommand(Com_String, device, receiver);
                textBox_soft_term.AppendText(receiver.ToString() + Environment.NewLine);
            }
            catch (SharpAdbClient.Exceptions.AdbException ex)
            {
                textBox_soft_term.AppendText(ex.AdbError + Environment.NewLine);
            }
        }

        /// <summary>
        /// Проверка заполнения грида прочтёнными файлами и запуск параллельного потока для непрочтённых
        /// </summary>
        private void Check_Unread_Files()
        {
            button_path.Enabled = false;
            Dictionary<string, long> Resfiles = func.WFiles(button_path.Text, radioButton_alldir.Checked); //Полный путь с именем файла и его объём для каждого файла в выбраной папке
            int currreadfiles = dataGridView_final.Rows.Count;
            int totalreadfiles = Resfiles.Count;
            toolStripStatusLabel_filescompleted.Text = "Обработано " + currreadfiles.ToString() + " файлов из " + totalreadfiles.ToString();
            //Либо 0, либо чтение всех файлов закончено, в грид всё добавлено - уходим
            if (currreadfiles == totalreadfiles)
            {
                button_path.Enabled = true;
                toolStripStatusLabel_vol.Text = string.Empty;
                toolStripProgressBar_filescompleted.Value = 0;
                if (currreadfiles > 0) dataGridView_final.Rows[0].Selected = true;
                return;
            }
            //Есть необработанные файлы - обрабатываем первый отсутствующий в цикле
            List<string> ReadedFiles = new List<string>(); //Создаём массив под список уже обработанных файлов
                                                           //Заполняем массив полными именами файлов из грида (если они есть)
            for (int i = 0; i < currreadfiles; i++) ReadedFiles.Add(dataGridView_final["Column_Name", i].Value.ToString().Trim());
            toolStripProgressBar_filescompleted.Value = currreadfiles * 100 / totalreadfiles; //Количество обработанных файлов в прогрессбаре
            dataGridView_final.Rows.Add();
            foreach (KeyValuePair<string, long> unreadfiles in Resfiles)
            {
                string shortfilename = Path.GetFileName(unreadfiles.Key); //Получили название файла
                if (!ReadedFiles.Contains(unreadfiles.Key))
                {
                    toolStripStatusLabel_vol.Text = "Сейчас обрабатывается файл - " + shortfilename;
                    statusStrip_firehose.Refresh();
                    dataGridView_final["Column_Name", currreadfiles].Value = unreadfiles.Key;
                    backgroundWorker_Read_File.RunWorkerAsync(unreadfiles); //Запускаем цикл обработки отдельно каждого необработанного файла в папке
                    break;
                }
            }
        }

        /// <summary>
        /// Список проверок для увеличения рейтинга файла и заполнения грида идентификаторами
        /// </summary>
        /// <param name="id_str">Строковый массив байт обработанного файла</param>
        /// <param name="Currnum">Номер текущей строки грида для добавления идентификаторов</param>
        private byte Rating(string[] id_str, int Currnum)
        {
            byte gross = 0; //Рейтинг файла
            string sw_type = string.Empty;
            string oemhash;
            if (id_str[3].Length < 8) oemhash = id_str[3];
            else oemhash = id_str[3].Substring(id_str[3].Length - 8);
            dataGridView_final["Column_id", Currnum].Value = id_str[0] + "-" + id_str[1] + "-" + id_str[2] + "-" + oemhash + "-" + id_str[4] + id_str[5];
            if (guide.SW_ID_type.ContainsKey(id_str[4])) sw_type = guide.SW_ID_type[id_str[4]];
            dataGridView_final["Column_SW_type", Currnum].Value = sw_type;
            dataGridView_final["Column_Full", Currnum].Value = "Jtag_ID (процессор) - " + id_str[0] + Environment.NewLine +
                "OEM_ID (производитель) - " + id_str[1] + Environment.NewLine +
                "MODEL_ID (модель) - " + id_str[2] + Environment.NewLine +
                "OEM_PK_HASH (хеш корневого сертификата) - " + id_str[3] + Environment.NewLine +
                "SW_ID (тип программы (версия)) - " + id_str[4] + id_str[5] + " - " + sw_type;
            if (guide.Double_CPU.ContainsKey(id_str[0])) //HWID два или более
            {
                StringBuilder comp_model = new StringBuilder(string.Empty);
                byte count = 1;
                foreach (string d_cpu_str in DOUBLE_CPU(id_str[0]))
                {
                    if (d_cpu_str.Equals(textBox_hwid.Text)) //Процессор такой же
                    {
                        textBox_hwid.BackColor = Color.LawnGreen;
                        gross++;
                    }
                    //Добавляем из справочника возможные модели для данного шланга "Может подойти для ..."
                    bindingSource_collection.Filter = string.Format("HWID = '{0}' AND OEMID = '{1}' AND MODELID = '{2}' AND HASHID = '{3}'",
                        d_cpu_str, id_str[1], id_str[2], id_str[3]);
                    if (dataGridView_collection.Rows.Count > 0) //Есть минимум одно устройство с такими идентификаторами
                    {
                        foreach (DataGridViewRow comp_row in dataGridView_collection.Rows)
                        {
                            if (count > 1) comp_model.Append("; ");
                            comp_model.Append(comp_row.Cells["Model"].Value.ToString());
                            count++;
                        }
                    }
                }
                dataGridView_final["Column_Comp", Currnum].Value = comp_model;
            }
            else //HWID единственный
            {
                StringBuilder comp_model = new StringBuilder(string.Empty);
                switch (id_str[0])
                {
                    case "00000000":
                        //Добавляем из справочника возможные модели для данного шланга "Может подойти для ..."
                        bindingSource_collection.Filter = string.Format("OEMID = '{0}' AND MODELID = '{1}' AND HASHID = '{2}'",
                            id_str[1], id_str[2], id_str[3]);

                        break;
                    default:
                        if (textBox_hwid.Text.Equals(id_str[0])) //Процессор такой же
                        {
                            textBox_hwid.BackColor = Color.LawnGreen;
                            gross++;
                        }
                        //Добавляем из справочника возможные модели для данного шланга "Может подойти для ..."
                        bindingSource_collection.Filter = string.Format("HWID = '{0}' AND OEMID = '{1}' AND MODELID = '{2}' AND HASHID = '{3}'",
                            id_str[0], id_str[1], id_str[2], id_str[3]);
                        break;
                }
                byte count = 1;
                if (dataGridView_collection.Rows.Count > 0) //Есть минимум одно устройство с такими идентификаторами
                {
                    foreach (DataGridViewRow comp_row in dataGridView_collection.Rows)
                    {
                        if (count > 1) comp_model.Append("; ");
                        comp_model.Append(comp_row.Cells["Model"].Value.ToString());
                        count++;
                    }
                }
                dataGridView_final["Column_Comp", Currnum].Value = comp_model;
            }
            if (textBox_oemid.Text.Equals(id_str[1])) // Производитель один и тот же
            {
                textBox_oemid.BackColor = Color.LawnGreen;
                gross++;
            }
            if (textBox_modelid.Text.Equals(id_str[2])) // Модели равны
            {
                textBox_modelid.BackColor = Color.LawnGreen;
                gross++;
            }
            if (id_str[3].Equals(textBox_oemhash.Text)) // Хеши равны
            {
                textBox_oemhash.BackColor = Color.LawnGreen;
                gross += 5;
            }
            if (id_str[4].Equals("3")) gross++; // SWID начинается с 3
            return gross;
        }

        /// <summary>
        /// Список дубликатов процессоров по указанному идентификатору
        /// </summary>
        /// <param name="hwid">Идентификатор процессора для поиска дублей</param>
        /// <returns>Список дубликатов</returns>
        private List<string> DOUBLE_CPU(string hwid)
        {
            string d_cpu_val = guide.Double_CPU[hwid];
            List<string> d_cpu_key = new List<string>();
            foreach (KeyValuePair<string, string> d_cpu in guide.Double_CPU)
            {
                if (d_cpu.Value.Equals(d_cpu_val)) d_cpu_key.Add(d_cpu.Key.ToString());
            }
            return d_cpu_key;
        }

        /// <summary>
        /// Проверяем корректность подключения устройства через запуск ADB
        /// </summary>
        /// <returns>true - всё хорошо, false - есть ошибки</returns>
        private bool ADB_Check()
        {
            button_ADB_clear.Enabled = true;
            //Стартуем сервер
            textBox_soft_term.AppendText("Запускаем сервер ADB ..." + Environment.NewLine);
            textBox_main_term.AppendText("Запускаем сервер ADB ..." + Environment.NewLine);
            AdbServer server = new AdbServer();
            StartServerResult result = server.StartServer("adb.exe", restartServerIfNewer: false);
            textBox_soft_term.AppendText(result.ToString() + Environment.NewLine);
            textBox_main_term.AppendText(result.ToString() + Environment.NewLine);
            //Подключаем клиента (устройства)
            AdbClient client = new AdbClient();
            List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
            //Заполнили листвью наименованием и транспортом
            foreach (DeviceData dev in devices)
            {
                ListViewItem viewItem = new ListViewItem(dev.Serial);
                viewItem.SubItems.Add(dev.Model);
                listView_ADB_devices.Items.Add(viewItem);
                if (!Connected_Devices.ContainsKey(dev.Serial)) Connected_Devices.Add(dev.Serial, dev.Model);
            }
            //Пометили первый попавшийся и активировали если больше одного
            if (listView_ADB_devices.Items.Count > 0)
            {
                listView_ADB_devices.Items[0].Checked = true;
                if (listView_ADB_devices.Items.Count > 1) listView_ADB_devices.Enabled = true;
            }
            button_ADB_start.Enabled = false;
            foreach (var device in devices)
            {
                textBox_soft_term.AppendText("Подключено устройство: " + device + Environment.NewLine);
                textBox_main_term.AppendText("Подключено устройство: " + device + Environment.NewLine);
            }
            if (devices.Count == 0)
            {
                textBox_soft_term.AppendText("Подключённых устройств не найдено. Пожалуйста, проверьте в настройках устройства разрешена ли \"Отладка по USB\" в разделе \"Система\" - \"Для разработчиков\"" + Environment.NewLine);
                textBox_main_term.AppendText("Подключённых устройств не найдено. Пожалуйста, проверьте в настройках устройства разрешена ли \"Отладка по USB\" в разделе \"Система\" - \"Для разработчиков\"" + Environment.NewLine);
                return false;
            }
            else
            {
                groupBox_adb_commands.Enabled = true;
                button_ADB_comstart.Enabled = true;
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
            DeviceData device = Global_ADB_Device;
            List<string> adbcommands = new List<string>() {
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
                    textBox_soft_term.AppendText(ex.AdbError + Environment.NewLine);
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
            label_altname.Text = results[0];
            label_tm.Text = results[1];
            label_model.Text = results[2];
            textBox_soft_term.AppendText("Производитель: " + label_tm.Text + Environment.NewLine +
                "Модель: " + label_model.Text + Environment.NewLine +
                "Альтернативное наименование: " + label_altname.Text + Environment.NewLine);
            textBox_main_term.AppendText("Производитель: " + label_tm.Text + Environment.NewLine +
                "Модель: " + label_model.Text + Environment.NewLine +
                "Альтернативное наименование: " + label_altname.Text + Environment.NewLine);
            if (reset)
            {
                textBox_soft_term.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                textBox_main_term.AppendText("Устройство перегружается в аварийный режим" + Environment.NewLine);
                try
                {
                    client.Reboot("edl", device);
                }
                catch (Exception ex)
                {
                    textBox_soft_term.AppendText(ex.Message + Environment.NewLine + "Автоматическая перезагрузка в аварийный режим 9008 из ADB закончилась неудачно. Попробуйте вручную." + Environment.NewLine);
                    textBox_main_term.AppendText(ex.Message + Environment.NewLine + "Автоматическая перезагрузка в аварийный режим 9008 из ADB закончилась неудачно. Попробуйте вручную." + Environment.NewLine);
                }
                Thread.Sleep(500);
                StopAdb();
            }
        }

        /// <summary>
        /// Получаем идентификаторы из Сахары
        /// </summary>
        private void GetSaharaIDs()
        {
            waitSahara = false;
            if (NeedReset)
            {
                MessageBox.Show("Для получения идентификаторов устройство должно быть переподключено!" + Environment.NewLine +
                    "Пожалуйста, отключите устройство от компьютера, перезагрузите в аварийный режим (9008) и подключите повторно.", "Внимание!");
                button_Sahara_Ids.Enabled = false;
                button_Sahara_CommandStart.Enabled = false;
                return;
            }
            //Выполняем запрос HWID-OEMID (command02, 03, 07)
            Process process = new Process();
            process.StartInfo.FileName = "QSaharaServer.exe";
            process.StartInfo.Arguments = "-p \\\\.\\" + serialPort1.PortName + " -c 1 -c 2 -c 3 -c 7";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            try
            {
                process.Start();
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();
                textBox_soft_term.AppendText(output);
                textBox_main_term.AppendText(output);
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NeedReset = true;
            //Обрабатываем запрос идентификаторов
            //textBox_soft_term.AppendText("Получили S/N устройства - " + func.SaharaCommand1() + Environment.NewLine);
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
                    switch (fr.ShowDialog())
                    {
                        case DialogResult.Cancel:
                            label_tm.Text = "---";
                            label_model.Text = "---";
                            label_altname.Text = "---";
                            toolStripStatusLabel_filescompleted.Text = "Не все идентификаторы получены, отправка данных отменена";
                            checkBox_send.Checked = false;
                            break;
                        default:
                            label_tm.Text = "\"" + fr.comboBox_tm_insert.Text + "\""; //Если Производитель пришёл в кавычках, значит вводили вручную
                            label_model.Text = fr.textBox_model_insert.Text;
                            label_altname.Text = fr.textBox_alt_insert.Text;
                            break;
                    }
                }
            }
            string logstr = label_tm.Text + "<>" + label_model.Text + "<>" + label_altname.Text + Environment.NewLine + textBox_hwid.Text + textBox_oemid.Text + textBox_modelid.Text + "<>" + textBox_oemhash.Text + "<>" + label_SW_Ver.Text;
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
            if (checkBox_send.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox_hwid.Text) && string.IsNullOrWhiteSpace(textBox_oemid.Text) &&
                    string.IsNullOrWhiteSpace(textBox_modelid.Text) && string.IsNullOrWhiteSpace(textBox_oemhash.Text))
                {
                    toolStripStatusLabel_filescompleted.Text = "Идентификаторы пусты. Нечего отправлять";
                }
                else CheckIDs(logstr);
            }
        }

        /// <summary>
        /// Проверяем все идентификаторы на наличие в Справочнике.
        /// </summary>
        public void CheckIDs(string send_string)
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
                    if (dataGridView_collection["Model", i].Value.ToString().Equals(label_model.Text)) //Проверяем модель на наличие
                    {
                        return;
                    }
                }
                //Исправить/добавить название/модель если 1 совпадает, а 2 нет
                BotSendMes("Добавить/исправить модель >" + send_string, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
            //Устройства нет, надо добавить в автосообщение
            else
            {
                if (!string.IsNullOrEmpty(textBox_hwid.Text) &&
                    !string.IsNullOrEmpty(textBox_oemid.Text) &&
                    !string.IsNullOrEmpty(textBox_modelid.Text) &&
                    !string.IsNullOrEmpty(textBox_oemhash.Text))
                {
                    BotSendMes("Добавить устройство >" + send_string, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                }
                else
                {
                    toolStripStatusLabel_filescompleted.Text = "Не все идентификаторы указаны. Пока не отправляем.";
                }
            }
        }

        /// <summary>
        /// Асинхронная операция отправки сообщения боту телеграма
        /// </summary>
        /// <param name="send_message"></param>
        /// <returns></returns>
        public void BotSendMes(string send_message, string version)
        {
            send_message += Environment.NewLine + version;
            //Экранируем запрещённые символы
            string message_not_mark = send_message.Replace("_", "\\_")
                .Replace("*", "\\*")
                .Replace("[", "\\[")
                .Replace("'", "\\'")
                .Replace("\"", "``");
            string correct_mess = message_not_mark;
            //Ограничение на размер сообщения. Оставляем только конец.
            if (message_not_mark.Length > 4096)
            {
                correct_mess = message_not_mark.Remove(0, message_not_mark.Length - 4092)
                    .Insert(0, "...");
            }
            var mybot = new TelegramBotApi.TelegramBotClient(Resources.bot);
            long chat = -1001227261414;
            try
            {
                mybot.SendTextMessage(chat, correct_mess);
                toolStripStatusLabel_filescompleted.Text = "Данные успешно отправлены";
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                //Отправляется, не смотря на косяк сериализации!
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText("Данные не отправлены." + ex.ToString() + Environment.NewLine + ex.Message + Environment.NewLine);
                MessageBox.Show(ex.Message, "Данные не отправлены - " + ex.ToString());
            }
            checkBox_send.Checked = false;
        }

        /// <summary>
        /// Возвращаем исходное состояние
        /// </summary>
        private void StartStatus()
        {
            button_Sahara_CommandStart.Enabled = false;
            button_Sahara_Ids.Enabled = false;
            groupBox_mem_type.Enabled = false;
            radioButton_mem_emmc.Checked = true;
            comboBox_lun_count.SelectedIndex = 0;
            comboBox_lun_count.Text = comboBox_lun_count.SelectedItem.ToString();
            comboBox_lun_count.Enabled = false;
            comboBox_fh_commands.SelectedIndex = 0;
            comboBox_fh_commands.Text = comboBox_fh_commands.SelectedItem.ToString();
            comboBox_fh_commands.Enabled = false;
            groupBox_LUN.Text = comboBox_lun_count.SelectedItem.ToString();
            label_block_size.Text = Flash_Params[comboBox_lun_count.SelectedIndex].Sector_Size.ToString();
            label_total_blocks.Text = Flash_Params[comboBox_lun_count.SelectedIndex].Total_Sectors.ToString("### ### ### ##0");
            label_total_gpt.Text = "0";
            label_select_gpt.Text = "0";
            contextMenuStrip_gpt.Items[4].Enabled = false;
            contextMenuStrip_gpt.Items[7].Enabled = false;
            listView_GPT.Items.Clear();
        }

        /// <summary>
        /// Очищаем список подключённых устройств
        /// </summary>
        private void ClearListViewDevices()
        {
            if (listView_ADB_devices.Items.Count > 0) listView_ADB_devices.Items.Clear();
            listView_ADB_devices.Enabled = false;
            button_ADB_comstart.Enabled = false;
            groupBox_adb_commands.Enabled = false;
            if (listView_fb_devices.Items.Count > 0) listView_fb_devices.Items.Clear();
            listView_fb_devices.Enabled = false;
            button_fb_com_start.Enabled = false;
            groupBox_fb_commands.Enabled = false;
        }

        #endregion

        private void ВыбратьВсеРазделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_GPT.Items)
            {
                item.Checked = true;
            }
        }

        private void СброситьВыборdeselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_GPT.Items)
            {
                item.Checked = false;
            }
        }

        private void ListView_GPT_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            label_select_gpt.Text = listView_GPT.CheckedItems.Count.ToString();
        }

        private void ВыбратьРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_GPT.SelectedItems)
            {
                if (item.Checked) item.Checked = false;
                else item.Checked = true;
            }
        }

        private void СохранитьТаблицуВФайлmainGPTbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("gpt_main0.bin"))
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        File.Copy("gpt_main0.bin", folderBrowserDialog1.SelectedPath + "\\gpt_main0.bin");
                        textBox_soft_term.AppendText("Сохранение файла таблицы разметки в выбранную папку прошло успешно." + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка записи файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else MessageBox.Show("Не найден базовый файл таблицы разметки - gpt_main0.bin", "Ошибка доступа к файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void СохранитьВыбранныеРазделыdumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обязательно убедитесь, что свободный размер диска больше суммарного объёма (всех выбранных разделов) сохраняемого дампа. " +
                "Иначе возможны ошибки при сохранении или в процесе дальнейшей работы с сохранёнными разделами.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (listView_GPT.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одного раздела для сохранения.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DumpBySectors(true, 0, 0);
        }

        private void Label_select_gpt_TextChanged(object sender, EventArgs e)
        {
            long selbytes = 0; //Размер выбранных секторов в байтах
            if (label_select_gpt.Text.Equals(listView_GPT.Items.Count.ToString())) contextMenuStrip_gpt.Items[7].Enabled = false;
            else
            {
                contextMenuStrip_gpt.Items[7].Enabled = true;
            }
            if (label_select_gpt.Text.Equals("0"))
            {
                contextMenuStrip_gpt.Items[5].Enabled = false;
                contextMenuStrip_gpt.Items[8].Enabled = false;
            }
            else
            {
                foreach (ListViewItem item in listView_GPT.CheckedItems)
                {
                    selbytes += Convert.ToInt64(item.SubItems[4].Text);
                }
                contextMenuStrip_gpt.Items[5].Enabled = true;
                contextMenuStrip_gpt.Items[8].Enabled = true;
            }
            label_GPT_bytes.Text = func.Bytes_KB_MB(selbytes.ToString());
        }

        /// <summary>
        /// Меняем статус кнопок меню при изменении количества доступных разделов GPT для слива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_total_gpt_TextChanged(object sender, EventArgs e)
        {
            if (label_total_gpt.Text.Equals("0"))
            {
                contextMenuStrip_gpt.Items[0].Enabled = false;
                contextMenuStrip_gpt.Items[1].Enabled = false;
                contextMenuStrip_gpt.Items[3].Enabled = false;
                contextMenuStrip_gpt.Items[5].Enabled = false;
                contextMenuStrip_gpt.Items[7].Enabled = false;
                contextMenuStrip_gpt.Items[8].Enabled = false;
            }
            else
            {
                contextMenuStrip_gpt.Items[0].Enabled = true;
                contextMenuStrip_gpt.Items[1].Enabled = true;
                contextMenuStrip_gpt.Items[3].Enabled = true;
                contextMenuStrip_gpt.Items[5].Enabled = true;
                contextMenuStrip_gpt.Items[7].Enabled = true;
            }
        }

        /// <summary>
        /// Меняем статус кнопок меню при изменении количества доступных секторов для слива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_total_blocks_TextChanged(object sender, EventArgs e)
        {
            if (Flash_Params[comboBox_lun_count.SelectedIndex].Total_Sectors == 0) contextMenuStrip_gpt.Items[4].Enabled = false;
            else contextMenuStrip_gpt.Items[4].Enabled = true;
        }

        private void СохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dump_Sectors dump = new Dump_Sectors(this);
            switch (dump.ShowDialog())
            {
                case DialogResult.OK:
                    DumpBySectors(false, Convert.ToInt32(dump.textBox_start_dump.Text), Convert.ToInt32(dump.textBox_count_dump.Text));
                    break;
                case DialogResult.Cancel:
                    textBox_soft_term.AppendText("Сохранение секторов отменено пользователем" + Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        private void DumpBySectors(bool ByBlocks, int StartSector, int NumSectors)
        {
            //Запускаем диалог сохранения папки
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                StringBuilder fh_all_args = new StringBuilder("--port=\\\\.\\");
                List<string> argsfordump = new List<string>(); //Необходимые данные для параллельного потока
                int lun_int = 0;
                fh_all_args.Append(serialPort1.PortName);
                fh_all_args.Append(" --convertprogram2read");
                if (comboBox_lun_count.SelectedIndex != -1) lun_int = comboBox_lun_count.SelectedIndex;
                fh_all_args.Append(string.Format(" --lun={0}", lun_int));
                fh_all_args.Append(" --noprompt --zlpawarehost=1"); // --showpercentagecomplete
                if (radioButton_mem_ufs.Checked) fh_all_args.Append(" --memoryname=ufs");
                else fh_all_args.Append(" --memoryname=emmc");
                switch (ByBlocks)
                {
                    case true: //Один или несколько запросов по именам разделов
                        foreach (ListViewItem item in listView_GPT.CheckedItems)
                        {
                            StringBuilder fh_mass_args = new StringBuilder(fh_all_args.ToString());
                            fh_mass_args.Append(string.Format(" --sendimage=dump_{0}", item.SubItems[2].Text));
                            fh_mass_args.Append(string.Format(" --start_sector={0}", Convert.ToInt32(item.SubItems[0].Text, 16)));
                            int NumSec = Convert.ToInt32(item.SubItems[1].Text, 16) - Convert.ToInt32(item.SubItems[0].Text, 16) + 1;
                            fh_mass_args.Append(string.Format(" --num_sectors={0}", NumSec));
                            argsfordump.Add(fh_mass_args.ToString());
                        }
                        break;
                    case false: //Один запрос по секторам
                        string newfilename = string.Format("dump_sectors{0}_{1}", StartSector, NumSectors);
                        fh_all_args.Append(" --sendimage=" + newfilename);
                        fh_all_args.Append(string.Format(" --start_sector={0}", StartSector));
                        fh_all_args.Append(string.Format(" --num_sectors={0}", NumSectors));
                        argsfordump.Add(fh_all_args.ToString());
                        break;
                    default:
                        break;
                }
                if (!backgroundWorker_dump.IsBusy) backgroundWorker_dump.RunWorkerAsync(argsfordump);
            }
        }

        private void BackgroundWorker_dump_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<string> do_str = new List<string>((List<string>)e.Argument);
            string dump_results = string.Empty; //Отчёт
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "fh_loader.exe";
            int count = 1;
            foreach (string str in do_str)
            {
                process.StartInfo.Arguments = str.ToString();
                string endoffilename = str.Remove(0, str.IndexOf("--sendimage=dump_") + 12);
                int endoffile = endoffilename.IndexOf(' ');
                string userState = endoffilename.Substring(0, endoffile); //Имя файла
                try
                {
                    process.Start();
                    StreamReader reader = process.StandardOutput;
                    string output_dump = reader.ReadToEnd();
                    dump_results += output_dump + Environment.NewLine;
                    process.WaitForExit();
                    worker.ReportProgress(count * 100 / do_str.Count, userState);
                    count++;
                }
                catch (Exception ex)
                {
                    dump_results += "Ошибка сохранения дампа" + Environment.NewLine + ex.Message + Environment.NewLine;
                }
            }
            process.Close();
            e.Result = dump_results;
            Thread.Sleep(1);
        }

        private void BackgroundWorker_dump_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string newfilename = e.UserState.ToString();
            progressBar_phone.Value = e.ProgressPercentage;
            textBox_soft_term.AppendText("Сохраняем " + newfilename + " ... ");
            if (File.Exists(newfilename))
            {
                try
                {
                    File.Copy(newfilename, folderBrowserDialog1.SelectedPath + "\\" + newfilename);
                }
                catch (IOException)
                {
                    File.Delete(folderBrowserDialog1.SelectedPath + "\\" + newfilename);
                    File.Copy(newfilename, folderBrowserDialog1.SelectedPath + "\\" + newfilename);
                }
                File.Delete(newfilename);
            }
            textBox_soft_term.AppendText("Готово." + Environment.NewLine);
        }

        private void BackgroundWorker_dump_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) textBox_soft_term.AppendText(e.Error.Message + Environment.NewLine);
            else
            {
                progressBar_phone.Value = 0;
                textBox_soft_term.AppendText(e.Result + Environment.NewLine + "Сохранение в выбранную папку прошло успешно." + Environment.NewLine);
            }
        }

        private bool FB_Check()
        {
            bool goodjob = false;
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "fastboot.exe";
            process.StartInfo.Arguments = "devices -l";
            textBox_soft_term.AppendText("Отправили: devices -l" + Environment.NewLine);
            try
            {

                process.Start();
                string normstr = process.StandardOutput.ReadToEnd();
                string errstr = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(normstr))
                {
                    Pars_FB_Dev(normstr);//Разбираем полученный массив на список устройств
                    textBox_soft_term.AppendText("Получили: " + normstr + Environment.NewLine);
                    goodjob = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(errstr))
                    {
                        Pars_FB_Dev(errstr);//Разбираем полученный массив на список устройств
                        textBox_soft_term.AppendText("Получили er: " + errstr + Environment.NewLine);
                        goodjob = true;
                    }
                }
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(ex.ToString() + Environment.NewLine + ex.Message + Environment.NewLine);
            }
            return goodjob;
        }

        /// <summary>
        /// Отправка команды в режиме загрузчика
        /// </summary>
        /// <param name="fb_command">Команда</param>
        private void Fastboot_commands(string fb_command)
        {
            Process process = new Process();
            string real_command = fb_command;
            if (!string.IsNullOrEmpty(Global_FB_Device)) real_command = "-s " + Global_FB_Device + " " + fb_command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "fastboot.exe";
            process.StartInfo.Arguments = real_command;
            textBox_soft_term.AppendText("Отправили: " + real_command + Environment.NewLine);
            try
            {
                process.Start();
                string exstr = process.StandardError.ReadToEnd();
                string normstr = process.StandardOutput.ReadToEnd();
                if (!string.IsNullOrEmpty(normstr)) textBox_soft_term.AppendText("Получили: " + normstr + Environment.NewLine);
                if (!string.IsNullOrEmpty(exstr)) textBox_soft_term.AppendText("Получили(ex): " + exstr + Environment.NewLine);
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(ex.ToString() + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }

        private void Pars_FB_Dev(string parsing_string)
        {
            string temp_str = parsing_string; //Временная строка для разбора
            if (listView_fb_devices.Items.Count > 0) listView_fb_devices.Items.Clear();
            Global_FB_Device = string.Empty;
            while (temp_str.Contains("fastboot"))
            {
                char[] for_trim = { ' ', '\t', '\n', '\r' };
                int cut_str = temp_str.IndexOf("fastboot");
                string fb_device = temp_str.Substring(0, cut_str).Trim(for_trim);
                if (!string.IsNullOrEmpty(fb_device))
                {
                    ListViewItem new_device = new ListViewItem(fb_device);
                    if (Connected_Devices.ContainsKey(fb_device)) new_device.SubItems.Add(Connected_Devices[fb_device]);
                    listView_fb_devices.Items.Add(new_device);
                }
                temp_str = temp_str.Substring(cut_str + 8);
            }
            if (listView_fb_devices.Items.Count > 0)
            {
                Global_FB_Device = listView_fb_devices.Items[0].Text;
                listView_fb_devices.Items[0].Checked = true;
                if (listView_fb_devices.Items.Count > 1)
                {
                    listView_fb_devices.Enabled = true;
                }
            }
        }

        private void Button_fb_check_Click(object sender, EventArgs e)
        {
            if (FB_Check())
            {
                button_fb_com_start.Enabled = true;
                groupBox_fb_commands.Enabled = true;
                if (listView_fb_devices.Items.Count > 1) listView_fb_devices.Enabled = true;
            }
        }

        private void Button_fb_com_start_Click(object sender, EventArgs e)
        {
            string Com_String = textBox_ADB_commandstring.Text;
            if (radioButton_fb_reboot_normal.Checked) Fastboot_commands("reboot");
            if (radioButton_fb_rebootbootloader.Checked) Fastboot_commands("reboot bootloader");
            if (radioButton_fb_rebootedl.Checked) Fastboot_commands("oem reboot-edl");
            if (radioButton_fb_getvar.Checked) Fastboot_commands("getvar all");
            if (radioButton_fb_devinfo.Checked) Fastboot_commands("oem device-info");
            if (radioButton_fb_unlock.Checked) Fastboot_commands("flashing unlock");
            if (radioButton_fb_lock.Checked) Fastboot_commands("flashing lock");
            if (radioButton_fb_commandline.Checked && !string.IsNullOrEmpty(Com_String)) Fastboot_commands(Com_String);
        }

        /// <summary>
        /// Оставляем столбец скрытым при попытке изменения размера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_GPT_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (listView_GPT.Columns[4].Width > 0) listView_GPT.Columns[4].Width = 0;
        }

        private void RadioButton_fb_commandline_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_fb_commandline.Checked) textBox_fb_commandline.Enabled = true;
            else
            {
                textBox_fb_commandline.Enabled = false;
                textBox_fb_commandline.Text = string.Empty;
            }
        }

        private void TextBox_fb_commandline_KeyUp(object sender, KeyEventArgs e)
        {
            string Com_String = textBox_fb_commandline.Text;
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(Com_String)) Fastboot_commands(Com_String);
        }

        /// <summary>
        /// Оставляем только один маркер на устройствах ADB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ADB_devices_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                AdbClient client = new AdbClient();
                List<DeviceData> devices = new List<DeviceData>(client.GetDevices());
                foreach (DeviceData dev in devices)
                {
                    if (dev.Serial.Equals(e.Item.Text)) Global_ADB_Device = dev;
                }
                foreach (ListViewItem item in listView_ADB_devices.Items)
                {
                    if (!item.Equals(e.Item)) item.Checked = false;
                }
            }
        }

        /// <summary>
        /// Оставляем только один маркер на устройствах Fastboot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_fb_devices_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                Global_FB_Device = e.Item.Text;
                foreach (ListViewItem item in listView_fb_devices.Items)
                {
                    if (!item.Text.Equals(e.Item.Text)) item.Checked = false;
                }
            }
        }

        /// <summary>
        /// Открываем данные раздела по дабл-клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_GPT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Select_Partition(listView_GPT.SelectedItems[0]);
        }

        /// <summary>
        /// Команда открытия данных раздела
        /// </summary>
        /// <param name="selected_item">Выбранный раздел</param>
        private void Select_Partition(ListViewItem selected_item)
        {
            //Сбросили выбор всех отмеченных галками разделов и открыли только один
            foreach (ListViewItem item in listView_GPT.CheckedItems)
            {
                item.Checked = false;
            }
            listView_GPT.SelectedItems[0].Checked = true;
            ManagePartition MP = new ManagePartition(this);
            MP.ShowDialog();
            switch (MP.button_MP_Cancel.Text)
            {
                case "Готово":
                    textBox_soft_term.AppendText("Работа с разделом " + MP.label_MP_Part.Text + " завершена." + Environment.NewLine);
                    if (MP.checkBox_MP_Reboot.Checked)
                    {
                        string fh_command_args = "--port=\\\\.\\" + serialPort1.PortName + " --noprompt --reset";
                        textBox_soft_term.AppendText(func.FH_Commands(fh_command_args) + Environment.NewLine);
                        StartStatus();
                    }
                    break;
                case "Отмена":
                    textBox_soft_term.AppendText("Форма работы с разделом " + MP.label_MP_Part.Text + " закрыта без изменений." + Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Открываем данные раздела по энтеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_GPT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Select_Partition(listView_GPT.SelectedItems[0]);
        }

        /// <summary>
        /// Открываем данные раздела из контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ОткрытьДанныеРазделавНовомОкнеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Select_Partition(listView_GPT.SelectedItems[0]);
        }

        /// <summary>
        /// Ставим галку на выбранной строке с программером
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_final_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!dataGridView_final.Rows[e.RowIndex].ReadOnly)
                {
                    if (Convert.ToBoolean(dataGridView_final["Column_Sel", e.RowIndex].Value) == true)
                    {
                        dataGridView_final["Column_Sel", e.RowIndex].Value = false;
                        button_useSahara_fhf.Enabled = false;
                        label_Sahara_fhf.Text = "Выберете программер на вкладке \"Работа с файлами\"";
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView_final.Rows.Count; i++)
                        {
                            dataGridView_final["Column_Sel", i].Value = false;
                        }
                        dataGridView_final["Column_Sel", e.RowIndex].Value = true;
                        button_useSahara_fhf.Enabled = true;
                        label_Sahara_fhf.Text = dataGridView_final.SelectedRows[0].Cells[1].Value.ToString();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //Просто игнорируем ошибку
            }
            catch (Exception ex)
            {
                textBox_main_term.AppendText(ex.Message + Environment.NewLine);
                textBox_soft_term.AppendText(ex.Message + Environment.NewLine);
            }
        }
    }
}
