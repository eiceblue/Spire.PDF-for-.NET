Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace Transition
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document
            Dim doc As New PdfDocument()

            ' Set the viewer preferences to display in full-screen mode
            doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen

            ' Initialize a unit converter for converting measurement units
            Dim unitCvtr As New PdfUnitConvertor()

            ' Set the margins for the pages
            Dim margin As New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            ' Add a section to the document
            Dim section As PdfSection = doc.Sections.Add()

            ' Set the page size and margins for the section
            section.PageSettings.Size = PdfPageSize.A4
            section.PageSettings.Margins = margin

            ' Set the transition settings for the section
            section.PageSettings.Transition = New PdfPageTransition()
            section.PageSettings.Transition.Duration = 2
            section.PageSettings.Transition.Style = PdfTransitionStyle.Fly
            section.PageSettings.Transition.PageDuration = 1

            ' Add a new page to the section with a red background color and draw the content on it
            Dim page As PdfNewPage = section.Pages.Add()
            page.BackgroundColor = Color.Red
            DrawPage(page)

            ' Repeat the above steps for two more pages with different background colors
            page = section.Pages.Add()
            page.BackgroundColor = Color.Green
            DrawPage(page)

            page = section.Pages.Add()
            page.BackgroundColor = Color.Blue
            DrawPage(page)

            ' Add another section with different transition settings
            section = doc.Sections.Add()
            section.PageSettings.Size = PdfPageSize.A4
            section.PageSettings.Margins = margin
            section.PageSettings.Transition = New PdfPageTransition()
            section.PageSettings.Transition.Duration = 2
            section.PageSettings.Transition.Style = PdfTransitionStyle.Box
            section.PageSettings.Transition.PageDuration = 1

            ' Add pages to the section with different background colors and draw the content on them
            page = section.Pages.Add()
            page.BackgroundColor = Color.Orange
            DrawPage(page)

            page = section.Pages.Add()
            page.BackgroundColor = Color.Brown
            DrawPage(page)

            page = section.Pages.Add()
            page.BackgroundColor = Color.Navy
            DrawPage(page)

            ' Add another section with different transition settings
            section = doc.Sections.Add()
            section.PageSettings.Size = PdfPageSize.A4
            section.PageSettings.Margins = margin
            section.PageSettings.Transition = New PdfPageTransition()
            section.PageSettings.Transition.Duration = 2
            section.PageSettings.Transition.Style = PdfTransitionStyle.Split
            section.PageSettings.Transition.Dimension = PdfTransitionDimension.Vertical
            section.PageSettings.Transition.Motion = PdfTransitionMotion.Inward
            section.PageSettings.Transition.PageDuration = 1

            ' Add pages to the section with different background colors and draw the content on them
            page = section.Pages.Add()
            page.BackgroundColor = Color.Orange
            DrawPage(page)

            page = section.Pages.Add()
            page.BackgroundColor = Color.Brown
            DrawPage(page)

            page = section.Pages.Add()
            page.BackgroundColor = Color.Navy
            DrawPage(page)

            ' Save the document to a file and close it
            doc.SaveToFile("Transition.pdf")
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Transition.pdf")
        End Sub

        Private Sub DrawPage(ByVal page As PdfPageBase)
            'Get the width of the page
            Dim pageWidth As Single = page.Canvas.ClientSize.Width

            ' Initialize the starting y-coordinate
            Dim y As Single = 0

            ' Increase the y-coordinate by 5 units
            y = y + 5

            ' Create a brush and font for drawing text
            Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))

            ' Create a string format for center-aligned text
            Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
            format2.CharacterSpacing = 1.0F

            ' Set the text to be drawn
            Dim text As String = "Summary of Science"

            ' Draw the text on the page using the specified font, brush, and format
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)

            ' Measure the size of the drawn text
            Dim size As SizeF = font2.MeasureString(text, format2)

            ' Increase the y-coordinate by the height of the drawn text plus a margin
            y = y + size.Height + 6

            ' Load an image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Wikipedia_Science.png")

            ' Draw the image on the page at the specified position
            page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))

            ' Calculate the position of the image's left side and bottom
            Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
            Dim imageBottom As Single = image.PhysicalDimension.Height + y

            ' Create a new font and string format for additional text
            Dim font3 As New PdfTrueTypeFont(New Font("Arial", 9.0F))
            Dim format3 As New PdfStringFormat()
            format3.ParagraphIndent = font3.Size * 2
            format3.MeasureTrailingSpaces = True
            format3.LineSpacing = font3.Size * 1.5F

            ' Set the text for the additional lines
            Dim text1 As String = "(All text and picture from "
            Dim text2 As String = "Wikipedia"
            Dim text3 As String = ", the free encyclopedia)"

            ' Draw the additional lines of text on the page
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

            ' Measure the size of the drawn text
            size = font3.MeasureString(text1, format3)
            Dim x1 As Single = size.Width
            format3.ParagraphIndent = 0

            ' Create a new font and brush for underlined text
            Dim font4 As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Underline))
            Dim brush3 As PdfBrush = PdfBrushes.Blue

            ' Draw the underlined text on the page
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)

            ' Measure the size of the drawn text
            size = font4.MeasureString(text2, format3)
            x1 = x1 + size.Width

            ' Draw the remaining part of the additional text on the page
            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)

            ' Update the y-coordinate
            y = y + size.Height

            ' Create a new string format for the main text content
            Dim format4 As New PdfStringFormat()

            ' Get the text content from a file
            text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\Summary_of_Science.txt")

            ' Create a new font for the main text content
            Dim font5 As New PdfTrueTypeFont(New Font("Arial", 10.0F))

            ' Set the line spacing for the main text content
            format4.LineSpacing = font5.Size * 1.5F

            ' Create a string layouter for laying out the text
            Dim textLayouter As New PdfStringLayouter()

            ' Calculate the available space for the text on the page
            Dim imageLeftBlockHeight As Single = imageBottom - y

            ' Layout the text within the available space
            Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))

            ' Adjust the available space if necessary to fit the text
            If result.ActualSize.Height < imageBottom - y Then
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
                result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
            End If

            ' Draw each line of the text on the page
            For Each line As LineInfo In result.Lines
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4)
                y = y + result.LineHeight
            Next line

            ' Create a new instance of PdfTextWidget with specified parameters
            Dim textWidget As New PdfTextWidget(result.Remainder, font5, brush2)

            ' Create a new instance of PdfTextLayout
            Dim textLayout As New PdfTextLayout()

            ' Set the break type of textLayout to FitPage
            textLayout.Break = PdfLayoutBreakType.FitPage

            ' Set the layout type of textLayout to Paginate
            textLayout.Layout = PdfLayoutType.Paginate

            ' Create a new instance of RectangleF with specified parameters
            Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)

            ' Set the string format of textWidget to format4
            textWidget.StringFormat = format4

            ' Draw the textWidget on the page within the specified bounds using the given textLayout
            textWidget.Draw(page, bounds, textLayout)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
