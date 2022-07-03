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
    enum FileExtentions
    {
        TXT = 1,
        PDF = 2,
        AllFiles = 3
    }
    public partial class MainForm : Form
    {
        private PrintDocument _printDocument = new PrintDocument();
        private PrintDialog _printDialog = new PrintDialog();
        private PageSetupDialog _pageSetupDialog = new PageSetupDialog();
        private FontDialog _fontDialog = new FontDialog();
        private Document _document = new Document(DefaultFont);

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

        //private void SaveAsPDF(string fileName)
        //{
        //    string line = null;
        //    int yPoint = 0;

        //    PdfDocument pdf = new PdfDocument();
        //    pdf.PageLayout = PdfPageLayout.SinglePage;
        //    pdf.Info.Title = "TXT to PDF";
        //    PdfPage pdfPage = pdf.AddPage();
        //    pdfPage.Width = 1500;
        //    pdfPage.Height = noteTextBox.Lines.Length * 40;
        //    XGraphics graph = XGraphics.FromPdfPage(pdfPage);
        //    XFont font = new XFont(_fontDialog.Font.Name, _fontDialog.Font.Size, XFontStyle.Regular);

        //    for (int i = 0; i < noteTextBox.Lines.Length; i++)
        //    {
        //        line = noteTextBox.Lines[i];
        //        graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
        //        yPoint = yPoint + 40;
        //    }

        //    pdf.Save(fileName);
        //    Process.Start(fileName);
        //}

        public MainForm()
        {
            InitializeComponent();
            _printDocument.PrintPage += new PrintPageEventHandler(Document_PrintPage);
        }

        private void SaveAsMenu_Click(object sender, EventArgs e)
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
                        if (saveFileDialog.FilterIndex.Equals(FileExtentions.TXT) || saveFileDialog.FilterIndex.Equals(FileExtentions.AllFiles))
                            _document.SaveAsText(saveFileDialog.FileName, noteTextBox.Text);
                        else
                            _document.SaveAsPDF(saveFileDialog.FileName, noteTextBox.Lines);

                        _document.IsDocumentSaved = true;
                    }
                    else
                        _document.IsDocumentSaved = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                _document.IsDocumentSaved = false;
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (_document.LoadedFilePath == "")
            {
                SaveAsMenu_Click(sender, e);
            }
            else
            {
                _document.SaveAsText(_document.LoadedFilePath, noteTextBox.Text);
                this.Text = this.Text.Replace('*', ' ');
            }
        }

        private void OpenMenu_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt";
                openFileDialog.ShowDialog();
                try
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        noteTextBox.Text = _document.Load(openFileDialog.FileName);
                        _document.IsDocumentChanged = false;
                        _document.IsExistingDocumentLoaded = true;
                        _document.Title = openFileDialog.SafeFileName;
                        this.Text = _document.Title + " - " + Application.ProductName;
                        _document.LoadedFilePath = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DateTimeMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Text += DateTime.Now.ToShortDateString();
        }

        private void FontMenu_Click(object sender, EventArgs e)
        {
            _fontDialog.MinSize = 10;
            _fontDialog.ShowColor = true;
            _fontDialog.ShowEffects = true;
            _fontDialog.ShowApply = true;

            if (_fontDialog.ShowDialog().Equals(DialogResult.OK))
            {
                noteTextBox.Font = _fontDialog.Font;
                noteTextBox.ForeColor = _fontDialog.Color;
                lineIndicatorListBox.Font = _fontDialog.Font;
            }
        }

        private void WordWrapMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.WordWrap = !noteTextBox.WordWrap;
            wordWrapMenu.Checked = !wordWrapMenu.Checked;
        }

        private void SelectAllMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.SelectAll();
        }

        private void ZoomInMenu_Click(object sender, EventArgs e)
        {
            using (Font font = new Font(noteTextBox.Font.FontFamily, noteTextBox.Font.Size + 1))
            {
                noteTextBox.Font = font;
            }
        }

        private void ZoomOutMenu_Click(object sender, EventArgs e)
        {
            using (Font font = new Font(noteTextBox.Font.FontFamily, noteTextBox.Font.Size - 1))
            {
                noteTextBox.Font = font;
            }
        }

        private void AboutNotepadMenu_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void RestoreDefaultMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Font = new Font(noteTextBox.Font.FontFamily, 8.5f);
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            SolidBrush s = new SolidBrush(_fontDialog.Color);
            //Draw text to the document
            e.Graphics.DrawString(noteTextBox.Text, new Font(noteTextBox.Font.Name, noteTextBox.Font.Size, noteTextBox.Font.Style), s, new PointF(100, 100));
        }
        private void PrintMenu_Click(object sender, EventArgs e)
        {
            _printDialog.Document = _printDocument;
            if (_printDialog.ShowDialog().Equals(DialogResult.OK)) _printDocument.Print();
        }

        private void GoToLineMenu_Click(object sender, EventArgs e)
        {
            using (GoToLineForm goToLineForm = new GoToLineForm(this))
            {
                goToLineForm.ShowDialog();
            }
        }

        private void FindMenu_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(this);
            findForm.Show();
        }
        private void ReplaceMenu_Click(object sender, EventArgs e)
        {
            ReplaceForm replaceForm = new ReplaceForm(this);
            replaceForm.Show();
        }

        private void FindNextMenu_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(this);
            findForm.Show();
        }

        private void NewWindowMenu_Click(object sender, EventArgs e)
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

        private void SearchWithGoogleMenu_Click(object sender, EventArgs e)
        {
            if (noteTextBox.SelectedText != string.Empty)
                Process.Start("https://www.google.com/search?q=" + noteTextBox.SelectedText);
            else
                Process.Start("https://www.google.com/search?q=" + noteTextBox.Text);
        }

        private void CopyMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Copy();
        }

        private void PasteMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Paste();
        }

        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            int SelectionStart = noteTextBox.SelectionStart;
            noteTextBox.Text = noteTextBox.Text.Remove(noteTextBox.SelectionStart, noteTextBox.SelectionLength);
            noteTextBox.SelectionStart = SelectionStart;
        }

        private void UndoMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Undo();
        }

        private void CutMenu_Click(object sender, EventArgs e)
        {
            noteTextBox.Cut();
        }

        private void FindPreviousMenu_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(this);
            findForm.Show();
        }

        private void PageSetupMenu_Click(object sender, EventArgs e)
        {
            _printDocument.DocumentName = noteTextBox.Text;
            _pageSetupDialog.Document = _printDocument;
            if (_pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.DefaultPageSettings = _pageSetupDialog.PageSettings;
                _printDocument.PrinterSettings = _pageSetupDialog.PrinterSettings;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
            this.Text = _document.Title + " - " + Application.ProductName;
            noteTextBox.AllowDrop = true;
            noteTextBox.DragDrop += NoteTextBox_DragDrop;
            noteTextBox.DragOver += NoteTextBox_DragOver;
            MainForm_Resize(sender, e);
        }

        private void NoteTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void NoteTextBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var Data = e.Data.GetData(DataFormats.FileDrop);
                if (Data != null)
                {
                    var FileNames = Data as string[];
                    if (FileNames.Length > 0)
                    {
                        noteTextBox.Text = File.ReadAllText(FileNames[0]);
                        _document.IsDocumentChanged = false;
                        string[] SplitedFilePath = FileNames[0].Split('\\');
                        this.Text = FileNames[0].Split('\\')[SplitedFilePath.Length - 1];//Safe file name
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RunResource(byte[] resource)
        {
            using (FileStream fileStream = new FileStream(Application.StartupPath.ToString() + @"\Doc.pdf", FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(resource);
                }
            }
            Process.Start(Application.StartupPath.ToString() + @"\Doc.pdf");
        }

        private void ViewHelpMenu_Click(object sender, EventArgs e)
        {
            try
            {
                RunResource(Properties.Resources.Help);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateLineIndicatorListBox()
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

        private void NoteTextBox_TextChanged(object sender, EventArgs e)
        {
            _document.IsDocumentChanged = true;
            this.Text = _document.Title + "* - " + Application.ProductName;
            UpdateLineIndicatorListBox();
        }

        private void NewDocumentMenu_Click(object sender, EventArgs e)
        {
            if (_document.IsDocumentChanged)
            {
                DialogResult UserChoice = MessageBox.Show("Do you want to save changes to current document?", Application.ProductName, MessageBoxButtons.YesNo);

                if (UserChoice.Equals(DialogResult.Yes))
                {
                    SaveMenu_Click(sender, e);
                    _document.IsDocumentChanged = false;
                    _document.Title = "Untitled";
                    _document.IsExistingDocumentLoaded = false;
                    UpdateFormTitle();
                }
                else
                {
                    noteTextBox.Text = string.Empty;
                    _document.IsDocumentChanged = false;
                    _document.Title = "Untitled";
                    _document.IsExistingDocumentLoaded = false;
                    UpdateFormTitle();
                }
            }
            else
            {
                noteTextBox.Text = string.Empty;
                _document.IsDocumentChanged = false;
                _document.Title = "Untitled";
                _document.IsExistingDocumentLoaded = false;
                UpdateFormTitle();
            }
        }

        private void UpdateFormTitle()
        {
            if (_document.IsDocumentChanged)
                this.Text = _document.Title + "* - " + Application.ProductName;
            else
                this.Text = _document.Title + " - " + Application.ProductName;
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

        private void LineIndicatorListBox_MouseEnter(object sender, EventArgs e)
        {
            lineIndicatorListBox.Cursor = Cursors.Hand;
        }

        private void LineIndicatorListBox_MouseLeave(object sender, EventArgs e)
        {
            lineIndicatorListBox.Cursor = Cursors.Arrow;
        }

        private void LineIndicatorListBox_SelectedIndexChanged(object sender, EventArgs e)
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
            if (_document.IsDocumentChanged)
            {
                DialogResult UserChoice = MessageBox.Show("Do you want to save changes to current document?", Application.ProductName, MessageBoxButtons.YesNoCancel);

                if (UserChoice.Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                    SaveAsMenu_Click(sender, e);
                    if (_document.IsDocumentSaved)
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

        private void OpenURLMenu_Click(object sender, EventArgs e)
        {
            GetURLFrom getURLFrom = new GetURLFrom(this);
            getURLFrom.Show();
        }
    }
}
