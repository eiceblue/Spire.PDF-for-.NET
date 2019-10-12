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
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string pdfFile = dialog.FileName;

                    List<PdfSignature> signatures = new List<PdfSignature>();

                    //Open a pdf document and get its all signatures
                    using (PdfDocument pdf = new PdfDocument())
                    {
			pdf.LoadFromFile(pdfFile);
                        PdfFormWidget form = pdf.Form as PdfFormWidget;
                        for (int i = 0; i < form.FieldsWidget.Count; i++)
                        {
                            PdfSignatureFieldWidget field = form.FieldsWidget[i] as PdfSignatureFieldWidget;
                            if (field != null && field.Signature != null)
                            {
                                PdfSignature signature = field.Signature;
                                signatures.Add(signature);
                            }
                        }

                        //Get the first signature
                        PdfSignature signatureOne = signatures[0];

                        //Detect if the pdf document was modified
                        bool modified = signatureOne.VerifyDocModified();

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
                    MessageBox.Show(exe.Message, "Spire.Pdf Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}