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
        public ManagePartition()
        {
            InitializeComponent();
        }

        private void Button_MP_Cancel_Click(object sender, EventArgs e)
        {
            //Восстанавливаем значения по-умолчанию и скрываем форму
            Hide();
            label_MP_Part.Text = "***";
            toolStripStatusLabel_MP.Text = string.Empty;
            toolStripProgressBar_MP.Value = 0;
            checkBox_MP_Reboot.Checked = true;
            DialogResult = DialogResult.Cancel;
        }

        private void Button_MP_Save_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void Button_MP_Erase_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Abort;
        }

        private void Button_MP_Load_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Retry;
        }
    }
}
