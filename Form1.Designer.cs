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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formfhf));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_firehose = new System.Windows.Forms.TabPage();
            this.statusStrip_firehose = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_filescompleted = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_filescompleted = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel_vol = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage_about = new System.Windows.Forms.TabPage();
            this.richTextBox_about = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView_final = new System.Windows.Forms.DataGridView();
            this.textBox_oemhash = new System.Windows.Forms.TextBox();
            this.label_oemhash = new System.Windows.Forms.Label();
            this.label_path = new System.Windows.Forms.Label();
            this.button_path = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_startscan = new System.Windows.Forms.Button();
            this.label_oemid = new System.Windows.Forms.Label();
            this.textBox_oemid = new System.Windows.Forms.TextBox();
            this.label_modelid = new System.Windows.Forms.Label();
            this.textBox_modelid = new System.Windows.Forms.TextBox();
            this.label_hwid = new System.Windows.Forms.Label();
            this.textBox_hwid = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Column_Sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Full = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SW_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage_firehose.SuspendLayout();
            this.statusStrip_firehose.SuspendLayout();
            this.tabPage_about.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_final)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_firehose);
            this.tabControl1.Controls.Add(this.tabPage_about);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1250, 613);
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
            this.tabPage_firehose.Size = new System.Drawing.Size(1242, 584);
            this.tabPage_firehose.TabIndex = 0;
            this.tabPage_firehose.Text = "Firehose";
            this.tabPage_firehose.UseVisualStyleBackColor = true;
            // 
            // statusStrip_firehose
            // 
            this.statusStrip_firehose.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_firehose.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_filescompleted,
            this.toolStripProgressBar_filescompleted,
            this.toolStripStatusLabel_vol});
            this.statusStrip_firehose.Location = new System.Drawing.Point(3, 552);
            this.statusStrip_firehose.Name = "statusStrip_firehose";
            this.statusStrip_firehose.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip_firehose.Size = new System.Drawing.Size(1236, 30);
            this.statusStrip_firehose.TabIndex = 12;
            this.statusStrip_firehose.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_filescompleted
            // 
            this.toolStripStatusLabel_filescompleted.Name = "toolStripStatusLabel_filescompleted";
            this.toolStripStatusLabel_filescompleted.Size = new System.Drawing.Size(199, 24);
            this.toolStripStatusLabel_filescompleted.Text = "Обработано файлов: 0 из 0";
            // 
            // toolStripProgressBar_filescompleted
            // 
            this.toolStripProgressBar_filescompleted.AutoToolTip = true;
            this.toolStripProgressBar_filescompleted.Name = "toolStripProgressBar_filescompleted";
            this.toolStripProgressBar_filescompleted.Size = new System.Drawing.Size(400, 22);
            // 
            // toolStripStatusLabel_vol
            // 
            this.toolStripStatusLabel_vol.Name = "toolStripStatusLabel_vol";
            this.toolStripStatusLabel_vol.Size = new System.Drawing.Size(0, 24);
            // 
            // tabPage_about
            // 
            this.tabPage_about.Controls.Add(this.richTextBox_about);
            this.tabPage_about.Location = new System.Drawing.Point(4, 25);
            this.tabPage_about.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_about.Name = "tabPage_about";
            this.tabPage_about.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_about.Size = new System.Drawing.Size(1056, 426);
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
            this.richTextBox_about.Size = new System.Drawing.Size(1050, 422);
            this.richTextBox_about.TabIndex = 1;
            this.richTextBox_about.Text = "";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Укажите путь к папке с программерами";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
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
            this.dataGridView_final.Name = "dataGridView_final";
            this.dataGridView_final.RowHeadersWidth = 51;
            this.dataGridView_final.RowTemplate.Height = 24;
            this.dataGridView_final.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_final.Size = new System.Drawing.Size(1236, 388);
            this.dataGridView_final.TabIndex = 15;
            this.dataGridView_final.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_final_CellClick);
            this.dataGridView_final.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_final_CellDoubleClick);
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
            this.textBox_oemhash.Text = "7C6DCA9BF5674291AA39DD55760C0D4B65C7A4223097AAB1DB791E2192002DDF";
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
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(29, 91);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(237, 17);
            this.label_path.TabIndex = 8;
            this.label_path.Text = "Укажите путь к коллекции firehose";
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(11, 112);
            this.button_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(275, 23);
            this.button_path.TabIndex = 9;
            this.button_path.Text = "~Рабочий стол";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.Button_path_Click);
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
            // button_startscan
            // 
            this.button_startscan.Location = new System.Drawing.Point(331, 111);
            this.button_startscan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_startscan.Name = "button_startscan";
            this.button_startscan.Size = new System.Drawing.Size(324, 23);
            this.button_startscan.TabIndex = 10;
            this.button_startscan.Text = "Использовать выбранный программер";
            this.button_startscan.UseVisualStyleBackColor = true;
            this.button_startscan.Visible = false;
            this.button_startscan.Click += new System.EventHandler(this.Button_startscan_Click);
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
            // textBox_oemid
            // 
            this.textBox_oemid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_oemid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_oemid.Location = new System.Drawing.Point(242, 10);
            this.textBox_oemid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_oemid.MaxLength = 4;
            this.textBox_oemid.Name = "textBox_oemid";
            this.textBox_oemid.Size = new System.Drawing.Size(43, 22);
            this.textBox_oemid.TabIndex = 4;
            this.textBox_oemid.Text = "0043";
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
            // textBox_modelid
            // 
            this.textBox_modelid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_modelid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_modelid.Location = new System.Drawing.Point(389, 11);
            this.textBox_modelid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_modelid.MaxLength = 4;
            this.textBox_modelid.Name = "textBox_modelid";
            this.textBox_modelid.Size = new System.Drawing.Size(43, 22);
            this.textBox_modelid.TabIndex = 2;
            this.textBox_modelid.Text = "0000";
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
            // textBox_hwid
            // 
            this.textBox_hwid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_hwid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_hwid.Location = new System.Drawing.Point(81, 9);
            this.textBox_hwid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_hwid.MaxLength = 8;
            this.textBox_hwid.Name = "textBox_hwid";
            this.textBox_hwid.Size = new System.Drawing.Size(73, 22);
            this.textBox_hwid.TabIndex = 0;
            this.textBox_hwid.Text = "0009A0E1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_hwid);
            this.panel1.Controls.Add(this.button_startscan);
            this.panel1.Controls.Add(this.label_path);
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
            this.panel1.Size = new System.Drawing.Size(1236, 162);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_final);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1236, 388);
            this.panel2.TabIndex = 18;
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
            this.Column_id.HeaderText = "HW-OEM-MODEL-HASH-SW";
            this.Column_id.MinimumWidth = 6;
            this.Column_id.Name = "Column_id";
            this.Column_id.Width = 220;
            // 
            // Column_rate
            // 
            this.Column_rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_rate.HeaderText = "Рейтинг";
            this.Column_rate.MinimumWidth = 6;
            this.Column_rate.Name = "Column_rate";
            this.Column_rate.Width = 90;
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
            this.Column_SW_type.Width = 87;
            // 
            // Formfhf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 613);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formfhf";
            this.Text = "Firehose Finder";
            this.Load += new System.EventHandler(this.Formfhf_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_firehose.ResumeLayout(false);
            this.tabPage_firehose.PerformLayout();
            this.statusStrip_firehose.ResumeLayout(false);
            this.statusStrip_firehose.PerformLayout();
            this.tabPage_about.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_final)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button button_startscan;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox textBox_oemid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_modelid;
        private System.Windows.Forms.TextBox textBox_hwid;
        private System.Windows.Forms.Label label_oemid;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.TextBox textBox_oemhash;
        private System.Windows.Forms.Label label_oemhash;
        private System.Windows.Forms.TextBox textBox_modelid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_Sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Full;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SW_type;
    }
}

