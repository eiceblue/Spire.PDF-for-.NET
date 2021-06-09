Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetPdfChildBookmarks
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

			'Get bookmarks collections of the PDF file.
			Dim bookmarks As PdfBookmarkCollection = doc.Bookmarks

			Dim result As String = "GetPdfChildBookmarks_out.txt"

			'Get Pdf child Bookmarks.
			GetChildBookmarks(bookmarks, result)

			'Launch the file.
			DocumentViewer(result)
		End Sub

		Private Sub GetChildBookmarks(ByVal bookmarks As PdfBookmarkCollection, ByVal result As String)
			'Declare a new StringBuilder content
			Dim content As New StringBuilder()

			'Get Pdf child Bookmarks information.
			For Each parentBookmark As PdfBookmark In bookmarks
				If parentBookmark.Count > 0 Then
					content.AppendLine("Child Bookmarks:")

					For Each childBookmark As PdfBookmark In parentBookmark
						'Get the title
						content.AppendLine(childBookmark.Title)

						'Get the color.
						Dim color As String = childBookmark.Color.ToString()
						content.AppendLine(color)

						'Get the text style.
						Dim textStyle As String = childBookmark.DisplayStyle.ToString()
						content.AppendLine(textStyle)
					Next childBookmark
				End If

				'Save to file.
				File.WriteAllText(result, content.ToString())
			Next parentBookmark
		End Sub

		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
