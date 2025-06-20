Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.IO
Imports System.Text

Namespace GetPdfChildBookmarks
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

			' Get the collection of bookmarks from the document
			Dim bookmarks As PdfBookmarkCollection = doc.Bookmarks

			' Specify the output file name
			Dim result As String = "GetPdfChildBookmarks_out.txt"

			' Retrieve and save the child bookmark information recursively
			GetChildBookmarks(bookmarks, result)

			' Close the document
			doc.Close()

			' Launch the file
			DocumentViewer(result)
		End Sub
		Private Sub GetChildBookmarks(ByVal bookmarks As PdfBookmarkCollection, ByVal result As String)
			' Create a StringBuilder to hold the bookmark content
			Dim content As New StringBuilder()

			' Iterate through each parent bookmark in the collection
			For Each parentBookmark As PdfBookmark In bookmarks

				' Check if the parent bookmark has any child bookmarks
				If parentBookmark.Count > 0 Then
					content.AppendLine("Child Bookmarks:")

					' Iterate through each child bookmark within the parent bookmark
					For Each childBookmark As PdfBookmark In parentBookmark

						' Append the title of the child bookmark
						content.AppendLine(childBookmark.Title)

						' Get the color of the child bookmark and append it
						Dim color As String = childBookmark.Color.ToString()
						content.AppendLine(color)

						' Get the display style of the child bookmark and append it
						Dim textStyle As String = childBookmark.DisplayStyle.ToString()
						content.AppendLine(textStyle)
					Next childBookmark
				End If

				' Write the bookmark content to the specified file
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
