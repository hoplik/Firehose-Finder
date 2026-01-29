using System;
using System.Windows.Forms;

namespace FirehoseFinder.Forms
{
    public partial class Ten_Sec_Form : Form
    {
        public string Ten_Sec_Form_Text
        {
            get { return Text; }
            set { Text = value; }
        }

        public string Ten_Sec_Label_Text
        {
            get { return label_ten_sec_mess.Text; }
            set { label_ten_sec_mess.Text = value; }
        }

        private int countdown = 15; //Начальное значение обратного отчёта
        public Ten_Sec_Form()
        {
            InitializeComponent();
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            timer_ten_sec_mess.Stop();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button_can_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Ten_Sec_Form_Load(object sender, EventArgs e)
        {
            timer_ten_sec_mess.Start();
            countdown_timer.Start();
        }

        private void Timer_ten_sec_mess_Tick(object sender, EventArgs e)
        {
            button_ok.PerformClick();
        }

        private void Countdown_timer_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                button_ok.Text = "Ok (" + countdown.ToString() + ")";
                countdown--;
            }
            else countdown_timer.Stop();
        }
    }
}
