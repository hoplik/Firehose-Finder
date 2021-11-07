using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FirehoseFinder
{
    public partial class Peekpoke : Form
    {
        public Peekpoke(Formfhf formfhf)
        {
            InitializeComponent();
        }

        private void Button_pp_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Cancel;
        }

        private void Button_pp_ok_Click(object sender, EventArgs e)
        {
            //Создали xml-файл
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", string.Empty, null);
            //Если решили прочитать байт
            if (radioButton_peek.Checked) doc.LoadXml(string.Format("<data>" +
                "<peek address64 =\"0x{0}\" size_in_bytes =\"{1}\"/>" +
                "</data>", textBox_peek_adr.Text, textBox_peek_cb.Text));
            //Если решили записать байт
            if (radioButton_poke.Checked) doc.LoadXml(string.Format("<data>" +
                "<poke address64 =\"0x{0}\" size_in_bytes =\"{1}\" value64=\"0x{3}\"/>" +
                "</data>", textBox_poke_adr.Text, label_poke_cbytes.Text, textBox_poke_bytes.Text));
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            doc.Save("work.xml");
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void RadioButton_peek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_peek.Checked)
            {
                groupBox_peek.Enabled = true;
                groupBox_poke.Enabled = false;
            }
        }

        private void RadioButton_poke_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_poke.Checked)
            {
                groupBox_peek.Enabled = false;
                groupBox_poke.Enabled = true;
            }
        }

        private void TextBox_poke_bytes_TextChanged(object sender, EventArgs e)
        {
            //Подсчёт количества байт для записи
            if (string.IsNullOrEmpty(textBox_poke_bytes.Text)) label_poke_cbytes.Text = "0";
            else
            {
                int cb = textBox_poke_bytes.Text.Length;
                if (cb % 2 != 0) cb = cb / 2 + 1;
                else cb /= 2;
                label_poke_cbytes.Text = cb.ToString();
            }
        }

        /// <summary>
        /// При уходе с контрола ввода байт для записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_poke_bytes_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_poke_bytes.Text))
            {
                //Если знаков для байт нечётное число, то добавляем спереди нуль
                if (textBox_poke_bytes.Text.Length % 2 != 0) textBox_poke_bytes.Text = textBox_poke_bytes.Text.Insert(0, "0");
            }
        }

        private void TextBox_peek_adr_TextChanged(object sender, EventArgs e)
        {
            //Переводим все символы в верхний регистр
            if (!string.IsNullOrEmpty(textBox_peek_adr.Text)) textBox_peek_adr.Text = textBox_peek_adr.Text.ToUpper();
        }

        private void TextBox_poke_adr_TextChanged(object sender, EventArgs e)
        {
            //Переводим все символы в верхний регистр
            if (!string.IsNullOrEmpty(textBox_poke_adr.Text)) textBox_poke_adr.Text = textBox_poke_adr.Text.ToUpper();
        }
    }
}
