using System;
using System.Resources;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Write_Sectors : Form
    {
        string secsize = "512"; //Размер сектора по-умолчанию
        string totalsec = "0"; //всего секторов стартовое значение
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public Write_Sectors(Formfhf formfhf)
        {
            InitializeComponent();
            //Получаем данные по секторам с основной формы
            secsize = formfhf.label_block_size.Text;
            totalsec = formfhf.label_total_blocks.Text;
        }

        private void Button_ws_ok_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Восстанавливаем значения по-умолчанию и закрываем форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ws_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            textBox_start_ws.Text = "0";
            textBox_count_ws.Text = "34";
            textBox_disk_ws.Text = "0";
            textBox_secsize_ws.Text = "512";
            label_storinfo_ws.Text = LocRes.GetString("write_ss") + '\u0020' +
                secsize + '\u002C' + '\u0020' +
                LocRes.GetString("write_ts") + '\u0020' +
                totalsec;
            DialogResult = DialogResult.Cancel;
        }

        private void Write_Sectors_Shown(object sender, EventArgs e)
        {
            label_storinfo_ws.Text = LocRes.GetString("write_ss") + '\u0020' +
                secsize + '\u002C' + '\u0020' +
                LocRes.GetString("write_ts") + '\u0020' +
                totalsec;
        }
    }
}
