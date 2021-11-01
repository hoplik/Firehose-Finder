
namespace FirehoseFinder
{
    partial class Peekpoke
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
            this.tableLayoutPanel_PP = new System.Windows.Forms.TableLayoutPanel();
            this.button_pp_ok = new System.Windows.Forms.Button();
            this.button_pp_cancel = new System.Windows.Forms.Button();
            this.panel_pp_select = new System.Windows.Forms.Panel();
            this.radioButton_poke = new System.Windows.Forms.RadioButton();
            this.radioButton_peek = new System.Windows.Forms.RadioButton();
            this.groupBox_peek = new System.Windows.Forms.GroupBox();
            this.groupBox_poke = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_PP.SuspendLayout();
            this.panel_pp_select.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_PP
            // 
            this.tableLayoutPanel_PP.ColumnCount = 2;
            this.tableLayoutPanel_PP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_PP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_PP.Controls.Add(this.button_pp_ok, 0, 2);
            this.tableLayoutPanel_PP.Controls.Add(this.button_pp_cancel, 1, 2);
            this.tableLayoutPanel_PP.Controls.Add(this.panel_pp_select, 0, 0);
            this.tableLayoutPanel_PP.Controls.Add(this.groupBox_peek, 0, 1);
            this.tableLayoutPanel_PP.Controls.Add(this.groupBox_poke, 1, 1);
            this.tableLayoutPanel_PP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_PP.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_PP.Name = "tableLayoutPanel_PP";
            this.tableLayoutPanel_PP.RowCount = 3;
            this.tableLayoutPanel_PP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_PP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_PP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_PP.Size = new System.Drawing.Size(525, 251);
            this.tableLayoutPanel_PP.TabIndex = 0;
            // 
            // button_pp_ok
            // 
            this.button_pp_ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_pp_ok.Location = new System.Drawing.Point(3, 214);
            this.button_pp_ok.Name = "button_pp_ok";
            this.button_pp_ok.Size = new System.Drawing.Size(256, 34);
            this.button_pp_ok.TabIndex = 0;
            this.button_pp_ok.Text = "Ок";
            this.button_pp_ok.UseVisualStyleBackColor = true;
            this.button_pp_ok.Click += new System.EventHandler(this.Button_pp_ok_Click);
            // 
            // button_pp_cancel
            // 
            this.button_pp_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_pp_cancel.Location = new System.Drawing.Point(265, 214);
            this.button_pp_cancel.Name = "button_pp_cancel";
            this.button_pp_cancel.Size = new System.Drawing.Size(257, 34);
            this.button_pp_cancel.TabIndex = 1;
            this.button_pp_cancel.Text = "Отмена";
            this.button_pp_cancel.UseVisualStyleBackColor = true;
            this.button_pp_cancel.Click += new System.EventHandler(this.Button_pp_cancel_Click);
            // 
            // panel_pp_select
            // 
            this.tableLayoutPanel_PP.SetColumnSpan(this.panel_pp_select, 2);
            this.panel_pp_select.Controls.Add(this.radioButton_poke);
            this.panel_pp_select.Controls.Add(this.radioButton_peek);
            this.panel_pp_select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_pp_select.Location = new System.Drawing.Point(3, 3);
            this.panel_pp_select.Name = "panel_pp_select";
            this.panel_pp_select.Size = new System.Drawing.Size(519, 34);
            this.panel_pp_select.TabIndex = 2;
            // 
            // radioButton_poke
            // 
            this.radioButton_poke.AutoSize = true;
            this.radioButton_poke.BackColor = System.Drawing.Color.Red;
            this.radioButton_poke.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioButton_poke.Location = new System.Drawing.Point(329, 0);
            this.radioButton_poke.Name = "radioButton_poke";
            this.radioButton_poke.Size = new System.Drawing.Size(190, 34);
            this.radioButton_poke.TabIndex = 1;
            this.radioButton_poke.Text = "Пишем байты по адресу";
            this.radioButton_poke.UseVisualStyleBackColor = false;
            this.radioButton_poke.CheckedChanged += new System.EventHandler(this.RadioButton_poke_CheckedChanged);
            // 
            // radioButton_peek
            // 
            this.radioButton_peek.AutoSize = true;
            this.radioButton_peek.BackColor = System.Drawing.Color.GreenYellow;
            this.radioButton_peek.Checked = true;
            this.radioButton_peek.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton_peek.Location = new System.Drawing.Point(0, 0);
            this.radioButton_peek.Name = "radioButton_peek";
            this.radioButton_peek.Size = new System.Drawing.Size(194, 34);
            this.radioButton_peek.TabIndex = 0;
            this.radioButton_peek.TabStop = true;
            this.radioButton_peek.Text = "Читаем байты по адресу";
            this.radioButton_peek.UseVisualStyleBackColor = false;
            this.radioButton_peek.CheckedChanged += new System.EventHandler(this.RadioButton_peek_CheckedChanged);
            // 
            // groupBox_peek
            // 
            this.groupBox_peek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_peek.Location = new System.Drawing.Point(3, 43);
            this.groupBox_peek.Name = "groupBox_peek";
            this.groupBox_peek.Size = new System.Drawing.Size(256, 165);
            this.groupBox_peek.TabIndex = 3;
            this.groupBox_peek.TabStop = false;
            this.groupBox_peek.Text = "Читаем";
            // 
            // groupBox_poke
            // 
            this.groupBox_poke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_poke.Enabled = false;
            this.groupBox_poke.Location = new System.Drawing.Point(265, 43);
            this.groupBox_poke.Name = "groupBox_poke";
            this.groupBox_poke.Size = new System.Drawing.Size(257, 165);
            this.groupBox_poke.TabIndex = 4;
            this.groupBox_poke.TabStop = false;
            this.groupBox_poke.Text = "Пишем";
            // 
            // Peekpoke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 251);
            this.Controls.Add(this.tableLayoutPanel_PP);
            this.Name = "Peekpoke";
            this.Text = "Читаем/пишем байты по адресу";
            this.tableLayoutPanel_PP.ResumeLayout(false);
            this.panel_pp_select.ResumeLayout(false);
            this.panel_pp_select.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_PP;
        private System.Windows.Forms.Button button_pp_ok;
        private System.Windows.Forms.Button button_pp_cancel;
        private System.Windows.Forms.Panel panel_pp_select;
        private System.Windows.Forms.RadioButton radioButton_poke;
        private System.Windows.Forms.RadioButton radioButton_peek;
        private System.Windows.Forms.GroupBox groupBox_peek;
        private System.Windows.Forms.GroupBox groupBox_poke;
    }
}