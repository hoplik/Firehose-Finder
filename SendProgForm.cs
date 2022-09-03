using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class SendProgForm : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public SendProgForm(Formfhf formfhf)
        {
            InitializeComponent();
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void Button_send_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.OK;
            Hide();
        }

        private void SendProgForm_Load(object sender, EventArgs e)
        {
            if (true)
            {
                button_send.Enabled=true;
            }
        }
    }
}
