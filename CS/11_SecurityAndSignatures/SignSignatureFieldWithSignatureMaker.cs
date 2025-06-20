using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.DigitalSignatures;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace SignSignatureFieldWithSignatureMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the path of the input files
            string inputFile = @"..\..\..\..\..\..\Data\SignatureField.pdf";
            string inputFile_pfx= @"..\..\..\..\..\..\Data\gary.pfx";
            string inputFile_Img = @"..\..\..\..\..\..\Data\logo.png";

            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(inputFile);
            PdfFormWidget widgets = pdf.Form as PdfFormWidget;
            for (int i = 0; i < widgets.FieldsWidget.List.Count; i++)
            {
                PdfFieldWidget widget = widgets.FieldsWidget.List[i] as PdfFieldWidget;
                if (widget is PdfSignatureFieldWidget)
                {
                    string originalName = widget.Name;
                    X509Certificate2 cert = new X509Certificate2(inputFile_pfx, "e-iceblue");
                    IPdfSignatureFormatter formatter = new PdfPKCS7Formatter(cert, false);

                    // PdfMDPSignatureMaker signatureMaker = new PdfMDPSignatureMaker(pdf, formatter);
                    PdfOrdinarySignatureMaker signatureMaker = new PdfOrdinarySignatureMaker(pdf, formatter);

                    PdfSignature signature = signatureMaker.Signature;
                    signature.Name = "E-iceblue";
                    signature.ContactInfo = "028-81705109";
                    signature.Location = "Cheng Du";
                    signature.Reason = "Ensure document integrity";

                    PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);
                    appearance.NameLabel = "Signer: ";
                    appearance.ContactInfoLabel = "ContactInfo: ";
                    appearance.LocationLabel = "Loaction: ";
                    appearance.ReasonLabel = "Reason: ";
                    appearance.SignatureImage = PdfImage.FromFile(inputFile_Img);
                    appearance.GraphicMode = GraphicMode.SignImageAndSignDetail;

                    signatureMaker.MakeSignature(originalName, appearance);
                }
            }

            // Define the output file name for the signed PDF.
            string outputFile = "SignSignatureFieldWithSignatureMaker.pdf";

            // Save the signed PDF document to the specified output path.
            pdf.SaveToFile(outputFile, FileFormat.PDF);

            // Dispose of the PDF document to release resources.
            pdf.Dispose();

            // Launch the result file.
            PDFDocumentViewer(outputFile);
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
