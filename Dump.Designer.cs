
namespace FirehoseFinder
{
    partial class Dump
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_ok_dump = new System.Windows.Forms.Button();
            this.button_cancel_dump = new System.Windows.Forms.Button();
            this.progressBar_dump = new System.Windows.Forms.ProgressBar();
            this.label1_dump = new System.Windows.Forms.Label();
            this.label2_dump = new System.Windows.Forms.Label();
            this.backgroundWorker_dump = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.button_ok_dump, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_cancel_dump, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_dump, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1_dump, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2_dump, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 242);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_ok_dump
            // 
            this.button_ok_dump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ok_dump.Enabled = false;
            this.button_ok_dump.Location = new System.Drawing.Point(3, 205);
            this.button_ok_dump.Name = "button_ok_dump";
            this.button_ok_dump.Size = new System.Drawing.Size(144, 34);
            this.button_ok_dump.TabIndex = 0;
            this.button_ok_dump.Text = "Ok";
            this.button_ok_dump.UseVisualStyleBackColor = true;
            this.button_ok_dump.Click += new System.EventHandler(this.Button_ok_dump_Click);
            // 
            // button_cancel_dump
            // 
            this.button_cancel_dump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_cancel_dump.Location = new System.Drawing.Point(453, 205);
            this.button_cancel_dump.Name = "button_cancel_dump";
            this.button_cancel_dump.Size = new System.Drawing.Size(144, 34);
            this.button_cancel_dump.TabIndex = 1;
            this.button_cancel_dump.Text = "Отмена";
            this.button_cancel_dump.UseVisualStyleBackColor = true;
            this.button_cancel_dump.Click += new System.EventHandler(this.Button_cancel_dump_Click);
            // 
            // progressBar_dump
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar_dump, 3);
            this.progressBar_dump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_dump.Location = new System.Drawing.Point(3, 165);
            this.progressBar_dump.Name = "progressBar_dump";
            this.progressBar_dump.Size = new System.Drawing.Size(594, 34);
            this.progressBar_dump.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar_dump.TabIndex = 2;
            // 
            // label1_dump
            // 
            this.label1_dump.AutoSize = true;
            this.label1_dump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1_dump.Location = new System.Drawing.Point(3, 0);
            this.label1_dump.Name = "label1_dump";
            this.label1_dump.Size = new System.Drawing.Size(144, 162);
            this.label1_dump.TabIndex = 3;
            this.label1_dump.Text = "Запущена длительная по времени операция. Для досрочного прекращения выполнения мо" +
    "жно воспользоваться кнопкой \"Отмена\"";
            // 
            // label2_dump
            // 
            this.label2_dump.AutoSize = true;
            this.label2_dump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2_dump.Location = new System.Drawing.Point(153, 0);
            this.label2_dump.Name = "label2_dump";
            this.label2_dump.Size = new System.Drawing.Size(294, 162);
            this.label2_dump.TabIndex = 4;
            this.label2_dump.Text = "Выполнено";
            // 
            // backgroundWorker_dump
            // 
            this.backgroundWorker_dump.WorkerReportsProgress = true;
            this.backgroundWorker_dump.WorkerSupportsCancellation = true;
            this.backgroundWorker_dump.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_dump_DoWork);
            this.backgroundWorker_dump.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_dump_ProgressChanged);
            this.backgroundWorker_dump.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_dump_RunWorkerCompleted);
            // 
            // Dump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 242);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dump";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Процедура сохранения разделов";
            this.Shown += new System.EventHandler(this.Dump_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_ok_dump;
        private System.Windows.Forms.Button button_cancel_dump;
        private System.Windows.Forms.ProgressBar progressBar_dump;
        private System.Windows.Forms.Label label1_dump;
        private System.Windows.Forms.Label label2_dump;
        private System.ComponentModel.BackgroundWorker backgroundWorker_dump;
    }
}