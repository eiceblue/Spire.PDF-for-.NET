using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;


namespace GetDataFromRichMediaAnnotationWidget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf instance
            PdfDocument doc = new PdfDocument();

            doc.LoadFromFile(@"..\..\..\..\..\..\Data\VideoAndAudio.pdf");

            for (int i = 0; i < doc.Pages.Count; i++)
            {
                PdfPageBase page = doc.Pages[i];
                //Get the annotation collection of the page
                PdfAnnotationCollection ancoll = page.Annotations;
                for (int j = 0; j < ancoll.Count; j++)
                {
                    //Convert to Rich Media Annotations
                    PdfRichMediaAnnotationWidget MediaWidget = ancoll[j] as PdfRichMediaAnnotationWidget;
                    //Obtain data from rich media annotations
                    byte[] data = MediaWidget.RichMediaData;
                    //Obtain names from rich media annotations
                    string embedFileName = MediaWidget.RichMediaName;
                    //Save Data
                    File.WriteAllBytes(embedFileName, data);
                    //Launch the Pdf file
                    PDFDocumentViewer(embedFileName);
                }
            }
          
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
