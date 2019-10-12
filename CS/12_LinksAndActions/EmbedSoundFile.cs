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
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();

            doc.LoadFromFile("..\\..\\..\\..\\..\\..\\Data\\EmbedSoundFile.pdf");
            //Add a page
            PdfPageBase page = doc.Pages[0];

            //Create a sound action
            PdfSoundAction soundAction = new PdfSoundAction("..\\..\\..\\..\\..\\..\\Data\\5 apple song.mp3");
            soundAction.Sound.Bits = 15;
            soundAction.Sound.Channels = PdfSoundChannels.Stereo;
            soundAction.Sound.Encoding = PdfSoundEncoding.Signed;
            soundAction.Volume = 0.8f;
            soundAction.Repeat = true;
        
            // Set the sound action to be executed when the PDF document is opened
            doc.AfterOpenAction = soundAction;


            String result = "EmbedSoundFile_out.pdf";

            //Save the document
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
