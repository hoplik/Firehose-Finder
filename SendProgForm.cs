using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class SendProgForm : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public SendProgForm(Formfhf formfhf)
        {
            InitializeComponent();
            DataGridViewRow row_adb = new DataGridViewRow();
            DataGridViewRow row_sahara = new DataGridViewRow();
            DataGridViewRow row_loader = new DataGridViewRow();
            DataGridViewRow row_prog = new DataGridViewRow();
            DataGridViewRow[] rows = new DataGridViewRow[4]
            {
                row_adb,
                row_sahara,
                row_loader,
                row_prog
            };
            row_adb.HeaderCell.Value = "ADB";
            row_sahara.HeaderCell.Value = "Sahara";
            row_loader.HeaderCell.Value = "Loader";
            row_prog.HeaderCell.Value = "Programer";
            rows[0] = row_adb;
            rows[1] = row_sahara;
            rows[2] = row_loader;
            rows[3] = row_prog;
            dataGridView_shareprog.Rows.AddRange(rows);
            //Данные от ADB
            dataGridView_shareprog["Column_dev_num", 0].Value = formfhf.Global_ADB_Device.Serial;
            dataGridView_shareprog["Column_manuf", 0].Value = formfhf.label_tm.Text;
            dataGridView_shareprog["Column_model", 0].Value = formfhf.label_model.Text;
            dataGridView_shareprog["Column_altname", 0].Value = formfhf.label_altname.Text; 
            dataGridView_shareprog["Column_chipnum", 0].Value = formfhf.label_chip_sn.Text;
            //Данные от Sahara
            //Данные от Loader
            //Данные от Programer
            dataGridView_shareprog["Column_id", 3].Value = formfhf.dataGridView_final.SelectedRows[0].Cells[2].Value;
            dataGridView_shareprog["Column_path", 3].Value = formfhf.label_Sahara_fhf.Text;
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
            //0    "Номер устройства",
            //1    "Производитель",
            //2    "Модель",
            //3    "Альтернативное наименование",
            //4    "Номер чипа",
            //5    "Процессор-вендор-модель",
            //6    "хеш",
            //7    "Версия",
            //8    "Путь к файлу"

            if (true)
            {
                button_send.Enabled=true;
            }
        }
    }
}
