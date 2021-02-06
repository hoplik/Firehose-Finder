
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
            this.checkBox_start = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.richTextBox_greeting = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel_greeting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_greeting
            // 
            this.tableLayoutPanel_greeting.ColumnCount = 2;
            this.tableLayoutPanel_greeting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_greeting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_greeting.Controls.Add(this.checkBox_start, 0, 1);
            this.tableLayoutPanel_greeting.Controls.Add(this.button_ok, 1, 1);
            this.tableLayoutPanel_greeting.Controls.Add(this.richTextBox_greeting, 0, 0);
            this.tableLayoutPanel_greeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_greeting.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_greeting.Name = "tableLayoutPanel_greeting";
            this.tableLayoutPanel_greeting.RowCount = 2;
            this.tableLayoutPanel_greeting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel_greeting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel_greeting.Size = new System.Drawing.Size(656, 458);
            this.tableLayoutPanel_greeting.TabIndex = 0;
            // 
            // checkBox_start
            // 
            this.checkBox_start.AutoSize = true;
            this.checkBox_start.Checked = true;
            this.checkBox_start.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_start.Location = new System.Drawing.Point(3, 415);
            this.checkBox_start.Name = "checkBox_start";
            this.checkBox_start.Size = new System.Drawing.Size(175, 21);
            this.checkBox_start.TabIndex = 0;
            this.checkBox_start.Text = "Запускать при старте";
            this.checkBox_start.UseVisualStyleBackColor = true;
            this.checkBox_start.CheckedChanged += new System.EventHandler(this.CheckBox_start_CheckedChanged);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(331, 415);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // richTextBox_greeting
            // 
            this.tableLayoutPanel_greeting.SetColumnSpan(this.richTextBox_greeting, 2);
            this.richTextBox_greeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_greeting.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_greeting.Name = "richTextBox_greeting";
            this.richTextBox_greeting.Size = new System.Drawing.Size(650, 406);
            this.richTextBox_greeting.TabIndex = 2;
            this.richTextBox_greeting.Text = "";
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
        private System.Windows.Forms.RichTextBox richTextBox_greeting;
    }
}