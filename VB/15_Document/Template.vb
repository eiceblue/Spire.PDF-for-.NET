Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.AutomaticFields
Imports System.IO

Namespace Template
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Set the page layout of the viewer preferences to TwoColumnLeft
            doc.ViewerPreferences.PageLayout = PdfPageLayout.TwoColumnLeft

            ' Create a new PdfUnitConvertor object for unit conversion
            Dim unitCvtr As New PdfUnitConvertor()

            ' Create a new PdfMargins object for setting margins
            Dim margin As New PdfMargins()

            ' Set the top margin using unit conversion from centimeter to point
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the bottom margin equal to the top margin
            margin.Bottom = margin.Top

            ' Set the left margin using unit conversion from centimeter to point
            margin.Left = unitCvtr.ConvertUnits(3.17F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the right margin equal to the left margin
            margin.Right = margin.Left

            ' Set the document template with specified page size and margins
            SetDocumentTemplate(doc, PdfPageSize.A4, margin)

            ' Add a new section to the document
            Dim section As PdfSection = doc.Sections.Add()

            ' Set the page settings of the section to A4 size and zero margins
            section.PageSettings.Size = PdfPageSize.A4
            section.PageSettings.Margins = New PdfMargins(0)

            ' Set the section template with specified page size, margins, and title
            SetSectionTemplate(section, PdfPageSize.A4, margin, "Section 1")

            ' Add multiple pages to the section and draw their content
            Dim page As PdfNewPage = section.Pages.Add()
            DrawPage(page)

            page = section.Pages.Add()
            DrawPage(page)

            page = section.Pages.Add()
            DrawPage(page)

            page = section.Pages.Add()
            DrawPage(page)

            page = section.Pages.Add()
            DrawPage(page)

            ' Save the document to a file
            doc.SaveToFile("Template.pdf")

            ' Close the PDF document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Template.pdf")
        End Sub

        Private Sub SetSectionTemplate(ByVal section As PdfSection, ByVal pageSize As SizeF, ByVal margin As PdfMargins, ByVal label As String)
            ' Create a new PdfPageTemplateElement for the left space of the page
            Dim leftSpace As New PdfPageTemplateElement(margin.Left, pageSize.Height)
            leftSpace.Foreground = True
            section.Template.OddLeft = leftSpace

            ' Create a new PdfTrueTypeFont for the text font
            Dim font As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Italic))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 9.0F, FontStyle.Italic, True)
            ' =============================================================================

            ' Create a new PdfStringFormat for text alignment and vertical alignment
            Dim format As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

            ' Calculate the y-coordinate for the text placement based on page size and margins
            Dim y As Single = (pageSize.Height - margin.Top - margin.Bottom) * (1 - 0.618F)

            ' Define the bounds of the rectangle for drawing on the left space
            Dim bounds As New RectangleF(10, y, margin.Left - 20, font.Height + 6)

            ' Draw a rectangle with OrangeRed color on the left space
            leftSpace.Graphics.DrawRectangle(PdfBrushes.OrangeRed, bounds)

            ' Draw the label text in white color within the rectangle
            leftSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format)

            ' Create a new PdfPageTemplateElement for the right space of the page
            Dim rightSpace As New PdfPageTemplateElement(margin.Right, pageSize.Height)
            rightSpace.Foreground = True
            section.Template.EvenRight = rightSpace

            ' Define the bounds of the rectangle for drawing on the right space
            bounds = New RectangleF(10, y, margin.Right - 20, font.Height + 6)

            ' Draw a rectangle with SaddleBrown color on the right space
            rightSpace.Graphics.DrawRectangle(PdfBrushes.SaddleBrown, bounds)

            ' Draw the label text in white color within the rectangle
            rightSpace.Graphics.DrawString(label, font, PdfBrushes.White, bounds, format)
        End Sub

        Private Sub SetDocumentTemplate(ByVal doc As PdfDocument, ByVal pageSize As SizeF, ByVal margin As PdfMargins)
            ' Create a new PdfPageTemplateElement for the left space of the page
            Dim leftSpace As New PdfPageTemplateElement(margin.Left, pageSize.Height)
            doc.Template.Left = leftSpace

            ' Create a new PdfPageTemplateElement for the top space of the page
            Dim topSpace As New PdfPageTemplateElement(pageSize.Width, margin.Top)
            topSpace.Foreground = True
            doc.Template.Top = topSpace

            ' Create a new PdfTrueTypeFont for the text font
            Dim font As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Italic))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 9.0F, FontStyle.Italic, True)
            ' =============================================================================


            ' Create a new PdfStringFormat for text alignment
            Dim format As New PdfStringFormat(PdfTextAlignment.Right)

            ' Define the label and measure its size with the specified font and format
            Dim label As String = "Demo of Spire.Pdf"
            Dim size As SizeF = font.MeasureString(label, format)

            ' Calculate the y-coordinate for drawing on the top space
            Dim y As Single = topSpace.Height - font.Height - 1

            ' Create a new PdfPen for drawing lines
            Dim pen As New PdfPen(Color.Black, 0.75F)

            ' Set transparency for the top space graphics
            topSpace.Graphics.SetTransparency(0.5F)

            ' Draw a line on the top space using the pen
            topSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)

            ' Adjust the y-coordinate for drawing the label below the line
            y = y - 1 - size.Height

            ' Draw the label text in black color on the top space
            topSpace.Graphics.DrawString(label, font, PdfBrushes.Black, pageSize.Width - margin.Right, y, format)

            ' Create a new PdfPageTemplateElement for the right space of the page
            Dim rightSpace As New PdfPageTemplateElement(margin.Right, pageSize.Height)
            doc.Template.Right = rightSpace

            ' Create a new PdfPageTemplateElement for the bottom space of the page
            Dim bottomSpace As New PdfPageTemplateElement(pageSize.Width, margin.Bottom)
            bottomSpace.Foreground = True
            doc.Template.Bottom = bottomSpace

            ' Adjust the y-coordinate for drawing lines on the bottom space
            y = font.Height + 1

            ' Set transparency for the bottom space graphics
            bottomSpace.Graphics.SetTransparency(0.5F)

            ' Draw a line on the bottom space using the pen
            bottomSpace.Graphics.DrawLine(pen, margin.Left, y, pageSize.Width - margin.Right, y)

            ' Increment the y-coordinate for drawing text below the line
            y = y + 1

            ' Create instances of PdfPageNumberField and PdfPageCountField
            Dim pageNumber As New PdfPageNumberField()
            Dim pageCount As New PdfPageCountField()

            ' Create a composite field for displaying page number and total pages
            Dim pageNumberLabel As New PdfCompositeField()
            pageNumberLabel.AutomaticFields = New PdfAutomaticField() {pageNumber, pageCount}
            pageNumberLabel.Brush = PdfBrushes.Black
            pageNumberLabel.Font = font
            pageNumberLabel.StringFormat = format
            pageNumberLabel.Text = "page {0} of {1}"

            ' Draw the page number label on the bottom space
            pageNumberLabel.Draw(bottomSpace.Graphics, pageSize.Width - margin.Right, y)

            ' Load header and footer images from file
            Dim headerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Header.png")
            Dim footerImage As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Footer.png")

            ' Define the position of the header image
            Dim pageLeftTop As New PointF(-margin.Left, -margin.Top)
            Dim header As New PdfPageTemplateElement(pageLeftTop, headerImage.PhysicalDimension)
            header.Foreground = False
            header.Graphics.SetTransparency(0.5F)

            ' Draw the header image on the page template
            header.Graphics.DrawImage(headerImage, 0, 0)

            ' Add the header template to the document's stamps collection
            doc.Template.Stamps.Add(header)

            ' Calculate the y-coordinate for the footer image placement
            y = pageSize.Height - footerImage.PhysicalDimension.Height

            ' Define the position of the footer image
            Dim footerLocation As New PointF(-margin.Left, y)
            Dim footer As New PdfPageTemplateElement(footerLocation, footerImage.PhysicalDimension)
            footer.Foreground = False
            footer.Graphics.SetTransparency(0.5F)

            ' Draw the footer image on the page template
            footer.Graphics.DrawImage(footerImage, 0, 0)

            ' Add the footer template to the document's stamps collection
            doc.Template.Stamps.Add(footer)
        End Sub

        Private Sub DrawPage(ByVal page As PdfPageBase)
            ' Retrieve the width of the page
            Dim pageWidth As Single = page.Canvas.ClientSize.Width

            ' Initialize the y-coordinate
            Dim y As Single = 0

            ' Increase the y-coordinate by 5
            y = y + 5

            ' Create a brush for text color and a font for text styling
            Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font2 As New PdfTrueTypeFont("Arial", 9.0F, FontStyle.Bold, True)
            ' =============================================================================

            ' Create a format for text alignment and spacing
            Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
            format2.CharacterSpacing = 1.0F

            ' Set the text to be displayed
            Dim text As String = "Summary of Science"

            ' Draw the text on the page using the specified font, brush, position, and format
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)

            ' Measure the size of the drawn text
            Dim size As SizeF = font2.MeasureString(text, format2)

            ' Increase the y-coordinate by the height of the drawn text plus some padding
            y = y + size.Height + 6

            ' Load an image from a file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Wikipedia_Science.png")

            ' Draw the image on the page at a specific position
            page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))

            ' Calculate the left space for the image and the bottom position
            Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
            Dim imageBottom As Single = image.PhysicalDimension.Height + y

            ' Display reference content
            Dim font3 As New PdfTrueTypeFont(New Font("Arial", 9.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font3 As New PdfTrueTypeFont("Arial", 9.0F, FontStyle.Regular, True)
            ' =============================================================================
            Dim format3 As New PdfStringFormat()
            format3.ParagraphIndent = font3.Size * 2
            format3.MeasureTrailingSpaces = True
            format3.LineSpacing = font3.Size * 1.5F

            ' Draw the first part of the reference text
            Dim text1 As String = "(All text and picture from "
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

            ' Measure the size of the drawn text
            size = font3.MeasureString(text1, format3)

            ' Calculate the starting position for the next part of the reference text
            Dim x1 As Single = size.Width
            format3.ParagraphIndent = 0

            ' Create a font and a brush for the underlined text
            Dim font4 As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Underline))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font4 As New PdfTrueTypeFont("Arial", 9.0F, FontStyle.Underline, True)
            ' =============================================================================
            Dim brush3 As PdfBrush = PdfBrushes.Blue

            ' Draw the second part of the reference text with underline
            Dim text2 As String = "Wikipedia"
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)

            ' Measure the size of the drawn text
            size = font4.MeasureString(text2, format3)

            ' Update the starting position for the next part of the reference text
            x1 = x1 + size.Width

            ' Draw the third part of the reference text
            Dim text3 As String = ", the free encyclopedia)"
            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)

            ' Increase the y-coordinate by the height of the drawn text
            y = y + size.Height

            ' Configure the format for the main content
            Dim format4 As New PdfStringFormat()
            text = File.ReadAllText("..\..\..\..\..\..\Data\Summary_of_Science.txt")
            Dim font5 As New PdfTrueTypeFont(New Font("Arial", 10.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font5 As New PdfTrueTypeFont("Arial", 10.0F, FontStyle.Regular, True)
            ' =============================================================================
            format4.LineSpacing = font5.Size * 1.5F

            ' Create a layouter for arranging the text
            Dim textLayouter As New PdfStringLayouter()

            ' Calculate the available height for the main content block
            Dim imageLeftBlockHeight As Single = imageBottom - y

            ' Layout the text to fit within the available space
            Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))

            ' Adjust the available height if the actual content height is smaller
            If result.ActualSize.Height < imageBottom - y Then
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
                result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
            End If

            ' Draw each line of the main content
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

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        End Sub

    End Class
End Namespace
