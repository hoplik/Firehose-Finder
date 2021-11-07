
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
            this.textBox_peek_cb = new System.Windows.Forms.TextBox();
            this.textBox_peek_adr = new System.Windows.Forms.TextBox();
            this.label_peek_cb = new System.Windows.Forms.Label();
            this.label_peek_adr = new System.Windows.Forms.Label();
            this.groupBox_poke = new System.Windows.Forms.GroupBox();
            this.label_poke_cbytes = new System.Windows.Forms.Label();
            this.label_poke_cb = new System.Windows.Forms.Label();
            this.textBox_poke_bytes = new System.Windows.Forms.TextBox();
            this.textBox_poke_adr = new System.Windows.Forms.TextBox();
            this.label_poke_bytes = new System.Windows.Forms.Label();
            this.label_poke_adr = new System.Windows.Forms.Label();
            this.tableLayoutPanel_PP.SuspendLayout();
            this.panel_pp_select.SuspendLayout();
            this.groupBox_peek.SuspendLayout();
            this.groupBox_poke.SuspendLayout();
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
            this.groupBox_peek.Controls.Add(this.textBox_peek_cb);
            this.groupBox_peek.Controls.Add(this.textBox_peek_adr);
            this.groupBox_peek.Controls.Add(this.label_peek_cb);
            this.groupBox_peek.Controls.Add(this.label_peek_adr);
            this.groupBox_peek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_peek.Location = new System.Drawing.Point(3, 43);
            this.groupBox_peek.Name = "groupBox_peek";
            this.groupBox_peek.Size = new System.Drawing.Size(256, 165);
            this.groupBox_peek.TabIndex = 3;
            this.groupBox_peek.TabStop = false;
            this.groupBox_peek.Text = "Читаем";
            // 
            // textBox_peek_cb
            // 
            this.textBox_peek_cb.Location = new System.Drawing.Point(150, 69);
            this.textBox_peek_cb.Name = "textBox_peek_cb";
            this.textBox_peek_cb.Size = new System.Drawing.Size(100, 22);
            this.textBox_peek_cb.TabIndex = 3;
            this.textBox_peek_cb.Text = "1";
            this.textBox_peek_cb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_peek_adr
            // 
            this.textBox_peek_adr.Location = new System.Drawing.Point(150, 31);
            this.textBox_peek_adr.Name = "textBox_peek_adr";
            this.textBox_peek_adr.Size = new System.Drawing.Size(100, 22);
            this.textBox_peek_adr.TabIndex = 2;
            this.textBox_peek_adr.Text = "000000";
            this.textBox_peek_adr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_peek_adr.TextChanged += new System.EventHandler(this.TextBox_peek_adr_TextChanged);
            // 
            // label_peek_cb
            // 
            this.label_peek_cb.AutoSize = true;
            this.label_peek_cb.Location = new System.Drawing.Point(9, 74);
            this.label_peek_cb.Name = "label_peek_cb";
            this.label_peek_cb.Size = new System.Drawing.Size(125, 17);
            this.label_peek_cb.TabIndex = 1;
            this.label_peek_cb.Text = "Кол-во байт (dec)";
            // 
            // label_peek_adr
            // 
            this.label_peek_adr.AutoSize = true;
            this.label_peek_adr.Location = new System.Drawing.Point(9, 36);
            this.label_peek_adr.Name = "label_peek_adr";
            this.label_peek_adr.Size = new System.Drawing.Size(106, 17);
            this.label_peek_adr.TabIndex = 0;
            this.label_peek_adr.Text = "Адрес (hex, 0x)";
            // 
            // groupBox_poke
            // 
            this.groupBox_poke.Controls.Add(this.label_poke_cbytes);
            this.groupBox_poke.Controls.Add(this.label_poke_cb);
            this.groupBox_poke.Controls.Add(this.textBox_poke_bytes);
            this.groupBox_poke.Controls.Add(this.textBox_poke_adr);
            this.groupBox_poke.Controls.Add(this.label_poke_bytes);
            this.groupBox_poke.Controls.Add(this.label_poke_adr);
            this.groupBox_poke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_poke.Enabled = false;
            this.groupBox_poke.Location = new System.Drawing.Point(265, 43);
            this.groupBox_poke.Name = "groupBox_poke";
            this.groupBox_poke.Size = new System.Drawing.Size(257, 165);
            this.groupBox_poke.TabIndex = 4;
            this.groupBox_poke.TabStop = false;
            this.groupBox_poke.Text = "Пишем";
            // 
            // label_poke_cbytes
            // 
            this.label_poke_cbytes.AutoSize = true;
            this.label_poke_cbytes.Location = new System.Drawing.Point(144, 74);
            this.label_poke_cbytes.Name = "label_poke_cbytes";
            this.label_poke_cbytes.Size = new System.Drawing.Size(16, 17);
            this.label_poke_cbytes.TabIndex = 9;
            this.label_poke_cbytes.Text = "0";
            // 
            // label_poke_cb
            // 
            this.label_poke_cb.AutoSize = true;
            this.label_poke_cb.Location = new System.Drawing.Point(6, 74);
            this.label_poke_cb.Name = "label_poke_cb";
            this.label_poke_cb.Size = new System.Drawing.Size(125, 17);
            this.label_poke_cb.TabIndex = 8;
            this.label_poke_cb.Text = "Кол-во байт (dec)";
            // 
            // textBox_poke_bytes
            // 
            this.textBox_poke_bytes.Location = new System.Drawing.Point(9, 123);
            this.textBox_poke_bytes.Name = "textBox_poke_bytes";
            this.textBox_poke_bytes.Size = new System.Drawing.Size(238, 22);
            this.textBox_poke_bytes.TabIndex = 7;
            this.textBox_poke_bytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_poke_bytes.TextChanged += new System.EventHandler(this.TextBox_poke_bytes_TextChanged);
            this.textBox_poke_bytes.Leave += new System.EventHandler(this.TextBox_poke_bytes_Leave);
            // 
            // textBox_poke_adr
            // 
            this.textBox_poke_adr.Location = new System.Drawing.Point(147, 31);
            this.textBox_poke_adr.Name = "textBox_poke_adr";
            this.textBox_poke_adr.Size = new System.Drawing.Size(100, 22);
            this.textBox_poke_adr.TabIndex = 6;
            this.textBox_poke_adr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_poke_adr.TextChanged += new System.EventHandler(this.TextBox_poke_adr_TextChanged);
            // 
            // label_poke_bytes
            // 
            this.label_poke_bytes.AutoSize = true;
            this.label_poke_bytes.Location = new System.Drawing.Point(6, 103);
            this.label_poke_bytes.Name = "label_poke_bytes";
            this.label_poke_bytes.Size = new System.Drawing.Size(186, 17);
            this.label_poke_bytes.TabIndex = 5;
            this.label_poke_bytes.Text = "Байты для записи (hex, 0x)";
            // 
            // label_poke_adr
            // 
            this.label_poke_adr.AutoSize = true;
            this.label_poke_adr.Location = new System.Drawing.Point(6, 36);
            this.label_poke_adr.Name = "label_poke_adr";
            this.label_poke_adr.Size = new System.Drawing.Size(106, 17);
            this.label_poke_adr.TabIndex = 4;
            this.label_poke_adr.Text = "Адрес (hex, 0x)";
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
            this.groupBox_peek.ResumeLayout(false);
            this.groupBox_peek.PerformLayout();
            this.groupBox_poke.ResumeLayout(false);
            this.groupBox_poke.PerformLayout();
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
        private System.Windows.Forms.Label label_peek_cb;
        private System.Windows.Forms.Label label_peek_adr;
        private System.Windows.Forms.TextBox textBox_peek_cb;
        private System.Windows.Forms.TextBox textBox_peek_adr;
        private System.Windows.Forms.Label label_poke_cbytes;
        private System.Windows.Forms.Label label_poke_cb;
        private System.Windows.Forms.TextBox textBox_poke_bytes;
        private System.Windows.Forms.TextBox textBox_poke_adr;
        private System.Windows.Forms.Label label_poke_bytes;
        private System.Windows.Forms.Label label_poke_adr;
    }
}