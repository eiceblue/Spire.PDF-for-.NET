using Spire.Pdf;
using Spire.Pdf.Interactive.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModifyLineAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "ModifyLineAnnotation.pdf";

            // Create a new PdfDocument object
            PdfDocument document = new PdfDocument();

            // Load an existing PDF file into the document from the specified path
            document.LoadFromFile(@"..\..\..\..\..\..\Data\PdfLineAnnotation.pdf");

            // Retrieve the first annotation from the first page of the document
            PdfAnnotation annotation = PdfAnnotationCollection.Create(document.Pages[0])[0];

            // Check if the retrieved annotation is a PdfLineAnnotation
            if (annotation is PdfLineAnnotation)
            {
                // Cast the annotation as a PdfLineAnnotation to access its specific properties and methods
                PdfLineAnnotation lineAnn = annotation as PdfLineAnnotation;

                // Set the title property of the line annotation to "Author_test"
                lineAnn.Title = "Author_test";

                // Set the subject property of the line annotation to "Subject_test"
                lineAnn.Subject = "Subject_test";
            }

            // Save the modified document to the specified file path
            document.SaveToFile(result);

            document.Dispose();

            //Launch the Pdf file
            PDFDocumentViewer(result);
        }

        private void PDFDocumentViewer(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start(filename);
            }
            catch { }
        }
    }
}
