Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Namespace UpdateBookmark
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\Bookmark.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'get the first bookmark
			Dim bookmark As PdfBookmark = doc.Bookmarks(0)

			'change the title of the bookmark
			bookmark.Title = "Modified BookMarks"

			'set the color of the bookmark
			bookmark.Color = Color.Black

			'set the outline text style of the bookmark
			bookmark.DisplayStyle = PdfTextStyle.Bold

			'edit child bookmarks of parent bookmark
			EditChildBookmark(bookmark)

			Dim output As String = "UpdateBookmark.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub EditChildBookmark(ByVal parentBookmark As PdfBookmark)
			For Each childBookmark As PdfBookmark In parentBookmark
				childBookmark.Color = Color.Blue
				childBookmark.DisplayStyle = PdfTextStyle.Regular
				EditChild2Bookmark(childBookmark)
			Next childBookmark
		End Sub
		Private Sub EditChild2Bookmark(ByVal childBookmark As PdfBookmark)
			For Each child2Bookmark As PdfBookmark In childBookmark
			   child2Bookmark.Color = Color.LightSalmon
			   child2Bookmark.DisplayStyle = PdfTextStyle.Italic
			Next child2Bookmark
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
