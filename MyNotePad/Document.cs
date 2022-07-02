using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Net;



namespace MyNotepad
{
    public class Document
    {
        private Font _font;
        private string _loadedFilePath = string.Empty;
        private bool _isDocumentChanged = false;
        private string _documentTitle = "Untitled";
        private bool _isDocumentSaved = false;
        public Document() { }
        ~Document() { }

        public void SaveAsPDF(string fileName, string[] content)
        {
            string line = null;
            int yPoint = 0;

            PdfDocument pdf = new PdfDocument();
            pdf.PageLayout = PdfPageLayout.SinglePage;
            pdf.Info.Title = "TXT to PDF";
            PdfPage pdfPage = pdf.AddPage();
            pdfPage.Width = 1500;
            pdfPage.Height = content.Length * 40;
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont(_font.Name, _font.Size, XFontStyle.Regular);

            for (int i = 0; i < content.Length; i++)
            {
                line = content[i];
                graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint += 40;
            }

            pdf.Save(fileName);
        }

        public void SaveAsText(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
        public string Load(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public async Task<string> LoadURL(string URL)
        {
            WebClient client = new WebClient();
            return await Task.FromResult(client.DownloadString(URL));
        }

        public void Print()
        { }


    }
}
