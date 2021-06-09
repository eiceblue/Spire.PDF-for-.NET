Imports Spire.Pdf

Namespace MergeDocuments
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf document list
			Dim files() As String = { "..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf", "..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf", "..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf" }
			'Open pdf documents            
			Dim docs(files.Length - 1) As PdfDocument
			For i As Integer = 0 To files.Length - 1
				docs(i) = New PdfDocument()
				docs(i).LoadFromFile(files(i))
			Next i

			'Append document
			docs(0).AppendPage(docs(1))

			'Import page
			For i As Integer = 0 To docs(2).Pages.Count - 1 Step 2
				docs(0).InsertPage(docs(2), i)
			Next i

			'Save pdf file
			docs(0).SaveToFile("MergeDocuments.pdf")

			'Close
			For Each doc As PdfDocument In docs
				doc.Close()
			Next doc

			'Launching the Pdf file
			PDFDocumentViewer("MergeDocuments.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
