Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions

Namespace Link
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document.
            Dim doc As PdfDocument = New PdfDocument()

            ' Set margins for the document.
            Dim unitCvtr As PdfUnitConvertor = New PdfUnitConvertor()
            Dim margin As PdfMargins = New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            ' Create a new page with specified size and margins.
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            Dim y As Single = 100
            Dim x As Single = 10

            ' Set font and label for the first text link.
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 14))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Lucida Sans Unicode", 14, PdfFontStyle.Regular, True)
            */
            Dim label As String = "Simple Text Link: "

            ' Draw the label on the page.
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)

            x = font.MeasureString(label, format).Width

            ' Set font and URL for the first text link.
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 14, FontStyle.Underline))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Lucida Sans Unicode", 14, PdfFontStyle.Underline, True)
            */
            Dim url1 As String = "http://www.e-iceblue.com"

            ' Draw the URL on the page.
            page.Canvas.DrawString(url1, font1, PdfBrushes.CadetBlue, x, y)
            y = y + font1.MeasureString(url1).Height + 25

            ' Set font and label for the second web link.
            Dim text As String = "E-iceblue home"
            Dim action2 As PdfURIAction = New PdfURIAction(url1)
            Dim link2 As PdfLinkAnnotation = New PdfLinkAnnotation(page, New RectangleF(x + margin.Left, y + margin.Top, 50, 20), action2)
            link2.Border.Width = 0
            link2.Contents = text
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, New PointF(x, y))
            PdfAnnotationCollection.Create(page).Add(link2)
            y = y + font1.MeasureString(text).Height + 30

            label = "URI Annonation: "
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
            x = font.MeasureString(label, format).Width
            text = "Google"
            Dim location As PointF = New PointF(x + margin.Left, y + margin.Top)
            Dim size As SizeF = font1.MeasureString(text)
            Dim linkBounds As RectangleF = New RectangleF(location, size)
            Dim action3 As PdfURIAction = New PdfURIAction("http://www.google.com")
            Dim link3 As PdfLinkAnnotation = New PdfLinkAnnotation(page, linkBounds, action3)

            link3.Border.Width = 0
            PdfAnnotationCollection.Create(page).Add(link3)
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y)
            y = y + size.Height + 30

            label = "URI Annonation Action: "
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
            x = font.MeasureString(label, format).Width
            text = "JavaScript Action (Click Me)"
            location = New PointF(x - 2 + margin.Left, y - 2 + margin.Top)
            size = font1.MeasureString(text)
            size = New SizeF(size.Width + 5, size.Height + 5)
            linkBounds = New RectangleF(location, size)
            'Script
            Dim script As String
                = "app.alert({"
                + "    cMsg: \"Hello.\","
                + "    nIcon: 3,"
                + "    cTitle: \"JavaScript Action\""
                + "});"
            Dim action4 As PdfJavaScriptAction = New PdfJavaScriptAction(script)
            Dim link4 As PdfLinkAnnotation = New PdfLinkAnnotation(page, linkBounds, action4)
            link4.Border.Width = 0.75f
            link4.Color = Color.CadetBlue

            PdfAnnotationCollection.Create(page).Add(link4)
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, x, y)
            y = y + size.Height + 30

            label = "Need Help:  "
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
            x = font.MeasureString(label, format).Width
            text = "Go to forum to ask questions"
            Dim action5 As PdfURIAction = New PdfURIAction("https://www.e-iceblue.com/forum/components-f5.html")
            link2 = New PdfLinkAnnotation(page, New RectangleF(x + margin.Left, y + margin.Top, 100, 20), action5)
            link2.Border.Width = 0
            link2.Contents = text
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, New PointF(x, y))
            PdfAnnotationCollection.Create(page).Add(link2)
            y = y + font1.MeasureString(text).Height + 30

            label = "Contct us:  "
            page.Canvas.DrawString(label, font, PdfBrushes.Orange, 0, y, format)
            x = font.MeasureString(label, format).Width
            text = "Send an email"
            Dim action6 As PdfURIAction = New PdfURIAction("mailto:support@e-iceblue.com")
            link2 = New PdfLinkAnnotation(page, New RectangleF(x + margin.Left, y + margin.Top, 50, 20), action6)
            link2.Border.Width = 0
            link2.Contents = text
            page.Canvas.DrawString(text, font1, PdfBrushes.CadetBlue, New PointF(x, y))
            PdfAnnotationCollection.Create(page).Add(link2)
            y = y + font1.MeasureString(text).Height + 30

            'Save pdf file.
            doc.SaveToFile("Link.pdf")
            doc.Close()

            'Launch the file.
            PDFDocumentViewer("Link.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
