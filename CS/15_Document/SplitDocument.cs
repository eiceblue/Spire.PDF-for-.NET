using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace SplitDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SplitDocument.pdf");

            // Split the document based on the specified pattern
            String pattern = "SplitDocument-{0}.pdf";
            doc.Split(pattern);
            String lastPageFileName = String.Format(pattern, doc.Pages.Count - 1);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(lastPageFileName);
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
