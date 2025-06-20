Imports Spire.Pdf
Imports Spire.Pdf.Utilities

Namespace DeleteImageByBounds
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\DeleteImageByBounds.pdf"

            ' Specify the output file name
            Dim result As String = "DeleteImageByBounds_result.pdf"

            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified input file
            pdf.LoadFromFile(input)

            ' Get the first page of the PDF document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Create a PdfImageHelper object to work with images in the PDF document
            Dim helper As New PdfImageHelper()

            ' Retrieve information about all the images on the page
            Dim images() As PdfImageInfo = helper.GetImagesInfo(page)

            ' Iterate through each image on the page
            For i As Integer = 0 To images.Length - 1

                ' If the image's bounds contain the specified coordinates (49.68f, 72.75f), delete the image
                If images(i).Bounds.Contains(49.68F, 72.75F) Then
                    helper.DeleteImage(images(i))
                End If

                ' If the image's bounds intersect with the specified rectangle (100f, 500f, 30f, 40f), delete the image
                If images(i).Bounds.IntersectsWith(New RectangleF(100.0F, 500.0F, 30.0F, 40.0F)) Then
                    helper.DeleteImage(images(i))
                End If

            Next i

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
