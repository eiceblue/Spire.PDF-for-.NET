Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ConvertImageToPDF

	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a pdf document with a section and page added.
			Dim pdf As New PdfDocument()
			Dim section As PdfSection = pdf.Sections.Add()
			Dim page As PdfPageBase = pdf.Pages.Add()

			'Load a tiff image from system
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\bg.png")
			'Set image display location and size in PDF
			'Calculate rate
			Dim widthFitRate As Single = (image.PhysicalDimension.Width \ page.Canvas.ClientSize.Width)
			Dim heightFitRate As Single = (image.PhysicalDimension.Height \ page.Canvas.ClientSize.Height)
			Dim fitRate As Single = Math.Max(widthFitRate, heightFitRate)
			'Calculate the size of image 
			Dim fitWidth As Single = image.PhysicalDimension.Width / fitRate
			Dim fitHeight As Single = image.PhysicalDimension.Height / fitRate
			'Draw image
			page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight)

		   Dim output As String = "ConvertImageToPDF-result.pdf"

            pdf.SaveToFile(output)
			pdf.Close()

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
