using System;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Security;
using System.Drawing;
using Spire.Pdf.Graphics;

namespace SignWithSmartCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Load the PDF document from the disk
            string input = "../../../../../../Data/PDFTemplate_HF.pdf";
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(input);

            // Open the Windows certificate store for read-only access
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

            // Manually select a certificate from the store
            System.Security.Cryptography.X509Certificates.X509Certificate2Collection sel = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection);

            // Create a PdfCertificate object using the certificate data from the selected certificate
            PdfCertificate cert = new PdfCertificate(sel[0].RawData);

            // Create a PdfSignature object using the document, page, certificate, and field name
            PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, "signature0");
            signature.Bounds = new RectangleF(new PointF(250, 660), new SizeF(250, 90));

            // Load the sign image source
            signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png");

            // Set the graphics mode for display
            signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;

            // Set the label and value for the signer's name
            signature.NameLabel = "Signer:";
            signature.Name = sel[0].GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

            // Set the label and value for the contact information
            signature.ContactInfoLabel = "ContactInfo:";
            signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

            // Set the label and value for the signing date
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;

            // Set the label and value for the signing location
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Chengdu";

            // Set the label and value for the reason of signing
            signature.ReasonLabel = "Reason: ";
            signature.Reason = "The certificate of this document";

            // Set the label and value for the distinguished name (DN) of the certificate issuer
            signature.DistinguishedNameLabel = "DN: ";
            signature.DistinguishedName = signature.Certificate.IssuerName.Name;

            // Set the document permissions and mark the document as certified
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
            signature.Certificated = true;

            // Set the fonts for the sign details and sign name, if not set, default ones will be applied
            signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
            signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

            // Set the sign image layout mode to None
            signature.SignImageLayout = SignImageLayout.None;

            // Save the modified PDF document to a file
            string output = "SignWithSmartCardUsingPdfFileSignature_out.pdf";
            doc.SaveToFile(output);
            doc.Close();

            //Launch the Pdf file
            PDFDocumentViewer(output);
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
