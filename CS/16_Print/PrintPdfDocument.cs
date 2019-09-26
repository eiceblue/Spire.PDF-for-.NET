using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintPdfDocument
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
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\PrintPdfDocument.pdf");

            //Set the printer and select the pages you want to print
            PrintDialog dialogPrint = new PrintDialog();
            dialogPrint.AllowPrintToFile = true;
            dialogPrint.AllowSomePages = true;
            dialogPrint.PrinterSettings.FromPage = 1;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {   
                //Print
                doc.PrintSettings.SelectPageRange(dialogPrint.PrinterSettings.FromPage, dialogPrint.PrinterSettings.ToPage);
                doc.PrintSettings.PrinterName= dialogPrint.PrinterSettings.PrinterName;                
                doc.Print();               
            }
        }
    }
}
