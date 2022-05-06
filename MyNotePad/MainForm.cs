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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public MainForm()
        {
            InitializeComponent();
            _printDocument.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt|PDF Files|*.PDF|All Files|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;
                saveFileDialog.ValidateNames = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FilterIndex == 0 || saveFileDialog.FilterIndex == 2)
                        File.WriteAllText(saveFileDialog.FileName, noteTextBox.Text);
                    else
                        SaveTextAsPDF(saveFileDialog.FileName);
                }
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
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.ValidateNames = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(saveFileDialog.FileName, noteTextBox.Text);
                }
            }
            else
                File.WriteAllText(_filepath, noteTextBox.Text);
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
            using (About AboutForm = new About())
            {
                AboutForm.ShowDialog();
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
            //Process.Start(Application.StartupPath + ".exe");
        }

        private void searchWithGoogleMenu_Click(object sender, EventArgs e)
        {
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
            runResource(Properties.Resources.Help);
        }

        private void noteTextBox_TextChanged(object sender, EventArgs e)
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

        private void newDocumentMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
