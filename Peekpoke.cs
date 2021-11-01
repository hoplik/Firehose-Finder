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

        private void TextBox_poke_bytes_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_poke_bytes.Text)) label_poke_cbytes.Text = "0";
            else label_poke_cbytes.Text = (textBox_poke_bytes.Text.Length / 2).ToString();
        }

        private void TextBox_poke_bytes_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_poke_bytes.Text))
            {
                if (textBox_poke_bytes.Text.Length % 2 != 0) textBox_poke_bytes.Text.Insert(0, "0");
            }
        }
    }
}
