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
            //pdf file
            String file = @"..\..\..\..\..\..\Data\Sample9.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //convert to svg file.
            doc.SaveToFile("Sample9.svg", FileFormat.SVG);
            doc.Close();

            //Launching the svg file.
            System.Diagnostics.Process.Start("Sample9.svg");
        }
    }
}
