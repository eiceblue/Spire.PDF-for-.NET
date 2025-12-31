Imports Spire.Pdf
Imports Spire.Pdf.AutomaticFields
Imports Spire.Pdf.Graphics

Namespace AutomaticField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Set the author name in the document information
			doc.DocumentInformation.Author = "Spire.Pdf"

			' Create a PdfUnitConvertor object for unit conversion
			Dim unitCvtr As New PdfUnitConvertor()

			' Create a PdfMargins object to set margins
			Dim margin As New PdfMargins()

			' Convert 2.54 centimeters to points and set it as the top margin
			margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the bottom margin equal to the top margin
			margin.Bottom = margin.Top

			' Convert 3.17 centimeters to points and set it as the left margin
			margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

			' Set the right margin equal to the left margin
			margin.Right = margin.Left

			' Add a section to the document
			Dim section As PdfSection = doc.Sections.Add()

			' Set the page size of the section to A4
			section.PageSettings.Size = PdfPageSize.A4

			' Set the margins of the section
			section.PageSettings.Margins = margin

			' Add a page to the section
			Dim page As PdfPageBase = section.Pages.Add()

			' Call a function to draw automatic fields on the page
			DrawAutomaticField(page)

			' Save the document to a file named "AutomaticField.pdf"
			doc.SaveToFile("AutomaticField.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("AutomaticField.pdf")
		End Sub

		Private Sub DrawAutomaticField(ByVal page As PdfPageBase)
			' Define the initial value for the y-coordinate
			Dim y As Single = 20

			' Create a PdfBrush for the text color
			Dim brush1 As PdfBrush = PdfBrushes.CadetBlue

			' Create a PdfTrueTypeFont object with Arial font, size 16, and bold style
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font1 As New PdfTrueTypeFont("Arial", 16.0F, FontStyle.Bold, True)
			' =============================================================================

			' Create a PdfStringFormat object for text alignment
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)

			' Draw the title "Automatic Field List" on the page
			page.Canvas.DrawString("Automatic Field List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

			' Update the y-coordinate position
			y = y + font1.MeasureString("Automatic Field List", format1).Height
			y = y + 15

			' Define an array of field names
			Dim fieldList() As String = {"DateTimeField", "CreationDateField", "DocumentAuthorField", "SectionNumberField", "SectionPageNumberField", "SectionPageCountField", "PageNumberField", "PageCountField", "DestinationPageNumberField", "CompositeField"}

			' Create a PdfTrueTypeFont object with Arial font and size 12
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
			' =============================================================================

			' Create a PdfStringFormat object for field name formatting
			Dim fieldNameFormat As New PdfStringFormat()

			' Set the MeasureTrailingSpaces property to true to measure trailing spaces in the field name
			fieldNameFormat.MeasureTrailingSpaces = True

			' Iterate through each field name in the field list
			For Each fieldName As String In fieldList
				' Create the text to display, including the field name followed by a colon
				Dim text As String = String.Format("{0}: ", fieldName)

				' Draw the field name text on the page using the specified font and color
				page.Canvas.DrawString(text, font, PdfBrushes.DodgerBlue, 0, y)

				' Measure the width of the drawn text
				Dim x As Single = font.MeasureString(text, fieldNameFormat).Width

				' Create a rectangle for the bounds of the automatic field
				Dim bounds As New RectangleF(x, y, 200, font.Height)

				' Call a function to draw the specific automatic field within the bounds
				DrawAutomaticField(fieldName, page, bounds)

				' Update the y-coordinate position
				y = y + font.Height + 8
			Next fieldName
		End Sub

		Private Sub DrawAutomaticField(ByVal fieldName As String, ByVal page As PdfPageBase, ByVal bounds As RectangleF)
			' Create a PdfTrueTypeFont object with Arial font, size 12, and italic style
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Italic))

			' Create a PdfBrush for the text color
			Dim brush As PdfBrush = PdfBrushes.OrangeRed

			' Create a PdfStringFormat object for text alignment and vertical alignment
			Dim format As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)

			' Check if the field name is "DateTimeField"
			If "DateTimeField" = fieldName Then
				' Create a new PdfDateTimeField object
				Dim field As New PdfDateTimeField()

				' Set the font of the field to the specified font
				field.Font = font

				' Set the brush of the field to the specified brush
				field.Brush = brush

				' Set the string format of the field to the specified format
				field.StringFormat = format

				' Set the bounds of the field to the specified bounds
				field.Bounds = bounds

				' Set the date format string of the field to "yyyy-MM-dd HH:mm:ss"
				field.DateFormatString = "yyyy-MM-dd HH:mm:ss"

				' Draw the field on the page canvas
				field.Draw(page.Canvas)
			End If

			' Create new PdfCreationDateField object, PdfDocumentAuthorField, PdfSectionNumberField, PdfSectionPageNumberField,
			' PdfSectionPageCountField, PdfPageNumberField£¬PdfPageCountField£¬PdfDestinationPageNumberField£¬CompositeField

			If "CreationDateField" = fieldName Then
				Dim field As New PdfCreationDateField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.DateFormatString = "yyyy-MM-dd HH:mm:ss"
				field.Draw(page.Canvas)
			End If

			If "DocumentAuthorField" = fieldName Then
				Dim field As New PdfDocumentAuthorField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Draw(page.Canvas)
			End If


			If "SectionNumberField" = fieldName Then
				Dim field As New PdfSectionNumberField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Draw(page.Canvas)
			End If

			If "SectionPageNumberField" = fieldName Then
				Dim field As New PdfSectionPageNumberField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Draw(page.Canvas)
			End If

			If "SectionPageCountField" = fieldName Then
				Dim field As New PdfSectionPageCountField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Draw(page.Canvas)
			End If

			If "PageNumberField" = fieldName Then
				Dim field As New PdfPageNumberField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Draw(page.Canvas)
			End If

			If "PageCountField" = fieldName Then
				Dim field As New PdfPageCountField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Draw(page.Canvas)
			End If

			If "DestinationPageNumberField" = fieldName Then
				Dim field As New PdfDestinationPageNumberField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.Page = TryCast(page, PdfNewPage)
				field.Draw(page.Canvas)
			End If

			If "CompositeField" = fieldName Then
				Dim field1 As New PdfSectionPageNumberField()
				field1.NumberStyle = PdfNumberStyle.LowerRoman
				Dim field2 As New PdfSectionPageCountField()
				Dim fields As New PdfCompositeField()
				fields.Font = font
				fields.Brush = brush
				fields.StringFormat = format
				fields.Bounds = bounds
				fields.AutomaticFields = New PdfAutomaticField() { field1, field2 }
				fields.Text = "section page {0} of {1}"
				fields.Draw(page.Canvas)
			End If
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
