using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FirehoseFinder
{
    public partial class Peekpoke : Form
    {
        Func func = new Func();
        private string fh_path = string.Empty; //Полный путь к программеру
        public Peekpoke(Formfhf formfhf)
        {
            InitializeComponent();
            fh_path = formfhf.label_Sahara_fhf.Text;
        }

        /// <summary>
        /// При загрузке формы определяем подсказки для контролов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Peekpoke_Load(object sender, EventArgs e)
        {
            toolTip_pp.SetToolTip(groupBox_fh_aarch, "Если в логе появляется ошибка о некорректном значении команды (HANDLE_PEEK_FAILURE)," +
                " попробуйте изменить выбор архитектуры процессора для этого программера.");
            using (BinaryReader reader = new BinaryReader(File.Open(fh_path, FileMode.Open)))
            {
                reader.BaseStream.Position = 4;
                switch (reader.ReadByte())
                {
                    case (byte)Guide.ELF_AArch.bit32:
                        radioButton_aarch32.Checked = true;
                        break;
                    case (byte)Guide.ELF_AArch.bit64:
                        radioButton_aarch64.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Button_pp_ok_Click(object sender, EventArgs e)
        {
            string sib = "SizeInBytes"; //По-умолчанию архитектура программера 32 бита
            if (radioButton_aarch64.Checked) sib = "size_in_bytes";
            //Создали xml-файл
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", string.Empty, null);
            //Если решили прочитать байт
            if (radioButton_peek.Checked) doc.LoadXml(string.Format("<data>" +
                "<peek address64=\"0x{0}\" {1}=\"0x{2}\"/>" +
                "</data>", textBox_peek_adr.Text, sib, textBox_peek_cb.Text));
            //Если решили записать байт
            if (radioButton_poke.Checked) doc.LoadXml(string.Format("<data>" +
                "<poke address64=\"0x{0}\" {1}=\"{2}\" value64=\"0x{3}\"/>" +
                "</data>", textBox_poke_adr.Text, sib, label_poke_cbytes.Text, textBox_poke_bytes.Text));
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            doc.Save("work.xml");
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void Button_pp_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Cancel;
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

        private void TextBox_peek_adr_TextChanged(object sender, EventArgs e)
        {
            //Переводим все символы в верхний регистр
            if (!string.IsNullOrEmpty(textBox_peek_adr.Text))
            {
                textBox_peek_adr.Text = func.DelUnknownChars(textBox_peek_adr.Text, Func.System_Count.hex);
                textBox_peek_adr.SelectionStart = textBox_peek_adr.TextLength;
            }
        }

        private void TextBox_peek_cb_TextChanged(object sender, EventArgs e)
        {
            //Переводим все символы в верхний регистр
            if (!string.IsNullOrEmpty(textBox_peek_cb.Text))
            {
                textBox_peek_cb.Text = func.DelUnknownChars(textBox_peek_cb.Text, Func.System_Count.hex);
                textBox_peek_cb.SelectionStart = textBox_peek_cb.TextLength;
            }
        }

        private void TextBox_poke_adr_TextChanged(object sender, EventArgs e)
        {
            //Переводим все символы в верхний регистр
            if (!string.IsNullOrEmpty(textBox_poke_adr.Text))
            {
                textBox_poke_adr.Text = func.DelUnknownChars(textBox_poke_adr.Text, Func.System_Count.hex);
                textBox_poke_adr.SelectionStart = textBox_poke_adr.TextLength;
            }
        }

        private void TextBox_poke_bytes_TextChanged(object sender, EventArgs e)
        {
            //Подсчёт количества байт для записи
            if (string.IsNullOrEmpty(textBox_poke_bytes.Text)) label_poke_cbytes.Text = "0";
            else
            {
                textBox_poke_bytes.Text = func.DelUnknownChars(textBox_poke_bytes.Text, Func.System_Count.hex);
                textBox_poke_bytes.SelectionStart = textBox_poke_bytes.TextLength;
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

        /// <summary>
        /// Дублирование вывода в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_output_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_output.Checked)
            {
                if (saveFileDialog_output.ShowDialog() == DialogResult.OK) checkBox_output.Text = saveFileDialog_output.FileName;
                else checkBox_output.Checked = false;
            }
            else checkBox_output.Text = string.Empty;
        }
    }
}
