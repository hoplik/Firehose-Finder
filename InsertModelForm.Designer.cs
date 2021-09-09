
namespace FirehoseFinder
{
    partial class InsertModelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertModelForm));
            this.comboBox_tm_insert = new System.Windows.Forms.ComboBox();
            this.label_tm_insert = new System.Windows.Forms.Label();
            this.label_model_insert = new System.Windows.Forms.Label();
            this.label_altname_insert = new System.Windows.Forms.Label();
            this.textBox_alt_insert = new System.Windows.Forms.TextBox();
            this.button_ok_insert = new System.Windows.Forms.Button();
            this.button_cancel_insert = new System.Windows.Forms.Button();
            this.textBox_model_insert = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_tm_insert
            // 
            this.comboBox_tm_insert.FormattingEnabled = true;
            this.comboBox_tm_insert.Items.AddRange(new object[] {
            "Acer",
            "AGM",
            "Alcatel",
            "Ark",
            "Artel",
            "ASUS",
            "BenQ",
            "Bluebird",
            "BQ",
            "Caterpillar",
            "Coolpad",
            "Dexp",
            "Discovery",
            "Essential Phone",
            "Foxda",
            "General Mobile",
            "Gionee",
            "Google",
            "Highscreen",
            "Hisense",
            "Honeywell",
            "HP",
            "HTC",
            "Huawei",
            "Hytera",
            "Kyocera",
            "LeEco",
            "LENOVO",
            "LG",
            "Meizu",
            "Micromax",
            "MOQI",
            "Motorola",
            "Nextbit",
            "Nexus",
            "Nokia",
            "OnePlus",
            "OPPO",
            "Phicomm",
            "Prestigio",
            "Protruly",
            "Razer",
            "Realme",
            "RED",
            "Samsung",
            "Santin",
            "Sharp",
            "Smartisan",
            "SONY",
            "Stream",
            "TCL",
            "Tplink",
            "UNIPRO",
            "UniStrong",
            "Vertex",
            "vivo",
            "vsmart",
            "Wileyfox",
            "Xiaomi",
            "Yandex",
            "Yota Devices Limited",
            "ZTE",
            "ZUK",
            "Билайн",
            "Мегафон"});
            this.comboBox_tm_insert.Location = new System.Drawing.Point(136, 12);
            this.comboBox_tm_insert.Name = "comboBox_tm_insert";
            this.comboBox_tm_insert.Size = new System.Drawing.Size(179, 24);
            this.comboBox_tm_insert.TabIndex = 0;
            this.comboBox_tm_insert.TextChanged += new System.EventHandler(this.ComboBox_tm_insert_TextChanged);
            // 
            // label_tm_insert
            // 
            this.label_tm_insert.AutoSize = true;
            this.label_tm_insert.Location = new System.Drawing.Point(13, 12);
            this.label_tm_insert.Name = "label_tm_insert";
            this.label_tm_insert.Size = new System.Drawing.Size(119, 17);
            this.label_tm_insert.TabIndex = 3;
            this.label_tm_insert.Text = "Производитель *";
            // 
            // label_model_insert
            // 
            this.label_model_insert.AutoSize = true;
            this.label_model_insert.Location = new System.Drawing.Point(13, 42);
            this.label_model_insert.Name = "label_model_insert";
            this.label_model_insert.Size = new System.Drawing.Size(58, 17);
            this.label_model_insert.TabIndex = 4;
            this.label_model_insert.Text = "Модель";
            // 
            // label_altname_insert
            // 
            this.label_altname_insert.AutoSize = true;
            this.label_altname_insert.Location = new System.Drawing.Point(13, 72);
            this.label_altname_insert.Name = "label_altname_insert";
            this.label_altname_insert.Size = new System.Drawing.Size(117, 34);
            this.label_altname_insert.TabIndex = 5;
            this.label_altname_insert.Text = "Альтернативное\r\nнаименование";
            // 
            // textBox_alt_insert
            // 
            this.textBox_alt_insert.Location = new System.Drawing.Point(136, 72);
            this.textBox_alt_insert.Name = "textBox_alt_insert";
            this.textBox_alt_insert.Size = new System.Drawing.Size(179, 22);
            this.textBox_alt_insert.TabIndex = 6;
            this.textBox_alt_insert.TextChanged += new System.EventHandler(this.TextBox_alt_insert_TextChanged);
            // 
            // button_ok_insert
            // 
            this.button_ok_insert.Location = new System.Drawing.Point(16, 118);
            this.button_ok_insert.Name = "button_ok_insert";
            this.button_ok_insert.Size = new System.Drawing.Size(75, 23);
            this.button_ok_insert.TabIndex = 7;
            this.button_ok_insert.Text = "ОК";
            this.button_ok_insert.UseVisualStyleBackColor = true;
            this.button_ok_insert.Click += new System.EventHandler(this.Button_ok_insert_Click);
            // 
            // button_cancel_insert
            // 
            this.button_cancel_insert.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel_insert.Location = new System.Drawing.Point(240, 118);
            this.button_cancel_insert.Name = "button_cancel_insert";
            this.button_cancel_insert.Size = new System.Drawing.Size(75, 23);
            this.button_cancel_insert.TabIndex = 8;
            this.button_cancel_insert.Text = "Отмена";
            this.button_cancel_insert.UseVisualStyleBackColor = true;
            this.button_cancel_insert.Click += new System.EventHandler(this.Button_cancel_insert_Click);
            // 
            // textBox_model_insert
            // 
            this.textBox_model_insert.Location = new System.Drawing.Point(136, 42);
            this.textBox_model_insert.Name = "textBox_model_insert";
            this.textBox_model_insert.Size = new System.Drawing.Size(179, 22);
            this.textBox_model_insert.TabIndex = 9;
            this.textBox_model_insert.TextChanged += new System.EventHandler(this.TextBox_model_insert_TextChanged);
            // 
            // InsertModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 153);
            this.Controls.Add(this.textBox_model_insert);
            this.Controls.Add(this.button_cancel_insert);
            this.Controls.Add(this.button_ok_insert);
            this.Controls.Add(this.textBox_alt_insert);
            this.Controls.Add(this.label_altname_insert);
            this.Controls.Add(this.label_model_insert);
            this.Controls.Add(this.label_tm_insert);
            this.Controls.Add(this.comboBox_tm_insert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertModelForm";
            this.Text = "Внесение модели устройства";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_tm_insert;
        private System.Windows.Forms.Label label_model_insert;
        private System.Windows.Forms.Label label_altname_insert;
        private System.Windows.Forms.Button button_ok_insert;
        private System.Windows.Forms.Button button_cancel_insert;
        internal System.Windows.Forms.ComboBox comboBox_tm_insert;
        internal System.Windows.Forms.TextBox textBox_alt_insert;
        internal System.Windows.Forms.TextBox textBox_model_insert;
    }
}