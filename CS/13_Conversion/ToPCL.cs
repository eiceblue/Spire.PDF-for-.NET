using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToPCL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input PDF file.
            string input = @"..\..\..\..\..\..\Data\ToPCL.pdf";

            // Create a new PdfDocument object.
            PdfDocument doc = new PdfDocument();

            // Load the PDF document from the specified input file.
            doc.LoadFromFile(input);

            // Specify the desired file name for the resulting PCL file.
            string output = "ToPCL_result.pcl";

            // Save the loaded PDF document as a PCL file using the specified output file name.
            doc.SaveToFile(output, FileFormat.PCL);

            //Launch the PCL file
            PDFDocumentViewer(output);
        }
        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch {}
        }
    }
}
