using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Texts;

namespace ObtainVideoAudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PDF document
            PdfDocument pdf = new PdfDocument();

            // Load the PDF file from disk
            pdf.LoadFromFile("..\\..\\..\\..\\..\\..\\Data\\ObtainVideoAudio.pdf");

            // Loop through each page in the PDF document
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                // Get the current page
                PdfPageBase page = pdf.Pages[i];

                // Get all annotations on the current page
                PdfAnnotationCollection annotations = page.Annotations;

                // Loop through each annotation on the page
                for (int j = 0; j < annotations.Count; j++)
                {
                    // Cast the annotation to a rich media annotation widget
                    PdfRichMediaAnnotationWidget MediaWidget = (PdfRichMediaAnnotationWidget)annotations[j];

                    // Get the embedded media data (e.g., video, audio)
                    byte[] data = MediaWidget.RichMediaData;

                    // Get the original file name of the embedded media
                    String embedFileName = MediaWidget.RichMediaName;

                    // Save the embedded media data to a file
                    File.WriteAllBytes(embedFileName, data);
                }
            }

            // Close the PDF document
            pdf.Close();
        }
    }
}
