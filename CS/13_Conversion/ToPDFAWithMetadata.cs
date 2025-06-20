using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Conversion;
using Spire.Pdf.Interchange.Metadata;

namespace ToPDFAWithMetadata
{

	public partial class Form1 : Form
	{
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string path = @"..\..\..\..\..\..\Data\ToPDFAWithMetadata.pdf";
            string pdfA = "ToPDFAWithMetadata_out.pdf";

            // Create an instance of the PdfStandardsConverter class
            PdfStandardsConverter converter = new PdfStandardsConverter(path);
            // Convert to PDFA format document to preserve XMP data
            converter.Options.PreserveAllowedMetadata = true;
            converter.ToPdfA1A(pdfA);

            //Launch the file
            DocumentViewer(pdfA);
        }
        private void DocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

	}
}
