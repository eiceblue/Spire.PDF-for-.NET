using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.Annotations;
using Spire.Pdf.Multimedia._3DArtwork;
using System;
using System.Drawing;
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
            Rectangle rt = new Rectangle(40, 120, 200, 200);

            //Initialize a new object of Pdf3DAnnotation, load the .u3d file as 3D annotation.
            Pdf3DArtwork artwork = new Pdf3DArtwork(@"..\..\..\..\..\..\Data\CreatePdf3DAnnotation.u3d", Pdf3DFileFormat.U3D);
            Pdf3DAnnotation annotation = new Pdf3DAnnotation(page, rt, artwork);
            annotation.Activation = new Pdf3DActivation();
            annotation.Activation.ActivationMode = Pdf3DActivationMode.PageOpen;

            //Define a 3D view mode.
            Pdf3DView View = new Pdf3DView("3DAnnotation");
            View.Background = new Pdf3DBackground(new PdfRGBColor(Color.Purple));
            View.RenderMode = new Pdf3DRenderMode(PdfRenderModeType.Solid);
            View.InternalName = "3DAnnotation";
            View.LightingScheme = new Pdf3DLightingScheme(PdfLightingSchemeType.Day);

            //Set the 3D view mode for the annotation.
            annotation.Views.Add(View);

            //Add the annotation to Pdf.
            PdfAnnotationCollection.Create(page).Add(annotation);

            string result = "CreatePdf3DAnnotation.pdf";

            //Save the document
            doc.SaveToFile(result);
            doc.Close();

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
