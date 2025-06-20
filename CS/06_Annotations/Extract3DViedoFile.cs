using Spire.Pdf;
using Spire.Pdf.Annotations;
using System;
using System.IO;
using System.Windows.Forms;

namespace Extract3DViedoFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load old PDF from disk.
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\3D.pdf");

            //Get the first page.
            PdfPageBase firstPage = pdf.Pages[0];

            //Get the annotation collection of the first page
            PdfAnnotationCollection annot = firstPage.Annotations;

            //Define an int variable
            int count = 0;

            //Traverse the annotations
            for (int i = 0; i < annot.Count; i++)
            {
                //If it is Pdf3DAnnotation
                if (annot[i] is Pdf3DAnnotation)
                {
                    Pdf3DAnnotation annot3D = annot[i] as Pdf3DAnnotation;

                    //Get the 3D video data
                    byte[] bytes = annot3D._3DData;

                    //Write the data into .u3d format file
                    if (bytes != null)
                    {
                        File.WriteAllBytes(String.Format(@"3d-{0}.u3d", count), bytes);
                        count++;
                    }
                }
            }
        }
    }
}
