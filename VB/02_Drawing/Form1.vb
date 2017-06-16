Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Transparency
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			' Create one section
			Dim section As PdfSection = doc.Sections.Add()

			'Load image
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\SalesReportChart.png")
            Dim imageWidth As Single = image.PhysicalDimension.Width / 2
            Dim imageHeight As Single = image.PhysicalDimension.Height / 2
			For Each mode As PdfBlendMode In System.Enum.GetValues(GetType(PdfBlendMode))
				Dim page As PdfPageBase = section.Pages.Add()
				Dim pageWidth As Single = page.Canvas.ClientSize.Width
				Dim y As Single = 0

				'title
				y = y + 5
				Dim brush As PdfBrush = New PdfSolidBrush(Color.OrangeRed)
				Dim font As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Bold))
				Dim format As New PdfStringFormat(PdfTextAlignment.Center)
				Dim text As String = String.Format("Transparency Blend Mode: {0}", mode)
				page.Canvas.DrawString(text, font, brush, pageWidth / 2, y, format)
				Dim size As SizeF = font.MeasureString(text, format)
				y = y + size.Height + 6

				page.Canvas.DrawImage(image, 0, y, imageWidth, imageHeight)
				page.Canvas.Save()
				Dim d As Single = (page.Canvas.ClientSize.Width - imageWidth) / 5
				Dim x As Single = d
				y = y + d / 2
				For i As Integer = 0 To 4
					Dim alpha As Single = 1.0f / 6 * (5 - i)
					page.Canvas.SetTransparency(alpha, alpha, mode)
					page.Canvas.DrawImage(image, x, y, imageWidth, imageHeight)
					x = x + d
					y = y + d / 2
				Next i
				page.Canvas.Restore()
			Next mode

			'Save pdf file.
			doc.SaveToFile("Transparency.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Transparency.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
