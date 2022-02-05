using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class InsertModelForm : Form
    {
        List<string> manuflist = new List<string>();
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public InsertModelForm(Formfhf formfhf)
        {
            InitializeComponent();
            for (int i = 0; i < formfhf.dataGridView_collection.Rows.Count; i++)
            {
                string celltoadd = formfhf.dataGridView_collection["Trademark", i].Value.ToString();
                if (!manuflist.Contains(celltoadd)) manuflist.Add(celltoadd);
            }
        }

        private void InsertModelForm_Load(object sender, EventArgs e)
        {
            foreach (string item in manuflist)
            {
                comboBox_tm_insert.Items.Add(item);
            }
        }

        /// <summary>
        /// Копируем данные на основную форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ok_insert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_tm_insert.Text))
            {
                label_tm_insert.BackColor = Color.Red;
                MessageBox.Show(LocRes.GetString("message_body_need_fields"), LocRes.GetString("message_title_need_fields"), MessageBoxButtons.OK);
                return;
            }
            Hide();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Всё стираем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_cancel_insert_Click(object sender, EventArgs e)
        {
            comboBox_tm_insert.Text = string.Empty;
            textBox_model_insert.Text = string.Empty;
            textBox_alt_insert.Text = string.Empty;
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Удаляем небезопасные символы при ручном вводе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_tm_insert_TextChanged(object sender, EventArgs e)
        {
            label_tm_insert.BackColor = Color.Transparent;
            if (comboBox_tm_insert.Text.Contains("http") || comboBox_tm_insert.Text.Contains("/") || comboBox_tm_insert.Text.Contains("@")) comboBox_tm_insert.Text = string.Empty;
        }

        /// <summary>
        /// Удаляем небезопасные символы при ручном вводе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_model_insert_TextChanged(object sender, EventArgs e)
        {
            label_model_insert.BackColor = Color.Transparent;
            if (textBox_model_insert.Text.Contains("http") || textBox_model_insert.Text.Contains("/") || textBox_model_insert.Text.Contains("@")) textBox_model_insert.Text = string.Empty;
        }

        /// <summary>
        /// Удаляем небезопасные символы при ручном вводе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_alt_insert_TextChanged(object sender, EventArgs e)
        {
            if (textBox_alt_insert.Text.Contains("http") || textBox_alt_insert.Text.Contains("/") || textBox_alt_insert.Text.Contains("@")) textBox_alt_insert.Text = string.Empty;
        }
    }
}
