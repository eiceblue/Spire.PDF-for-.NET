Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SetImageSize
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Load an image
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\ChartImage.png")

			'Set the width and height of image
			Dim width As Single = image.Width * 0.75f
			Dim height As Single = image.Height * 0.75f

			'Define a position to draw image
			Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2
			Dim y As Single = 60f

			'Draw image on page canvas
			page.Canvas.DrawImage(image, x, y, width, height)

			Dim result As String = "SetImageSize_out.pdf"

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
