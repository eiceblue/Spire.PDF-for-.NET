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
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'Set the margins
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			SetDocumentTemplate(doc, PdfPageSize.A4, margin)

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(0))

			Dim y As Single = 10

			'Add a title
			y = DrawPageTitle(page, y)

			'Load form config data
			Using stream As Stream = File.OpenRead("..\..\..\..\..\..\Data\AddFormField-Form.xml")
				Dim xpathDoc As New XPathDocument(stream)
				Dim sectionNodes As XPathNodeIterator = xpathDoc.CreateNavigator().Select("/form/section")
				Dim fieldIndex As Integer = 0
				For Each sectionNode As XPathNavigator In sectionNodes
					'Draw section label
					Dim sectionLabel As String = sectionNode.GetAttribute("name", "")
					y = DrawFormSection(sectionLabel, page, y)

					Dim fieldNodes As XPathNodeIterator = sectionNode.Select("field")
					For Each fieldNode As XPathNavigator In fieldNodes
						y= DrawFormField(fieldNode, doc.Form, page, y, fieldIndex)
						fieldIndex += 1
					Next fieldNode
				Next sectionNode
			End Using

			'Draw button
			y = y + 10
			Dim buttonWidth As Single = 80
			Dim buttonX As Single = (page.Canvas.ClientSize.Width - buttonWidth) / 2
			Dim buttonBounds As New RectangleF(buttonX, y, buttonWidth, 16f)
			Dim button As New PdfButtonField(page, "submit")
			button.Text = "Submit"
			button.Bounds = buttonBounds
			Dim submitAction As New PdfSubmitAction("http://www.e-iceblue.com")
			button.Actions.MouseUp = submitAction
			doc.Form.Fields.Add(button)

			'Save pdf file.
			doc.SaveToFile("AddFormField.pdf")
			doc.Close()

			'Launch the file.
			PDFDocumentViewer("AddFormField.pdf")
		End Sub

		Private Sub SetDocumentTemplate(ByVal doc As PdfDocument, ByVal pageSize As SizeF, ByVal margin As PdfMargins)
			Dim leftSpace As New PdfPageTemplateElement(margin.Left, pageSize.Height)
			doc.Template.Left = leftSpace

			Dim topSpace As New PdfPageTemplateElement(pageSize.Width, margin.Top)
			topSpace.Foreground = True
			doc.Template.Top = topSpace

			'Draw header label
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic))
			Dim format As New PdfStringFormat(PdfTextAlignment.Right)
			Dim label As String = "Demo of Spire.Pdf"
			Dim size As SizeF = font.MeasureString(label, format)
			Dim y As Single = topSpace.Height - font.Height - 1
			Dim pen As New PdfPen(Color.Black, 0.75f)
			topSpace.Graphics.SetTransparency(0.5f)
			topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)
			y = y - 1 - size.Height
			topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format)

			Dim rightSpace As New PdfPageTemplateElement(margin.Right, pageSize.Height)
			doc.Template.Right = rightSpace

			Dim bottomSpace As New PdfPageTemplateElement(pageSize.Width, margin.Bottom)
			bottomSpace.Foreground = True
			doc.Template.Bottom = bottomSpace

			'Draw footer label
			y = font.Height + 1
			bottomSpace.Graphics.SetTransparency(0.5f)
			bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)
			y = y + 1
			Dim pageNumber As New PdfPageNumberField()
			Dim pageCount As New PdfPageCountField()
			Dim pageNumberLabel As New PdfCompositeField()
			pageNumberLabel.AutomaticFields = New PdfAutomaticField() { pageNumber, pageCount }
			pageNumberLabel.Brush = PdfBrushes.Black
			pageNumberLabel.Font = font
			pageNumberLabel.StringFormat = format
			pageNumberLabel.Text = "page {0} of {1}"
			pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y)

			Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
			Dim pageLeftTop As New PointF(-margin.Left, -margin.Top)
			Dim header As New PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension)
			header.Foreground = False
			header.Graphics.SetTransparency(0.5f)
			header.Graphics.DrawImage(headerImage, 0, 0)
			doc.Template.Stamps.Add(header)

			Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")
			y = pageSize.Height - footerImage.PhysicalDimension.Height
			Dim footerLocation As New PointF(-margin.Left, y)
			Dim footer As New PdfPageTemplateElement(footerLocation, footerImage.PhysicalDimension)
			footer.Foreground = False
			footer.Graphics.SetTransparency(0.5f)
			footer.Graphics.DrawImage(footerImage, 0, 0)
			doc.Template.Stamps.Add(footer)
		End Sub

		Private Function DrawPageTitle(ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim brush1 As PdfBrush = PdfBrushes.MidnightBlue
			Dim brush2 As PdfBrush = PdfBrushes.Red
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Bold))
			Dim title As String = "Your Account Information(* = Required)"
			Dim size As SizeF = font1.MeasureString(title)
			Dim x As Single = (page.Canvas.ClientSize.Width - size.Width) / 2
			page.Canvas.DrawString("Your Account Information(", font1, brush1, x, y)
			size = font1.MeasureString("Your Account Information(")
			x = x + size.Width
			page.Canvas.DrawString("* = Required", font1, brush2, x, y)
			size = font1.MeasureString("* = Required")
			x = x + size.Width
			page.Canvas.DrawString(")", font1, brush1, x, y)
			y = y + size.Height

			y = y + 3
			Dim font2 As New PdfTrueTypeFont(New Font("Arial", 8f, FontStyle.Italic))
			Dim p As String = "Your information is not public, shared in anyway, or displayed on this site."
			page.Canvas.DrawString(p, font2, brush1, 0, y)

			Return y + font2.Height
		End Function

		Private Function DrawFormSection(ByVal label As String, ByVal page As PdfPageBase, ByVal y As Single) As Single
			Dim brush1 As PdfBrush = PdfBrushes.LightYellow
			Dim brush2 As PdfBrush = PdfBrushes.DarkSlateGray
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Bold))
			Dim format As New PdfStringFormat()
			Dim height As Single = font.MeasureString(label).Height
			page.Canvas.DrawRectangle(brush2, 0, y, page.Canvas.ClientSize.Width, height + 2)
			page.Canvas.DrawString(label, font, brush1, 2, y + 1)
			y = y + height + 2
			Dim pen As New PdfPen(PdfBrushes.LightSkyBlue, 0.75f)
			page.Canvas.DrawLine(pen, 0, y, page.Canvas.ClientSize.Width, y)
			Return y + 0.75f
		End Function

		Private Function DrawFormField(ByVal fieldNode As XPathNavigator, ByVal form As PdfForm, ByVal page As PdfPageBase, ByVal y As Single, ByVal fieldIndex As Integer) As Single
			Dim width As Single = page.Canvas.ClientSize.Width
			Dim padding As Single = 2

			'Measure field label
			Dim label As String = fieldNode.GetAttribute("label", "")
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 9f))
			Dim format As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)
			Dim labelMaxWidth As Single = width * 0.4f - 2 * padding
			Dim labelSize As SizeF = font1.MeasureString(label, labelMaxWidth, format)

			'Measure field height
			Dim fieldHeight As Single = MeasureFieldHeight(fieldNode)

			Dim height As Single = If(labelSize.Height > fieldHeight, labelSize.Height, fieldHeight)
			height = height + 2

			'Draw background
			Dim brush As PdfBrush = PdfBrushes.SteelBlue
			If fieldIndex Mod 2 = 1 Then
				brush = PdfBrushes.LightGreen
			End If
			page.Canvas.DrawRectangle(brush, 0, y, width, height)

			'Draw field label
			Dim brush1 As PdfBrush = PdfBrushes.LightYellow
			Dim labelBounds As New RectangleF(padding, y, labelMaxWidth, height)
			page.Canvas.DrawString(label, font1, brush1, labelBounds, format)

			'Draw field
			Dim fieldMaxWidth As Single = width * 0.57f - 2 * padding
			Dim fieldX As Single = labelBounds.Right + 2 * padding
			Dim fieldY As Single = y + (height - fieldHeight) / 2
			Dim fieldType As String = fieldNode.GetAttribute("type", "")
			Dim fieldId As String = fieldNode.GetAttribute("id", "")
			Dim required As Boolean = "true" = fieldNode.GetAttribute("required", "")
			Select Case fieldType
				Case "text", "password"
					Dim textField As New PdfTextBoxField(page, fieldId)
					textField.Bounds = New RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight)
					textField.BorderWidth = 0.75f
					textField.BorderStyle = PdfBorderStyle.Solid
					textField.Required = required
					If "password" = fieldType Then
						textField.Password = True
					End If
					If "true" = fieldNode.GetAttribute("multiple", "") Then
						textField.Multiline = True
						textField.Scrollable = True
					End If
					form.Fields.Add(textField)
				Case "checkbox"
					Dim checkboxField As New PdfCheckBoxField(page, fieldId)
					Dim checkboxWidth As Single = fieldHeight - 2 * padding
					Dim checkboxHeight As Single = checkboxWidth
					checkboxField.Bounds = New RectangleF(fieldX, fieldY + padding, checkboxWidth, checkboxHeight)
					checkboxField.BorderWidth = 0.75f
					checkboxField.Style = PdfCheckBoxStyle.Cross
					checkboxField.Required = required
					form.Fields.Add(checkboxField)

				Case "list"
					Dim itemNodes As XPathNodeIterator = fieldNode.Select("item")
					If "true" = fieldNode.GetAttribute("multiple", "") Then
						Dim listBoxField As New PdfListBoxField(page, fieldId)
						listBoxField.Bounds = New RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight)
						listBoxField.BorderWidth = 0.75f
						listBoxField.MultiSelect = True
						listBoxField.Font = New PdfFont(PdfFontFamily.Helvetica, 9f)
						listBoxField.Required = required
						'Add items into list box.
						For Each itemNode As XPathNavigator In itemNodes
							Dim text As String = itemNode.SelectSingleNode("text()").Value
							listBoxField.Items.Add(New PdfListFieldItem(text, text))
						Next itemNode
						listBoxField.SelectedIndex = 0
						form.Fields.Add(listBoxField)

						Exit Select
					End If
					If itemNodes IsNot Nothing AndAlso itemNodes.Count <= 3 Then
						Dim radioButtonListFile As New PdfRadioButtonListField(page, fieldId)
						radioButtonListFile.Required = required
						'Add items into radio button list.
						Dim fieldItemHeight As Single = fieldHeight / itemNodes.Count
						Dim radioButtonWidth As Single = fieldItemHeight - 2 * padding
						Dim radioButtonHeight As Single = radioButtonWidth
						For Each itemNode As XPathNavigator In itemNodes
							Dim text As String = itemNode.SelectSingleNode("text()").Value
							Dim fieldItem As New PdfRadioButtonListItem(text)
							fieldItem.BorderWidth = 0.75f
							fieldItem.Bounds = New RectangleF(fieldX, fieldY + padding, radioButtonWidth, radioButtonHeight)
							radioButtonListFile.Items.Add(fieldItem)

							Dim fieldItemLabelX As Single = fieldX + radioButtonWidth + padding
							Dim fieldItemLabelSize As SizeF = font1.MeasureString(text)
							Dim fieldItemLabelY As Single = fieldY + (fieldItemHeight - fieldItemLabelSize.Height) / 2
							page.Canvas.DrawString(text, font1, brush1, fieldItemLabelX, fieldItemLabelY)

							fieldY = fieldY + fieldItemHeight
						Next itemNode
						form.Fields.Add(radioButtonListFile)

						Exit Select
					End If

					'Combo box
					Dim comboBoxField As New PdfComboBoxField(page, fieldId)
					comboBoxField.Bounds = New RectangleF(fieldX, fieldY, fieldMaxWidth, fieldHeight)
					comboBoxField.BorderWidth = 0.75f
					comboBoxField.Font = New PdfFont(PdfFontFamily.Helvetica, 9f)
					comboBoxField.Required = required
					'Add items into combo box.
					For Each itemNode As XPathNavigator In itemNodes
						Dim text As String = itemNode.SelectSingleNode("text()").Value
						comboBoxField.Items.Add(New PdfListFieldItem(text, text))
					Next itemNode
					form.Fields.Add(comboBoxField)

			End Select

			If required Then
				'Draw *
				Dim flagX As Single = width * 0.97f + padding
				Dim font3 As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
				Dim size As SizeF = font3.MeasureString("*")
				Dim flagY As Single = y + (height - size.Height) / 2
				page.Canvas.DrawString("*", font3, PdfBrushes.Red, flagX, flagY)
			End If

			Return y + height
		End Function

		Private Function MeasureFieldHeight(ByVal fieldNode As XPathNavigator) As Single
			Dim fieldType As String = fieldNode.GetAttribute("type", "")
			Dim defaultHeight As Single = 16f
			Select Case fieldType
				Case "text", "password"
					If "true" = fieldNode.GetAttribute("multiple", "") Then
						Return defaultHeight * 3
					End If
					Return defaultHeight

				Case "checkbox"
					Return defaultHeight

				Case "list"
					If "true" = fieldNode.GetAttribute("multiple", "") Then
						Return defaultHeight * 3
					End If
					Dim itemNodes As XPathNodeIterator = fieldNode.Select("item")
					If itemNodes IsNot Nothing AndAlso itemNodes.Count <= 3 Then
						Return defaultHeight * 3
					End If
					Return defaultHeight

			End Select
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
