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
    public partial class Dump_Sectors : Form
    {
        public Dump_Sectors(Formfhf formfhf)
        {
            InitializeComponent();
        }

        private void Button_dump_cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
