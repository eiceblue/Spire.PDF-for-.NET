using Spire.Pdf;
using Spire.Pdf.Print;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace AutomaticRotationPrinting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF file into the document
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\MultiPage.pdf");
            //Set up multi page printing layout
            PdfMultiPageLayout printParameters = doc.PrintSettings.SelectMultiPageLayout(1, 2);
            //Control whether the page automatically rotates to fit the print layout
            printParameters.AutoRotatePages = true;
            //Horizontal flipping double-sided printing mode
            doc.PrintSettings.Duplex = Duplex.Horizontal;
            // Print the document using the specified settings
            doc.Print();
            
        }
    }
}
