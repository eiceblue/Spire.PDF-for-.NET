using Spire.Pdf;
using Spire.Pdf.Print;
using System;
using System.Windows.Forms;

namespace BookletLayoutSettings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a PDF file
            PdfDocument pdf = new PdfDocument();

            //Load a PDF file from disk
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Sample.pdf");

            //If the printer can print with Duplex
            bool isDuplex = pdf.PrintSettings.CanDuplex;
            if (isDuplex)
            {
                //Set PdfBookletSubsetMode as "BothSides" and PdfBookletBindingMode as "Left"
                pdf.PrintSettings.SelectBookletLayout(PdfBookletSubsetMode.BothSides, PdfBookletBindingMode.Left);

                //Print the PDF
                pdf.Print();
            }
            //Close  
            this.Close();
        }
    }
}
