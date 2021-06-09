Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace DrawContentWithSpotColor
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load the document from disk
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawContentWithSpotColor.pdf")

			'Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			'Initialize an instance of PdfSeparationColorSpace
			Dim cs As New PdfSeparationColorSpace("MySpotColor", System.Drawing.Color.DarkViolet)


            'Set tini = 1 for the cs
            Dim color As New PdfSeparationColor(cs, 1f)

			'Create a brush with spot color
			Dim brush As New PdfSolidBrush(color)

			'Draw a string
			page.Canvas.DrawString("Tint=1.0", New PdfFont(PdfFontFamily.Helvetica, 10f), brush, New PointF(160, 160))

			'Draw pie with spot color(DarkViolet)
			page.Canvas.DrawPie(brush, 148, 200, 60, 60, 360, 360)

			page.Canvas.DrawString("Tint=0.7", New PdfFont(PdfFontFamily.Helvetica, 10f), brush, New PointF(230, 160))
			color = New PdfSeparationColor(cs, 0.7f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 218, 200, 60, 60, 360, 360)

			page.Canvas.DrawString("Tint=0.4", New PdfFont(PdfFontFamily.Helvetica, 10f), brush, New PointF(300, 160))
			color = New PdfSeparationColor(cs, 0.4f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 288, 200, 60, 60, 360, 360)

			page.Canvas.DrawString("Tint=0.1", New PdfFont(PdfFontFamily.Helvetica, 10f), brush, New PointF(370, 160))
			color = New PdfSeparationColor(cs, 0.1f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 358, 200, 60, 60, 360, 360)


			'Draw pie with spot color(Purple)
			cs = New PdfSeparationColorSpace("MySpotColor", System.Drawing.Color.Purple)
			color = New PdfSeparationColor(cs, 1f)

			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 148, 280, 60, 60, 360, 360)

			color = New PdfSeparationColor(cs, 0.7f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 218, 280, 60, 60, 360, 360)

			color = New PdfSeparationColor(cs, 0.4f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 288, 280, 60, 60, 360, 360)

			color = New PdfSeparationColor(cs, 0.1f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 358, 280, 60, 60, 360, 360)


			'Draw pie with spot color(DarkSlateBlue)
			cs = New PdfSeparationColorSpace("MySpotColor", System.Drawing.Color.DarkSlateBlue)
			color = New PdfSeparationColor(cs, 1f)

			brush = New PdfSolidBrush(color)

			page.Canvas.DrawPie(brush, 148, 360, 60, 60, 360, 360)

			color = New PdfSeparationColor(cs, 0.7f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 218, 360, 60, 60, 360, 360)

			color = New PdfSeparationColor(cs, 0.4f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 288, 360, 60, 60, 360, 360)

			color = New PdfSeparationColor(cs, 0.1f)
			brush = New PdfSolidBrush(color)
			page.Canvas.DrawPie(brush, 358, 360, 60, 60, 360, 360)

			'Save the document
			pdf.SaveToFile("SpotColor.pdf")

			'View the pdf document
			PDFDocumentViewer("SpotColor.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
