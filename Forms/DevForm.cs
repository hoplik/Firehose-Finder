using System;
using System.Resources;
using System.Windows.Forms;

namespace FirehoseFinder.Forms
{
    public partial class DevForm : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);
        public DevForm()
        {
            InitializeComponent();
        }

        private void DevForm_Shown(object sender, EventArgs e)
        {
            richTextBox_comm.Text = LocRes.GetObject("Dev_comm").ToString();
        }
    }
}
