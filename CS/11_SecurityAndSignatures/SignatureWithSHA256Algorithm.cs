using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Interactive.DigitalSignatures;
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace SignatureWithSHA256Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize a new PdfDocument instance
            PdfDocument pdf = new PdfDocument();

            // Load the existing PDF file from the specified path
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DigitalSignature.pdf");

            // Load the X.509 certificate from a PFX file using the provided password
            X509Certificate2 cert = new X509Certificate2(@"..\..\..\..\..\..\Data\gary.pfx", "e-iceblue");

            // Create a PKCS#7 signature formatter using the loaded certificate
            IPdfSignatureFormatter formatter = new PdfPKCS7Formatter(cert, false);

            // Initialize the MDP signature maker with the PDF document and the formatter
            PdfMDPSignatureMaker pdfMDPSignatureMaker = new PdfMDPSignatureMaker(pdf, formatter);

            // Get the signature object from the signature maker
            PdfSignature signature = pdfMDPSignatureMaker.Signature;

            // Set the name of the signer
            signature.Name = "e-iceblue";

            // Set the contact information of the signer
            signature.ContactInfo = "028-81705109";

            // Set the location where the document is signed
            signature.Location = "chengdu";

            // Set the reason for signing the document
            signature.Reason = "Sign a pdf document.";

            // Create a signature appearance object to customize the visual layout
            PdfSignatureAppearance appearance = new PdfSignatureAppearance(signature);

            // Set the custom label for the signer's name
            appearance.NameLabel = "Signer: ";

            // Set the custom label for the contact information
            appearance.ContactInfoLabel = "ContactInfo: ";

            // Set the custom label for the location
            appearance.LocationLabel = "Location: ";

            // Set the custom label for the signing reason
            appearance.ReasonLabel = "Reason: ";

            // Apply the signature to the first page at the specified coordinates and size
            pdfMDPSignatureMaker.MakeSignature("signName", pdf.Pages[0], 300, 550, 200, 100, appearance);

            // Define the output file name for the signed PDF
            String result = "SignatureWithSHA256Algorithm.pdf";


            // Set the current hash algorithm
            formatter.Properties.HashAlgorithm = HashAlgorithmType.SHA256;

            // Use a try-catch block to handle potential saving errors
            try
            {
                // Save the signed PDF document to a file
                pdf.SaveToFile(result, FileFormat.PDF);
            }
            catch (Exception ex)
            {
                // Print the error message to the console if saving fails
                Console.WriteLine($"error：{ex.Message}");
            }


            // Dispose of the PDF document to release system resources
            pdf.Dispose();

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
