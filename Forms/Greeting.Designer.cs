
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Greeting));
            this.tableLayoutPanel_greeting = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_greeting = new System.Windows.Forms.TextBox();
            this.checkBox_start = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel_greeting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_greeting
            // 
            resources.ApplyResources(this.tableLayoutPanel_greeting, "tableLayoutPanel_greeting");
            this.tableLayoutPanel_greeting.Controls.Add(this.textBox_greeting, 0, 0);
            this.tableLayoutPanel_greeting.Controls.Add(this.checkBox_start, 0, 1);
            this.tableLayoutPanel_greeting.Controls.Add(this.button_ok, 1, 1);
            this.tableLayoutPanel_greeting.Name = "tableLayoutPanel_greeting";
            // 
            // textBox_greeting
            // 
            this.tableLayoutPanel_greeting.SetColumnSpan(this.textBox_greeting, 2);
            resources.ApplyResources(this.textBox_greeting, "textBox_greeting");
            this.textBox_greeting.Name = "textBox_greeting";
            this.textBox_greeting.ReadOnly = true;
            // 
            // checkBox_start
            // 
            resources.ApplyResources(this.checkBox_start, "checkBox_start");
            this.checkBox_start.Checked = global::FirehoseFinder.Properties.Settings.Default.CheckBox_start_Checked;
            this.checkBox_start.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_start.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FirehoseFinder.Properties.Settings.Default, "CheckBox_start_Checked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_start.Name = "checkBox_start";
            this.checkBox_start.UseVisualStyleBackColor = true;
            this.checkBox_start.CheckedChanged += new System.EventHandler(this.CheckBox_start_CheckedChanged);
            // 
            // button_ok
            // 
            resources.ApplyResources(this.button_ok, "button_ok");
            this.button_ok.Name = "button_ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // Greeting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_greeting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Greeting";
            this.ShowIcon = false;
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
        private System.Windows.Forms.TextBox textBox_greeting;
    }
}