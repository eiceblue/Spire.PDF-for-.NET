using Spire.Pdf;
using Spire.Pdf.Annotations;
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

namespace GetParticularAnnotationInfo
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
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf");

            //Get the annotation collection from the document.
            PdfAnnotationCollection annotations = pdf.Pages[0].Annotations;

            //Get particular annotation information from the document.
            StringBuilder content = new StringBuilder();
            if (annotations[0] is PdfTextAnnotationWidget)
            {
                PdfTextAnnotationWidget textAnnotation = annotations[0] as PdfTextAnnotationWidget;
                content.AppendLine("Annotation text: " + textAnnotation.Text);
                content.AppendLine("Annotation ModifiedDate: " + textAnnotation.ModifiedDate.ToString());
                content.AppendLine("Annotation author: " + textAnnotation.Author);
                content.AppendLine("Annotation Name: " + textAnnotation.Name);
            }

            String result = "GetParticularAnnotationInfo_out.txt";
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
