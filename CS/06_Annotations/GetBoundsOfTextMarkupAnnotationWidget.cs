using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GetBoundsOfTextMarkupAnnotationWidget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create a PdfDocument object
            PdfDocument doc = new PdfDocument();         
            // Load a PDF file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\PdfTextMarkupAnnotation.pdf");       

            // Save the obtained text to a .txt file
            StringBuilder sb = new StringBuilder();

            // Loop through each page in the document
            foreach (PdfPageBase page in doc.Pages)
            {
                // Get all annotations on the page
                PdfAnnotationCollection annotations = page.Annotations;          
                // Loop through the annotations
                foreach (PdfAnnotation annotation in annotations)
                {
                    // Check if the annotation is a highlight annotation
                    if (annotation is PdfTextMarkupAnnotationWidget highlightAnnotation)
                    {
                        //Get annotation Type
                        if (highlightAnnotation.TextMarkupAnnotationType == PdfTextMarkupAnnotationType.Highlight)
                        {
                           for (int i = 0; i < highlightAnnotation.QuadPoints.Length; i ++)
                            {
                                sb.AppendLine("Point"+ i + " X:" +  highlightAnnotation.QuadPoints[i].X.ToString());
                                sb.AppendLine("Point" + i + " Y:" + highlightAnnotation.QuadPoints[i].Y.ToString());
                            }

                        }
                    }
                }
            }
            string result = "result.txt";
            File.WriteAllText(result, sb.ToString());


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
