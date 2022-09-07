using FirehoseFinder.Properties;
using Microsoft.Win32;
using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace FirehoseFinder
{
    public partial class Formfhf : Form
    {
        Func func = new Func(); //Подключили функции
        Guide guide = new Guide(); //Подключили справочник
        bool waitSahara = false; //Ждём ли мы автоперезагрузку с получением ID Sahara
        bool FHAlreadyLoaded = false; //Был ли успешно загружен программер (не надо грузить повторно)
        bool NeedReset = false; //Требуется ли перезагрузка устройства после работы с Сахарой
        Flash_Disk flash_start = new Flash_Disk(0, 0, 1);
        internal Flash_Disk[] Flash_Params = new Flash_Disk[1];
        internal DeviceData Global_ADB_Device = new DeviceData();
        internal string Global_FB_Device = string.Empty;
        internal string[][] Global_Share_Prog = new string[4][] //Массив данных для отправки программера
        {
            new string[8] { "ADB", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            new string[8] { "Sahara", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            new string[8] { "Loader", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty},
            new string[8] { "Programer", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty }
        };
        internal Dictionary<string, string> Connected_Devices = new Dictionary<string, string>(); //Список подключённых ADB устройств
        //Подтянули перевод на другие языки
        readonly ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);
        int ppc = 0; //Процент выполнения в параллельном процессе
        string output_FH = string.Empty; //Вывод результата работы лоадера в консоли на форму

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public Formfhf()
        {
            //Устанавливаем язык приложения
            if (!string.IsNullOrEmpty(Settings.Default.local_lang))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.local_lang);
            }
            InitializeComponent();
        }

        /// <summary>
        /// Отлавливаем подключение USB устройств. Перезапускаем скан доступных портов
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
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
                //Просто игнорируем ошибку
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
            dataGridView_collection.Columns["Trust"].Visible=false;
            dataGridView_collection.Columns["LASTKNOWNSBLVER"].HeaderText = "SW Ver";
            dataGridView_collection.Columns["HASHID"].HeaderText = "OEM Private Key Hash";
            dataGridView_collection.Columns["OEMID"].HeaderText = "OEM";
            dataGridView_collection.Columns["MODELID"].HeaderText = "Model";
            //Устанавливаем размер шрифта в Справочнике
            using (Font font = new Font(
                dataGridView_collection.DefaultCellStyle.Font.FontFamily, float.Parse(Settings.Default.db_font, CultureInfo.InvariantCulture)))
            {
                dataGridView_collection.DefaultCellStyle.Font = font;
            }
            toolStripLabel_font.Text=Settings.Default.db_font;
            //Закрываем специализированные закладки
            tabControl1.TabPages.Remove(tabPage_collection);
            tabControl1.TabPages.Remove(tabPage_phone);
            //Обнуляем глобальные переменные
            Flash_Params.SetValue(flash_start, 0);
            //Всплывающие подсказки к разным контролам
            toolTip1.SetToolTip(button_findIDs, LocRes.GetString("tt_find"));
            toolTip1.SetToolTip(button_path, LocRes.GetString("tt_path"));
            toolTip1.SetToolTip(button_useSahara_fhf, LocRes.GetString("tt_check"));
            CheckListPorts();
            //Открываем приветствие если новое или отмечено в настройках
            if (Settings.Default.CheckBox_start_Checked)
            {
                Greeting greeting = new Greeting();
                greeting.ShowDialog();
            }
            //Устанавливаем индикатор языка
            switch (Settings.Default.local_lang)
            {
                case "ru":
                    русскийToolStripMenuItem.Checked = true;
                    break;
                case "en":
                    englishToolStripMenuItem.Checked = true;
                    break;
                default:
                    автоматическиToolStripMenuItem.Checked = true;
                    break;
            }
            //Закрываем запущенные процессы и чистим файлы (если есть что)
            CleanFilesProcess();
        }

        /// <summary>
        /// При закрытии приложения подчищаем за собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formfhf_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save(); //Сохраняем настройки
            CleanFilesProcess(); //Очищаем рабочие файлы и запущенные процессы
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
                //Отображаем только подтверждённые данные
                string strfil = string.Format("Trust = '{0}'", "full trust");
                if (реальноПодключённыеУстройстваToolStripMenuItem.Checked)
                {
                    strfil+=string.Format(" AND Trust = '{0}'", "real dev");
                }
                if (устройстваСПрограммерамиToolStripMenuItem.Checked)
                {
                    strfil+=string.Format(" AND Url is Not Null");
                }
                bindingSource_collection.Filter = strfil;
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage_collection);
                реальноПодключённыеУстройстваToolStripMenuItem.Checked = false;
                устройстваСПрограммерамиToolStripMenuItem.Checked = false;
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
            InsertModelForm imf = new InsertModelForm(this);
            switch (imf.ShowDialog())
            {
                case DialogResult.Cancel:
                    Global_Share_Prog[0][1] = string.Empty;
                    label_tm.Text = "---";
                    Global_Share_Prog[0][2] = string.Empty;
                    label_model.Text = "---";
                    Global_Share_Prog[0][3] = string.Empty;
                    label_altname.Text = "---";
                    Global_Share_Prog[0][4] = string.Empty;
                    label_chip_sn.Text = "---";
                    Global_Share_Prog[0][5] = string.Empty;
                    break;
                default:
                    label_tm.Text = imf.comboBox_tm_insert.Text;
                    label_model.Text = imf.textBox_model_insert.Text;
                    label_altname.Text = imf.textBox_alt_insert.Text;
                    Global_Share_Prog[0][2] = label_tm.Text;
                    Global_Share_Prog[0][3] = label_model.Text;
                    Global_Share_Prog[0][4] = label_altname.Text;
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
            string helppath = Application.StartupPath;
            switch (Settings.Default.local_lang)
            {
                case "en":
                    helppath+="\\Resources\\help_en.pdf";
                    break;
                default:
                    helppath+="\\Resources\\help_ru.pdf";
                    break;
            }
            ProcessStartInfo psin = new ProcessStartInfo(helppath);
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
                    textBox_soft_term.AppendText(LocRes.GetString("tb_reboot") + '\u0020' +
                        LocRes.GetString("hex_in") + '\u0020' +
                        LocRes.GetString("tb_edl") + '\u0020' +
                        Environment.NewLine);
                    client.Reboot("edl", device);
                    Thread.Sleep(500);
                    StopAdb();
                    tabControl_soft.SelectedTab = tabPage_sahara;
                }
                if (radioButton_adb_com.Checked && !string.IsNullOrEmpty(Com_String)) Adb_Comm_String(Com_String);
                if (radioButton_reboot_fastboot.Checked)
                {
                    textBox_soft_term.AppendText(LocRes.GetString("tb_reboot") + '\u0020' +
                        LocRes.GetString("hex_in") + '\u0020' +
                        LocRes.GetString("tb_blm") + '\u0020' +
                        Environment.NewLine);
                    client.Reboot("bootloader", device);
                    Thread.Sleep(500);
                    StopAdb();
                    tabControl_soft.SelectedTab = tabPage_fb;
                }
            }
            catch (SharpAdbClient.Exceptions.AdbException ex)
            {
                textBox_soft_term.AppendText(ex.AdbError + Environment.NewLine);
                SendErrorInChat();
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
            StringBuilder sahara_command_args = new StringBuilder("-u " + serialPort1.PortName.Remove(0, 3) + " -s 13:");
            StringBuilder fh_command_args = new StringBuilder("--port=\\\\.\\" + serialPort1.PortName + " --noprompt");
            bool need_parsing_lun = false; //Необходимо ли парсить данные хранилища
            bool getgpt = false; //Необходимо ли получить таблицу GPT
            button_Sahara_Ids.Enabled = false;
            output_FH=string.Empty;
            int counter_backgroung = 0;
            if (!File.Exists(label_Sahara_fhf.Text))
            {
                DialogResult dr = MessageBox.Show(LocRes.GetString("mb_note_sel_prog"),
                    LocRes.GetString("mb_title_sel_prog"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.OK) tabControl1.SelectedTab = tabPage_firehose;
                return;
            }
            sahara_command_args.Append(label_Sahara_fhf.Text);
            switch (comboBox_log.SelectedIndex)
            {
                case 0:
                    sahara_command_args.Append(" -v 0");
                    fh_command_args.Append(" --loglevel=1");
                    break;
                case 1:
                    sahara_command_args.Append(" -v 0");
                    fh_command_args.Append(" --loglevel=0");
                    break;
                case 2:
                    sahara_command_args.Append(" -v 1");
                    fh_command_args.Append(" --loglevel=2");
                    break;
                case 3:
                    sahara_command_args.Append(" -v 2");
                    fh_command_args.Append(" --loglevel=3");
                    break;
                default:
                    sahara_command_args.Append(" -v 0");
                    fh_command_args.Append(" --loglevel=1");
                    break;
            }
            if (!FHAlreadyLoaded)
            {
                if (NeedReset)
                {
                    MessageBox.Show(LocRes.GetString("mb_note_dev_recon") +
                        Environment.NewLine +
                        LocRes.GetString("mb_note_dev_recon2"),
                        LocRes.GetString("mb_title_dev_recon"));

                    button_Sahara_Ids.Enabled = false;
                    button_Sahara_CommandStart.Enabled = false;
                    return;
                }
                process_Sahara.StartInfo.Arguments = sahara_command_args.ToString();
                try
                {
                    process_Sahara.Start();
                    StreamReader reader = process_Sahara.StandardOutput;
                    StreamReader erread = process_Sahara.StandardError;
                    string output = string.Empty;
                    if (reader.Peek() >= 0) output = reader.ReadToEnd();
                    if (erread.Peek() >= 0) output = "er: " + erread.ReadToEnd();
                    textBox_soft_term.AppendText(output + Environment.NewLine);
                    process_Sahara.WaitForExit();
                    process_Sahara.Close();
                    FHAlreadyLoaded = true;
                    NeedReset = true;
                }
                catch (Exception ex)
                {
                    textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                    SendErrorInChat();
                }
            }
            //После первой выполненной команды по получению инфо хранилища делаем доступным выбор других команд
            comboBox_fh_commands.Enabled = true;
            comboBox_lun_count.Enabled = true;
            comboBox_log.Enabled = true;
            int lun_int = 0;
            if (comboBox_lun_count.SelectedIndex != -1) lun_int = comboBox_lun_count.SelectedIndex;
            groupBox_LUN.Text = LocRes.GetString("gb_disk") + '\u0020' + lun_int.ToString();
            //Выбираем тип памяти для лоадера
            if (radioButton_mem_ufs.Checked) fh_command_args.Append(" --memoryname=ufs");
            else fh_command_args.Append(" --memoryname=emmc");
            Peekpoke pp = new Peekpoke(this);
            switch (comboBox_fh_commands.SelectedIndex)
            {
                case 0: //Информация хранилища
                    textBox_soft_term.AppendText(LocRes.GetString("tbs_stor_dev") + Environment.NewLine);
                    fh_command_args.Append(" --getstorageinfo=" + lun_int.ToString());
                    need_parsing_lun = true;
                    if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                    break;
                case 1: //Получить таблицу разметки
                    textBox_soft_term.AppendText(LocRes.GetString("tbs_part_table") + Environment.NewLine);
                    fh_command_args.Append(" --getgptmainbackup=" + lun_int.ToString());
                    getgpt = true;
                    if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                    break;
                case 2: //Перезагрузка устройства
                    textBox_soft_term.AppendText(LocRes.GetString("tb_reboot") + '\u0020' +
                        LocRes.GetString("hex_in") + '\u0020' +
                        LocRes.GetString("tb_norm") + Environment.NewLine);
                    fh_command_args.Append(" --reset");
                    if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                    StartStatus();
                    break;
                //case 3 - разделитель "Внимание, запись!"
                case 4: //Запись секторов
                    textBox_soft_term.AppendText(LocRes.GetString("tb_write_file_sectors") + Environment.NewLine);
                    Write_Sectors ws = new Write_Sectors(this);
                    if (ws.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            //Определяем путь к файлу
                            string loadpath = openFileDialog1.FileName.Remove(openFileDialog1.FileName.IndexOf(openFileDialog1.SafeFileName) - 1);
                            if (loadpath.Contains('\u0020'))
                            {
                                textBox_soft_term.AppendText(LocRes.GetString("mb_title_att") + Environment.NewLine);
                                MessageBox.Show(LocRes.GetString("mb_body_att_spaces"),
                                    LocRes.GetString("mb_title_att"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                                break;
                            }
                            //Определяем последний сектор для записи
                            uint lastsec = Convert.ToUInt32(ws.textBox_start_ws.Text, 16) + Convert.ToUInt32(ws.textBox_count_ws.Text, 10) - 1;
                            //Создаём xml-файл для записи
                            func.FhXmltoRW(
                                false,
                                ws.textBox_secsize_ws.Text,
                                openFileDialog1.SafeFileName,
                                ws.textBox_disk_ws.Text,
                                ws.textBox_start_ws.Text,
                                Convert.ToString(lastsec, 16));
                            //Создаём аргументы для лоадера и при наличии файла запускаем процесс записи
                            if (File.Exists("p_r.xml"))
                            {
                                fh_command_args.Append(" --sendxml=p_r.xml --search_path=" + loadpath);
                                if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                            }
                        }
                        else textBox_soft_term.AppendText(LocRes.GetString("tb_write_cancel") + Environment.NewLine);
                    }
                    else textBox_soft_term.AppendText(LocRes.GetString("tb_write_cancel") + Environment.NewLine);
                    break;
                case 5: //Пакетная запись прошивки
                    textBox_soft_term.AppendText(LocRes.GetString("tb_batch_record") + Environment.NewLine);
                    RawProgramForm rp = new RawProgramForm();
                    switch (rp.ShowDialog())
                    {
                        case DialogResult.OK:
                            if (!string.IsNullOrEmpty(rp.label_raw_patch.Text) && !string.IsNullOrEmpty(rp.label_path.Text))
                            {
                                fh_command_args.Append(" --sendxml=" + rp.label_raw_patch.Text +
                                    " --search_path=" + rp.label_path.Text +
                                    " --showpercentagecomplete --zlpawarehost=1");
                                if (radioButton_mem_ufs.Checked) fh_command_args.Append(" --setactivepartition=1");
                                else fh_command_args.Append(" --setactivepartition=0");
                                if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args);
                            }
                            break;
                        case DialogResult.Cancel:
                            textBox_soft_term.AppendText(LocRes.GetString("tb_cancel_user") + Environment.NewLine);
                            break;
                        default:
                            break;
                    }
                    break;
                case 6: //Стереть выбранный диск полностью
                    textBox_soft_term.AppendText(LocRes.GetString("tb_er_mem") + Environment.NewLine);
                    if (MessageBox.Show(LocRes.GetString("tb_body_att_del_mem"),
                        LocRes.GetString("tb_note_att_del_mem"),
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2,
                        MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        fh_command_args.Append(" --erase=" + lun_int.ToString());
                        if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                    }
                    else textBox_soft_term.AppendText(LocRes.GetString("tb_er_mem") + '\u0020' +
                        LocRes.GetString("tb_cancel_user") + Environment.NewLine);
                    break;
                case 7: //Читать/писать IMEM
                    textBox_soft_term.AppendText(LocRes.GetString("tb_pp") + Environment.NewLine);
                    switch (pp.ShowDialog())
                    {
                        case DialogResult.OK:
                            if (File.Exists("work.xml"))
                            {
                                fh_command_args.Append(string.Format(" --sendxml=work.xml --search_path={0}", Directory.GetCurrentDirectory()));
                                if (pp.radioButton_peek.Checked) fh_command_args.Append(" --convertprogram2read");
                            }
                            else textBox_soft_term.AppendText(LocRes.GetString("tb_xml_not_gen") + Environment.NewLine);
                            textBox_soft_term.AppendText(LocRes.GetString("tb_form_comp") + Environment.NewLine);
                            if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                            break;
                        case DialogResult.Cancel:
                            textBox_soft_term.AppendText(LocRes.GetString("tb_form_close") + Environment.NewLine);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    textBox_soft_term.AppendText(LocRes.GetString("tbs_stor_dev") + Environment.NewLine);
                    fh_command_args.Append(" --getstorageinfo=" + lun_int.ToString());
                    need_parsing_lun = true;
                    if (!backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.RunWorkerAsync(fh_command_args.ToString());
                    break;
            }
            //Притормозим основной поток пока не выполнится асинхрон
            while (backgroundWorker_rawprogram.IsBusy)
            {
                counter_backgroung++;
                if (counter_backgroung>100) counter_backgroung=100;
                progressBar_phone.Value = counter_backgroung;
                Thread.Sleep(1200);
                Application.DoEvents();
            }
            counter_backgroung=0;
            progressBar_phone.Value=counter_backgroung;
            if (need_parsing_lun) NeedParsingLun(output_FH, lun_int);
            if (getgpt) GetGPT(lun_int);
            if (pp.checkBox_output.Checked)
            {
                string peektofile = pp.checkBox_output.Text;
                uint bytecontrol = Convert.ToUInt32(pp.textBox_peek_cb.Text, 16);
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(peektofile)))
                {
                    writer.Write(func.Parse_peek_res(output_FH, bytecontrol));
                }
            }
        }

        /// <summary>
        /// Выполняется при необходимости разбора ответа памяти (хранилища)
        /// </summary>
        /// <param name="output_FH">Ответ хранилища</param>
        /// <param name="lun_numder">Номер диска хранилища</param>
        private void NeedParsingLun(string output_FH, int lun_numder)
        {
            if (output_FH.Contains("TARGET SAID: '"))
            {
                string[] splitstr = { "TARGET SAID: '", "\n" };
                string[] parLun = output_FH.Split(splitstr, StringSplitOptions.RemoveEmptyEntries);
                /*Значения по-умолчанию в случае некорректного парсинга
                 * 
                 * 1 (0) - всего блоков для выбранного диска
                 * 2 (0) - размер блока в байтах (512 или 4096)
                 * 3 (1) - всего логических дисков
                 * 4 (0) - тип памяти (еммс - 0, ufs - 1)
                 */
                int[] parsLUN_int = new int[] { 0, 0, 1, 0 };
                List<string> goodparLun = new List<string>();
                //Отрезаем с конца все данные массива ответов таргет сэд по символу '
                foreach (string strparLun in parLun)
                {
                    //if (strparLun.Contains("'")) goodparLun.Add(strparLun.Substring(0, strparLun.IndexOf("'")));
                    if (strparLun.Contains('\u0027')) goodparLun.Add(strparLun.Remove(strparLun.LastIndexOf('\u0027')));
                }
                //Парсим ответ и раскидываем результат в массив
                foreach (string item in goodparLun)
                {
                    if (item.Length > 23)
                    {
                        string parstr;
                        string correct_pars_str = item;
                        if (item.StartsWith("INFO: ")) correct_pars_str = item.Substring(6); //Если строка ответа устройства начинается с инфо
                        if (item.StartsWith("ERROR: ")) correct_pars_str = item.Substring(7); //Если строка ответа начинается с еррор
                        try
                        {
                            switch (correct_pars_str.Substring(0, 16))
                            {
                                //Всего блоков для выбранного диска
                                case "Device Total Log":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf(": ") + 2);
                                    parsLUN_int.SetValue(Convert.ToInt32(parstr, 16), 0);
                                    break;
                                case "num_partition_se":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf('=') + 1);
                                    parsLUN_int.SetValue(Convert.ToInt32(parstr, 10), 0);
                                    break;
                                //Размер блока
                                case "Device Block Siz":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf(": ") + 2);
                                    parsLUN_int.SetValue(Convert.ToInt32(parstr, 16), 1);
                                    break;
                                case "SECTOR_SIZE_IN_B":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf('=') + 1);
                                    parsLUN_int.SetValue(Convert.ToInt32(parstr, 10), 1);
                                    break;
                                //Количество дисков
                                case "Device Total Phy":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf(": ") + 2);
                                    int dtp = Convert.ToInt32(parstr, 16);
                                    if (dtp <= 0) dtp = 1;
                                    parsLUN_int.SetValue(dtp, 2);
                                    break;
                                case "num_physical_par":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf('=') + 1);
                                    parsLUN_int.SetValue(Convert.ToInt32(parstr, 10), 2);
                                    break;
                                //Тип памяти
                                case "eMMC_RAW_DATA [0":
                                    parsLUN_int.SetValue((int)Guide.MEM_TYPE.eMMC, 3);
                                    break;
                                case "{\"storage_info\":":
                                    parsLUN_int.SetValue((int)Guide.MEM_TYPE.eMMC, 3);
                                    parstr = item.Substring(item.IndexOf("mem_type\":\"") + 11);
                                    string m_type = parstr.Substring(0, parstr.IndexOf("\","));
                                    if (m_type.Equals("UFS")) parsLUN_int.SetValue((int)Guide.MEM_TYPE.UFS, 3);
                                    break;
                                case "Chip serial num:":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf("(0x") + 3, 8);
                                    Global_Share_Prog[2][5] = parstr.ToUpper();
                                    break;
                                case "Device Serial Nu":
                                    parstr = correct_pars_str.Substring(correct_pars_str.IndexOf(": 0x") + 4, 8);
                                    Global_Share_Prog[2][1] = parstr.ToUpper();
                                    break;
                                //Ошибки
                                //Используется программер с авторизацией
                                case "Only nop and sig":
                                    //if (item.EndsWith("authentication."))
                                    //{
                                    textBox_soft_term.AppendText(LocRes.GetString("auth_body") + Environment.NewLine);
                                    parsLUN_int.SetValue(512, 1); //Чтоб корректно отрабатывало ошибку
                                    MessageBox.Show(LocRes.GetString("auth_body"), LocRes.GetString("auth_title"));
                                    //}
                                    break;
                                //Неправильно выбран тип памяти (еммс вместо ufs)
                                case "Failed to open d":
                                    textBox_soft_term.AppendText(LocRes.GetString("mb_body_memtype") + Environment.NewLine);
                                    parsLUN_int.SetValue(4096, 1); //Чтоб корректно отрабатывало ошибку
                                    MessageBox.Show(LocRes.GetString("mb_body_memtype"), LocRes.GetString("mb_title_mis"));
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                            SendErrorInChat();
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
                        comboBox_lun_count.Items.Add(LocRes.GetString("gb_disk") + '\u0020' + i.ToString());
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
                    SendErrorInChat();
                    StartStatus(); //Отменяем возможность выполнения других операций 
                }
                else
                {
                    //Проверяем наличие программера в базе и если его нет, то предлагаем поделиться
                    if (ProgNoServer())
                    {
                        отправкаПрограммераToolStripMenuItem.Enabled = true;
                        MessageBox.Show("Похоже, что выбранный вами программер отработал успешно и при этом он отсутствует в базе данных." +
                            " Если есть желание поделиться этим программером, добавив его в базу данных, пожалуйста перейдите в окно отправки программера в чат сейчас или после завершения текущей работы." +
                            " В окне \"Поделиться программером\" из меню \"Вид\" необходимо заполнить все недостающие данные модели вручную или автоматически для корректной привязки программера к модели.");
                    }
                    if (comboBox_lun_count.SelectedIndex != lun_numder) comboBox_lun_count.SelectedIndex = lun_numder;
                    else
                    {
                        label_total_blocks.Text = Flash_Params[lun_numder].Total_Sectors.ToString("### ### ### ##0");
                        label_block_size.Text = Flash_Params[lun_numder].Sector_Size.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Сравниваем программеры на сервере с программером пользователя
        /// </summary>
        /// <returns>false - Программер есть на сервере, true - Программера нет на сервере</returns>
        private bool ProgNoServer()
        {
            if (dataGridView_FInd_Server.Rows.Count > 0)
            {
                //Собираем строки сервера по маске грида
                List<string> serverprogs = new List<string>();
                for (int i = 0; i < dataGridView_FInd_Server.Rows.Count; i++)
                {
                    string swtype = "3";
                    string swver = string.Empty;
                    if (!string.IsNullOrEmpty(dataGridView_FInd_Server["SWType", i].Value.ToString())) swtype = dataGridView_FInd_Server["SWType", i].Value.ToString();
                    if (!string.IsNullOrEmpty(dataGridView_FInd_Server["SWVer", i].Value.ToString())) swver = "(" + dataGridView_FInd_Server["SWVer", i].Value.ToString() + ")";
                    string somerec = string.Format("{0}-{1}-{2}-{3}-{4}", dataGridView_FInd_Server["HW_FH", i].Value.ToString(),
                        dataGridView_FInd_Server["OEM_FH", i].Value.ToString(),
                        dataGridView_FInd_Server["MODEL_FH", i].Value.ToString(),
                        dataGridView_FInd_Server["HASH_FH", i].Value.ToString().Substring(dataGridView_FInd_Server["HASH_FH", i].Value.ToString().Length - 8),
                        swtype + swver);
                    serverprogs.Add(somerec);
                }
                if (serverprogs.Contains(dataGridView_final.SelectedRows[0].Cells[2].Value.ToString())) return false; //Программер есть на сервере
                else return true; //Программера нет на сервере
            }
            else return true; //Программера нет на сервере
        }

        /// <summary>
        /// Получаем таблицу GPT для диска
        /// </summary>
        /// <param name="lun_number">Номер диска</param>
        private void GetGPT(int lun_number)
        {
            string gptmain = string.Format("gpt_main{0}.bin", lun_number.ToString());
            if (listView_GPT.Items.Count > 0) listView_GPT.Items.Clear();
            if (File.Exists(gptmain))
            {
                List<GPT_Table> gpt_array = func.Parsing_GPT_main(gptmain, Convert.ToInt32(label_block_size.Text));
                if (string.IsNullOrEmpty(gpt_array[0].EndLBA)) MessageBox.Show(gpt_array[0].StartLBA, LocRes.GetString("mb_body_er_gpt"));
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
            else MessageBox.Show(LocRes.GetString("mb_body_gpt_not_formed"));
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
                    using (StreamWriter sw = new StreamWriter(folderBrowserDialog1.SelectedPath + "\\log_terminal_soft_" + DateTime.Now.ToString("mm_ss") + ".txt", false))
                        sw.Write(textBox_soft_term.Text +
                            LocRes.GetString("tb_save") + '\u0020' +
                            LocRes.GetString("tb_log") + '\u0020' +
                            LocRes.GetString("tb_pass_suc") + Environment.NewLine);
                    textBox_soft_term.AppendText(LocRes.GetString("tb_save") + '\u0020' +
                            LocRes.GetString("tb_log") + '\u0020' +
                            LocRes.GetString("tb_pass_suc") + Environment.NewLine);
                    button_term_save.Enabled = false;
                }
                catch (Exception ex)
                {
                    textBox_soft_term.AppendText(LocRes.GetString("tb_er_write") + '\u0020' +
                        LocRes.GetString("tb_log") + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                    SendErrorInChat();
                }
            }
            else textBox_soft_term.AppendText(LocRes.GetString("tb_save") + '\u0020' +
                    LocRes.GetString("tb_cancel_user") + Environment.NewLine);
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

        /// <summary>
        /// Выбор всех разделов таблицы GPT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ВыбратьВсеРазделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_GPT.Items)
            {
                item.Checked = true;
            }
            сохранитьВыбранныйРазделToolStripMenuItem.Enabled = false;
            записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Сбросить выбор всех разделов таблицы GPT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СброситьВыборdeselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_GPT.Items)
            {
                item.Checked = false;
            }
            сохранитьВыбранныйРазделToolStripMenuItem.Enabled = false;
            записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Выбор элемента в списке разделов таблицы GPT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_GPT_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int cp = listView_GPT.CheckedItems.Count;
            label_select_gpt.Text = cp.ToString();
            if (cp == 1)
            {
                сохранитьВыбранныйРазделToolStripMenuItem.Enabled = true;
                записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = true;
            }
            else
            {
                сохранитьВыбранныйРазделToolStripMenuItem.Enabled = false;
                записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Выбор единичного раздела в списке разделов таблицы GPT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ВыбратьРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_GPT.Items)
            {
                item.Checked = false;
            }
            listView_GPT.SelectedItems[0].Checked = true;
            сохранитьВыбранныйРазделToolStripMenuItem.Enabled = true;
            записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Сохраняем таблицу GPT и бэкап в файлы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СохранитьТаблицуВФайлmainGPTbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lunnum = comboBox_lun_count.SelectedIndex;
            string gptmain = string.Format("gpt_main{0}.bin", lunnum);
            string gptbackup = string.Format("gpt_backup{0}.bin", lunnum);
            if (File.Exists(gptmain) && File.Exists(gptbackup))
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(gptmain, folderBrowserDialog1.SelectedPath + "\\" + gptmain);
                        File.Copy(gptbackup, folderBrowserDialog1.SelectedPath + "\\" + gptbackup);
                        textBox_soft_term.AppendText(LocRes.GetString("tb_gpt_save") + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                        SendErrorInChat();
                    }
                }
            }
            else MessageBox.Show(LocRes.GetString("gpt_not_found"),
                LocRes.GetString("mb_acc_er") + '\u0020' +
                LocRes.GetString("file"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Запускаем процедуру сохранения выбранных разделов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СохранитьВыбранныеРазделыdumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LocRes.GetString("free_space"),
                LocRes.GetString("warn"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            if (listView_GPT.CheckedItems.Count == 0)
            {
                MessageBox.Show(LocRes.GetString("no_part_sel"),
                    LocRes.GetString("warn"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            DumpBySectors(true, 0, 0);
        }

        /// <summary>
        /// Активизируем пункты меню в зависимости от количества выбранных разделов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_select_gpt_TextChanged(object sender, EventArgs e)
        {
            long selbytes = 0; //Размер выбранных секторов в байтах
            if (label_select_gpt.Text.Equals(listView_GPT.Items.Count.ToString())) contextMenuStrip_gpt.Items[7].Enabled = false;
            else contextMenuStrip_gpt.Items[7].Enabled = true;
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
                contextMenuStrip_gpt.Items[2].Enabled = false;
                contextMenuStrip_gpt.Items[3].Enabled = false;
                contextMenuStrip_gpt.Items[5].Enabled = false;
                contextMenuStrip_gpt.Items[7].Enabled = false;
                contextMenuStrip_gpt.Items[8].Enabled = false;
            }
            else
            {
                contextMenuStrip_gpt.Items[0].Enabled = true;
                contextMenuStrip_gpt.Items[2].Enabled = true;
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

        /// <summary>
        /// Открываем форму для сохранения секторов по номеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dump_Sectors dump = new Dump_Sectors(this);
            switch (dump.ShowDialog())
            {
                case DialogResult.OK:
                    DumpBySectors(false, Convert.ToInt32(dump.textBox_start_dump.Text), Convert.ToInt32(dump.textBox_count_dump.Text));
                    break;
                case DialogResult.Cancel:
                    textBox_soft_term.AppendText(LocRes.GetString("tb_save") + '\u0020' +
                        LocRes.GetString("sectors") + '\u0020' +
                        LocRes.GetString("tb_cancel_user") + Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        private void BackgroundWorker_dump_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<string> do_str = new List<string>((List<string>)e.Argument);
            output_FH = string.Empty; //Обнуляем строку вывода консоли
            int count = 1;
            foreach (string str in do_str)
            {
                string endoffilename = str.Remove(0, str.IndexOf("--sendimage=dump_") + 12);
                int endoffile = endoffilename.IndexOf(".bin");
                string userState = endoffilename.Substring(0, endoffile + 4); //Имя файла
                FH_Commands(str.ToString());
                worker.ReportProgress(count * 100 / do_str.Count, userState);
                count++;
            }
            e.Result = output_FH;
            Thread.Sleep(1);
        }

        private void BackgroundWorker_dump_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string newfilename = e.UserState.ToString();
            progressBar_phone.Value = e.ProgressPercentage;
            textBox_soft_term.AppendText(LocRes.GetString("tb_save") + '\u0020' + newfilename + " ... ");
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
            textBox_soft_term.AppendText(LocRes.GetString("done") + Environment.NewLine);
        }

        private void BackgroundWorker_dump_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) textBox_soft_term.AppendText(e.Error.Message + Environment.NewLine);
            else
            {
                progressBar_phone.Value = 0;
                textBox_soft_term.AppendText(e.Result + Environment.NewLine +
                    LocRes.GetString("tb_save") + '\u0020' +
                    LocRes.GetString("hex_in") + '\u0020' +
                    LocRes.GetString("sel_fold") + '\u0020' +
                    LocRes.GetString("tb_pass_suc") + Environment.NewLine);
            }
        }

        /// <summary>
        /// Активизируем кнопку и группу при удачном подключении устройства в режиме загрузчика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_fb_check_Click(object sender, EventArgs e)
        {
            if (FB_Check())
            {
                button_fb_com_start.Enabled = true;
                groupBox_fb_commands.Enabled = true;
                if (listView_fb_devices.Items.Count > 1) listView_fb_devices.Enabled = true;
            }
        }

        /// <summary>
        /// Выполняем команду в зависимости от выбранного контрола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Активируем или закрываем форму ввода вручную команды для режима загрузчика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_fb_commandline_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_fb_commandline.Checked) textBox_fb_commandline.Enabled = true;
            else
            {
                textBox_fb_commandline.Enabled = false;
                textBox_fb_commandline.Text = string.Empty;
            }
        }

        /// <summary>
        /// Отправляем команду на выполнение по энтеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Сохраняем таблицу разметки в формате XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СохранитьТаблицуВФорматеCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmldecl;
                int lunnum = comboBox_lun_count.SelectedIndex;
                string gptfile = "gpt" + lunnum.ToString();
                StringBuilder xmlgpt = new StringBuilder("<" + gptfile + ">");
                xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                foreach (ListViewItem item in listView_GPT.Items)
                {
                    xmlgpt.Append("<Name name=\"" + item.SubItems[2].Text + "\">");
                    xmlgpt.Append("<StartLBA>" + item.SubItems[0].Text + "</StartLBA>");
                    xmlgpt.Append("<EndLBA>" + item.SubItems[1].Text + "</EndLBA>");
                    xmlgpt.Append("<Blocks>" + item.SubItems[3].Text + "</Blocks>");
                    xmlgpt.Append("<Bytes>" + item.SubItems[4].Text + "</Bytes>");
                    xmlgpt.Append("</Name>");
                }
                xmlgpt.Append("</" + gptfile +">");
                doc.LoadXml(xmlgpt.ToString());
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmldecl, root);
                try
                {
                    doc.Save(saveFileDialog1.FileName);
                    textBox_soft_term.AppendText(LocRes.GetString("tb_gpt_save") + Environment.NewLine);
                }
                catch (XmlException ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, LocRes.GetString("er_func_xml"));
                }
            }
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
                MessageBox.Show(LocRes.GetString("mb_body_check_fail") + Environment.NewLine +
                    LocRes.GetString("mb_body_corr_er"),
                    LocRes.GetString("mb_title_adb_er"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (radioButton_adb_reset.Checked) GetADBIDs(true);
            if (radioButton_man_reset.Checked)
            {
                GetADBIDs(false);
                if (label_model.Text.StartsWith("---")) MessageBox.Show(LocRes.GetString("mb_body_id_not_res"),
                    LocRes.GetString("mb_title_reboot"));
                else MessageBox.Show(LocRes.GetString("mb_body_id_res"),
                    LocRes.GetString("mb_title_reboot"));
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
            toolStripStatusLabel_dowork.Text = string.Empty;
            toolStripProgressBar_filescompleted.Value = 0;
            //Ищем локально или на сервере
            if (checkBox_Find_Local.Checked)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    button_path.Text = folderBrowserDialog1.SelectedPath;
                    Check_Unread_Files();
                }
            }
            if (checkBox_Find_Server.Checked)
            {
                object[] somerec = { false, //Выбор
                    LocRes.GetString("server_not_found"), //Файл
                    null, //Набор идентификаторов
                    0, //Рейтинг
                    null, //Полный ИД (скрыто)
                    null, //Тип ПО
                    null }; //Может подойти
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
                        string swtype = "3";
                        string swver = string.Empty;
                        if (!string.IsNullOrEmpty(dataGridView_FInd_Server["SWType", i].Value.ToString())) swtype = dataGridView_FInd_Server["SWType", i].Value.ToString();
                        if (!string.IsNullOrEmpty(dataGridView_FInd_Server["SWVer", i].Value.ToString())) swver = "(" + dataGridView_FInd_Server["SWVer", i].Value.ToString() + ")";
                        somerec[1] = dataGridView_FInd_Server["Url", i].Value.ToString();
                        somerec[2] = string.Format("{0}-{1}-{2}-{3}-{4}", dataGridView_FInd_Server["HW_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["OEM_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["MODEL_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["HASH_FH", i].Value.ToString().Substring(dataGridView_FInd_Server["HASH_FH", i].Value.ToString().Length - 8),
                            swtype + swver);
                        string[] id_str = {
                            dataGridView_FInd_Server["HW_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["OEM_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["MODEL_FH", i].Value.ToString(),
                            dataGridView_FInd_Server["HASH_FH", i].Value.ToString(),
                            swtype,
                            swver};
                        dataGridView_final.Rows.Insert(0, somerec);
                        dataGridView_final["Column_rate", 0].Value = 1 + Rating(id_str, 0);
                        dataGridView_final["Column_rate", 0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        toolStripProgressBar_filescompleted.Value = i * 100 / dataGridView_FInd_Server.Rows.Count;
                    }
                    toolStripStatusLabel_filescompleted.Text = LocRes.GetString("hex_processed") + '\u0020' +
                        dataGridView_final.Rows.Count.ToString() + '\u0020'+
                        LocRes.GetString("hex_files")+ '\u0020'+
                        LocRes.GetString("hex_from")+ '\u0020'+
                        dataGridView_final.Rows.Count.ToString();
                }
                else dataGridView_final.Rows.Insert(0, somerec);
                toolStripProgressBar_filescompleted.Value = 0;
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
                DialogResult dr = MessageBox.Show(LocRes.GetString("mb_body_server_down"),
                    LocRes.GetString("mb_title_server_down"),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                if (dr == DialogResult.OK) Process.Start(string.Format(label_Sahara_fhf.Text.Trim('#')));
            }
            else
            {
                работаСУстройствомToolStripMenuItem.Checked = true;
                tabControl1.SelectedTab = tabPage_phone;
                tabControl_soft.SelectedTab = tabPage_sahara;
                if (label_Sahara_fhf.Text.Contains('\u0020'))
                {
                    textBox_soft_term.AppendText(LocRes.GetString("mb_title_att") + Environment.NewLine);
                    MessageBox.Show(LocRes.GetString("mb_body_att_spaces"),
                        LocRes.GetString("mb_title_att"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                Global_Share_Prog[3][6] = dataGridView_final.SelectedRows[0].Cells[2].Value.ToString();
                Global_Share_Prog[3][7] = label_Sahara_fhf.Text;
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
                DialogResult dr = MessageBox.Show(dataGridView_final["Column_Full", e.RowIndex].Value.ToString(),
                    LocRes.GetString("mb_body_save_clip"),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
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
                            dataGridView_final["Column_Name", Currnum].ToolTipText = LocRes.GetString("file") + '\u0020' +
                                LocRes.GetString("not_elf");
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
                            dataGridView_final["Column_Name", Currnum].ToolTipText = LocRes.GetString("file") + '\u0020' +
                                LocRes.GetString("encode");
                            break;
                        case Guide.FH_magic_numbers.XiUFSEnc: //Xiaomi закодированный UFS программер
                            curfilerating++;
                            dataGridView_final.Rows[Currnum].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                            dataGridView_final["Column_Name", Currnum].ToolTipText = LocRes.GetString("file") + '\u0020' +
                                LocRes.GetString("encode");
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
            else label_oemhash.Text = "OEM_PK" + Environment.NewLine +
                    "_HASH" + Environment.NewLine + '\u0028' +
                    textBox_oemhash.Text.Length.ToString() + '\u0020' +
                    LocRes.GetString("signs") + '\u0029';
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
                if (checkBox_Find_Server.Checked) checkBox_Find_Server.Checked = false;
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
                checkBox_Find_Local.Checked = false;
                radioButton_topdir.Enabled = false;
                radioButton_alldir.Enabled = false;
                button_path.Text = LocRes.GetString("button_search");
            }
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
                        label_Sahara_fhf.Text = LocRes.GetString("sel_prog");
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
                textBox_main_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                SendErrorInChat();
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
            label_model.Text = dataGridView_collection["Model", sel_row].Value.ToString();
            label_altname.Text = dataGridView_collection["AltName", sel_row].Value.ToString();
            Global_Share_Prog[0][2] = label_tm.Text;
            Global_Share_Prog[0][3] = label_model.Text;
            Global_Share_Prog[0][4] = label_altname.Text;
            tabControl1.SelectedTab = tabPage_firehose;
            //Загружаем программер с сервера
            if (!string.IsNullOrEmpty(dataGridView_collection["Url", sel_row].Value.ToString()))
            {
                DialogResult dr = MessageBox.Show(LocRes.GetString("mb_body_server_down"),
                    LocRes.GetString("mb_title_server_down"),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
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
            string strfil = string.Format("Trust = '{0}'", "full trust");
            if (string.IsNullOrEmpty(toolStripTextBox_find.Text))
            {
                if (реальноПодключённыеУстройстваToolStripMenuItem.Checked)
                {
                    strfil="Trust is Not Null";
                }
                if (устройстваСПрограммерамиToolStripMenuItem.Checked)
                {
                    strfil+=string.Format(" AND Url is Not Null");
                }
            }
            else strfil = string.Format("HWID LIKE '%{0}%' OR FullName LIKE '%{0}%' OR OEMID LIKE '%{0}%' OR MODELID LIKE '%{0}%' OR HASHID LIKE '%{0}%' OR Trademark LIKE '%{0}%' OR Model LIKE '%{0}%' OR AltName LIKE '%{0}%'", toolStripTextBox_find.Text);
            bindingSource_collection.Filter = strfil;
            for (int i = 0; i < dataGridView_collection.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dataGridView_collection["Trust", i].Value.ToString())) dataGridView_collection.Rows[i].DefaultCellStyle.BackColor=Color.IndianRed;
            }
        }

        /// <summary>
        /// Уменьшаем размер шрифта в Справочнике на 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButton_small_font_Click(object sender, EventArgs e)
        {
            float newsizefont = float.Parse(Settings.Default.db_font, CultureInfo.InvariantCulture) - 1;
            if (newsizefont<1) newsizefont=1;
            //Устанавливаем размер шрифта в Справочнике
            using (Font font = new Font(
                dataGridView_collection.DefaultCellStyle.Font.FontFamily, newsizefont))
            {
                dataGridView_collection.DefaultCellStyle.Font = font;
            }
            toolStripLabel_font.Text = Convert.ToInt32(newsizefont).ToString();
            Settings.Default.db_font = toolStripLabel_font.Text;
        }

        /// <summary>
        /// Увеличиваем размер шрифта в Справочнике на 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripButton_large_font_Click(object sender, EventArgs e)
        {
            float newsizefont = float.Parse(Settings.Default.db_font, CultureInfo.InvariantCulture)+1;
            if (newsizefont>20) newsizefont=20;
            //Устанавливаем размер шрифта в Справочнике
            using (Font font = new Font(
                dataGridView_collection.DefaultCellStyle.Font.FontFamily, newsizefont))
            {
                dataGridView_collection.DefaultCellStyle.Font = font;
            }
            toolStripLabel_font.Text=Convert.ToInt32(newsizefont).ToString();
            Settings.Default.db_font = toolStripLabel_font.Text;
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
                    textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                    SendErrorInChat();
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
                textBox_soft_term.AppendText(LocRes.GetString("tb_adb_sess") + '\u0020' +
                    LocRes.GetString("tb_compl") + Environment.NewLine);
                textBox_main_term.AppendText(LocRes.GetString("tb_adb_sess") + '\u0020' +
                    LocRes.GetString("tb_compl") + Environment.NewLine);
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(LocRes.GetString("tb_compl_fail") + '\u0020' +
                    LocRes.GetString("tb_adb_sess") + Environment.NewLine +
                    ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                SendErrorInChat();
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
                SendErrorInChat();
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
            toolStripStatusLabel_filescompleted.Text = LocRes.GetString("hex_processed") + '\u0020' +
                currreadfiles.ToString() + '\u0020' +
                LocRes.GetString("hex_files") + '\u0020' +
                LocRes.GetString("hex_from") + '\u0020' +
                totalreadfiles.ToString();
            //Либо 0, либо чтение всех файлов закончено, в грид всё добавлено - уходим
            if (currreadfiles == totalreadfiles)
            {
                button_path.Enabled = true;
                toolStripStatusLabel_dowork.Text = string.Empty;
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
                    toolStripStatusLabel_dowork.Text = LocRes.GetString("tt_proc") + '\u0020' +
                        LocRes.GetString("file") + '\u0020' + '\u002D' + '\u0020' +
                        shortfilename;
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
            dataGridView_final["Column_id", Currnum].Value = id_str[0] + '\u002D' + id_str[1] + '\u002D' + id_str[2] + '\u002D' + oemhash + '\u002D' + id_str[4] + id_str[5];
            if (guide.SW_ID_type.ContainsKey(id_str[4])) sw_type = guide.SW_ID_type[id_str[4]];
            dataGridView_final["Column_SW_type", Currnum].Value = sw_type;
            dataGridView_final["Column_Full", Currnum].Value = "Jtag_ID (" + LocRes.GetString("chip") + ") - " + id_str[0] + Environment.NewLine +
                "OEM_ID (" + LocRes.GetString("manuf") + ") - " + id_str[1] + Environment.NewLine +
                "MODEL_ID (" + LocRes.GetString("model") + ") - " + id_str[2] + Environment.NewLine +
                "OEM_PK_HASH (" + LocRes.GetString("hash") + '\u0020' +
                id_str[3].Length.ToString() + '\u0020' +
                LocRes.GetString("signs") + ") - " + id_str[3] + Environment.NewLine +
                "SW_ID (" + LocRes.GetString("sw_ver") + ") - " + id_str[4] + id_str[5] + " - " + sw_type;
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
            textBox_soft_term.AppendText(LocRes.GetString("tb_adb_start") + Environment.NewLine);
            textBox_main_term.AppendText(LocRes.GetString("tb_adb_start") + Environment.NewLine);
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
                textBox_soft_term.AppendText(LocRes.GetString("tb_dev_con") + '\u0020' + device + Environment.NewLine);
                textBox_main_term.AppendText(LocRes.GetString("tb_dev_con") + '\u0020' + device + Environment.NewLine);
            }
            if (devices.Count == 0)
            {
                textBox_soft_term.AppendText(LocRes.GetString("tb_dev_not_con") + Environment.NewLine);
                textBox_main_term.AppendText(LocRes.GetString("tb_dev_not_con") + Environment.NewLine);
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
                "getprop | grep ro.product.model",
                "cat /sys/bus/soc/devices/soc0/serial_number"};
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
                    SendErrorInChat();
                }
            }
            string[] adbstr = receiver.ToString().Split('\u000A'); //Перевод строки
            long chipsn = 0;
            foreach (string item in adbstr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item.Length<14) chipsn = Convert.ToInt64(item);
                    else
                    {
                        int start = item.LastIndexOf('\u005B')+1; //[
                        int end = item.LastIndexOf('\u005D'); //]
                        switch (item.Substring(0, 14))
                        {
                            case "[ro.product.ma":
                                label_tm.Text = item.Substring(start, end-start);
                                break;
                            case "[ro.product.mo":
                                label_model.Text = item.Substring(start, end-start);
                                break;
                            case "[ro.product.na":
                                label_altname.Text = item.Substring(start, end-start);
                                break;
                            default:
                                try
                                {
                                    chipsn = Convert.ToInt64(item);
                                }
                                catch (FormatException)
                                {
                                    chipsn=0;
                                }
                                break;
                        }
                    }
                }
            }
            if (chipsn==0) label_chip_sn.Text = "---";
            else label_chip_sn.Text = Convert.ToString(chipsn, 16).ToUpper();
            textBox_soft_term.AppendText(LocRes.GetString("manuf") + '\u003A' + '\u0020' + label_tm.Text + Environment.NewLine +
                LocRes.GetString("model") + '\u003A' + '\u0020' + label_model.Text + Environment.NewLine +
                LocRes.GetString("alt_name") + '\u003A' + '\u0020' + label_altname.Text + Environment.NewLine +
                LocRes.GetString("chip_sn") + '\u003A' + '\u0020' + label_chip_sn.Text + Environment.NewLine);
            textBox_main_term.AppendText(LocRes.GetString("manuf") + '\u003A' + '\u0020' + label_tm.Text + Environment.NewLine +
                LocRes.GetString("model") + '\u003A' + '\u0020' + label_model.Text + Environment.NewLine +
                LocRes.GetString("alt_name") + '\u003A' + '\u0020' + label_altname.Text + Environment.NewLine +
                LocRes.GetString("chip_sn") + '\u003A' + '\u0020' + label_chip_sn.Text + Environment.NewLine);
            Global_Share_Prog[0][1] = device.Serial.ToUpper();
            Global_Share_Prog[0][2] = label_tm.Text;
            Global_Share_Prog[0][3] = label_model.Text;
            Global_Share_Prog[0][4] = label_altname.Text;
            Global_Share_Prog[0][5] = label_chip_sn.Text;
            if (reset)
            {
                textBox_soft_term.AppendText(LocRes.GetString("tb_reboot") + '\u0020' +
                    LocRes.GetString("hex_in") + '\u0020' +
                    LocRes.GetString("tb_edl") + '\u0020' + Environment.NewLine);
                textBox_main_term.AppendText(LocRes.GetString("tb_reboot") + '\u0020' +
                    LocRes.GetString("hex_in") + '\u0020' +
                    LocRes.GetString("tb_edl") + '\u0020' + Environment.NewLine);
                try
                {
                    client.Reboot("edl", device);
                }
                catch (Exception ex)
                {
                    textBox_soft_term.AppendText(LocRes.GetString("tb_reboot_fail") + Environment.NewLine +
                        ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                    textBox_main_term.AppendText(LocRes.GetString("tb_reboot_fail") + Environment.NewLine +
                        ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                    SendErrorInChat();
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
                MessageBox.Show(LocRes.GetString("mb_note_dev_recon") + Environment.NewLine +
                    LocRes.GetString("mb_note_dev_recon2"),
                    LocRes.GetString("mb_title_dev_recon"));
                button_Sahara_Ids.Enabled = false;
                button_Sahara_CommandStart.Enabled = false;
                return;
            }
            //Выполняем запрос HWID-OEMID (command01, 02, 03, 07)
            process_Sahara.StartInfo.Arguments = "-u " + serialPort1.PortName.Remove(0, 3) + " -c 1 -c 2 -c 3 -c 7";
            try
            {
                process_Sahara.Start();
                StreamReader reader = process_Sahara.StandardOutput;
                StreamReader erread = process_Sahara.StandardError;
                string output = string.Empty;
                if (erread.Peek() >= 0) output = "er: " + erread.ReadToEnd();
                if (reader.Peek() >= 0) output = reader.ReadToEnd();
                textBox_soft_term.AppendText(output + Environment.NewLine);
                textBox_main_term.AppendText(output + Environment.NewLine);
                process_Sahara.WaitForExit();
                process_Sahara.Close();
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                SendErrorInChat();
            }
            NeedReset = true;
            //Обрабатываем запрос идентификатора 1
            string chip_sn = func.SaharaCommand1();
            textBox_main_term.AppendText(LocRes.GetString("get") + '\u0020' + "S/N CPU - " + chip_sn + Environment.NewLine);
            textBox_soft_term.AppendText(LocRes.GetString("get") + '\u0020' + "S/N CPU - " + chip_sn + Environment.NewLine);
            if (chip_sn.Equals(label_chip_sn.Text))
            {
                textBox_main_term.AppendText(LocRes.GetString("tb_chip_same") + Environment.NewLine);
                textBox_soft_term.AppendText(LocRes.GetString("tb_chip_same") + Environment.NewLine);
            }
            //Обрабатываем запрос идентификатора 2
            string HWOEMIDs = func.SaharaCommand2();
            if (HWOEMIDs.Length == 16)
            {
                textBox_hwid.Text = HWOEMIDs.Substring(0, 8);
                textBox_oemid.Text = HWOEMIDs.Substring(8, 4);
                textBox_modelid.Text = HWOEMIDs.Substring(12, 4);
            }
            textBox_soft_term.AppendText("HWID - " + HWOEMIDs + Environment.NewLine);
            textBox_main_term.AppendText("HWID - " + HWOEMIDs + Environment.NewLine);
            //Обрабатываем запрос идентификатора 3
            string PK_HASH = func.SaharaCommand3();
            textBox_oemhash.Text = PK_HASH;
            textBox_soft_term.AppendText("OEM_PK_HASH (" + PK_HASH.Length.ToString() + ") - " + PK_HASH + Environment.NewLine);
            textBox_main_term.AppendText("OEM_PK_HASH (" + PK_HASH.Length.ToString() + ") - " + PK_HASH + Environment.NewLine);
            //Обрабатываем запрос идентификатора 7
            string SW_VER = func.SaharaCommand7();
            label_SW_Ver.Text = SW_VER;
            textBox_soft_term.AppendText("SBL SW Ver. - " + SW_VER + Environment.NewLine);
            textBox_main_term.AppendText("SBL SW Ver. - " + SW_VER + Environment.NewLine);
            //Переходим на вкладку Работа с файлами
            tabControl1.SelectedTab = tabPage_firehose;
            toolStripStatusLabel_filescompleted.Text = LocRes.GetString("tt_id_rec");
            if (checkBox_Log.Checked || checkBox_send.Checked)
            {
                if (label_tm.Text.StartsWith("---") || label_model.Text.StartsWith("---"))
                {
                    InsertModelForm fr = new InsertModelForm(this);
                    switch (fr.ShowDialog())
                    {
                        case DialogResult.Cancel:
                            label_tm.Text = "---";
                            label_model.Text = "---";
                            label_altname.Text = "---";
                            label_chip_sn.Text = "---";
                            toolStripStatusLabel_filescompleted.Text = LocRes.GetString("tt_id_not_rec");
                            checkBox_send.Checked = false;
                            break;
                        default:
                            label_tm.Text = fr.comboBox_tm_insert.Text;
                            label_model.Text = fr.textBox_model_insert.Text;
                            label_altname.Text = fr.textBox_alt_insert.Text;
                            //Если отчёт пришёл без серийного номера, значит вводили вручную
                            break;
                    }
                }
            }
            string logstr = label_tm.Text + "\u261F" + label_model.Text + "\u261F" + label_altname.Text + "\u261F"+ label_chip_sn.Text + Environment.NewLine +
                string.Format("Chip s/n: {0}", chip_sn) + Environment.NewLine +
                string.Format("HWID: {0}{1}{2}", textBox_hwid.Text, textBox_oemid.Text, textBox_modelid.Text) + Environment.NewLine +
                string.Format("OEM PK Hash ({0}): {1}", textBox_oemhash.TextLength, textBox_oemhash.Text) + Environment.NewLine +
                string.Format("SBL SW Version: {0}", label_SW_Ver.Text);
            //Записываем данные в глобальный массив
            Global_Share_Prog[0][2] = label_tm.Text;
            Global_Share_Prog[0][3] = label_model.Text;
            Global_Share_Prog[0][4] = label_altname.Text;
            Global_Share_Prog[1][5] = chip_sn;
            Global_Share_Prog[1][6] = textBox_hwid.Text + '\u002D' + textBox_oemid.Text + '\u002D' + textBox_modelid.Text + '\u002D' +
                textBox_oemhash.Text.Remove(0, textBox_oemhash.Text.Length - 8) + '\u002D' +
                label_SW_Ver.Text.TrimStart('0');
            if (checkBox_Log.Checked)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(label_log.Text + "\\" + label_model.Text + "_Report.txt", false)) sw.Write(logstr);
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel_filescompleted.Text = LocRes.GetString("tb_er_write") + '\u0020' +
                        LocRes.GetString("tb_rep_file") + '\u003A' + '\u0020' + ex.Message;
                    textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                    SendErrorInChat();
                }
            }
            if (checkBox_send.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBox_hwid.Text) && string.IsNullOrWhiteSpace(textBox_oemid.Text) &&
                    string.IsNullOrWhiteSpace(textBox_modelid.Text) && string.IsNullOrWhiteSpace(textBox_oemhash.Text))
                {
                    toolStripStatusLabel_filescompleted.Text = LocRes.GetString("tt_id_empty");
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
                 "Trust is Not Null AND HWID LIKE '{0}' AND OEMID LIKE '{1}' AND MODELID LIKE '{2}' AND HASHID LIKE '{3}'",
                 textBox_hwid.Text, textBox_oemid.Text, textBox_modelid.Text, textBox_oemhash.Text);
            if (dataGridView_collection.Rows.Count > 0) //Есть устройство с такими идентификаторами
            {
                for (int i = 0; i < dataGridView_collection.Rows.Count; i++)
                {
                    if (Convert.ToByte(dataGridView_collection["LASTKNOWNSBLVER", i].Value.ToString(), 16) >= Convert.ToByte(label_SW_Ver.Text, 16))
                    {
                        if (dataGridView_collection["Model", i].Value.ToString().Contains(label_model.Text)) return; //Проверяем модель на наличие
                    }
                }
                //Исправить/добавить название/модель если 1 совпадает, а 2 нет
                BotSendMes(LocRes.GetString("add_model") + '\u003A' + '\u0020' + send_string, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
            //Устройства нет, надо добавить в автосообщение
            else
            {
                if (!string.IsNullOrEmpty(textBox_hwid.Text) &&
                    !string.IsNullOrEmpty(textBox_oemid.Text) &&
                    !string.IsNullOrEmpty(textBox_modelid.Text) &&
                    !string.IsNullOrEmpty(textBox_oemhash.Text)) BotSendMes(LocRes.GetString("add_dev") + '\u003A' + '\u0020' +
                        send_string, Assembly.GetExecutingAssembly().GetName().Version.ToString());
                else toolStripStatusLabel_filescompleted.Text = LocRes.GetString("not_send");
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
                .Replace("`", "\\`")
                .Replace("]", "\\]")
                .Replace("(", "\\(")
                .Replace(")", "\\)")
                .Replace("~", "\\~")
                .Replace(">", "\\>")
                .Replace("#", "\\#")
                .Replace("+", "\\+")
                .Replace("-", "\\-")
                .Replace("=", "\\=")
                .Replace("|", "\\|")
                .Replace("{", "\\{")
                .Replace("}", "\\}")
                .Replace(".", "\\.")
                .Replace("!", "\\!")
                .Replace("\"", "\\\"");
            string correct_mess = message_not_mark;
            //Ограничение на размер сообщения. Оставляем только конец.
            if (message_not_mark.Length >= 4096)
            {
                correct_mess = message_not_mark.Remove(0, message_not_mark.Length - 4090)
                    .Insert(0, "...");
            }
            //Устанавливаем моношрифт
            correct_mess = '\u0060' + correct_mess + '\u0060';
            TelegramBotClient mybot = new TelegramBotClient(Resources.bot);
            long chat = -1001227261414;
            try
            {
                mybot.SendTextMessageAsync(
                    chat,
                    correct_mess,
                    parseMode: ParseMode.Markdown);
                toolStripStatusLabel_filescompleted.Text = LocRes.GetString("tt_data_sent");
            }
            //catch (SerializationException)
            //{
            //    //Отправляется, не смотря на косяк сериализации!
            //}
            //catch (InvalidOperationException ex)
            //{
            //    //Игнорим
            //}
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(LocRes.GetString("tt_data_not_sent") + '\u002E' + '\u0020' + ex.ToString() + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine, LocRes.GetString("tt_data_not_sent"));
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
            radioButton_mem_emmc.Checked = true;
            comboBox_lun_count.SelectedIndex = 0;
            comboBox_lun_count.Text = comboBox_lun_count.SelectedItem.ToString();
            comboBox_lun_count.Enabled = false;
            comboBox_log.Enabled = false;
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
            отправкаПрограммераToolStripMenuItem.Enabled = false;
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

        /// <summary>
        /// Проверяем подключённые устройства в режиме загрузчика
        /// </summary>
        /// <returns>true - получен список подключённых устройств, false - устройство не подключено</returns>
        private bool FB_Check()
        {
            bool goodjob = false;
            process_Fastboot.StartInfo.Arguments = "devices -l";
            textBox_soft_term.AppendText(LocRes.GetString("sent") + ": devices -l" + Environment.NewLine);
            try
            {

                process_Fastboot.Start();
                string normstr = process_Fastboot.StandardOutput.ReadToEnd();
                string errstr = process_Fastboot.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(normstr))
                {
                    Pars_FB_Dev(normstr);//Разбираем полученный массив на список устройств
                    textBox_soft_term.AppendText(LocRes.GetString("get") + '\u003A' + '\u0020' + normstr + Environment.NewLine);
                    goodjob = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(errstr))
                    {
                        Pars_FB_Dev(errstr);//Разбираем полученный массив на список устройств
                        textBox_soft_term.AppendText(LocRes.GetString("get") + " er: " + errstr + Environment.NewLine);
                        goodjob = true;
                    }
                }
                process_Fastboot.WaitForExit();
                process_Fastboot.Close();
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                SendErrorInChat();
            }
            return goodjob;
        }

        /// <summary>
        /// Отправка команды в режиме загрузчика
        /// </summary>
        /// <param name="fb_command">Команда</param>
        private void Fastboot_commands(string fb_command)
        {
            string real_command = fb_command;
            if (!string.IsNullOrEmpty(Global_FB_Device)) real_command = "-s " + Global_FB_Device + " " + fb_command;
            process_Fastboot.StartInfo.Arguments = real_command;
            textBox_soft_term.AppendText(LocRes.GetString("sent") + '\u003A' + '\u0020' + real_command + Environment.NewLine);
            try
            {
                process_Fastboot.Start();
                string exstr = process_Fastboot.StandardError.ReadToEnd();
                string normstr = process_Fastboot.StandardOutput.ReadToEnd();
                if (!string.IsNullOrEmpty(normstr)) textBox_soft_term.AppendText(LocRes.GetString("get") + '\u003A' + '\u0020' + normstr + Environment.NewLine);
                if (!string.IsNullOrEmpty(exstr)) textBox_soft_term.AppendText(LocRes.GetString("get") + "(ex): " + exstr + Environment.NewLine);
                process_Fastboot.WaitForExit();
                process_Fastboot.Close();
            }
            catch (Exception ex)
            {
                textBox_soft_term.AppendText(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
                SendErrorInChat();
            }
        }

        /// <summary>
        /// Процедура запуска в паралельном потоке функции сохранения разделов
        /// </summary>
        /// <param name="ByBlocks">true - по именам разделов, false - по секторам</param>
        /// <param name="StartSector">Начальный сектор</param>
        /// <param name="NumSectors">Количество секторов</param>
        private void DumpBySectors(bool ByBlocks, int StartSector, int NumSectors)
        {
            //Запускаем диалог сохранения папки
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                StringBuilder fh_all_args = new StringBuilder("--port=\\\\.\\" + serialPort1.PortName);
                List<string> argsfordump = new List<string>(); //Необходимые данные для параллельного потока
                int lun_int = 0;
                fh_all_args.Append(" --convertprogram2read");
                if (comboBox_lun_count.SelectedIndex != -1) lun_int = comboBox_lun_count.SelectedIndex;
                fh_all_args.Append(" --lun=" + lun_int);
                fh_all_args.Append(" --noprompt --zlpawarehost=1");
                if (radioButton_mem_ufs.Checked) fh_all_args.Append(" --memoryname=ufs");
                else fh_all_args.Append(" --memoryname=emmc");
                switch (ByBlocks)
                {
                    case true: //Один или несколько запросов по именам разделов
                        foreach (ListViewItem item in listView_GPT.CheckedItems)
                        {
                            StringBuilder fh_mass_args = new StringBuilder(fh_all_args.ToString());
                            fh_mass_args.Append(string.Format(" --sendimage=dump_{0}.bin", item.SubItems[2].Text));
                            fh_mass_args.Append(string.Format(" --start_sector={0}", Convert.ToInt32(item.SubItems[0].Text, 16)));
                            int NumSec = Convert.ToInt32(item.SubItems[1].Text, 16) - Convert.ToInt32(item.SubItems[0].Text, 16) + 1;
                            fh_mass_args.Append(string.Format(" --num_sectors={0}", NumSec));
                            argsfordump.Add(fh_mass_args.ToString());
                        }
                        break;
                    case false: //Один запрос по секторам
                        string newfilename = string.Format("dump_sectors{0}_{1}.bin", StartSector, NumSectors);
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

        /// <summary>
        /// Разбираем ответ запроса подключённых устройств в режиме загрузчика
        /// </summary>
        /// <param name="parsing_string"></param>
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

        /// <summary>
        /// Отправляем лог в чат с согласия пользователя
        /// </summary>
        private void SendErrorInChat()
        {
            if (MessageBox.Show(LocRes.GetString("mb_body_send"),
                    LocRes.GetString("mb_title_mis") + '\u0020' +
                    LocRes.GetString("mb_title_send"),
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1)==DialogResult.OK)
            {
                textBox_soft_term.AppendText(LocRes.GetString("tb_send_conf") + Environment.NewLine);
                BotSendMes(textBox_soft_term.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Блокируем видимость для всего, кроме единственного выбора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_GPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_GPT.CheckedIndices.Count == 1 && listView_GPT.SelectedItems.Count == 1)
            {
                if (listView_GPT.SelectedIndices[0] == listView_GPT.CheckedIndices[0])
                {
                    сохранитьВыбранныйРазделToolStripMenuItem.Enabled = true;
                    записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = true;
                }
                else
                {
                    сохранитьВыбранныйРазделToolStripMenuItem.Enabled = false;
                    записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Очищаем рабочую папку от файлов и систему от запущенных процессов
        /// </summary>
        private void CleanFilesProcess()
        {
            try
            {
                foreach (string cleanfile in guide.FilesToClean)
                {
                    if (File.Exists(cleanfile)) File.Delete(cleanfile);
                }
                foreach (string processforclose in guide.ProcessToClean)
                {
                    foreach (Process pfc in Process.GetProcessesByName(processforclose))
                    {
                        pfc.Kill();
                    }
                }
            }
            catch (Exception)
            {
                //Просто игнорируем все ошибки
            }
        }

        /// <summary>
        /// Выбор контекстного меню для сохранения выбранного раздела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СохранитьВыбранныйРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string loadpath = folderBrowserDialog1.SelectedPath;
                if (loadpath.Contains('\u0020'))
                {
                    textBox_soft_term.AppendText(LocRes.GetString("mb_title_att") + Environment.NewLine);
                    MessageBox.Show(LocRes.GetString("mb_body_att_spaces"),
                        LocRes.GetString("mb_title_att"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                //Создаём xml-файл для чтения
                func.FhXmltoRW(
                    true,
                    label_block_size.Text,
                    "dump_" + listView_GPT.CheckedItems[0].SubItems[2].Text + ".bin",
                    groupBox_LUN.Text.Remove(0, 5),
                    listView_GPT.CheckedItems[0].SubItems[0].Text,
                    listView_GPT.CheckedItems[0].SubItems[1].Text);
                //Создаём аргументы для лоадера
                StringBuilder Argstoxml = new StringBuilder("--port=\\\\.\\" + serialPort1.PortName);
                Argstoxml.Append(" --sendxml=p_r.xml --noprompt --search_path=" + loadpath);
                switch (comboBox_log.SelectedIndex)
                {
                    case 0:
                        Argstoxml.Append(" --loglevel=1");
                        break;
                    case 1:
                        Argstoxml.Append(" --loglevel=0");
                        break;
                    case 2:
                        Argstoxml.Append(" --loglevel=2");
                        break;
                    case 3:
                        Argstoxml.Append(" --loglevel=3");
                        break;
                    default:
                        Argstoxml.Append(" --loglevel=1");
                        break;
                }
                if (radioButton_mem_ufs.Checked) Argstoxml.Append(" --memoryname=ufs --lun=" + groupBox_LUN.Text.Remove(0, 5));
                else Argstoxml.Append(" --memoryname=emmc");
                Argstoxml.Append(" --convertprogram2read"); //Добавляем для операции чтения
                                                            //При наличии файла запускаем процесс чтения в отдельном потоке
                if (!backgroundWorker_xml.IsBusy && File.Exists("p_r.xml")) backgroundWorker_xml.RunWorkerAsync(Argstoxml.ToString());
            }
        }

        /// <summary>
        /// Выбор контексного меню на запись раздела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ЗаписатьФайлВВыбранныйРазделLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(LocRes.GetString("mb_body_record"),
                LocRes.GetString("mb_title_dev_recon") + '\u0020' +
                LocRes.GetString("mb_title_record"),
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK) textBox_soft_term.Text = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Определяем путь к файлу
                string loadpath = openFileDialog1.FileName.Remove(openFileDialog1.FileName.IndexOf(openFileDialog1.SafeFileName) - 1);
                if (loadpath.Contains('\u0020'))
                {
                    textBox_soft_term.AppendText(LocRes.GetString("mb_title_att") + Environment.NewLine);
                    MessageBox.Show(LocRes.GetString("mb_body_att_spaces"),
                        LocRes.GetString("mb_title_att"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                //Создаём xml-файл для записи
                func.FhXmltoRW(
                    false,
                    label_block_size.Text,
                    openFileDialog1.SafeFileName,
                    groupBox_LUN.Text.Remove(0, 5),
                    listView_GPT.CheckedItems[0].SubItems[0].Text,
                    listView_GPT.CheckedItems[0].SubItems[1].Text);
                //Создаём аргументы для лоадера
                StringBuilder Argstoxml = new StringBuilder("--port=\\\\.\\" + serialPort1.PortName);
                Argstoxml.Append(" --sendxml=p_r.xml --noprompt --search_path=" + loadpath);
                switch (comboBox_log.SelectedIndex)
                {
                    case 0:
                        Argstoxml.Append(" --loglevel=1");
                        break;
                    case 1:
                        Argstoxml.Append(" --loglevel=0");
                        break;
                    case 2:
                        Argstoxml.Append(" --loglevel=2");
                        break;
                    case 3:
                        Argstoxml.Append(" --loglevel=3");
                        break;
                    default:
                        Argstoxml.Append(" --loglevel=1");
                        break;
                }
                if (radioButton_mem_ufs.Checked) Argstoxml.Append(" --memoryname=ufs --lun=" + groupBox_LUN.Text.Remove(0, 5));
                else Argstoxml.Append(" --memoryname=emmc");
                //При наличии файла запускаем процесс записи в отдельном потоке
                if (!backgroundWorker_xml.IsBusy && File.Exists("p_r.xml")) backgroundWorker_xml.RunWorkerAsync(Argstoxml.ToString());
            }
        }

        private void BackgroundWorker_xml_DoWork(object sender, DoWorkEventArgs e)
        {
            FH_Commands(e.Argument.ToString());
            e.Result = output_FH;
        }

        private void BackgroundWorker_xml_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null) textBox_soft_term.AppendText(e.Error.Message + Environment.NewLine);
            else
            {
                string newfilename = "dump_" + listView_GPT.CheckedItems[0].SubItems[2].Text + ".bin";
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
                textBox_soft_term.AppendText(e.Result.ToString() + Environment.NewLine +
                    LocRes.GetString("tb_loader_com") + Environment.NewLine);
            }
        }

        #region Инструменты
        /// <summary>
        /// Открываем новое окно для осуществления бинарного поиска по маске
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ПоискМаскиБайтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hex_Search hsearch = new Hex_Search();
            hsearch.ShowDialog();
        }
        /// <summary>
        /// Открываем новое окно для распаковки и декодирования прошивки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void РаспаковкаОднобиновойПрошивкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AGMRepacker repacker = new AGMRepacker();
            repacker.ShowDialog();
        }
        #endregion

        private void РеальноПодключённыеУстройстваToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            string strfil = string.Format("Trust = '{0}'", "full trust");
            if (реальноПодключённыеУстройстваToolStripMenuItem.Checked)
            {
                strfil = "Trust is Not Null";
                if (!CollectionToolStripMenuItem.Checked) CollectionToolStripMenuItem.Checked=true;
                if (устройстваСПрограммерамиToolStripMenuItem.Checked) strfil += " AND Url is Not Null";
            }
            else if (устройстваСПрограммерамиToolStripMenuItem.Checked) strfil += " AND Url is Not Null";
            bindingSource_collection.Filter=strfil;
        }

        private void УстройстваСПрограммерамиToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            string strfil = string.Format("Trust = '{0}'", "full trust");
            if (устройстваСПрограммерамиToolStripMenuItem.Checked)
            {
                if (!CollectionToolStripMenuItem.Checked) CollectionToolStripMenuItem.Checked=true;
                if (реальноПодключённыеУстройстваToolStripMenuItem.Checked) strfil = "Trust is Not Null AND Url is Not Null";
                else strfil+=" AND Url is Not Null";
            }
            else if (реальноПодключённыеУстройстваToolStripMenuItem.Checked) strfil = "Trust is Not Null";
            bindingSource_collection.Filter=strfil;
        }


        /// <summary>
        /// Переключились на автоматический выбор языка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void АвтоматическиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (автоматическиToolStripMenuItem.Checked)
            {
                Settings.Default.local_lang=string.Empty;
                if (русскийToolStripMenuItem.Checked) русскийToolStripMenuItem.Checked=false;
                if (englishToolStripMenuItem.Checked) englishToolStripMenuItem.Checked=false;
                if (MessageBox.Show(LocRes.GetString("message_body_need_restart"),
                    LocRes.GetString("message_title_need_restart"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Переключились на русский независимо от языка системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void РусскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (русскийToolStripMenuItem.Checked)
            {
                Settings.Default.local_lang="ru";
                if (автоматическиToolStripMenuItem.Checked) автоматическиToolStripMenuItem.Checked=false;
                if (englishToolStripMenuItem.Checked) englishToolStripMenuItem.Checked=false;
                if (MessageBox.Show(LocRes.GetString("message_body_need_restart"),
                    LocRes.GetString("message_title_need_restart"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Переключились на английский независимо от языка системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (englishToolStripMenuItem.Checked)
            {
                Settings.Default.local_lang="en";
                if (автоматическиToolStripMenuItem.Checked) автоматическиToolStripMenuItem.Checked=false;
                if (русскийToolStripMenuItem.Checked) русскийToolStripMenuItem.Checked=false;
                if (MessageBox.Show(LocRes.GetString("message_body_need_restart"),
                    LocRes.GetString("message_title_need_restart"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Отправили в чат предлагать перевод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ПредложитьПереводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo offertrans = new ProcessStartInfo("https://t.me/+Suwc1u6h8PYzM2Qy");
            Process.Start(offertrans);
        }

        private void BackgroundWorker_rawprogram_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            process_FH_Loader.StartInfo.Arguments = e.Argument.ToString(); //аргументы лоадера;
            process_FH_Loader.Start();
            StreamReader reader = process_FH_Loader.StandardOutput;
            StreamReader erread = process_FH_Loader.StandardError;
            ppc = 10; //Начали обработку в параллельном потоке
            while (reader.Peek() >= 0)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    string outline = reader.ReadLine();
                    if (!string.IsNullOrEmpty(outline))
                    {
                        int ppn = func.ProcessPersent(outline);
                        if (ppc < ppn) ppc = ppn;
                        output_FH+=outline;
                        worker.ReportProgress(ppc, outline);
                    }
                }
            }
            if (erread.Peek() >= 0) worker.ReportProgress(100, "er: " + erread.ReadToEnd());
            process_FH_Loader.WaitForExit();
            process_FH_Loader.Close();
        }

        private void BackgroundWorker_rawprogram_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_phone.Value = e.ProgressPercentage;
            textBox_soft_term.AppendText(e.UserState.ToString() + Environment.NewLine);
        }

        private void BackgroundWorker_rawprogram_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ppc = 0;
            progressBar_phone.Value = ppc;
            if (e.Cancelled) textBox_soft_term.AppendText(LocRes.GetString("tb_cancel_user") + Environment.NewLine);
            else
            {
                if (e.Error != null) textBox_soft_term.AppendText(e.Error.Message + Environment.NewLine + e.Error.StackTrace + Environment.NewLine);
                else textBox_soft_term.AppendText(LocRes.GetString("done") + Environment.NewLine);
            }
        }

        /// <summary>
        /// Отменяем долгую операцию нажав прогрессбар
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_phone_Click(object sender, EventArgs e)
        {
            if (progressBar_phone.Value>5)
            {
                if (MessageBox.Show(LocRes.GetString("hex_mess_stopoper"), LocRes.GetString("hex_warn_stopoper"),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button2)==DialogResult.OK)
                {
                    if (backgroundWorker_rawprogram.IsBusy) backgroundWorker_rawprogram.CancelAsync();
                }
            }
        }

        /// <summary>
        /// Выполнение FH_Loader с указанными параметрами
        /// </summary>
        /// <param name="com_args">Аргументы команды лоадеру</param>
        /// <returns>Ответ лоадера по результатам исполнения команды</returns>
        private void FH_Commands(string com_args)
        {
            process_FH_Loader.StartInfo.Arguments = com_args; //аргументы лоадера
            try
            {
                process_FH_Loader.Start();
                StreamReader reader = process_FH_Loader.StandardOutput;
                StreamReader erread = process_FH_Loader.StandardError;
                while (reader.Peek() >= 0)
                {
                    string outline = reader.ReadLine();
                    if (!string.IsNullOrEmpty(outline))
                    {
                        output_FH += outline + Environment.NewLine;
                    }
                }
                if (erread.Peek() >=0) output_FH = "er: " + erread.ReadToEnd();
                process_FH_Loader.WaitForExit();
                process_FH_Loader.Close();
            }
            catch (Exception ex)
            {
                output_FH = LocRes.GetString("er_func_fhl_params") + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace;
            }
        }

        private void ОтправкаПрограммераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendProgForm spf = new SendProgForm(this);
            textBox_soft_term.AppendText(LocRes.GetString("tb_share_prog") + Environment.NewLine);
            switch (spf.ShowDialog())
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    MessageBox.Show("Отправили программер");
                    //Запускаем отправку файла в чат
                    break;
                case DialogResult.Cancel:
                    textBox_soft_term.AppendText(LocRes.GetString("tb_cancel_user") + Environment.NewLine);
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
