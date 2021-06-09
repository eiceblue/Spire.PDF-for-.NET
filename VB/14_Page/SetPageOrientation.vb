Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports Spire.Pdf.Graphics

Namespace SetPageOrientation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Add a section
			Dim section As PdfSection = doc.Sections.Add()

			'Load a image
            Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/scenery.jpg")

			'Check whether the width of the image file is greater than default page width or not
			If image.PhysicalDimension.Width > section.PageSettings.Size.Width Then

				'Set the orientation as landscape
				section.PageSettings.Orientation = PdfPageOrientation.Landscape

			Else
				section.PageSettings.Orientation = PdfPageOrientation.Portrait
			End If

			'Add a new page with orientation Landscape
			Dim page As PdfPageBase = section.Pages.Add()

			'Draw the image on the page
			page.Canvas.DrawImage(image,New PointF(0,0))

			Dim output As String = "PageOrientationAccordingToImageSize-result.pdf"
			'Save to file
			doc.SaveToFile(output)


			'Launch the reuslt file
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
