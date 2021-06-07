using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Security;
using Spire.Pdf.Widget;
using System.Collections.Generic;

namespace VerifySignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<PdfSignature> signatures = new List<PdfSignature>();

            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\VerifySignature.pdf");

            var form = (PdfFormWidget)pdf.Form;
            for (int i = 0; i < form.FieldsWidget.Count; ++i)
            {
                var field = form.FieldsWidget[i] as PdfSignatureFieldWidget; 
                if (field != null && field.Signature != null)
                {
                    PdfSignature signature = field.Signature;
                    signatures.Add(signature);
                }
            }

            //Get the first signature
            PdfSignature signatureOne = signatures[0];

            //Verify signature
            bool valid = signatureOne.VerifySignature();
            if (valid)
            {
                MessageBox.Show("The signature is valid");
            }
            else
            {
                MessageBox.Show("The signature is invalid");
            }
        }
    }
}
