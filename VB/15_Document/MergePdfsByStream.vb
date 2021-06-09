Imports Spire.Pdf
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace MergePdfsByStream
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim stream1 As FileStream = File.OpenRead("..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf")
			Dim stream2 As FileStream = File.OpenRead("..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf")
			Dim stream3 As FileStream = File.OpenRead("..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf")

			'Pdf document streams 
			Dim streams() As Stream = { stream1, stream2, stream3 }

			'Also can merge files by filename
			'Merge files by stream
			Dim doc As PdfDocumentBase = PdfDocument.MergeFiles(streams)

			'Save and launch
			doc.Save("MergeFilesByStream_result.pdf", FileFormat.PDF)
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
