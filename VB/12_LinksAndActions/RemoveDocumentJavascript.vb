Imports Spire.Pdf

Namespace RemoveDocumentJavaScript
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim document As New PdfDocument()

            ' Load a PDF file from a specified path
            document.LoadFromFile("..\..\..\..\..\..\Data\DocumentJavaScript.pdf")

            ' Remove any JavaScript actions present in the document
            document.RemoveDocumentJavaScript()

            ' Specify the output file name as "Output.pdf"
            Dim result As String = "Output.pdf"

            ' Save the modified document to a PDF file
            document.SaveToFile(result)

            ' Close the PDF document
            document.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace