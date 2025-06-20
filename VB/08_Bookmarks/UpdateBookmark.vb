Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks

Namespace UpdateBookmark
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\UpdateBookmark.pdf"

            ' Create a new PdfDocument instance
            Dim doc As New PdfDocument()

            ' Load an existing PDF document from the specified input file
            doc.LoadFromFile(input)

            ' Get the first bookmark from the collection
            Dim bookmark As PdfBookmark = doc.Bookmarks(0)

            ' Modify the properties of the bookmark
            bookmark.Title = "Modified BookMark"
            bookmark.Color = Color.Black
            bookmark.DisplayStyle = PdfTextStyle.Bold

            ' Edit child bookmarks recursively
            EditChildBookmark(bookmark)

            ' Specify the output file path
            Dim output As String = "UpdateBookmark.pdf"

            ' Save the modified document to the specified output file
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

            'Launch the file
            PDFDocumentViewer(output)
        End Sub
        Private Sub EditChildBookmark(ByVal parentBookmark As PdfBookmark)
            ' Iterate through each child bookmark of the parent bookmark
            For Each childBookmark As PdfBookmark In parentBookmark

                ' Modify the properties of the child bookmark
                childBookmark.Color = Color.Blue
                childBookmark.DisplayStyle = PdfTextStyle.Regular

                ' Call another method to edit further child bookmarks
                EditChild2Bookmark(childBookmark)
            Next childBookmark
        End Sub
        Private Sub EditChild2Bookmark(ByVal childBookmark As PdfBookmark)
            ' Iterate through each second-level child bookmark
            For Each child2Bookmark As PdfBookmark In childBookmark
                ' Modify the properties of the second-level child book
                ' mark
                child2Bookmark.Color = Color.LightSalmon
                child2Bookmark.DisplayStyle = PdfTextStyle.Italic
            Next child2Bookmark
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
