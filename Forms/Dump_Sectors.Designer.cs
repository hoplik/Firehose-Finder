
namespace FirehoseFinder
{
    partial class Dump_Sectors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dump_Sectors));
            this.button_dump_ok = new System.Windows.Forms.Button();
            this.button_dump_cancel = new System.Windows.Forms.Button();
            this.label_dump_max = new System.Windows.Forms.Label();
            this.groupBox_dump = new System.Windows.Forms.GroupBox();
            this.textBox_count_dump = new System.Windows.Forms.TextBox();
            this.label_count1 = new System.Windows.Forms.Label();
            this.label_count_dump = new System.Windows.Forms.Label();
            this.textBox_start_dump = new System.Windows.Forms.TextBox();
            this.label_start_dump = new System.Windows.Forms.Label();
            this.groupBox_dump.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_dump_ok
            // 
            resources.ApplyResources(this.button_dump_ok, "button_dump_ok");
            this.button_dump_ok.Name = "button_dump_ok";
            this.button_dump_ok.UseVisualStyleBackColor = true;
            this.button_dump_ok.Click += new System.EventHandler(this.Button_dump_ok_Click);
            // 
            // button_dump_cancel
            // 
            resources.ApplyResources(this.button_dump_cancel, "button_dump_cancel");
            this.button_dump_cancel.Name = "button_dump_cancel";
            this.button_dump_cancel.UseVisualStyleBackColor = true;
            this.button_dump_cancel.Click += new System.EventHandler(this.Button_dump_cancel_Click);
            // 
            // label_dump_max
            // 
            resources.ApplyResources(this.label_dump_max, "label_dump_max");
            this.label_dump_max.Name = "label_dump_max";
            // 
            // groupBox_dump
            // 
            this.groupBox_dump.Controls.Add(this.textBox_count_dump);
            this.groupBox_dump.Controls.Add(this.label_count1);
            this.groupBox_dump.Controls.Add(this.label_count_dump);
            this.groupBox_dump.Controls.Add(this.textBox_start_dump);
            this.groupBox_dump.Controls.Add(this.label_start_dump);
            resources.ApplyResources(this.groupBox_dump, "groupBox_dump");
            this.groupBox_dump.Name = "groupBox_dump";
            this.groupBox_dump.TabStop = false;
            // 
            // textBox_count_dump
            // 
            resources.ApplyResources(this.textBox_count_dump, "textBox_count_dump");
            this.textBox_count_dump.Name = "textBox_count_dump";
            this.textBox_count_dump.TextChanged += new System.EventHandler(this.TextBox_count_dump_TextChanged);
            // 
            // label_count1
            // 
            resources.ApplyResources(this.label_count1, "label_count1");
            this.label_count1.Name = "label_count1";
            // 
            // label_count_dump
            // 
            resources.ApplyResources(this.label_count_dump, "label_count_dump");
            this.label_count_dump.Name = "label_count_dump";
            // 
            // textBox_start_dump
            // 
            resources.ApplyResources(this.textBox_start_dump, "textBox_start_dump");
            this.textBox_start_dump.Name = "textBox_start_dump";
            this.textBox_start_dump.TextChanged += new System.EventHandler(this.TextBox_start_dump_TextChanged);
            // 
            // label_start_dump
            // 
            resources.ApplyResources(this.label_start_dump, "label_start_dump");
            this.label_start_dump.Name = "label_start_dump";
            // 
            // Dump_Sectors
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_dump);
            this.Controls.Add(this.label_dump_max);
            this.Controls.Add(this.button_dump_cancel);
            this.Controls.Add(this.button_dump_ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dump_Sectors";
            this.Shown += new System.EventHandler(this.Dump_Sectors_Shown);
            this.groupBox_dump.ResumeLayout(false);
            this.groupBox_dump.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_dump_ok;
        private System.Windows.Forms.Button button_dump_cancel;
        private System.Windows.Forms.Label label_dump_max;
        private System.Windows.Forms.GroupBox groupBox_dump;
        private System.Windows.Forms.Label label_count1;
        private System.Windows.Forms.Label label_count_dump;
        private System.Windows.Forms.Label label_start_dump;
        internal System.Windows.Forms.TextBox textBox_count_dump;
        internal System.Windows.Forms.TextBox textBox_start_dump;
    }
}