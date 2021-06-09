Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetAllPdfBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new Pdf document.
			Dim doc As New PdfDocument()

			'Load the file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			'Get bookmarks collection of the Pdf file.
			Dim bookmarks As PdfBookmarkCollection = doc.Bookmarks

			Dim result As String = "GetPdfBookmarks.txt"

			'Get Pdf Bookmarks.
			GetBookmarks(bookmarks, result)

			'Launch the file.
			DocumentViewer(result)
		End Sub

		Private Sub GetBookmarks(ByVal bookmarks As PdfBookmarkCollection, ByVal result As String)
			'Declare a new StringBuilder content
			Dim content As New StringBuilder()

			'Get Pdf bookmarks information.
			If bookmarks.Count > 0 Then
				content.AppendLine("Pdf bookmarks:")
				For Each parentBookmark As PdfBookmark In bookmarks
					'Get the title.
					content.AppendLine(parentBookmark.Title)

					'Get the text style.
					Dim textStyle As String = parentBookmark.DisplayStyle.ToString()
					content.AppendLine(textStyle)
					GetChildBookmark(parentBookmark,content)
				Next parentBookmark
			End If

			'Save to file.
			File.WriteAllText(result, content.ToString())
		End Sub

		Private Sub GetChildBookmark(ByVal parentBookmark As PdfBookmark, ByVal content As StringBuilder)
			If parentBookmark.Count > 0 Then
				For Each childBookmark As PdfBookmark In parentBookmark
					'Get the title.
					content.AppendLine(childBookmark.Title)

					'Get the text style.
					Dim textStyle As String = childBookmark.DisplayStyle.ToString()
					content.AppendLine(textStyle)
					GetChildBookmark(childBookmark, content)
				Next childBookmark
			End If

		End Sub
		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
