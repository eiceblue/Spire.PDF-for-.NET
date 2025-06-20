using Spire.Pdf;
using Spire.Pdf.Security;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExtractSignatureCertificate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the PDF document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/ExtractSignatureInfo.pdf");

            // Create a list to store the signatures found in the document
            List<PdfSignature> signatures = new List<PdfSignature>();

            // Get the form widget from the loaded document
            var form = (PdfFormWidget)doc.Form;

            // Iterate through each field in the form
            for (int i = 0; i < form.FieldsWidget.Count; ++i)
            {
                // Check if the field is a signature field
                var field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
                if (field != null && field.Signature != null)
                {
                    // If the field has a signature, add it to the list
                    PdfSignature signature = field.Signature;
                    signatures.Add(signature);
                }
            }

            // Get the first signature from the list
            PdfSignature signatureOne = signatures[0];

            // Get the certificates associated with the first signature
            X509Certificate2Collection collection = signatureOne.Certificates;

            // Iterate through each certificate in the collection
            foreach (var certificate in collection)
            {
                // Export the certificate as bytes in DER format
                byte[] cerByte = certificate.Export(X509ContentType.Cert);

                // Create a new file stream to save the exported certificate
                using (FileStream fileStream = new FileStream("Export.cer", FileMode.Create))
                {
                    // Write the exported certificate bytes to the file stream
                    for (int i = 0; i < cerByte.Length; i++)
                        fileStream.WriteByte(cerByte[i]);

                    // Set the file stream position to the beginning
                    fileStream.Seek(0, SeekOrigin.Begin);

                    // Read and verify the data in the file stream
                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        if (cerByte[i] != fileStream.ReadByte())
                        {
                            // Close the file stream if the verification fails
                            fileStream.Close();
                        }
                    }
                }
            }
            MessageBox.Show("Succeed!");
        }
    }
}
