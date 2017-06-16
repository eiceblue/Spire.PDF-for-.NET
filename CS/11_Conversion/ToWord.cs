using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;

namespace ToWord
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
            String file = @"..\..\..\..\..\..\Data\Sample5.pdf";

            //open pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(file);

            //convert to xps file.
            doc.SaveToFile("Sample5.doc", FileFormat.DOC);
            doc.Close();

            //Launching the xps file.
            System.Diagnostics.Process.Start("Sample5.doc");
        }
    }
}
