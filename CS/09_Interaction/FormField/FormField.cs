using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.XPath;
using Spire.Pdf;
using Spire.Pdf.Actions;
using Spire.Pdf.AutomaticFields;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;

namespace FormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            //margin
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            SetDocumentTemplate(doc, PdfPageSize.A4, margin);

            // Create one page
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0));

            float y = 0;

            //title
            y = DrawPageTitle(page, y);

            //load form config data
            using (Stream stream = File.OpenRead(@"..\..\..\..\..\..\..\Data\Form.xml"))
            {
                XPathDocument xpathDoc = new XPathDocument(stream);
                XPathNodeIterator sectionNodes = xpathDoc.CreateNavigator().Select("/form/section");
                int fieldIndex = 0;
                foreach (XPathNavigator sectionNode in sectionNodes)
                {
                    //draw section label
                    String sectionLabel = sectionNode.GetAttribute("name", "");
                    y = DrawFormSection(sectionLabel, page, y);

                    XPathNodeIterator fieldNodes = sectionNode.Select("field");
                    foreach (XPathNavigator fieldNode in fieldNodes)
                    {
                        y= DrawFormField(fieldNode, doc.Form, page, y, fieldIndex++);
                    }
                }
            }

            //draw button
            y = y + 10;
            float buttonWidth = 80;
            float buttonX = (page.Canvas.ClientSize.Width - buttonWidth) / 2;
            RectangleF buttonBounds = new RectangleF(buttonX, y, buttonWidth, 16f);
            PdfButtonField button = new PdfButtonField(page, "submit");
            button.Text = "Submit";
            button.Bounds = buttonBounds;
            PdfSubmitAction submitAction = new PdfSubmitAction("http://www.e-iceblue.com");
            button.Actions.MouseUp = submitAction;
            doc.Form.Fields.Add(button);

            //Save pdf file.
            doc.SaveToFile("FormField.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("FormField.pdf");
        }

        private void SetDocumentTemplate(PdfDocument doc, SizeF pageSize, PdfMargins margin)
        {
            PdfPageTemplateElement leftSpace
                = new PdfPageTemplateElement(margin.Left, pageSize.Height);
            doc.Template.Left = leftSpace;

            PdfPageTemplateElement topSpace
                = new PdfPageTemplateElement(pageSize.Width, margin.Top);
            topSpace.Foreground = true;
            doc.Template.Top = topSpace;

            //draw header label
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Italic));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right);
            String label = "Demo of Spire.Pdf";
            SizeF size = font.MeasureString(label, format);
            float y = topSpace.Height - font.Height - 1;
            PdfPen pen = new PdfPen(Color.Black, 0.75f);
            topSpace.Graphics.SetTransparency(0.5f);
            topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
            y = y - 1 - size.Height;
            topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format);

            PdfPageTemplateElement rightSpace
                = new PdfPageTemplateElement(margin.Right, pageSize.Height);
            doc.Template.Right = rightSpace;

            PdfPageTemplateElement bottomSpace
                = new PdfPageTemplateElement(pageSize.Width, margin.Bottom);
            bottomSpace.Foreground = true;
            doc.Template.Bottom = bottomSpace;

            //draw footer label
            y = font.Height + 1;
            bottomSpace.Graphics.SetTransparency(0.5f);
            bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
            y = y + 1;
            PdfPageNumberField pageNumber = new PdfPageNumberField();
            PdfPageCountField pageCount = new PdfPageCountField();
            PdfCompositeField pageNumberLabel = new PdfCompositeField();
            pageNumberLabel.AutomaticFields
                = new PdfAutomaticField[] { pageNumber, pageCount };
            pageNumberLabel.Brush = PdfBrushes.Black;
            pageNumberLabel.Font = font;
            pageNumberLabel.StringFormat = format;
            pageNumberLabel.Text = "page {0} of {1}";
            pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y);

            PdfImage headerImage
                = PdfImage.FromFile(@"..\..\..\..\..\..\..\Data\Header.png");
            PointF pageLeftTop = new PointF(-margin.Left, -margin.Top);
            PdfPageTemplateElement header = new PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension);
            header.Foreground = false;
            header.Graphics.SetTransparency(0.5f);
            header.Graphics.DrawImage(headerImage, 0, 0);
            doc.Template.Stamps.Add(header);

            PdfImage footerImage
                = PdfImage.FromFile(@"..\..\..\..\..\..\..\Data\Footer.png");
            y = pageSize.Height - footerImage.PhysicalDimension.Height;
            PointF footerLocation = new PointF(-margin.Left, y);
            PdfPageTemplateElement footer = new PdfPageTemplateElement(footerLocation, footerImage.PhysicalDimension);
            footer.Foreground = false;
            footer.Graphics.SetTransparency(0.5f);
            footer.Graphics.DrawImage(footerImage, 0, 0);
            doc.Template.Stamps.Add(footer);
        }

        private float DrawPageTitle(PdfPageBase page, float y)
        {
            PdfBrush brush1 = PdfBrushes.MidnightBlue;
            PdfBrush brush2 = PdfBrushes.Red;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold));
            String title = "Your Account Information(* = Required)";
            SizeF size = font1.MeasureString(title);
            float x = (page.Canvas.ClientSize.Width - size.Width) / 2;
            page.Canvas.DrawString("Your Account Information(", font1, brush1, x, y);
            size = font1.MeasureString("Your Account Information(");
            x = x + size.Width;
            page.Canvas.DrawString("* = Required", font1, brush2, x, y);
            size = font1.MeasureString("* = Required");
            x = x + size.Width;
            page.Canvas.DrawString(")", font1, brush1, x, y);
            y = y + size.Height;

            y = y + 3;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Italic));
            String p = "Your information is not public, shared in anyway, or displayed on this site.";
            page.Canvas.DrawString(p, font2, brush1, 0, y);

            return y + font2.Height;
        }

        private float DrawFormSection(String label, PdfPageBase page, float y)
        {
            PdfBrush brush1 = PdfBrushes.LightYellow;
            PdfBrush brush2 = PdfBrushes.DarkSlateGray;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat();
            float height = font.MeasureString(label).Height;
            page.Canvas.DrawRectangle(brush2, 0, y, page.Canvas.ClientSize.Width, height + 2);
            page.Canvas.DrawString(label, font, brush1, 2, y + 1);
            y = y + height + 2;
            PdfPen pen = new PdfPen(PdfBrushes.LightSkyBlue, 0.75f);
            page.Canvas.DrawLine(pen, 0, y, page.Canvas.ClientSize.Width, y);
            return y + 0.75f;
        }

        private float DrawFormField(XPathNavigator fieldNode, PdfForm form, PdfPageBase page, float y, int fieldIndex)
        {
            float width = page.Canvas.ClientSize.Width;
            float padding = 2;

            //measure field label
            String label = fieldNode.GetAttribute("label", "");
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            float labelMaxWidth = width * 0.4f - 2 * padding;
            SizeF labelSize = font1.MeasureString(label, labelMaxWidth, format);

            //measure field height
            float fieldHeight = MeasureFieldHeight(fieldNode);

            float height = labelSize.Height > fieldHeight ? labelSize.Height : fieldHeight;
            height = height + 2;

            //draw background
            PdfBrush brush = PdfBrushes.SteelBlue;
            if (fieldIndex % 2 == 1)
            {
                brush = PdfBrushes.LightGreen;
            }
            page.Canvas.DrawRectangle(brush, 0, y, width, height);

            //draw field label
            PdfBrush brush1 = PdfBrushes.LightYellow;
            RectangleF labelBounds = new RectangleF(padding, y, labelMaxWidth, height);
            page.Canvas.DrawString(label, font1, brush1, labelBounds, format);

            //daw field
            float fieldMaxWidth = width * 0.57f - 2 * padding;
            float fieldX = labelBounds.Right + 2 * padding;
            float fieldY = y + (height - fieldHeight) / 2;
            String fieldType = fieldNode.GetAttribute("type", "");
            String fieldId = fieldNode.GetAttribute("id", "");
            bool required = "true" == fieldNode.GetAttribute("required", "");
            switch (fieldType)
            {
                case "text":
                case "password":
                    PdfTextBoxField textField = new PdfTextBoxField(page, fieldId);
                    textField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
                    textField.BorderWidth = 0.75f;
                    textField.BorderStyle = PdfBorderStyle.Solid;
                    textField.Required = required;
                    if ("password" == fieldType)
                    {
                        textField.Password = true;
                    }
                    if ("true" == fieldNode.GetAttribute("multiple", ""))
                    {
                        textField.Multiline = true;
                        textField.Scrollable = true;
                    }
                    form.Fields.Add(textField);
                    break;
                case "checkbox":
                    PdfCheckBoxField checkboxField = new PdfCheckBoxField(page, fieldId);
                    float checkboxWidth = fieldHeight - 2 * padding;
                    float checkboxHeight = checkboxWidth;
                    checkboxField.Bounds = new RectangleF(fieldX, fieldY + padding, checkboxWidth, checkboxHeight);
                    checkboxField.BorderWidth = 0.75f;
                    checkboxField.Style = PdfCheckBoxStyle.Cross;
                    checkboxField.Required = required;
                    form.Fields.Add(checkboxField);
                    break;

                case "list":
                    XPathNodeIterator itemNodes = fieldNode.Select("item");
                    if ("true" == fieldNode.GetAttribute("multiple", ""))
                    {
                        PdfListBoxField listBoxField = new PdfListBoxField(page, fieldId);
                        listBoxField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
                        listBoxField.BorderWidth = 0.75f;
                        listBoxField.MultiSelect = true;
                        listBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
                        listBoxField.Required = required;
                        //add items into list box.
                        foreach (XPathNavigator itemNode in itemNodes)
                        {
                            String text = itemNode.SelectSingleNode("text()").Value;
                            listBoxField.Items.Add(new PdfListFieldItem(text, text));
                        }
                        listBoxField.SelectedIndex = 0;
                        form.Fields.Add(listBoxField);

                        break;
                    }
                    if (itemNodes != null && itemNodes.Count <= 3)
                    {
                        PdfRadioButtonListField radioButtonListFile
                            = new PdfRadioButtonListField(page, fieldId);
                        radioButtonListFile.Required = required;
                        //add items into radio button list.
                        float fieldItemHeight = fieldHeight / itemNodes.Count;
                        float radioButtonWidth = fieldItemHeight - 2 * padding;
                        float radioButtonHeight = radioButtonWidth;
                        foreach (XPathNavigator itemNode in itemNodes)
                        {
                            String text = itemNode.SelectSingleNode("text()").Value;
                            PdfRadioButtonListItem fieldItem = new PdfRadioButtonListItem(text);
                            fieldItem.BorderWidth = 0.75f;
                            fieldItem.Bounds = new RectangleF(fieldX, fieldY + padding, radioButtonWidth, radioButtonHeight);
                            radioButtonListFile.Items.Add(fieldItem);

                            float fieldItemLabelX = fieldX + radioButtonWidth + padding;
                            SizeF fieldItemLabelSize = font1.MeasureString(text);
                            float fieldItemLabelY = fieldY + (fieldItemHeight - fieldItemLabelSize.Height) / 2;
                            page.Canvas.DrawString(text, font1, brush1, fieldItemLabelX, fieldItemLabelY);

                            fieldY = fieldY + fieldItemHeight;
                        }
                        form.Fields.Add(radioButtonListFile);

                        break;
                    }

                    //combo box
                    PdfComboBoxField comboBoxField = new PdfComboBoxField(page, fieldId);
                    comboBoxField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
                    comboBoxField.BorderWidth = 0.75f;
                    comboBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
                    comboBoxField.Required = required;
                    //add items into combo box.
                    foreach (XPathNavigator itemNode in itemNodes)
                    {
                        String text = itemNode.SelectSingleNode("text()").Value;
                        comboBoxField.Items.Add(new PdfListFieldItem(text, text));
                    }
                    form.Fields.Add(comboBoxField);
                    break;

            }

            if (required)
            {
                //draw *
                float flagX = width * 0.97f + padding;
                PdfTrueTypeFont font3 = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Bold));
                SizeF size = font3.MeasureString("*");
                float flagY = y + (height - size.Height) / 2;
                page.Canvas.DrawString("*", font3, PdfBrushes.Red, flagX, flagY);
            }

            return y + height;
        }

        private float MeasureFieldHeight(XPathNavigator fieldNode)
        {
            String fieldType = fieldNode.GetAttribute("type", "");
            float defaultHeight = 16f;
            switch (fieldType)
            {
                case "text":
                case "password":
                    if ("true" == fieldNode.GetAttribute("multiple", ""))
                    {
                        return defaultHeight * 3;
                    }
                    return defaultHeight;

                case "checkbox":
                    return defaultHeight;

                case "list":
                    if ("true" == fieldNode.GetAttribute("multiple", ""))
                    {
                        return defaultHeight * 3;
                    }
                    XPathNodeIterator itemNodes = fieldNode.Select("item");
                    if (itemNodes != null && itemNodes.Count <= 3)
                    {
                        return defaultHeight * 3;
                    }
                    return defaultHeight;

            }
            String message = String.Format("Invalid field type: {0}", fieldType);
            throw new ArgumentException(message);
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
