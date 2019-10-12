using Spire.Pdf;
using Spire.Pdf.Attachments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetIndividualAttachment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument pdf = new PdfDocument();

            //Load the file from disk.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_2.pdf");

            //Get a collection of attachments on the PDF document.
            PdfAttachmentCollection collection = pdf.Attachments;

            //Get the second attachment in PDF file.
            PdfAttachment attachment = collection[1];

            //Save the second attachment to the file.
            File.WriteAllBytes(attachment.FileName, attachment.Data);
        }
    }
}
