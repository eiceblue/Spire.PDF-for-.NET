Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics

Namespace SetSeparationColorSpace
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

            ' Define a purple color
            Dim c As PdfRGBColor = Color.Purple

            ' Create a separation color space using the RGB components of the purple color
            Dim rgb As New PdfSeparationColorSpace("MySpotColor", New PdfRGBColor(c.R, c.G, c.B))

            ' CMYK color space
            'PdfSeparationColorSpace cmyk = new PdfSeparationColorSpace("MySpotColor", new PdfRGBColor(c.C, c.M, c.Y, c.K));
            ' Gray color space
            'PdfSeparationColorSpace grayscale = new PdfSeparationColorSpace("MySpotColor", new PdfRGBColor(c.Gray));

            ' Create a separation color using the separation color space and a tint value of 1.0
            Dim scolor As New PdfSeparationColor(rgb, 1.0F)

            ' Create a solid brush using the separation color
            Dim brush As New PdfSolidBrush(scolor)

            ' Draw a pie shape on the page using the brush
            page.Canvas.DrawPie(brush, 10, 30, 60, 60, 360, 360)

            ' Draw a text string on the page indicating the tint value
            page.Canvas.DrawString("Tint=1.0", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(22, 100))

            ' Update the separation color and brush with a tint value of 0.5
            scolor = New PdfSeparationColor(rgb, 0.5F)
            brush = New PdfSolidBrush(scolor)

            ' Draw another pie shape with the updated brush
            page.Canvas.DrawPie(brush, 80, 30, 60, 60, 360, 360)

            ' Draw a text string indicating the updated tint value
            page.Canvas.DrawString("Tint=0.5", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(92, 100))

            ' Update the separation color and brush with a tint value of 0.25
            scolor = New PdfSeparationColor(rgb, 0.25F)
            brush = New PdfSolidBrush(scolor)

            ' Draw another pie shape with the updated brush
            page.Canvas.DrawPie(brush, 150, 30, 60, 60, 360, 360)

            ' Draw a text string indicating the updated tint value
            page.Canvas.DrawString("Tint=0.25", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(162, 100))

            ' Save the document to a file named "result.pdf"
            Dim output As String = "result.pdf"
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

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
