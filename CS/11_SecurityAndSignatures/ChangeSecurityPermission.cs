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
            //Create and load a pdf document
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\ChangeSecurityPermission.pdf");

            //Set an owner password, enable the permissions of Printing and Copying, set encryption level
            pdf.Security.Encrypt("", "test  ", PdfPermissionsFlags.FillFields | PdfPermissionsFlags.FullQualityPrint,PdfEncryptionKeySize.Key256Bit);

            //Save and launch
            pdf.SaveToFile("SecurityPermission.pdf");
            System.Diagnostics.Process.Start("SecurityPermission.pdf");

        }
    }
}
