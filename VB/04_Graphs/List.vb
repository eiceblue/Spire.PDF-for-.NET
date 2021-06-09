Imports System.Data.OleDb
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Lists

Namespace List
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Margin
			Dim unitCvtr As New PdfUnitConvertor()
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

			Dim y As Single = 10

			'Title
			Dim brush1 As PdfBrush = PdfBrushes.Black
			Dim font1 As New PdfTrueTypeFont(New Font("Arial", 16f, FontStyle.Bold), True)
			Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
			page.Canvas.DrawString("Categories List", font1, brush1, page.Canvas.ClientSize.Width \ 2, y, format1)
			y = y + font1.MeasureString("Categories List", format1).Height
			y = y + 5

			Dim rctg As New RectangleF(New PointF(0, 0), page.Canvas.ClientSize)
			Dim brush As New PdfLinearGradientBrush(rctg, Color.Navy, Color.OrangeRed, PdfLinearGradientMode.Vertical)
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold)
			Dim formatted As String = "Beverages" & vbLf & "Condiments" & vbLf & "Confections" & vbLf & "Dairy Products" & vbLf & "Grains/Cereals" & vbLf & "Meat/Poultry" & vbLf & "Produce" & vbLf & "Seafood"

			'Create a list
			Dim list As New PdfList(formatted)
			list.Font = font
			list.Indent = 8
			list.TextIndent = 5
			list.Brush = brush

			'Draw the list on the page
			Dim result As PdfLayoutResult = list.Draw(page, 0, y)
			y = result.Bounds.Bottom

			'Create another list
			Dim sortedList As New PdfSortedList(formatted)
			sortedList.Font = font
			sortedList.Indent = 8
			sortedList.TextIndent = 5
			sortedList.Brush = brush
			'Draw the list on the page
			Dim result2 As PdfLayoutResult = sortedList.Draw(page, 0, y)

			y = result2.Bounds.Bottom
			Dim marker1 As New PdfOrderedMarker(PdfNumberStyle.LowerRoman, New PdfFont(PdfFontFamily.Helvetica, 12f))
			Dim list2 As New PdfSortedList(formatted)
			list2.Font = font
			list2.Marker = marker1
			list2.Indent = 8
			list2.TextIndent = 5
			list2.Brush = brush
			Dim result3 As PdfLayoutResult = list2.Draw(page, 0, y)
			y = result3.Bounds.Bottom

			Dim marker2 As New PdfOrderedMarker(PdfNumberStyle.LowerLatin, New PdfFont(PdfFontFamily.Helvetica, 12f))
			Dim list3 As New PdfSortedList(formatted)
			list3.Font = font
			list3.Marker = marker2
			list3.Indent = 8
			list3.TextIndent = 5
			list3.Brush = brush
			list3.Draw(page, 0, y)

			'Save pdf file
			doc.SaveToFile("List.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("List.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
