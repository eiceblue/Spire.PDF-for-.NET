using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using Spire.Pdf.Actions;
using Spire.Pdf.General;
using Spire.Pdf.General.Find;
using System.Drawing.Printing;
using Spire.Pdf.Print;
namespace TrayPrintSecondApproach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize an object of PdfDocument class
            PdfDocument doc = new PdfDocument();
            //Load the PDF document
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\PrintPdfDocument.pdf");

            // Set colour printing. If false, printing in black and white
            doc.PrintSettings.Color = true;

            // Set landscape orientation printing. If false, printing in portrait orientation
            doc.PrintSettings.Landscape = true;


            // Set duplex printing.
            doc.PrintSettings.Duplex = Duplex.Horizontal;

            //Set Paper source
            doc.PrintSettings.PaperSettings += delegate(object sender1, PdfPaperSettingsEventArgs e1)
            {
                //Set the paper source of page 1-50 as tray 1
                if (1 <= e1.CurrentPaper && e1.CurrentPaper <= 50)
                {
                    e1.CurrentPaperSource = e1.PaperSources[0];
                }
                //Set the paper source of the rest of pages as tray 2
                else
                {
                    e1.CurrentPaperSource = e1.PaperSources[1];
                }
            };
            //Print the document
            doc.Print();
        }
    }
}
