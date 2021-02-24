
namespace FirehoseFinder
{
    partial class Greeting
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
            this.tableLayoutPanel_greeting = new System.Windows.Forms.TableLayoutPanel();
            this.button_ok = new System.Windows.Forms.Button();
            this.checkBox_start = new System.Windows.Forms.CheckBox();
            this.textBox_greeting = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_greeting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_greeting
            // 
            this.tableLayoutPanel_greeting.ColumnCount = 2;
            this.tableLayoutPanel_greeting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_greeting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_greeting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_greeting.Controls.Add(this.textBox_greeting, 0, 0);
            this.tableLayoutPanel_greeting.Controls.Add(this.checkBox_start, 0, 1);
            this.tableLayoutPanel_greeting.Controls.Add(this.button_ok, 1, 1);
            this.tableLayoutPanel_greeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_greeting.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_greeting.Name = "tableLayoutPanel_greeting";
            this.tableLayoutPanel_greeting.RowCount = 2;
            this.tableLayoutPanel_greeting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_greeting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_greeting.Size = new System.Drawing.Size(656, 458);
            this.tableLayoutPanel_greeting.TabIndex = 0;
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ok.Location = new System.Drawing.Point(331, 421);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(322, 34);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // checkBox_start
            // 
            this.checkBox_start.AutoSize = true;
            this.checkBox_start.Checked = true;
            this.checkBox_start.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_start.Location = new System.Drawing.Point(3, 421);
            this.checkBox_start.Name = "checkBox_start";
            this.checkBox_start.Size = new System.Drawing.Size(322, 34);
            this.checkBox_start.TabIndex = 0;
            this.checkBox_start.Text = "Запускать при старте";
            this.checkBox_start.UseVisualStyleBackColor = true;
            this.checkBox_start.CheckedChanged += new System.EventHandler(this.CheckBox_start_CheckedChanged);
            // 
            // textBox_greeting
            // 
            this.tableLayoutPanel_greeting.SetColumnSpan(this.textBox_greeting, 2);
            this.textBox_greeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_greeting.Location = new System.Drawing.Point(3, 3);
            this.textBox_greeting.Multiline = true;
            this.textBox_greeting.Name = "textBox_greeting";
            this.textBox_greeting.ReadOnly = true;
            this.textBox_greeting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_greeting.Size = new System.Drawing.Size(650, 412);
            this.textBox_greeting.TabIndex = 2;
            // 
            // Greeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 458);
            this.Controls.Add(this.tableLayoutPanel_greeting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Greeting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приветствие";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Greeting_Load);
            this.tableLayoutPanel_greeting.ResumeLayout(false);
            this.tableLayoutPanel_greeting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_greeting;
        private System.Windows.Forms.CheckBox checkBox_start;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_greeting;
    }
}