using Spire.Pdf;
using System;
using System.Windows.Forms;

namespace ConvertToOFD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Input and output files path
            string output = "ConvertToOFD-result.ofd";
            string input = @"..\..\..\..\..\..\Data\ConvertToOFD.pdf";

            //Create pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(input);

            //Convert pdf to ofd
            pdf.SaveToFile(output,FileFormat.OFD);

            //Launch the odf file
            FileViewer(output);
        }
        private void FileViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }        
    }
}
