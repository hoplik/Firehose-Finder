using System;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Write_Sectors : Form
    {
        string secsize = "512";
        string totalsec = "0";

        public Write_Sectors(Formfhf formfhf)
        {
            InitializeComponent();
            secsize = formfhf.label_block_size.Text;
            totalsec = formfhf.label_total_blocks.Text;
        }

        private void Button_ws_ok_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void Button_ws_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            textBox_start_ws.Text = "0";
            textBox_count_ws.Text = "34";
            textBox_disk_ws.Text = "0";
            textBox_secsize_ws.Text = "512";
            label_storinfo_ws.Text = string.Format("Размер сектора {0}, всего секторов {1}", secsize, totalsec);
            DialogResult = DialogResult.Cancel;
        }

        private void Write_Sectors_Shown(object sender, EventArgs e)
        {
            label_storinfo_ws.Text = string.Format("Размер сектора {0}, всего секторов {1}", secsize, totalsec);
        }
    }
}
