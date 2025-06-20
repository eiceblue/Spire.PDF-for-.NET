Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace TextWaterMark
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load the PDF file from a specified path
            doc.LoadFromFile("..\..\..\..\..\..\Data\TextWaterMark.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfTilingBrush with a size of half the width and one-third the height of the page canvas
            Dim brush As New PdfTilingBrush(New SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3))

            ' Set the transparency of the brush's graphics context
            brush.Graphics.SetTransparency(0.3F)

            ' Save the current state of the brush's graphics context
            brush.Graphics.Save()

            ' Translate the origin of the brush's graphics context to the center of the brush's size
            brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2)

            ' Rotate the brush's graphics context by -45 degrees
            brush.Graphics.RotateTransform(-45)

            ' Draw the text "Spire.Pdf Demo" using a specified font, color, and alignment within the brush's graphics context
            brush.Graphics.DrawString("Spire.Pdf Demo", New PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0, New PdfStringFormat(PdfTextAlignment.Center))

            ' Restore the previous state of the brush's graphics context
            brush.Graphics.Restore()

            ' Reset the transparency of the brush's graphics context
            brush.Graphics.SetTransparency(1)

            ' Draw a rectangle on the page canvas using the brush as a background
            page.Canvas.DrawRectangle(brush, New RectangleF(New PointF(0, 0), page.Canvas.ClientSize))

            ' Specify the output file name for the modified PDF document
            doc.SaveToFile("TextWaterMark.pdf")

            ' Close the PDF document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("TextWaterMark.pdf")
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
