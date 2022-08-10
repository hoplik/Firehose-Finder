namespace FirehoseFinder
{
    partial class RawProgramForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawProgramForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_comment = new System.Windows.Forms.Label();
            this.label_raw_patch = new System.Windows.Forms.Label();
            this.label_path = new System.Windows.Forms.Label();
            this.button_files = new System.Windows.Forms.Button();
            this.openFileDialog_xmlfiles = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.button_ok, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_cancel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_comment, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_raw_patch, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_path, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_files, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // button_ok
            // 
            resources.ApplyResources(this.button_ok, "button_ok");
            this.button_ok.Name = "button_ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // button_cancel
            // 
            resources.ApplyResources(this.button_cancel, "button_cancel");
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.Button_cancel_Click);
            // 
            // label_comment
            // 
            resources.ApplyResources(this.label_comment, "label_comment");
            this.tableLayoutPanel1.SetColumnSpan(this.label_comment, 3);
            this.label_comment.Name = "label_comment";
            // 
            // label_raw_patch
            // 
            resources.ApplyResources(this.label_raw_patch, "label_raw_patch");
            this.tableLayoutPanel1.SetColumnSpan(this.label_raw_patch, 3);
            this.label_raw_patch.Name = "label_raw_patch";
            this.label_raw_patch.TextChanged += new System.EventHandler(this.Label_raw_patch_TextChanged);
            // 
            // label_path
            // 
            resources.ApplyResources(this.label_path, "label_path");
            this.tableLayoutPanel1.SetColumnSpan(this.label_path, 3);
            this.label_path.Name = "label_path";
            // 
            // button_files
            // 
            resources.ApplyResources(this.button_files, "button_files");
            this.button_files.Name = "button_files";
            this.button_files.UseVisualStyleBackColor = true;
            this.button_files.Click += new System.EventHandler(this.Button_files_Click);
            // 
            // openFileDialog_xmlfiles
            // 
            this.openFileDialog_xmlfiles.DefaultExt = "xml";
            this.openFileDialog_xmlfiles.FileName = "rawprogram";
            resources.ApplyResources(this.openFileDialog_xmlfiles, "openFileDialog_xmlfiles");
            this.openFileDialog_xmlfiles.InitialDirectory = "Desktop";
            this.openFileDialog_xmlfiles.Multiselect = true;
            // 
            // RawProgramForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RawProgramForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_comment;
        internal System.Windows.Forms.Label label_raw_patch;
        internal System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_files;
        private System.Windows.Forms.OpenFileDialog openFileDialog_xmlfiles;
    }
}