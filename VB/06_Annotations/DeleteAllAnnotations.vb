Imports Spire.Pdf

Namespace DeleteAllAnnotations
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim document As New PdfDocument()

            ' Load an existing PDF file from the specified path
            document.LoadFromFile("..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

            ' Clear all annotations from the first page of the document
            document.Pages(0).Annotations.Clear()

            ' Specify the output file name for the modified document
            Dim result As String = "DeleteAllAnnotations_out.pdf"

            ' Save the modified document to the specified file
            document.SaveToFile(result)

            ' Close the document
            document.Close()

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
