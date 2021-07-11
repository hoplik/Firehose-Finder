using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace FirehoseFinder
{

    public partial class Dump : Form
    {
        List<GPT_Table> GlobalTable;
        public Dump(Formfhf formfhf)
        {
            InitializeComponent();
            CheckedListViewItemCollection gl = formfhf.listView_GPT.CheckedItems;
            foreach (ListViewItem item in gl)
            {
                GPT_Table table = new GPT_Table()
                {
                    StartLBA = item.Text,
                    EndLBA=item.SubItems[0].Text,
                    BlockName=item.SubItems[1].Text,
                    BlockLength=item.SubItems[2].Text
                };
                GlobalTable.Add(table);
            }
        }

        private void Button_cancel_dump_Click(object sender, EventArgs e)
        {
            if (backgroundWorker_dump.IsBusy) backgroundWorker_dump.CancelAsync();
            button_ok_dump.Enabled = true;
            button_cancel_dump.Enabled = false;
        }

        private void Button_ok_dump_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void BackgroundWorker_dump_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //Формируем список разделов для экспорта
            MessageBox.Show(GlobalTable.Count.ToString());

            //Дампим раздел в указанную папку
            //Для теста
            for (int i = 0; i < 1000000; i++)
            {
                worker.ReportProgress(i * 100 / 1000000);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void BackgroundWorker_dump_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_dump.Value = e.ProgressPercentage;
            label2_dump.Text = "Выполняется - " + e.ProgressPercentage.ToString();
            Update();
        }

        private void BackgroundWorker_dump_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button_ok_dump.Enabled = true;
            button_cancel_dump.Enabled = false;
            if (e.Cancelled) label2_dump.Text = "Отменено пользователем. Можно закрыть окно, нажав кнопку \"Ok\"";
            else
            {
                if (e.Error != null) label2_dump.Text = e.Error.Message;
                else label2_dump.Text = "Сохранение выбранных разделов прошло успешно. Можно закрыть окно, нажав кнопку \"Ok\"";
            }
        }

        private void Dump_Shown(object sender, EventArgs e)
        {
            Update();
            Thread.Sleep(1000);
            backgroundWorker_dump.RunWorkerAsync();
        }
    }
}
