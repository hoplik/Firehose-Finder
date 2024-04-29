using System;
using System.Drawing;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class SendProgForm : Form
    {
        //ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public SendProgForm(Formfhf formfhf)
        {
            InitializeComponent();
            dataGridView_shareprog.Rows.Add(formfhf.Global_Share_Prog.Length);
            for (int i = 0; i < formfhf.Global_Share_Prog.Length; i++)
            {
                dataGridView_shareprog.Rows[i].HeaderCell.Value = formfhf.Global_Share_Prog[i][0];
                for (int e = 1; e < formfhf.Global_Share_Prog[i].Length; e++)
                {
                    dataGridView_shareprog[e - 1, i].Value = formfhf.Global_Share_Prog[i][e];
                }
            }
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
            if (!string.IsNullOrEmpty(dataGridView_shareprog[0, 0].Value.ToString())) button_send.Enabled=true;
            else dataGridView_shareprog.Rows[0].DefaultCellStyle.BackColor = Color.Red;
        }
    }
}
