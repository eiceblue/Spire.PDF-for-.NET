Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks

Namespace SetInheritZoom
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim pdfdoc As New PdfDocument()

			' Load an existing PDF document from the specified file path
			pdfdoc.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_1.pdf")

			' Get the collection of bookmarks from the document
			Dim bookmarks As PdfBookmarkCollection = pdfdoc.Bookmarks

			' Iterate through each bookmark in the collection
			For Each bookMark As PdfBookmark In bookmarks

				' Set the zoom level of the bookmark's destination to 0.5 (50% zoom)
				bookMark.Destination.Zoom = 0.5F
			Next bookMark

			' Specify the output file name
			Dim result As String = "SetInheritZoom_out.pdf"

			' Save the modified document to the specified file path
			pdfdoc.SaveToFile(result)

			' Close the document
			pdfdoc.Close()

			' Launch the Pdf file
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
