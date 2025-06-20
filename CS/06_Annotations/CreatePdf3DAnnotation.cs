using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatePdf3DAnnotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new Pdf document.
            PdfDocument doc = new PdfDocument();

            //Add a new page to it.
            PdfPageBase page = doc.Pages.Add();

            //Draw a rectangle on the page to define the canvas area for the 3D file.
            Rectangle rt = new Rectangle(0, 80, 200, 200);

            //Initialize a new object of Pdf3DAnnotation, load the .u3d file as 3D annotation.
            Pdf3DAnnotation annotation = new Pdf3DAnnotation(rt, @"..\..\..\..\..\..\Data\CreatePdf3DAnnotation.u3d");
            annotation.Activation = new Pdf3DActivation();
            annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen;

            //Define a 3D view mode and set its parameter
            Pdf3DView View = new Pdf3DView();
            View.Background = new Pdf3DBackground(new PdfRGBColor(Color.Purple));
            View.ViewNodeName = "3DAnnotation";
            View.RenderMode = new Pdf3DRendermode(Pdf3DRenderStyle.Solid);
            View.InternalName = "3DAnnotation";
            View.LightingScheme = new Pdf3DLighting();
            View.LightingScheme.Style = Pdf3DLightingStyle.Day;

            //Set the 3D view mode for the annotation.
            annotation.Views.Add(View);

            //Add the annotation to Pdf.
            page.Annotations.Add(annotation);

            String result = "CreatePdf3DAnnotation_out.pdf";

            //Save the document
            doc.SaveToFile(result);

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
