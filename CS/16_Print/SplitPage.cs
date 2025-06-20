using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace SplitPage
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
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\SplitPage.pdf");

            //Indicating whether the page is printed in landscape or portrait orientation.
            doc.PrintSettings.Landscape = false;

            //Set print page range
            doc.PrintSettings.SelectPageRange(1, 1);

            //Select split page to multiple paper layout
            doc.PrintSettings.SelectSplitPageLayout();

            //Print document
            doc.Print();

            //Close the document
            doc.Close();
        }
    }
}
