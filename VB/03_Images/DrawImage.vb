Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawImage
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

            ' Apply text transformation on the page
            TransformText(page)

            ' Draw an image on the page
            DrawImage(page)

            ' Apply image transformation on the page
            TransformImage(page)

            ' Save the document to "DrawImage.pdf"
            doc.SaveToFile("DrawImage.pdf")

            ' Close the PdfDocument
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("DrawImage.pdf")
        End Sub

        Private Sub TransformText(ByVal page As PdfPageBase)
            ' Save the current graphics state of the page's canvas
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Create a font and brushes for text drawing
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 18.0F)
            Dim brush1 As New PdfSolidBrush(Color.Blue)
            Dim brush2 As New PdfSolidBrush(Color.CadetBlue)

            ' Create a string format for text alignment
            Dim format As New PdfStringFormat(PdfTextAlignment.Center)

            ' Translate the coordinate system of the canvas to the center of the page
            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width / 2, 20)

            ' Draw the first "Chart image" text with blue color
            page.Canvas.DrawString("Chart image", font, brush1, 0, 0, format)

            ' Scale the coordinate system of the canvas
            page.Canvas.ScaleTransform(1.0F, -0.8F)

            ' Draw the second "Chart image" text with cadet blue color
            page.Canvas.DrawString("Chart image", font, brush2, 0, -2 * 18 * 1.2F, format)

            ' Restore the previously saved graphics state
            page.Canvas.Restore(state)
        End Sub

        Private Sub DrawImage(ByVal page As PdfPageBase)
            ' Load the image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\ChartImage.png")

            ' Calculate the scaled width and height of the image
            Dim width As Single = image.Width * 0.75F
            Dim height As Single = image.Height * 0.75F

            ' Calculate the x-coordinate for centering the image horizontally
            Dim x As Single = (page.Canvas.ClientSize.Width - width) / 2

            ' Draw the image on the page's canvas at specified coordinates and dimensions
            page.Canvas.DrawImage(image, x, 60, width, height)
        End Sub

        Private Sub TransformImage(ByVal page As PdfPageBase)
            ' Load the image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\ChartImage.png")

            ' Define skew angles, scale factors, and calculate the resulting width and height of the transformed image
            Dim skewX As Integer = 20
            Dim skewY As Integer = 20
            Dim scaleX As Single = 0.2F
            Dim scaleY As Single = 0.6F
            Dim width As Integer = CInt(Fix((image.Width + image.Height * Math.Tan(Math.PI * skewX / 180)) * scaleX))
            Dim height As Integer = CInt(Fix((image.Height + image.Width * Math.Tan(Math.PI * skewY / 180)) * scaleY))

            ' Create a PdfTemplate with the calculated width and height
            Dim template As New PdfTemplate(width, height)

            ' Apply scaling and skew transformations to the graphics context of the template
            template.Graphics.ScaleTransform(scaleX, scaleY)
            template.Graphics.SkewTransform(skewX, skewY)

            ' Draw the original image onto the template
            template.Graphics.DrawImage(image, 0, 0)

            ' Save the current graphics state of the page's canvas
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Translate the coordinate system of the canvas to the desired position
            page.Canvas.TranslateTransform(page.Canvas.ClientSize.Width - 50, 260)

            ' Calculate the offset for each iteration of the loop
            Dim offset As Single = (page.Canvas.ClientSize.Width - 100) / 12

            ' Iterate through a range and draw the template with varying transparency levels
            For i As Integer = 0 To 11
                ' Translate the coordinate system to the left by the offset amount
                page.Canvas.TranslateTransform(-offset, 0)

                ' Set the transparency level based on the current iteration
                page.Canvas.SetTransparency(i / 12.0F)

                ' Draw the template onto the canvas at the specified position
                page.Canvas.DrawTemplate(template, New PointF(0, 0))
            Next i

            ' Restore the previously saved graphics state
            page.Canvas.Restore(state)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace