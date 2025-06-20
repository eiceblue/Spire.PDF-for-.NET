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

namespace AddFormField
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();

            // Set the margins of the document
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            // Set the document template with specified page size and margins
            SetDocumentTemplate(doc, PdfPageSize.A4, margin);

            // Create a new page with A4 size and zero margins
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins(0));

            float y = 10;

            // Add a title to the page and update the current y coordinate
            y = DrawPageTitle(page, y);

            // Load form configuration data from an XML file
            using (Stream stream = File.OpenRead(@"..\..\..\..\..\..\Data\AddFormField-Form.xml"))
            {
                XPathDocument xpathDoc = new XPathDocument(stream);
                XPathNodeIterator sectionNodes = xpathDoc.CreateNavigator().Select("/form/section");
                int fieldIndex = 0;
                foreach (XPathNavigator sectionNode in sectionNodes)
                {
                    // Draw section label and update the current y coordinate
                    String sectionLabel = sectionNode.GetAttribute("name", "");
                    y = DrawFormSection(sectionLabel, page, y);

                    XPathNodeIterator fieldNodes = sectionNode.Select("field");
                    foreach (XPathNavigator fieldNode in fieldNodes)
                    {
                        // Draw each form field and update the current y coordinate
                        y = DrawFormField(fieldNode, doc.Form, page, y, fieldIndex++);
                    }
                }
            }

            // Draw a button on the page for submitting the form
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

            // Save the PDF document to a file
            doc.SaveToFile("AddFormField.pdf");

            // Close the PDF document
            doc.Close();


            //Launch the file.
            PDFDocumentViewer("AddFormField.pdf");
        }

        private void SetDocumentTemplate(PdfDocument doc, SizeF pageSize, PdfMargins margin)
        {
            // Create a template for the left margin
            PdfPageTemplateElement leftSpace = new PdfPageTemplateElement(margin.Left, pageSize.Height);
            doc.Template.Left = leftSpace;

            // Create a template for the top margin
            PdfPageTemplateElement topSpace = new PdfPageTemplateElement(pageSize.Width, margin.Top);
            topSpace.Foreground = true;
            doc.Template.Top = topSpace;

            // Draw the header label on the top template
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

            // Create a template for the right margin
            PdfPageTemplateElement rightSpace = new PdfPageTemplateElement(margin.Right, pageSize.Height);
            doc.Template.Right = rightSpace;

            // Create a template for the bottom margin
            PdfPageTemplateElement bottomSpace = new PdfPageTemplateElement(pageSize.Width, margin.Bottom);
            bottomSpace.Foreground = true;
            doc.Template.Bottom = bottomSpace;

            // Draw the footer label on the bottom template
            y = font.Height + 1;
            bottomSpace.Graphics.SetTransparency(0.5f);
            bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y);
            y = y + 1;
            PdfPageNumberField pageNumber = new PdfPageNumberField();
            PdfPageCountField pageCount = new PdfPageCountField();
            PdfCompositeField pageNumberLabel = new PdfCompositeField();
            pageNumberLabel.AutomaticFields = new PdfAutomaticField[] { pageNumber, pageCount };
            pageNumberLabel.Brush = PdfBrushes.Black;
            pageNumberLabel.Font = font;
            pageNumberLabel.StringFormat = format;
            pageNumberLabel.Text = "page {0} of {1}";
            pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y);

            // Add a header stamp to the document using an image
            PdfImage headerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Header.png");
            PointF pageLeftTop = new PointF(-margin.Left, -margin.Top);
            PdfPageTemplateElement header = new PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension);
            header.Foreground = false;
            header.Graphics.SetTransparency(0.5f);
            header.Graphics.DrawImage(headerImage, 0, 0);
            doc.Template.Stamps.Add(header);

            // Add a footer stamp to the document using an image
            PdfImage footerImage = PdfImage.FromFile(@"..\..\..\..\..\..\Data\Footer.png");
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
            // Define the brushes and fonts for the title
            PdfBrush brush1 = PdfBrushes.MidnightBlue;
            PdfBrush brush2 = PdfBrushes.Red;
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 12f, FontStyle.Bold));

            // Set the title text and measure its size
            String title = "Your Account Information(* = Required)";
            SizeF size = font1.MeasureString(title);

            // Calculate the x-coordinate for centering the title horizontally
            float x = (page.Canvas.ClientSize.Width - size.Width) / 2;

            // Draw the first part of the title using brush1
            page.Canvas.DrawString("Your Account Information(", font1, brush1, x, y);

            // Measure the size of the first part of the title and update the x-coordinate
            size = font1.MeasureString("Your Account Information(");
            x = x + size.Width;

            // Draw the second part of the title using brush2
            page.Canvas.DrawString("* = Required", font1, brush2, x, y);

            // Measure the size of the second part of the title and update the x-coordinate
            size = font1.MeasureString("* = Required");
            x = x + size.Width;

            // Draw the closing parenthesis of the title using brush1
            page.Canvas.DrawString(")", font1, brush1, x, y);

            // Update the y-coordinate to position the next element below the title
            y = y + size.Height;

            // Add some spacing between elements
            y = y + 3;

            // Define the font and text for additional information
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 8f, FontStyle.Italic));
            String p = "Your information is not public, shared in any way, or displayed on this site.";

            // Draw the additional information using font2 and brush1
            page.Canvas.DrawString(p, font2, brush1, 0, y);

            // Return the updated y-coordinate for positioning the next element
            return y + font2.Height;
        }


        private float DrawFormSection(String label, PdfPageBase page, float y)
        {
            // Define the brushes, font, and format for the label
            PdfBrush brush1 = PdfBrushes.LightYellow;
            PdfBrush brush2 = PdfBrushes.DarkSlateGray;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 9f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat();

            // Measure the height of the label text using the font
            float height = font.MeasureString(label).Height;

            // Draw a rectangle with brush2 as the background color for the label
            page.Canvas.DrawRectangle(brush2, 0, y, page.Canvas.ClientSize.Width, height + 2);

            // Draw the label text using brush1 inside the rectangle
            page.Canvas.DrawString(label, font, brush1, 2, y + 1);

            // Update the y-coordinate to position the next element below the label
            y = y + height + 2;

            // Draw a horizontal line below the label using a pen with light sky blue color
            PdfPen pen = new PdfPen(PdfBrushes.LightSkyBlue, 0.75f);
            page.Canvas.DrawLine(pen, 0, y, page.Canvas.ClientSize.Width, y);

            // Return the updated y-coordinate for positioning the next element
            return y + 0.75f;
        }

        // Private method to draw a form field on a PDF page
        private float DrawFormField(XPathNavigator fieldNode, PdfForm form, PdfPageBase page, float y, int fieldIndex)
        {
            // Get the width and padding of the page
            float width = page.Canvas.ClientSize.Width;
            float padding = 2;

            // Measure the label of the field
            String label = fieldNode.GetAttribute("label", "");
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 9f));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            float labelMaxWidth = width * 0.4f - 2 * padding;
            SizeF labelSize = font1.MeasureString(label, labelMaxWidth, format);

            // Measure the height of the field
            float fieldHeight = MeasureFieldHeight(fieldNode);

            // Calculate the overall height of the field based on the label and field heights
            float height = labelSize.Height > fieldHeight ? labelSize.Height : fieldHeight;
            height = height + 2;

            // Draw the background rectangle for the field
            PdfBrush brush = PdfBrushes.SteelBlue;
            if (fieldIndex % 2 == 1)
            {
                brush = PdfBrushes.LightGreen;
            }
            page.Canvas.DrawRectangle(brush, 0, y, width, height);

            // Draw the field label inside a rectangle
            PdfBrush brush1 = PdfBrushes.LightYellow;
            RectangleF labelBounds = new RectangleF(padding, y, labelMaxWidth, height);
            page.Canvas.DrawString(label, font1, brush1, labelBounds, format);

            // Draw the specific type of field based on the "type" attribute
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
                    // Draw a text box field with the specified attributes
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
                    // Draw a checkbox field with the specified attributes
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
                    // Draw a list box field with the specified attributes
                    XPathNodeIterator itemNodes = fieldNode.Select("item");
                    if ("true" == fieldNode.GetAttribute("multiple", ""))
                    {
                        PdfListBoxField listBoxField = new PdfListBoxField(page, fieldId);
                        listBoxField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
                        listBoxField.BorderWidth = 0.75f;
                        listBoxField.MultiSelect = true;
                        listBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
                        listBoxField.Required = required;
                        // Add items into the list box
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
                        // Draw a radio button list field with the specified attributes
                        PdfRadioButtonListField radioButtonListFile = new PdfRadioButtonListField(page, fieldId);
                        radioButtonListFile.Required = required;
                        // Add items into the radio button list
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

                    //Combo box
                    PdfComboBoxField comboBoxField = new PdfComboBoxField(page, fieldId);
                    comboBoxField.Bounds = new RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight);
                    comboBoxField.BorderWidth = 0.75f;
                    comboBoxField.Font = new PdfFont(PdfFontFamily.Helvetica, 9f);
                    comboBoxField.Required = required;
                    //Add items into combo box.
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
                //Draw *
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
            // Get the type attribute of the field
            String fieldType = fieldNode.GetAttribute("type", "");

            // Set the default height for fields
            float defaultHeight = 16f;

            // Determine the height based on the field type
            switch (fieldType)
            {
                case "text":
                case "password":
                    // For text and password fields, check if multiple attribute is true
                    if ("true" == fieldNode.GetAttribute("multiple", ""))
                    {
                        return defaultHeight * 3;
                    }
                    return defaultHeight;

                case "checkbox":
                    // Checkbox fields have the default height
                    return defaultHeight;

                case "list":
                    // For list fields, check if multiple attribute is true or the number of items is less than or equal to 3
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

            // If an invalid field type is encountered, throw an exception
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
