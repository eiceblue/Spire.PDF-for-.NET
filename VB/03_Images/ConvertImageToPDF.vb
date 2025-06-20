Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ConvertImageToPDF
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Add a section to the document
            Dim section As PdfSection = pdf.Sections.Add()

            ' Add a page to the document
            Dim page As PdfPageBase = pdf.Pages.Add()

            ' Load an image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\bg.png")

            ' Calculate the fit rate for the image on the page
            Dim widthFitRate As Single = (image.PhysicalDimension.Width / page.Canvas.ClientSize.Width)
            Dim heightFitRate As Single = (image.PhysicalDimension.Height / page.Canvas.ClientSize.Height)
            Dim fitRate As Single = Math.Max(widthFitRate, heightFitRate)

            ' Calculate the dimensions of the image after fitting it on the page
            Dim fitWidth As Single = image.PhysicalDimension.Width / fitRate
            Dim fitHeight As Single = image.PhysicalDimension.Height / fitRate

            ' Draw the image on the page's canvas at position (0, 30) with the fitted dimensions
            page.Canvas.DrawImage(image, 0, 30, fitWidth, fitHeight)

            ' Specify the output file name for the converted PDF
            Dim output As String = "ConvertImageToPDF-result.pdf"

            ' Save the document to the specified file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

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
