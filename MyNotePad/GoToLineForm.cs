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
    public partial class GoToLineForm : Form
    {
        private int _lineNumber = 0;
        private MainForm _mainForm;
        public GoToLineForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gotoLineButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(LineTextbox.Text, out _lineNumber))
            {
                _lineNumber = Convert.ToInt32(LineTextbox.Text.Trim());
                if ((_lineNumber > 0) && (_lineNumber <= _mainForm.noteTextBox.Lines.Length))
                {
                    _mainForm.noteTextBox.HideSelection = false;
                    _mainForm.noteTextBox.SelectionStart = _mainForm.noteTextBox.GetFirstCharIndexFromLine(_lineNumber - 1);
                    _mainForm.noteTextBox.SelectionLength = _mainForm.noteTextBox.Lines[_lineNumber - 1].Length;
                    _mainForm.noteTextBox.ScrollToCaret();
                    this.Close();
                }
                else
                {
                    string Message = string.Format("Line number must be between <{0}> and <{1}> !", 1, (_mainForm.noteTextBox.Lines.Length == 0 ? 1 : _mainForm.noteTextBox.Lines.Length));
                    MessageBox.Show(Message, Application.ProductName + " - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LineTextbox.SelectAll();
                    LineTextbox.Focus();
                }

            }
        }

        private void GoTo_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
        }
    }
}
