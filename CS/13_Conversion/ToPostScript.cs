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

namespace ToPostScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input =  @"..\..\..\..\..\..\Data\ToPostScript.pdf";

            //Load a PDF document
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(input);

            //Save to PostScript
            string output = "toPostScript_result.ps";
            document.SaveToFile(output, FileFormat.POSTSCRIPT);

            //Launch the file
            PDFDocumentViewer(output);
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
