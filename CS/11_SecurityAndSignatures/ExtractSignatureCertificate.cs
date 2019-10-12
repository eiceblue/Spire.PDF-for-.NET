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
            //Load PDF document from disk
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("../../../../../../Data/ExtractSignatureInfo.pdf");
            List<PdfSignature> signatures = new List<PdfSignature>();
            var form = (PdfFormWidget)doc.Form;
            for (int i = 0; i < form.FieldsWidget.Count; ++i)
            {
                var field = form.FieldsWidget[i] as PdfSignatureFieldWidget;

                if (field != null && field.Signature != null)
                {
                    //Find signature and add in a list
                    PdfSignature signature = field.Signature;
                    signatures.Add(signature);
                }
            }

            //Get the first signature
            PdfSignature signatureOne = signatures[0];
            X509Certificate2Collection collection = signatureOne.Certificates;
            foreach (var certificate in collection)
            {
                byte[] cerByte = certificate.Export(X509ContentType.Cert);
                using (FileStream fileStream = new FileStream("Export.cer", FileMode.Create))
                {
                    //Write the data to the file
                    for (int i = 0; i < cerByte.Length; i++)
                        fileStream.WriteByte(cerByte[i]);
                    fileStream.Seek(0, SeekOrigin.Begin);

                    //Read and verify the data   
                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        if (cerByte[i] != fileStream.ReadByte())
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
            MessageBox.Show("Succeed!");
        }
    }
}
