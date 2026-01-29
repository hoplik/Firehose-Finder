namespace FirehoseFinder
{
    partial class SendProgForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendProgForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_send = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.dataGridView_shareprog = new System.Windows.Forms.DataGridView();
            this.Column_manuf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_altname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_dev_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_chipnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shareprog)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.button_send, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_cancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_shareprog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_title, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // button_send
            // 
            resources.ApplyResources(this.button_send, "button_send");
            this.button_send.Name = "button_send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.Button_send_Click);
            // 
            // button_cancel
            // 
            resources.ApplyResources(this.button_cancel, "button_cancel");
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.Button_cancel_Click);
            // 
            // dataGridView_shareprog
            // 
            this.dataGridView_shareprog.AllowUserToAddRows = false;
            this.dataGridView_shareprog.AllowUserToDeleteRows = false;
            this.dataGridView_shareprog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView_shareprog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_shareprog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_manuf,
            this.Column_model,
            this.Column_altname,
            this.Column_dev_num,
            this.Column_chipnum,
            this.Column_id,
            this.Column_path});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_shareprog, 3);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_shareprog.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridView_shareprog, "dataGridView_shareprog");
            this.dataGridView_shareprog.MultiSelect = false;
            this.dataGridView_shareprog.Name = "dataGridView_shareprog";
            this.dataGridView_shareprog.ReadOnly = true;
            this.dataGridView_shareprog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_shareprog.RowTemplate.Height = 24;
            // 
            // Column_manuf
            // 
            resources.ApplyResources(this.Column_manuf, "Column_manuf");
            this.Column_manuf.Name = "Column_manuf";
            this.Column_manuf.ReadOnly = true;
            // 
            // Column_model
            // 
            resources.ApplyResources(this.Column_model, "Column_model");
            this.Column_model.Name = "Column_model";
            this.Column_model.ReadOnly = true;
            // 
            // Column_altname
            // 
            resources.ApplyResources(this.Column_altname, "Column_altname");
            this.Column_altname.Name = "Column_altname";
            this.Column_altname.ReadOnly = true;
            // 
            // Column_dev_num
            // 
            resources.ApplyResources(this.Column_dev_num, "Column_dev_num");
            this.Column_dev_num.Name = "Column_dev_num";
            this.Column_dev_num.ReadOnly = true;
            // 
            // Column_chipnum
            // 
            resources.ApplyResources(this.Column_chipnum, "Column_chipnum");
            this.Column_chipnum.Name = "Column_chipnum";
            this.Column_chipnum.ReadOnly = true;
            // 
            // Column_id
            // 
            resources.ApplyResources(this.Column_id, "Column_id");
            this.Column_id.Name = "Column_id";
            this.Column_id.ReadOnly = true;
            // 
            // Column_path
            // 
            resources.ApplyResources(this.Column_path, "Column_path");
            this.Column_path.Name = "Column_path";
            this.Column_path.ReadOnly = true;
            // 
            // label_title
            // 
            resources.ApplyResources(this.label_title, "label_title");
            this.tableLayoutPanel1.SetColumnSpan(this.label_title, 3);
            this.label_title.Name = "label_title";
            // 
            // SendProgForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendProgForm";
            this.Load += new System.EventHandler(this.SendProgForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shareprog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_cancel;
        internal System.Windows.Forms.DataGridView dataGridView_shareprog;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_manuf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_altname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_dev_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_chipnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_path;
    }
}