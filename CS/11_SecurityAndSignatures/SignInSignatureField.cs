using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Spire.Pdf.Security;
using Spire.Pdf.Graphics;

namespace SignInSignatureField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Load PDF document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/SignatureField.pdf");

            PdfFormWidget widgets = doc.Form as PdfFormWidget;

            for (int i = 0; i < widgets.FieldsWidget.List.Count; i++)
            {
                PdfFieldWidget widget = widgets.FieldsWidget.List[i] as PdfFieldWidget;
                if (widget is PdfSignatureFieldWidget)
                {
                    //Get the field name
                    string name = widget.Name;
                    PdfSignatureFieldWidget signWidget = widget as PdfSignatureFieldWidget;
                    
                    //Sign with certificate selection in the windows certificate store
                    System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);
                    store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

                    //Manually chose the certificate in the store
                    System.Security.Cryptography.X509Certificates.X509Certificate2Collection sel = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection);

                    //Create a certificate using the certificate data from the store
                    PdfCertificate cert = new PdfCertificate(sel[0].RawData);

                    //Create a signature using the signature field
                    PdfSignature signature = new PdfSignature(doc, signWidget.Page, cert, name, signWidget);

                    //Load sign image source
                    signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png");

                    //Set the dispay mode of graphics, if not set any, the default one will be applied
                    signature.GraphicsMode = GraphicMode.SignImageAndSignDetail;
                    signature.NameLabel = "Signer:";

                    signature.Name = sel[0].GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

                    signature.ContactInfoLabel = "ContactInfo:";
                    signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, true);

                    signature.DateLabel = "Date:";
                    signature.Date = DateTime.Now;

                    signature.LocationInfoLabel = "Location:";
                    signature.LocationInfo = "Chengdu";

                    signature.ReasonLabel = "Reason: ";
                    signature.Reason = "The certificate of this document";

                    signature.DistinguishedNameLabel = "DN: ";
                    signature.DistinguishedName = signature.Certificate.IssuerName.Name;

                    signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill | PdfCertificationFlags.ForbidChanges;
                    signature.Certificated = true;

                    //Set fonts, if not set, default ones will be applied
                    signature.SignDetailsFont = new PdfFont(PdfFontFamily.TimesRoman, 10f);
                    signature.SignNameFont = new PdfFont(PdfFontFamily.Courier, 15);

                    //Set the sign image layout mode
                    signature.SignImageLayout = SignImageLayout.None;
                }
            }

            //Save the Pdf document
            string output = "SignWithSmartCardUsingSignatureField_out.pdf";
            doc.SaveToFile(output);

            //Launch the result file
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
