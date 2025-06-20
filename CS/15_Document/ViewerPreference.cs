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
            // Load PDF document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ViewerPreference.pdf");

            // Center the window of the PDF viewer
            doc.ViewerPreferences.CenterWindow = true;

            // Do not display the title of the PDF document in the viewer
            doc.ViewerPreferences.DisplayTitle = false;

            // Do not fit the content of the PDF document to the window of the viewer
            doc.ViewerPreferences.FitWindow = false;

            // Hide the menu bar of the PDF viewer
            doc.ViewerPreferences.HideMenubar = true;

            // Hide the toolbar of the PDF viewer
            doc.ViewerPreferences.HideToolbar = true;

            // Display the PDF document as a single page
            doc.ViewerPreferences.PageLayout = PdfPageLayout.SinglePage;

            // Save the modified PDF document with the specified filename
            doc.SaveToFile("ViewerPreference_result.pdf");

            // Close the PDF document
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
