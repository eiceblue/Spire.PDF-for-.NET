Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddTilingBackgroundImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load document from disk
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			'Load an image
			Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

			For Each page As PdfPageBase In pdf.Pages
				'Create PdfTilingBrush
				Dim brush As New PdfTilingBrush(New SizeF(page.Canvas.Size.Width \ 3, page.Canvas.Size.Height \ 5))

				'Set the transparency
				brush.Graphics.SetTransparency(0.3f)

				'Draw image on brush graphics
				brush.Graphics.DrawImage(image, New PointF((brush.Size.Width - image.Width) / 2, (brush.Size.Height - image.Height) / 2))

				'use the brush to draw rectangle
				page.Canvas.DrawRectangle(brush, New RectangleF(New PointF(0, 0), page.Canvas.Size))
			Next page

			'Save the Pdf document
			Dim output As String = "AddTilingBackgroundImage_out.pdf"
			pdf.SaveToFile(output,FileFormat.PDF)

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
