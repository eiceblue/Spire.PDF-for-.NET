Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace EmbedImages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\..\Data\EmbedImagesInHTML.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Set the convertion option to embed image in html
			doc.ConvertOptions.SetPdfToHtmlOptions(True, True)

			Dim result As String = "ToHTMLWithEmbedImages_out.html"

			'Convert to html file
			doc.SaveToFile(result, FileFormat.HTML)
			doc.Close()

			'Launch the reuslt file
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
