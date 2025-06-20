using System;
using System.Windows.Forms;
using Spire.Pdf.Conversion;

namespace ToWordSecondApproach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load a PDF document from the specified file path.
            String file = @"..\..\..\..\..\..\Data\ToDocx.pdf";

            // Create a PdfToWordConverter object to convert the PDF to Word with flow layout.
            PdfToWordConverter converter = new PdfToWordConverter(file);

            // Save the converted Word document.
            converter.SaveToDocx("ToWordConvorter.docx");

            // Dispose of the converter object to release any resources used.
            converter.Dispose();

            //Launch the file.
            PDFDocumentViewer("ToWordConvorter.docx");
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
