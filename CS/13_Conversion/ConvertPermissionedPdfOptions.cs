using Spire.Pdf;
using Spire.Pdf.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ConvertPermissionedPdfOptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            // Load a PDF file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ConvertPermissionedPdf.pdf", "e-iceblue");        

            // Apply permissions options to the conversion options.
            // When the option parameter is true, the PDF cannot be converted to other formats if permission Settings are set.
            doc.ConvertOptions.ApplyPermissionsOptions(true);

            // Create a StringBuilder object for storing results
            StringBuilder sb = new StringBuilder();

            // Iterate over each FileFormat value in the enumeration
            foreach (FileFormat type in Enum.GetValues(typeof(FileFormat)))
            {
                try
                {
                    // Check the current FileFormat value and save the document accordingly
                    if (type.ToString().Equals("PPTX"))
                    {
                        doc.SaveToFile("result_PPT.pptx", type);
                    }                 
                    else if (type.ToString().Equals("DOCX"))
                    {
                        doc.SaveToFile("result_Docx.docx", type);
                    }
                    else if (type.ToString().Equals("XLSX"))
                    {
                        doc.SaveToFile("result_Xlsx.xlsx", type);
                    }
                }
                catch (Exception ex)
                {
                    // Append any exception message to the StringBuilder
                    sb.AppendLine("save to: " + type + "  :" + ex.Message);
                }
            }

            // Append the contents of the StringBuilder to ConvertResult.txt file
            File.AppendAllText("ConvertResult.txt", sb.ToString());

            // Dispose of the PdfDocument object to release resources
            doc.Dispose();
        }
    }
}
