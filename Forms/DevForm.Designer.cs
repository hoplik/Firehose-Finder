namespace FirehoseFinder.Forms
{
    partial class DevForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_fh7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_com = new System.Windows.Forms.Label();
            this.richTextBox_comm = new System.Windows.Forms.RichTextBox();
            this.button_select_fh = new System.Windows.Forms.Button();
            this.button_share_fh = new System.Windows.Forms.Button();
            this.textBox_fh_res = new System.Windows.Forms.TextBox();
            this.textBox_fh_log = new System.Windows.Forms.TextBox();
            this.textBox_dev_comcom = new System.Windows.Forms.TextBox();
            this.tabPage_sahara3 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.UniButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel_bgw_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_load_fh = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_analyse_fh = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage_fh7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_fh7);
            this.tabControl1.Controls.Add(this.tabPage_sahara3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage_fh7
            // 
            this.tabPage_fh7.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage_fh7, "tabPage_fh7");
            this.tabPage_fh7.Name = "tabPage_fh7";
            this.tabPage_fh7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label_com, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_comm, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_select_fh, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_share_fh, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_fh_res, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_fh_log, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_dev_comcom, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label_com
            // 
            resources.ApplyResources(this.label_com, "label_com");
            this.label_com.Name = "label_com";
            // 
            // richTextBox_comm
            // 
            this.richTextBox_comm.AcceptsTab = true;
            resources.ApplyResources(this.richTextBox_comm, "richTextBox_comm");
            this.richTextBox_comm.Name = "richTextBox_comm";
            this.richTextBox_comm.ReadOnly = true;
            // 
            // button_select_fh
            // 
            resources.ApplyResources(this.button_select_fh, "button_select_fh");
            this.button_select_fh.Name = "button_select_fh";
            this.button_select_fh.UseVisualStyleBackColor = true;
            this.button_select_fh.Click += new System.EventHandler(this.Button_select_fh_Click);
            // 
            // button_share_fh
            // 
            resources.ApplyResources(this.button_share_fh, "button_share_fh");
            this.button_share_fh.Name = "button_share_fh";
            this.button_share_fh.UseVisualStyleBackColor = true;
            // 
            // textBox_fh_res
            // 
            resources.ApplyResources(this.textBox_fh_res, "textBox_fh_res");
            this.textBox_fh_res.Name = "textBox_fh_res";
            this.textBox_fh_res.ReadOnly = true;
            // 
            // textBox_fh_log
            // 
            resources.ApplyResources(this.textBox_fh_log, "textBox_fh_log");
            this.textBox_fh_log.Name = "textBox_fh_log";
            this.textBox_fh_log.ReadOnly = true;
            // 
            // textBox_dev_comcom
            // 
            resources.ApplyResources(this.textBox_dev_comcom, "textBox_dev_comcom");
            this.textBox_dev_comcom.Name = "textBox_dev_comcom";
            this.textBox_dev_comcom.Enter += new System.EventHandler(this.TextBox_dev_comcom_Enter);
            this.textBox_dev_comcom.Leave += new System.EventHandler(this.TextBox_dev_comcom_Leave);
            // 
            // tabPage_sahara3
            // 
            resources.ApplyResources(this.tabPage_sahara3, "tabPage_sahara3");
            this.tabPage_sahara3.Name = "tabPage_sahara3";
            this.tabPage_sahara3.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.UniButton});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // UniButton
            // 
            this.UniButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UniButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SendToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.Cancel_bgw_ToolStripMenuItem});
            resources.ApplyResources(this.UniButton, "UniButton");
            this.UniButton.Name = "UniButton";
            // 
            // SendToolStripMenuItem
            // 
            this.SendToolStripMenuItem.Name = "SendToolStripMenuItem";
            resources.ApplyResources(this.SendToolStripMenuItem, "SendToolStripMenuItem");
            this.SendToolStripMenuItem.Click += new System.EventHandler(this.SendToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // Cancel_bgw_ToolStripMenuItem
            // 
            resources.ApplyResources(this.Cancel_bgw_ToolStripMenuItem, "Cancel_bgw_ToolStripMenuItem");
            this.Cancel_bgw_ToolStripMenuItem.Name = "Cancel_bgw_ToolStripMenuItem";
            this.Cancel_bgw_ToolStripMenuItem.Click += new System.EventHandler(this.Cancel_bgw_ToolStripMenuItem_Click);
            // 
            // openFileDialog_load_fh
            // 
            this.openFileDialog_load_fh.DefaultExt = "elf";
            resources.ApplyResources(this.openFileDialog_load_fh, "openFileDialog_load_fh");
            this.openFileDialog_load_fh.InitialDirectory = "Desktop";
            // 
            // backgroundWorker_analyse_fh
            // 
            this.backgroundWorker_analyse_fh.WorkerReportsProgress = true;
            this.backgroundWorker_analyse_fh.WorkerSupportsCancellation = true;
            this.backgroundWorker_analyse_fh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_analyse_fh_DoWork);
            this.backgroundWorker_analyse_fh.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_analyse_fh_ProgressChanged);
            this.backgroundWorker_analyse_fh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_analyse_fh_RunWorkerCompleted);
            // 
            // DevForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DevForm";
            this.Shown += new System.EventHandler(this.DevForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_fh7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_fh7;
        private System.Windows.Forms.TabPage tabPage_sahara3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_com;
        private System.Windows.Forms.RichTextBox richTextBox_comm;
        private System.Windows.Forms.ToolStripDropDownButton UniButton;
        private System.Windows.Forms.ToolStripMenuItem SendToolStripMenuItem;
        private System.Windows.Forms.Button button_select_fh;
        private System.Windows.Forms.Button button_share_fh;
        private System.Windows.Forms.TextBox textBox_fh_res;
        private System.Windows.Forms.TextBox textBox_fh_log;
        private System.Windows.Forms.OpenFileDialog openFileDialog_load_fh;
        private System.Windows.Forms.TextBox textBox_dev_comcom;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker_analyse_fh;
        private System.Windows.Forms.ToolStripMenuItem Cancel_bgw_ToolStripMenuItem;
    }
}