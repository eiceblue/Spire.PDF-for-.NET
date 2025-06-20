Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SetImageSize
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a new page to the document
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Load an image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\ChartImage.png")

            ' Calculate the width and height of the image with a scaling factor of 0.75
            Dim width As Single = image.Width * 0.75F
            Dim height As Single = image.Height * 0.75F

            ' Calculate the x and y coordinates to position the image at the center of the page
            Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2
            Dim y As Single = 60.0F

            ' Draw the image on the page's canvas using the calculated positions and dimensions
            page.Canvas.DrawImage(image, x, y, width, height)

            ' Specify the name of the output file
            Dim result As String = "SetImageSize_out.pdf"

            ' Save the modified document to the specified file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

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
