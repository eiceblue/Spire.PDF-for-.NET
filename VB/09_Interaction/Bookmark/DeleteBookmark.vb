Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace DeleteBookmark
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

			'delete the first bookmark
			doc.Bookmarks.RemoveAt(0)

			Dim output As String = "DeleteBookmark.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
