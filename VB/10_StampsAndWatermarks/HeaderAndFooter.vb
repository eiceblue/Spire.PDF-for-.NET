Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace HeaderAndFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\..\Data\HeaderAndFooter.pdf"

			'Open the document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)
			Dim brush As PdfBrush = PdfBrushes.Black
			Dim pen As New PdfPen(brush, 0.75f)
			Dim font As New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Italic), True)
			Dim rightAlign As New PdfStringFormat(PdfTextAlignment.Right)
			Dim leftAlign As New PdfStringFormat(PdfTextAlignment.Left)
			rightAlign.MeasureTrailingSpaces = True
			rightAlign.MeasureTrailingSpaces = True
			Dim margin As PdfMargins = doc.PageSettings.Margins

			Dim space As Single = font.Height * 0.75f
			Dim x As Single = 0
			Dim y As Single = 0
			Dim width As Single=0

			'Create a new pdf document
			Dim newPdf As New PdfDocument()
			Dim newPage As PdfPageBase

			For Each page As PdfPageBase In doc.Pages
				'Add new page
				newPage = newPdf.Pages.Add(page.Size,New PdfMargins(0))

				newPage.Canvas.SetTransparency(0.5f)
				x = margin.Left
				width = page.Canvas.ClientSize.Width - margin.Left - margin.Right
				y = margin.Top - space

				'Draw header line
				newPage.Canvas.DrawLine(pen, x, y + 15, x + width, y + 15)
				y = y+10 - font.Height

				'Draw header image into newPage
				newPage.Canvas.SetTransparency(0.5f)
				Dim headerImage As PdfImage= PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
				newPage.Canvas.DrawImage(headerImage, New PointF(0, 0))

				'Draw header text into newPage
				newPage.Canvas.DrawString("Demo of Spire.Pdf", font, brush, x + width, y, rightAlign)

				'Draw footer image into newPage
				Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")
				newPage.Canvas.DrawImage(footerImage, New PointF(0, newPage.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height))

				brush = PdfBrushes.DarkBlue
				font = New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Bold), True)
				y = newPage.Canvas.ClientSize.Height - margin.Bottom - font.Height

				'Draw footer text into newPage
				newPage.Canvas.DrawString("Created by E-iceblue Co,.Ltd", font, brush, x, y, leftAlign)

				newPage.Canvas.SetTransparency(1)

				'Draw the page into newPage
				page.CreateTemplate().Draw(newPage.Canvas, New PointF(0, 0))
			Next page

			Dim output As String = "Output.pdf"

			'Save the document
			newPdf.SaveToFile(output)
			newPdf.Close()

			'Launch the Pdf file
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
