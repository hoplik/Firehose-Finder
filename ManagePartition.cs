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
        public ManagePartition(Formfhf formfhf)
        {
            InitializeComponent();
            try
            {
                label_MP_Part.Text = formfhf.listView_GPT.SelectedItems[0].SubItems[2].Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_MP_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Button_MP_Save_Click(object sender, EventArgs e)
        {
            button_MP_Cancel.Text = "Готово";
            MessageBox.Show("Функция в разработке");
        }

        private void Button_MP_Erase_Click(object sender, EventArgs e)
        {
            button_MP_Cancel.Text = "Готово";
            MessageBox.Show("Функция в разработке");

        }

        private void Button_MP_Load_Click(object sender, EventArgs e)
        {
            button_MP_Cancel.Text = "Готово";
            MessageBox.Show("Функция в разработке");

        }
    }
}
