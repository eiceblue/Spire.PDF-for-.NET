Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddPageNumber
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\Sample8.pdf"

			'open a pdf document
			Dim document As New PdfDocument(input)

			'get pdf margins
			Dim margin As PdfMargins = document.PageSettings.Margins

			Dim startNumber As Integer = 1

			'get the count of pages
			Dim pageCount As Integer = document.Pages.Count

			'set page number
			For Each page As PdfPageBase In document.Pages
				page.Canvas.SetTransparency(0.5f)
				Dim brush As PdfBrush = PdfBrushes.Black
				Dim pen As New PdfPen(brush, 0.75f)
				Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic), True)
				Dim format As New PdfStringFormat(PdfTextAlignment.Right)
				format.MeasureTrailingSpaces = True
				Dim space As Single = font.Height * 0.75f
				Dim x As Single = margin.Left
				Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
				Dim y As Single = page.Canvas.ClientSize.Height - margin.Bottom + space
				page.Canvas.DrawLine(pen, x, y, x + width, y)
				y = y + 1
				Dim numberLabel As String = String.Format("{0} of {1}", startNumber, pageCount)
				startNumber += 1
				page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format)
				page.Canvas.SetTransparency(1)
			Next page

			Dim output As String = "AddPageNumber.pdf"

			'save pdf document
			document.SaveToFile(output)

			'Launching the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
