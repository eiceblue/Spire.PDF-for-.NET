Imports Spire.Pdf

Namespace EmbedImages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim file As String = "..\..\..\..\..\..\..\Data\EmbedImagesInHTML.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF file into the PdfDocument object
			doc.LoadFromFile(file)

			' Set the conversion options to embed images and include them in the HTML output
			doc.ConvertOptions.SetPdfToHtmlOptions(True, True)

			' Provide a file name for the resulting HTML file
			Dim result As String = "ToHTMLWithEmbedImages_out.html"

			' Save the PDF document as an HTML file with embedded images
			doc.SaveToFile(result, FileFormat.HTML)

			' Close the PdfDocument object
			doc.Close()

			' Launch the reuslt file
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
