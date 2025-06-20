Imports Spire.Pdf

Namespace MergeDocuments
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Array of file paths for the documents to merge
			Dim files() As String = {"..\..\..\..\..\..\Data\MergePdfsTemplate_1.pdf", "..\..\..\..\..\..\Data\MergePdfsTemplate_2.pdf", "..\..\..\..\..\..\Data\MergePdfsTemplate_3.pdf"}

			' Array to store PdfDocument objects
			Dim docs(files.Length - 1) As PdfDocument

			' Load each document from the file paths into PdfDocument objects
			For i As Integer = 0 To files.Length - 1
				' Load a specific document
				docs(i) = New PdfDocument(files(i))
			Next i

			' Create a new PdfDocument object to merge the documents
			Dim doc As New PdfDocument()

			' Insert the first document at the beginning of the merged document
			doc.InsertPage(docs(0), 0)

			' Insert pages from the second document at the beginning of the merged document
			doc.InsertPageRange(docs(1), 0, 2)

			' Insert the third document at the beginning of the merged document
			doc.InsertPage(docs(2), 0)

			' Save the merged document to a file
			doc.SaveToFile("MergeDocuments.pdf")

			' Close the merged document
			doc.Close()

			' Close each individual document in the array
			For Each docf As PdfDocument In docs
				docf.Close()
			Next docf

			' Launch the Pdf file
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
