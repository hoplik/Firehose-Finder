namespace FirehoseFinder.Forms
{
    partial class Ten_Sec_Form
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ten_sec_mess = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_can = new System.Windows.Forms.Button();
            this.timer_ten_sec_mess = new System.Windows.Forms.Timer(this.components);
            this.countdown_timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_ten_sec_mess, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ok, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_can, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(577, 211);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_ten_sec_mess
            // 
            this.label_ten_sec_mess.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label_ten_sec_mess, 2);
            this.label_ten_sec_mess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ten_sec_mess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ten_sec_mess.Location = new System.Drawing.Point(3, 0);
            this.label_ten_sec_mess.Name = "label_ten_sec_mess";
            this.label_ten_sec_mess.Size = new System.Drawing.Size(571, 175);
            this.label_ten_sec_mess.TabIndex = 1;
            this.label_ten_sec_mess.Text = "label1";
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ok.Location = new System.Drawing.Point(3, 178);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(282, 30);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ok (15)";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // button_can
            // 
            this.button_can.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_can.Location = new System.Drawing.Point(291, 178);
            this.button_can.Name = "button_can";
            this.button_can.Size = new System.Drawing.Size(283, 30);
            this.button_can.TabIndex = 1;
            this.button_can.Text = "Отмена";
            this.button_can.UseVisualStyleBackColor = true;
            this.button_can.Click += new System.EventHandler(this.Button_can_Click);
            // 
            // timer_ten_sec_mess
            // 
            this.timer_ten_sec_mess.Interval = 15000;
            this.timer_ten_sec_mess.Tick += new System.EventHandler(this.Timer_ten_sec_mess_Tick);
            // 
            // countdown_timer
            // 
            this.countdown_timer.Interval = 1000;
            this.countdown_timer.Tick += new System.EventHandler(this.Countdown_timer_Tick);
            // 
            // Ten_Sec_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 211);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Ten_Sec_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ten_Sec_Form";
            this.Load += new System.EventHandler(this.Ten_Sec_Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_can;
        private System.Windows.Forms.Timer timer_ten_sec_mess;
        private System.Windows.Forms.Label label_ten_sec_mess;
        private System.Windows.Forms.Timer countdown_timer;
    }
}