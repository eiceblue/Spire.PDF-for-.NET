using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Multimedia;

namespace SoundAnnotation
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

            // Add a page
            PdfPageBase page = doc.Pages.Add();

            // Define a rectangle for the sound annotation
            RectangleF rect = new RectangleF(100, 100, 20, 15);

            // Generate a minimal raw PCM sound data (1 second of silence, 8-bit, mono)
            byte[] soundData = new byte[8000];
            for (int i = 0; i < soundData.Length; i++)
            {
                soundData[i] = 128; // Middle value for unsigned 8-bit audio
            }

            // Create a sound object from the byte array
            PdfSound sound = new PdfSound(soundData);

            // Create a sound annotation with the sound object
            PdfSoundAnnotation annotation = new PdfSoundAnnotation(page, rect, sound);

            // Set the annotation properties
            annotation.Icon = PdfSoundIcon.Speaker;
            annotation.Color = Color.Red;
            annotation.Flags = PdfAnnotationFlags.Print;
            annotation.Border.Width = 2f;
            annotation.Subject = "Subject";
            annotation.Title = "Title";
            annotation.Contents = "Contents";
            annotation.Name = "Name";

            // Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation);
            annotation.RefreshAppearances();

            // Save the document
            string output = "SoundAnnotation.pdf";
            doc.SaveToFile(output);
            doc.Close();

            // Launch the Pdf file
            PDFDocumentViewer(output);
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
