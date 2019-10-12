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
            //Load a pdf document.
            PdfDocument doc = new PdfDocument();
	    doc.LoadFromFile(@"..\..\..\..\..\..\Data\Encryption.pdf");
            //Encrypt
            PdfEncryptionKeySize keySize = PdfEncryptionKeySize.Key128Bit;
            string openPassword = "e-iceblue";
            string permissionPassword = "test";
            PdfPermissionsFlags flags = PdfPermissionsFlags.Print | PdfPermissionsFlags.FillFields;
            doc.Security.Encrypt(openPassword, permissionPassword, flags, keySize);

            //Save pdf file.
            doc.SaveToFile("Encryption-result.pdf");
            doc.Close();

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
