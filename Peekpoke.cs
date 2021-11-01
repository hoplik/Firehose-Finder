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
    public partial class Peekpoke : Form
    {
        public Peekpoke(Formfhf formfhf)
        {
            InitializeComponent();
        }

        private void Button_pp_cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Button_pp_ok_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создали xml-файл");
            Hide();
        }

        private void RadioButton_peek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_peek.Checked)
            {
                groupBox_peek.Enabled = true;
                groupBox_poke.Enabled = false;
            }
        }

        private void RadioButton_poke_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_poke.Checked)
            {
                groupBox_peek.Enabled = false;
                groupBox_poke.Enabled = true;
            }
        }
    }
}
