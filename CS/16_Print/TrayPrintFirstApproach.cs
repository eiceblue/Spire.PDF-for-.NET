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
namespace TrayPrintFirstApproach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();

            // Gets paper sources
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Contains("HP ColorLaserJet MFP"))
                {
                    doc.PrinterSettings.PrinterName = printer;
                    break;
                }

                var myDictPaperTray = new Dictionary<string, PaperSource>();
                for (int i = 0; i < doc.PrinterSettings.PaperSources.Count; i++)
                {
                    myDictPaperTray.Add(doc.PrinterSettings.PaperSources[i].SourceName, doc.PrinterSettings.PaperSources[i]);
                }

                // Uses tray1 to print the first page on one side
                pPrintPages(1, 1, myDictPaperTray["Tray 1"], false,true,false);
                // Uses tray4 to print the second page to fifth page on both sides
                pPrintPages(2, 5, myDictPaperTray["Tray 4"], true,false,true);
            }
        }

        private static void pPrintPages(int pStart, int pEnd, PaperSource pSource, bool pDuplex, bool IsColour, bool IsLandscape)
        {
            PdfDocument doc = new Spire.Pdf.PdfDocument(@"..\..\..\..\..\..\Data\PrintPdfDocument.pdf");
            doc.PrintSettings.SelectPageRange(pStart, pEnd);

            
            if (pDuplex)
                doc.PrintSettings.Duplex = Duplex.Vertical;
            else
                doc.PrintSettings.Duplex = Duplex.Simplex;

            if (IsColour)
                doc.PrintSettings.Color = true;
            else
                doc.PrintSettings.Color = false;

            if (IsLandscape)
                doc.PrintSettings.Landscape = true;
            else
                doc.PrintSettings.Landscape = false;

            doc.PrintSettings.PaperSettings += delegate(object sender, Spire.Pdf.Print.PdfPaperSettingsEventArgs e)
            {
                e.CurrentPaperSource = pSource;
            };

            doc.Print();
        }
    }
}
