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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_firehose = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_final = new System.Windows.Forms.DataGridView();
            this.Column_Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Full = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SW_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_SW_Ver = new System.Windows.Forms.Label();
            this.label_swid = new System.Windows.Forms.Label();
            this.label_hwid = new System.Windows.Forms.Label();
            this.button_useSahara_fhf = new System.Windows.Forms.Button();
            this.textBox_oemid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.button_Sahara_Reset = new System.Windows.Forms.Button();
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
            this.tabPage_guide = new System.Windows.Forms.TabPage();
            this.radioButton_manualfilter = new System.Windows.Forms.RadioButton();
            this.radioButton_autofilter = new System.Windows.Forms.RadioButton();
            this.tabPage_about = new System.Windows.Forms.TabPage();
            this.richTextBox_about = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker_Read_File = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.qcom_phonesDataSet = new FirehoseFinder.qcom_phonesDataSet();
            this.для_фильтраBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.для_фильтраTableAdapter = new FirehoseFinder.qcom_phonesDataSetTableAdapters.Для_фильтраTableAdapter();
            this.tableAdapterManager = new FirehoseFinder.qcom_phonesDataSetTableAdapters.TableAdapterManager();
            this.для_фильтраDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage_firehose.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_final)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip_firehose.SuspendLayout();
            this.tabPage_phone.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_guide.SuspendLayout();
            this.tabPage_about.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qcom_phonesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.для_фильтраBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.для_фильтраDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_guide);
            this.tabControl1.Controls.Add(this.tabPage_firehose);
            this.tabControl1.Controls.Add(this.tabPage_phone);
            this.tabControl1.Controls.Add(this.tabPage_about);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1313, 604);
            this.tabControl1.TabIndex = 0;
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
            this.tabPage_firehose.Size = new System.Drawing.Size(1305, 575);
            this.tabPage_firehose.TabIndex = 0;
            this.tabPage_firehose.Text = "Работа с файлами";
            this.tabPage_firehose.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_final);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 440);
            this.panel2.TabIndex = 18;
            // 
            // dataGridView_final
            // 
            this.dataGridView_final.AllowUserToAddRows = false;
            this.dataGridView_final.AllowUserToDeleteRows = false;
            this.dataGridView_final.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_final.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Sel,
            this.Column_Name,
            this.Column_id,
            this.Column_rate,
            this.Column_Full,
            this.Column_SW_type});
            this.dataGridView_final.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView_final.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_final.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_final.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_final.MultiSelect = false;
            this.dataGridView_final.Name = "dataGridView_final";
            this.dataGridView_final.RowHeadersWidth = 51;
            this.dataGridView_final.RowTemplate.Height = 24;
            this.dataGridView_final.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_final.Size = new System.Drawing.Size(1299, 440);
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
            this.Column_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_Name.HeaderText = "Файл";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.Width = 74;
            // 
            // Column_id
            // 
            this.Column_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_id.HeaderText = "HW-OEM-MODEL-HASH-SW(Ver)";
            this.Column_id.MinimumWidth = 6;
            this.Column_id.Name = "Column_id";
            this.Column_id.Width = 252;
            // 
            // Column_rate
            // 
            this.Column_rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_rate.HeaderText = "Рейтинг (max10)";
            this.Column_rate.MinimumWidth = 6;
            this.Column_rate.Name = "Column_rate";
            this.Column_rate.Width = 133;
            // 
            // Column_Full
            // 
            this.Column_Full.HeaderText = "Full Ids";
            this.Column_Full.MinimumWidth = 6;
            this.Column_Full.Name = "Column_Full";
            this.Column_Full.Visible = false;
            this.Column_Full.Width = 125;
            // 
            // Column_SW_type
            // 
            this.Column_SW_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_SW_type.HeaderText = "Тип ПО";
            this.Column_SW_type.MinimumWidth = 6;
            this.Column_SW_type.Name = "Column_SW_type";
            this.Column_SW_type.Width = 62;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_SW_Ver);
            this.panel1.Controls.Add(this.label_swid);
            this.panel1.Controls.Add(this.label_hwid);
            this.panel1.Controls.Add(this.button_useSahara_fhf);
            this.panel1.Controls.Add(this.textBox_oemid);
            this.panel1.Controls.Add(this.label1);
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
            this.panel1.Size = new System.Drawing.Size(1299, 101);
            this.panel1.TabIndex = 17;
            // 
            // label_SW_Ver
            // 
            this.label_SW_Ver.AutoSize = true;
            this.label_SW_Ver.Location = new System.Drawing.Point(589, 12);
            this.label_SW_Ver.Name = "label_SW_Ver";
            this.label_SW_Ver.Size = new System.Drawing.Size(72, 17);
            this.label_SW_Ver.TabIndex = 19;
            this.label_SW_Ver.Text = "00000000";
            // 
            // label_swid
            // 
            this.label_swid.AutoSize = true;
            this.label_swid.Location = new System.Drawing.Point(438, 12);
            this.label_swid.Name = "label_swid";
            this.label_swid.Size = new System.Drawing.Size(153, 17);
            this.label_swid.TabIndex = 18;
            this.label_swid.Text = "SBL SWID (Version) 0x";
            // 
            // label_hwid
            // 
            this.label_hwid.AutoSize = true;
            this.label_hwid.Location = new System.Drawing.Point(5, 11);
            this.label_hwid.Name = "label_hwid";
            this.label_hwid.Size = new System.Drawing.Size(70, 17);
            this.label_hwid.TabIndex = 1;
            this.label_hwid.Text = "HW_ID 0x";
            // 
            // button_useSahara_fhf
            // 
            this.button_useSahara_fhf.Location = new System.Drawing.Point(290, 68);
            this.button_useSahara_fhf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_useSahara_fhf.Name = "button_useSahara_fhf";
            this.button_useSahara_fhf.Size = new System.Drawing.Size(324, 23);
            this.button_useSahara_fhf.TabIndex = 10;
            this.button_useSahara_fhf.Text = "Использовать в работе с устройством";
            this.button_useSahara_fhf.UseVisualStyleBackColor = true;
            this.button_useSahara_fhf.Visible = false;
            this.button_useSahara_fhf.Click += new System.EventHandler(this.Button__useSahara_fhf_Click);
            // 
            // textBox_oemid
            // 
            this.textBox_oemid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemid.Location = new System.Drawing.Point(239, 10);
            this.textBox_oemid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemid.MaxLength = 4;
            this.textBox_oemid.Name = "textBox_oemid";
            this.textBox_oemid.Size = new System.Drawing.Size(43, 22);
            this.textBox_oemid.TabIndex = 4;
            this.textBox_oemid.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Алгоритм SHA-256";
            // 
            // label_modelid
            // 
            this.label_modelid.AutoSize = true;
            this.label_modelid.Location = new System.Drawing.Point(287, 14);
            this.label_modelid.Name = "label_modelid";
            this.label_modelid.Size = new System.Drawing.Size(96, 17);
            this.label_modelid.TabIndex = 3;
            this.label_modelid.Text = "MODEL_ID 0x";
            // 
            // textBox_hwid
            // 
            this.textBox_hwid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_hwid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_hwid.Location = new System.Drawing.Point(80, 9);
            this.textBox_hwid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_hwid.MaxLength = 8;
            this.textBox_hwid.Name = "textBox_hwid";
            this.textBox_hwid.Size = new System.Drawing.Size(73, 22);
            this.textBox_hwid.TabIndex = 0;
            this.textBox_hwid.Text = "00000000";
            // 
            // label_oemid
            // 
            this.label_oemid.AutoSize = true;
            this.label_oemid.Location = new System.Drawing.Point(159, 11);
            this.label_oemid.Name = "label_oemid";
            this.label_oemid.Size = new System.Drawing.Size(78, 17);
            this.label_oemid.TabIndex = 5;
            this.label_oemid.Text = "OEM_ID 0x";
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(5, 68);
            this.button_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(275, 23);
            this.button_path.TabIndex = 9;
            this.button_path.Text = "~Рабочий стол";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.Button_path_Click);
            // 
            // textBox_oemhash
            // 
            this.textBox_oemhash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemhash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemhash.Location = new System.Drawing.Point(95, 42);
            this.textBox_oemhash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemhash.MaxLength = 64;
            this.textBox_oemhash.Name = "textBox_oemhash";
            this.textBox_oemhash.Size = new System.Drawing.Size(559, 22);
            this.textBox_oemhash.TabIndex = 6;
            // 
            // label_oemhash
            // 
            this.label_oemhash.AutoSize = true;
            this.label_oemhash.Location = new System.Drawing.Point(5, 43);
            this.label_oemhash.Name = "label_oemhash";
            this.label_oemhash.Size = new System.Drawing.Size(85, 17);
            this.label_oemhash.TabIndex = 7;
            this.label_oemhash.Text = "OEM_HASH";
            // 
            // textBox_modelid
            // 
            this.textBox_modelid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_modelid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_modelid.Location = new System.Drawing.Point(388, 11);
            this.textBox_modelid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_modelid.MaxLength = 4;
            this.textBox_modelid.Name = "textBox_modelid";
            this.textBox_modelid.Size = new System.Drawing.Size(43, 22);
            this.textBox_modelid.TabIndex = 2;
            this.textBox_modelid.Text = "0000";
            // 
            // statusStrip_firehose
            // 
            this.statusStrip_firehose.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_firehose.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_filescompleted,
            this.toolStripProgressBar_filescompleted,
            this.toolStripStatusLabel_vol});
            this.statusStrip_firehose.Location = new System.Drawing.Point(3, 543);
            this.statusStrip_firehose.Name = "statusStrip_firehose";
            this.statusStrip_firehose.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip_firehose.Size = new System.Drawing.Size(1299, 30);
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
            this.tabPage_phone.Size = new System.Drawing.Size(1305, 575);
            this.tabPage_phone.TabIndex = 2;
            this.tabPage_phone.Text = "Работа с устройством";
            this.tabPage_phone.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_Sahara_Reset);
            this.groupBox2.Controls.Add(this.button_Sahara_Ids);
            this.groupBox2.Controls.Add(this.label_Sahara_fhf);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.listView_comport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(481, 359);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(821, 213);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sahara";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Для этой команды программер не нужен";
            // 
            // button_Sahara_Reset
            // 
            this.button_Sahara_Reset.Enabled = false;
            this.button_Sahara_Reset.Location = new System.Drawing.Point(6, 179);
            this.button_Sahara_Reset.Name = "button_Sahara_Reset";
            this.button_Sahara_Reset.Size = new System.Drawing.Size(348, 23);
            this.button_Sahara_Reset.TabIndex = 4;
            this.button_Sahara_Reset.Text = "Перегрузить устройство в нормальный режим";
            this.button_Sahara_Reset.UseVisualStyleBackColor = true;
            this.button_Sahara_Reset.Click += new System.EventHandler(this.Button_Sahara_Reset_Click);
            // 
            // button_Sahara_Ids
            // 
            this.button_Sahara_Ids.Enabled = false;
            this.button_Sahara_Ids.Location = new System.Drawing.Point(6, 133);
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
            this.label_Sahara_fhf.Location = new System.Drawing.Point(317, 159);
            this.label_Sahara_fhf.Name = "label_Sahara_fhf";
            this.label_Sahara_fhf.Size = new System.Drawing.Size(382, 17);
            this.label_Sahara_fhf.TabIndex = 2;
            this.label_Sahara_fhf.Text = "Пожалуйста, выберете на закладке \"Работа с файлами\"";
            this.label_Sahara_fhf.TextChanged += new System.EventHandler(this.Label_Sahara_fhf_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Для команд ниже используется программер: ";
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
            this.listView_comport.Size = new System.Drawing.Size(815, 92);
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
            this.groupBox3.Size = new System.Drawing.Size(821, 185);
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
            "Получить список параметров устройства",
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
            this.groupBox1.Size = new System.Drawing.Size(478, 569);
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
            this.textBox_ADB.Size = new System.Drawing.Size(472, 548);
            this.textBox_ADB.TabIndex = 1;
            // 
            // tabPage_guide
            // 
            this.tabPage_guide.Controls.Add(this.для_фильтраDataGridView);
            this.tabPage_guide.Controls.Add(this.radioButton_manualfilter);
            this.tabPage_guide.Controls.Add(this.radioButton_autofilter);
            this.tabPage_guide.Location = new System.Drawing.Point(4, 25);
            this.tabPage_guide.Name = "tabPage_guide";
            this.tabPage_guide.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_guide.Size = new System.Drawing.Size(1305, 575);
            this.tabPage_guide.TabIndex = 3;
            this.tabPage_guide.Text = "Справочник ID";
            this.tabPage_guide.UseVisualStyleBackColor = true;
            // 
            // radioButton_manualfilter
            // 
            this.radioButton_manualfilter.AutoSize = true;
            this.radioButton_manualfilter.Location = new System.Drawing.Point(6, 37);
            this.radioButton_manualfilter.Name = "radioButton_manualfilter";
            this.radioButton_manualfilter.Size = new System.Drawing.Size(549, 21);
            this.radioButton_manualfilter.TabIndex = 1;
            this.radioButton_manualfilter.Text = "Вручную применить фильтр для выбора идентификаторов модели устройства";
            this.radioButton_manualfilter.UseVisualStyleBackColor = true;
            // 
            // radioButton_autofilter
            // 
            this.radioButton_autofilter.AutoSize = true;
            this.radioButton_autofilter.Checked = true;
            this.radioButton_autofilter.Location = new System.Drawing.Point(6, 9);
            this.radioButton_autofilter.Name = "radioButton_autofilter";
            this.radioButton_autofilter.Size = new System.Drawing.Size(707, 21);
            this.radioButton_autofilter.TabIndex = 0;
            this.radioButton_autofilter.TabStop = true;
            this.radioButton_autofilter.Text = "Автоматически отфильтровать данные справочника по идентификаторам подключённого у" +
    "стройства";
            this.radioButton_autofilter.UseVisualStyleBackColor = true;
            // 
            // tabPage_about
            // 
            this.tabPage_about.Controls.Add(this.richTextBox_about);
            this.tabPage_about.Location = new System.Drawing.Point(4, 25);
            this.tabPage_about.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_about.Name = "tabPage_about";
            this.tabPage_about.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_about.Size = new System.Drawing.Size(1305, 575);
            this.tabPage_about.TabIndex = 1;
            this.tabPage_about.Text = "О программе";
            this.tabPage_about.UseVisualStyleBackColor = true;
            // 
            // richTextBox_about
            // 
            this.richTextBox_about.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_about.Location = new System.Drawing.Point(3, 2);
            this.richTextBox_about.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox_about.Name = "richTextBox_about";
            this.richTextBox_about.Size = new System.Drawing.Size(1299, 571);
            this.richTextBox_about.TabIndex = 1;
            this.richTextBox_about.Text = "";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Укажите путь к папке с программерами";
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
            // qcom_phonesDataSet
            // 
            this.qcom_phonesDataSet.DataSetName = "qcom_phonesDataSet";
            this.qcom_phonesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // для_фильтраBindingSource
            // 
            this.для_фильтраBindingSource.DataMember = "Для фильтра";
            this.для_фильтраBindingSource.DataSource = this.qcom_phonesDataSet;
            // 
            // для_фильтраTableAdapter
            // 
            this.для_фильтраTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CPUsTableAdapter = null;
            this.tableAdapterManager.FullDBTableAdapter = null;
            this.tableAdapterManager.HASH_IDsTableAdapter = null;
            this.tableAdapterManager.HW_IDsTableAdapter = null;
            this.tableAdapterManager.OEM_IDsTableAdapter = null;
            this.tableAdapterManager.Phone_ModelsTableAdapter = null;
            this.tableAdapterManager.SellersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = FirehoseFinder.qcom_phonesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VendorsTableAdapter = null;
            // 
            // для_фильтраDataGridView
            // 
            this.для_фильтраDataGridView.AutoGenerateColumns = false;
            this.для_фильтраDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.для_фильтраDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.для_фильтраDataGridView.DataSource = this.для_фильтраBindingSource;
            this.для_фильтраDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.для_фильтраDataGridView.Location = new System.Drawing.Point(3, 251);
            this.для_фильтраDataGridView.Name = "для_фильтраDataGridView";
            this.для_фильтраDataGridView.RowHeadersWidth = 51;
            this.для_фильтраDataGridView.RowTemplate.Height = 24;
            this.для_фильтраDataGridView.Size = new System.Drawing.Size(1299, 321);
            this.для_фильтраDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "HWID";
            this.dataGridViewTextBoxColumn1.HeaderText = "HWID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OEMID";
            this.dataGridViewTextBoxColumn2.HeaderText = "OEMID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MODELID";
            this.dataGridViewTextBoxColumn3.HeaderText = "MODELID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HASHID";
            this.dataGridViewTextBoxColumn4.HeaderText = "HASHID";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Trademark";
            this.dataGridViewTextBoxColumn5.HeaderText = "Trademark";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Model";
            this.dataGridViewTextBoxColumn6.HeaderText = "Model";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // Formfhf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 604);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formfhf";
            this.Text = "Firehose Finder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formfhf_FormClosing);
            this.Load += new System.EventHandler(this.Formfhf_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_firehose.ResumeLayout(false);
            this.tabPage_firehose.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_final)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip_firehose.ResumeLayout(false);
            this.statusStrip_firehose.PerformLayout();
            this.tabPage_phone.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_guide.ResumeLayout(false);
            this.tabPage_guide.PerformLayout();
            this.tabPage_about.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qcom_phonesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.для_фильтраBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.для_фильтраDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_firehose;
        private System.Windows.Forms.TabPage tabPage_about;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip_firehose;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_filescompleted;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_filescompleted;
        private System.Windows.Forms.RichTextBox richTextBox_about;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_vol;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_final;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_hwid;
        private System.Windows.Forms.Button button_useSahara_fhf;
        private System.Windows.Forms.TextBox textBox_oemid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_modelid;
        private System.Windows.Forms.TextBox textBox_hwid;
        private System.Windows.Forms.Label label_oemid;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.TextBox textBox_oemhash;
        private System.Windows.Forms.Label label_oemhash;
        private System.Windows.Forms.TextBox textBox_modelid;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Read_File;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Full;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SW_type;
        private System.Windows.Forms.TabPage tabPage_phone;
        private System.Windows.Forms.TabPage tabPage_guide;
        private System.Windows.Forms.Button button_ADB_start;
        private System.Windows.Forms.TextBox textBox_ADB;
        private System.Windows.Forms.Button button_ADB_clear;
        private System.Windows.Forms.ComboBox comboBox_ADB_commands;
        private System.Windows.Forms.Button button_ADB_comstart;
        private System.Windows.Forms.TextBox textBox_ADB_commandstring;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_comport;
        private System.Windows.Forms.ColumnHeader columnHeader_portnum;
        private System.Windows.Forms.ColumnHeader columnHeader_portname;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label_Sahara_fhf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Sahara_Ids;
        private System.Windows.Forms.Label label_SW_Ver;
        private System.Windows.Forms.Label label_swid;
        private System.Windows.Forms.Button button_Sahara_Reset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_manualfilter;
        private System.Windows.Forms.RadioButton radioButton_autofilter;
        private qcom_phonesDataSet qcom_phonesDataSet;
        private System.Windows.Forms.BindingSource для_фильтраBindingSource;
        private qcom_phonesDataSetTableAdapters.Для_фильтраTableAdapter для_фильтраTableAdapter;
        private qcom_phonesDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView для_фильтраDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}

