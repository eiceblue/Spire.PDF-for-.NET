Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace TextWaterMark
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document and load file from disk
			Dim doc As New PdfDocument()
		doc.LoadFromFile("..\..\..\..\..\..\Data\TextWaterMark.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Draw text watermark
			Dim brush As New PdfTilingBrush(New SizeF(page.Canvas.ClientSize.Width \ 2, page.Canvas.ClientSize.Height \ 3))
			brush.Graphics.SetTransparency(0.3f)
			brush.Graphics.Save()
			brush.Graphics.TranslateTransform(brush.Size.Width \ 2, brush.Size.Height \ 2)
			brush.Graphics.RotateTransform(-45)
			brush.Graphics.DrawString("Spire.Pdf Demo", New PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0, New PdfStringFormat(PdfTextAlignment.Center))
			brush.Graphics.Restore()
			brush.Graphics.SetTransparency(1)
			page.Canvas.DrawRectangle(brush, New RectangleF(New PointF(0, 0), page.Canvas.ClientSize))

			'Save pdf file
			doc.SaveToFile("TextWaterMark.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("TextWaterMark.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
