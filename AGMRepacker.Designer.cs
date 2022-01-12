namespace FirehoseFinder
{
    partial class AGMRepacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AGMRepacker));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_controls = new System.Windows.Forms.GroupBox();
            this.comboBox_charsinrow = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_keycode = new System.Windows.Forms.TextBox();
            this.button_decode = new System.Windows.Forms.Button();
            this.button_repack = new System.Windows.Forms.Button();
            this.button_dirrepack = new System.Windows.Forms.Button();
            this.button_rampath = new System.Windows.Forms.Button();
            this.groupBox_orig = new System.Windows.Forms.GroupBox();
            this.textBox_orig = new System.Windows.Forms.TextBox();
            this.groupBox_decode = new System.Windows.Forms.GroupBox();
            this.textBox_decode = new System.Windows.Forms.TextBox();
            this.groupBox_parse = new System.Windows.Forms.GroupBox();
            this.textBox_parse = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_readheader = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_decodeheader = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox_controls.SuspendLayout();
            this.groupBox_orig.SuspendLayout();
            this.groupBox_decode.SuspendLayout();
            this.groupBox_parse.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1279, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 18);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(414, 20);
            this.toolStripStatusLabel1.Text = "Выберите путь к прошивке и директорию для распаковки";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox_controls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_orig, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_decode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_parse, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1279, 522);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox_controls
            // 
            this.groupBox_controls.Controls.Add(this.comboBox_charsinrow);
            this.groupBox_controls.Controls.Add(this.label2);
            this.groupBox_controls.Controls.Add(this.label1);
            this.groupBox_controls.Controls.Add(this.textBox_keycode);
            this.groupBox_controls.Controls.Add(this.button_decode);
            this.groupBox_controls.Controls.Add(this.button_repack);
            this.groupBox_controls.Controls.Add(this.button_dirrepack);
            this.groupBox_controls.Controls.Add(this.button_rampath);
            this.groupBox_controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_controls.Location = new System.Drawing.Point(3, 3);
            this.groupBox_controls.Name = "groupBox_controls";
            this.groupBox_controls.Size = new System.Drawing.Size(633, 194);
            this.groupBox_controls.TabIndex = 3;
            this.groupBox_controls.TabStop = false;
            this.groupBox_controls.Text = "Управление";
            // 
            // comboBox_charsinrow
            // 
            this.comboBox_charsinrow.FormattingEnabled = true;
            this.comboBox_charsinrow.Items.AddRange(new object[] {
            "8",
            "16"});
            this.comboBox_charsinrow.Location = new System.Drawing.Point(475, 85);
            this.comboBox_charsinrow.Name = "comboBox_charsinrow";
            this.comboBox_charsinrow.Size = new System.Drawing.Size(144, 24);
            this.comboBox_charsinrow.TabIndex = 7;
            this.comboBox_charsinrow.Text = "16";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество символов в строке";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Алгоритм шифрования DES-ECB (64 bit/8 байт/16 знаков)";
            // 
            // textBox_keycode
            // 
            this.textBox_keycode.Location = new System.Drawing.Point(475, 56);
            this.textBox_keycode.Name = "textBox_keycode";
            this.textBox_keycode.Size = new System.Drawing.Size(145, 22);
            this.textBox_keycode.TabIndex = 1;
            this.textBox_keycode.Text = "0123456789ABCDEF";
            this.textBox_keycode.TextChanged += new System.EventHandler(this.TextBox_keycode_TextChanged);
            // 
            // button_decode
            // 
            this.button_decode.Enabled = false;
            this.button_decode.Location = new System.Drawing.Point(475, 22);
            this.button_decode.Name = "button_decode";
            this.button_decode.Size = new System.Drawing.Size(145, 27);
            this.button_decode.TabIndex = 3;
            this.button_decode.Text = "Декодировать";
            this.button_decode.UseVisualStyleBackColor = true;
            this.button_decode.Click += new System.EventHandler(this.Button_decode_Click);
            // 
            // button_repack
            // 
            this.button_repack.Enabled = false;
            this.button_repack.Location = new System.Drawing.Point(475, 161);
            this.button_repack.Name = "button_repack";
            this.button_repack.Size = new System.Drawing.Size(145, 27);
            this.button_repack.TabIndex = 5;
            this.button_repack.Text = "Распаковать";
            this.button_repack.UseVisualStyleBackColor = true;
            // 
            // button_dirrepack
            // 
            this.button_dirrepack.Location = new System.Drawing.Point(6, 161);
            this.button_dirrepack.Name = "button_dirrepack";
            this.button_dirrepack.Size = new System.Drawing.Size(428, 27);
            this.button_dirrepack.TabIndex = 4;
            this.button_dirrepack.Text = "Директория для распаковки";
            this.button_dirrepack.UseVisualStyleBackColor = true;
            // 
            // button_rampath
            // 
            this.button_rampath.Location = new System.Drawing.Point(7, 22);
            this.button_rampath.Name = "button_rampath";
            this.button_rampath.Size = new System.Drawing.Size(428, 27);
            this.button_rampath.TabIndex = 0;
            this.button_rampath.Text = "Путь к файлу прошивки";
            this.button_rampath.UseVisualStyleBackColor = true;
            this.button_rampath.Click += new System.EventHandler(this.Button_rampath_Click);
            // 
            // groupBox_orig
            // 
            this.groupBox_orig.Controls.Add(this.textBox_orig);
            this.groupBox_orig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_orig.Location = new System.Drawing.Point(3, 203);
            this.groupBox_orig.Name = "groupBox_orig";
            this.groupBox_orig.Size = new System.Drawing.Size(633, 316);
            this.groupBox_orig.TabIndex = 4;
            this.groupBox_orig.TabStop = false;
            this.groupBox_orig.Text = "Начало оригинального заголовка прошивки (BYTES | ASCII)";
            // 
            // textBox_orig
            // 
            this.textBox_orig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_orig.Location = new System.Drawing.Point(3, 18);
            this.textBox_orig.Multiline = true;
            this.textBox_orig.Name = "textBox_orig";
            this.textBox_orig.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_orig.Size = new System.Drawing.Size(627, 295);
            this.textBox_orig.TabIndex = 0;
            // 
            // groupBox_decode
            // 
            this.groupBox_decode.Controls.Add(this.textBox_decode);
            this.groupBox_decode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_decode.Location = new System.Drawing.Point(642, 203);
            this.groupBox_decode.Name = "groupBox_decode";
            this.groupBox_decode.Size = new System.Drawing.Size(634, 316);
            this.groupBox_decode.TabIndex = 5;
            this.groupBox_decode.TabStop = false;
            this.groupBox_decode.Text = "Декодированная часть заголовка прошивки (BYTES | ASCII)";
            // 
            // textBox_decode
            // 
            this.textBox_decode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_decode.Location = new System.Drawing.Point(3, 18);
            this.textBox_decode.Multiline = true;
            this.textBox_decode.Name = "textBox_decode";
            this.textBox_decode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_decode.Size = new System.Drawing.Size(628, 295);
            this.textBox_decode.TabIndex = 0;
            // 
            // groupBox_parse
            // 
            this.groupBox_parse.Controls.Add(this.textBox_parse);
            this.groupBox_parse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_parse.Location = new System.Drawing.Point(642, 3);
            this.groupBox_parse.Name = "groupBox_parse";
            this.groupBox_parse.Size = new System.Drawing.Size(634, 194);
            this.groupBox_parse.TabIndex = 6;
            this.groupBox_parse.TabStop = false;
            this.groupBox_parse.Text = "Парсинг декодированного заголовка";
            // 
            // textBox_parse
            // 
            this.textBox_parse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_parse.Location = new System.Drawing.Point(3, 18);
            this.textBox_parse.Multiline = true;
            this.textBox_parse.Name = "textBox_parse";
            this.textBox_parse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_parse.Size = new System.Drawing.Size(628, 173);
            this.textBox_parse.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*";
            // 
            // backgroundWorker_readheader
            // 
            this.backgroundWorker_readheader.WorkerReportsProgress = true;
            this.backgroundWorker_readheader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_readheader_DoWork);
            this.backgroundWorker_readheader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_readheader_ProgressChanged);
            this.backgroundWorker_readheader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_readheader_RunWorkerCompleted);
            // 
            // backgroundWorker_decodeheader
            // 
            this.backgroundWorker_decodeheader.WorkerReportsProgress = true;
            this.backgroundWorker_decodeheader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_decodeheader_DoWork);
            this.backgroundWorker_decodeheader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_decodeheader_ProgressChanged);
            this.backgroundWorker_decodeheader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_decodeheader_RunWorkerCompleted);
            // 
            // AGMRepacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 548);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AGMRepacker";
            this.Text = "Декодер-распаковщик однобиновой прошивки для AGM";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox_controls.ResumeLayout(false);
            this.groupBox_controls.PerformLayout();
            this.groupBox_orig.ResumeLayout(false);
            this.groupBox_orig.PerformLayout();
            this.groupBox_decode.ResumeLayout(false);
            this.groupBox_decode.PerformLayout();
            this.groupBox_parse.ResumeLayout(false);
            this.groupBox_parse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox_controls;
        private System.Windows.Forms.GroupBox groupBox_orig;
        private System.Windows.Forms.TextBox textBox_orig;
        private System.Windows.Forms.GroupBox groupBox_decode;
        private System.Windows.Forms.TextBox textBox_decode;
        private System.Windows.Forms.Button button_dirrepack;
        private System.Windows.Forms.Button button_rampath;
        private System.Windows.Forms.GroupBox groupBox_parse;
        private System.Windows.Forms.TextBox textBox_parse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_decode;
        private System.Windows.Forms.Button button_repack;
        private System.Windows.Forms.ComboBox comboBox_charsinrow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_keycode;
        private System.ComponentModel.BackgroundWorker backgroundWorker_readheader;
        private System.ComponentModel.BackgroundWorker backgroundWorker_decodeheader;
    }
}