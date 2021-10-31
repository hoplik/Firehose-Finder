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

        private void button_pp_ok_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создали xml-файл");
            Hide();
        }
    }
}
