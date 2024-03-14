
namespace FirehoseFinder
{
    partial class Hex_Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hex_Search));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_hex_search = new System.ComponentModel.BackgroundWorker();
            this.statusStrip_search = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar_search = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_search = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel_hs = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_search = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_byte_text = new System.Windows.Forms.GroupBox();
            this.textBox_hexsearch = new System.Windows.Forms.TextBox();
            this.textBox_byte_search = new System.Windows.Forms.TextBox();
            this.radioButton_search_text = new System.Windows.Forms.RadioButton();
            this.radioButton_byte_search = new System.Windows.Forms.RadioButton();
            this.button_start_search = new System.Windows.Forms.Button();
            this.groupBox_hs = new System.Windows.Forms.GroupBox();
            this.radioButton_dir = new System.Windows.Forms.RadioButton();
            this.radioButton_file = new System.Windows.Forms.RadioButton();
            this.groupBox_addbytes = new System.Windows.Forms.GroupBox();
            this.textBox_addlast = new System.Windows.Forms.TextBox();
            this.textBox_addfirst = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_mask = new System.Windows.Forms.TabPage();
            this.tabPage_dd = new System.Windows.Forms.TabPage();
            this.label_path = new System.Windows.Forms.Label();
            this.button_destr = new System.Windows.Forms.Button();
            this.groupBox_sector = new System.Windows.Forms.GroupBox();
            this.textBox_sector = new System.Windows.Forms.TextBox();
            this.listView_dd = new System.Windows.Forms.ListView();
            this.columnHeader_ss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ls = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_pn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_pl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_bl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_dd = new System.Windows.Forms.Button();
            this.tabPage_folders = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView_dubl_files = new System.Windows.Forms.ListView();
            this.columnHeader_fullpath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_filelen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_dubl_files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.поменятьМестамиОригиналИДубликатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выбратьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снятьВесьВыборToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_dubl = new System.Windows.Forms.GroupBox();
            this.radioButton_dd_yes = new System.Windows.Forms.RadioButton();
            this.radioButton_dd_no = new System.Windows.Forms.RadioButton();
            this.groupBox_orig = new System.Windows.Forms.GroupBox();
            this.radioButton_od_yes = new System.Windows.Forms.RadioButton();
            this.radioButton_od_no = new System.Windows.Forms.RadioButton();
            this.button_dubl = new System.Windows.Forms.Button();
            this.button_orig = new System.Windows.Forms.Button();
            this.groupBox_comp = new System.Windows.Forms.GroupBox();
            this.radioButton_hashonly = new System.Windows.Forms.RadioButton();
            this.radioButton_nameandhash = new System.Windows.Forms.RadioButton();
            this.button_exe = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.tabPage_files = new System.Windows.Forms.TabPage();
            this.groupBox_dif = new System.Windows.Forms.GroupBox();
            this.label_newdir = new System.Windows.Forms.Label();
            this.button_comp = new System.Windows.Forms.Button();
            this.groupBox_raw = new System.Windows.Forms.GroupBox();
            this.label_raw_secsize = new System.Windows.Forms.Label();
            this.comboBox_raw_secsize = new System.Windows.Forms.ComboBox();
            this.label_raw_lun = new System.Windows.Forms.Label();
            this.textBox_raw_lun = new System.Windows.Forms.TextBox();
            this.checkBox_difraw = new System.Windows.Forms.CheckBox();
            this.checkBox_difbin = new System.Windows.Forms.CheckBox();
            this.checkBox_diftxt = new System.Windows.Forms.CheckBox();
            this.button_df = new System.Windows.Forms.Button();
            this.button_of = new System.Windows.Forms.Button();
            this.folderBrowserDialog_orig = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_dubl = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker_orig = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_dubl = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_destr = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog_of = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_df = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_comp = new System.ComponentModel.BackgroundWorker();
            this.statusStrip_search.SuspendLayout();
            this.tableLayoutPanel_hs.SuspendLayout();
            this.groupBox_byte_text.SuspendLayout();
            this.groupBox_hs.SuspendLayout();
            this.groupBox_addbytes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_mask.SuspendLayout();
            this.tabPage_dd.SuspendLayout();
            this.groupBox_sector.SuspendLayout();
            this.tabPage_folders.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip_dubl_files.SuspendLayout();
            this.groupBox_dubl.SuspendLayout();
            this.groupBox_orig.SuspendLayout();
            this.groupBox_comp.SuspendLayout();
            this.tabPage_files.SuspendLayout();
            this.groupBox_dif.SuspendLayout();
            this.groupBox_raw.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker_hex_search
            // 
            this.backgroundWorker_hex_search.WorkerReportsProgress = true;
            this.backgroundWorker_hex_search.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_hex_search_DoWork);
            this.backgroundWorker_hex_search.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_hex_search_ProgressChanged);
            this.backgroundWorker_hex_search.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_hex_search_RunWorkerCompleted);
            // 
            // statusStrip_search
            // 
            this.statusStrip_search.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_search.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar_search,
            this.toolStripStatusLabel_search});
            resources.ApplyResources(this.statusStrip_search, "statusStrip_search");
            this.statusStrip_search.Name = "statusStrip_search";
            // 
            // toolStripProgressBar_search
            // 
            this.toolStripProgressBar_search.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripProgressBar_search.Name = "toolStripProgressBar_search";
            resources.ApplyResources(this.toolStripProgressBar_search, "toolStripProgressBar_search");
            this.toolStripProgressBar_search.Step = 1;
            this.toolStripProgressBar_search.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel_search
            // 
            this.toolStripStatusLabel_search.Name = "toolStripStatusLabel_search";
            resources.ApplyResources(this.toolStripStatusLabel_search, "toolStripStatusLabel_search");
            // 
            // tableLayoutPanel_hs
            // 
            resources.ApplyResources(this.tableLayoutPanel_hs, "tableLayoutPanel_hs");
            this.tableLayoutPanel_hs.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_hs.Controls.Add(this.listView_search, 0, 1);
            this.tableLayoutPanel_hs.Controls.Add(this.groupBox_byte_text, 1, 0);
            this.tableLayoutPanel_hs.Controls.Add(this.button_start_search, 2, 2);
            this.tableLayoutPanel_hs.Controls.Add(this.groupBox_hs, 2, 1);
            this.tableLayoutPanel_hs.Controls.Add(this.groupBox_addbytes, 2, 0);
            this.tableLayoutPanel_hs.Name = "tableLayoutPanel_hs";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // listView_search
            // 
            this.listView_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.tableLayoutPanel_hs.SetColumnSpan(this.listView_search, 2);
            resources.ApplyResources(this.listView_search, "listView_search");
            this.listView_search.FullRowSelect = true;
            this.listView_search.GridLines = true;
            this.listView_search.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_search.HideSelection = false;
            this.listView_search.MultiSelect = false;
            this.listView_search.Name = "listView_search";
            this.tableLayoutPanel_hs.SetRowSpan(this.listView_search, 2);
            this.listView_search.UseCompatibleStateImageBehavior = false;
            this.listView_search.View = System.Windows.Forms.View.Details;
            this.listView_search.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_search_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // groupBox_byte_text
            // 
            this.groupBox_byte_text.Controls.Add(this.textBox_hexsearch);
            this.groupBox_byte_text.Controls.Add(this.textBox_byte_search);
            this.groupBox_byte_text.Controls.Add(this.radioButton_search_text);
            this.groupBox_byte_text.Controls.Add(this.radioButton_byte_search);
            resources.ApplyResources(this.groupBox_byte_text, "groupBox_byte_text");
            this.groupBox_byte_text.Name = "groupBox_byte_text";
            this.groupBox_byte_text.TabStop = false;
            // 
            // textBox_hexsearch
            // 
            resources.ApplyResources(this.textBox_hexsearch, "textBox_hexsearch");
            this.textBox_hexsearch.Name = "textBox_hexsearch";
            this.textBox_hexsearch.TextChanged += new System.EventHandler(this.TextBox_hexsearch_TextChanged);
            // 
            // textBox_byte_search
            // 
            resources.ApplyResources(this.textBox_byte_search, "textBox_byte_search");
            this.textBox_byte_search.Name = "textBox_byte_search";
            this.textBox_byte_search.TextChanged += new System.EventHandler(this.TextBox_byte_search_TextChanged);
            // 
            // radioButton_search_text
            // 
            resources.ApplyResources(this.radioButton_search_text, "radioButton_search_text");
            this.radioButton_search_text.Name = "radioButton_search_text";
            this.radioButton_search_text.UseVisualStyleBackColor = true;
            this.radioButton_search_text.CheckedChanged += new System.EventHandler(this.RadioButton_search_text_CheckedChanged);
            // 
            // radioButton_byte_search
            // 
            resources.ApplyResources(this.radioButton_byte_search, "radioButton_byte_search");
            this.radioButton_byte_search.Checked = true;
            this.radioButton_byte_search.Name = "radioButton_byte_search";
            this.radioButton_byte_search.TabStop = true;
            this.radioButton_byte_search.UseVisualStyleBackColor = true;
            this.radioButton_byte_search.CheckedChanged += new System.EventHandler(this.RadioButton_byte_search_CheckedChanged);
            // 
            // button_start_search
            // 
            this.button_start_search.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_start_search, "button_start_search");
            this.button_start_search.Name = "button_start_search";
            this.button_start_search.UseVisualStyleBackColor = false;
            this.button_start_search.Click += new System.EventHandler(this.Button_start_search_Click);
            // 
            // groupBox_hs
            // 
            this.groupBox_hs.Controls.Add(this.radioButton_dir);
            this.groupBox_hs.Controls.Add(this.radioButton_file);
            resources.ApplyResources(this.groupBox_hs, "groupBox_hs");
            this.groupBox_hs.Name = "groupBox_hs";
            this.groupBox_hs.TabStop = false;
            // 
            // radioButton_dir
            // 
            resources.ApplyResources(this.radioButton_dir, "radioButton_dir");
            this.radioButton_dir.Name = "radioButton_dir";
            this.radioButton_dir.TabStop = true;
            this.radioButton_dir.UseVisualStyleBackColor = true;
            // 
            // radioButton_file
            // 
            resources.ApplyResources(this.radioButton_file, "radioButton_file");
            this.radioButton_file.Checked = true;
            this.radioButton_file.Name = "radioButton_file";
            this.radioButton_file.TabStop = true;
            this.radioButton_file.UseVisualStyleBackColor = true;
            // 
            // groupBox_addbytes
            // 
            this.groupBox_addbytes.Controls.Add(this.textBox_addlast);
            this.groupBox_addbytes.Controls.Add(this.textBox_addfirst);
            this.groupBox_addbytes.Controls.Add(this.label3);
            this.groupBox_addbytes.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox_addbytes, "groupBox_addbytes");
            this.groupBox_addbytes.Name = "groupBox_addbytes";
            this.groupBox_addbytes.TabStop = false;
            // 
            // textBox_addlast
            // 
            resources.ApplyResources(this.textBox_addlast, "textBox_addlast");
            this.textBox_addlast.Name = "textBox_addlast";
            // 
            // textBox_addfirst
            // 
            resources.ApplyResources(this.textBox_addfirst, "textBox_addfirst");
            this.textBox_addfirst.Name = "textBox_addfirst";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_mask);
            this.tabControl1.Controls.Add(this.tabPage_files);
            this.tabControl1.Controls.Add(this.tabPage_folders);
            this.tabControl1.Controls.Add(this.tabPage_dd);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl1_KeyDown);
            // 
            // tabPage_mask
            // 
            this.tabPage_mask.Controls.Add(this.tableLayoutPanel_hs);
            resources.ApplyResources(this.tabPage_mask, "tabPage_mask");
            this.tabPage_mask.Name = "tabPage_mask";
            this.tabPage_mask.UseVisualStyleBackColor = true;
            // 
            // tabPage_dd
            // 
            this.tabPage_dd.Controls.Add(this.label_path);
            this.tabPage_dd.Controls.Add(this.button_destr);
            this.tabPage_dd.Controls.Add(this.groupBox_sector);
            this.tabPage_dd.Controls.Add(this.listView_dd);
            this.tabPage_dd.Controls.Add(this.button_dd);
            resources.ApplyResources(this.tabPage_dd, "tabPage_dd");
            this.tabPage_dd.Name = "tabPage_dd";
            this.tabPage_dd.UseVisualStyleBackColor = true;
            // 
            // label_path
            // 
            resources.ApplyResources(this.label_path, "label_path");
            this.label_path.Name = "label_path";
            // 
            // button_destr
            // 
            this.button_destr.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_destr, "button_destr");
            this.button_destr.Name = "button_destr";
            this.button_destr.UseVisualStyleBackColor = false;
            this.button_destr.Click += new System.EventHandler(this.Button_destr_Click);
            // 
            // groupBox_sector
            // 
            this.groupBox_sector.Controls.Add(this.textBox_sector);
            resources.ApplyResources(this.groupBox_sector, "groupBox_sector");
            this.groupBox_sector.Name = "groupBox_sector";
            this.groupBox_sector.TabStop = false;
            // 
            // textBox_sector
            // 
            resources.ApplyResources(this.textBox_sector, "textBox_sector");
            this.textBox_sector.Name = "textBox_sector";
            // 
            // listView_dd
            // 
            this.listView_dd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ss,
            this.columnHeader_ls,
            this.columnHeader_pn,
            this.columnHeader_pl,
            this.columnHeader_bl});
            this.listView_dd.FullRowSelect = true;
            this.listView_dd.GridLines = true;
            this.listView_dd.HideSelection = false;
            resources.ApplyResources(this.listView_dd, "listView_dd");
            this.listView_dd.MultiSelect = false;
            this.listView_dd.Name = "listView_dd";
            this.listView_dd.ShowGroups = false;
            this.listView_dd.UseCompatibleStateImageBehavior = false;
            this.listView_dd.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_ss
            // 
            resources.ApplyResources(this.columnHeader_ss, "columnHeader_ss");
            // 
            // columnHeader_ls
            // 
            resources.ApplyResources(this.columnHeader_ls, "columnHeader_ls");
            // 
            // columnHeader_pn
            // 
            resources.ApplyResources(this.columnHeader_pn, "columnHeader_pn");
            // 
            // columnHeader_pl
            // 
            resources.ApplyResources(this.columnHeader_pl, "columnHeader_pl");
            // 
            // columnHeader_bl
            // 
            resources.ApplyResources(this.columnHeader_bl, "columnHeader_bl");
            // 
            // button_dd
            // 
            this.button_dd.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_dd, "button_dd");
            this.button_dd.Name = "button_dd";
            this.button_dd.UseVisualStyleBackColor = false;
            this.button_dd.Click += new System.EventHandler(this.Button_dd_Click);
            // 
            // tabPage_folders
            // 
            this.tabPage_folders.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage_folders, "tabPage_folders");
            this.tabPage_folders.Name = "tabPage_folders";
            this.tabPage_folders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.listView_dubl_files, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_dubl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_orig, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_dubl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_orig, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_comp, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_exe, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_del, 1, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // listView_dubl_files
            // 
            this.listView_dubl_files.CheckBoxes = true;
            this.listView_dubl_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_fullpath,
            this.columnHeader_filelen});
            this.tableLayoutPanel1.SetColumnSpan(this.listView_dubl_files, 2);
            this.listView_dubl_files.ContextMenuStrip = this.contextMenuStrip_dubl_files;
            resources.ApplyResources(this.listView_dubl_files, "listView_dubl_files");
            this.listView_dubl_files.FullRowSelect = true;
            this.listView_dubl_files.GridLines = true;
            this.listView_dubl_files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_dubl_files.HideSelection = false;
            this.listView_dubl_files.MultiSelect = false;
            this.listView_dubl_files.Name = "listView_dubl_files";
            this.listView_dubl_files.UseCompatibleStateImageBehavior = false;
            this.listView_dubl_files.View = System.Windows.Forms.View.Details;
            this.listView_dubl_files.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListView_dubl_files_ItemChecked);
            // 
            // columnHeader_fullpath
            // 
            resources.ApplyResources(this.columnHeader_fullpath, "columnHeader_fullpath");
            // 
            // columnHeader_filelen
            // 
            resources.ApplyResources(this.columnHeader_filelen, "columnHeader_filelen");
            // 
            // contextMenuStrip_dubl_files
            // 
            this.contextMenuStrip_dubl_files.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_dubl_files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поменятьМестамиОригиналИДубликатToolStripMenuItem,
            this.toolStripSeparator1,
            this.выбратьВсёToolStripMenuItem,
            this.снятьВесьВыборToolStripMenuItem});
            this.contextMenuStrip_dubl_files.Name = "contextMenuStrip_dubl_files";
            resources.ApplyResources(this.contextMenuStrip_dubl_files, "contextMenuStrip_dubl_files");
            this.contextMenuStrip_dubl_files.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip_dubl_files_Opening);
            // 
            // поменятьМестамиОригиналИДубликатToolStripMenuItem
            // 
            resources.ApplyResources(this.поменятьМестамиОригиналИДубликатToolStripMenuItem, "поменятьМестамиОригиналИДубликатToolStripMenuItem");
            this.поменятьМестамиОригиналИДубликатToolStripMenuItem.Name = "поменятьМестамиОригиналИДубликатToolStripMenuItem";
            this.поменятьМестамиОригиналИДубликатToolStripMenuItem.Click += new System.EventHandler(this.ПоменятьМестамиОригиналИДубликатToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // выбратьВсёToolStripMenuItem
            // 
            this.выбратьВсёToolStripMenuItem.Name = "выбратьВсёToolStripMenuItem";
            resources.ApplyResources(this.выбратьВсёToolStripMenuItem, "выбратьВсёToolStripMenuItem");
            this.выбратьВсёToolStripMenuItem.Click += new System.EventHandler(this.ВыбратьВсёToolStripMenuItem_Click);
            // 
            // снятьВесьВыборToolStripMenuItem
            // 
            this.снятьВесьВыборToolStripMenuItem.Name = "снятьВесьВыборToolStripMenuItem";
            resources.ApplyResources(this.снятьВесьВыборToolStripMenuItem, "снятьВесьВыборToolStripMenuItem");
            this.снятьВесьВыборToolStripMenuItem.Click += new System.EventHandler(this.СнятьВесьВыборToolStripMenuItem_Click);
            // 
            // groupBox_dubl
            // 
            this.groupBox_dubl.Controls.Add(this.radioButton_dd_yes);
            this.groupBox_dubl.Controls.Add(this.radioButton_dd_no);
            resources.ApplyResources(this.groupBox_dubl, "groupBox_dubl");
            this.groupBox_dubl.Name = "groupBox_dubl";
            this.groupBox_dubl.TabStop = false;
            // 
            // radioButton_dd_yes
            // 
            resources.ApplyResources(this.radioButton_dd_yes, "radioButton_dd_yes");
            this.radioButton_dd_yes.Name = "radioButton_dd_yes";
            this.radioButton_dd_yes.UseVisualStyleBackColor = true;
            // 
            // radioButton_dd_no
            // 
            resources.ApplyResources(this.radioButton_dd_no, "radioButton_dd_no");
            this.radioButton_dd_no.Checked = true;
            this.radioButton_dd_no.Name = "radioButton_dd_no";
            this.radioButton_dd_no.TabStop = true;
            this.radioButton_dd_no.UseVisualStyleBackColor = true;
            // 
            // groupBox_orig
            // 
            this.groupBox_orig.Controls.Add(this.radioButton_od_yes);
            this.groupBox_orig.Controls.Add(this.radioButton_od_no);
            resources.ApplyResources(this.groupBox_orig, "groupBox_orig");
            this.groupBox_orig.Name = "groupBox_orig";
            this.groupBox_orig.TabStop = false;
            // 
            // radioButton_od_yes
            // 
            resources.ApplyResources(this.radioButton_od_yes, "radioButton_od_yes");
            this.radioButton_od_yes.Name = "radioButton_od_yes";
            this.radioButton_od_yes.UseVisualStyleBackColor = true;
            // 
            // radioButton_od_no
            // 
            resources.ApplyResources(this.radioButton_od_no, "radioButton_od_no");
            this.radioButton_od_no.Checked = true;
            this.radioButton_od_no.Name = "radioButton_od_no";
            this.radioButton_od_no.TabStop = true;
            this.radioButton_od_no.UseVisualStyleBackColor = true;
            // 
            // button_dubl
            // 
            this.button_dubl.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_dubl, "button_dubl");
            this.button_dubl.Name = "button_dubl";
            this.button_dubl.UseVisualStyleBackColor = false;
            this.button_dubl.Click += new System.EventHandler(this.Button_dubl_Click);
            // 
            // button_orig
            // 
            this.button_orig.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_orig, "button_orig");
            this.button_orig.Name = "button_orig";
            this.button_orig.UseVisualStyleBackColor = false;
            this.button_orig.Click += new System.EventHandler(this.Button_orig_Click);
            // 
            // groupBox_comp
            // 
            this.groupBox_comp.Controls.Add(this.radioButton_hashonly);
            this.groupBox_comp.Controls.Add(this.radioButton_nameandhash);
            resources.ApplyResources(this.groupBox_comp, "groupBox_comp");
            this.groupBox_comp.Name = "groupBox_comp";
            this.groupBox_comp.TabStop = false;
            // 
            // radioButton_hashonly
            // 
            resources.ApplyResources(this.radioButton_hashonly, "radioButton_hashonly");
            this.radioButton_hashonly.Name = "radioButton_hashonly";
            this.radioButton_hashonly.UseVisualStyleBackColor = true;
            // 
            // radioButton_nameandhash
            // 
            resources.ApplyResources(this.radioButton_nameandhash, "radioButton_nameandhash");
            this.radioButton_nameandhash.Checked = true;
            this.radioButton_nameandhash.Name = "radioButton_nameandhash";
            this.radioButton_nameandhash.TabStop = true;
            this.radioButton_nameandhash.UseVisualStyleBackColor = true;
            // 
            // button_exe
            // 
            this.button_exe.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_exe, "button_exe");
            this.button_exe.Name = "button_exe";
            this.button_exe.UseVisualStyleBackColor = false;
            this.button_exe.Click += new System.EventHandler(this.Button_exe_Click);
            // 
            // button_del
            // 
            this.button_del.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.button_del, "button_del");
            this.button_del.Name = "button_del";
            this.button_del.UseVisualStyleBackColor = false;
            this.button_del.Click += new System.EventHandler(this.Button_del_Click);
            // 
            // tabPage_files
            // 
            this.tabPage_files.Controls.Add(this.groupBox_dif);
            this.tabPage_files.Controls.Add(this.button_df);
            this.tabPage_files.Controls.Add(this.button_of);
            resources.ApplyResources(this.tabPage_files, "tabPage_files");
            this.tabPage_files.Name = "tabPage_files";
            this.tabPage_files.UseVisualStyleBackColor = true;
            // 
            // groupBox_dif
            // 
            this.groupBox_dif.Controls.Add(this.label_newdir);
            this.groupBox_dif.Controls.Add(this.button_comp);
            this.groupBox_dif.Controls.Add(this.groupBox_raw);
            this.groupBox_dif.Controls.Add(this.checkBox_difraw);
            this.groupBox_dif.Controls.Add(this.checkBox_difbin);
            this.groupBox_dif.Controls.Add(this.checkBox_diftxt);
            resources.ApplyResources(this.groupBox_dif, "groupBox_dif");
            this.groupBox_dif.Name = "groupBox_dif";
            this.groupBox_dif.TabStop = false;
            // 
            // label_newdir
            // 
            resources.ApplyResources(this.label_newdir, "label_newdir");
            this.label_newdir.Name = "label_newdir";
            // 
            // button_comp
            // 
            this.button_comp.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.button_comp, "button_comp");
            this.button_comp.Name = "button_comp";
            this.button_comp.UseVisualStyleBackColor = false;
            this.button_comp.Click += new System.EventHandler(this.Button_comp_Click);
            // 
            // groupBox_raw
            // 
            this.groupBox_raw.Controls.Add(this.label_raw_secsize);
            this.groupBox_raw.Controls.Add(this.comboBox_raw_secsize);
            this.groupBox_raw.Controls.Add(this.label_raw_lun);
            this.groupBox_raw.Controls.Add(this.textBox_raw_lun);
            resources.ApplyResources(this.groupBox_raw, "groupBox_raw");
            this.groupBox_raw.Name = "groupBox_raw";
            this.groupBox_raw.TabStop = false;
            // 
            // label_raw_secsize
            // 
            resources.ApplyResources(this.label_raw_secsize, "label_raw_secsize");
            this.label_raw_secsize.Name = "label_raw_secsize";
            // 
            // comboBox_raw_secsize
            // 
            this.comboBox_raw_secsize.FormattingEnabled = true;
            this.comboBox_raw_secsize.Items.AddRange(new object[] {
            resources.GetString("comboBox_raw_secsize.Items"),
            resources.GetString("comboBox_raw_secsize.Items1"),
            resources.GetString("comboBox_raw_secsize.Items2")});
            resources.ApplyResources(this.comboBox_raw_secsize, "comboBox_raw_secsize");
            this.comboBox_raw_secsize.Name = "comboBox_raw_secsize";
            // 
            // label_raw_lun
            // 
            resources.ApplyResources(this.label_raw_lun, "label_raw_lun");
            this.label_raw_lun.Name = "label_raw_lun";
            // 
            // textBox_raw_lun
            // 
            resources.ApplyResources(this.textBox_raw_lun, "textBox_raw_lun");
            this.textBox_raw_lun.Name = "textBox_raw_lun";
            // 
            // checkBox_difraw
            // 
            resources.ApplyResources(this.checkBox_difraw, "checkBox_difraw");
            this.checkBox_difraw.Name = "checkBox_difraw";
            this.checkBox_difraw.UseVisualStyleBackColor = true;
            this.checkBox_difraw.CheckedChanged += new System.EventHandler(this.CheckBox_difraw_CheckedChanged);
            // 
            // checkBox_difbin
            // 
            resources.ApplyResources(this.checkBox_difbin, "checkBox_difbin");
            this.checkBox_difbin.Name = "checkBox_difbin";
            this.checkBox_difbin.UseVisualStyleBackColor = true;
            this.checkBox_difbin.CheckedChanged += new System.EventHandler(this.CheckBox_difbin_CheckedChanged);
            // 
            // checkBox_diftxt
            // 
            resources.ApplyResources(this.checkBox_diftxt, "checkBox_diftxt");
            this.checkBox_diftxt.Name = "checkBox_diftxt";
            this.checkBox_diftxt.UseVisualStyleBackColor = true;
            this.checkBox_diftxt.CheckedChanged += new System.EventHandler(this.CheckBox_diftxt_CheckedChanged);
            // 
            // button_df
            // 
            this.button_df.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.button_df, "button_df");
            this.button_df.Name = "button_df";
            this.button_df.UseVisualStyleBackColor = false;
            this.button_df.Click += new System.EventHandler(this.Button_df_Click);
            // 
            // button_of
            // 
            this.button_of.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.button_of, "button_of");
            this.button_of.Name = "button_of";
            this.button_of.UseVisualStyleBackColor = false;
            this.button_of.Click += new System.EventHandler(this.Button_of_Click);
            // 
            // backgroundWorker_orig
            // 
            this.backgroundWorker_orig.WorkerReportsProgress = true;
            this.backgroundWorker_orig.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_orig_DoWork);
            this.backgroundWorker_orig.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_orig_ProgressChanged);
            this.backgroundWorker_orig.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_orig_RunWorkerCompleted);
            // 
            // backgroundWorker_dubl
            // 
            this.backgroundWorker_dubl.WorkerReportsProgress = true;
            this.backgroundWorker_dubl.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_dubl_DoWork);
            this.backgroundWorker_dubl.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_dubl_ProgressChanged);
            this.backgroundWorker_dubl.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_dubl_RunWorkerCompleted);
            // 
            // backgroundWorker_destr
            // 
            this.backgroundWorker_destr.WorkerReportsProgress = true;
            this.backgroundWorker_destr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_destr_DoWork);
            this.backgroundWorker_destr.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_destr_ProgressChanged);
            this.backgroundWorker_destr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_destr_RunWorkerCompleted);
            // 
            // openFileDialog_of
            // 
            resources.ApplyResources(this.openFileDialog_of, "openFileDialog_of");
            this.openFileDialog_of.InitialDirectory = "Desktop";
            // 
            // openFileDialog_df
            // 
            resources.ApplyResources(this.openFileDialog_df, "openFileDialog_df");
            this.openFileDialog_df.InitialDirectory = "Desktop";
            // 
            // backgroundWorker_comp
            // 
            this.backgroundWorker_comp.WorkerReportsProgress = true;
            this.backgroundWorker_comp.WorkerSupportsCancellation = true;
            this.backgroundWorker_comp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_comp_DoWork);
            this.backgroundWorker_comp.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_comp_ProgressChanged);
            this.backgroundWorker_comp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_comp_RunWorkerCompleted);
            // 
            // Hex_Search
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip_search);
            this.Name = "Hex_Search";
            this.Load += new System.EventHandler(this.Hex_Search_Load);
            this.statusStrip_search.ResumeLayout(false);
            this.statusStrip_search.PerformLayout();
            this.tableLayoutPanel_hs.ResumeLayout(false);
            this.tableLayoutPanel_hs.PerformLayout();
            this.groupBox_byte_text.ResumeLayout(false);
            this.groupBox_byte_text.PerformLayout();
            this.groupBox_hs.ResumeLayout(false);
            this.groupBox_hs.PerformLayout();
            this.groupBox_addbytes.ResumeLayout(false);
            this.groupBox_addbytes.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_mask.ResumeLayout(false);
            this.tabPage_dd.ResumeLayout(false);
            this.tabPage_dd.PerformLayout();
            this.groupBox_sector.ResumeLayout(false);
            this.groupBox_sector.PerformLayout();
            this.tabPage_folders.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip_dubl_files.ResumeLayout(false);
            this.groupBox_dubl.ResumeLayout(false);
            this.groupBox_dubl.PerformLayout();
            this.groupBox_orig.ResumeLayout(false);
            this.groupBox_orig.PerformLayout();
            this.groupBox_comp.ResumeLayout(false);
            this.groupBox_comp.PerformLayout();
            this.tabPage_files.ResumeLayout(false);
            this.groupBox_dif.ResumeLayout(false);
            this.groupBox_dif.PerformLayout();
            this.groupBox_raw.ResumeLayout(false);
            this.groupBox_raw.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker_hex_search;
        private System.Windows.Forms.StatusStrip statusStrip_search;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_search;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_search;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_hs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_hs;
        private System.Windows.Forms.RadioButton radioButton_dir;
        private System.Windows.Forms.RadioButton radioButton_file;
        private System.Windows.Forms.Button button_start_search;
        private System.Windows.Forms.ListView listView_search;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox_byte_text;
        private System.Windows.Forms.TextBox textBox_hexsearch;
        private System.Windows.Forms.TextBox textBox_byte_search;
        private System.Windows.Forms.RadioButton radioButton_search_text;
        private System.Windows.Forms.RadioButton radioButton_byte_search;
        private System.Windows.Forms.GroupBox groupBox_addbytes;
        private System.Windows.Forms.TextBox textBox_addlast;
        private System.Windows.Forms.TextBox textBox_addfirst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_folders;
        private System.Windows.Forms.TabPage tabPage_dd;
        private System.Windows.Forms.TabPage tabPage_mask;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_orig;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_orig;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_dubl;
        private System.ComponentModel.BackgroundWorker backgroundWorker_orig;
        private System.ComponentModel.BackgroundWorker backgroundWorker_dubl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_dubl_files;
        private System.Windows.Forms.ToolStripMenuItem поменятьМестамиОригиналИДубликатToolStripMenuItem;
        private System.Windows.Forms.ListView listView_dd;
        private System.Windows.Forms.Button button_dd;
        private System.Windows.Forms.ColumnHeader columnHeader_ss;
        private System.Windows.Forms.ColumnHeader columnHeader_ls;
        private System.Windows.Forms.ColumnHeader columnHeader_pn;
        private System.Windows.Forms.ColumnHeader columnHeader_pl;
        private System.Windows.Forms.GroupBox groupBox_sector;
        private System.Windows.Forms.TextBox textBox_sector;
        private System.Windows.Forms.ColumnHeader columnHeader_bl;
        private System.Windows.Forms.Button button_destr;
        private System.ComponentModel.BackgroundWorker backgroundWorker_destr;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_exe;
        private System.Windows.Forms.GroupBox groupBox_dubl;
        private System.Windows.Forms.RadioButton radioButton_dd_yes;
        private System.Windows.Forms.RadioButton radioButton_dd_no;
        private System.Windows.Forms.GroupBox groupBox_orig;
        private System.Windows.Forms.RadioButton radioButton_od_yes;
        private System.Windows.Forms.RadioButton radioButton_od_no;
        private System.Windows.Forms.Button button_dubl;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.GroupBox groupBox_comp;
        private System.Windows.Forms.ListView listView_dubl_files;
        private System.Windows.Forms.ColumnHeader columnHeader_fullpath;
        private System.Windows.Forms.ColumnHeader columnHeader_filelen;
        private System.Windows.Forms.RadioButton radioButton_hashonly;
        private System.Windows.Forms.RadioButton radioButton_nameandhash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выбратьВсёToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снятьВесьВыборToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_files;
        private System.Windows.Forms.OpenFileDialog openFileDialog_of;
        private System.Windows.Forms.OpenFileDialog openFileDialog_df;
        private System.Windows.Forms.Button button_df;
        private System.Windows.Forms.Button button_of;
        private System.Windows.Forms.GroupBox groupBox_dif;
        private System.Windows.Forms.CheckBox checkBox_diftxt;
        private System.Windows.Forms.CheckBox checkBox_difraw;
        private System.Windows.Forms.CheckBox checkBox_difbin;
        private System.Windows.Forms.GroupBox groupBox_raw;
        private System.Windows.Forms.Label label_raw_secsize;
        private System.Windows.Forms.ComboBox comboBox_raw_secsize;
        private System.Windows.Forms.Label label_raw_lun;
        private System.Windows.Forms.TextBox textBox_raw_lun;
        private System.Windows.Forms.Button button_comp;
        private System.ComponentModel.BackgroundWorker backgroundWorker_comp;
        private System.Windows.Forms.Label label_newdir;
    }
}