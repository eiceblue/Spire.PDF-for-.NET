using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace PDFToMarkdown
{

	public partial class Form1 : Form
	{
        public Form1()
        {
            InitializeComponent();
        }

		private void btnRun_Click(object sender, EventArgs e)
		{
            String file = @"..\..\..\..\..\..\Data\ToTiff.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            string output = "ToMarkdown.md";
            // Convert the loaded PDF document to a Markdown file.
            doc.SaveToFile(output, FileFormat.Markdown);

            // Close the PDF document.
            doc.Close();

            // Launch the file
            DocumentViewer(output);
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
