Imports System.IO
Imports System.Xml.XPath
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.AutomaticFields
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddFormField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document
            Dim doc As New PdfDocument()

            ' Create a unit converter for PDF measurements
            Dim unitCvtr As New PdfUnitConvertor()

            ' Set the margins of the document
            Dim margin As New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            SetDocumentTemplate(doc, PdfPageSize.A4, margin)

            ' Add a new page to the document
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(0))

            ' Set the initial Y position for drawing content on the page
            Dim y As Single = 10

            ' Draw the page title at the specified Y position
            y = DrawPageTitle(page, y)

            ' Open an XML file containing form data
            Using stream As Stream = File.OpenRead("..\..\..\..\..\..\Data\AddFormField-Form.xml")

                ' Create an XPath document from the XML stream
                Dim xpathDoc As New XPathDocument(stream)

                ' Select all section nodes in the form
                Dim sectionNodes As XPathNodeIterator = xpathDoc.CreateNavigator().Select("/form/section")

                ' Initialize the field index
                Dim fieldIndex As Integer = 0

                ' Iterate over each section node
                For Each sectionNode As XPathNavigator In sectionNodes

                    ' Get the name attribute of the section
                    Dim sectionLabel As String = sectionNode.GetAttribute("name", "")

                    ' Draw the form section with the specified label on the page
                    y = DrawFormSection(sectionLabel, page, y)

                    ' Select all field nodes within the current section
                    Dim fieldNodes As XPathNodeIterator = sectionNode.Select("field")

                    ' Iterate over each field node
                    For Each fieldNode As XPathNavigator In fieldNodes

                        ' Draw the form field and update the Y position
                        y = DrawFormField(fieldNode, doc.Form, page, y, fieldIndex)

                        ' Increment the field index
                        fieldIndex += 1
                    Next fieldNode
                Next sectionNode
            End Using

            ' Update the Y position with a spacing of 10
            y = y + 10

            ' Set the dimensions and position of the submit button
            Dim buttonWidth As Single = 80
            Dim buttonX As Single = (page.Canvas.ClientSize.Width - buttonWidth) / 2
            Dim buttonBounds As New RectangleF(buttonX, y, buttonWidth, 16.0F)

            ' Create a new PDF button field
            Dim button As New PdfButtonField(page, "submit")
            button.Text = "Submit"
            button.Bounds = buttonBounds

            ' Set the submit action for the button
            Dim submitAction As New PdfSubmitAction("http://www.e-iceblue.com")
            button.Actions.MouseUp = submitAction

            ' Add the button field to the document's form fields collection
            doc.Form.Fields.Add(button)

            ' Save the document to a file
            doc.SaveToFile("AddFormField.pdf")

            ' Close the document
            doc.Close()

            ' Launch the file
            PDFDocumentViewer("AddFormField.pdf")
        End Sub
        Private Sub SetDocumentTemplate(ByVal doc As PdfDocument, ByVal pageSize As SizeF, ByVal margin As PdfMargins)
            ' Create a new PDF page template element for the left space
            Dim leftSpace As New PdfPageTemplateElement(margin.Left, pageSize.Height)
            doc.Template.Left = leftSpace

            ' Create a new PDF page template element for the top space
            Dim topSpace As New PdfPageTemplateElement(pageSize.Width, margin.Top)
            topSpace.Foreground = True
            doc.Template.Top = topSpace

            ' Create a new PDF true type font and string format for the label
            Dim font As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Italic))
            Dim format As New PdfStringFormat(PdfTextAlignment.Right)
            Dim label As String = "Demo of Spire.Pdf"
            Dim size As SizeF = font.MeasureString(label, format)
            Dim y As Single = topSpace.Height - font.Height - 1
            Dim pen As New PdfPen(Color.Black, 0.75F)

            ' Draw a line and the label on the top space
            topSpace.Graphics.SetTransparency(0.5F)
            topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)
            y = y - 1 - size.Height
            topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format)

            ' Create a new PDF page template element for the right space
            Dim rightSpace As New PdfPageTemplateElement(margin.Right, pageSize.Height)
            doc.Template.Right = rightSpace

            ' Create a new PDF page template element for the bottom space
            Dim bottomSpace As New PdfPageTemplateElement(pageSize.Width, margin.Bottom)
            bottomSpace.Foreground = True
            doc.Template.Bottom = bottomSpace

            ' Draw a line and the page number label on the bottom space
            y = font.Height + 1
            bottomSpace.Graphics.SetTransparency(0.5F)
            bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)
            y = y + 1
            Dim pageNumber As New PdfPageNumberField()
            Dim pageCount As New PdfPageCountField()
            Dim pageNumberLabel As New PdfCompositeField()
            pageNumberLabel.AutomaticFields = New PdfAutomaticField() {pageNumber, pageCount}
            pageNumberLabel.Brush = PdfBrushes.Black
            pageNumberLabel.Font = font
            pageNumberLabel.StringFormat = format
            pageNumberLabel.Text = "page {0} of {1}"
            pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y)

            ' Create a PDF page template element for the header image
            Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
            Dim pageLeftTop As New PointF(-margin.Left, -margin.Top)
            Dim header As New PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension)
            header.Foreground = False
            header.Graphics.SetTransparency(0.5F)
            header.Graphics.DrawImage(headerImage, 0, 0)
            doc.Template.Stamps.Add(header)

            ' Create a PDF page template element for the footer image
            Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")
            y = pageSize.Height - footerImage.PhysicalDimension.Height
            Dim footerLocation As New PointF(-margin.Left, y)
            Dim footer As New PdfPageTemplateElement(footerLocation, footerImage.PhysicalDimension)
            footer.Foreground = False
            footer.Graphics.SetTransparency(0.5F)
            footer.Graphics.DrawImage(footerImage, 0, 0)
            doc.Template.Stamps.Add(footer)
        End Sub

        Private Function DrawPageTitle(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Set the brush color for the first part of the title
            Dim brush1 As PdfBrush = PdfBrushes.MidnightBlue

            ' Set the brush color for the second part of the title
            Dim brush2 As PdfBrush = PdfBrushes.Red

            ' Create a new PDF true type font for the title
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Bold))

            ' Set the text for the title
            Dim title As String = "Your Account Information(* = Required)"

            ' Measure the size of the title text
            Dim size As SizeF = font1.MeasureString(title)

            ' Calculate the X position to center the title on the page
            Dim x As Single = (page.Canvas.ClientSize.Width - size.Width) / 2

            ' Draw the first part of the title
            page.Canvas.DrawString("Your Account Information(", font1, brush1, x, y)

            ' Measure the size of the first part of the title
            size = font1.MeasureString("Your Account Information(")

            ' Update the X position for drawing the next part of the title
            x = x + size.Width

            ' Draw the second part of the title
            page.Canvas.DrawString("* = Required", font1, brush2, x, y)

            ' Measure the size of the second part of the title
            size = font1.MeasureString("* = Required")

            ' Update the X position for drawing the closing parenthesis of the title
            x = x + size.Width

            ' Draw the closing parenthesis of the title
            page.Canvas.DrawString(")", font1, brush1, x, y)

            ' Update the Y position after drawing the title
            y = y + size.Height

            ' Add a vertical spacing of 3
            y = y + 3

            ' Create a new PDF true type font for the description
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 8.0F, FontStyle.Italic))

            ' Set the text for the description
            Dim p As String = "Your information is not public, shared in anyway, or displayed on this site."

            ' Draw the description
            page.Canvas.DrawString(p, font2, brush1, 0, y)

            ' Return the updated Y position after drawing the form section
            Return y + font2.Height
        End Function

        Private Function DrawFormSection(ByVal label As String, ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Set the brush color for the background of the form field label
            Dim brush1 As PdfBrush = PdfBrushes.LightYellow

            ' Set the brush color for the text of the form field label
            Dim brush2 As PdfBrush = PdfBrushes.DarkSlateGray

            ' Create a new PDF true type font for the form field label
            Dim font As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Bold))

            ' Create a new PDF string format
            Dim format As New PdfStringFormat()

            ' Measure the height of the label text using the font
            Dim height As Single = font.MeasureString(label).Height

            ' Draw a rectangle as the background for the label
            page.Canvas.DrawRectangle(brush2, 0, y, page.Canvas.ClientSize.Width, height + 2)

            ' Draw the label text
            page.Canvas.DrawString(label, font, brush1, 2, y + 1)

            ' Update the Y position after drawing the label
            y = y + height + 2

            ' Create a new PDF pen for drawing a horizontal line
            Dim pen As New PdfPen(PdfBrushes.LightSkyBlue, 0.75F)

            ' Draw a horizontal line below the label
            page.Canvas.DrawLine(pen, 0, y, page.Canvas.ClientSize.Width, y)

            ' Return the updated Y position after drawing the form field
            Return y + 0.75F
        End Function

        Private Function DrawFormField(ByVal fieldNode As XPathNavigator, ByVal form As PdfForm, ByVal page As PdfPageBase, ByVal y As Single, ByVal fieldIndex As Integer) As Single
            ' Get the width of the page canvas
            Dim width As Single = page.Canvas.ClientSize.Width

            ' Set the padding value
            Dim padding As Single = 2

            ' Get the label attribute from the fieldNode element
            Dim label As String = fieldNode.GetAttribute("label", "")

            ' Create a new PDF true type font for the label
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 9.0F))

            ' Create a new PDF string format with right alignment and middle vertical alignment
            Dim format As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

            ' Calculate the maximum width for the label based on the page width and padding
            Dim labelMaxWidth As Single = width * 0.4F - 2 * padding

            ' Measure the size of the label text within the maximum width limit
            Dim labelSize As SizeF = font1.MeasureString(label, labelMaxWidth, format)

            ' Measure the height of the field based on its content
            Dim fieldHeight As Single = MeasureFieldHeight(fieldNode)

            ' Determine the overall height of the form field by choosing the larger value between the label size height and the field height
            Dim height As Single = If(labelSize.Height > fieldHeight, labelSize.Height, fieldHeight)

            ' Add additional space for padding and border
            height = height + 2

            ' Set the brush color for the form field background
            Dim brush As PdfBrush = PdfBrushes.SteelBlue

            ' Alternate the brush color for every other field using fieldIndex variable
            If fieldIndex Mod 2 = 1 Then
                brush = PdfBrushes.LightGreen
            End If

            ' Draw a rectangle as the background for the form field
            page.Canvas.DrawRectangle(brush, 0, y, width, height)

            ' Set the brush color for the label text
            Dim brush1 As PdfBrush = PdfBrushes.LightYellow

            ' Define the bounds of the label text within the allocated space
            Dim labelBounds As New RectangleF(padding, y, labelMaxWidth, height)

            ' Draw the label text on the page canvas
            page.Canvas.DrawString(label, font1, brush1, labelBounds, format)

            ' Calculate the maximum width for the form field based on the page width and padding
            Dim fieldMaxWidth As Single = width * 0.57F - 2 * padding

            ' Calculate the X position for drawing the form field
            Dim fieldX As Single = labelBounds.Right + 2 * padding

            ' Calculate the Y position for drawing the form field vertically centered within the allocated space
            Dim fieldY As Single = y + (height - fieldHeight) / 2

            ' Get the type attribute from the fieldNode element
            Dim fieldType As String = fieldNode.GetAttribute("type", "")

            ' Get the id attribute from the fieldNode element
            Dim fieldId As String = fieldNode.GetAttribute("id", "")

            ' Check if the field is marked as required
            Dim required As Boolean = "true" = fieldNode.GetAttribute("required", "")

            ' Determine the type of form field and create the corresponding PDF form field object
            Select Case fieldType
                Case "text", "password"
                    ' Create a text box field
                    Dim textField As New PdfTextBoxField(page, fieldId)
                    ' Set the bounds for the text box field
                    textField.Bounds = New RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight)
                    ' Set the border properties for the text box field
                    textField.BorderWidth = 0.75F
                    textField.BorderStyle = PdfBorderStyle.Solid
                    ' Set the required property for the text box field
                    textField.Required = required
                    ' Check if the field type is password and set the Password property accordingly
                    If "password" = fieldType Then
                        textField.Password = True
                    End If
                    ' Check if the field has multiple attribute and set the Multiline and Scrollable properties accordingly
                    If "true" = fieldNode.GetAttribute("multiple", "") Then
                        textField.Multiline = True
                        textField.Scrollable = True
                    End If
                    ' Add the text box field to the form
                    form.Fields.Add(textField)

                Case "checkbox"
                    ' Create a check box field
                    Dim checkboxField As New PdfCheckBoxField(page, fieldId)
                    ' Calculate the dimensions for the check box
                    Dim checkboxWidth As Single = fieldHeight - 2 * padding
                    Dim checkboxHeight As Single = checkboxWidth
                    ' Set the bounds for the check box field
                    checkboxField.Bounds = New RectangleF(fieldX, fieldY + padding, checkboxWidth, checkboxHeight)
                    ' Set the border properties for the check box field
                    checkboxField.BorderWidth = 0.75F
                    checkboxField.Style = PdfCheckBoxStyle.Cross
                    ' Set the required property for the check box field
                    checkboxField.Required = required
                    ' Add the check box field to the form
                    form.Fields.Add(checkboxField)

                Case "list"
                    ' Get the item nodes within the field node
                    Dim itemNodes As XPathNodeIterator = fieldNode.Select("item")

                    ' Check if the field has the "multiple" attribute set to "true"
                    If "true" = fieldNode.GetAttribute("multiple", "") Then
                        ' Create a list box field with multiple selection
                        Dim listBoxField As New PdfListBoxField(page, fieldId)
                        ' Set the bounds for the list box field
                        listBoxField.Bounds = New RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight)
                        listBoxField.BorderWidth = 0.75F
                        listBoxField.MultiSelect = True
                        listBoxField.Font = New PdfFont(PdfFontFamily.Helvetica, 9.0F)
                        listBoxField.Required = required

                        ' Add items into the list box
                        For Each itemNode As XPathNavigator In itemNodes
                            Dim text As String = itemNode.SelectSingleNode("text()").Value
                            listBoxField.Items.Add(New PdfListFieldItem(text, text))
                        Next itemNode
                        listBoxField.SelectedIndex = 0
                        ' Add the listbox field to the form
                        form.Fields.Add(listBoxField)
                        Exit Select
                    End If

                    ' Check if there are item nodes and the count is less than or equal to 3
                    If itemNodes IsNot Nothing AndAlso itemNodes.Count <= 3 Then
                        ' Create a radio button list field
                        Dim radioButtonListFile As New PdfRadioButtonListField(page, fieldId)
                        radioButtonListFile.Required = required

                        ' Add items into the radio button list
                        Dim fieldItemHeight As Single = fieldHeight / itemNodes.Count
                        Dim radioButtonWidth As Single = fieldItemHeight - 2 * padding
                        Dim radioButtonHeight As Single = radioButtonWidth

                        For Each itemNode As XPathNavigator In itemNodes
                            Dim text As String = itemNode.SelectSingleNode("text()").Value
                            Dim fieldItem As New PdfRadioButtonListItem(text)
                            fieldItem.BorderWidth = 0.75F
                            fieldItem.Bounds = New RectangleF(fieldX, fieldY + padding, radioButtonWidth, radioButtonHeight)
                            radioButtonListFile.Items.Add(fieldItem)

                            Dim fieldItemLabelX As Single = fieldX + radioButtonWidth + padding
                            Dim fieldItemLabelSize As SizeF = font1.MeasureString(text)
                            Dim fieldItemLabelY As Single = fieldY + (fieldItemHeight - fieldItemLabelSize.Height) / 2
                            page.Canvas.DrawString(text, font1, brush1, fieldItemLabelX, fieldItemLabelY)

                            fieldY = fieldY + fieldItemHeight
                        Next itemNode
                        ' Add the radio button list field to the form
                        form.Fields.Add(radioButtonListFile)

                        Exit Select
                    End If

                    ' Combo box
                    Dim comboBoxField As New PdfComboBoxField(page, fieldId)
                    comboBoxField.Bounds = New RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight)
                    comboBoxField.BorderWidth = 0.75F
                    comboBoxField.Font = New PdfFont(PdfFontFamily.Helvetica, 9.0F)
                    comboBoxField.Required = required

                    ' Add items into the combo box
                    For Each itemNode As XPathNavigator In itemNodes
                        Dim text As String = itemNode.SelectSingleNode("text()").Value
                        comboBoxField.Items.Add(New PdfListFieldItem(text, text))
                    Next itemNode
                    ' Add the combo box field to the form
                    form.Fields.Add(comboBoxField)

            End Select

            ' Check if the field is required and draw a red asterisk flag
            If required Then
                Dim flagX As Single = width * 0.97F + padding
                Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10.0F, FontStyle.Bold))
                Dim size As SizeF = font3.MeasureString("*")
                Dim flagY As Single = y + (height - size.Height) / 2
                page.Canvas.DrawString("*", font3, PdfBrushes.Red, flagX, flagY)
            End If

            Return y + height
        End Function
        Private Function MeasureFieldHeight(ByVal fieldNode As XPathNavigator) As Single
            ' Get the type attribute from the fieldNode element
            Dim fieldType As String = fieldNode.GetAttribute("type", "")

            ' Set the default height for form fields
            Dim defaultHeight As Single = 16.0F

            ' Determine the height of the form field based on its type
            Select Case fieldType
                Case "text", "password"
                    ' Check if the field has the "multiple" attribute set to "true"
                    If "true" = fieldNode.GetAttribute("multiple", "") Then
                        ' Return triple the default height for a multiline text or password field
                        Return defaultHeight * 3
                    End If
                    ' Return the default height for a single-line text or password field
                    Return defaultHeight

                Case "checkbox"
                    ' Return the default height for a checkbox field
                    Return defaultHeight

                Case "list"
                    ' Check if the field has the "multiple" attribute set to "true"
                    If "true" = fieldNode.GetAttribute("multiple", "") Then
                        ' Return triple the default height for a multiple selection list box field
                        Return defaultHeight * 3
                    End If
                    ' Get the item nodes within the field node
                    Dim itemNodes As XPathNodeIterator = fieldNode.Select("item")
                    ' Check if there are item nodes and the count is less than or equal to 3
                    If itemNodes IsNot Nothing AndAlso itemNodes.Count <= 3 Then
                        ' Return triple the default height for a radio button list field with few options
                        Return defaultHeight * 3
                    End If
                    ' Return the default height for a combo box or a radio button list field with more options
                    Return defaultHeight

            End Select

            ' If the field type is not recognized, throw an exception
            Dim message As String = String.Format("Invalid field type: {0}", fieldType)
            Throw New ArgumentException(message)
        End Function

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
