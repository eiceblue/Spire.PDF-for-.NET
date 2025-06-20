Imports Spire.Pdf
Imports System.IO

Namespace MergePdfsByStream
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Open the first PDF file as a FileStream for reading
			Dim stream1 As FileStream = File.OpenRead("..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf")

			' Open the second PDF file as a FileStream for reading
			Dim stream2 As FileStream = File.OpenRead("..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf")

			' Open the third PDF file as a FileStream for reading
			Dim stream3 As FileStream = File.OpenRead("..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf")

			' Store the FileStream objects in an array of Stream
			Dim streams() As Stream = {stream1, stream2, stream3}

			' Merge the PDF files using the FileStreams and obtain a PdfDocumentBase object
			Dim doc As PdfDocumentBase = PdfDocument.MergeFiles(streams)

			' Save the merged document to a file named "MergeFilesByStream_result.pdf" in PDF format
			doc.Save("MergeFilesByStream_result.pdf", FileFormat.PDF)

			' Close the merged document
			doc.Close()

			' Launch the file
			PDFDocumentViewer("MergeFilesByStream_result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
