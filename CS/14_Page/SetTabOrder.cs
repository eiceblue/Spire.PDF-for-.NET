using Spire.Pdf;
using System;
using System.Windows.Forms;

namespace SetTabOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load an existing PDF from disk
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\SetTabOrder.pdf");

            // Disable incremental updates to the document structure to set tab order
            pdf.FileInfo.IncrementalUpdate = false;

            // Get the first page of the PDF
            PdfPageBase page = pdf.Pages[0];

            // Set the tab order of the page using the structure method
            page.SetTabOrder(TabOrder.Structure);

            // Specify the output file name for the modified PDF with the updated tab order
            String result = "SetTabOrder_output.pdf";

            // Save the modified document with the updated tab order to disk
            pdf.SaveToFile(result);

            //Launch the file.
            DocumentViewer(result);
        }
        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
