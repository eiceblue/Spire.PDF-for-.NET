Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace TextLayout
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

            ' Create a pen and brush for drawing
            Dim pen1 As New PdfPen(Color.LightGray, 1.0F)
            Dim brush1 As PdfBrush = New PdfSolidBrush(Color.LightGray)

            ' Create a font for text
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 8.0F, FontStyle.Italic))

            ' Create a string format for text alignment
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Right)

            ' Set the text to be drawn
            Dim text As String = "Demo of Spire.Pdf"

            ' Draw the text on the page
            page.Canvas.DrawString(text, font1, brush1, pageWidth - 2, y, format1)

            ' Measure the size of the drawn text
            Dim size As SizeF = font1.MeasureString(text, format1)

            ' Update the y coordinate
            y = y + size.Height + 1

            ' Draw a horizontal line
            page.Canvas.DrawLine(pen1, 0, y, pageWidth, y)

            ' Update the y coordinate
            y = y + 25

            ' Create a brush and font for the header
            Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 18.0F, FontStyle.Bold))

            ' Create a string format for center alignment
            Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)

            ' Set character spacing
            format2.CharacterSpacing = 1.0F

            ' Set the header text
            text = "Summary of Science"

            ' Draw the header on the page
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)

            ' Measure the size of the drawn text
            size = font2.MeasureString(text, format2)

            ' Update the y coordinate
            y = y + size.Height + 16

            ' Load an image file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Wikipedia_Science.png")

            ' Draw the image on the page
            page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))

            ' Calculate the position of the image
            Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
            Dim imageBottom As Single = image.PhysicalDimension.Height + y

            ' Create a font and string format for the content
            Dim font3 As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            Dim format3 As New PdfStringFormat()

            ' Set paragraph indentation, trailing spaces, and line spacing
            format3.ParagraphIndent = font3.Size * 2
            format3.MeasureTrailingSpaces = True
            format3.LineSpacing = font3.Size * 1.5F

            ' Set the first part of the content text
            Dim text1 As String = "(All text and picture from "

            ' Set the second part of the content text
            Dim text2 As String = "Wikipedia"

            ' Set the third part of the content text
            Dim text3 As String = ", the free encyclopedia)"

            ' Draw the first part of the content text
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

            ' Measure the size of the drawn text
            size = font3.MeasureString(text1, format3)

            ' Calculate the x coordinate
            Dim x1 As Single = size.Width

            ' Reset paragraph indentation
            format3.ParagraphIndent = 0

            ' Create a font and brush for underlined text
            Dim font4 As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Underline))
            Dim brush3 As PdfBrush = PdfBrushes.Blue

            ' Draw the second part of the content text
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)

            ' Measure the size of the drawn text
            size = font4.MeasureString(text2, format3)

            ' Update the x coordinate
            x1 = x1 + size.Width

            ' Draw the third part of the content text
            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)

            ' Update the y coordinate
            y = y + size.Height

            ' Create a string format for the remaining text
            Dim format4 As New PdfStringFormat()

            ' Read the remaining text from a file
            text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\Summary_of_Science.txt")

            ' Create a font for the content text
            Dim font5 As New PdfTrueTypeFont(New Font("Arial", 12.0F))

            ' Set the line spacing for the content text
            format4.LineSpacing = font5.Size * 1.5F

            ' Create a layouter to handle text layout
            Dim textLayouter As New PdfStringLayouter()

            ' Calculate the height of the remaining space for text
            Dim imageLeftBlockHeight As Single = imageBottom - y

            ' Layout the text with the specified font, format, and available space
            Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))

            ' Check if the actual height of the layout is smaller than the available space
            If result.ActualSize.Height < imageBottom - y Then
                ' Adjust the available space by adding the line height
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight

                ' Layout the text again with the adjusted space
                result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
            End If

            ' Iterate over each line in the layout result
            For Each line As LineInfo In result.Lines
                ' Draw each line of text on the page
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4)

                ' Update the y coordinate for the next line
                y = y + result.LineHeight + 2
            Next line

            ' Create a text widget for the remaining text
            Dim textWidget As New PdfTextWidget(result.Remainder, font5, brush2)

            ' Create a text layout for pagination
            Dim textLayout As New PdfTextLayout()
            textLayout.Break = PdfLayoutBreakType.FitPage
            textLayout.Layout = PdfLayoutType.Paginate

            ' Set the bounding rectangle for the text widget
            Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)

            ' Set the string format for the text widget
            textWidget.StringFormat = format4

            ' Draw the remaining text on the page using the text widget and layout settings
            textWidget.Draw(page, bounds, textLayout)

            ' Save the document to a file
            doc.SaveToFile("TextLayout.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("TextLayout.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
