Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddTilingBackgroundImage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load an existing PDF file from the specified path
            pdf.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

            ' Load an image from the specified path
            Dim image As PdfImage = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

            ' Iterate through each page in the document
            For Each page As PdfPageBase In pdf.Pages

                ' Create a new PdfTilingBrush with a size one-third of the page's canvas size
                Dim brush As New PdfTilingBrush(New SizeF(page.Canvas.Size.Width / 3, page.Canvas.Size.Height / 5))

                ' Set the transparency of the brush to 0.3 (30%)
                brush.Graphics.SetTransparency(0.3F)

                ' Draw the image onto the brush
                brush.Graphics.DrawImage(image, New PointF((brush.Size.Width - image.Width) / 2, (brush.Size.Height - image.Height) / 2))

                ' Draw a rectangle on the page's canvas using the brush as the background
                page.Canvas.DrawRectangle(brush, New RectangleF(New PointF(0, 0), page.Canvas.Size))
            Next page

            ' Specify the output file name
            Dim output As String = "AddTilingBackgroundImage_out.pdf"

            ' Save the modified document to a file in PDF format
            pdf.SaveToFile(output, FileFormat.PDF)

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
