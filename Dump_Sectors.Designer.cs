
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
            this.button_dump_ok = new System.Windows.Forms.Button();
            this.button_dump_cancel = new System.Windows.Forms.Button();
            this.label_dump_max = new System.Windows.Forms.Label();
            this.groupBox_dump = new System.Windows.Forms.GroupBox();
            this.label_start_dump = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_count_dump = new System.Windows.Forms.Label();
            this.label_count1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox_dump.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_dump_ok
            // 
            this.button_dump_ok.Enabled = false;
            this.button_dump_ok.Location = new System.Drawing.Point(13, 116);
            this.button_dump_ok.Name = "button_dump_ok";
            this.button_dump_ok.Size = new System.Drawing.Size(75, 23);
            this.button_dump_ok.TabIndex = 0;
            this.button_dump_ok.Text = "Ok";
            this.button_dump_ok.UseVisualStyleBackColor = true;
            // 
            // button_dump_cancel
            // 
            this.button_dump_cancel.Location = new System.Drawing.Point(384, 116);
            this.button_dump_cancel.Name = "button_dump_cancel";
            this.button_dump_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_dump_cancel.TabIndex = 1;
            this.button_dump_cancel.Text = "Отмена";
            this.button_dump_cancel.UseVisualStyleBackColor = true;
            this.button_dump_cancel.Click += new System.EventHandler(this.Button_dump_cancel_Click);
            // 
            // label_dump_max
            // 
            this.label_dump_max.AutoSize = true;
            this.label_dump_max.Location = new System.Drawing.Point(13, 13);
            this.label_dump_max.Name = "label_dump_max";
            this.label_dump_max.Size = new System.Drawing.Size(398, 17);
            this.label_dump_max.TabIndex = 2;
            this.label_dump_max.Text = "Вы можете выбрать не более {0} секторов для этого диска";
            // 
            // groupBox_dump
            // 
            this.groupBox_dump.Controls.Add(this.textBox2);
            this.groupBox_dump.Controls.Add(this.label_count1);
            this.groupBox_dump.Controls.Add(this.label_count_dump);
            this.groupBox_dump.Controls.Add(this.textBox1);
            this.groupBox_dump.Controls.Add(this.label_start_dump);
            this.groupBox_dump.Location = new System.Drawing.Point(16, 51);
            this.groupBox_dump.Name = "groupBox_dump";
            this.groupBox_dump.Size = new System.Drawing.Size(443, 46);
            this.groupBox_dump.TabIndex = 3;
            this.groupBox_dump.TabStop = false;
            this.groupBox_dump.Text = "Сохранить сектора";
            // 
            // label_start_dump
            // 
            this.label_start_dump.AutoSize = true;
            this.label_start_dump.Location = new System.Drawing.Point(6, 24);
            this.label_start_dump.Name = "label_start_dump";
            this.label_start_dump.Size = new System.Drawing.Size(128, 17);
            this.label_start_dump.TabIndex = 0;
            this.label_start_dump.Text = "начиная с номера";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            // 
            // label_count_dump
            // 
            this.label_count_dump.AutoSize = true;
            this.label_count_dump.Location = new System.Drawing.Point(210, 24);
            this.label_count_dump.Name = "label_count_dump";
            this.label_count_dump.Size = new System.Drawing.Size(95, 17);
            this.label_count_dump.TabIndex = 2;
            this.label_count_dump.Text = "в количестве";
            // 
            // label_count1
            // 
            this.label_count1.AutoSize = true;
            this.label_count1.Location = new System.Drawing.Point(397, 24);
            this.label_count1.Name = "label_count1";
            this.label_count1.Size = new System.Drawing.Size(40, 17);
            this.label_count1.TabIndex = 3;
            this.label_count1.Text = "штук";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(311, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 22);
            this.textBox2.TabIndex = 4;
            // 
            // Dump_Sectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 154);
            this.Controls.Add(this.groupBox_dump);
            this.Controls.Add(this.label_dump_max);
            this.Controls.Add(this.button_dump_cancel);
            this.Controls.Add(this.button_dump_ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dump_Sectors";
            this.Text = "Сектора для сохранения";
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label_count1;
        private System.Windows.Forms.Label label_count_dump;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_start_dump;
    }
}