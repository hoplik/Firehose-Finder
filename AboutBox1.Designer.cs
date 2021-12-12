
namespace FirehoseFinder
{
    partial class AboutBox1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.linkLabel_telega = new System.Windows.Forms.LinkLabel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.linkLabel_forum = new System.Windows.Forms.LinkLabel();
            this.label_donate = new System.Windows.Forms.Label();
            this.button_donate_ymoney = new System.Windows.Forms.Button();
            this.button_donate_pp = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.linkLabel_telega, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.linkLabel_forum, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.label_donate, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.button_donate_ymoney, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.button_donate_pp, 0, 6);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(753, 353);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // linkLabel_telega
            // 
            this.linkLabel_telega.AutoSize = true;
            this.linkLabel_telega.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel_telega.LinkArea = new System.Windows.Forms.LinkArea(65, 24);
            this.linkLabel_telega.Location = new System.Drawing.Point(251, 245);
            this.linkLabel_telega.Name = "linkLabel_telega";
            this.linkLabel_telega.Size = new System.Drawing.Size(499, 70);
            this.linkLabel_telega.TabIndex = 26;
            this.linkLabel_telega.TabStop = true;
            this.linkLabel_telega.Text = "Есть вопросы, предложения, замечания?\r\nПишите в Телеграмм-канал \"Firehose - Finde" +
    "r issues\"";
            this.linkLabel_telega.UseCompatibleTextRendering = true;
            this.linkLabel_telega.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_telega_LinkClicked);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::FirehoseFinder.Properties.Resources.Fh_Image;
            this.logoPictureBox.Location = new System.Drawing.Point(4, 4);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 4);
            this.logoPictureBox.Size = new System.Drawing.Size(240, 167);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(256, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(493, 21);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Название продукта";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(256, 35);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(493, 21);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Версия";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(256, 70);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 21);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(493, 21);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Авторские права";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(649, 322);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 27);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&ОК";
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(256, 109);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(493, 62);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Описание";
            // 
            // linkLabel_forum
            // 
            this.linkLabel_forum.AutoSize = true;
            this.linkLabel_forum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel_forum.LinkArea = new System.Windows.Forms.LinkArea(14, 125);
            this.linkLabel_forum.Location = new System.Drawing.Point(251, 175);
            this.linkLabel_forum.Name = "linkLabel_forum";
            this.linkLabel_forum.Size = new System.Drawing.Size(499, 70);
            this.linkLabel_forum.TabIndex = 25;
            this.linkLabel_forum.TabStop = true;
            this.linkLabel_forum.Text = "Tема на 4PDA \"Общие принципы восстановления загрузчиков на Qualcomm | HS - USB QD" +
    "Loader 9008, HS - USB Diagnostics 9006, QHUSB_DLOAD и т.д.\"";
            this.linkLabel_forum.UseCompatibleTextRendering = true;
            this.linkLabel_forum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_forum_LinkClicked);
            // 
            // label_donate
            // 
            this.label_donate.AutoSize = true;
            this.label_donate.Location = new System.Drawing.Point(3, 175);
            this.label_donate.Name = "label_donate";
            this.label_donate.Size = new System.Drawing.Size(239, 68);
            this.label_donate.TabIndex = 27;
            this.label_donate.Text = "Возникло желание поблагодарить автора за проделанную работу? Пожалуйста, использу" +
    "йте кнопки ниже для пожертвования.";
            // 
            // button_donate_ymoney
            // 
            this.button_donate_ymoney.Location = new System.Drawing.Point(3, 248);
            this.button_donate_ymoney.Name = "button_donate_ymoney";
            this.button_donate_ymoney.Size = new System.Drawing.Size(224, 35);
            this.button_donate_ymoney.TabIndex = 28;
            this.button_donate_ymoney.Text = "ЮMoney - спасибо";
            this.button_donate_ymoney.UseVisualStyleBackColor = true;
            this.button_donate_ymoney.Click += new System.EventHandler(this.Button_donate_ymoney_Click);
            // 
            // button_donate_pp
            // 
            this.button_donate_pp.Location = new System.Drawing.Point(3, 318);
            this.button_donate_pp.Name = "button_donate_pp";
            this.button_donate_pp.Size = new System.Drawing.Size(224, 32);
            this.button_donate_pp.TabIndex = 29;
            this.button_donate_pp.Text = "QiWi - many thanks";
            this.button_donate_pp.UseVisualStyleBackColor = true;
            this.button_donate_pp.Click += new System.EventHandler(this.Button_donate_pp_Click);
            // 
            // AboutBox1
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 375);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox1";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.LinkLabel linkLabel_telega;
        private System.Windows.Forms.LinkLabel linkLabel_forum;
        private System.Windows.Forms.Label label_donate;
        private System.Windows.Forms.Button button_donate_ymoney;
        private System.Windows.Forms.Button button_donate_pp;
    }
}
