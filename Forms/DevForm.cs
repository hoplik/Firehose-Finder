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

        /// <summary>
        /// Загрузити текст из текстового файла на выбранном языке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevForm_Shown(object sender, EventArgs e)
        {
            richTextBox_comm.Text = LocRes.GetObject("Dev_comm").ToString();
        }

        private void SendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Потом сделаю отправку предложения в канал");
        }
    }
}
