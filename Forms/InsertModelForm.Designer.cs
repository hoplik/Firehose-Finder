
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
            resources.ApplyResources(this.comboBox_tm_insert, "comboBox_tm_insert");
            this.comboBox_tm_insert.Name = "comboBox_tm_insert";
            this.comboBox_tm_insert.Sorted = true;
            this.comboBox_tm_insert.TextChanged += new System.EventHandler(this.ComboBox_tm_insert_TextChanged);
            // 
            // label_tm_insert
            // 
            resources.ApplyResources(this.label_tm_insert, "label_tm_insert");
            this.label_tm_insert.Name = "label_tm_insert";
            // 
            // label_model_insert
            // 
            resources.ApplyResources(this.label_model_insert, "label_model_insert");
            this.label_model_insert.Name = "label_model_insert";
            // 
            // label_altname_insert
            // 
            resources.ApplyResources(this.label_altname_insert, "label_altname_insert");
            this.label_altname_insert.Name = "label_altname_insert";
            // 
            // textBox_alt_insert
            // 
            resources.ApplyResources(this.textBox_alt_insert, "textBox_alt_insert");
            this.textBox_alt_insert.Name = "textBox_alt_insert";
            this.textBox_alt_insert.TextChanged += new System.EventHandler(this.TextBox_alt_insert_TextChanged);
            // 
            // button_ok_insert
            // 
            resources.ApplyResources(this.button_ok_insert, "button_ok_insert");
            this.button_ok_insert.Name = "button_ok_insert";
            this.button_ok_insert.UseVisualStyleBackColor = true;
            this.button_ok_insert.Click += new System.EventHandler(this.Button_ok_insert_Click);
            // 
            // button_cancel_insert
            // 
            this.button_cancel_insert.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.button_cancel_insert, "button_cancel_insert");
            this.button_cancel_insert.Name = "button_cancel_insert";
            this.button_cancel_insert.UseVisualStyleBackColor = true;
            this.button_cancel_insert.Click += new System.EventHandler(this.Button_cancel_insert_Click);
            // 
            // textBox_model_insert
            // 
            resources.ApplyResources(this.textBox_model_insert, "textBox_model_insert");
            this.textBox_model_insert.Name = "textBox_model_insert";
            this.textBox_model_insert.TextChanged += new System.EventHandler(this.TextBox_model_insert_TextChanged);
            // 
            // InsertModelForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_model_insert);
            this.Controls.Add(this.button_cancel_insert);
            this.Controls.Add(this.button_ok_insert);
            this.Controls.Add(this.textBox_alt_insert);
            this.Controls.Add(this.label_altname_insert);
            this.Controls.Add(this.label_model_insert);
            this.Controls.Add(this.label_tm_insert);
            this.Controls.Add(this.comboBox_tm_insert);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertModelForm";
            this.Load += new System.EventHandler(this.InsertModelForm_Load);
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