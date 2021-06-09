Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Namespace ImageWatermarkSecond
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load Pdf document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			'Load an image
			Dim image As Image = Image.FromFile("../../../../../../Data/E-logo.png")

			'Adjust image size
			Dim width As Integer = image.Width
			Dim height As Integer = image.Height
			Dim schale As Single = 1.5f
			Dim size As New Size(CInt(Fix(width * schale)), CInt(Fix(height * schale)))
			Dim schaleImage As New Bitmap(image, size)

			'Insert an image into the first PDF page at specific position
			Dim pdfImage As PdfImage = PdfImage.FromImage(schaleImage)
			Dim page As PdfPageBase = doc.Pages(0)
			Dim position As New PointF(160, 260)
			page.Canvas.Save()
			page.Canvas.SetTransparency(0.5f, 0.5f, PdfBlendMode.Multiply)
			page.Canvas.DrawImage(pdfImage, position)
			page.Canvas.Restore()

			'Save the Pdf document
			Dim output As String = "ImageWatermarkSecondApproach_out.pdf"
			doc.SaveToFile(output,FileFormat.PDF)

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
