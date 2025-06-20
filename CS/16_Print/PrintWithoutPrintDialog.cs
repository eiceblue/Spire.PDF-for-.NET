using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using System.Drawing.Printing;

namespace PrintWithoutPrintDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a document
            PdfDocument doc = new PdfDocument();

            //Load file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\PrintWithoutPrintDialog.pdf");

            //Set the print controller without printing process dialog
            doc.PrintSettings.PrintController = new StandardPrintController();

            //Print all pages with default printer
            doc.Print();   
        }
    }
}
