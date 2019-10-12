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
            string input = @"..\..\..\..\..\..\Data\ToPCL.pdf";

            //Load a PDF file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            //Save to PCL file
            string output = "ToPCL_result.pcl";
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
