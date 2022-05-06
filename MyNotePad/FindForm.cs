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
    public partial class FindForm : Form
    {
        MainForm _mainForm;
        int _lastIndex, _preIndex;
        public FindForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }


        private void findNextBouton_Click(object sender, EventArgs e)
        {

            if (downRadioButton.Checked && _lastIndex<_mainForm.noteTextBox.Text.Length)
            {
                _lastIndex = _mainForm.noteTextBox.Text.IndexOf(findTextBox.Text, _lastIndex);
                _mainForm.noteTextBox.SelectionStart = _lastIndex;
                _mainForm.noteTextBox.SelectionLength = findTextBox.Text.Length;
                _lastIndex += findTextBox.Text.Length;
            }
            else if (upRadioButton.Checked && _preIndex>-1)
            {
                _preIndex = _mainForm.noteTextBox.SelectionStart;
                _preIndex = _mainForm.noteTextBox.Text.Substring(0, _preIndex - findTextBox.Text.Length).LastIndexOf(findTextBox.Text);
                _mainForm.noteTextBox.SelectionStart = _preIndex;
                _mainForm.noteTextBox.SelectionLength = findTextBox.Text.Length;
                _preIndex -= findTextBox.Text.Length;
            }
            _mainForm.Focus();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Find_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
            downRadioButton.Checked = true;
        }
    }
}
