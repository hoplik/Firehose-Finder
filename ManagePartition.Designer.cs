
namespace FirehoseFinder
{
    partial class ManagePartition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePartition));
            this.tableLayoutPanel_MP = new System.Windows.Forms.TableLayoutPanel();
            this.label_MP_Titul = new System.Windows.Forms.Label();
            this.button_MP_Save = new System.Windows.Forms.Button();
            this.button_MP_Erase = new System.Windows.Forms.Button();
            this.button_MP_Load = new System.Windows.Forms.Button();
            this.button_MP_Cancel = new System.Windows.Forms.Button();
            this.checkBox_MP_Reboot = new System.Windows.Forms.CheckBox();
            this.label_MP_Part = new System.Windows.Forms.Label();
            this.label_MP_Comments = new System.Windows.Forms.Label();
            this.tableLayoutPanel_MP.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_MP
            // 
            this.tableLayoutPanel_MP.ColumnCount = 4;
            this.tableLayoutPanel_MP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_MP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_MP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_MP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_MP.Controls.Add(this.label_MP_Titul, 0, 0);
            this.tableLayoutPanel_MP.Controls.Add(this.button_MP_Save, 0, 3);
            this.tableLayoutPanel_MP.Controls.Add(this.button_MP_Erase, 1, 3);
            this.tableLayoutPanel_MP.Controls.Add(this.button_MP_Load, 2, 3);
            this.tableLayoutPanel_MP.Controls.Add(this.button_MP_Cancel, 3, 3);
            this.tableLayoutPanel_MP.Controls.Add(this.checkBox_MP_Reboot, 0, 4);
            this.tableLayoutPanel_MP.Controls.Add(this.label_MP_Part, 3, 0);
            this.tableLayoutPanel_MP.Controls.Add(this.label_MP_Comments, 0, 1);
            this.tableLayoutPanel_MP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_MP.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_MP.Name = "tableLayoutPanel_MP";
            this.tableLayoutPanel_MP.RowCount = 5;
            this.tableLayoutPanel_MP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_MP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_MP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_MP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_MP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel_MP.Size = new System.Drawing.Size(1033, 471);
            this.tableLayoutPanel_MP.TabIndex = 0;
            // 
            // label_MP_Titul
            // 
            this.label_MP_Titul.AutoSize = true;
            this.tableLayoutPanel_MP.SetColumnSpan(this.label_MP_Titul, 3);
            this.label_MP_Titul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MP_Titul.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MP_Titul.Location = new System.Drawing.Point(3, 0);
            this.label_MP_Titul.Name = "label_MP_Titul";
            this.label_MP_Titul.Size = new System.Drawing.Size(768, 40);
            this.label_MP_Titul.TabIndex = 4;
            this.label_MP_Titul.Text = "Внимание! Сейчас проводится работа с разделом -";
            // 
            // button_MP_Save
            // 
            this.button_MP_Save.BackColor = System.Drawing.Color.GreenYellow;
            this.button_MP_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_MP_Save.Location = new System.Drawing.Point(3, 403);
            this.button_MP_Save.Name = "button_MP_Save";
            this.button_MP_Save.Size = new System.Drawing.Size(252, 29);
            this.button_MP_Save.TabIndex = 0;
            this.button_MP_Save.Text = "Сохранить раздел";
            this.button_MP_Save.UseVisualStyleBackColor = false;
            this.button_MP_Save.Click += new System.EventHandler(this.Button_MP_Save_Click);
            // 
            // button_MP_Erase
            // 
            this.button_MP_Erase.BackColor = System.Drawing.Color.Red;
            this.button_MP_Erase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_MP_Erase.Location = new System.Drawing.Point(261, 403);
            this.button_MP_Erase.Name = "button_MP_Erase";
            this.button_MP_Erase.Size = new System.Drawing.Size(252, 29);
            this.button_MP_Erase.TabIndex = 1;
            this.button_MP_Erase.Text = "Стереть раздел";
            this.button_MP_Erase.UseVisualStyleBackColor = false;
            this.button_MP_Erase.Click += new System.EventHandler(this.Button_MP_Erase_Click);
            // 
            // button_MP_Load
            // 
            this.button_MP_Load.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_MP_Load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_MP_Load.Location = new System.Drawing.Point(519, 403);
            this.button_MP_Load.Name = "button_MP_Load";
            this.button_MP_Load.Size = new System.Drawing.Size(252, 29);
            this.button_MP_Load.TabIndex = 2;
            this.button_MP_Load.Text = "Записать из файла";
            this.button_MP_Load.UseVisualStyleBackColor = false;
            this.button_MP_Load.Click += new System.EventHandler(this.Button_MP_Load_Click);
            // 
            // button_MP_Cancel
            // 
            this.button_MP_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_MP_Cancel.Location = new System.Drawing.Point(777, 403);
            this.button_MP_Cancel.Name = "button_MP_Cancel";
            this.button_MP_Cancel.Size = new System.Drawing.Size(253, 29);
            this.button_MP_Cancel.TabIndex = 3;
            this.button_MP_Cancel.Text = "Отмена";
            this.button_MP_Cancel.UseVisualStyleBackColor = true;
            this.button_MP_Cancel.Click += new System.EventHandler(this.Button_MP_Cancel_Click);
            // 
            // checkBox_MP_Reboot
            // 
            this.checkBox_MP_Reboot.AutoSize = true;
            this.checkBox_MP_Reboot.Checked = true;
            this.checkBox_MP_Reboot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel_MP.SetColumnSpan(this.checkBox_MP_Reboot, 4);
            this.checkBox_MP_Reboot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_MP_Reboot.Location = new System.Drawing.Point(3, 438);
            this.checkBox_MP_Reboot.Name = "checkBox_MP_Reboot";
            this.checkBox_MP_Reboot.Size = new System.Drawing.Size(1027, 30);
            this.checkBox_MP_Reboot.TabIndex = 5;
            this.checkBox_MP_Reboot.Text = "После завершения операций  и нажатия кнопки \"Готово\" перегрузить устройство в нор" +
    "мальный режим";
            this.checkBox_MP_Reboot.UseVisualStyleBackColor = true;
            // 
            // label_MP_Part
            // 
            this.label_MP_Part.AutoSize = true;
            this.label_MP_Part.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_MP_Part.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MP_Part.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MP_Part.Location = new System.Drawing.Point(777, 0);
            this.label_MP_Part.Name = "label_MP_Part";
            this.label_MP_Part.Size = new System.Drawing.Size(253, 40);
            this.label_MP_Part.TabIndex = 6;
            this.label_MP_Part.Text = "***";
            // 
            // label_MP_Comments
            // 
            this.label_MP_Comments.AutoSize = true;
            this.tableLayoutPanel_MP.SetColumnSpan(this.label_MP_Comments, 4);
            this.label_MP_Comments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_MP_Comments.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_MP_Comments.Location = new System.Drawing.Point(3, 40);
            this.label_MP_Comments.Name = "label_MP_Comments";
            this.label_MP_Comments.Size = new System.Drawing.Size(1027, 180);
            this.label_MP_Comments.TabIndex = 7;
            this.label_MP_Comments.Text = resources.GetString("label_MP_Comments.Text");
            // 
            // ManagePartition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 471);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_MP);
            this.Name = "ManagePartition";
            this.Text = "Управление разделом";
            this.tableLayoutPanel_MP.ResumeLayout(false);
            this.tableLayoutPanel_MP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_MP;
        private System.Windows.Forms.Button button_MP_Erase;
        private System.Windows.Forms.Button button_MP_Save;
        private System.Windows.Forms.Button button_MP_Load;
        private System.Windows.Forms.Label label_MP_Titul;
        private System.Windows.Forms.Label label_MP_Comments;
        internal System.Windows.Forms.Button button_MP_Cancel;
        internal System.Windows.Forms.CheckBox checkBox_MP_Reboot;
        internal System.Windows.Forms.Label label_MP_Part;
    }
}