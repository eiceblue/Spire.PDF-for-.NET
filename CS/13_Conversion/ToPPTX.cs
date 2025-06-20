using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToPPTX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load a pdf document
            String file = @"..\..\..\..\..\..\Data\ToDocx.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //Convert to pptx file.
            doc.SaveToFile("ToPPTX.pptx", FileFormat.PPTX);
            doc.Close();

            //Launch the file.
            System.Diagnostics.Process.Start("ToPPTX.pptx");
        }
    }
}
