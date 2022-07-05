using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Net;
using System;

namespace MyNotepad
{
    public class Document : IDisposable
    {
        private Font _font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
        private string _loadedFilePath = string.Empty;
        private bool _isChanged = false;
        private string _title = "Untitled";
        private bool _isSaved = false;
        private bool isDisposed;

        public string LoadedFilePath { get => _loadedFilePath; set => _loadedFilePath = value; }
        public bool IsChanged { get => _isChanged; set => _isChanged = value; }
        public  bool IsSaved { get => _isSaved; }
        public string Title { get => _title; set => _title = value; }
        public Font Font { get => _font; set => _font = value; }

        public Document(Font font) { Font = font; }
        public Document() { }

        ~Document() { Dispose(false); }

        ///<summary>
        ///Sets the document title to "Untitled".
        ///</summary>
        public void ResetTitle() { _title = "Untitled"; }

        ///<summary>
        ///Saves the provided content in desired file format.
        ///</summary>
        public void Save(string fileName, string[] content, FileType fileType)
        {
            if (fileType.Equals(FileType.PDF))
                SaveAsPDF(fileName, content);
            else
                SaveAsText(fileName, content);

            _isSaved = true;
            _isChanged = false;
        }

        protected void SaveAsPDF(string fileName, string[] content)
        {
            int yPoint = 0;
            PdfDocument pdf = new PdfDocument();
            pdf.PageLayout = PdfPageLayout.SinglePage;
            pdf.Info.Title = "TXT to PDF";
            PdfPage pdfPage = pdf.AddPage();
            pdfPage.Width = 1500;
            pdfPage.Height = content.Length * 40;
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont(Font.Name, Font.Size, XFontStyle.Regular);

            for (int i = 0; i < content.Length; i++)
            {
                string line = content[i];
                graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint += 40;
            }

            pdf.Save(fileName);
        }

        protected void SaveAsText(string fileName, string[] content)
        {
            string temp = string.Empty;

            foreach (string line in content)
            {
                temp += line + Environment.NewLine;
            }

            if (content.Length > 0) temp = temp.Remove(temp.LastIndexOf(Environment.NewLine)); //Removing the last redundant newline if any
            File.WriteAllText(fileName, temp);
        }

        ///<summary>
        ///Loads content of specified file.
        ///</summary>
        public string Load(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        ///<summary>
        ///Gets online content asynchronously.
        ///</summary>
        public async Task<string> LoadURL(string URL)
        {
            WebClient client = new WebClient();
            return await Task.FromResult(client.DownloadString(URL));
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {
                // free managed resources
                Dispose();
            }

            isDisposed = true;
        }
    }
}
