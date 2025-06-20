using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Print;

namespace MultiPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document
            PdfDocument doc = new PdfDocument();

            //Load a file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\MultiPage.pdf");

            //Select muti page to one paper layout
            doc.PrintSettings.SelectMultiPageLayout(2, 2, false, PdfMultiPageOrder.Horizontal);

            //Set print page range
            doc.PrintSettings.SelectPageRange(3, 15);

            //Set paper margins,measured in hundredths of an inch
            doc.PrintSettings.SetPaperMargins(10, 10, 10, 10);

            //Indicating whether the page is printed in landscape or portrait orientation.
            doc.PrintSettings.Landscape = false;

            //Print document
            doc.Print();

            //Close the document
            doc.Close();
        }
    }
}
