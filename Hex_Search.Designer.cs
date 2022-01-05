
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hex_Search));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_hex_search = new System.ComponentModel.BackgroundWorker();
            this.statusStrip_search = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_search = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_search = new System.Windows.Forms.ToolStripProgressBar();
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
            this.statusStrip_search.SuspendLayout();
            this.tableLayoutPanel_hs.SuspendLayout();
            this.groupBox_byte_text.SuspendLayout();
            this.groupBox_hs.SuspendLayout();
            this.groupBox_addbytes.SuspendLayout();
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
            this.statusStrip_search.Location = new System.Drawing.Point(0, 313);
            this.statusStrip_search.Name = "statusStrip_search";
            this.statusStrip_search.Size = new System.Drawing.Size(993, 26);
            this.statusStrip_search.TabIndex = 7;
            this.statusStrip_search.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_search
            // 
            this.toolStripStatusLabel_search.Name = "toolStripStatusLabel_search";
            this.toolStripStatusLabel_search.Size = new System.Drawing.Size(100, 20);
            this.toolStripStatusLabel_search.Text = "Оповещения";
            // 
            // toolStripProgressBar_search
            // 
            this.toolStripProgressBar_search.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripProgressBar_search.Name = "toolStripProgressBar_search";
            this.toolStripProgressBar_search.Size = new System.Drawing.Size(200, 18);
            this.toolStripProgressBar_search.Step = 1;
            this.toolStripProgressBar_search.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tableLayoutPanel_hs
            // 
            this.tableLayoutPanel_hs.ColumnCount = 3;
            this.tableLayoutPanel_hs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_hs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_hs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_hs.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_hs.Controls.Add(this.listView_search, 0, 1);
            this.tableLayoutPanel_hs.Controls.Add(this.groupBox_byte_text, 1, 0);
            this.tableLayoutPanel_hs.Controls.Add(this.button_start_search, 2, 2);
            this.tableLayoutPanel_hs.Controls.Add(this.groupBox_hs, 2, 1);
            this.tableLayoutPanel_hs.Controls.Add(this.groupBox_addbytes, 2, 0);
            this.tableLayoutPanel_hs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_hs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_hs.Name = "tableLayoutPanel_hs";
            this.tableLayoutPanel_hs.RowCount = 3;
            this.tableLayoutPanel_hs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_hs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_hs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_hs.Size = new System.Drawing.Size(993, 313);
            this.tableLayoutPanel_hs.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ищем последовательность";
            // 
            // listView_search
            // 
            this.listView_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.tableLayoutPanel_hs.SetColumnSpan(this.listView_search, 2);
            this.listView_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_search.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView_search.FullRowSelect = true;
            this.listView_search.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_search.HideSelection = false;
            this.listView_search.Location = new System.Drawing.Point(3, 93);
            this.listView_search.MultiSelect = false;
            this.listView_search.Name = "listView_search";
            this.tableLayoutPanel_hs.SetRowSpan(this.listView_search, 2);
            this.listView_search.Size = new System.Drawing.Size(787, 217);
            this.listView_search.TabIndex = 4;
            this.listView_search.UseCompatibleStateImageBehavior = false;
            this.listView_search.View = System.Windows.Forms.View.Details;
            this.listView_search.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_search_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Адрес (hex, 0x)";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bytes | ASCII";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Файл";
            this.columnHeader3.Width = 588;
            // 
            // groupBox_byte_text
            // 
            this.groupBox_byte_text.Controls.Add(this.textBox_hexsearch);
            this.groupBox_byte_text.Controls.Add(this.textBox_byte_search);
            this.groupBox_byte_text.Controls.Add(this.radioButton_search_text);
            this.groupBox_byte_text.Controls.Add(this.radioButton_byte_search);
            this.groupBox_byte_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_byte_text.Location = new System.Drawing.Point(203, 3);
            this.groupBox_byte_text.Name = "groupBox_byte_text";
            this.groupBox_byte_text.Size = new System.Drawing.Size(587, 84);
            this.groupBox_byte_text.TabIndex = 5;
            this.groupBox_byte_text.TabStop = false;
            this.groupBox_byte_text.Text = "Набор символов для поиска";
            // 
            // textBox_hexsearch
            // 
            this.textBox_hexsearch.Enabled = false;
            this.textBox_hexsearch.Location = new System.Drawing.Point(77, 51);
            this.textBox_hexsearch.Name = "textBox_hexsearch";
            this.textBox_hexsearch.Size = new System.Drawing.Size(507, 22);
            this.textBox_hexsearch.TabIndex = 3;
            this.textBox_hexsearch.TextChanged += new System.EventHandler(this.TextBox_hexsearch_TextChanged);
            // 
            // textBox_byte_search
            // 
            this.textBox_byte_search.Location = new System.Drawing.Point(77, 22);
            this.textBox_byte_search.Name = "textBox_byte_search";
            this.textBox_byte_search.Size = new System.Drawing.Size(507, 22);
            this.textBox_byte_search.TabIndex = 2;
            this.textBox_byte_search.TextChanged += new System.EventHandler(this.TextBox_byte_search_TextChanged);
            // 
            // radioButton_search_text
            // 
            this.radioButton_search_text.AutoSize = true;
            this.radioButton_search_text.Location = new System.Drawing.Point(6, 48);
            this.radioButton_search_text.Name = "radioButton_search_text";
            this.radioButton_search_text.Size = new System.Drawing.Size(64, 20);
            this.radioButton_search_text.TabIndex = 1;
            this.radioButton_search_text.Text = "текст";
            this.radioButton_search_text.UseVisualStyleBackColor = true;
            this.radioButton_search_text.CheckedChanged += new System.EventHandler(this.RadioButton_search_text_CheckedChanged);
            // 
            // radioButton_byte_search
            // 
            this.radioButton_byte_search.AutoSize = true;
            this.radioButton_byte_search.Checked = true;
            this.radioButton_byte_search.Location = new System.Drawing.Point(7, 22);
            this.radioButton_byte_search.Name = "radioButton_byte_search";
            this.radioButton_byte_search.Size = new System.Drawing.Size(59, 20);
            this.radioButton_byte_search.TabIndex = 0;
            this.radioButton_byte_search.TabStop = true;
            this.radioButton_byte_search.Text = "байт";
            this.radioButton_byte_search.UseVisualStyleBackColor = true;
            this.radioButton_byte_search.CheckedChanged += new System.EventHandler(this.RadioButton_byte_search_CheckedChanged);
            // 
            // button_start_search
            // 
            this.button_start_search.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_start_search.Location = new System.Drawing.Point(796, 183);
            this.button_start_search.Name = "button_start_search";
            this.button_start_search.Size = new System.Drawing.Size(194, 23);
            this.button_start_search.TabIndex = 3;
            this.button_start_search.Text = "путь поиска";
            this.button_start_search.UseVisualStyleBackColor = true;
            this.button_start_search.Click += new System.EventHandler(this.Button_start_search_Click);
            // 
            // groupBox_hs
            // 
            this.groupBox_hs.Controls.Add(this.radioButton_dir);
            this.groupBox_hs.Controls.Add(this.radioButton_file);
            this.groupBox_hs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_hs.Location = new System.Drawing.Point(796, 93);
            this.groupBox_hs.Name = "groupBox_hs";
            this.groupBox_hs.Size = new System.Drawing.Size(194, 84);
            this.groupBox_hs.TabIndex = 2;
            this.groupBox_hs.TabStop = false;
            this.groupBox_hs.Text = "Область поиска";
            // 
            // radioButton_dir
            // 
            this.radioButton_dir.AutoSize = true;
            this.radioButton_dir.Location = new System.Drawing.Point(81, 45);
            this.radioButton_dir.Name = "radioButton_dir";
            this.radioButton_dir.Size = new System.Drawing.Size(69, 20);
            this.radioButton_dir.TabIndex = 1;
            this.radioButton_dir.TabStop = true;
            this.radioButton_dir.Text = "Папка";
            this.radioButton_dir.UseVisualStyleBackColor = true;
            // 
            // radioButton_file
            // 
            this.radioButton_file.AutoSize = true;
            this.radioButton_file.Checked = true;
            this.radioButton_file.Location = new System.Drawing.Point(6, 45);
            this.radioButton_file.Name = "radioButton_file";
            this.radioButton_file.Size = new System.Drawing.Size(63, 20);
            this.radioButton_file.TabIndex = 0;
            this.radioButton_file.TabStop = true;
            this.radioButton_file.Text = "Файл";
            this.radioButton_file.UseVisualStyleBackColor = true;
            // 
            // groupBox_addbytes
            // 
            this.groupBox_addbytes.Controls.Add(this.textBox_addlast);
            this.groupBox_addbytes.Controls.Add(this.textBox_addfirst);
            this.groupBox_addbytes.Controls.Add(this.label3);
            this.groupBox_addbytes.Controls.Add(this.label2);
            this.groupBox_addbytes.Location = new System.Drawing.Point(796, 3);
            this.groupBox_addbytes.Name = "groupBox_addbytes";
            this.groupBox_addbytes.Size = new System.Drawing.Size(194, 84);
            this.groupBox_addbytes.TabIndex = 6;
            this.groupBox_addbytes.TabStop = false;
            this.groupBox_addbytes.Text = "Добавить байты";
            // 
            // textBox_addlast
            // 
            this.textBox_addlast.Location = new System.Drawing.Point(85, 56);
            this.textBox_addlast.Name = "textBox_addlast";
            this.textBox_addlast.Size = new System.Drawing.Size(100, 22);
            this.textBox_addlast.TabIndex = 3;
            this.textBox_addlast.Text = "4";
            // 
            // textBox_addfirst
            // 
            this.textBox_addfirst.Location = new System.Drawing.Point(85, 27);
            this.textBox_addfirst.Name = "textBox_addfirst";
            this.textBox_addfirst.Size = new System.Drawing.Size(100, 22);
            this.textBox_addfirst.TabIndex = 2;
            this.textBox_addfirst.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "в конце";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "в начале";
            // 
            // Hex_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 339);
            this.Controls.Add(this.tableLayoutPanel_hs);
            this.Controls.Add(this.statusStrip_search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hex_Search";
            this.Text = "Hex_Search";
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
    }
}