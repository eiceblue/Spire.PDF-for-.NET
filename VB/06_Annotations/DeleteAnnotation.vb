Imports Spire.Pdf

Namespace DeleteAnnotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load an existing PDF file from the specified path
            doc.LoadFromFile("..\..\..\..\..\..\Data\DeleteAnnotation.pdf")

            ' Clear the first annotation from the first page of the document
            doc.Pages(0).Annotations.RemoveAt(0)

            ' Specify the output file name for the modified document
            Dim output As String = "DeleteAnnotation.pdf"

            ' Save the modified document to the specified file
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
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
