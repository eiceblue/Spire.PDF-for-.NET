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

namespace GetPdfAttachmentInfo
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
            PdfDocument pdf = new PdfDocument();

            //Load the file from disk.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_2.pdf");

            //Get a collection of attachments on the PDF document
            PdfAttachmentCollection collection = pdf.Attachments;

            //Get the first attachment.
            PdfAttachment attachment = collection[0];

            //Get the information of the first attachment.
            StringBuilder content = new StringBuilder();
            content.AppendLine("Filename: " + attachment.FileName);
            content.AppendLine("Description: " + attachment.Description);
            content.AppendLine("Creation Date: " + attachment.CreationDate);
            content.AppendLine("Modification Date: " + attachment.ModificationDate);


            String result = "GetPdfAttachmentInfo_out.txt";

            //Save to file.
            File.WriteAllText(result, content.ToString());

            //Launch the file.
            DocumentViewer(result);
        }

        private void DocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
