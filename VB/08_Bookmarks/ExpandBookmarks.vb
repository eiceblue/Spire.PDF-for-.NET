Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace ExpandBookmarks
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

			'Set BookMarkExpandOrCollapse as true to expand the bookmarks.
			doc.ViewerPreferences.BookMarkExpandOrCollapse = True

			Dim result As String = "ExpandBookmarks_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
