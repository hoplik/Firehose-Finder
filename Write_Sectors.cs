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
    public partial class Write_Sectors : Form
    {
        public Write_Sectors(Formfhf formfhf)
        {
            InitializeComponent();
        }

        private void Button_ws_ok_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void button_ws_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            textBox_start_ws.Text = "0";
            textBox_count_ws.Text = "0";
            textBox_disk_ws.Text = "0";
            DialogResult = DialogResult.Cancel;
        }
    }
}
