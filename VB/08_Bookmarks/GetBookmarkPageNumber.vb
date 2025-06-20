Imports Spire.Pdf
Imports Spire.Pdf.Bookmarks
Imports System.IO

Namespace GetPdfBookmarkPageNumber
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

            ' Get the first bookmark from the collection
            Dim bookmark As PdfBookmark = bookmarks(0)

            ' Get the page number of the destination page associated with the bookmark
            Dim pageNumber As Integer = doc.Pages.IndexOf(bookmark.Destination.Page) + 1

            ' Convert the page number to a string
            Dim showPageNumber As String = pageNumber.ToString()

            ' Specify the output file name
            Dim result As String = "GetPdfBookmarkPageNumber.txt"

            ' Write the bookmark page number information to the specified file
            File.WriteAllText(result, "The page number of the first bookmark is: " & showPageNumber)

            ' Close the document
            doc.Close()

            ' Launch the file
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
