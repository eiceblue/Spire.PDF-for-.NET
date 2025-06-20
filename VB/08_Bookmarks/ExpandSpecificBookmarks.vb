Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks

Namespace ExpandSpecificBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim pdf As New PdfDocument()

			' Load an existing PDF document from the specified file path
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ExpandSpecificBookmarks.pdf")

			' Set the ExpandBookmark property to "true" for the first bookmark
			pdf.Bookmarks(0).ExpandBookmark = True

			' Set the ExpandBookmark property to "false" for the first level of bookmarks in the second bookmark collection
			TryCast(pdf.Bookmarks(1), PdfBookmarkCollection)(0).ExpandBookmark = False

			' Specify the output file name
			Dim result As String = "ExpandSpecificBookmarks_output.pdf"

			' Save the modified document to the specified file path
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			' Launch the file
			DocumentViewer(result)
		End Sub
		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
