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
        MainForm x;
        int lastIndex;
        public ReplaceForm(MainForm fmain)
        {
            InitializeComponent();
             x = fmain;
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
            lastIndex = x.noteTextBox.Text.IndexOf(findTextBox.Text, lastIndex);
            x.noteTextBox.SelectionStart = lastIndex;
            x.noteTextBox.SelectionLength = findTextBox.Text.Length;
            lastIndex += findTextBox.Text.Length;
            x.Focus();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            x.noteTextBox.Text = x.noteTextBox.Text.Replace(findTextBox.Text, replaceTextBox.Text);
        }
    }
}
