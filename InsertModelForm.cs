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
    public partial class InsertModelForm : Form
    {
        public InsertModelForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Копируем данные на основную форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ok_insert_Click(object sender, EventArgs e)
        {
            
            Hide();
        }

        /// <summary>
        /// Всё стираем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_cancel_insert_Click(object sender, EventArgs e)
        {
            comboBox_tm_insert.Text = string.Empty;
            comboBox_model_insert.Text = string.Empty;
            textBox_alt_insert.Text = string.Empty;
            Hide();
        }
    }
}
