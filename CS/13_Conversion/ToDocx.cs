using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToDocx
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
            doc.LoadFromFile(file);;

            //Convert to docx file.
            doc.SaveToFile("ToDocx.docx", FileFormat.DOCX);
            doc.Close();

            //Launch the file.
            System.Diagnostics.Process.Start("ToDocx.docx");
        }
    }
}
