Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks

Namespace ExpandSpecificBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ExpandSpecificBookmarks.pdf")

			'Set BookMarkExpandOrCollapse as "true" for the first bookmarks and "false" for the first level of the second bookmarks  
			pdf.Bookmarks(0).ExpandBookmark = True
			TryCast(pdf.Bookmarks(1), PdfBookmarkCollection)(0).ExpandBookmark = False

			'Save the file
			Dim result As String = "ExpandSpecificBookmarks_output.pdf"
			pdf.SaveToFile(result)

			'Launch the file.
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
