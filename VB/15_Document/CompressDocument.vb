Imports Spire.Pdf
Imports Spire.Pdf.Utilities

Namespace CompressDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Load an existing PDF file from the specified path.
			doc.LoadFromFile("..\..\..\..\..\..\Data\CompressDocument.pdf")

			' Compress the content of the document.
			CompressContent(doc)

			' Compress the images in the document.
			CompressImage(doc)

			' Save the compressed document to a new file named "CompressDocument_result.pdf".
			doc.SaveToFile("CompressDocument_result.pdf")

			' Close the document, releasing any resources associated with it.
			doc.Close()

			' View the pdf document.
			PDFDocumentViewer("CompressDocument_result.pdf")
		End Sub

		' This method sets the compression level and incremental update for the document.
		Private Sub CompressContent(ByVal doc As PdfDocument)
			doc.FileInfo.IncrementalUpdate = False
			doc.CompressionLevel = PdfCompressionLevel.Best
		End Sub

		' This method compresses the images in each page of the document.
		Private Sub CompressImage(ByVal doc As PdfDocument)
			doc.FileInfo.IncrementalUpdate = False
			For Each page As PdfPageBase In doc.Pages
				If page IsNot Nothing Then
					Dim helper As New PdfImageHelper()
					Dim pdfImageInfos() As Spire.Pdf.Utilities.PdfImageInfo = helper.GetImagesInfo(page)
					If pdfImageInfos IsNot Nothing Then
						For i As Integer = 0 To pdfImageInfos.Length - 1
                  pdfImageInfos(i).TryCompressImage()
						Next i
					End If
				End If
			Next page
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
