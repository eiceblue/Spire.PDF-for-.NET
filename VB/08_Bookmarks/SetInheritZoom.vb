Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SetInheritZoom
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a new PDF document
			Dim pdfdoc As New PdfDocument()

			'load the document from disk
			pdfdoc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			'Get bookmarks collections of the PDF file
			Dim bookmarks As PdfBookmarkCollection = pdfdoc.Bookmarks

			'Set Zoom level as 0, which the value is inherit zoom
			For Each bookMark As PdfBookmark In bookmarks
				bookMark.Destination.Zoom = 0.5f
			Next bookMark

			Dim result As String = "SetInheritZoom_out.pdf"

			'Save the document
			pdfdoc.SaveToFile(result)
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
