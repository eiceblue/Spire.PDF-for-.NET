Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Lists

Namespace SimpleList
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			Dim y As Single = 10

			'title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold), True)
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)
			y = y + font1.MeasureString("Categories List", format1).Height
			y = y + 5

			Dim rctg As New RectangleF(New PointF(0, 0), page.Canvas.ClientSize)
			Dim brush As New PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical)
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold)
			Dim formatted As String = "Beverages" & vbLf & "Condiments" & vbLf & "Confections" & vbLf & "Dairy Products" & vbLf & "Grains/Cereals" & vbLf & "Meat/Poultry" & vbLf & "Produce" & vbLf & "Seafood"

			Dim list As New PdfList(formatted)
			list.Font = font
			list.Indent = 8
			list.TextIndent = 5
			list.Brush = brush
			Dim result As PdfLayoutResult = list.Draw(page, 0, y)
			y = result.Bounds.Bottom

			Dim sortedList As New PdfSortedList(formatted)
			sortedList.Font = font
			sortedList.Indent = 8
			sortedList.TextIndent = 5
			sortedList.Brush = brush
			sortedList.Draw(page, 0, y)

			'Save pdf file.
			doc.SaveToFile("SimpleList.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("SimpleList.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
