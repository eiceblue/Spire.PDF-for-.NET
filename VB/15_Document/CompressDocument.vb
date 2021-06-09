Imports Spire.Pdf
Imports Spire.Pdf.Exporting
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace CompressDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load the pdf document
			Dim doc As New PdfDocument()
		doc.LoadFromFile("..\..\..\..\..\..\Data\CompressDocument.pdf")
			'Compress the content in document
			CompressContent(doc)

			'Compress the images in document
			CompressImage(doc)

			'Save the document
			doc.SaveToFile("CompressDocument_result.pdf")

			'View the pdf document
			PDFDocumentViewer("CompressDocument_result.pdf")
		End Sub

		Private Sub CompressContent(ByVal doc As PdfDocument)
			'Disable the incremental update
			doc.FileInfo.IncrementalUpdate = False

			'Set the compression level to best
			doc.CompressionLevel = PdfCompressionLevel.Best
		End Sub

		Private Sub CompressImage(ByVal doc As PdfDocument)
			'Disable the incremental update
			doc.FileInfo.IncrementalUpdate = False

			'Traverse all pages
			For Each page As PdfPageBase In doc.Pages
				If page IsNot Nothing Then
					If page.ImagesInfo IsNot Nothing Then
						For Each info As PdfImageInfo In page.ImagesInfo
							page.TryCompressImage(info.Index)
						Next info
					End If
				End If
			Next page
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
