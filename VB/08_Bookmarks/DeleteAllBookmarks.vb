Imports Spire.Pdf

Namespace DeleteAllBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim document As New PdfDocument()

			' Load an existing PDF document from the specified file path
			document.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			' Clear all bookmarks in the document
			document.Bookmarks.Clear()

			' Specify the output file name
			Dim result As String = "DeleteAllBookmarks_out.pdf"

			' Save the modified document to the specified file path
			document.SaveToFile(result)

			' Close the document
			document.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
