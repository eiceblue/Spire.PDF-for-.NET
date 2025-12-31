Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Namespace WrapTextAroundImage
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

            ' Get the width of the page
            Dim pageWidth As Single = page.Canvas.ClientSize.Width

            ' Set the initial y coordinate
            Dim y As Single = 0

            ' Increase the y coordinate by 8
            y = y + 8

            ' Create a brush for drawing
            Dim brush As PdfBrush = New PdfSolidBrush(Color.Black)

            ' Create a font for text
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 20.0F, FontStyle.Bold))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            '  Dim font1 As New PdfTrueTypeFont("Arial", 20.0F, FontStyle.Bold, True)
            ' =============================================================================

            ' Create a string format for text alignment
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Center)
            format1.CharacterSpacing = 1.0F

            ' Set the text to be drawn
            Dim text As String = "Spire.PDF for .NET"

            ' Draw the text on the page
            page.Canvas.DrawString(text, font1, brush, pageWidth / 2, y, format1)

            ' Measure the size of the drawn text
            Dim size As SizeF = font1.MeasureString(text, format1)

            ' Update the y coordinate
            y = y + size.Height + 6

            ' Load an image file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\PdfImage.png")

            ' Draw the image on the page
            page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))

            ' Calculate the position of the image
            Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
            Dim imageBottom As Single = image.PhysicalDimension.Height + y

            ' Create a string format for the content text
            Dim format2 As New PdfStringFormat()

            ' Read the content text from a file
            text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\text.txt")

            ' Create a font for the content text
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16.0F))

            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            '   Dim font2 As New PdfTrueTypeFont("Arial", 16.0F)
            ' =============================================================================

            ' Set the line spacing for the content text
            format2.LineSpacing = font2.Size * 1.5F

            ' Create a layouter to handle text layout
            Dim textLayouter As New PdfStringLayouter()

            ' Calculate the height of the remaining space for text
            Dim imageLeftBlockHeight As Single = imageBottom - y

            ' Layout the text with the specified font, format, and available space
            Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font2, format2, New SizeF(imageLeftSpace, imageLeftBlockHeight))

            ' Check if the actual height of the layout is smaller than the available space
            If result.ActualSize.Height < imageLeftBlockHeight Then
                ' Adjust the available space by adding the line height
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight

                ' Layout the text again with the adjusted space
                result = textLayouter.Layout(text, font2, format2, New SizeF(imageLeftSpace, imageLeftBlockHeight))
            End If

            ' Iterate over each line in the layout result
            For Each line As LineInfo In result.Lines
                ' Draw each line of text on the page
                page.Canvas.DrawString(line.Text, font2, brush, 0, y, format2)

                ' Update the y coordinate for the next line
                y = y + result.LineHeight
            Next line

            ' Create a text widget for the remaining text
            Dim textWidget As New PdfTextWidget(result.Remainder, font2, brush)

            ' Create a text layout for pagination
            Dim textLayout As New PdfTextLayout()
            textLayout.Break = PdfLayoutBreakType.FitPage
            textLayout.Layout = PdfLayoutType.Paginate

            ' Set the bounding rectangle for the text widget
            Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)

            ' Set the string format for the text widget
            textWidget.StringFormat = format2

            ' Draw the remaining text on the page using the text widget and layout settings
            textWidget.Draw(page, bounds, textLayout)

            ' Save the document to a file
            Dim output As String = "PlaceTextAroundImage_out.pdf"
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
