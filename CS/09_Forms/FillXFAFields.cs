using Spire.Pdf;
using Spire.Pdf.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FillXFAFields
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("XFASample.pdf");

            PdfFormWidget formWidget = doc.Form as PdfFormWidget;
            List<XfaField> xfafields = formWidget.XFAForm.XfaFields;
            foreach (XfaField xfaField in xfafields)
            {
                if (xfaField is XfaTextField)
                {
                    XfaTextField xf = xfaField as XfaTextField;
                    
                    switch (xfaField.Name)
                    {
                        case "EmployeeName":
                            xf.Value = "Gary";
                            break;
                        case "Address":
                            xf.Value = "Chengdu, China";
                            break;
                        case "StateProv":
                            xf.Value = "Sichuan Province";
                            break;
                        case "ZipCode":
                            xf.Value = "610093";
                            break;
                        case "SSNumber":
                            xf.Value = "000-00-0000";
                            break;
                        case "HomePhone":
                            xf.Value = "86-028-81705109";
                            break;
                        case "CellPhone":
                            xf.Value = "123456789";
                            break;
                        case "Comments":
                            xf.Value = "This demo shows how to fill XFA forms using Spire.PDF";
                            break;
                        default:
                            break;
                    }
                }
            }
            doc.SaveToFile("FillXfaField.pdf", FileFormat.PDF);
        }
    }
}
