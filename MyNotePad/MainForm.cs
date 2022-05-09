using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace MyNotepad
{
    public partial class MainForm : Form
    {
        private PrintDocument _printDocument = new PrintDocument();
        private PrintDialog _printDialog = new PrintDialog();
        private PageSetupDialog _pageSetupDialog = new PageSetupDialog();

        private FontDialog _fontDialog = new FontDialog();
        private string _filepath = string.Empty;
        private bool _isDocumentChanged = false;
        private string _documentTitle = "Untitled";
        private bool _isDocumentSaved = false;
        //private void saveStreamAsPDF()
        //{
        //    try
        //    {
        //        string line = null;
        //        System.IO.TextReader readFile = new StreamReader(@"Address\file.txt");
        //        int yPoint = 0;

        //        PdfDocument pdf = new PdfDocument();
        //        pdf.PageLayout = PdfPageLayout.SinglePage;
        //        pdf.Info.Title = "TXT to PDF";
        //        PdfPage pdfPage = pdf.AddPage();
        //        pdfPage.Width = 1500;
        //        pdfPage.Height = txtNote.Lines.Length * 40;
        //        XGraphics graph = XGraphics.FromPdfPage(pdfPage);
        //        XFont font = new XFont("Verdana", 20, XFontStyle.Regular);

        //        while (true)
        //        {
        //            line = readFile.ReadLine();
        //            if (line == null)
        //            {
        //                break; // TODO: might not be correct. Was : Exit While
        //            }
        //            else
        //            {
        //                graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
        //                yPoint = yPoint + 40;
        //            }
        //        }

        //        string pdfFilename = "txttopdf.pdf";
        //        pdf.Save(pdfFilename);
        //        readFile.Close();
        //        readFile = null;
        //        Process.Start(pdfFilename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void SaveTextAsPDF(string fileName)
        {
                string line = null;
                int yPoint = 0;

                PdfDocument pdf = new PdfDocument();
                pdf.PageLayout = PdfPageLayout.SinglePage;
                pdf.Info.Title = "TXT to PDF";
                PdfPage pdfPage = pdf.AddPage();
                pdfPage.Width = 1500;
                pdfPage.Height = noteTextBox.Lines.Length * 40;
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 20, XFontStyle.Regular);

                for (int i = 0; i < noteTextBox.Lines.Length; i++)
                {
                    line = noteTextBox.Lines[i];
                    graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    yPoint = yPoint + 40;
                }

                pdf.Save(fileName);
                Process.Start(fileName);
        }

        public MainForm()
        {
            InitializeComponent();
            _printDocument.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files|*.txt|PDF Files|*.PDF|All Files|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.ValidateNames = true;

                    if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
                    {
                        if (saveFileDialog.FilterIndex == 1 || saveFileDialog.FilterIndex == 3)
                            File.WriteAllText(saveFileDialog.FileName, noteTextBox.Text);
                        else
                            SaveTextAsPDF(saveFileDialog.FileName);
                        _isDocumentSaved = true;
                    }
                    else
                        _isDocumentSaved = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _isDocumentSaved = false;
            }
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            if (_filepath == "")
            {
                saveAsMenu_Click(sender, e);
            }
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt";
                openFileDialog.ShowDialog();
                try
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        noteTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                        _filepath = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimeMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Text += DateTime.Now.ToShortDateString();
        }

        private void fontMenu_Click(object sender, EventArgs e)
        {
            _fontDialog.MinSize = 20;
            _fontDialog.ShowColor = true;
            _fontDialog.ShowEffects = true;
            _fontDialog.ShowApply = true;
            _fontDialog.ShowDialog();
            noteTextBox.Font = _fontDialog.Font;
            noteTextBox.ForeColor = _fontDialog.Color;
            lineIndicatorListBox.Font = new Font(lineIndicatorListBox.Font.Name, _fontDialog.Font.Size);
            noteTextBox_TextChanged(sender, e);
        }

        private void wordWrapMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.WordWrap = !noteTextBox.WordWrap;
            wordWrapMenu.Checked = !wordWrapMenu.Checked;
        }

        private void selectAllMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.SelectAll();
        }

        private void zoomInMenu_Click(object sender, EventArgs e)
        {
            using (Font font = new Font(noteTextBox.Font.FontFamily, noteTextBox.Font.Size + 1))
            {
                noteTextBox.Font = font;
            }
        }

        private void zoomOutMenu_Click(object sender, EventArgs e)
        {
            using (Font font = new Font(noteTextBox.Font.FontFamily, noteTextBox.Font.Size - 1))
            {
                noteTextBox.Font = font;
            }
        }

        private void aboutNotepadMenu_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void restoreDefaultMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Font = new Font(noteTextBox.Font.FontFamily, 8.5f);
        }

        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            SolidBrush s = new SolidBrush(_fontDialog.Color);
            //Draw text to your document
            e.Graphics.DrawString(noteTextBox.Text, new Font(noteTextBox.Font.Name, noteTextBox.Font.Size, noteTextBox.Font.Style), s, new PointF(100, 100));
        }
        private void printMenu_Click(object sender, EventArgs e)
        {
            _printDialog.Document = _printDocument;
            if (_printDialog.ShowDialog() == DialogResult.OK) _printDocument.Print();
        }

        private void goToLineMenu_Click(object sender, EventArgs e)
        {
            GoToLineForm goToLineForm = new GoToLineForm(this);
            goToLineForm.ShowDialog();
        }

        private void findMenu_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(this);
            findForm.Show();
        }

        private void replaceMenu_Click(object sender, EventArgs e)
        {
            ReplaceForm replaceForm = new ReplaceForm(this);
            replaceForm.Show();
        }

        private void findNextMenu_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(this);
            findForm.Show();
        }

        private void newWindowMenu_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchWithGoogleMenu_Click(object sender, EventArgs e)
        {
            if (noteTextBox.SelectedText != string.Empty)
                Process.Start("https://www.google.com/search?q=" + noteTextBox.SelectedText);
            else
                Process.Start("https://www.google.com/search?q=" + noteTextBox.Text);
        }

        private void copyMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Copy();
        }

        private void pasteMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Paste();
        }

        private void deleteMenu_Click(object sender, EventArgs e)
        {
            int s = noteTextBox.SelectionStart;
            noteTextBox.Text = noteTextBox.Text.Remove(noteTextBox.SelectionStart, noteTextBox.SelectionLength);
            noteTextBox.SelectionStart = s;
        }

        private void undoMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Undo();
        }

        private void cutMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Cut();
        }

        private void findPreviousMenu_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(this);
            findForm.Show();
        }

        private void pageSetupMenu_Click(object sender, EventArgs e)
        {
            if (_pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.DefaultPageSettings = _pageSetupDialog.PageSettings;
                _printDocument.PrinterSettings = _pageSetupDialog.PrinterSettings;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
            this.Text = _documentTitle + " - " + Application.ProductName;
            MainForm_Resize(sender, e);
        }

        private void runResource(byte[] resource)
        {
            using (FileStream fileStream = new FileStream(Application.StartupPath.ToString() + "\\Help.pdf", FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(resource);
                }
            }
            Process.Start(Application.StartupPath.ToString() + @"\Help.pdf");
        }

        private void viewHelpMenu_Click(object sender, EventArgs e)
        {
            try
            {
                runResource(Properties.Resources.Help);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void updateLineIndicatorListBox()
        {
            int lineCount = noteTextBox.Lines.Length;

            lineIndicatorListBox.Items.Clear();

            if (lineCount > 1)
            {
                for (int i = 1; i < noteTextBox.Lines.Length + 1; i++)
                    lineIndicatorListBox.Items.Add(i);
            }
            else
                lineIndicatorListBox.Items.Add(1);
        }

        private void noteTextBox_TextChanged(object sender, EventArgs e)
        {
            _isDocumentChanged = true;
            this.Text = _documentTitle + "* - " + Application.ProductName;
            updateLineIndicatorListBox();
        }

        private void newDocumentMenu_Click(object sender, EventArgs e)
        {
            //New document code here
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            noteTextBox.Height = lineIndicatorListBox.Height;
            noteTextBox.Width = this.Width - lineIndicatorListBox.Width - 17;
            noteTextBox.Left = lineIndicatorListBox.Left + lineIndicatorListBox.Width;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            MainForm_Resize(sender, e);
        }

        private void lineIndicatorListBox_MouseEnter(object sender, EventArgs e)
        {
            lineIndicatorListBox.Cursor = Cursors.Hand;
        }

        private void lineIndicatorListBox_MouseLeave(object sender, EventArgs e)
        {
            lineIndicatorListBox.Cursor = Cursors.Arrow;
        }

        private void lineIndicatorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            noteTextBox.HideSelection = false;
            if (noteTextBox.Lines.Length > 0)
            {
                noteTextBox.SelectionStart = noteTextBox.GetFirstCharIndexFromLine(lineIndicatorListBox.SelectedIndex);
                noteTextBox.SelectionLength = noteTextBox.Lines[lineIndicatorListBox.SelectedIndex].Length;
                noteTextBox.ScrollToCaret();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDocumentChanged)
            {
                DialogResult UserChoice = MessageBox.Show("Do you want to save changes to current document?", Application.ProductName, MessageBoxButtons.YesNoCancel);

                if (UserChoice.Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                    saveAsMenu_Click(sender, e);
                    if (_isDocumentSaved)
                    {
                        e.Cancel = false;
                        Application.Exit();
                    }
                }
                else if (UserChoice.Equals(DialogResult.No))
                {
                    e.Cancel = false;
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                Application.Exit();
            }
        }
    }
}
