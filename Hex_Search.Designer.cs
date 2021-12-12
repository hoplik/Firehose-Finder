
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Файл", System.Windows.Forms.HorizontalAlignment.Left);
            this.label_hello = new System.Windows.Forms.Label();
            this.textBox_hexsearch = new System.Windows.Forms.TextBox();
            this.radioButton_file = new System.Windows.Forms.RadioButton();
            this.radioButton_dir = new System.Windows.Forms.RadioButton();
            this.button_start_search = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar_hex_search = new System.Windows.Forms.ToolStripProgressBar();
            this.listView_hex_search = new System.Windows.Forms.ListView();
            this.columnHeader_adress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_hex_search = new System.ComponentModel.BackgroundWorker();
            this.toolStripStatusLabel_search = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_hello
            // 
            this.label_hello.AutoSize = true;
            this.label_hello.Location = new System.Drawing.Point(13, 13);
            this.label_hello.Name = "label_hello";
            this.label_hello.Size = new System.Drawing.Size(222, 17);
            this.label_hello.TabIndex = 0;
            this.label_hello.Text = "Ищем последовательность байт";
            // 
            // textBox_hexsearch
            // 
            this.textBox_hexsearch.Location = new System.Drawing.Point(242, 13);
            this.textBox_hexsearch.Name = "textBox_hexsearch";
            this.textBox_hexsearch.Size = new System.Drawing.Size(215, 22);
            this.textBox_hexsearch.TabIndex = 1;
            this.textBox_hexsearch.TextChanged += new System.EventHandler(this.TextBox_hexsearch_TextChanged);
            // 
            // radioButton_file
            // 
            this.radioButton_file.AutoSize = true;
            this.radioButton_file.Checked = true;
            this.radioButton_file.Location = new System.Drawing.Point(479, 13);
            this.radioButton_file.Name = "radioButton_file";
            this.radioButton_file.Size = new System.Drawing.Size(83, 21);
            this.radioButton_file.TabIndex = 2;
            this.radioButton_file.TabStop = true;
            this.radioButton_file.Text = "в файле";
            this.radioButton_file.UseVisualStyleBackColor = true;
            // 
            // radioButton_dir
            // 
            this.radioButton_dir.AutoSize = true;
            this.radioButton_dir.Location = new System.Drawing.Point(568, 12);
            this.radioButton_dir.Name = "radioButton_dir";
            this.radioButton_dir.Size = new System.Drawing.Size(79, 21);
            this.radioButton_dir.TabIndex = 3;
            this.radioButton_dir.Text = "в папке";
            this.radioButton_dir.UseVisualStyleBackColor = true;
            // 
            // button_start_search
            // 
            this.button_start_search.Enabled = false;
            this.button_start_search.Location = new System.Drawing.Point(654, 11);
            this.button_start_search.Name = "button_start_search";
            this.button_start_search.Size = new System.Drawing.Size(255, 23);
            this.button_start_search.TabIndex = 4;
            this.button_start_search.Text = "по пути";
            this.button_start_search.UseVisualStyleBackColor = true;
            this.button_start_search.Click += new System.EventHandler(this.Button_start_search_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar_hex_search,
            this.toolStripStatusLabel_search});
            this.statusStrip1.Location = new System.Drawing.Point(0, 218);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar_hex_search
            // 
            this.toolStripProgressBar_hex_search.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripProgressBar_hex_search.Name = "toolStripProgressBar_hex_search";
            this.toolStripProgressBar_hex_search.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressBar_hex_search.Step = 1;
            this.toolStripProgressBar_hex_search.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // listView_hex_search
            // 
            this.listView_hex_search.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_adress,
            this.columnHeader_result,
            this.columnHeader_file});
            this.listView_hex_search.FullRowSelect = true;
            listViewGroup1.Header = "Файл";
            listViewGroup1.Name = "listViewGroup1";
            this.listView_hex_search.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listView_hex_search.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_hex_search.HideSelection = false;
            this.listView_hex_search.Location = new System.Drawing.Point(12, 51);
            this.listView_hex_search.MultiSelect = false;
            this.listView_hex_search.Name = "listView_hex_search";
            this.listView_hex_search.Size = new System.Drawing.Size(969, 166);
            this.listView_hex_search.TabIndex = 6;
            this.listView_hex_search.UseCompatibleStateImageBehavior = false;
            this.listView_hex_search.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_adress
            // 
            this.columnHeader_adress.Text = "Адрес";
            this.columnHeader_adress.Width = 52;
            // 
            // columnHeader_result
            // 
            this.columnHeader_result.Text = "Значение (4 до и 4 после)";
            this.columnHeader_result.Width = 177;
            // 
            // columnHeader_file
            // 
            this.columnHeader_file.Text = "Файл";
            this.columnHeader_file.Width = 736;
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
            this.backgroundWorker_hex_search.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_hex_search_RunWorkerCompleted);
            // 
            // toolStripStatusLabel_search
            // 
            this.toolStripStatusLabel_search.Name = "toolStripStatusLabel_search";
            this.toolStripStatusLabel_search.Size = new System.Drawing.Size(100, 20);
            this.toolStripStatusLabel_search.Text = "Оповещение";
            // 
            // Hex_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 244);
            this.Controls.Add(this.listView_hex_search);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_start_search);
            this.Controls.Add(this.radioButton_dir);
            this.Controls.Add(this.radioButton_file);
            this.Controls.Add(this.textBox_hexsearch);
            this.Controls.Add(this.label_hello);
            this.Name = "Hex_Search";
            this.Text = "Hex_Search";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_hello;
        private System.Windows.Forms.TextBox textBox_hexsearch;
        private System.Windows.Forms.RadioButton radioButton_file;
        private System.Windows.Forms.RadioButton radioButton_dir;
        private System.Windows.Forms.Button button_start_search;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_hex_search;
        private System.Windows.Forms.ListView listView_hex_search;
        private System.Windows.Forms.ColumnHeader columnHeader_adress;
        private System.Windows.Forms.ColumnHeader columnHeader_result;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader_file;
        private System.ComponentModel.BackgroundWorker backgroundWorker_hex_search;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_search;
    }
}