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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formfhf));
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
            this.справочникУстройствToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.неподтверждённыеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСУстройствомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton_adb_reset = new System.Windows.Forms.RadioButton();
            this.radioButton_man_reset = new System.Windows.Forms.RadioButton();
            this.label_info = new System.Windows.Forms.Label();
            this.checkBox_send = new System.Windows.Forms.CheckBox();
            this.label_log = new System.Windows.Forms.Label();
            this.checkBox_Log = new System.Windows.Forms.CheckBox();
            this.button_findIDs = new System.Windows.Forms.Button();
            this.label_altname = new System.Windows.Forms.Label();
            this.label_model = new System.Windows.Forms.Label();
            this.label_tm = new System.Windows.Forms.Label();
            this.label_tm_model = new System.Windows.Forms.Label();
            this.label_SW_Ver = new System.Windows.Forms.Label();
            this.label_swid = new System.Windows.Forms.Label();
            this.label_hwid = new System.Windows.Forms.Label();
            this.button_useSahara_fhf = new System.Windows.Forms.Button();
            this.textBox_oemid = new System.Windows.Forms.TextBox();
            this.label_modelid = new System.Windows.Forms.Label();
            this.textBox_hwid = new System.Windows.Forms.TextBox();
            this.label_oemid = new System.Windows.Forms.Label();
            this.button_path = new System.Windows.Forms.Button();
            this.textBox_oemhash = new System.Windows.Forms.TextBox();
            this.label_oemhash = new System.Windows.Forms.Label();
            this.textBox_modelid = new System.Windows.Forms.TextBox();
            this.statusStrip_firehose = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_filescompleted = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_filescompleted = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_vol = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage_phone = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox_logs = new System.Windows.Forms.GroupBox();
            this.radioButton_fulllog = new System.Windows.Forms.RadioButton();
            this.radioButton_shortlog = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_mem_type = new System.Windows.Forms.ComboBox();
            this.comboBox_fh_command = new System.Windows.Forms.ComboBox();
            this.checkBox_reset = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Sahara_CommandStart = new System.Windows.Forms.Button();
            this.button_Sahara_Ids = new System.Windows.Forms.Button();
            this.label_Sahara_fhf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_comport = new System.Windows.Forms.ListView();
            this.columnHeader_portnum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_portname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_ADB_start = new System.Windows.Forms.Button();
            this.button_ADB_comstart = new System.Windows.Forms.Button();
            this.button_ADB_clear = new System.Windows.Forms.Button();
            this.textBox_ADB_commandstring = new System.Windows.Forms.TextBox();
            this.comboBox_ADB_commands = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ADB = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bindingSource_collection = new System.Windows.Forms.BindingSource(this.components);
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
            this.groupBox4.SuspendLayout();
            this.statusStrip_firehose.SuspendLayout();
            this.tabPage_phone.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_logs.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_collection)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet_ForFilter";
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
            this.справочникУстройствToolStripMenuItem,
            this.работаСУстройствомToolStripMenuItem,
            this.toolStripSeparator2,
            this.внестиПроизводителяМодельToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // приветствиеToolStripMenuItem
            // 
            this.приветствиеToolStripMenuItem.Name = "приветствиеToolStripMenuItem";
            this.приветствиеToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.приветствиеToolStripMenuItem.Text = "Приветствие";
            this.приветствиеToolStripMenuItem.Click += new System.EventHandler(this.ПриветствиеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(307, 6);
            // 
            // справочникУстройствToolStripMenuItem
            // 
            this.справочникУстройствToolStripMenuItem.CheckOnClick = true;
            this.справочникУстройствToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.неподтверждённыеДанныеToolStripMenuItem});
            this.справочникУстройствToolStripMenuItem.Name = "справочникУстройствToolStripMenuItem";
            this.справочникУстройствToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.справочникУстройствToolStripMenuItem.Text = "Справочник устройств";
            this.справочникУстройствToolStripMenuItem.CheckedChanged += new System.EventHandler(this.СправочникУстройствToolStripMenuItem_CheckedChanged);
            // 
            // неподтверждённыеДанныеToolStripMenuItem
            // 
            this.неподтверждённыеДанныеToolStripMenuItem.CheckOnClick = true;
            this.неподтверждённыеДанныеToolStripMenuItem.Name = "неподтверждённыеДанныеToolStripMenuItem";
            this.неподтверждённыеДанныеToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.неподтверждённыеДанныеToolStripMenuItem.Text = "Неподтверждённые данные";
            this.неподтверждённыеДанныеToolStripMenuItem.Click += new System.EventHandler(this.НеподтверждённыеДанныеToolStripMenuItem_Click);
            // 
            // работаСУстройствомToolStripMenuItem
            // 
            this.работаСУстройствомToolStripMenuItem.CheckOnClick = true;
            this.работаСУстройствомToolStripMenuItem.Name = "работаСУстройствомToolStripMenuItem";
            this.работаСУстройствомToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.работаСУстройствомToolStripMenuItem.Text = "Работа с устройством";
            this.работаСУстройствомToolStripMenuItem.CheckedChanged += new System.EventHandler(this.РаботаСУстройствомToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(307, 6);
            // 
            // внестиПроизводителяМодельToolStripMenuItem
            // 
            this.внестиПроизводителяМодельToolStripMenuItem.Name = "внестиПроизводителяМодельToolStripMenuItem";
            this.внестиПроизводителяМодельToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
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
            this.tabPage_collection.Size = new System.Drawing.Size(1361, 547);
            this.tabPage_collection.TabIndex = 4;
            this.tabPage_collection.Text = "Справочник устройств";
            this.tabPage_collection.UseVisualStyleBackColor = true;
            // 
            // dataGridView_collection
            // 
            this.dataGridView_collection.AllowUserToAddRows = false;
            this.dataGridView_collection.AllowUserToDeleteRows = false;
            this.dataGridView_collection.AllowUserToOrderColumns = true;
            this.dataGridView_collection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_collection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dataGridView_collection.Size = new System.Drawing.Size(1361, 520);
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
            this.bindingNavigator_collection.Location = new System.Drawing.Point(0, 520);
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
            this.tabPage_firehose.Location = new System.Drawing.Point(4, 25);
            this.tabPage_firehose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_firehose.Name = "tabPage_firehose";
            this.tabPage_firehose.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_firehose.Size = new System.Drawing.Size(1361, 547);
            this.tabPage_firehose.TabIndex = 0;
            this.tabPage_firehose.Text = "Работа с файлами";
            this.tabPage_firehose.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_main_term);
            this.panel2.Controls.Add(this.dataGridView_final);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1355, 364);
            this.panel2.TabIndex = 18;
            // 
            // textBox_main_term
            // 
            this.textBox_main_term.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_main_term.Location = new System.Drawing.Point(0, 0);
            this.textBox_main_term.Multiline = true;
            this.textBox_main_term.Name = "textBox_main_term";
            this.textBox_main_term.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_main_term.Size = new System.Drawing.Size(409, 364);
            this.textBox_main_term.TabIndex = 16;
            // 
            // dataGridView_final
            // 
            this.dataGridView_final.AllowUserToAddRows = false;
            this.dataGridView_final.AllowUserToDeleteRows = false;
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
            this.dataGridView_final.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView_final.Location = new System.Drawing.Point(409, 0);
            this.dataGridView_final.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_final.MultiSelect = false;
            this.dataGridView_final.Name = "dataGridView_final";
            this.dataGridView_final.RowHeadersVisible = false;
            this.dataGridView_final.RowHeadersWidth = 51;
            this.dataGridView_final.RowTemplate.Height = 24;
            this.dataGridView_final.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_final.Size = new System.Drawing.Size(946, 364);
            this.dataGridView_final.TabIndex = 15;
            this.dataGridView_final.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_final_CellClick);
            this.dataGridView_final.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_final_CellDoubleClick);
            // 
            // Column_Sel
            // 
            this.Column_Sel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Sel.HeaderText = "Выбор";
            this.Column_Sel.MinimumWidth = 6;
            this.Column_Sel.Name = "Column_Sel";
            this.Column_Sel.Width = 57;
            // 
            // Column_Name
            // 
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
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label_info);
            this.panel1.Controls.Add(this.checkBox_send);
            this.panel1.Controls.Add(this.label_log);
            this.panel1.Controls.Add(this.checkBox_Log);
            this.panel1.Controls.Add(this.button_findIDs);
            this.panel1.Controls.Add(this.label_altname);
            this.panel1.Controls.Add(this.label_model);
            this.panel1.Controls.Add(this.label_tm);
            this.panel1.Controls.Add(this.label_tm_model);
            this.panel1.Controls.Add(this.label_SW_Ver);
            this.panel1.Controls.Add(this.label_swid);
            this.panel1.Controls.Add(this.label_hwid);
            this.panel1.Controls.Add(this.button_useSahara_fhf);
            this.panel1.Controls.Add(this.textBox_oemid);
            this.panel1.Controls.Add(this.label_modelid);
            this.panel1.Controls.Add(this.textBox_hwid);
            this.panel1.Controls.Add(this.label_oemid);
            this.panel1.Controls.Add(this.button_path);
            this.panel1.Controls.Add(this.textBox_oemhash);
            this.panel1.Controls.Add(this.label_oemhash);
            this.panel1.Controls.Add(this.textBox_modelid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1355, 149);
            this.panel1.TabIndex = 17;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton_adb_reset);
            this.groupBox4.Controls.Add(this.radioButton_man_reset);
            this.groupBox4.Location = new System.Drawing.Point(6, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(375, 49);
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
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(1059, 8);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(293, 119);
            this.label_info.TabIndex = 28;
            this.label_info.Text = resources.GetString("label_info.Text");
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
            this.checkBox_Log.Size = new System.Drawing.Size(203, 21);
            this.checkBox_Log.TabIndex = 25;
            this.checkBox_Log.Text = "Сохранить данные в файл";
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.CheckBox_Log_CheckedChanged);
            // 
            // button_findIDs
            // 
            this.button_findIDs.Location = new System.Drawing.Point(5, 4);
            this.button_findIDs.Name = "button_findIDs";
            this.button_findIDs.Size = new System.Drawing.Size(157, 86);
            this.button_findIDs.TabIndex = 24;
            this.button_findIDs.Text = "Опросить устройство с перезагрузкой в аварийный режим";
            this.button_findIDs.UseVisualStyleBackColor = true;
            this.button_findIDs.Click += new System.EventHandler(this.Button_findIDs_Click);
            // 
            // label_altname
            // 
            this.label_altname.AutoSize = true;
            this.label_altname.Location = new System.Drawing.Point(600, 14);
            this.label_altname.Name = "label_altname";
            this.label_altname.Size = new System.Drawing.Size(23, 17);
            this.label_altname.TabIndex = 23;
            this.label_altname.Text = "---";
            // 
            // label_model
            // 
            this.label_model.AutoSize = true;
            this.label_model.Location = new System.Drawing.Point(680, 14);
            this.label_model.Name = "label_model";
            this.label_model.Size = new System.Drawing.Size(23, 17);
            this.label_model.TabIndex = 22;
            this.label_model.Text = "---";
            // 
            // label_tm
            // 
            this.label_tm.AutoSize = true;
            this.label_tm.Location = new System.Drawing.Point(518, 14);
            this.label_tm.Name = "label_tm";
            this.label_tm.Size = new System.Drawing.Size(23, 17);
            this.label_tm.TabIndex = 21;
            this.label_tm.Text = "---";
            // 
            // label_tm_model
            // 
            this.label_tm_model.AutoSize = true;
            this.label_tm_model.Location = new System.Drawing.Point(395, 14);
            this.label_tm_model.Name = "label_tm_model";
            this.label_tm_model.Size = new System.Drawing.Size(117, 17);
            this.label_tm_model.TabIndex = 20;
            this.label_tm_model.Text = "Для устройства:";
            // 
            // label_SW_Ver
            // 
            this.label_SW_Ver.AutoSize = true;
            this.label_SW_Ver.Location = new System.Drawing.Point(978, 43);
            this.label_SW_Ver.Name = "label_SW_Ver";
            this.label_SW_Ver.Size = new System.Drawing.Size(72, 17);
            this.label_SW_Ver.TabIndex = 19;
            this.label_SW_Ver.Text = "00000000";
            // 
            // label_swid
            // 
            this.label_swid.AutoSize = true;
            this.label_swid.Location = new System.Drawing.Point(861, 43);
            this.label_swid.Name = "label_swid";
            this.label_swid.Size = new System.Drawing.Size(99, 17);
            this.label_swid.TabIndex = 18;
            this.label_swid.Text = "Image id (ver.)";
            // 
            // label_hwid
            // 
            this.label_hwid.AutoSize = true;
            this.label_hwid.Location = new System.Drawing.Point(394, 43);
            this.label_hwid.Name = "label_hwid";
            this.label_hwid.Size = new System.Drawing.Size(56, 17);
            this.label_hwid.TabIndex = 1;
            this.label_hwid.Text = "Jtag_ID";
            // 
            // button_useSahara_fhf
            // 
            this.button_useSahara_fhf.Location = new System.Drawing.Point(733, 116);
            this.button_useSahara_fhf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_useSahara_fhf.Name = "button_useSahara_fhf";
            this.button_useSahara_fhf.Size = new System.Drawing.Size(324, 23);
            this.button_useSahara_fhf.TabIndex = 10;
            this.button_useSahara_fhf.Text = "Проверить выбранный программер";
            this.button_useSahara_fhf.UseVisualStyleBackColor = true;
            this.button_useSahara_fhf.Visible = false;
            this.button_useSahara_fhf.Click += new System.EventHandler(this.Button__useSahara_fhf_Click);
            // 
            // textBox_oemid
            // 
            this.textBox_oemid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemid.Location = new System.Drawing.Point(657, 40);
            this.textBox_oemid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemid.MaxLength = 4;
            this.textBox_oemid.Name = "textBox_oemid";
            this.textBox_oemid.Size = new System.Drawing.Size(45, 22);
            this.textBox_oemid.TabIndex = 4;
            // 
            // label_modelid
            // 
            this.label_modelid.AutoSize = true;
            this.label_modelid.Location = new System.Drawing.Point(708, 43);
            this.label_modelid.Name = "label_modelid";
            this.label_modelid.Size = new System.Drawing.Size(78, 17);
            this.label_modelid.TabIndex = 3;
            this.label_modelid.Text = "MODEL_ID";
            // 
            // textBox_hwid
            // 
            this.textBox_hwid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_hwid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_hwid.Location = new System.Drawing.Point(484, 40);
            this.textBox_hwid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_hwid.MaxLength = 8;
            this.textBox_hwid.Name = "textBox_hwid";
            this.textBox_hwid.Size = new System.Drawing.Size(83, 22);
            this.textBox_hwid.TabIndex = 0;
            // 
            // label_oemid
            // 
            this.label_oemid.AutoSize = true;
            this.label_oemid.Location = new System.Drawing.Point(573, 43);
            this.label_oemid.Name = "label_oemid";
            this.label_oemid.Size = new System.Drawing.Size(60, 17);
            this.label_oemid.TabIndex = 5;
            this.label_oemid.Text = "OEM_ID";
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(398, 116);
            this.button_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(275, 23);
            this.button_path.TabIndex = 9;
            this.button_path.Text = "Выберите папку с программерами";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.Button_path_Click);
            // 
            // textBox_oemhash
            // 
            this.textBox_oemhash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemhash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemhash.Location = new System.Drawing.Point(512, 77);
            this.textBox_oemhash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemhash.MaxLength = 96;
            this.textBox_oemhash.Name = "textBox_oemhash";
            this.textBox_oemhash.Size = new System.Drawing.Size(545, 22);
            this.textBox_oemhash.TabIndex = 6;
            // 
            // label_oemhash
            // 
            this.label_oemhash.AutoSize = true;
            this.label_oemhash.Location = new System.Drawing.Point(395, 79);
            this.label_oemhash.Name = "label_oemhash";
            this.label_oemhash.Size = new System.Drawing.Size(111, 17);
            this.label_oemhash.TabIndex = 7;
            this.label_oemhash.Text = "OEM_PK_HASH";
            // 
            // textBox_modelid
            // 
            this.textBox_modelid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_modelid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_modelid.Location = new System.Drawing.Point(810, 40);
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
            this.statusStrip_firehose.Location = new System.Drawing.Point(3, 515);
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
            this.toolStripProgressBar_filescompleted.Name = "toolStripProgressBar_filescompleted";
            this.toolStripProgressBar_filescompleted.Size = new System.Drawing.Size(400, 22);
            this.toolStripProgressBar_filescompleted.Step = 1;
            // 
            // toolStripStatusLabel_vol
            // 
            this.toolStripStatusLabel_vol.Name = "toolStripStatusLabel_vol";
            this.toolStripStatusLabel_vol.Size = new System.Drawing.Size(0, 24);
            // 
            // tabPage_phone
            // 
            this.tabPage_phone.Controls.Add(this.groupBox2);
            this.tabPage_phone.Controls.Add(this.groupBox3);
            this.tabPage_phone.Controls.Add(this.groupBox1);
            this.tabPage_phone.Location = new System.Drawing.Point(4, 25);
            this.tabPage_phone.Name = "tabPage_phone";
            this.tabPage_phone.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_phone.Size = new System.Drawing.Size(1361, 547);
            this.tabPage_phone.TabIndex = 2;
            this.tabPage_phone.Text = "Работа с устройством";
            this.tabPage_phone.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox_logs);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_mem_type);
            this.groupBox2.Controls.Add(this.comboBox_fh_command);
            this.groupBox2.Controls.Add(this.checkBox_reset);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_Sahara_CommandStart);
            this.groupBox2.Controls.Add(this.button_Sahara_Ids);
            this.groupBox2.Controls.Add(this.label_Sahara_fhf);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.listView_comport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(481, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sahara";
            // 
            // groupBox_logs
            // 
            this.groupBox_logs.Controls.Add(this.radioButton_fulllog);
            this.groupBox_logs.Controls.Add(this.radioButton_shortlog);
            this.groupBox_logs.Location = new System.Drawing.Point(487, 345);
            this.groupBox_logs.Name = "groupBox_logs";
            this.groupBox_logs.Size = new System.Drawing.Size(353, 58);
            this.groupBox_logs.TabIndex = 10;
            this.groupBox_logs.TabStop = false;
            this.groupBox_logs.Text = "Вывод логов в терминал";
            // 
            // radioButton_fulllog
            // 
            this.radioButton_fulllog.AutoSize = true;
            this.radioButton_fulllog.Location = new System.Drawing.Point(139, 22);
            this.radioButton_fulllog.Name = "radioButton_fulllog";
            this.radioButton_fulllog.Size = new System.Drawing.Size(105, 21);
            this.radioButton_fulllog.TabIndex = 1;
            this.radioButton_fulllog.Text = "Подробный";
            this.radioButton_fulllog.UseVisualStyleBackColor = true;
            // 
            // radioButton_shortlog
            // 
            this.radioButton_shortlog.AutoSize = true;
            this.radioButton_shortlog.Checked = true;
            this.radioButton_shortlog.Location = new System.Drawing.Point(7, 22);
            this.radioButton_shortlog.Name = "radioButton_shortlog";
            this.radioButton_shortlog.Size = new System.Drawing.Size(122, 21);
            this.radioButton_shortlog.TabIndex = 0;
            this.radioButton_shortlog.TabStop = true;
            this.radioButton_shortlog.Text = "Сокращённый";
            this.radioButton_shortlog.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 34);
            this.label3.TabIndex = 9;
            this.label3.Text = "Тип памяти\r\n(eMMC по-умолчанию)";
            // 
            // comboBox_mem_type
            // 
            this.comboBox_mem_type.Enabled = false;
            this.comboBox_mem_type.FormattingEnabled = true;
            this.comboBox_mem_type.Items.AddRange(new object[] {
            "eMMC",
            "UFS"});
            this.comboBox_mem_type.Location = new System.Drawing.Point(687, 313);
            this.comboBox_mem_type.Name = "comboBox_mem_type";
            this.comboBox_mem_type.Size = new System.Drawing.Size(153, 24);
            this.comboBox_mem_type.TabIndex = 8;
            // 
            // comboBox_fh_command
            // 
            this.comboBox_fh_command.Enabled = false;
            this.comboBox_fh_command.FormattingEnabled = true;
            this.comboBox_fh_command.Items.AddRange(new object[] {
            "Проверка firehose (только перезагрузка устройства)"});
            this.comboBox_fh_command.Location = new System.Drawing.Point(7, 314);
            this.comboBox_fh_command.Name = "comboBox_fh_command";
            this.comboBox_fh_command.Size = new System.Drawing.Size(462, 24);
            this.comboBox_fh_command.TabIndex = 7;
            this.comboBox_fh_command.Text = "Выберите команду";
            this.comboBox_fh_command.SelectedIndexChanged += new System.EventHandler(this.ComboBox_fh_command_SelectedIndexChanged);
            // 
            // checkBox_reset
            // 
            this.checkBox_reset.AutoSize = true;
            this.checkBox_reset.Checked = true;
            this.checkBox_reset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_reset.Enabled = false;
            this.checkBox_reset.Location = new System.Drawing.Point(7, 344);
            this.checkBox_reset.Name = "checkBox_reset";
            this.checkBox_reset.Size = new System.Drawing.Size(334, 38);
            this.checkBox_reset.TabIndex = 6;
            this.checkBox_reset.Text = "Перегрузить устройство в нормальный режим\r\nпосле выполнения запроса";
            this.checkBox_reset.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Для этой команды программер не нужен";
            // 
            // button_Sahara_CommandStart
            // 
            this.button_Sahara_CommandStart.Enabled = false;
            this.button_Sahara_CommandStart.Location = new System.Drawing.Point(487, 314);
            this.button_Sahara_CommandStart.Name = "button_Sahara_CommandStart";
            this.button_Sahara_CommandStart.Size = new System.Drawing.Size(170, 23);
            this.button_Sahara_CommandStart.TabIndex = 4;
            this.button_Sahara_CommandStart.Text = "Выполнить команду";
            this.button_Sahara_CommandStart.UseVisualStyleBackColor = true;
            this.button_Sahara_CommandStart.Click += new System.EventHandler(this.Button_Sahara_CommandStart_Click);
            // 
            // button_Sahara_Ids
            // 
            this.button_Sahara_Ids.Enabled = false;
            this.button_Sahara_Ids.Location = new System.Drawing.Point(6, 199);
            this.button_Sahara_Ids.Name = "button_Sahara_Ids";
            this.button_Sahara_Ids.Size = new System.Drawing.Size(307, 23);
            this.button_Sahara_Ids.TabIndex = 3;
            this.button_Sahara_Ids.Text = "Получить идентификаторы устройства";
            this.button_Sahara_Ids.UseVisualStyleBackColor = true;
            this.button_Sahara_Ids.Click += new System.EventHandler(this.Button_Sahara_Ids_Click);
            // 
            // label_Sahara_fhf
            // 
            this.label_Sahara_fhf.AutoSize = true;
            this.label_Sahara_fhf.Location = new System.Drawing.Point(3, 289);
            this.label_Sahara_fhf.Name = "label_Sahara_fhf";
            this.label_Sahara_fhf.Size = new System.Drawing.Size(371, 17);
            this.label_Sahara_fhf.TabIndex = 2;
            this.label_Sahara_fhf.Text = "Выберете программер на вкладке \"Работа с файлами\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(821, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // listView_comport
            // 
            this.listView_comport.CheckBoxes = true;
            this.listView_comport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_portnum,
            this.columnHeader_portname});
            this.listView_comport.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView_comport.HideSelection = false;
            this.listView_comport.Location = new System.Drawing.Point(3, 18);
            this.listView_comport.Name = "listView_comport";
            this.listView_comport.Size = new System.Drawing.Size(871, 158);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_ADB_start);
            this.groupBox3.Controls.Add(this.button_ADB_comstart);
            this.groupBox3.Controls.Add(this.button_ADB_clear);
            this.groupBox3.Controls.Add(this.textBox_ADB_commandstring);
            this.groupBox3.Controls.Add(this.comboBox_ADB_commands);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(481, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(877, 127);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Android Debug Bridge";
            // 
            // button_ADB_start
            // 
            this.button_ADB_start.Location = new System.Drawing.Point(6, 21);
            this.button_ADB_start.Name = "button_ADB_start";
            this.button_ADB_start.Size = new System.Drawing.Size(213, 23);
            this.button_ADB_start.TabIndex = 2;
            this.button_ADB_start.Text = "Подключить ADB";
            this.button_ADB_start.UseVisualStyleBackColor = true;
            this.button_ADB_start.Click += new System.EventHandler(this.Button_ADB_start_Click);
            // 
            // button_ADB_comstart
            // 
            this.button_ADB_comstart.Enabled = false;
            this.button_ADB_comstart.Location = new System.Drawing.Point(225, 93);
            this.button_ADB_comstart.Name = "button_ADB_comstart";
            this.button_ADB_comstart.Size = new System.Drawing.Size(206, 23);
            this.button_ADB_comstart.TabIndex = 5;
            this.button_ADB_comstart.Text = "Выполнить команду";
            this.button_ADB_comstart.UseVisualStyleBackColor = true;
            this.button_ADB_comstart.Click += new System.EventHandler(this.Button_ADB_comstart_Click);
            // 
            // button_ADB_clear
            // 
            this.button_ADB_clear.Location = new System.Drawing.Point(225, 21);
            this.button_ADB_clear.Name = "button_ADB_clear";
            this.button_ADB_clear.Size = new System.Drawing.Size(206, 23);
            this.button_ADB_clear.TabIndex = 3;
            this.button_ADB_clear.Text = "Очистить и закрыть ADB";
            this.button_ADB_clear.UseVisualStyleBackColor = true;
            this.button_ADB_clear.Click += new System.EventHandler(this.Button_ADB_clear_Click);
            // 
            // textBox_ADB_commandstring
            // 
            this.textBox_ADB_commandstring.Location = new System.Drawing.Point(6, 93);
            this.textBox_ADB_commandstring.Name = "textBox_ADB_commandstring";
            this.textBox_ADB_commandstring.Size = new System.Drawing.Size(213, 22);
            this.textBox_ADB_commandstring.TabIndex = 6;
            this.textBox_ADB_commandstring.Visible = false;
            this.textBox_ADB_commandstring.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_ADB_commandstring_KeyUp);
            // 
            // comboBox_ADB_commands
            // 
            this.comboBox_ADB_commands.Enabled = false;
            this.comboBox_ADB_commands.FormattingEnabled = true;
            this.comboBox_ADB_commands.Items.AddRange(new object[] {
            "Перегрузить устройство в аварийный режим",
            "Параметры устройства (модель, тип памяти)",
            "Командная строка (ADB Shell)"});
            this.comboBox_ADB_commands.Location = new System.Drawing.Point(6, 63);
            this.comboBox_ADB_commands.Name = "comboBox_ADB_commands";
            this.comboBox_ADB_commands.Size = new System.Drawing.Size(462, 24);
            this.comboBox_ADB_commands.TabIndex = 4;
            this.comboBox_ADB_commands.Text = "Выберите команду";
            this.comboBox_ADB_commands.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ADB_commands_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ADB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 541);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Terminal";
            // 
            // textBox_ADB
            // 
            this.textBox_ADB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ADB.Location = new System.Drawing.Point(3, 18);
            this.textBox_ADB.Multiline = true;
            this.textBox_ADB.Name = "textBox_ADB";
            this.textBox_ADB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ADB.Size = new System.Drawing.Size(472, 520);
            this.textBox_ADB.TabIndex = 1;
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
            this.tabControl1.Size = new System.Drawing.Size(1369, 576);
            this.tabControl1.TabIndex = 0;
            // 
            // bindingSource_collection
            // 
            this.bindingSource_collection.AllowNew = false;
            // 
            // Formfhf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 604);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip_firehose.ResumeLayout(false);
            this.statusStrip_firehose.PerformLayout();
            this.tabPage_phone.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_logs.ResumeLayout(false);
            this.groupBox_logs.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_collection)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem справочникУстройствToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСУстройствомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вопросОтветToolStripMenuItem;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem неподтверждённыеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabPage tabPage_collection;
        private System.Windows.Forms.DataGridView dataGridView_collection;
        private System.Windows.Forms.TabPage tabPage_firehose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_main_term;
        private System.Windows.Forms.DataGridView dataGridView_final;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.CheckBox checkBox_send;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.CheckBox checkBox_Log;
        private System.Windows.Forms.Button button_findIDs;
        private System.Windows.Forms.Label label_tm_model;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox_logs;
        private System.Windows.Forms.RadioButton radioButton_fulllog;
        private System.Windows.Forms.RadioButton radioButton_shortlog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_mem_type;
        private System.Windows.Forms.ComboBox comboBox_fh_command;
        private System.Windows.Forms.CheckBox checkBox_reset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Sahara_CommandStart;
        private System.Windows.Forms.Button button_Sahara_Ids;
        private System.Windows.Forms.Label label_Sahara_fhf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView_comport;
        private System.Windows.Forms.ColumnHeader columnHeader_portnum;
        private System.Windows.Forms.ColumnHeader columnHeader_portname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_ADB_start;
        private System.Windows.Forms.Button button_ADB_comstart;
        private System.Windows.Forms.Button button_ADB_clear;
        private System.Windows.Forms.TextBox textBox_ADB_commandstring;
        private System.Windows.Forms.ComboBox comboBox_ADB_commands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_ADB;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Full;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SW_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Comp;
    }
}

