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

            // Create a list to store PdfSignature objects
            List<PdfSignature> signatures = new List<PdfSignature>();

            // Load the PDF document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\VerifySignature.pdf");

            // Get the form widget from the PDF document
            var form = (PdfFormWidget)pdf.Form;

            // Iterate through each field in the form
            for (int i = 0; i < form.FieldsWidget.Count; ++i)
            {
                var field = form.FieldsWidget[i] as PdfSignatureFieldWidget;

                // Check if the field is a signature field and has a signature
                if (field != null && field.Signature != null)
                {
                    // Add the signature to the list
                    PdfSignature signature = field.Signature;
                    signatures.Add(signature);
                }
            }

            // Get the first signature from the list
            PdfSignature signatureOne = signatures[0];

            // Verify the signature
            bool valid = signatureOne.VerifySignature();

            // Check if the signature is valid and display the result in a message box
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
