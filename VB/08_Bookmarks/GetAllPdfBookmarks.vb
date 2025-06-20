Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.IO
Imports System.Text

Namespace GetAllPdfBookmarks
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
            Dim result As String = "GetPdfBookmarks.txt"

            ' Retrieve and save the bookmark information recursively
            GetBookmarks(bookmarks, result)

            ' Close the document
            doc.Close()
        End Sub
        Private Sub GetBookmarks(ByVal bookmarks As PdfBookmarkCollection, ByVal result As String)
            ' Create a StringBuilder to hold the bookmark content
            Dim content As New StringBuilder()

            ' Check if there are any bookmarks in the collection
            If bookmarks.Count > 0 Then
                content.AppendLine("Pdf bookmarks:")

                ' Iterate through each parent bookmark in the collection
                For Each parentBookmark As PdfBookmark In bookmarks

                    ' Append the title of the parent bookmark
                    content.AppendLine(parentBookmark.Title)

                    ' Get the display style of the parent bookmark and append it
                    Dim textStyle As String = parentBookmark.DisplayStyle.ToString()
                    content.AppendLine(textStyle)

                    ' Recursively retrieve child bookmarks within the parent bookmark
                    GetChildBookmark(parentBookmark, content)
                Next parentBookmark
            End If

            ' Write the bookmark content to the specified file
            File.WriteAllText(result, content.ToString())
        End Sub
        Private Sub GetChildBookmark(ByVal parentBookmark As PdfBookmark, ByVal content As StringBuilder)
            ' Check if the parent bookmark has any child bookmarks
            If parentBookmark.Count > 0 Then

                ' Iterate through each child bookmark
                For Each childBookmark As PdfBookmark In parentBookmark

                    ' Append the title of the child bookmark
                    content.AppendLine(childBookmark.Title)

                    ' Get the display style of the child bookmark and append it
                    Dim textStyle As String = childBookmark.DisplayStyle.ToString()
                    content.AppendLine(textStyle)

                    ' Recursively retrieve child bookmarks within the current child bookmark
                    GetChildBookmark(childBookmark, content)
                Next childBookmark
            End If
        End Sub
        Private Sub DocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
