using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;

namespace Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            // Create and load a pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Encryption.pdf");

            // Define user and owner passwords
            string userPassword = "user";
            string ownerPassword = "owner";

            // Create a security policy with the specified passwords
            PdfSecurityPolicy securityPolicy = new PdfPasswordSecurityPolicy(userPassword, ownerPassword);

            // Set the encryption algorithm to AES 128-bit
            securityPolicy.EncryptionAlgorithm = PdfEncryptionAlgorithm.AES_128;

            // Allow printing of the document
            securityPolicy.DocumentPrivilege.AllowPrint = true;

            // Allow filling form fields in the document
            securityPolicy.DocumentPrivilege.AllowFillFormFields = true;

            // Allow copying content from the document
            securityPolicy.DocumentPrivilege.AllowContentCopying = true;

            // Encrypt the PDF document using the specified security policy
            pdf.Encrypt(securityPolicy);

            // Save the encrypted PDF document to a file named "SecurityPermission.pdf"
            pdf.SaveToFile("Encryption-result.pdf");
          
            //Launch the file.
            PDFDocumentViewer("Encryption-result.pdf");
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
