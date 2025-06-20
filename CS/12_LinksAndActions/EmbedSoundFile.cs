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
namespace EmbedSoundFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            // Load an existing PDF document from a file.
            doc.LoadFromFile("..\\..\\..\\..\\..\\..\\Data\\EmbedSoundFile.pdf");

            // Get the first page of the loaded document.
            PdfPageBase page = doc.Pages[0];

            // Create a sound action with the specified sound file.
            PdfSoundAction soundAction = new PdfSoundAction("..\\..\\..\\..\\..\\..\\Data\\Music.wav");

            // Set properties for the sound action.
            soundAction.Sound.Bits = 15;
            soundAction.Sound.Channels = PdfSoundChannels.Stereo;
            soundAction.Sound.Encoding = PdfSoundEncoding.Signed;
            soundAction.Volume = 0.8f;
            soundAction.Repeat = true;

            // Set the sound action to be executed when the PDF document is opened.
            doc.AfterOpenAction = soundAction;

            // Specify the output file name for the modified PDF document.
            String result = "EmbedSoundFile_out.pdf";

            // Save the document to the output file.
            doc.SaveToFile(result);

            //Launch the Pdf file
            PDFDocumentViewer(result);
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
