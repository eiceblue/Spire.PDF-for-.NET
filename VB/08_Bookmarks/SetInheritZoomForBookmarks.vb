Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports Spire.Pdf.General

Namespace SetInheritZoomForBookmarks
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input and output file path
            Dim inputFile As String = "..\..\..\..\..\..\Data\SetInheritZoomForBookmarks.pdf"
            Dim outputFile As String = "output.pdf"

            ' Create a new PdfDocument instance
            Dim pdf As New PdfDocument()

            ' Load an existing PDF document from the specified input file
            pdf.LoadFromFile(inputFile)

            ' Get the collection of bookmarks from the document
            Dim bookmarks As PdfBookmarkCollection = pdf.Bookmarks

            ' Iterate through each bookmark in the collection
            For i As Integer = 0 To bookmarks.Count - 1

                ' Get the current bookmark
                Dim bookmark As PdfBookmark = bookmarks(i)

                ' Set the bookmark action
                SetBookmarkAction(bookmark)
            Next i

            ' Save the modified document to the specified output file path
            pdf.SaveToFile(outputFile, FileFormat.PDF)

            ' Close the document
            pdf.Close()

            ' Launch the file
            PDFDocumentViewer(outputFile)
        End Sub
        Private Sub SetBookmarkAction(ByVal bookmark As PdfBookmark)
            ' Get the destination of the bookmark
            Dim dest As PdfDestination = bookmark.Destination

            ' Set the destination mode to "Location" and zoom level to 0
            dest.Mode = PdfDestinationMode.Location
            dest.Zoom = 0

            ' Iterate through each child bookmark
            For i As Integer = 0 To bookmark.Count - 1
                Dim childbookmark As PdfBookmark = bookmark(i)

                ' Recursively set bookmark actions for child bookmarks
                SetBookmarkAction(childbookmark)
            Next i
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
