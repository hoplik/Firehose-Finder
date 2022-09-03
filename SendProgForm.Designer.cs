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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_send = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.dataGridView_shareprog = new System.Windows.Forms.DataGridView();
            this.Column_cat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_adb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sahara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_loader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_prog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shareprog)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.button_send, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_cancel, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_shareprog, 0, 1);
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
            this.dataGridView_shareprog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_shareprog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_cat,
            this.Column_adb,
            this.Column_sahara,
            this.Column_loader,
            this.Column_prog});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView_shareprog, 5);
            resources.ApplyResources(this.dataGridView_shareprog, "dataGridView_shareprog");
            this.dataGridView_shareprog.MultiSelect = false;
            this.dataGridView_shareprog.Name = "dataGridView_shareprog";
            this.dataGridView_shareprog.ReadOnly = true;
            this.dataGridView_shareprog.RowHeadersVisible = false;
            this.dataGridView_shareprog.RowTemplate.Height = 24;
            this.dataGridView_shareprog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // Column_cat
            // 
            resources.ApplyResources(this.Column_cat, "Column_cat");
            this.Column_cat.Name = "Column_cat";
            this.Column_cat.ReadOnly = true;
            // 
            // Column_adb
            // 
            resources.ApplyResources(this.Column_adb, "Column_adb");
            this.Column_adb.Name = "Column_adb";
            this.Column_adb.ReadOnly = true;
            // 
            // Column_sahara
            // 
            resources.ApplyResources(this.Column_sahara, "Column_sahara");
            this.Column_sahara.Name = "Column_sahara";
            this.Column_sahara.ReadOnly = true;
            // 
            // Column_loader
            // 
            resources.ApplyResources(this.Column_loader, "Column_loader");
            this.Column_loader.Name = "Column_loader";
            this.Column_loader.ReadOnly = true;
            // 
            // Column_prog
            // 
            resources.ApplyResources(this.Column_prog, "Column_prog");
            this.Column_prog.Name = "Column_prog";
            this.Column_prog.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_shareprog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_cancel;
        internal System.Windows.Forms.DataGridView dataGridView_shareprog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_cat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_adb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sahara;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_loader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_prog;
    }
}