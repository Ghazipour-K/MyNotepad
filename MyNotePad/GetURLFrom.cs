using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MyNotepad
{
    public partial class GetURLFrom : Form
    {
        private MainForm mainForm;
        public GetURLFrom(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void GetURLFrom_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
        }

        private async void loadURLButton_Click(object sender, EventArgs e)
        {
            string DefaultFormTitle = this.Text;
            this.Text += "- Loading...";
            string address = URLTextBox.Text.Trim();
            if (address != string.Empty)
            {
                try
                {
                    WebClient client = new WebClient();
                    string Reply = string.Empty;
                    await Task.Run(() => { Reply = client.DownloadString(address); });
                    mainForm.noteTextBox.Text = Reply;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ResetText();
                    this.Text = DefaultFormTitle;
                    URLTextBox.HideSelection = false;
                    URLTextBox.Focus();
                }
            }
            else
            {
                this.Text = DefaultFormTitle;
                System.Media.SystemSounds.Exclamation.Play();
                URLTextBox.SelectAll();
                URLTextBox.HideSelection = false;
                URLTextBox.Focus();
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
