Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddTextInHeaderAndFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim path As String = "..\..\..\..\..\..\Data\"
			'pdf file 
			Dim input As String = path & "Sample4.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			Dim brush As PdfBrush = PdfBrushes.Black
			Dim pen As New PdfPen(brush, 0.75f)
			Dim font As New PdfTrueTypeFont(New Font("Arial", 9f, FontStyle.Italic), True)
			Dim leftAlign As New PdfStringFormat(PdfTextAlignment.Left)
			Dim rightAlign As New PdfStringFormat(PdfTextAlignment.Right)
			leftAlign.MeasureTrailingSpaces = True
			rightAlign.MeasureTrailingSpaces = True
			Dim margin As PdfMargins = doc.PageSettings.Margins

			Dim space As Single = font.Height * 0.75f
			Dim x As Single = 0
			Dim y As Single = 0
			Dim width As Single = 0

			For Each page As PdfPageBase In doc.Pages
				page.Canvas.SetTransparency(0.5f)
				x = margin.Left
				width = page.Canvas.ClientSize.Width - margin.Left - margin.Right
				y = margin.Top - space
				page.Canvas.DrawLine(pen, x, y, x + width, y)
				y = y - 1 - font.Height

				'draw header text into page
				page.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x, y, leftAlign)

				brush = PdfBrushes.Blue
				font = New PdfTrueTypeFont(New Font("Arial", 8f, FontStyle.Regular), True)
				y = page.Canvas.ClientSize.Height - margin.Bottom - font.Height

				'draw footer text into page
				page.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x + width, y, rightAlign)

				page.Canvas.SetTransparency(1)
			Next page

			Dim output As String = "AddTextInHeaderAndFooter.pdf"

			'Save pdf file.
			doc.SaveToFile(output)
			doc.Close()

			'Launching the Pdf file.
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
