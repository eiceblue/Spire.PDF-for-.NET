Imports Spire.Pdf

Namespace DeleteLayer
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of the PdfDocument class.
            Dim doc As New PdfDocument()

            ' Load a PDF file from the specified path.
            doc.LoadFromFile("..\..\..\..\..\..\Data\DeleteLayer.pdf")

            ' Remove a layer named "red line" from the document's layers.
            doc.Layers.RemoveLayer("red line")

            ' Save the modified document to a file named "Output.pdf".
            doc.SaveToFile("Output.pdf")

            ' Close the document, releasing any resources associated with it.
            doc.Close()

            ' View the Pdf file
            PDFDocumentViewer("Output.pdf")
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
