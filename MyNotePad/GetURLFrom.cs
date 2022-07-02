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
        private MainForm _mainForm;
        public GetURLFrom(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
        }

        private void GetURLFrom_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
        }

        private void LoadURLButton_Click(object sender, EventArgs e)
        {
            Document document = new Document(_mainForm.noteTextBox.Font);
            string DefaultFormTitle = this.Text;
            this.Text += "- Loading...";
            string URL = URLTextBox.Text.Trim();
            if (URL != string.Empty)
            {
                try
                {
                    //WebClient client = new WebClient();
                    //string Reply = string.Empty;
                    //await Task.Run(() => { Reply = client.DownloadString(URL); });
                    _mainForm.noteTextBox.Text = document.LoadURL(URL).Result;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm(DefaultFormTitle);
                }
            }
            else
            {
                ResetForm(DefaultFormTitle);
            }
        }

        private void ResetForm(string defaultFormTitle)
        {
            this.Text = defaultFormTitle;
            URLTextBox.SelectAll();
            URLTextBox.HideSelection = false;
            URLTextBox.Focus();
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
