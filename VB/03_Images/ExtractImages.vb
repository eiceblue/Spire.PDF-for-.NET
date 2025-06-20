Imports Spire.Pdf
Imports Spire.Pdf.Utilities


Namespace ExtractImages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a PDF document
			Dim doc As New PdfDocument()

			' Load a file from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\ExtractImges.pdf")

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create an instance of PdfImageHelper to work with images
			Dim imageHelper As New PdfImageHelper()

			' Get information about the images on the page
			Dim imageInfos() As PdfImageInfo = imageHelper.GetImagesInfo(page)

			' Extract images from the page
			Dim index As Integer = 0
			For Each info As PdfImageInfo In imageInfos
				' Save each image as a PNG file with a unique name
				info.Image.Save(String.Format("Image-{0}.png", index))
				index += 1
			Next info

			' Dispose the PDF document to release resources
			doc.Dispose()
		End Sub
	End Class
End Namespace
