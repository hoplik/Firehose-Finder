
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox1));
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
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
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
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // linkLabel_telega
            // 
            resources.ApplyResources(this.linkLabel_telega, "linkLabel_telega");
            this.linkLabel_telega.Name = "linkLabel_telega";
            this.linkLabel_telega.TabStop = true;
            this.linkLabel_telega.UseCompatibleTextRendering = true;
            this.linkLabel_telega.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_telega_LinkClicked);
            // 
            // logoPictureBox
            // 
            resources.ApplyResources(this.logoPictureBox, "logoPictureBox");
            this.logoPictureBox.Image = global::FirehoseFinder.Properties.Resources.Fh_Image;
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 4);
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.Click += new System.EventHandler(this.logoPictureBox_Click);
            // 
            // labelProductName
            // 
            resources.ApplyResources(this.labelProductName, "labelProductName");
            this.labelProductName.Name = "labelProductName";
            // 
            // labelVersion
            // 
            resources.ApplyResources(this.labelVersion, "labelVersion");
            this.labelVersion.Name = "labelVersion";
            // 
            // labelCopyright
            // 
            resources.ApplyResources(this.labelCopyright, "labelCopyright");
            this.labelCopyright.Name = "labelCopyright";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.TabStop = false;
            // 
            // linkLabel_forum
            // 
            resources.ApplyResources(this.linkLabel_forum, "linkLabel_forum");
            this.linkLabel_forum.Name = "linkLabel_forum";
            this.linkLabel_forum.TabStop = true;
            this.linkLabel_forum.UseCompatibleTextRendering = true;
            this.linkLabel_forum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_forum_LinkClicked);
            // 
            // label_donate
            // 
            resources.ApplyResources(this.label_donate, "label_donate");
            this.label_donate.Name = "label_donate";
            // 
            // button_donate_ymoney
            // 
            resources.ApplyResources(this.button_donate_ymoney, "button_donate_ymoney");
            this.button_donate_ymoney.Name = "button_donate_ymoney";
            this.button_donate_ymoney.UseVisualStyleBackColor = true;
            this.button_donate_ymoney.Click += new System.EventHandler(this.Button_donate_ymoney_Click);
            // 
            // button_donate_pp
            // 
            resources.ApplyResources(this.button_donate_pp, "button_donate_pp");
            this.button_donate_pp.Name = "button_donate_pp";
            this.button_donate_pp.UseVisualStyleBackColor = true;
            this.button_donate_pp.Click += new System.EventHandler(this.Button_donate_pp_Click);
            // 
            // AboutBox1
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
