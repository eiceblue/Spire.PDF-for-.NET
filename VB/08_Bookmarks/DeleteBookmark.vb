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
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\DeleteBookmark.pdf"
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)

			'Delete the first bookmark
			doc.Bookmarks.RemoveAt(0)

			'Save the pdf document
			Dim output As String = "DeleteBookmark.pdf"
			doc.SaveToFile(output)

			'Launch the file
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
