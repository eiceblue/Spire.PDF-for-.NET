Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports Spire.Pdf.Utilities
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Namespace Extraction
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\Extraction.pdf")

			' Create a StringBuilder to store extracted text
			Dim buffer As New StringBuilder()

			' Create a list to store extracted images
			Dim images As IList(Of Image) = New List(Of Image)()

			' Create PdfImageHelper
			Dim imageHelper As New PdfImageHelper()

			' Iterate through each page of the document.
			For Each page As PdfPageBase In doc.Pages
				' Extract text from the current page.
				Dim pdfTextExtractor As New PdfTextExtractor(page)
				Dim pdfTextExtractOptions As New PdfTextExtractOptions()
				pdfTextExtractOptions.IsExtractAllText = True
				buffer.Append(pdfTextExtractor.ExtractText(pdfTextExtractOptions))

				'Get images information 
				Dim imageInfos() As PdfImageInfo = imageHelper.GetImagesInfo(page)

				' Extract images from the current page and add them to the images list
				For Each info As PdfImageInfo In imageInfos
					images.Add(info.Image)
				Next info
			Next page

			' Close the PDF document
			doc.Close()

			' Save the extracted text to a text file
			Dim fileName As String = "TextInPdf.txt"
			File.WriteAllText(fileName, buffer.ToString())

			' Save the extracted images as PNG files
			Dim index As Integer = 0
			For Each image As Image In images
				Dim imageFileName As String = String.Format("Image-{0}.png", index)
				index += 1
				image.Save(imageFileName, ImageFormat.Png)
			Next image

			' Launch the Pdf file
			PDFDocumentViewer(fileName)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
