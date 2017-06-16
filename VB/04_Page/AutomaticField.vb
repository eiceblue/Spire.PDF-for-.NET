Imports Spire.Pdf
Imports Spire.Pdf.AutomaticFields
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace AutomaticField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()
			doc.DocumentInformation.Author = "Spire.Pdf"

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			For i As Integer = 1 To 3
				'create section
				Dim section As PdfSection = doc.Sections.Add()
				section.PageSettings.Size = PdfPageSize.A4
				section.PageSettings.Margins = margin

				For j As Integer = 0 To i - 1
					' Create one page
					Dim page As PdfPageBase = section.Pages.Add()
					DrawAutomaticField(page)
				Next j
			Next i

			'Save pdf file.
			doc.SaveToFile("AutomaticField.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("AutomaticField.pdf")
		End Sub

		Private Sub DrawAutomaticField(ByVal page As PdfPageBase)
			Dim y As Single = 0

			'title
			Dim brush1 As PdfBrush = PdfBrushes.CadetBlue
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold))
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Automatic Field List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Automatic Field List", format1).Height
			y = y + 5

			Dim fieldList() As String = { "DateTimeField", "CreationDateField", "DocumentAuthorField", "SectionNumberField", "SectionPageNumberField", "SectionPageCountField", "PageNumberField", "PageCountField", "DestinationPageNumberField", "CompositeField" }
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f))
			Dim fieldNameFormat As New PdfStringFormat()
			fieldNameFormat.MeasureTrailingSpaces = True
			For Each fieldName As String In fieldList
				'draw field name
				Dim text As String = String.Format("{0}: ", fieldName)
				page.Canvas.DrawString(text, font, PdfBrushes.DodgerBlue, 0, y)
				Dim x As Single = font.MeasureString(text, fieldNameFormat).Width
				Dim bounds As New RectangleF(x, y, 200, font.Height)
				DrawAutomaticField(fieldName, page, bounds)
				y = y + font.Height + 3
			Next fieldName
		End Sub

		Private Sub DrawAutomaticField(ByVal fieldName As String, ByVal page As PdfPageBase, ByVal bounds As RectangleF)
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic))
			Dim brush As PdfBrush = PdfBrushes.OrangeRed
			Dim format As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)

			If "DateTimeField" = fieldName Then
				Dim field As New PdfDateTimeField()
				field.Font = font
				field.Brush = brush
				field.StringFormat = format
				field.Bounds = bounds
				field.DateFormatString = "yyyy-MM-dd HH:mm:ss"
				field.Draw(page.Canvas)
			End If

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
