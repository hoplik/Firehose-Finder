using System;
using System.Resources;
using System.Windows.Forms;

namespace FirehoseFinder
{
    public partial class RawProgramForm : Form
    {
        ResourceManager LocRes = new ResourceManager("FirehoseFinder.Properties.Resources", typeof(Formfhf).Assembly);

        public RawProgramForm()
        {
            InitializeComponent();
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult= DialogResult.Cancel;
        }

        private void Button_files_Click(object sender, EventArgs e)
        {
            switch (openFileDialog_xmlfiles.ShowDialog())
            {
                case DialogResult.OK:
                    foreach (string rawfile in openFileDialog_xmlfiles.SafeFileNames)
                    {
                        label_raw_patch.Text += rawfile + '\u002C';
                    }
                    label_raw_patch.Text = label_raw_patch.Text.TrimEnd('\u002C');
                    label_path.Text = openFileDialog_xmlfiles.FileName.Remove(openFileDialog_xmlfiles.FileName.LastIndexOf('\u005C'));
                    break;
                case DialogResult.Cancel:
                    label_raw_patch.Text = string.Empty;
                    label_path.Text = string.Empty;
                    break;
                default:
                    break;
            }
        }

        private void Label_raw_patch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label_raw_patch.Text)) button_ok.Enabled=false;
            else button_ok.Enabled=true;
        }
    }
}
