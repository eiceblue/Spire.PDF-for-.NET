Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics

Namespace DrawContentWithSpotColor
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document
            Dim pdf As New PdfDocument()

            ' Load an existing PDF from a file
            pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawContentWithSpotColor.pdf")

            ' Get the first page of the loaded PDF
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Create a separation color space with the name "MySpotColor" and the color DarkViolet
            Dim cs As New PdfSeparationColorSpace("MySpotColor", System.Drawing.Color.DarkViolet)

            ' Create a separation color using the color space and a tint value of 1.0
            Dim color As New PdfSeparationColor(cs, 1.0F)

            ' Create a solid brush with the separation color
            Dim brush As New PdfSolidBrush(color)

            ' Draw text on the page with the brush at coordinates (160, 160)
            page.Canvas.DrawString("Tint=1.0", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(160, 160))

            ' Draw a pie shape on the page with the brush at coordinates (148, 200) and size 60x60
            page.Canvas.DrawPie(brush, 148, 200, 60, 60, 360, 360)

            ' Draw text on the page with the brush at coordinates (230, 160)
            page.Canvas.DrawString("Tint=0.7", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(230, 160))

            ' Update the separation color and brush for a tint value of 0.7
            color = New PdfSeparationColor(cs, 0.7F)
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (218, 200)
            page.Canvas.DrawPie(brush, 218, 200, 60, 60, 360, 360)

            ' Draw text on the page with the brush at coordinates (300, 160)
            page.Canvas.DrawString("Tint=0.4", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(300, 160))

            ' Update the separation color and brush for a tint value of 0.4
            color = New PdfSeparationColor(cs, 0.4F)
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (288, 200)
            page.Canvas.DrawPie(brush, 288, 200, 60, 60, 360, 360)

            ' Draw text on the page with the brush at coordinates (370, 160)
            page.Canvas.DrawString("Tint=0.1", New PdfFont(PdfFontFamily.Helvetica, 10.0F), brush, New PointF(370, 160))

            ' Update the separation color and brush for a tint value of 0.1
            color = New PdfSeparationColor(cs, 0.1F)
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (358, 200)
            page.Canvas.DrawPie(brush, 358, 200, 60, 60, 360, 360)

            ' Change the separation color space to use the color Purple
            cs = New PdfSeparationColorSpace("MySpotColor", System.Drawing.Color.Purple)

            ' Update the separation color with the new color space and a tint value of 1.0
            color = New PdfSeparationColor(cs, 1.0F)

            ' Update the brush with the updated separation color
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (148, 280)
            page.Canvas.DrawPie(brush, 148, 280, 60, 60, 360, 360)

            ' Update the separation color for a tint value of 0.7
            color = New PdfSeparationColor(cs, 0.7F)
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (218, 280)
            page.Canvas.DrawPie(brush, 218, 280, 60, 60, 360, 360)

            ' Update the separation color for a tint value of 0.4
            color = New PdfSeparationColor(cs, 0.4F)
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (288, 280)
            page.Canvas.DrawPie(brush, 288, 280, 60, 60, 360, 360)

            ' Update the separation color for a tint value of 0.1
            color = New PdfSeparationColor(cs, 0.1F)
            brush = New PdfSolidBrush(color)

            ' Draw a pie shape on the page with the updated brush at coordinates (358, 280)
            page.Canvas.DrawPie(brush, 358, 280, 60, 60, 360, 360)

            'Save the document
            pdf.SaveToFile("SpotColor.pdf")

            ' Close the document
            pdf.Close()

            ' View the pdf document
            PDFDocumentViewer("SpotColor.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
