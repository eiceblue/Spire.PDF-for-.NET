Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks

Namespace ExpandBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim doc As New PdfDocument()

			' Load an existing PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			' Recursively expand all bookmarks in the document
			ForeachBookmark(doc.Bookmarks, True)

			' Specify the output file name
			Dim result As String = "ExpandBookmarks_out.pdf"

			' Save the modified document to the specified file path
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub ForeachBookmark(ByVal collections As PdfBookmarkCollection, ByVal expand As Boolean)
			' Check if the collections variable has no elements
			If collections.Count = 0 Then
				' Exit the method if there are no collections
				Return
			End If
			' Iterate through each bookmark in the collections variable
			For Each bookmark As PdfBookmark In collections
				' Check if the current bookmark is a collection of bookmarks
				If (TryCast(bookmark, PdfBookmarkCollection)).Count > 0 Then
					' Recursively expand the sub-bookmarks within the bookmark collection
					ForeachBookmark(TryCast(bookmark, PdfBookmarkCollection), expand)

					' Set the expand state of the current bookmark based on the expand parameter
					bookmark.ExpandBookmark = expand
				End If
			Next bookmark
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				System.Diagnostics.Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
