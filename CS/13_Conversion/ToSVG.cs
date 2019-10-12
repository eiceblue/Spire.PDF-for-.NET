using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToSVG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pdf file
            String file = @"..\..\..\..\..\..\Data\ToSVG.pdf";

            //Open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Convert to svg file
            doc.SaveToFile("ToSVG-result.svg", FileFormat.SVG);
            doc.Close();
            PDFDocumentViewer("ToSVG-result.svg");
        }
        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}
