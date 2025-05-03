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
            this.tabPage_sahara3 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.UniButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // 
            // UniButton
            // 
            this.UniButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UniButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SendToolStripMenuItem});
            resources.ApplyResources(this.UniButton, "UniButton");
            this.UniButton.Name = "UniButton";
            // 
            // SendToolStripMenuItem
            // 
            this.SendToolStripMenuItem.Name = "SendToolStripMenuItem";
            resources.ApplyResources(this.SendToolStripMenuItem, "SendToolStripMenuItem");
            this.SendToolStripMenuItem.Click += new System.EventHandler(this.SendToolStripMenuItem_Click);
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
    }
}