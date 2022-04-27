
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Peekpoke));
            this.tableLayoutPanel_PP = new System.Windows.Forms.TableLayoutPanel();
            this.button_pp_ok = new System.Windows.Forms.Button();
            this.button_pp_cancel = new System.Windows.Forms.Button();
            this.groupBox_peek = new System.Windows.Forms.GroupBox();
            this.groupBox_output = new System.Windows.Forms.GroupBox();
            this.checkBox_output = new System.Windows.Forms.CheckBox();
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
            this.panel_pp_select = new System.Windows.Forms.Panel();
            this.radioButton_poke = new System.Windows.Forms.RadioButton();
            this.radioButton_peek = new System.Windows.Forms.RadioButton();
            this.groupBox_fh_aarch = new System.Windows.Forms.GroupBox();
            this.radioButton_aarch64 = new System.Windows.Forms.RadioButton();
            this.radioButton_aarch32 = new System.Windows.Forms.RadioButton();
            this.toolTip_pp = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog_output = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel_PP.SuspendLayout();
            this.groupBox_peek.SuspendLayout();
            this.groupBox_output.SuspendLayout();
            this.groupBox_poke.SuspendLayout();
            this.panel_pp_select.SuspendLayout();
            this.groupBox_fh_aarch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_PP
            // 
            resources.ApplyResources(this.tableLayoutPanel_PP, "tableLayoutPanel_PP");
            this.tableLayoutPanel_PP.Controls.Add(this.button_pp_ok, 0, 3);
            this.tableLayoutPanel_PP.Controls.Add(this.button_pp_cancel, 1, 3);
            this.tableLayoutPanel_PP.Controls.Add(this.groupBox_peek, 0, 2);
            this.tableLayoutPanel_PP.Controls.Add(this.groupBox_poke, 1, 2);
            this.tableLayoutPanel_PP.Controls.Add(this.panel_pp_select, 0, 1);
            this.tableLayoutPanel_PP.Controls.Add(this.groupBox_fh_aarch, 0, 0);
            this.tableLayoutPanel_PP.Name = "tableLayoutPanel_PP";
            this.toolTip_pp.SetToolTip(this.tableLayoutPanel_PP, resources.GetString("tableLayoutPanel_PP.ToolTip"));
            // 
            // button_pp_ok
            // 
            resources.ApplyResources(this.button_pp_ok, "button_pp_ok");
            this.button_pp_ok.Name = "button_pp_ok";
            this.toolTip_pp.SetToolTip(this.button_pp_ok, resources.GetString("button_pp_ok.ToolTip"));
            this.button_pp_ok.UseVisualStyleBackColor = true;
            this.button_pp_ok.Click += new System.EventHandler(this.Button_pp_ok_Click);
            // 
            // button_pp_cancel
            // 
            resources.ApplyResources(this.button_pp_cancel, "button_pp_cancel");
            this.button_pp_cancel.Name = "button_pp_cancel";
            this.toolTip_pp.SetToolTip(this.button_pp_cancel, resources.GetString("button_pp_cancel.ToolTip"));
            this.button_pp_cancel.UseVisualStyleBackColor = true;
            this.button_pp_cancel.Click += new System.EventHandler(this.Button_pp_cancel_Click);
            // 
            // groupBox_peek
            // 
            resources.ApplyResources(this.groupBox_peek, "groupBox_peek");
            this.groupBox_peek.Controls.Add(this.groupBox_output);
            this.groupBox_peek.Controls.Add(this.textBox_peek_cb);
            this.groupBox_peek.Controls.Add(this.textBox_peek_adr);
            this.groupBox_peek.Controls.Add(this.label_peek_cb);
            this.groupBox_peek.Controls.Add(this.label_peek_adr);
            this.groupBox_peek.Name = "groupBox_peek";
            this.groupBox_peek.TabStop = false;
            this.toolTip_pp.SetToolTip(this.groupBox_peek, resources.GetString("groupBox_peek.ToolTip"));
            // 
            // groupBox_output
            // 
            resources.ApplyResources(this.groupBox_output, "groupBox_output");
            this.groupBox_output.Controls.Add(this.checkBox_output);
            this.groupBox_output.Name = "groupBox_output";
            this.groupBox_output.TabStop = false;
            this.toolTip_pp.SetToolTip(this.groupBox_output, resources.GetString("groupBox_output.ToolTip"));
            // 
            // checkBox_output
            // 
            resources.ApplyResources(this.checkBox_output, "checkBox_output");
            this.checkBox_output.Name = "checkBox_output";
            this.toolTip_pp.SetToolTip(this.checkBox_output, resources.GetString("checkBox_output.ToolTip"));
            this.checkBox_output.UseVisualStyleBackColor = true;
            this.checkBox_output.CheckedChanged += new System.EventHandler(this.CheckBox_output_CheckedChanged);
            // 
            // textBox_peek_cb
            // 
            resources.ApplyResources(this.textBox_peek_cb, "textBox_peek_cb");
            this.textBox_peek_cb.Name = "textBox_peek_cb";
            this.toolTip_pp.SetToolTip(this.textBox_peek_cb, resources.GetString("textBox_peek_cb.ToolTip"));
            this.textBox_peek_cb.TextChanged += new System.EventHandler(this.TextBox_peek_cb_TextChanged);
            // 
            // textBox_peek_adr
            // 
            resources.ApplyResources(this.textBox_peek_adr, "textBox_peek_adr");
            this.textBox_peek_adr.Name = "textBox_peek_adr";
            this.toolTip_pp.SetToolTip(this.textBox_peek_adr, resources.GetString("textBox_peek_adr.ToolTip"));
            this.textBox_peek_adr.TextChanged += new System.EventHandler(this.TextBox_peek_adr_TextChanged);
            // 
            // label_peek_cb
            // 
            resources.ApplyResources(this.label_peek_cb, "label_peek_cb");
            this.label_peek_cb.Name = "label_peek_cb";
            this.toolTip_pp.SetToolTip(this.label_peek_cb, resources.GetString("label_peek_cb.ToolTip"));
            // 
            // label_peek_adr
            // 
            resources.ApplyResources(this.label_peek_adr, "label_peek_adr");
            this.label_peek_adr.Name = "label_peek_adr";
            this.toolTip_pp.SetToolTip(this.label_peek_adr, resources.GetString("label_peek_adr.ToolTip"));
            // 
            // groupBox_poke
            // 
            resources.ApplyResources(this.groupBox_poke, "groupBox_poke");
            this.groupBox_poke.Controls.Add(this.label_poke_cbytes);
            this.groupBox_poke.Controls.Add(this.label_poke_cb);
            this.groupBox_poke.Controls.Add(this.textBox_poke_bytes);
            this.groupBox_poke.Controls.Add(this.textBox_poke_adr);
            this.groupBox_poke.Controls.Add(this.label_poke_bytes);
            this.groupBox_poke.Controls.Add(this.label_poke_adr);
            this.groupBox_poke.Name = "groupBox_poke";
            this.groupBox_poke.TabStop = false;
            this.toolTip_pp.SetToolTip(this.groupBox_poke, resources.GetString("groupBox_poke.ToolTip"));
            // 
            // label_poke_cbytes
            // 
            resources.ApplyResources(this.label_poke_cbytes, "label_poke_cbytes");
            this.label_poke_cbytes.Name = "label_poke_cbytes";
            this.toolTip_pp.SetToolTip(this.label_poke_cbytes, resources.GetString("label_poke_cbytes.ToolTip"));
            // 
            // label_poke_cb
            // 
            resources.ApplyResources(this.label_poke_cb, "label_poke_cb");
            this.label_poke_cb.Name = "label_poke_cb";
            this.toolTip_pp.SetToolTip(this.label_poke_cb, resources.GetString("label_poke_cb.ToolTip"));
            // 
            // textBox_poke_bytes
            // 
            resources.ApplyResources(this.textBox_poke_bytes, "textBox_poke_bytes");
            this.textBox_poke_bytes.Name = "textBox_poke_bytes";
            this.toolTip_pp.SetToolTip(this.textBox_poke_bytes, resources.GetString("textBox_poke_bytes.ToolTip"));
            this.textBox_poke_bytes.TextChanged += new System.EventHandler(this.TextBox_poke_bytes_TextChanged);
            this.textBox_poke_bytes.Leave += new System.EventHandler(this.TextBox_poke_bytes_Leave);
            // 
            // textBox_poke_adr
            // 
            resources.ApplyResources(this.textBox_poke_adr, "textBox_poke_adr");
            this.textBox_poke_adr.Name = "textBox_poke_adr";
            this.toolTip_pp.SetToolTip(this.textBox_poke_adr, resources.GetString("textBox_poke_adr.ToolTip"));
            this.textBox_poke_adr.TextChanged += new System.EventHandler(this.TextBox_poke_adr_TextChanged);
            // 
            // label_poke_bytes
            // 
            resources.ApplyResources(this.label_poke_bytes, "label_poke_bytes");
            this.label_poke_bytes.Name = "label_poke_bytes";
            this.toolTip_pp.SetToolTip(this.label_poke_bytes, resources.GetString("label_poke_bytes.ToolTip"));
            // 
            // label_poke_adr
            // 
            resources.ApplyResources(this.label_poke_adr, "label_poke_adr");
            this.label_poke_adr.Name = "label_poke_adr";
            this.toolTip_pp.SetToolTip(this.label_poke_adr, resources.GetString("label_poke_adr.ToolTip"));
            // 
            // panel_pp_select
            // 
            resources.ApplyResources(this.panel_pp_select, "panel_pp_select");
            this.tableLayoutPanel_PP.SetColumnSpan(this.panel_pp_select, 2);
            this.panel_pp_select.Controls.Add(this.radioButton_poke);
            this.panel_pp_select.Controls.Add(this.radioButton_peek);
            this.panel_pp_select.Name = "panel_pp_select";
            this.toolTip_pp.SetToolTip(this.panel_pp_select, resources.GetString("panel_pp_select.ToolTip"));
            // 
            // radioButton_poke
            // 
            resources.ApplyResources(this.radioButton_poke, "radioButton_poke");
            this.radioButton_poke.BackColor = System.Drawing.Color.Red;
            this.radioButton_poke.Name = "radioButton_poke";
            this.toolTip_pp.SetToolTip(this.radioButton_poke, resources.GetString("radioButton_poke.ToolTip"));
            this.radioButton_poke.UseVisualStyleBackColor = false;
            this.radioButton_poke.CheckedChanged += new System.EventHandler(this.RadioButton_poke_CheckedChanged);
            // 
            // radioButton_peek
            // 
            resources.ApplyResources(this.radioButton_peek, "radioButton_peek");
            this.radioButton_peek.BackColor = System.Drawing.Color.GreenYellow;
            this.radioButton_peek.Checked = true;
            this.radioButton_peek.Name = "radioButton_peek";
            this.radioButton_peek.TabStop = true;
            this.toolTip_pp.SetToolTip(this.radioButton_peek, resources.GetString("radioButton_peek.ToolTip"));
            this.radioButton_peek.UseVisualStyleBackColor = false;
            this.radioButton_peek.CheckedChanged += new System.EventHandler(this.RadioButton_peek_CheckedChanged);
            // 
            // groupBox_fh_aarch
            // 
            resources.ApplyResources(this.groupBox_fh_aarch, "groupBox_fh_aarch");
            this.tableLayoutPanel_PP.SetColumnSpan(this.groupBox_fh_aarch, 2);
            this.groupBox_fh_aarch.Controls.Add(this.radioButton_aarch64);
            this.groupBox_fh_aarch.Controls.Add(this.radioButton_aarch32);
            this.groupBox_fh_aarch.Name = "groupBox_fh_aarch";
            this.groupBox_fh_aarch.TabStop = false;
            this.toolTip_pp.SetToolTip(this.groupBox_fh_aarch, resources.GetString("groupBox_fh_aarch.ToolTip"));
            // 
            // radioButton_aarch64
            // 
            resources.ApplyResources(this.radioButton_aarch64, "radioButton_aarch64");
            this.radioButton_aarch64.Name = "radioButton_aarch64";
            this.toolTip_pp.SetToolTip(this.radioButton_aarch64, resources.GetString("radioButton_aarch64.ToolTip"));
            this.radioButton_aarch64.UseVisualStyleBackColor = true;
            // 
            // radioButton_aarch32
            // 
            resources.ApplyResources(this.radioButton_aarch32, "radioButton_aarch32");
            this.radioButton_aarch32.Checked = true;
            this.radioButton_aarch32.Name = "radioButton_aarch32";
            this.radioButton_aarch32.TabStop = true;
            this.toolTip_pp.SetToolTip(this.radioButton_aarch32, resources.GetString("radioButton_aarch32.ToolTip"));
            this.radioButton_aarch32.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog_output
            // 
            this.saveFileDialog_output.DefaultExt = "bin";
            this.saveFileDialog_output.FileName = "peek.bin";
            resources.ApplyResources(this.saveFileDialog_output, "saveFileDialog_output");
            // 
            // Peekpoke
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_PP);
            this.Name = "Peekpoke";
            this.toolTip_pp.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.Peekpoke_Load);
            this.tableLayoutPanel_PP.ResumeLayout(false);
            this.groupBox_peek.ResumeLayout(false);
            this.groupBox_peek.PerformLayout();
            this.groupBox_output.ResumeLayout(false);
            this.groupBox_output.PerformLayout();
            this.groupBox_poke.ResumeLayout(false);
            this.groupBox_poke.PerformLayout();
            this.panel_pp_select.ResumeLayout(false);
            this.panel_pp_select.PerformLayout();
            this.groupBox_fh_aarch.ResumeLayout(false);
            this.groupBox_fh_aarch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_PP;
        private System.Windows.Forms.Button button_pp_ok;
        private System.Windows.Forms.Button button_pp_cancel;
        private System.Windows.Forms.Panel panel_pp_select;
        private System.Windows.Forms.RadioButton radioButton_poke;
        private System.Windows.Forms.GroupBox groupBox_peek;
        private System.Windows.Forms.GroupBox groupBox_poke;
        private System.Windows.Forms.Label label_peek_cb;
        private System.Windows.Forms.Label label_peek_adr;
        private System.Windows.Forms.TextBox textBox_peek_adr;
        private System.Windows.Forms.Label label_poke_cbytes;
        private System.Windows.Forms.Label label_poke_cb;
        private System.Windows.Forms.TextBox textBox_poke_bytes;
        private System.Windows.Forms.TextBox textBox_poke_adr;
        private System.Windows.Forms.Label label_poke_bytes;
        private System.Windows.Forms.Label label_poke_adr;
        internal System.Windows.Forms.RadioButton radioButton_peek;
        private System.Windows.Forms.GroupBox groupBox_fh_aarch;
        private System.Windows.Forms.RadioButton radioButton_aarch64;
        private System.Windows.Forms.RadioButton radioButton_aarch32;
        private System.Windows.Forms.ToolTip toolTip_pp;
        private System.Windows.Forms.GroupBox groupBox_output;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_output;
        internal System.Windows.Forms.CheckBox checkBox_output;
        internal System.Windows.Forms.TextBox textBox_peek_cb;
    }
}