using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotepad
{
    public partial class ReplaceForm : Form
    {
        MainForm mainForm;
        int lastIndex;
        public ReplaceForm(MainForm fmain)
        {
            InitializeComponent();
             mainForm = fmain;
        }

        private void Replace_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            lastIndex = mainForm.noteTextBox.Text.IndexOf(findTextBox.Text, lastIndex);
            mainForm.noteTextBox.SelectionStart = lastIndex;
            mainForm.noteTextBox.SelectionLength = findTextBox.Text.Length;
            lastIndex += findTextBox.Text.Length;
            mainForm.Focus();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            mainForm.noteTextBox.Text = mainForm.noteTextBox.Text.Replace(findTextBox.Text, replaceTextBox.Text);
        }
    }
}
