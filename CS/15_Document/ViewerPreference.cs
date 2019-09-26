using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace ViewerPreference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load pdf document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ViewerPreference.pdf");

            //Set view reference
            doc.ViewerPreferences.CenterWindow = true;
            doc.ViewerPreferences.DisplayTitle = false;
            doc.ViewerPreferences.FitWindow = false;
            doc.ViewerPreferences.HideMenubar = true;
            doc.ViewerPreferences.HideToolbar = true;
            doc.ViewerPreferences.PageLayout = PdfPageLayout.SinglePage;

            //Save pdf file
            doc.SaveToFile("ViewerPreference_result.pdf");
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer("ViewerPreference_result.pdf");
        }
        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
