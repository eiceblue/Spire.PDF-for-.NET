Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SetPageOrientation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim doc As New PdfDocument()

			' Add a section to the document
			Dim section As PdfSection = doc.Sections.Add()

			' Load an image from file
			Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/scenery.jpg")

			' Check if the width of the image is greater than the default page width
			If image.PhysicalDimension.Width > section.PageSettings.Size.Width Then
				' Set the page orientation to landscape
				section.PageSettings.Orientation = PdfPageOrientation.Landscape
			Else
				' Set the page orientation to portrait
				section.PageSettings.Orientation = PdfPageOrientation.Portrait
			End If

			' Add a new page with the specified orientation
			Dim page As PdfPageBase = section.Pages.Add()

			' Draw the image on the page at the top-left corner
			page.Canvas.DrawImage(image, New PointF(0, 0))

			' Specify the output file name
			Dim output As String = "PageOrientationAccordingToImageSize-result.pdf"

			' Save the document to the output file
			doc.SaveToFile(output)

			' Close the PDF document
			doc.Close()

			' Launch the reuslt file
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
