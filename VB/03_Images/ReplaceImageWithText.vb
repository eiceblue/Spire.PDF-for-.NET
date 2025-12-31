Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Utilities

Namespace ReplaceImageWithText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load an existing PDF file
            doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceImage.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfImageHelper object for image manipulation
            Dim helper As New PdfImageHelper()

            ' Get information about the images on the page
            Dim images() As PdfImageInfo = helper.GetImagesInfo(page)

            ' Get the width and height of the first image
            Dim widthInPixel As Single = images(0).Image.Width
            Dim heightInPixel As Single = images(0).Image.Height

            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim widthInPixel As Single = 100
            'Dim heightInPixel As Single = 100
            ' =============================================================================

            ' Convert the dimensions from pixels to points
            Dim convertor As New PdfUnitConvertor()
            Dim width As Single = convertor.ConvertFromPixels(widthInPixel, PdfGraphicsUnit.Point)
            Dim height As Single = convertor.ConvertFromPixels(heightInPixel, PdfGraphicsUnit.Point)

            ' Get the X and Y positions of the first image
            Dim xPos As Single = images(0).Bounds.X
            Dim yPos As Single = images(0).Bounds.Y

            ' Delete the first image from the page
            helper.DeleteImage(images(0))

            ' Create a rectangle with the specified position and size
            Dim rect As New RectangleF(New PointF(xPos, yPos), New SizeF(width, height))

            ' Create a string format for text alignment
            Dim format As New PdfStringFormat()
            format.Alignment = PdfTextAlignment.Center
            format.LineAlignment = PdfVerticalAlignment.Middle

            ' Draw a string ("ReplacedText") on the page using specified font, brush, rectangle, and format
            page.Canvas.DrawString("ReplacedText", New PdfFont(PdfFontFamily.Helvetica, 18.0F), PdfBrushes.Purple, rect, format)

            ' Specify the output file name
            Dim result As String = "ReplaceImageWithText_out.pdf"

            ' Save the modified document to the specified file
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
