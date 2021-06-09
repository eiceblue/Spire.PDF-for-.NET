Imports Spire.Pdf
Imports Spire.Pdf.Exporting
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace ReplaceImageWithText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceImage.pdf")

			'Get the first page.
			Dim page As PdfPageBase = doc.Pages(0)

			'Get images of the first page.
			Dim imageInfo() As PdfImageInfo = page.ImagesInfo

			'Get width and height of image
			Dim widthInPixel As Single = imageInfo(0).Image.Width
			Dim heightInPixel As Single = imageInfo(0).Image.Height

			'Convert unit from Pixel to Point
			Dim convertor As New PdfUnitConvertor()
			Dim width As Single = convertor.ConvertFromPixels(widthInPixel, PdfGraphicsUnit.Point)
			Dim height As Single = convertor.ConvertFromPixels(heightInPixel, PdfGraphicsUnit.Point)

			'Get location of image
			Dim xPos As Single=imageInfo(0).Bounds.X
			Dim yPos As Single=imageInfo(0).Bounds.Y

			'Remove the image
			page.DeleteImage(imageInfo(0).Image)

			'Define a rectangle
			Dim rect As New RectangleF(New PointF(xPos, yPos), New SizeF(width, height))

			'Define string format
			Dim format As New PdfStringFormat()
			format.Alignment= PdfTextAlignment.Center
			format.LineAlignment= PdfVerticalAlignment.Middle

			'Draw a string at the location of the image
			page.Canvas.DrawString("ReplacedText", New PdfFont(PdfFontFamily.Helvetica, 18f), PdfBrushes.Purple, rect, format)

			Dim result As String = "ReplaceImageWithText_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
