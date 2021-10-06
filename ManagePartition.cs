using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class ManagePartition : Form
    {
        internal string part_str = "***"; //Выбранный для работы раздел

        public ManagePartition(Formfhf formfhf)
        {
            InitializeComponent();
            try
            {
                part_str = formfhf.listView_GPT.SelectedItems[0].SubItems[2].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            label_MP_Part.Text = part_str;
        }

        private void Button_MP_Cancel_Click(object sender, EventArgs e)
        {
            switch (button_MP_Cancel.Text)
            {
                case "Отмена":
                    //Восстанавливаем значения по-умолчанию и скрываем форму
                    label_MP_Part.Text = "***";
                    toolStripStatusLabel_MP.Text = string.Empty;
                    toolStripProgressBar_MP.Value = 0;
                    checkBox_MP_Reboot.Checked = true;
                    DialogResult = DialogResult.Cancel;
                    break;
                default:
                    break;
            }
            Hide();
        }

        private void Button_MP_Save_Click(object sender, EventArgs e)
        {
            button_MP_Cancel.Text = "Готово";
            DialogResult = DialogResult.OK;
        }

        private void Button_MP_Erase_Click(object sender, EventArgs e)
        {
            button_MP_Cancel.Text = "Готово";
            DialogResult = DialogResult.Abort;
        }

        private void Button_MP_Load_Click(object sender, EventArgs e)
        {
            button_MP_Cancel.Text = "Готово";
            DialogResult = DialogResult.Retry;
        }
    }
}
