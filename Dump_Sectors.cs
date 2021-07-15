using System;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class Dump_Sectors : Form
    {
        int max_sectors; //Получили максимальное количество секторов для дампа с основной формы
        string selected_lun; //Выбранный диск

        /// <summary>
        /// Инициализация контролов формы
        /// </summary>
        /// <param name="formfhf">Ссылка на основную форму</param>
        public Dump_Sectors(Formfhf formfhf)
        {
            InitializeComponent();
            try
            {
                selected_lun = formfhf.groupBox_LUN.Text;
                int sel_lun_int = Convert.ToInt32(selected_lun.Remove(0, selected_lun.IndexOf(' ') + 1));
                max_sectors = formfhf.Flash_Params[sel_lun_int].Total_Sectors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Нажали "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_dump_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            label_dump_max.Text = "Вы можете выбрать не более {0} секторов для Диск {1}";
            textBox_start_dump.Text = "0";
            textBox_count_dump.Text = "0";
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Нажали "Ок"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_dump_ok_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Вводим начальный сектор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_start_dump_TextChanged(object sender, EventArgs e)
        {
            FillFormControls();
        }

        /// <summary>
        /// Вводим количество секторов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_count_dump_TextChanged(object sender, EventArgs e)
        {
            FillFormControls();
        }

        /// <summary>
        /// Отображаем лейбл при первичном отображении формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dump_Sectors_Shown(object sender, EventArgs e)
        {
            label_dump_max.Text = string.Format("Вы можете выбрать не более {0} секторов для {1}", max_sectors, selected_lun);
            textBox_count_dump.Text = max_sectors.ToString();
        }

        /// <summary>
        /// Проверка контролов формы на корректность заполнения
        /// </summary>
        private void FillFormControls()
        {
            try
            {
                int start_dump = Convert.ToInt32(textBox_start_dump.Text);
                int count_dump = Convert.ToInt32(textBox_count_dump.Text);
                if (string.IsNullOrEmpty(textBox_start_dump.Text)
                    || string.IsNullOrEmpty(textBox_count_dump.Text)
                    || start_dump > max_sectors
                    || count_dump > max_sectors
                    || count_dump == 0
                    || start_dump + count_dump > max_sectors) button_dump_ok.Enabled = false;
                else button_dump_ok.Enabled = true;
            }
            catch (FormatException)
            {
                textBox_start_dump.Text = "0";
                textBox_count_dump.Text = "0";
                button_dump_ok.Enabled = false;
            }
        }
    }
}
