using Spire.Pdf;
using Spire.Pdf.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChangeSecurityPermission
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
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\ChangeSecurityPermission.pdf");

            // Define user and owner passwords
            string userPassword = "";
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
            pdf.SaveToFile("SecurityPermission.pdf");

            System.Diagnostics.Process.Start("SecurityPermission.pdf");

        }
    }
}
