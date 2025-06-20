Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Utilities

Namespace ReplaceImage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()
            doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceImage.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfImageHelper object
            Dim helper As New PdfImageHelper()

            ' Get information about the images present on the page
            Dim images() As PdfImageInfo = helper.GetImagesInfo(page)

            ' Replace the first image with a new image
            helper.ReplaceImage(images(0), PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png"))

            ' Specify the name of the output file
            Dim result As String = "ReplaceImage_out.pdf"

            ' Save the modified document to the output file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
