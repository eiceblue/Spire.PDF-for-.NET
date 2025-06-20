Imports Spire.Pdf
Imports Spire.Pdf.Utilities

Namespace DeleteImageFirstApproach
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim file As String = "..\..\..\..\..\..\Data\DeleteImage.pdf"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified input file
            pdf.LoadFromFile(file)

            ' Get the first page of the PDF document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Create a PdfImageHelper object to work with images in the PDF document
            Dim helper As New PdfImageHelper()

            ' Retrieve information about all the images on the page
            Dim images() As PdfImageInfo = helper.GetImagesInfo(page)

            ' Delete the first image on the page
            helper.DeleteImage(images(0))

            ' Specify the output file name
            Dim result As String = "DeleteImage_out.pdf"

            ' Save the modified PDF document to the specified output file
            pdf.SaveToFile(result)

            ' Close the PDF document
            pdf.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
            Catch
            End Try
        End Sub

    End Class
End Namespace
