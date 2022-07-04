using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace MyNotepad
{
    public partial class MainForm : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintDialog printDialog = new PrintDialog();
        private PageSetupDialog pageSetupDialog = new PageSetupDialog();
        private FontDialog fontDialog = new FontDialog();
        private Document document = new Document(DefaultFont);

        public MainForm()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(Document_PrintPage);
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
                            document.SaveAsText(saveFileDialog.FileName, noteTextBox.Text);
                        else
                            document.SaveAsPDF(saveFileDialog.FileName, noteTextBox.Lines);

                        UpdateFormTitle();
                    }
                    else
                        document.IsDocumentSaved = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                document.IsDocumentSaved = false;
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            //if (document.IsDocumentChanged)
            //{
            //    FormClosingEventArgs formClosingEventArgs = new FormClosingEventArgs(CloseReason.UserClosing, false);
            //    MainForm_FormClosing(sender, formClosingEventArgs);
            //}
            //else
            Application.Exit();
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (document.LoadedFilePath == "")
            {
                SaveAsMenu_Click(sender, e);
            }
            else
            {
                document.SaveAsText(document.LoadedFilePath, noteTextBox.Text);

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
                        noteTextBox.Text = document.Load(openFileDialog.FileName);
                        document.IsDocumentChanged = false;
                        document.Title = openFileDialog.SafeFileName;
                        this.Text = document.Title + " - " + Application.ProductName;
                        document.LoadedFilePath = openFileDialog.FileName;
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
            fontDialog.MinSize = 10;
            fontDialog.ShowColor = true;
            fontDialog.ShowEffects = true;
            fontDialog.ShowApply = true;

            if (fontDialog.ShowDialog().Equals(DialogResult.OK))
            {
                noteTextBox.Font = fontDialog.Font;
                noteTextBox.ForeColor = fontDialog.Color;
                lineIndicatorListBox.Font = fontDialog.Font;
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
            SolidBrush s = new SolidBrush(fontDialog.Color);
            //Draw text to the document
            e.Graphics.DrawString(noteTextBox.Text, new Font(noteTextBox.Font.Name, noteTextBox.Font.Size, noteTextBox.Font.Style), s, new PointF(100, 100));
        }
        private void PrintMenu_Click(object sender, EventArgs e)
        {
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog().Equals(DialogResult.OK)) printDocument.Print();
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
            printDocument.DocumentName = noteTextBox.Text;
            pageSetupDialog.Document = printDocument;
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
                printDocument.PrinterSettings = pageSetupDialog.PrinterSettings;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon;
            this.Text = document.Title + " - " + Application.ProductName;
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
                        document.IsDocumentChanged = false;
                        document.LoadedFilePath = FileNames[0];
                        string[] SplitedFilePath = FileNames[0].Split('\\');
                        document.Title = FileNames[0].Split('\\')[SplitedFilePath.Length - 1];//Safe file name
                        UpdateFormTitle();
                    }
                }
            }
            catch (Exception ex)
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
            document.IsDocumentChanged = true;
            UpdateFormTitle();
            UpdateLineIndicatorListBox();
        }

        private void NewDocumentMenu_Click(object sender, EventArgs e)
        {
            if (document.IsDocumentChanged)
            {
                DialogResult UserChoice = MessageBox.Show("Do you want to save changes to current document?", Application.ProductName, MessageBoxButtons.YesNo);

                if (UserChoice.Equals(DialogResult.Yes))
                {
                    SaveMenu_Click(sender, e);
                    document.IsDocumentChanged = false;
                    document.Title = "Untitled";
                    UpdateFormTitle();
                }
                else
                {
                    noteTextBox.Text = string.Empty;
                    document.IsDocumentChanged = false;
                    document.Title = "Untitled";
                    UpdateFormTitle();
                }
            }
            else
            {
                noteTextBox.Text = string.Empty;
                document.IsDocumentChanged = false;
                document.Title = "Untitled";
                UpdateFormTitle();
            }
        }

        private void UpdateFormTitle()
        {
            if (document.IsDocumentChanged)
                this.Text = document.Title + "* - " + Application.ProductName;
            else
                this.Text = document.Title + " - " + Application.ProductName;
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
            try
            {
                noteTextBox.HideSelection = false;
                if (noteTextBox.Lines.Length > 0)
                {
                    noteTextBox.SelectionStart = noteTextBox.GetFirstCharIndexFromLine(lineIndicatorListBox.SelectedIndex);
                    noteTextBox.SelectionLength = noteTextBox.Lines[lineIndicatorListBox.SelectedIndex].Length;
                    noteTextBox.ScrollToCaret();
                }
            }
            catch { }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (document.IsDocumentChanged && e.CloseReason.Equals(CloseReason.UserClosing))
            {
                DialogResult UserChoice = MessageBox.Show("Do you want to save changes to current document?", Application.ProductName, MessageBoxButtons.YesNoCancel);

                if (UserChoice.Equals(DialogResult.Yes))
                {
                    SaveAsMenu_Click(sender, e);

                    if (document.IsDocumentSaved) { e.Cancel = false; }
                }
                else if (UserChoice.Equals(DialogResult.No))
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true; //User clicked either cancel or close button
            }
        }

        private void OpenURLMenu_Click(object sender, EventArgs e)
        {
            GetURLFrom getURLFrom = new GetURLFrom(this);
            getURLFrom.Show();
        }
    }
}
