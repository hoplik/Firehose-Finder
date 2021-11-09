namespace FirehoseFinder
{
    partial class Formfhf
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formfhf));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataSet1 = new System.Data.DataSet();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker_Read_File = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приветствиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.работаСУстройствомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProofAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.внестиПроизводителяМодельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вопросОтветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_collection = new System.Windows.Forms.TabPage();
            this.dataGridView_collection = new System.Windows.Forms.DataGridView();
            this.bindingNavigator_collection = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_find = new System.Windows.Forms.ToolStripTextBox();
            this.tabPage_firehose = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_main_term = new System.Windows.Forms.TextBox();
            this.dataGridView_final = new System.Windows.Forms.DataGridView();
            this.Column_Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Full = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SW_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Comp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_fh_sel_path = new System.Windows.Forms.GroupBox();
            this.checkBox_Find_Local = new System.Windows.Forms.CheckBox();
            this.checkBox_Find_Server = new System.Windows.Forms.CheckBox();
            this.radioButton_alldir = new System.Windows.Forms.RadioButton();
            this.radioButton_topdir = new System.Windows.Forms.RadioButton();
            this.button_path = new System.Windows.Forms.Button();
            this.groupBox_tm_model = new System.Windows.Forms.GroupBox();
            this.label_model = new System.Windows.Forms.Label();
            this.label_altname = new System.Windows.Forms.Label();
            this.label_tm = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton_adb_reset = new System.Windows.Forms.RadioButton();
            this.radioButton_man_reset = new System.Windows.Forms.RadioButton();
            this.checkBox_send = new System.Windows.Forms.CheckBox();
            this.label_log = new System.Windows.Forms.Label();
            this.checkBox_Log = new System.Windows.Forms.CheckBox();
            this.button_findIDs = new System.Windows.Forms.Button();
            this.label_SW_Ver = new System.Windows.Forms.Label();
            this.label_swid = new System.Windows.Forms.Label();
            this.label_hwid = new System.Windows.Forms.Label();
            this.button_useSahara_fhf = new System.Windows.Forms.Button();
            this.textBox_oemid = new System.Windows.Forms.TextBox();
            this.label_modelid = new System.Windows.Forms.Label();
            this.textBox_hwid = new System.Windows.Forms.TextBox();
            this.label_oemid = new System.Windows.Forms.Label();
            this.textBox_oemhash = new System.Windows.Forms.TextBox();
            this.label_oemhash = new System.Windows.Forms.Label();
            this.textBox_modelid = new System.Windows.Forms.TextBox();
            this.statusStrip_firehose = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_filescompleted = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_filescompleted = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_vol = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_FInd_Server = new System.Windows.Forms.DataGridView();
            this.tabPage_phone = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_phone = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_terminal = new System.Windows.Forms.GroupBox();
            this.textBox_soft_term = new System.Windows.Forms.TextBox();
            this.groupBox_soft = new System.Windows.Forms.GroupBox();
            this.tabControl_soft = new System.Windows.Forms.TabControl();
            this.tabPage_adb = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_adb = new System.Windows.Forms.TableLayoutPanel();
            this.button_ADB_start = new System.Windows.Forms.Button();
            this.button_ADB_clear = new System.Windows.Forms.Button();
            this.groupBox_adb_commands = new System.Windows.Forms.GroupBox();
            this.radioButton_reboot_fastboot = new System.Windows.Forms.RadioButton();
            this.radioButton_adb_com = new System.Windows.Forms.RadioButton();
            this.radioButton_adb_IDs = new System.Windows.Forms.RadioButton();
            this.radioButton_reboot_edl = new System.Windows.Forms.RadioButton();
            this.textBox_ADB_commandstring = new System.Windows.Forms.TextBox();
            this.listView_ADB_devices = new System.Windows.Forms.ListView();
            this.columnHeader_ADB_SN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ADB_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ADB_comstart = new System.Windows.Forms.Button();
            this.tabPage_sahara = new System.Windows.Forms.TabPage();
            this.listView_comport = new System.Windows.Forms.ListView();
            this.columnHeader_portnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_portname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_fh_commands = new System.Windows.Forms.GroupBox();
            this.comboBox_fh_commands = new System.Windows.Forms.ComboBox();
            this.button_Sahara_CommandStart = new System.Windows.Forms.Button();
            this.groupBox_lun_count = new System.Windows.Forms.GroupBox();
            this.comboBox_lun_count = new System.Windows.Forms.ComboBox();
            this.groupBox_mem_type = new System.Windows.Forms.GroupBox();
            this.radioButton_mem_ufs = new System.Windows.Forms.RadioButton();
            this.radioButton_mem_emmc = new System.Windows.Forms.RadioButton();
            this.groupBox_LUN = new System.Windows.Forms.GroupBox();
            this.groupBox_select_gpt = new System.Windows.Forms.GroupBox();
            this.label_GPT_bytes = new System.Windows.Forms.Label();
            this.label_select_gpt = new System.Windows.Forms.Label();
            this.groupBox_total_gpt = new System.Windows.Forms.GroupBox();
            this.label_total_gpt = new System.Windows.Forms.Label();
            this.listView_GPT = new System.Windows.Forms.ListView();
            this.StartLBA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndLBA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Block_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Block_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Block_Bytes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_gpt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выбратьРазделToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВыбранныйРазделToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стеретьВыбранныйРазделToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.выбратьВсеРазделыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сброситьВыборdeselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_block_size = new System.Windows.Forms.GroupBox();
            this.label_block_size = new System.Windows.Forms.Label();
            this.groupBox_total_blocks = new System.Windows.Forms.GroupBox();
            this.label_total_blocks = new System.Windows.Forms.Label();
            this.groupBox_logs = new System.Windows.Forms.GroupBox();
            this.comboBox_log = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Sahara_Ids = new System.Windows.Forms.Button();
            this.label_Sahara_fhf = new System.Windows.Forms.Label();
            this.tabPage_fb = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_fb = new System.Windows.Forms.TableLayoutPanel();
            this.button_fb_check = new System.Windows.Forms.Button();
            this.groupBox_fb_commands = new System.Windows.Forms.GroupBox();
            this.radioButton_fb_rebootedl = new System.Windows.Forms.RadioButton();
            this.radioButton_fb_getvar = new System.Windows.Forms.RadioButton();
            this.textBox_fb_commandline = new System.Windows.Forms.TextBox();
            this.radioButton_fb_commandline = new System.Windows.Forms.RadioButton();
            this.radioButton_fb_rebootbootloader = new System.Windows.Forms.RadioButton();
            this.radioButton_fb_unlock = new System.Windows.Forms.RadioButton();
            this.radioButton_fb_lock = new System.Windows.Forms.RadioButton();
            this.radioButton_fb_devinfo = new System.Windows.Forms.RadioButton();
            this.radioButton_fb_reboot_normal = new System.Windows.Forms.RadioButton();
            this.button_fb_com_start = new System.Windows.Forms.Button();
            this.listView_fb_devices = new System.Windows.Forms.ListView();
            this.columnHeader_FB_sernum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_FB_Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_term_buttons = new System.Windows.Forms.GroupBox();
            this.button_term_clear = new System.Windows.Forms.Button();
            this.button_term_save = new System.Windows.Forms.Button();
            this.progressBar_phone = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bindingSource_collection = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Find = new System.Data.DataSet();
            this.bindingSource_firehose = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker_dump = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_xml = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage_collection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator_collection)).BeginInit();
            this.bindingNavigator_collection.SuspendLayout();
            this.tabPage_firehose.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_final)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox_fh_sel_path.SuspendLayout();
            this.groupBox_tm_model.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip_firehose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FInd_Server)).BeginInit();
            this.tabPage_phone.SuspendLayout();
            this.tableLayoutPanel_phone.SuspendLayout();
            this.groupBox_terminal.SuspendLayout();
            this.groupBox_soft.SuspendLayout();
            this.tabControl_soft.SuspendLayout();
            this.tabPage_adb.SuspendLayout();
            this.tableLayoutPanel_adb.SuspendLayout();
            this.groupBox_adb_commands.SuspendLayout();
            this.tabPage_sahara.SuspendLayout();
            this.groupBox_fh_commands.SuspendLayout();
            this.groupBox_lun_count.SuspendLayout();
            this.groupBox_mem_type.SuspendLayout();
            this.groupBox_LUN.SuspendLayout();
            this.groupBox_select_gpt.SuspendLayout();
            this.groupBox_total_gpt.SuspendLayout();
            this.contextMenuStrip_gpt.SuspendLayout();
            this.groupBox_block_size.SuspendLayout();
            this.groupBox_total_blocks.SuspendLayout();
            this.groupBox_logs.SuspendLayout();
            this.tabPage_fb.SuspendLayout();
            this.tableLayoutPanel_fb.SuspendLayout();
            this.groupBox_fb_commands.SuspendLayout();
            this.groupBox_term_buttons.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Find)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_firehose)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet_ForFilter";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // backgroundWorker_Read_File
            // 
            this.backgroundWorker_Read_File.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_Read_File_DoWork);
            this.backgroundWorker_Read_File.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_Read_File_RunWorkerCompleted);
            // 
            // toolTip1
            // 
            this.toolTip1.Tag = "";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1369, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приветствиеToolStripMenuItem,
            this.toolStripSeparator1,
            this.работаСУстройствомToolStripMenuItem,
            this.CollectionToolStripMenuItem,
            this.toolStripSeparator2,
            this.внестиПроизводителяМодельToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // приветствиеToolStripMenuItem
            // 
            this.приветствиеToolStripMenuItem.Name = "приветствиеToolStripMenuItem";
            this.приветствиеToolStripMenuItem.Size = new System.Drawing.Size(391, 26);
            this.приветствиеToolStripMenuItem.Text = "Приветствие";
            this.приветствиеToolStripMenuItem.Click += new System.EventHandler(this.ПриветствиеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(388, 6);
            // 
            // работаСУстройствомToolStripMenuItem
            // 
            this.работаСУстройствомToolStripMenuItem.CheckOnClick = true;
            this.работаСУстройствомToolStripMenuItem.Name = "работаСУстройствомToolStripMenuItem";
            this.работаСУстройствомToolStripMenuItem.Size = new System.Drawing.Size(391, 26);
            this.работаСУстройствомToolStripMenuItem.Text = "Работа с устройством";
            this.работаСУстройствомToolStripMenuItem.CheckedChanged += new System.EventHandler(this.РаботаСУстройствомToolStripMenuItem_CheckedChanged);
            // 
            // CollectionToolStripMenuItem
            // 
            this.CollectionToolStripMenuItem.CheckOnClick = true;
            this.CollectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProofAllToolStripMenuItem});
            this.CollectionToolStripMenuItem.Name = "CollectionToolStripMenuItem";
            this.CollectionToolStripMenuItem.Size = new System.Drawing.Size(391, 26);
            this.CollectionToolStripMenuItem.Text = "Справочник устройств (с программерами)";
            this.CollectionToolStripMenuItem.CheckedChanged += new System.EventHandler(this.СправочникУстройствToolStripMenuItem_CheckedChanged);
            // 
            // ProofAllToolStripMenuItem
            // 
            this.ProofAllToolStripMenuItem.CheckOnClick = true;
            this.ProofAllToolStripMenuItem.Name = "ProofAllToolStripMenuItem";
            this.ProofAllToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.ProofAllToolStripMenuItem.Text = "Полный список";
            this.ProofAllToolStripMenuItem.Click += new System.EventHandler(this.НеподтверждённыеДанныеToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(388, 6);
            // 
            // внестиПроизводителяМодельToolStripMenuItem
            // 
            this.внестиПроизводителяМодельToolStripMenuItem.Name = "внестиПроизводителяМодельToolStripMenuItem";
            this.внестиПроизводителяМодельToolStripMenuItem.Size = new System.Drawing.Size(391, 26);
            this.внестиПроизводителяМодельToolStripMenuItem.Text = "Внести производителя, модель";
            this.внестиПроизводителяМодельToolStripMenuItem.Click += new System.EventHandler(this.ВнестиПроизводителяМодельToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вопросОтветToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // вопросОтветToolStripMenuItem
            // 
            this.вопросОтветToolStripMenuItem.Name = "вопросОтветToolStripMenuItem";
            this.вопросОтветToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вопросОтветToolStripMenuItem.Text = "Просмотр справки";
            this.вопросОтветToolStripMenuItem.Click += new System.EventHandler(this.ПросмотрСправкиToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОПрограммеToolStripMenuItem_Click);
            // 
            // tabPage_collection
            // 
            this.tabPage_collection.Controls.Add(this.dataGridView_collection);
            this.tabPage_collection.Controls.Add(this.bindingNavigator_collection);
            this.tabPage_collection.Location = new System.Drawing.Point(4, 25);
            this.tabPage_collection.Name = "tabPage_collection";
            this.tabPage_collection.Size = new System.Drawing.Size(1361, 625);
            this.tabPage_collection.TabIndex = 4;
            this.tabPage_collection.Text = "Справочник устройств";
            this.tabPage_collection.UseVisualStyleBackColor = true;
            // 
            // dataGridView_collection
            // 
            this.dataGridView_collection.AllowUserToAddRows = false;
            this.dataGridView_collection.AllowUserToDeleteRows = false;
            this.dataGridView_collection.AllowUserToOrderColumns = true;
            this.dataGridView_collection.AllowUserToResizeRows = false;
            this.dataGridView_collection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_collection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_collection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_collection.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_collection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_collection.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_collection.MultiSelect = false;
            this.dataGridView_collection.Name = "dataGridView_collection";
            this.dataGridView_collection.ReadOnly = true;
            this.dataGridView_collection.RowHeadersVisible = false;
            this.dataGridView_collection.RowHeadersWidth = 51;
            this.dataGridView_collection.RowTemplate.Height = 24;
            this.dataGridView_collection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_collection.ShowCellErrors = false;
            this.dataGridView_collection.ShowCellToolTips = false;
            this.dataGridView_collection.ShowEditingIcon = false;
            this.dataGridView_collection.ShowRowErrors = false;
            this.dataGridView_collection.Size = new System.Drawing.Size(1361, 598);
            this.dataGridView_collection.TabIndex = 2;
            this.dataGridView_collection.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_collection_CellContentDoubleClick);
            // 
            // bindingNavigator_collection
            // 
            this.bindingNavigator_collection.AddNewItem = null;
            this.bindingNavigator_collection.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator_collection.DeleteItem = null;
            this.bindingNavigator_collection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator_collection.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator_collection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripTextBox_find});
            this.bindingNavigator_collection.Location = new System.Drawing.Point(0, 598);
            this.bindingNavigator_collection.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator_collection.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator_collection.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator_collection.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator_collection.Name = "bindingNavigator_collection";
            this.bindingNavigator_collection.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator_collection.Size = new System.Drawing.Size(1361, 27);
            this.bindingNavigator_collection.TabIndex = 12;
            this.bindingNavigator_collection.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripTextBox_find
            // 
            this.toolStripTextBox_find.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_find.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_find.Name = "toolStripTextBox_find";
            this.toolStripTextBox_find.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox_find.ToolTipText = "Поиск по всем полям";
            this.toolStripTextBox_find.TextChanged += new System.EventHandler(this.TextBox_find_TextChanged);
            // 
            // tabPage_firehose
            // 
            this.tabPage_firehose.Controls.Add(this.panel2);
            this.tabPage_firehose.Controls.Add(this.panel1);
            this.tabPage_firehose.Controls.Add(this.statusStrip_firehose);
            this.tabPage_firehose.Controls.Add(this.dataGridView_FInd_Server);
            this.tabPage_firehose.Location = new System.Drawing.Point(4, 25);
            this.tabPage_firehose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_firehose.Name = "tabPage_firehose";
            this.tabPage_firehose.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_firehose.Size = new System.Drawing.Size(1361, 625);
            this.tabPage_firehose.TabIndex = 0;
            this.tabPage_firehose.Text = "Работа с файлами";
            this.tabPage_firehose.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_main_term);
            this.panel2.Controls.Add(this.dataGridView_final);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1355, 413);
            this.panel2.TabIndex = 18;
            // 
            // textBox_main_term
            // 
            this.textBox_main_term.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_main_term.Location = new System.Drawing.Point(0, 0);
            this.textBox_main_term.Multiline = true;
            this.textBox_main_term.Name = "textBox_main_term";
            this.textBox_main_term.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_main_term.Size = new System.Drawing.Size(409, 413);
            this.textBox_main_term.TabIndex = 16;
            // 
            // dataGridView_final
            // 
            this.dataGridView_final.AllowUserToAddRows = false;
            this.dataGridView_final.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_final.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_final.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_final.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_final.ColumnHeadersHeight = 29;
            this.dataGridView_final.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Sel,
            this.Column_Name,
            this.Column_id,
            this.Column_rate,
            this.Column_Full,
            this.Column_SW_type,
            this.Column_Comp});
            this.dataGridView_final.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_final.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_final.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView_final.Location = new System.Drawing.Point(409, 0);
            this.dataGridView_final.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_final.MultiSelect = false;
            this.dataGridView_final.Name = "dataGridView_final";
            this.dataGridView_final.RowHeadersVisible = false;
            this.dataGridView_final.RowHeadersWidth = 51;
            this.dataGridView_final.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridView_final.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_final.RowTemplate.Height = 24;
            this.dataGridView_final.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_final.Size = new System.Drawing.Size(946, 413);
            this.dataGridView_final.TabIndex = 15;
            this.dataGridView_final.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_final_CellContentClick);
            this.dataGridView_final.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_final_CellDoubleClick);
            // 
            // Column_Sel
            // 
            this.Column_Sel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle5.NullValue = false;
            this.Column_Sel.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column_Sel.HeaderText = "Выбор";
            this.Column_Sel.MinimumWidth = 6;
            this.Column_Sel.Name = "Column_Sel";
            this.Column_Sel.Width = 57;
            // 
            // Column_Name
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Name.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column_Name.HeaderText = "Файл";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 200;
            // 
            // Column_id
            // 
            this.Column_id.HeaderText = "Jtag-OEM-MODEL-HASH-SW(Ver)";
            this.Column_id.MinimumWidth = 6;
            this.Column_id.Name = "Column_id";
            this.Column_id.Width = 200;
            // 
            // Column_rate
            // 
            this.Column_rate.HeaderText = "Рейтинг (max10)";
            this.Column_rate.MinimumWidth = 6;
            this.Column_rate.Name = "Column_rate";
            this.Column_rate.Width = 60;
            // 
            // Column_Full
            // 
            this.Column_Full.HeaderText = "Full Ids";
            this.Column_Full.MinimumWidth = 6;
            this.Column_Full.Name = "Column_Full";
            this.Column_Full.Visible = false;
            this.Column_Full.Width = 59;
            // 
            // Column_SW_type
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_SW_type.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column_SW_type.HeaderText = "Тип ПО";
            this.Column_SW_type.MinimumWidth = 6;
            this.Column_SW_type.Name = "Column_SW_type";
            this.Column_SW_type.Width = 62;
            // 
            // Column_Comp
            // 
            this.Column_Comp.HeaderText = "Может подойти для:";
            this.Column_Comp.MinimumWidth = 6;
            this.Column_Comp.Name = "Column_Comp";
            this.Column_Comp.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox_fh_sel_path);
            this.panel1.Controls.Add(this.groupBox_tm_model);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.checkBox_send);
            this.panel1.Controls.Add(this.label_log);
            this.panel1.Controls.Add(this.checkBox_Log);
            this.panel1.Controls.Add(this.button_findIDs);
            this.panel1.Controls.Add(this.label_SW_Ver);
            this.panel1.Controls.Add(this.label_swid);
            this.panel1.Controls.Add(this.label_hwid);
            this.panel1.Controls.Add(this.button_useSahara_fhf);
            this.panel1.Controls.Add(this.textBox_oemid);
            this.panel1.Controls.Add(this.label_modelid);
            this.panel1.Controls.Add(this.textBox_hwid);
            this.panel1.Controls.Add(this.label_oemid);
            this.panel1.Controls.Add(this.textBox_oemhash);
            this.panel1.Controls.Add(this.label_oemhash);
            this.panel1.Controls.Add(this.textBox_modelid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1355, 178);
            this.panel1.TabIndex = 17;
            // 
            // groupBox_fh_sel_path
            // 
            this.groupBox_fh_sel_path.Controls.Add(this.checkBox_Find_Local);
            this.groupBox_fh_sel_path.Controls.Add(this.checkBox_Find_Server);
            this.groupBox_fh_sel_path.Controls.Add(this.radioButton_alldir);
            this.groupBox_fh_sel_path.Controls.Add(this.radioButton_topdir);
            this.groupBox_fh_sel_path.Controls.Add(this.button_path);
            this.groupBox_fh_sel_path.Location = new System.Drawing.Point(1063, 4);
            this.groupBox_fh_sel_path.Name = "groupBox_fh_sel_path";
            this.groupBox_fh_sel_path.Size = new System.Drawing.Size(287, 135);
            this.groupBox_fh_sel_path.TabIndex = 31;
            this.groupBox_fh_sel_path.TabStop = false;
            this.groupBox_fh_sel_path.Text = "Поиск программера";
            // 
            // checkBox_Find_Local
            // 
            this.checkBox_Find_Local.AutoSize = true;
            this.checkBox_Find_Local.Checked = true;
            this.checkBox_Find_Local.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Find_Local.Location = new System.Drawing.Point(142, 30);
            this.checkBox_Find_Local.Name = "checkBox_Find_Local";
            this.checkBox_Find_Local.Size = new System.Drawing.Size(94, 21);
            this.checkBox_Find_Local.TabIndex = 13;
            this.checkBox_Find_Local.Text = "Локально";
            this.checkBox_Find_Local.UseVisualStyleBackColor = true;
            this.checkBox_Find_Local.CheckedChanged += new System.EventHandler(this.CheckBox_Find_Local_CheckedChanged);
            // 
            // checkBox_Find_Server
            // 
            this.checkBox_Find_Server.AutoSize = true;
            this.checkBox_Find_Server.Location = new System.Drawing.Point(7, 30);
            this.checkBox_Find_Server.Name = "checkBox_Find_Server";
            this.checkBox_Find_Server.Size = new System.Drawing.Size(106, 21);
            this.checkBox_Find_Server.TabIndex = 12;
            this.checkBox_Find_Server.Text = "На сервере";
            this.checkBox_Find_Server.UseVisualStyleBackColor = true;
            this.checkBox_Find_Server.CheckedChanged += new System.EventHandler(this.CheckBox_Find_Server_CheckedChanged);
            // 
            // radioButton_alldir
            // 
            this.radioButton_alldir.AutoSize = true;
            this.radioButton_alldir.Checked = true;
            this.radioButton_alldir.Location = new System.Drawing.Point(7, 106);
            this.radioButton_alldir.Name = "radioButton_alldir";
            this.radioButton_alldir.Size = new System.Drawing.Size(206, 21);
            this.radioButton_alldir.TabIndex = 11;
            this.radioButton_alldir.TabStop = true;
            this.radioButton_alldir.Text = "включая вложенные папки";
            this.radioButton_alldir.UseVisualStyleBackColor = true;
            // 
            // radioButton_topdir
            // 
            this.radioButton_topdir.AutoSize = true;
            this.radioButton_topdir.Location = new System.Drawing.Point(7, 57);
            this.radioButton_topdir.Name = "radioButton_topdir";
            this.radioButton_topdir.Size = new System.Drawing.Size(151, 38);
            this.radioButton_topdir.TabIndex = 10;
            this.radioButton_topdir.Text = "только выбранная\r\nпапка";
            this.radioButton_topdir.UseVisualStyleBackColor = true;
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(164, 62);
            this.button_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(117, 34);
            this.button_path.TabIndex = 9;
            this.button_path.Text = "Поиск";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.Button_path_Click);
            // 
            // groupBox_tm_model
            // 
            this.groupBox_tm_model.Controls.Add(this.label_model);
            this.groupBox_tm_model.Controls.Add(this.label_altname);
            this.groupBox_tm_model.Controls.Add(this.label_tm);
            this.groupBox_tm_model.Location = new System.Drawing.Point(409, 4);
            this.groupBox_tm_model.Name = "groupBox_tm_model";
            this.groupBox_tm_model.Size = new System.Drawing.Size(647, 52);
            this.groupBox_tm_model.TabIndex = 30;
            this.groupBox_tm_model.TabStop = false;
            this.groupBox_tm_model.Text = "Для устройства";
            // 
            // label_model
            // 
            this.label_model.AutoSize = true;
            this.label_model.Location = new System.Drawing.Point(178, 21);
            this.label_model.Name = "label_model";
            this.label_model.Size = new System.Drawing.Size(23, 17);
            this.label_model.TabIndex = 22;
            this.label_model.Text = "---";
            // 
            // label_altname
            // 
            this.label_altname.AutoSize = true;
            this.label_altname.Location = new System.Drawing.Point(382, 21);
            this.label_altname.Name = "label_altname";
            this.label_altname.Size = new System.Drawing.Size(23, 17);
            this.label_altname.TabIndex = 23;
            this.label_altname.Text = "---";
            // 
            // label_tm
            // 
            this.label_tm.AutoSize = true;
            this.label_tm.Location = new System.Drawing.Point(6, 21);
            this.label_tm.Name = "label_tm";
            this.label_tm.Size = new System.Drawing.Size(23, 17);
            this.label_tm.TabIndex = 21;
            this.label_tm.Text = "---";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton_adb_reset);
            this.groupBox4.Controls.Add(this.radioButton_man_reset);
            this.groupBox4.Location = new System.Drawing.Point(6, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(375, 75);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Перегрузить в аварийный режим";
            // 
            // radioButton_adb_reset
            // 
            this.radioButton_adb_reset.AutoSize = true;
            this.radioButton_adb_reset.Checked = true;
            this.radioButton_adb_reset.Location = new System.Drawing.Point(123, 21);
            this.radioButton_adb_reset.Name = "radioButton_adb_reset";
            this.radioButton_adb_reset.Size = new System.Drawing.Size(140, 21);
            this.radioButton_adb_reset.TabIndex = 1;
            this.radioButton_adb_reset.TabStop = true;
            this.radioButton_adb_reset.Text = "Средствами ADB";
            this.radioButton_adb_reset.UseVisualStyleBackColor = true;
            // 
            // radioButton_man_reset
            // 
            this.radioButton_man_reset.AutoSize = true;
            this.radioButton_man_reset.Location = new System.Drawing.Point(7, 22);
            this.radioButton_man_reset.Name = "radioButton_man_reset";
            this.radioButton_man_reset.Size = new System.Drawing.Size(86, 21);
            this.radioButton_man_reset.TabIndex = 0;
            this.radioButton_man_reset.Text = "Вручную";
            this.radioButton_man_reset.UseVisualStyleBackColor = true;
            // 
            // checkBox_send
            // 
            this.checkBox_send.AutoSize = true;
            this.checkBox_send.Checked = true;
            this.checkBox_send.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_send.Location = new System.Drawing.Point(168, 4);
            this.checkBox_send.Name = "checkBox_send";
            this.checkBox_send.Size = new System.Drawing.Size(213, 38);
            this.checkBox_send.TabIndex = 27;
            this.checkBox_send.Text = "Отправить в Справочник\r\nданные (при их отсутствии)";
            this.checkBox_send.UseVisualStyleBackColor = true;
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(165, 66);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(0, 17);
            this.label_log.TabIndex = 26;
            // 
            // checkBox_Log
            // 
            this.checkBox_Log.AutoSize = true;
            this.checkBox_Log.Location = new System.Drawing.Point(168, 42);
            this.checkBox_Log.Name = "checkBox_Log";
            this.checkBox_Log.Size = new System.Drawing.Size(217, 38);
            this.checkBox_Log.TabIndex = 25;
            this.checkBox_Log.Text = "Сохранить идентификаторы\r\nи марку/модель в файл";
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.CheckBox_Log_CheckedChanged);
            // 
            // button_findIDs
            // 
            this.button_findIDs.Location = new System.Drawing.Point(5, 5);
            this.button_findIDs.Name = "button_findIDs";
            this.button_findIDs.Size = new System.Drawing.Size(157, 86);
            this.button_findIDs.TabIndex = 24;
            this.button_findIDs.Text = "Опросить устройство с перезагрузкой в аварийный режим";
            this.button_findIDs.UseVisualStyleBackColor = true;
            this.button_findIDs.Click += new System.EventHandler(this.Button_findIDs_Click);
            // 
            // label_SW_Ver
            // 
            this.label_SW_Ver.AutoSize = true;
            this.label_SW_Ver.Location = new System.Drawing.Point(984, 64);
            this.label_SW_Ver.Name = "label_SW_Ver";
            this.label_SW_Ver.Size = new System.Drawing.Size(72, 17);
            this.label_SW_Ver.TabIndex = 19;
            this.label_SW_Ver.Text = "00000000";
            // 
            // label_swid
            // 
            this.label_swid.AutoSize = true;
            this.label_swid.Location = new System.Drawing.Point(875, 64);
            this.label_swid.Name = "label_swid";
            this.label_swid.Size = new System.Drawing.Size(99, 17);
            this.label_swid.TabIndex = 18;
            this.label_swid.Text = "Image id (ver.)";
            // 
            // label_hwid
            // 
            this.label_hwid.AutoSize = true;
            this.label_hwid.Location = new System.Drawing.Point(400, 64);
            this.label_hwid.Name = "label_hwid";
            this.label_hwid.Size = new System.Drawing.Size(56, 17);
            this.label_hwid.TabIndex = 1;
            this.label_hwid.Text = "Jtag_ID";
            // 
            // button_useSahara_fhf
            // 
            this.button_useSahara_fhf.Enabled = false;
            this.button_useSahara_fhf.Location = new System.Drawing.Point(1063, 146);
            this.button_useSahara_fhf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_useSahara_fhf.Name = "button_useSahara_fhf";
            this.button_useSahara_fhf.Size = new System.Drawing.Size(287, 27);
            this.button_useSahara_fhf.TabIndex = 10;
            this.button_useSahara_fhf.Text = "Проверить выбранный программер";
            this.button_useSahara_fhf.UseVisualStyleBackColor = true;
            this.button_useSahara_fhf.Click += new System.EventHandler(this.Button__useSahara_fhf_Click);
            // 
            // textBox_oemid
            // 
            this.textBox_oemid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemid.Location = new System.Drawing.Point(663, 61);
            this.textBox_oemid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemid.MaxLength = 4;
            this.textBox_oemid.Name = "textBox_oemid";
            this.textBox_oemid.Size = new System.Drawing.Size(45, 22);
            this.textBox_oemid.TabIndex = 4;
            // 
            // label_modelid
            // 
            this.label_modelid.AutoSize = true;
            this.label_modelid.Location = new System.Drawing.Point(719, 64);
            this.label_modelid.Name = "label_modelid";
            this.label_modelid.Size = new System.Drawing.Size(78, 17);
            this.label_modelid.TabIndex = 3;
            this.label_modelid.Text = "MODEL_ID";
            // 
            // textBox_hwid
            // 
            this.textBox_hwid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_hwid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_hwid.Location = new System.Drawing.Point(484, 61);
            this.textBox_hwid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_hwid.MaxLength = 8;
            this.textBox_hwid.Name = "textBox_hwid";
            this.textBox_hwid.Size = new System.Drawing.Size(83, 22);
            this.textBox_hwid.TabIndex = 0;
            // 
            // label_oemid
            // 
            this.label_oemid.AutoSize = true;
            this.label_oemid.Location = new System.Drawing.Point(587, 64);
            this.label_oemid.Name = "label_oemid";
            this.label_oemid.Size = new System.Drawing.Size(60, 17);
            this.label_oemid.TabIndex = 5;
            this.label_oemid.Text = "OEM_ID";
            // 
            // textBox_oemhash
            // 
            this.textBox_oemhash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemhash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemhash.Location = new System.Drawing.Point(484, 97);
            this.textBox_oemhash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemhash.MaxLength = 96;
            this.textBox_oemhash.Multiline = true;
            this.textBox_oemhash.Name = "textBox_oemhash";
            this.textBox_oemhash.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_oemhash.Size = new System.Drawing.Size(573, 76);
            this.textBox_oemhash.TabIndex = 6;
            this.textBox_oemhash.TextChanged += new System.EventHandler(this.TextBox_oemhash_TextChanged);
            // 
            // label_oemhash
            // 
            this.label_oemhash.AutoSize = true;
            this.label_oemhash.Location = new System.Drawing.Point(400, 99);
            this.label_oemhash.Name = "label_oemhash";
            this.label_oemhash.Size = new System.Drawing.Size(65, 34);
            this.label_oemhash.TabIndex = 7;
            this.label_oemhash.Text = "OEM_PK\r\n_HASH";
            // 
            // textBox_modelid
            // 
            this.textBox_modelid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_modelid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_modelid.Location = new System.Drawing.Point(816, 61);
            this.textBox_modelid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_modelid.MaxLength = 4;
            this.textBox_modelid.Name = "textBox_modelid";
            this.textBox_modelid.Size = new System.Drawing.Size(45, 22);
            this.textBox_modelid.TabIndex = 2;
            // 
            // statusStrip_firehose
            // 
            this.statusStrip_firehose.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_firehose.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_filescompleted,
            this.toolStripProgressBar_filescompleted,
            this.toolStripStatusLabel_vol});
            this.statusStrip_firehose.Location = new System.Drawing.Point(3, 593);
            this.statusStrip_firehose.Name = "statusStrip_firehose";
            this.statusStrip_firehose.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip_firehose.Size = new System.Drawing.Size(1355, 30);
            this.statusStrip_firehose.TabIndex = 12;
            this.statusStrip_firehose.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_filescompleted
            // 
            this.toolStripStatusLabel_filescompleted.Name = "toolStripStatusLabel_filescompleted";
            this.toolStripStatusLabel_filescompleted.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripProgressBar_filescompleted
            // 
            this.toolStripProgressBar_filescompleted.AutoToolTip = true;
            this.toolStripProgressBar_filescompleted.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripProgressBar_filescompleted.Name = "toolStripProgressBar_filescompleted";
            this.toolStripProgressBar_filescompleted.Size = new System.Drawing.Size(400, 22);
            this.toolStripProgressBar_filescompleted.Step = 1;
            this.toolStripProgressBar_filescompleted.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel_vol
            // 
            this.toolStripStatusLabel_vol.Name = "toolStripStatusLabel_vol";
            this.toolStripStatusLabel_vol.Size = new System.Drawing.Size(0, 24);
            // 
            // dataGridView_FInd_Server
            // 
            this.dataGridView_FInd_Server.AllowUserToAddRows = false;
            this.dataGridView_FInd_Server.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_FInd_Server.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_FInd_Server.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_FInd_Server.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_FInd_Server.Location = new System.Drawing.Point(166, 253);
            this.dataGridView_FInd_Server.Name = "dataGridView_FInd_Server";
            this.dataGridView_FInd_Server.ReadOnly = true;
            this.dataGridView_FInd_Server.RowHeadersWidth = 51;
            this.dataGridView_FInd_Server.RowTemplate.Height = 24;
            this.dataGridView_FInd_Server.Size = new System.Drawing.Size(186, 96);
            this.dataGridView_FInd_Server.TabIndex = 19;
            // 
            // tabPage_phone
            // 
            this.tabPage_phone.Controls.Add(this.tableLayoutPanel_phone);
            this.tabPage_phone.Location = new System.Drawing.Point(4, 25);
            this.tabPage_phone.Name = "tabPage_phone";
            this.tabPage_phone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_phone.Size = new System.Drawing.Size(1361, 627);
            this.tabPage_phone.TabIndex = 2;
            this.tabPage_phone.Text = "Работа с устройством";
            this.tabPage_phone.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_phone
            // 
            this.tableLayoutPanel_phone.ColumnCount = 2;
            this.tableLayoutPanel_phone.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel_phone.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_phone.Controls.Add(this.groupBox_terminal, 0, 0);
            this.tableLayoutPanel_phone.Controls.Add(this.groupBox_soft, 1, 0);
            this.tableLayoutPanel_phone.Controls.Add(this.groupBox_term_buttons, 0, 1);
            this.tableLayoutPanel_phone.Controls.Add(this.progressBar_phone, 0, 2);
            this.tableLayoutPanel_phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_phone.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_phone.Name = "tableLayoutPanel_phone";
            this.tableLayoutPanel_phone.RowCount = 3;
            this.tableLayoutPanel_phone.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_phone.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_phone.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_phone.Size = new System.Drawing.Size(1355, 621);
            this.tableLayoutPanel_phone.TabIndex = 8;
            // 
            // groupBox_terminal
            // 
            this.groupBox_terminal.Controls.Add(this.textBox_soft_term);
            this.groupBox_terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_terminal.Location = new System.Drawing.Point(3, 3);
            this.groupBox_terminal.Name = "groupBox_terminal";
            this.groupBox_terminal.Size = new System.Drawing.Size(394, 535);
            this.groupBox_terminal.TabIndex = 7;
            this.groupBox_terminal.TabStop = false;
            this.groupBox_terminal.Text = "Terminal";
            // 
            // textBox_soft_term
            // 
            this.textBox_soft_term.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_soft_term.Location = new System.Drawing.Point(3, 18);
            this.textBox_soft_term.Multiline = true;
            this.textBox_soft_term.Name = "textBox_soft_term";
            this.textBox_soft_term.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_soft_term.Size = new System.Drawing.Size(388, 514);
            this.textBox_soft_term.TabIndex = 1;
            this.textBox_soft_term.TextChanged += new System.EventHandler(this.TextBox_soft_term_TextChanged);
            // 
            // groupBox_soft
            // 
            this.groupBox_soft.Controls.Add(this.tabControl_soft);
            this.groupBox_soft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_soft.Location = new System.Drawing.Point(403, 3);
            this.groupBox_soft.Name = "groupBox_soft";
            this.tableLayoutPanel_phone.SetRowSpan(this.groupBox_soft, 3);
            this.groupBox_soft.Size = new System.Drawing.Size(949, 615);
            this.groupBox_soft.TabIndex = 8;
            this.groupBox_soft.TabStop = false;
            this.groupBox_soft.Text = "Soft";
            // 
            // tabControl_soft
            // 
            this.tabControl_soft.Controls.Add(this.tabPage_adb);
            this.tabControl_soft.Controls.Add(this.tabPage_sahara);
            this.tabControl_soft.Controls.Add(this.tabPage_fb);
            this.tabControl_soft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_soft.Location = new System.Drawing.Point(3, 18);
            this.tabControl_soft.Name = "tabControl_soft";
            this.tabControl_soft.SelectedIndex = 0;
            this.tabControl_soft.Size = new System.Drawing.Size(943, 594);
            this.tabControl_soft.TabIndex = 0;
            // 
            // tabPage_adb
            // 
            this.tabPage_adb.Controls.Add(this.tableLayoutPanel_adb);
            this.tabPage_adb.Location = new System.Drawing.Point(4, 25);
            this.tabPage_adb.Name = "tabPage_adb";
            this.tabPage_adb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_adb.Size = new System.Drawing.Size(935, 565);
            this.tabPage_adb.TabIndex = 0;
            this.tabPage_adb.Text = "ADB (Android Debug Bridge)";
            this.tabPage_adb.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_adb
            // 
            this.tableLayoutPanel_adb.ColumnCount = 3;
            this.tableLayoutPanel_adb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_adb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_adb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_adb.Controls.Add(this.button_ADB_start, 0, 0);
            this.tableLayoutPanel_adb.Controls.Add(this.button_ADB_clear, 1, 0);
            this.tableLayoutPanel_adb.Controls.Add(this.groupBox_adb_commands, 0, 2);
            this.tableLayoutPanel_adb.Controls.Add(this.listView_ADB_devices, 0, 1);
            this.tableLayoutPanel_adb.Controls.Add(this.button_ADB_comstart, 2, 1);
            this.tableLayoutPanel_adb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_adb.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_adb.Name = "tableLayoutPanel_adb";
            this.tableLayoutPanel_adb.RowCount = 3;
            this.tableLayoutPanel_adb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_adb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_adb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_adb.Size = new System.Drawing.Size(929, 559);
            this.tableLayoutPanel_adb.TabIndex = 8;
            // 
            // button_ADB_start
            // 
            this.button_ADB_start.Location = new System.Drawing.Point(3, 3);
            this.button_ADB_start.Name = "button_ADB_start";
            this.button_ADB_start.Size = new System.Drawing.Size(194, 23);
            this.button_ADB_start.TabIndex = 2;
            this.button_ADB_start.Text = "Подключить ADB";
            this.button_ADB_start.UseVisualStyleBackColor = true;
            this.button_ADB_start.Click += new System.EventHandler(this.Button_ADB_start_Click);
            // 
            // button_ADB_clear
            // 
            this.button_ADB_clear.Enabled = false;
            this.button_ADB_clear.Location = new System.Drawing.Point(203, 3);
            this.button_ADB_clear.Name = "button_ADB_clear";
            this.button_ADB_clear.Size = new System.Drawing.Size(194, 23);
            this.button_ADB_clear.TabIndex = 3;
            this.button_ADB_clear.Text = "Закрыть сессию ADB";
            this.button_ADB_clear.UseVisualStyleBackColor = true;
            this.button_ADB_clear.Click += new System.EventHandler(this.Button_ADB_clear_Click);
            // 
            // groupBox_adb_commands
            // 
            this.tableLayoutPanel_adb.SetColumnSpan(this.groupBox_adb_commands, 3);
            this.groupBox_adb_commands.Controls.Add(this.radioButton_reboot_fastboot);
            this.groupBox_adb_commands.Controls.Add(this.radioButton_adb_com);
            this.groupBox_adb_commands.Controls.Add(this.radioButton_adb_IDs);
            this.groupBox_adb_commands.Controls.Add(this.radioButton_reboot_edl);
            this.groupBox_adb_commands.Controls.Add(this.textBox_ADB_commandstring);
            this.groupBox_adb_commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_adb_commands.Enabled = false;
            this.groupBox_adb_commands.Location = new System.Drawing.Point(3, 133);
            this.groupBox_adb_commands.Name = "groupBox_adb_commands";
            this.groupBox_adb_commands.Size = new System.Drawing.Size(923, 423);
            this.groupBox_adb_commands.TabIndex = 7;
            this.groupBox_adb_commands.TabStop = false;
            this.groupBox_adb_commands.Text = "Команды ADB";
            // 
            // radioButton_reboot_fastboot
            // 
            this.radioButton_reboot_fastboot.AutoSize = true;
            this.radioButton_reboot_fastboot.Location = new System.Drawing.Point(300, 48);
            this.radioButton_reboot_fastboot.Name = "radioButton_reboot_fastboot";
            this.radioButton_reboot_fastboot.Size = new System.Drawing.Size(397, 21);
            this.radioButton_reboot_fastboot.TabIndex = 10;
            this.radioButton_reboot_fastboot.Text = "Перегрузить в режим загрузчика (Fastboot - Bootloader)";
            this.radioButton_reboot_fastboot.UseVisualStyleBackColor = true;
            // 
            // radioButton_adb_com
            // 
            this.radioButton_adb_com.AutoSize = true;
            this.radioButton_adb_com.Location = new System.Drawing.Point(6, 48);
            this.radioButton_adb_com.Name = "radioButton_adb_com";
            this.radioButton_adb_com.Size = new System.Drawing.Size(229, 21);
            this.radioButton_adb_com.TabIndex = 9;
            this.radioButton_adb_com.Text = "Командная строка (ADB Shell)";
            this.radioButton_adb_com.UseVisualStyleBackColor = true;
            this.radioButton_adb_com.CheckedChanged += new System.EventHandler(this.RadioButton_adb_com_CheckedChanged);
            // 
            // radioButton_adb_IDs
            // 
            this.radioButton_adb_IDs.AutoSize = true;
            this.radioButton_adb_IDs.Checked = true;
            this.radioButton_adb_IDs.Location = new System.Drawing.Point(6, 21);
            this.radioButton_adb_IDs.Name = "radioButton_adb_IDs";
            this.radioButton_adb_IDs.Size = new System.Drawing.Size(265, 21);
            this.radioButton_adb_IDs.TabIndex = 8;
            this.radioButton_adb_IDs.TabStop = true;
            this.radioButton_adb_IDs.Text = "Получить марку/модель устройства";
            this.radioButton_adb_IDs.UseVisualStyleBackColor = true;
            this.radioButton_adb_IDs.CheckedChanged += new System.EventHandler(this.RadioButton_adb_IDs_CheckedChanged);
            // 
            // radioButton_reboot_edl
            // 
            this.radioButton_reboot_edl.AutoSize = true;
            this.radioButton_reboot_edl.Location = new System.Drawing.Point(300, 21);
            this.radioButton_reboot_edl.Name = "radioButton_reboot_edl";
            this.radioButton_reboot_edl.Size = new System.Drawing.Size(512, 21);
            this.radioButton_reboot_edl.TabIndex = 7;
            this.radioButton_reboot_edl.Text = "Перегрузить в аварийный режим (Emergency Download - EDL - PID#9008)";
            this.radioButton_reboot_edl.UseVisualStyleBackColor = true;
            this.radioButton_reboot_edl.CheckedChanged += new System.EventHandler(this.RadioButton_reboot_edl_CheckedChanged);
            // 
            // textBox_ADB_commandstring
            // 
            this.textBox_ADB_commandstring.Enabled = false;
            this.textBox_ADB_commandstring.Location = new System.Drawing.Point(6, 75);
            this.textBox_ADB_commandstring.Name = "textBox_ADB_commandstring";
            this.textBox_ADB_commandstring.Size = new System.Drawing.Size(213, 22);
            this.textBox_ADB_commandstring.TabIndex = 6;
            this.textBox_ADB_commandstring.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_ADB_commandstring_KeyUp);
            // 
            // listView_ADB_devices
            // 
            this.listView_ADB_devices.CheckBoxes = true;
            this.listView_ADB_devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ADB_SN,
            this.columnHeader_ADB_Model});
            this.tableLayoutPanel_adb.SetColumnSpan(this.listView_ADB_devices, 2);
            this.listView_ADB_devices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_ADB_devices.Enabled = false;
            this.listView_ADB_devices.FullRowSelect = true;
            this.listView_ADB_devices.GridLines = true;
            this.listView_ADB_devices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_ADB_devices.HideSelection = false;
            this.listView_ADB_devices.Location = new System.Drawing.Point(3, 33);
            this.listView_ADB_devices.MultiSelect = false;
            this.listView_ADB_devices.Name = "listView_ADB_devices";
            this.listView_ADB_devices.ShowGroups = false;
            this.listView_ADB_devices.Size = new System.Drawing.Size(394, 94);
            this.listView_ADB_devices.TabIndex = 8;
            this.listView_ADB_devices.UseCompatibleStateImageBehavior = false;
            this.listView_ADB_devices.View = System.Windows.Forms.View.Details;
            this.listView_ADB_devices.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_ADB_devices_ItemChecked);
            // 
            // columnHeader_ADB_SN
            // 
            this.columnHeader_ADB_SN.Text = "Серийный номер";
            this.columnHeader_ADB_SN.Width = 130;
            // 
            // columnHeader_ADB_Model
            // 
            this.columnHeader_ADB_Model.Text = "Модель устройства";
            this.columnHeader_ADB_Model.Width = 150;
            // 
            // button_ADB_comstart
            // 
            this.button_ADB_comstart.Enabled = false;
            this.button_ADB_comstart.Location = new System.Drawing.Point(403, 33);
            this.button_ADB_comstart.Name = "button_ADB_comstart";
            this.button_ADB_comstart.Size = new System.Drawing.Size(206, 23);
            this.button_ADB_comstart.TabIndex = 5;
            this.button_ADB_comstart.Text = "Выполнить команду";
            this.button_ADB_comstart.UseVisualStyleBackColor = true;
            this.button_ADB_comstart.Click += new System.EventHandler(this.Button_ADB_comstart_Click);
            // 
            // tabPage_sahara
            // 
            this.tabPage_sahara.Controls.Add(this.listView_comport);
            this.tabPage_sahara.Controls.Add(this.groupBox_fh_commands);
            this.tabPage_sahara.Controls.Add(this.groupBox_lun_count);
            this.tabPage_sahara.Controls.Add(this.groupBox_mem_type);
            this.tabPage_sahara.Controls.Add(this.groupBox_LUN);
            this.tabPage_sahara.Controls.Add(this.groupBox_logs);
            this.tabPage_sahara.Controls.Add(this.label4);
            this.tabPage_sahara.Controls.Add(this.button_Sahara_Ids);
            this.tabPage_sahara.Controls.Add(this.label_Sahara_fhf);
            this.tabPage_sahara.Location = new System.Drawing.Point(4, 25);
            this.tabPage_sahara.Name = "tabPage_sahara";
            this.tabPage_sahara.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_sahara.Size = new System.Drawing.Size(935, 563);
            this.tabPage_sahara.TabIndex = 1;
            this.tabPage_sahara.Text = "Sahara & Firehose_loader";
            this.tabPage_sahara.UseVisualStyleBackColor = true;
            // 
            // listView_comport
            // 
            this.listView_comport.CheckBoxes = true;
            this.listView_comport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_portnum,
            this.columnHeader_portname});
            this.listView_comport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_comport.HideSelection = false;
            this.listView_comport.Location = new System.Drawing.Point(-1, 42);
            this.listView_comport.Name = "listView_comport";
            this.listView_comport.Size = new System.Drawing.Size(648, 95);
            this.listView_comport.TabIndex = 0;
            this.listView_comport.UseCompatibleStateImageBehavior = false;
            this.listView_comport.View = System.Windows.Forms.View.Details;
            this.listView_comport.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_comport_ItemChecked);
            // 
            // columnHeader_portnum
            // 
            this.columnHeader_portnum.Text = "Порт";
            // 
            // columnHeader_portname
            // 
            this.columnHeader_portname.Text = "Наименование устройства";
            this.columnHeader_portname.Width = 300;
            // 
            // groupBox_fh_commands
            // 
            this.groupBox_fh_commands.Controls.Add(this.comboBox_fh_commands);
            this.groupBox_fh_commands.Controls.Add(this.button_Sahara_CommandStart);
            this.groupBox_fh_commands.Location = new System.Drawing.Point(4, 161);
            this.groupBox_fh_commands.Name = "groupBox_fh_commands";
            this.groupBox_fh_commands.Size = new System.Drawing.Size(643, 56);
            this.groupBox_fh_commands.TabIndex = 18;
            this.groupBox_fh_commands.TabStop = false;
            this.groupBox_fh_commands.Text = "Доступные команды программера (Firehose)";
            // 
            // comboBox_fh_commands
            // 
            this.comboBox_fh_commands.Enabled = false;
            this.comboBox_fh_commands.FormattingEnabled = true;
            this.comboBox_fh_commands.Items.AddRange(new object[] {
            "Информация о запоминающем устройстве (storage_info)",
            "Получить таблицу разметки (GPT)",
            "Перегрузить устройство в нормальный режим (reset)",
            "======================================",
            "Пишем/читаем байты по определённому адресу (peek&poke) (не работает)"});
            this.comboBox_fh_commands.Location = new System.Drawing.Point(6, 26);
            this.comboBox_fh_commands.Name = "comboBox_fh_commands";
            this.comboBox_fh_commands.Size = new System.Drawing.Size(419, 24);
            this.comboBox_fh_commands.TabIndex = 17;
            this.comboBox_fh_commands.Text = "Информация о запоминающем устройстве (storage_info)";
            // 
            // button_Sahara_CommandStart
            // 
            this.button_Sahara_CommandStart.Enabled = false;
            this.button_Sahara_CommandStart.Location = new System.Drawing.Point(471, 17);
            this.button_Sahara_CommandStart.Name = "button_Sahara_CommandStart";
            this.button_Sahara_CommandStart.Size = new System.Drawing.Size(166, 33);
            this.button_Sahara_CommandStart.TabIndex = 4;
            this.button_Sahara_CommandStart.Text = "Выполнить команду";
            this.button_Sahara_CommandStart.UseVisualStyleBackColor = true;
            this.button_Sahara_CommandStart.Click += new System.EventHandler(this.Button_Sahara_CommandStart_Click);
            // 
            // groupBox_lun_count
            // 
            this.groupBox_lun_count.Controls.Add(this.comboBox_lun_count);
            this.groupBox_lun_count.Location = new System.Drawing.Point(653, 148);
            this.groupBox_lun_count.Name = "groupBox_lun_count";
            this.groupBox_lun_count.Size = new System.Drawing.Size(275, 47);
            this.groupBox_lun_count.TabIndex = 16;
            this.groupBox_lun_count.TabStop = false;
            this.groupBox_lun_count.Text = "Список доступных дисков";
            // 
            // comboBox_lun_count
            // 
            this.comboBox_lun_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_lun_count.Enabled = false;
            this.comboBox_lun_count.FormattingEnabled = true;
            this.comboBox_lun_count.Items.AddRange(new object[] {
            "Диск 0"});
            this.comboBox_lun_count.Location = new System.Drawing.Point(3, 18);
            this.comboBox_lun_count.Name = "comboBox_lun_count";
            this.comboBox_lun_count.Size = new System.Drawing.Size(269, 24);
            this.comboBox_lun_count.TabIndex = 16;
            this.comboBox_lun_count.Text = "Диск 0";
            this.comboBox_lun_count.SelectedIndexChanged += new System.EventHandler(this.ComboBox_lun_count_SelectedIndexChanged);
            // 
            // groupBox_mem_type
            // 
            this.groupBox_mem_type.Controls.Add(this.radioButton_mem_ufs);
            this.groupBox_mem_type.Controls.Add(this.radioButton_mem_emmc);
            this.groupBox_mem_type.Enabled = false;
            this.groupBox_mem_type.Location = new System.Drawing.Point(653, 95);
            this.groupBox_mem_type.Name = "groupBox_mem_type";
            this.groupBox_mem_type.Size = new System.Drawing.Size(275, 47);
            this.groupBox_mem_type.TabIndex = 2;
            this.groupBox_mem_type.TabStop = false;
            this.groupBox_mem_type.Text = "Тип памяти";
            // 
            // radioButton_mem_ufs
            // 
            this.radioButton_mem_ufs.AutoSize = true;
            this.radioButton_mem_ufs.Location = new System.Drawing.Point(139, 20);
            this.radioButton_mem_ufs.Name = "radioButton_mem_ufs";
            this.radioButton_mem_ufs.Size = new System.Drawing.Size(56, 21);
            this.radioButton_mem_ufs.TabIndex = 2;
            this.radioButton_mem_ufs.Text = "UFS";
            this.radioButton_mem_ufs.UseVisualStyleBackColor = true;
            // 
            // radioButton_mem_emmc
            // 
            this.radioButton_mem_emmc.AutoSize = true;
            this.radioButton_mem_emmc.Checked = true;
            this.radioButton_mem_emmc.Location = new System.Drawing.Point(7, 20);
            this.radioButton_mem_emmc.Name = "radioButton_mem_emmc";
            this.radioButton_mem_emmc.Size = new System.Drawing.Size(68, 21);
            this.radioButton_mem_emmc.TabIndex = 1;
            this.radioButton_mem_emmc.TabStop = true;
            this.radioButton_mem_emmc.Text = "eMMC";
            this.radioButton_mem_emmc.UseVisualStyleBackColor = true;
            // 
            // groupBox_LUN
            // 
            this.groupBox_LUN.Controls.Add(this.groupBox_select_gpt);
            this.groupBox_LUN.Controls.Add(this.groupBox_total_gpt);
            this.groupBox_LUN.Controls.Add(this.listView_GPT);
            this.groupBox_LUN.Controls.Add(this.groupBox_block_size);
            this.groupBox_LUN.Controls.Add(this.groupBox_total_blocks);
            this.groupBox_LUN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_LUN.Location = new System.Drawing.Point(3, 221);
            this.groupBox_LUN.Name = "groupBox_LUN";
            this.groupBox_LUN.Size = new System.Drawing.Size(929, 339);
            this.groupBox_LUN.TabIndex = 15;
            this.groupBox_LUN.TabStop = false;
            this.groupBox_LUN.Text = "Диск 0";
            // 
            // groupBox_select_gpt
            // 
            this.groupBox_select_gpt.Controls.Add(this.label_GPT_bytes);
            this.groupBox_select_gpt.Controls.Add(this.label_select_gpt);
            this.groupBox_select_gpt.Location = new System.Drawing.Point(725, 21);
            this.groupBox_select_gpt.Name = "groupBox_select_gpt";
            this.groupBox_select_gpt.Size = new System.Drawing.Size(197, 41);
            this.groupBox_select_gpt.TabIndex = 4;
            this.groupBox_select_gpt.TabStop = false;
            this.groupBox_select_gpt.Text = "Выбрано разделов GPT";
            // 
            // label_GPT_bytes
            // 
            this.label_GPT_bytes.AutoSize = true;
            this.label_GPT_bytes.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_GPT_bytes.Location = new System.Drawing.Point(166, 18);
            this.label_GPT_bytes.Name = "label_GPT_bytes";
            this.label_GPT_bytes.Size = new System.Drawing.Size(28, 17);
            this.label_GPT_bytes.TabIndex = 1;
            this.label_GPT_bytes.Text = "0 b";
            // 
            // label_select_gpt
            // 
            this.label_select_gpt.AutoSize = true;
            this.label_select_gpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_select_gpt.Location = new System.Drawing.Point(3, 18);
            this.label_select_gpt.Name = "label_select_gpt";
            this.label_select_gpt.Size = new System.Drawing.Size(16, 17);
            this.label_select_gpt.TabIndex = 0;
            this.label_select_gpt.Text = "0";
            this.label_select_gpt.TextChanged += new System.EventHandler(this.Label_select_gpt_TextChanged);
            // 
            // groupBox_total_gpt
            // 
            this.groupBox_total_gpt.Controls.Add(this.label_total_gpt);
            this.groupBox_total_gpt.Location = new System.Drawing.Point(540, 21);
            this.groupBox_total_gpt.Name = "groupBox_total_gpt";
            this.groupBox_total_gpt.Size = new System.Drawing.Size(179, 41);
            this.groupBox_total_gpt.TabIndex = 3;
            this.groupBox_total_gpt.TabStop = false;
            this.groupBox_total_gpt.Text = "Всего разделов GPT";
            // 
            // label_total_gpt
            // 
            this.label_total_gpt.AutoSize = true;
            this.label_total_gpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_total_gpt.Location = new System.Drawing.Point(3, 18);
            this.label_total_gpt.Name = "label_total_gpt";
            this.label_total_gpt.Size = new System.Drawing.Size(16, 17);
            this.label_total_gpt.TabIndex = 0;
            this.label_total_gpt.Text = "0";
            this.label_total_gpt.TextChanged += new System.EventHandler(this.Label_total_gpt_TextChanged);
            // 
            // listView_GPT
            // 
            this.listView_GPT.CheckBoxes = true;
            this.listView_GPT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StartLBA,
            this.EndLBA,
            this.Block_Name,
            this.Block_length,
            this.Block_Bytes});
            this.listView_GPT.ContextMenuStrip = this.contextMenuStrip_gpt;
            this.listView_GPT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView_GPT.FullRowSelect = true;
            this.listView_GPT.GridLines = true;
            this.listView_GPT.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_GPT.HideSelection = false;
            this.listView_GPT.Location = new System.Drawing.Point(3, 68);
            this.listView_GPT.MultiSelect = false;
            this.listView_GPT.Name = "listView_GPT";
            this.listView_GPT.ShowGroups = false;
            this.listView_GPT.Size = new System.Drawing.Size(923, 268);
            this.listView_GPT.TabIndex = 2;
            this.listView_GPT.UseCompatibleStateImageBehavior = false;
            this.listView_GPT.View = System.Windows.Forms.View.Details;
            this.listView_GPT.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.ListView_GPT_ColumnWidthChanged);
            this.listView_GPT.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_GPT_ItemChecked);
            this.listView_GPT.SelectedIndexChanged += new System.EventHandler(this.ListView_GPT_SelectedIndexChanged);
            // 
            // StartLBA
            // 
            this.StartLBA.Text = "Start LBA";
            this.StartLBA.Width = 84;
            // 
            // EndLBA
            // 
            this.EndLBA.Text = "End LBA";
            this.EndLBA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.EndLBA.Width = 83;
            // 
            // Block_Name
            // 
            this.Block_Name.Text = "Имя раздела";
            this.Block_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Block_Name.Width = 111;
            // 
            // Block_length
            // 
            this.Block_length.Text = "Размер раздела - блоков (байт)";
            this.Block_length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Block_length.Width = 226;
            // 
            // Block_Bytes
            // 
            this.Block_Bytes.Text = "Объём в байтах";
            this.Block_Bytes.Width = 0;
            // 
            // contextMenuStrip_gpt
            // 
            this.contextMenuStrip_gpt.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_gpt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьРазделToolStripMenuItem,
            this.toolStripSeparator4,
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem,
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem,
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem,
            this.toolStripSeparator3,
            this.выбратьВсеРазделыToolStripMenuItem,
            this.сброситьВыборdeselectAllToolStripMenuItem});
            this.contextMenuStrip_gpt.Name = "contextMenuStrip_gpt";
            this.contextMenuStrip_gpt.Size = new System.Drawing.Size(442, 160);
            // 
            // выбратьРазделToolStripMenuItem
            // 
            this.выбратьРазделToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВыбранныйРазделToolStripMenuItem,
            this.стеретьВыбранныйРазделToolStripMenuItem,
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem});
            this.выбратьРазделToolStripMenuItem.Enabled = false;
            this.выбратьРазделToolStripMenuItem.Name = "выбратьРазделToolStripMenuItem";
            this.выбратьРазделToolStripMenuItem.ShowShortcutKeys = false;
            this.выбратьРазделToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.выбратьРазделToolStripMenuItem.Text = "Выбрать раздел (single select)";
            this.выбратьРазделToolStripMenuItem.Click += new System.EventHandler(this.ВыбратьРазделToolStripMenuItem_Click);
            // 
            // сохранитьВыбранныйРазделToolStripMenuItem
            // 
            this.сохранитьВыбранныйРазделToolStripMenuItem.Enabled = false;
            this.сохранитьВыбранныйРазделToolStripMenuItem.Name = "сохранитьВыбранныйРазделToolStripMenuItem";
            this.сохранитьВыбранныйРазделToolStripMenuItem.Size = new System.Drawing.Size(392, 26);
            this.сохранитьВыбранныйРазделToolStripMenuItem.Text = "Сохранить выбранный раздел (Save)";
            this.сохранитьВыбранныйРазделToolStripMenuItem.Click += new System.EventHandler(this.СохранитьВыбранныйРазделToolStripMenuItem_Click);
            // 
            // стеретьВыбранныйРазделToolStripMenuItem
            // 
            this.стеретьВыбранныйРазделToolStripMenuItem.Enabled = false;
            this.стеретьВыбранныйРазделToolStripMenuItem.Name = "стеретьВыбранныйРазделToolStripMenuItem";
            this.стеретьВыбранныйРазделToolStripMenuItem.Size = new System.Drawing.Size(392, 26);
            this.стеретьВыбранныйРазделToolStripMenuItem.Text = "Стереть выбранный раздел (Erase)";
            this.стеретьВыбранныйРазделToolStripMenuItem.Click += new System.EventHandler(this.СтеретьВыбранныйРазделToolStripMenuItem_Click);
            // 
            // записатьФайлВВыбранныйРазделLoadToolStripMenuItem
            // 
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Enabled = false;
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Name = "записатьФайлВВыбранныйРазделLoadToolStripMenuItem";
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Size = new System.Drawing.Size(392, 26);
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Text = "Записать файл в выбранный раздел (Load)";
            this.записатьФайлВВыбранныйРазделLoadToolStripMenuItem.Click += new System.EventHandler(this.ЗаписатьФайлВВыбранныйРазделLoadToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(438, 6);
            // 
            // сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem
            // 
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem.Enabled = false;
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem.Name = "сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem";
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem.ShowShortcutKeys = false;
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem.Text = "Сохранить таблицу в файл (gpt_main0.bin)";
            this.сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem.Click += new System.EventHandler(this.СохранитьТаблицуВФайлmainGPTbinToolStripMenuItem_Click);
            // 
            // сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem
            // 
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem.Enabled = false;
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem.Name = "сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem";
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem.Text = "Сохранить сектора по номеру (dump sector numder)";
            this.сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem.Click += new System.EventHandler(this.СохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem_Click);
            // 
            // сохранитьВыбранныеРазделыdumpToolStripMenuItem
            // 
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem.Enabled = false;
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem.Name = "сохранитьВыбранныеРазделыdumpToolStripMenuItem";
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem.ShowShortcutKeys = false;
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem.Text = "Сохранить выбранные разделы (dump selected)";
            this.сохранитьВыбранныеРазделыdumpToolStripMenuItem.Click += new System.EventHandler(this.СохранитьВыбранныеРазделыdumpToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(438, 6);
            // 
            // выбратьВсеРазделыToolStripMenuItem
            // 
            this.выбратьВсеРазделыToolStripMenuItem.Enabled = false;
            this.выбратьВсеРазделыToolStripMenuItem.Name = "выбратьВсеРазделыToolStripMenuItem";
            this.выбратьВсеРазделыToolStripMenuItem.ShowShortcutKeys = false;
            this.выбратьВсеРазделыToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.выбратьВсеРазделыToolStripMenuItem.Text = "Выбрать все разделы (select all)";
            this.выбратьВсеРазделыToolStripMenuItem.Click += new System.EventHandler(this.ВыбратьВсеРазделыToolStripMenuItem_Click);
            // 
            // сброситьВыборdeselectAllToolStripMenuItem
            // 
            this.сброситьВыборdeselectAllToolStripMenuItem.Enabled = false;
            this.сброситьВыборdeselectAllToolStripMenuItem.Name = "сброситьВыборdeselectAllToolStripMenuItem";
            this.сброситьВыборdeselectAllToolStripMenuItem.ShowShortcutKeys = false;
            this.сброситьВыборdeselectAllToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.сброситьВыборdeselectAllToolStripMenuItem.Text = "Сбросить выбор (deselecting all)";
            this.сброситьВыборdeselectAllToolStripMenuItem.Click += new System.EventHandler(this.СброситьВыборdeselectAllToolStripMenuItem_Click);
            // 
            // groupBox_block_size
            // 
            this.groupBox_block_size.Controls.Add(this.label_block_size);
            this.groupBox_block_size.Location = new System.Drawing.Point(6, 21);
            this.groupBox_block_size.Name = "groupBox_block_size";
            this.groupBox_block_size.Size = new System.Drawing.Size(168, 41);
            this.groupBox_block_size.TabIndex = 0;
            this.groupBox_block_size.TabStop = false;
            this.groupBox_block_size.Text = "Размер сектора";
            // 
            // label_block_size
            // 
            this.label_block_size.AutoSize = true;
            this.label_block_size.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_block_size.Location = new System.Drawing.Point(3, 18);
            this.label_block_size.Name = "label_block_size";
            this.label_block_size.Size = new System.Drawing.Size(16, 17);
            this.label_block_size.TabIndex = 0;
            this.label_block_size.Text = "0";
            // 
            // groupBox_total_blocks
            // 
            this.groupBox_total_blocks.Controls.Add(this.label_total_blocks);
            this.groupBox_total_blocks.Location = new System.Drawing.Point(198, 21);
            this.groupBox_total_blocks.Name = "groupBox_total_blocks";
            this.groupBox_total_blocks.Size = new System.Drawing.Size(176, 41);
            this.groupBox_total_blocks.TabIndex = 1;
            this.groupBox_total_blocks.TabStop = false;
            this.groupBox_total_blocks.Text = "Всего секторов";
            // 
            // label_total_blocks
            // 
            this.label_total_blocks.AutoSize = true;
            this.label_total_blocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_total_blocks.Location = new System.Drawing.Point(3, 18);
            this.label_total_blocks.Name = "label_total_blocks";
            this.label_total_blocks.Size = new System.Drawing.Size(16, 17);
            this.label_total_blocks.TabIndex = 0;
            this.label_total_blocks.Text = "0";
            this.label_total_blocks.TextChanged += new System.EventHandler(this.Label_total_blocks_TextChanged);
            // 
            // groupBox_logs
            // 
            this.groupBox_logs.Controls.Add(this.comboBox_log);
            this.groupBox_logs.Location = new System.Drawing.Point(653, 42);
            this.groupBox_logs.Name = "groupBox_logs";
            this.groupBox_logs.Size = new System.Drawing.Size(275, 47);
            this.groupBox_logs.TabIndex = 10;
            this.groupBox_logs.TabStop = false;
            this.groupBox_logs.Text = "Вывод логов в терминал";
            // 
            // comboBox_log
            // 
            this.comboBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_log.FormattingEnabled = true;
            this.comboBox_log.Items.AddRange(new object[] {
            "Стандартный лог",
            "Минимально возможный лог",
            "Подробный лог",
            "Максимально возможный лог"});
            this.comboBox_log.Location = new System.Drawing.Point(3, 18);
            this.comboBox_log.Name = "comboBox_log";
            this.comboBox_log.Size = new System.Drawing.Size(269, 24);
            this.comboBox_log.TabIndex = 0;
            this.comboBox_log.Text = "Стандартный лог";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(363, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Для выполнения этой команды программер не нужен";
            // 
            // button_Sahara_Ids
            // 
            this.button_Sahara_Ids.Enabled = false;
            this.button_Sahara_Ids.Location = new System.Drawing.Point(6, 6);
            this.button_Sahara_Ids.Name = "button_Sahara_Ids";
            this.button_Sahara_Ids.Size = new System.Drawing.Size(275, 30);
            this.button_Sahara_Ids.TabIndex = 3;
            this.button_Sahara_Ids.Text = "Получить идентификаторы устройства";
            this.button_Sahara_Ids.UseVisualStyleBackColor = true;
            this.button_Sahara_Ids.Click += new System.EventHandler(this.Button_Sahara_Ids_Click);
            // 
            // label_Sahara_fhf
            // 
            this.label_Sahara_fhf.AutoSize = true;
            this.label_Sahara_fhf.Location = new System.Drawing.Point(6, 140);
            this.label_Sahara_fhf.Name = "label_Sahara_fhf";
            this.label_Sahara_fhf.Size = new System.Drawing.Size(371, 17);
            this.label_Sahara_fhf.TabIndex = 2;
            this.label_Sahara_fhf.Text = "Выберете программер на вкладке \"Работа с файлами\"";
            // 
            // tabPage_fb
            // 
            this.tabPage_fb.Controls.Add(this.tableLayoutPanel_fb);
            this.tabPage_fb.Location = new System.Drawing.Point(4, 25);
            this.tabPage_fb.Name = "tabPage_fb";
            this.tabPage_fb.Size = new System.Drawing.Size(935, 563);
            this.tabPage_fb.TabIndex = 2;
            this.tabPage_fb.Text = "Fastboot (bootloader)";
            this.tabPage_fb.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_fb
            // 
            this.tableLayoutPanel_fb.ColumnCount = 3;
            this.tableLayoutPanel_fb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_fb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_fb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_fb.Controls.Add(this.button_fb_check, 0, 0);
            this.tableLayoutPanel_fb.Controls.Add(this.groupBox_fb_commands, 0, 2);
            this.tableLayoutPanel_fb.Controls.Add(this.button_fb_com_start, 2, 1);
            this.tableLayoutPanel_fb.Controls.Add(this.listView_fb_devices, 0, 1);
            this.tableLayoutPanel_fb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_fb.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_fb.Name = "tableLayoutPanel_fb";
            this.tableLayoutPanel_fb.RowCount = 3;
            this.tableLayoutPanel_fb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_fb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_fb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_fb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_fb.Size = new System.Drawing.Size(935, 563);
            this.tableLayoutPanel_fb.TabIndex = 0;
            // 
            // button_fb_check
            // 
            this.button_fb_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_fb_check.Location = new System.Drawing.Point(3, 3);
            this.button_fb_check.Name = "button_fb_check";
            this.button_fb_check.Size = new System.Drawing.Size(194, 24);
            this.button_fb_check.TabIndex = 0;
            this.button_fb_check.Text = "Проверить подключение";
            this.button_fb_check.UseVisualStyleBackColor = true;
            this.button_fb_check.Click += new System.EventHandler(this.Button_fb_check_Click);
            // 
            // groupBox_fb_commands
            // 
            this.tableLayoutPanel_fb.SetColumnSpan(this.groupBox_fb_commands, 3);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_rebootedl);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_getvar);
            this.groupBox_fb_commands.Controls.Add(this.textBox_fb_commandline);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_commandline);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_rebootbootloader);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_unlock);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_lock);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_devinfo);
            this.groupBox_fb_commands.Controls.Add(this.radioButton_fb_reboot_normal);
            this.groupBox_fb_commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_fb_commands.Enabled = false;
            this.groupBox_fb_commands.Location = new System.Drawing.Point(3, 133);
            this.groupBox_fb_commands.Name = "groupBox_fb_commands";
            this.groupBox_fb_commands.Size = new System.Drawing.Size(929, 427);
            this.groupBox_fb_commands.TabIndex = 1;
            this.groupBox_fb_commands.TabStop = false;
            this.groupBox_fb_commands.Text = "Команды Fastboot";
            // 
            // radioButton_fb_rebootedl
            // 
            this.radioButton_fb_rebootedl.AutoSize = true;
            this.radioButton_fb_rebootedl.Location = new System.Drawing.Point(7, 68);
            this.radioButton_fb_rebootedl.Name = "radioButton_fb_rebootedl";
            this.radioButton_fb_rebootedl.Size = new System.Drawing.Size(512, 21);
            this.radioButton_fb_rebootedl.TabIndex = 8;
            this.radioButton_fb_rebootedl.Text = "Перегрузить в аварийный режим (Emergency Download - EDL - PID#9008)";
            this.radioButton_fb_rebootedl.UseVisualStyleBackColor = true;
            // 
            // radioButton_fb_getvar
            // 
            this.radioButton_fb_getvar.AutoSize = true;
            this.radioButton_fb_getvar.Location = new System.Drawing.Point(566, 22);
            this.radioButton_fb_getvar.Name = "radioButton_fb_getvar";
            this.radioButton_fb_getvar.Size = new System.Drawing.Size(285, 21);
            this.radioButton_fb_getvar.TabIndex = 7;
            this.radioButton_fb_getvar.Text = "Информация об устройстве (getvar all)";
            this.radioButton_fb_getvar.UseVisualStyleBackColor = true;
            // 
            // textBox_fb_commandline
            // 
            this.textBox_fb_commandline.Enabled = false;
            this.textBox_fb_commandline.Location = new System.Drawing.Point(7, 113);
            this.textBox_fb_commandline.Name = "textBox_fb_commandline";
            this.textBox_fb_commandline.Size = new System.Drawing.Size(217, 22);
            this.textBox_fb_commandline.TabIndex = 6;
            this.textBox_fb_commandline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_fb_commandline_KeyUp);
            // 
            // radioButton_fb_commandline
            // 
            this.radioButton_fb_commandline.AutoSize = true;
            this.radioButton_fb_commandline.Location = new System.Drawing.Point(7, 91);
            this.radioButton_fb_commandline.Name = "radioButton_fb_commandline";
            this.radioButton_fb_commandline.Size = new System.Drawing.Size(217, 21);
            this.radioButton_fb_commandline.TabIndex = 5;
            this.radioButton_fb_commandline.Text = "Командная строка (fastboot)";
            this.radioButton_fb_commandline.UseVisualStyleBackColor = true;
            this.radioButton_fb_commandline.CheckedChanged += new System.EventHandler(this.RadioButton_fb_commandline_CheckedChanged);
            // 
            // radioButton_fb_rebootbootloader
            // 
            this.radioButton_fb_rebootbootloader.AutoSize = true;
            this.radioButton_fb_rebootbootloader.Location = new System.Drawing.Point(7, 45);
            this.radioButton_fb_rebootbootloader.Name = "radioButton_fb_rebootbootloader";
            this.radioButton_fb_rebootbootloader.Size = new System.Drawing.Size(377, 21);
            this.radioButton_fb_rebootbootloader.TabIndex = 4;
            this.radioButton_fb_rebootbootloader.Text = "Перегрузить режим загрузчика (Fastboot-bootloader)";
            this.radioButton_fb_rebootbootloader.UseVisualStyleBackColor = true;
            // 
            // radioButton_fb_unlock
            // 
            this.radioButton_fb_unlock.AutoSize = true;
            this.radioButton_fb_unlock.Location = new System.Drawing.Point(566, 68);
            this.radioButton_fb_unlock.Name = "radioButton_fb_unlock";
            this.radioButton_fb_unlock.Size = new System.Drawing.Size(261, 21);
            this.radioButton_fb_unlock.TabIndex = 3;
            this.radioButton_fb_unlock.Text = "Разблокировать загрузчик (unlock)";
            this.radioButton_fb_unlock.UseVisualStyleBackColor = true;
            // 
            // radioButton_fb_lock
            // 
            this.radioButton_fb_lock.AutoSize = true;
            this.radioButton_fb_lock.Location = new System.Drawing.Point(566, 91);
            this.radioButton_fb_lock.Name = "radioButton_fb_lock";
            this.radioButton_fb_lock.Size = new System.Drawing.Size(238, 21);
            this.radioButton_fb_lock.TabIndex = 2;
            this.radioButton_fb_lock.Text = "Заблокировать загрузчик (lock)";
            this.radioButton_fb_lock.UseVisualStyleBackColor = true;
            // 
            // radioButton_fb_devinfo
            // 
            this.radioButton_fb_devinfo.AutoSize = true;
            this.radioButton_fb_devinfo.Location = new System.Drawing.Point(566, 45);
            this.radioButton_fb_devinfo.Name = "radioButton_fb_devinfo";
            this.radioButton_fb_devinfo.Size = new System.Drawing.Size(326, 21);
            this.radioButton_fb_devinfo.TabIndex = 1;
            this.radioButton_fb_devinfo.Text = "Проверка состояния загрузчика (device-info)";
            this.radioButton_fb_devinfo.UseVisualStyleBackColor = true;
            // 
            // radioButton_fb_reboot_normal
            // 
            this.radioButton_fb_reboot_normal.AutoSize = true;
            this.radioButton_fb_reboot_normal.Checked = true;
            this.radioButton_fb_reboot_normal.Location = new System.Drawing.Point(7, 22);
            this.radioButton_fb_reboot_normal.Name = "radioButton_fb_reboot_normal";
            this.radioButton_fb_reboot_normal.Size = new System.Drawing.Size(255, 21);
            this.radioButton_fb_reboot_normal.TabIndex = 0;
            this.radioButton_fb_reboot_normal.TabStop = true;
            this.radioButton_fb_reboot_normal.Text = "Перегрузить в нормальный режим";
            this.radioButton_fb_reboot_normal.UseVisualStyleBackColor = true;
            // 
            // button_fb_com_start
            // 
            this.button_fb_com_start.Enabled = false;
            this.button_fb_com_start.Location = new System.Drawing.Point(403, 33);
            this.button_fb_com_start.Name = "button_fb_com_start";
            this.button_fb_com_start.Size = new System.Drawing.Size(188, 23);
            this.button_fb_com_start.TabIndex = 1;
            this.button_fb_com_start.Text = "Выполнить команду";
            this.button_fb_com_start.UseVisualStyleBackColor = true;
            this.button_fb_com_start.Click += new System.EventHandler(this.Button_fb_com_start_Click);
            // 
            // listView_fb_devices
            // 
            this.listView_fb_devices.CheckBoxes = true;
            this.listView_fb_devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_FB_sernum,
            this.columnHeader_FB_Model});
            this.tableLayoutPanel_fb.SetColumnSpan(this.listView_fb_devices, 2);
            this.listView_fb_devices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_fb_devices.Enabled = false;
            this.listView_fb_devices.FullRowSelect = true;
            this.listView_fb_devices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_fb_devices.HideSelection = false;
            this.listView_fb_devices.Location = new System.Drawing.Point(3, 33);
            this.listView_fb_devices.MultiSelect = false;
            this.listView_fb_devices.Name = "listView_fb_devices";
            this.listView_fb_devices.ShowGroups = false;
            this.listView_fb_devices.Size = new System.Drawing.Size(394, 94);
            this.listView_fb_devices.TabIndex = 2;
            this.listView_fb_devices.UseCompatibleStateImageBehavior = false;
            this.listView_fb_devices.View = System.Windows.Forms.View.Details;
            this.listView_fb_devices.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_fb_devices_ItemChecked);
            // 
            // columnHeader_FB_sernum
            // 
            this.columnHeader_FB_sernum.Text = "Серийный номер";
            this.columnHeader_FB_sernum.Width = 130;
            // 
            // columnHeader_FB_Model
            // 
            this.columnHeader_FB_Model.Text = "Модель устройства";
            this.columnHeader_FB_Model.Width = 150;
            // 
            // groupBox_term_buttons
            // 
            this.groupBox_term_buttons.Controls.Add(this.button_term_clear);
            this.groupBox_term_buttons.Controls.Add(this.button_term_save);
            this.groupBox_term_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_term_buttons.Location = new System.Drawing.Point(3, 544);
            this.groupBox_term_buttons.Name = "groupBox_term_buttons";
            this.groupBox_term_buttons.Size = new System.Drawing.Size(394, 54);
            this.groupBox_term_buttons.TabIndex = 9;
            this.groupBox_term_buttons.TabStop = false;
            this.groupBox_term_buttons.Text = "Управление терминалом";
            // 
            // button_term_clear
            // 
            this.button_term_clear.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_term_clear.Enabled = false;
            this.button_term_clear.Location = new System.Drawing.Point(147, 18);
            this.button_term_clear.Name = "button_term_clear";
            this.button_term_clear.Size = new System.Drawing.Size(244, 33);
            this.button_term_clear.TabIndex = 1;
            this.button_term_clear.Text = "Очистить окно терминала";
            this.button_term_clear.UseVisualStyleBackColor = true;
            this.button_term_clear.Click += new System.EventHandler(this.Button_term_clear_Click);
            // 
            // button_term_save
            // 
            this.button_term_save.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_term_save.Enabled = false;
            this.button_term_save.Location = new System.Drawing.Point(3, 18);
            this.button_term_save.Name = "button_term_save";
            this.button_term_save.Size = new System.Drawing.Size(138, 33);
            this.button_term_save.TabIndex = 0;
            this.button_term_save.Text = "Сохранить лог";
            this.button_term_save.UseVisualStyleBackColor = true;
            this.button_term_save.Click += new System.EventHandler(this.Button_term_save_Click);
            // 
            // progressBar_phone
            // 
            this.progressBar_phone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_phone.ForeColor = System.Drawing.Color.LimeGreen;
            this.progressBar_phone.Location = new System.Drawing.Point(3, 604);
            this.progressBar_phone.Name = "progressBar_phone";
            this.progressBar_phone.Size = new System.Drawing.Size(394, 14);
            this.progressBar_phone.Step = 1;
            this.progressBar_phone.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_phone.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_phone);
            this.tabControl1.Controls.Add(this.tabPage_firehose);
            this.tabControl1.Controls.Add(this.tabPage_collection);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1369, 656);
            this.tabControl1.TabIndex = 0;
            // 
            // bindingSource_collection
            // 
            this.bindingSource_collection.AllowNew = false;
            // 
            // dataSet_Find
            // 
            this.dataSet_Find.DataSetName = "DataSet_ForFound";
            // 
            // bindingSource_firehose
            // 
            this.bindingSource_firehose.AllowNew = false;
            // 
            // backgroundWorker_dump
            // 
            this.backgroundWorker_dump.WorkerReportsProgress = true;
            this.backgroundWorker_dump.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_dump_DoWork);
            this.backgroundWorker_dump.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_dump_ProgressChanged);
            this.backgroundWorker_dump.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_dump_RunWorkerCompleted);
            // 
            // backgroundWorker_xml
            // 
            this.backgroundWorker_xml.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_xml_DoWork);
            this.backgroundWorker_xml.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_xml_RunWorkerCompleted);
            // 
            // Formfhf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 684);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formfhf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firehose Finder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formfhf_FormClosing);
            this.Load += new System.EventHandler(this.Formfhf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage_collection.ResumeLayout(false);
            this.tabPage_collection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator_collection)).EndInit();
            this.bindingNavigator_collection.ResumeLayout(false);
            this.bindingNavigator_collection.PerformLayout();
            this.tabPage_firehose.ResumeLayout(false);
            this.tabPage_firehose.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_final)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_fh_sel_path.ResumeLayout(false);
            this.groupBox_fh_sel_path.PerformLayout();
            this.groupBox_tm_model.ResumeLayout(false);
            this.groupBox_tm_model.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip_firehose.ResumeLayout(false);
            this.statusStrip_firehose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FInd_Server)).EndInit();
            this.tabPage_phone.ResumeLayout(false);
            this.tableLayoutPanel_phone.ResumeLayout(false);
            this.groupBox_terminal.ResumeLayout(false);
            this.groupBox_terminal.PerformLayout();
            this.groupBox_soft.ResumeLayout(false);
            this.tabControl_soft.ResumeLayout(false);
            this.tabPage_adb.ResumeLayout(false);
            this.tableLayoutPanel_adb.ResumeLayout(false);
            this.groupBox_adb_commands.ResumeLayout(false);
            this.groupBox_adb_commands.PerformLayout();
            this.tabPage_sahara.ResumeLayout(false);
            this.tabPage_sahara.PerformLayout();
            this.groupBox_fh_commands.ResumeLayout(false);
            this.groupBox_lun_count.ResumeLayout(false);
            this.groupBox_mem_type.ResumeLayout(false);
            this.groupBox_mem_type.PerformLayout();
            this.groupBox_LUN.ResumeLayout(false);
            this.groupBox_select_gpt.ResumeLayout(false);
            this.groupBox_select_gpt.PerformLayout();
            this.groupBox_total_gpt.ResumeLayout(false);
            this.groupBox_total_gpt.PerformLayout();
            this.contextMenuStrip_gpt.ResumeLayout(false);
            this.groupBox_block_size.ResumeLayout(false);
            this.groupBox_block_size.PerformLayout();
            this.groupBox_total_blocks.ResumeLayout(false);
            this.groupBox_total_blocks.PerformLayout();
            this.groupBox_logs.ResumeLayout(false);
            this.tabPage_fb.ResumeLayout(false);
            this.tableLayoutPanel_fb.ResumeLayout(false);
            this.groupBox_fb_commands.ResumeLayout(false);
            this.groupBox_fb_commands.PerformLayout();
            this.groupBox_term_buttons.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Find)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_firehose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Read_File;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСУстройствомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вопросОтветToolStripMenuItem;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ProofAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabPage tabPage_collection;
        private System.Windows.Forms.DataGridView dataGridView_collection;
        private System.Windows.Forms.TabPage tabPage_firehose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_main_term;
        private System.Windows.Forms.DataGridView dataGridView_final;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_send;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.CheckBox checkBox_Log;
        private System.Windows.Forms.Button button_findIDs;
        private System.Windows.Forms.Label label_SW_Ver;
        private System.Windows.Forms.Label label_swid;
        private System.Windows.Forms.Label label_hwid;
        private System.Windows.Forms.Button button_useSahara_fhf;
        private System.Windows.Forms.TextBox textBox_oemid;
        private System.Windows.Forms.Label label_modelid;
        private System.Windows.Forms.TextBox textBox_hwid;
        private System.Windows.Forms.Label label_oemid;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.TextBox textBox_oemhash;
        private System.Windows.Forms.Label label_oemhash;
        private System.Windows.Forms.TextBox textBox_modelid;
        private System.Windows.Forms.StatusStrip statusStrip_firehose;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_filescompleted;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_filescompleted;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_vol;
        private System.Windows.Forms.TabPage tabPage_phone;
        private System.Windows.Forms.GroupBox groupBox_logs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Sahara_CommandStart;
        private System.Windows.Forms.Button button_Sahara_Ids;
        private System.Windows.Forms.Label label_Sahara_fhf;
        private System.Windows.Forms.ListView listView_comport;
        private System.Windows.Forms.ColumnHeader columnHeader_portnum;
        private System.Windows.Forms.ColumnHeader columnHeader_portname;
        private System.Windows.Forms.Button button_ADB_start;
        private System.Windows.Forms.Button button_ADB_comstart;
        private System.Windows.Forms.Button button_ADB_clear;
        private System.Windows.Forms.TextBox textBox_ADB_commandstring;
        private System.Windows.Forms.GroupBox groupBox_terminal;
        private System.Windows.Forms.TextBox textBox_soft_term;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.BindingSource bindingSource_collection;
        private System.Windows.Forms.BindingNavigator bindingNavigator_collection;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_find;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton_adb_reset;
        private System.Windows.Forms.RadioButton radioButton_man_reset;
        private System.Windows.Forms.Label label_altname;
        private System.Windows.Forms.Label label_model;
        private System.Windows.Forms.Label label_tm;
        private System.Windows.Forms.ToolStripMenuItem приветствиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem внестиПроизводителяМодельToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_tm_model;
        private System.Windows.Forms.GroupBox groupBox_fh_sel_path;
        private System.Windows.Forms.RadioButton radioButton_alldir;
        private System.Windows.Forms.RadioButton radioButton_topdir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_phone;
        private System.Windows.Forms.GroupBox groupBox_soft;
        private System.Windows.Forms.TabControl tabControl_soft;
        private System.Windows.Forms.TabPage tabPage_adb;
        private System.Windows.Forms.TabPage tabPage_sahara;
        private System.Windows.Forms.GroupBox groupBox_term_buttons;
        private System.Windows.Forms.Button button_term_clear;
        private System.Windows.Forms.Button button_term_save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_adb;
        private System.Windows.Forms.GroupBox groupBox_adb_commands;
        private System.Windows.Forms.RadioButton radioButton_adb_com;
        private System.Windows.Forms.RadioButton radioButton_adb_IDs;
        private System.Windows.Forms.RadioButton radioButton_reboot_edl;
        private System.Windows.Forms.CheckBox checkBox_Find_Local;
        private System.Windows.Forms.CheckBox checkBox_Find_Server;
        private System.Data.DataSet dataSet_Find;
        private System.Windows.Forms.BindingSource bindingSource_firehose;
        private System.Windows.Forms.DataGridView dataGridView_FInd_Server;
        private System.Windows.Forms.GroupBox groupBox_total_blocks;
        private System.Windows.Forms.GroupBox groupBox_block_size;
        private System.Windows.Forms.Label label_block_size;
        private System.Windows.Forms.GroupBox groupBox_mem_type;
        private System.Windows.Forms.GroupBox groupBox_lun_count;
        private System.Windows.Forms.GroupBox groupBox_fh_commands;
        private System.Windows.Forms.ComboBox comboBox_fh_commands;
        private System.Windows.Forms.RadioButton radioButton_mem_ufs;
        private System.Windows.Forms.RadioButton radioButton_mem_emmc;
        private System.Windows.Forms.ColumnHeader StartLBA;
        private System.Windows.Forms.ColumnHeader EndLBA;
        private System.Windows.Forms.ColumnHeader Block_Name;
        private System.Windows.Forms.ColumnHeader Block_length;
        private System.Windows.Forms.GroupBox groupBox_total_gpt;
        private System.Windows.Forms.Label label_total_gpt;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_gpt;
        private System.Windows.Forms.ToolStripMenuItem выбратьРазделToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВыбранныеРазделыdumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьВсеРазделыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сброситьВыборdeselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьТаблицуВФайлmainGPTbinToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox_select_gpt;
        private System.Windows.Forms.Label label_select_gpt;
        internal System.Windows.Forms.ListView listView_GPT;
        private System.Windows.Forms.ProgressBar progressBar_phone;
        private System.Windows.Forms.ToolStripMenuItem сохранитьСектораПоНомеруdumpSectorNumderToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker_dump;
        private System.Windows.Forms.Label label_total_blocks;
        internal System.Windows.Forms.GroupBox groupBox_LUN;
        private System.Windows.Forms.ComboBox comboBox_lun_count;
        private System.Windows.Forms.TabPage tabPage_fb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_fb;
        private System.Windows.Forms.Button button_fb_check;
        private System.Windows.Forms.GroupBox groupBox_fb_commands;
        private System.Windows.Forms.Button button_fb_com_start;
        private System.Windows.Forms.RadioButton radioButton_fb_reboot_normal;
        private System.Windows.Forms.Label label_GPT_bytes;
        private System.Windows.Forms.ColumnHeader Block_Bytes;
        private System.Windows.Forms.RadioButton radioButton_reboot_fastboot;
        private System.Windows.Forms.RadioButton radioButton_fb_getvar;
        private System.Windows.Forms.TextBox textBox_fb_commandline;
        private System.Windows.Forms.RadioButton radioButton_fb_commandline;
        private System.Windows.Forms.RadioButton radioButton_fb_rebootbootloader;
        private System.Windows.Forms.RadioButton radioButton_fb_unlock;
        private System.Windows.Forms.RadioButton radioButton_fb_lock;
        private System.Windows.Forms.RadioButton radioButton_fb_devinfo;
        private System.Windows.Forms.RadioButton radioButton_fb_rebootedl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Full;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SW_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Comp;
        private System.Windows.Forms.ListView listView_ADB_devices;
        private System.Windows.Forms.ColumnHeader columnHeader_ADB_SN;
        private System.Windows.Forms.ColumnHeader columnHeader_ADB_Model;
        private System.Windows.Forms.ListView listView_fb_devices;
        private System.Windows.Forms.ColumnHeader columnHeader_FB_sernum;
        private System.Windows.Forms.ColumnHeader columnHeader_FB_Model;
        private System.Windows.Forms.ComboBox comboBox_log;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВыбранныйРазделToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стеретьВыбранныйРазделToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записатьФайлВВыбранныйРазделLoadToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker_xml;
    }
}

