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
    class Document
    {
        private Font _font;
        private string _loadedFilePath = string.Empty;
        private bool _isDocumentChanged = false;
        private string _documentTitle = "Untitled";
        private bool _isDocumentSaved = false;
        public void Save()
        { }

        private void SaveAsPDF(string fileName, string[] content)
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
                yPoint = yPoint + 40;
            }

            pdf.Save(fileName);
        }

        private void SaveAsText(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
        public void Load()
        { }

        public void LoadUrl()
        { }

        public void UpdateTitle()
        { }

        public void Print()
        { }


    }
}
