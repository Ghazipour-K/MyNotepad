﻿using System.Drawing;
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
        private bool _isDocumentChanged = false;
        private string _title = "Untitled";
        private bool _isDocumentSaved = false;
        private bool isDisposed;

        public string LoadedFilePath { get => _loadedFilePath; set => _loadedFilePath = value; }
        public bool IsDocumentChanged { get => _isDocumentChanged; set => _isDocumentChanged = value; }
        public bool IsDocumentSaved { get => _isDocumentSaved; set => _isDocumentSaved = value; }
        public string Title { get => _title; set => _title = value; }
        public Font Font { get => _font; set => _font = value; }

        public Document(Font font) { Font = font; }
        public Document() { }

        ~Document() { Dispose(false); }

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
            XFont font = new XFont(Font.Name, Font.Size, XFontStyle.Regular);

            for (int i = 0; i < content.Length; i++)
            {
                line = content[i];
                graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                yPoint += 40;
            }

            pdf.Save(fileName);
            this.IsDocumentSaved = true;
            this.IsDocumentChanged = false;
        }

        public void SaveAsText(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
            this.IsDocumentSaved = true;
            this.IsDocumentChanged = false;
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
                this.Dispose();
            }

            isDisposed = true;
        }
    }
}
