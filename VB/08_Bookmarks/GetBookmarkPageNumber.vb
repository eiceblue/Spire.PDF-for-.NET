Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Namespace GetPdfBookmarkPageNumber
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document.
			Dim doc As New PdfDocument()

			'Load the file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			'Get bookmarks collections of the PDF file.
			Dim bookmarks As PdfBookmarkCollection = doc.Bookmarks

			'Get the page number of the first bookmark.
			Dim bookmark As PdfBookmark = bookmarks(0)
			Dim pageNumber As Integer = doc.Pages.IndexOf(bookmark.Destination.Page)+1

			'Save to file.
			Dim showPageNumber As String = pageNumber.ToString()

			Dim result As String = "GetPdfBookmarkPageNumber.txt"

			'Save to file.
			File.WriteAllText(result, "The page number of the first bookmark is: " & showPageNumber)

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
