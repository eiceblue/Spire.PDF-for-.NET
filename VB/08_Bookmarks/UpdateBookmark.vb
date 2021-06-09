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
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\UpdateBookmark.pdf"
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)

			'Get the first bookmark
			Dim bookmark As PdfBookmark = doc.Bookmarks(0)

			'Change the title of the bookmark
			bookmark.Title = "Modified BookMark"

			'Set the color of the bookmark
			bookmark.Color = Color.Black

			'Set the outline text style of the bookmark
			bookmark.DisplayStyle = PdfTextStyle.Bold

			'Edit child bookmarks of the parent bookmark
			EditChildBookmark(bookmark)

				  'Save the pdf document
			Dim output As String = "UpdateBookmark.pdf"
			doc.SaveToFile(output)

			'Launch the file
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
