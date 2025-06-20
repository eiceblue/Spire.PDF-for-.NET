using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Pdf.Security;
using Spire.Pdf.Widget;
using Spire.Pdf;

namespace IsModifiedSignedPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF document (*.pdf)|*.pdf";

            // Display the open file dialog and get the result
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    // Get the selected PDF file path
                    string pdfFile = dialog.FileName;

                    // Create a list to store the signatures found in the document
                    List<PdfSignature> signatures = new List<PdfSignature>();

                    // Open the PDF document and retrieve its signatures
                    using (PdfDocument pdf = new PdfDocument())
                    {
                        pdf.LoadFromFile(pdfFile);

                        // Get the form widget from the loaded document
                        PdfFormWidget form = pdf.Form as PdfFormWidget;

                        // Iterate through each field in the form
                        for (int i = 0; i < form.FieldsWidget.Count; i++)
                        {
                            // Check if the field is a signature field
                            PdfSignatureFieldWidget field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
                            if (field != null && field.Signature != null)
                            {
                                // If the field has a signature, add it to the list
                                PdfSignature signature = field.Signature;
                                signatures.Add(signature);
                            }
                        }

                        // Get the first signature from the list
                        PdfSignature signatureOne = signatures[0];

                        // Determine if the PDF document was modified
                        bool modified = signatureOne.VerifyDocModified();

                        // Show a message box indicating whether the document was modified or not
                        if (modified)
                        {
                            MessageBox.Show("The document was modified");
                        }
                        else
                        {
                            MessageBox.Show("The document was not modified");
                        }
                    }
                }
                catch (Exception exe)
                {
                    // Show an error message box if an exception occurs
                    MessageBox.Show(exe.Message, "Spire.Pdf Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}