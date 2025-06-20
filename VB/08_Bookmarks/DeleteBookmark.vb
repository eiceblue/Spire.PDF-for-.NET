Imports Spire.Pdf

Namespace DeleteBookmark
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim input As String = "..\..\..\..\..\..\Data\DeleteBookmark.pdf"

            ' Create a new PdfDocument instance
            Dim doc As New PdfDocument()

            ' Load an existing PDF document from the specified file path
            doc.LoadFromFile(input)

            ' Delete the first bookmark
            doc.Bookmarks.RemoveAt(0)

            ' Specify the output file name
            Dim output As String = "DeleteBookmark.pdf"

            ' Save the modified document to the specified file path
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

            ' Launch the file
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
