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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AGMRepacker));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton_explorer = new System.Windows.Forms.ToolStripSplitButton();
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
            this.backgroundWorker_unpacker = new System.ComponentModel.BackgroundWorker();
            this.toolTip_Dir = new System.Windows.Forms.ToolTip(this.components);
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
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripSplitButton_explorer});
            this.statusStrip1.Name = "statusStrip1";
            this.toolTip_Dir.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // toolStripProgressBar1
            // 
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton_explorer
            // 
            resources.ApplyResources(this.toolStripSplitButton_explorer, "toolStripSplitButton_explorer");
            this.toolStripSplitButton_explorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_explorer.DropDownButtonWidth = 0;
            this.toolStripSplitButton_explorer.Name = "toolStripSplitButton_explorer";
            this.toolStripSplitButton_explorer.Click += new System.EventHandler(this.ToolStripSplitButton_explorer_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox_controls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_orig, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_decode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_parse, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.toolTip_Dir.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // groupBox_controls
            // 
            resources.ApplyResources(this.groupBox_controls, "groupBox_controls");
            this.groupBox_controls.Controls.Add(this.comboBox_charsinrow);
            this.groupBox_controls.Controls.Add(this.label2);
            this.groupBox_controls.Controls.Add(this.label1);
            this.groupBox_controls.Controls.Add(this.textBox_keycode);
            this.groupBox_controls.Controls.Add(this.button_decode);
            this.groupBox_controls.Controls.Add(this.button_repack);
            this.groupBox_controls.Controls.Add(this.button_dirrepack);
            this.groupBox_controls.Controls.Add(this.button_rampath);
            this.groupBox_controls.Name = "groupBox_controls";
            this.groupBox_controls.TabStop = false;
            this.toolTip_Dir.SetToolTip(this.groupBox_controls, resources.GetString("groupBox_controls.ToolTip"));
            // 
            // comboBox_charsinrow
            // 
            resources.ApplyResources(this.comboBox_charsinrow, "comboBox_charsinrow");
            this.comboBox_charsinrow.FormattingEnabled = true;
            this.comboBox_charsinrow.Items.AddRange(new object[] {
            resources.GetString("comboBox_charsinrow.Items"),
            resources.GetString("comboBox_charsinrow.Items1"),
            resources.GetString("comboBox_charsinrow.Items2"),
            resources.GetString("comboBox_charsinrow.Items3")});
            this.comboBox_charsinrow.Name = "comboBox_charsinrow";
            this.toolTip_Dir.SetToolTip(this.comboBox_charsinrow, resources.GetString("comboBox_charsinrow.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip_Dir.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip_Dir.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // textBox_keycode
            // 
            resources.ApplyResources(this.textBox_keycode, "textBox_keycode");
            this.textBox_keycode.Name = "textBox_keycode";
            this.toolTip_Dir.SetToolTip(this.textBox_keycode, resources.GetString("textBox_keycode.ToolTip"));
            this.textBox_keycode.TextChanged += new System.EventHandler(this.TextBox_keycode_TextChanged);
            // 
            // button_decode
            // 
            resources.ApplyResources(this.button_decode, "button_decode");
            this.button_decode.Name = "button_decode";
            this.toolTip_Dir.SetToolTip(this.button_decode, resources.GetString("button_decode.ToolTip"));
            this.button_decode.UseVisualStyleBackColor = true;
            this.button_decode.Click += new System.EventHandler(this.Button_decode_Click);
            // 
            // button_repack
            // 
            resources.ApplyResources(this.button_repack, "button_repack");
            this.button_repack.Name = "button_repack";
            this.toolTip_Dir.SetToolTip(this.button_repack, resources.GetString("button_repack.ToolTip"));
            this.button_repack.UseVisualStyleBackColor = true;
            this.button_repack.Click += new System.EventHandler(this.Button_repack_Click);
            // 
            // button_dirrepack
            // 
            resources.ApplyResources(this.button_dirrepack, "button_dirrepack");
            this.button_dirrepack.Name = "button_dirrepack";
            this.toolTip_Dir.SetToolTip(this.button_dirrepack, resources.GetString("button_dirrepack.ToolTip"));
            this.button_dirrepack.UseVisualStyleBackColor = true;
            this.button_dirrepack.Click += new System.EventHandler(this.Button_dirrepack_Click);
            // 
            // button_rampath
            // 
            resources.ApplyResources(this.button_rampath, "button_rampath");
            this.button_rampath.Name = "button_rampath";
            this.toolTip_Dir.SetToolTip(this.button_rampath, resources.GetString("button_rampath.ToolTip"));
            this.button_rampath.UseVisualStyleBackColor = true;
            this.button_rampath.Click += new System.EventHandler(this.Button_rampath_Click);
            // 
            // groupBox_orig
            // 
            resources.ApplyResources(this.groupBox_orig, "groupBox_orig");
            this.groupBox_orig.Controls.Add(this.textBox_orig);
            this.groupBox_orig.Name = "groupBox_orig";
            this.groupBox_orig.TabStop = false;
            this.toolTip_Dir.SetToolTip(this.groupBox_orig, resources.GetString("groupBox_orig.ToolTip"));
            // 
            // textBox_orig
            // 
            resources.ApplyResources(this.textBox_orig, "textBox_orig");
            this.textBox_orig.Name = "textBox_orig";
            this.textBox_orig.ReadOnly = true;
            this.toolTip_Dir.SetToolTip(this.textBox_orig, resources.GetString("textBox_orig.ToolTip"));
            // 
            // groupBox_decode
            // 
            resources.ApplyResources(this.groupBox_decode, "groupBox_decode");
            this.groupBox_decode.Controls.Add(this.textBox_decode);
            this.groupBox_decode.Name = "groupBox_decode";
            this.groupBox_decode.TabStop = false;
            this.toolTip_Dir.SetToolTip(this.groupBox_decode, resources.GetString("groupBox_decode.ToolTip"));
            // 
            // textBox_decode
            // 
            resources.ApplyResources(this.textBox_decode, "textBox_decode");
            this.textBox_decode.Name = "textBox_decode";
            this.textBox_decode.ReadOnly = true;
            this.toolTip_Dir.SetToolTip(this.textBox_decode, resources.GetString("textBox_decode.ToolTip"));
            // 
            // groupBox_parse
            // 
            resources.ApplyResources(this.groupBox_parse, "groupBox_parse");
            this.groupBox_parse.Controls.Add(this.textBox_parse);
            this.groupBox_parse.Name = "groupBox_parse";
            this.groupBox_parse.TabStop = false;
            this.toolTip_Dir.SetToolTip(this.groupBox_parse, resources.GetString("groupBox_parse.ToolTip"));
            // 
            // textBox_parse
            // 
            resources.ApplyResources(this.textBox_parse, "textBox_parse");
            this.textBox_parse.Name = "textBox_parse";
            this.textBox_parse.ReadOnly = true;
            this.toolTip_Dir.SetToolTip(this.textBox_parse, resources.GetString("textBox_parse.ToolTip"));
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
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
            // backgroundWorker_unpacker
            // 
            this.backgroundWorker_unpacker.WorkerReportsProgress = true;
            this.backgroundWorker_unpacker.WorkerSupportsCancellation = true;
            this.backgroundWorker_unpacker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_unpacker_DoWork);
            this.backgroundWorker_unpacker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_unpacker_ProgressChanged);
            this.backgroundWorker_unpacker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_unpacker_RunWorkerCompleted);
            // 
            // AGMRepacker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AGMRepacker";
            this.toolTip_Dir.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.AGMRepacker_Load);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker_unpacker;
        private System.Windows.Forms.ToolTip toolTip_Dir;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_explorer;
    }
}