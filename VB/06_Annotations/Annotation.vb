Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics

Namespace Annotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Create a PdfUnitConvertor object for unit conversion
            Dim unitCvtr As New PdfUnitConvertor()

            ' Create a PdfMargins object for setting the page margins
            Dim margin As New PdfMargins()

            ' Convert and set the top margin to 2.54 centimeters in points
            margin.Top = unitCvtr.ConvertUnits(2.54F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the bottom margin equal to the top margin
            margin.Bottom = margin.Top

            ' Convert and set the left margin to 3 centimeters in points
            margin.Left = unitCvtr.ConvertUnits(3.0F, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)

            ' Set the right margin equal to the left margin
            margin.Right = margin.Left

            ' Add a new page to the document with A4 size and specified margins
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Set up brushes, fonts, and string format for drawing text
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 13.0F, FontStyle.Bold Or FontStyle.Italic), True)
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font1 As New PdfTrueTypeFont("Arial", 13.0F, FontStyle.Bold Or FontStyle.Italic, True)
            ' =============================================================================
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Left)

            ' Set the initial y-coordinate position for drawing text
            Dim y As Single = 50

            ' Set the text content to be drawn on the page
            Dim s As String = "The sample demonstrates how to add annotations in PDF document."

            ' Draw the text on the page using the specified font, brush, and format
            page.Canvas.DrawString(s, font1, brush1, 0, y - 5, format1)

            ' Adjust the y-coordinate position based on the height of the drawn text and some spacing
            y = y + font1.MeasureString(s, format1).Height
            y = y + 15

            ' Call functions to add different types of annotations and update the y-coordinate position accordingly
            y = AddDocumentLinkAnnotation(page, y)

            y = y + 6
            y = AddFileLinkAnnotation(page, y)

            y = y + 6
            y = AddFreeTextAnnotation(page, y)

            y = y + 6
            y = AddLineAnnotation(page, y)

            y = y + 6
            y = AddTextMarkupAnnotation(page, y)

            y = y + 6
            y = AddPopupAnnotation(page, y)

            y = y + 6
            y = AddRubberStampAnnotation(page, y)

            ' Save the document to a PDF file
            doc.SaveToFile("Annotation.pdf")

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("Annotation.pdf")
        End Sub

        Private Function AddDocumentLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new PdfTrueTypeFont object with Arial font and size 12
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new PdfStringFormat object
            Dim format As New PdfStringFormat()

            ' Enable measuring trailing spaces in the string format
            format.MeasureTrailingSpaces = True

            ' Set the prompt text for the document link annotation
            Dim prompt As String = "Document Link: "

            ' Measure the size of the prompt text using the font
            Dim size As SizeF = font.MeasureString(prompt)

            ' Draw the prompt text on the page using the font and specified position
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Calculate the x-coordinate position for subsequent elements based on the width of the prompt text
            Dim x As Single = font.MeasureString(prompt, format).Width

            ' Create a new destination for the document link annotation
            Dim dest As New PdfDestination(page)
            dest.Mode = PdfDestinationMode.Location
            dest.Location = New PointF(0, y)
            dest.Zoom = 2.0F

            ' Set the label text for the document link annotation
            Dim label As String = "Click me, Zoom 200%"

            ' Measure the size of the label text using the font
            size = font.MeasureString(label)

            ' Define the bounds for the document link annotation
            Dim bounds As New RectangleF(x, y, size.Width, size.Height)

            ' Draw the label text on the page using the font and specified position
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Create a new PdfDocumentLinkAnnotation object with the bounds and destination
            Dim annotation As New PdfDocumentLinkAnnotation(bounds, dest)
            annotation.Color = Color.Blue

            ' Add the document link annotation to the page's collection of annotations
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the y-coordinate position for the next annotation
            y = bounds.Bottom

            ' Return the updated y-coordinate position
            Return y
        End Function

        Private Function AddFileLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new PdfTrueTypeFont object with Arial font and size 12
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new PdfStringFormat object
            Dim format As New PdfStringFormat()

            ' Enable measuring trailing spaces in the string format
            format.MeasureTrailingSpaces = True

            ' Set the prompt text for the file link annotation
            Dim prompt As String = "Launch File: "

            ' Measure the size of the prompt text using the font
            Dim size As SizeF = font.MeasureString(prompt)

            ' Draw the prompt text on the page using the font and specified position
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Calculate the x-coordinate position for subsequent elements based on the width of the prompt text
            Dim x As Single = font.MeasureString(prompt, format).Width

            ' Set the label text for the file link annotation
            Dim label As String = "Launch Notepad.exe"

            ' Measure the size of the label text using the font
            size = font.MeasureString(label)

            ' Define the bounds for the file link annotation
            Dim bounds As New RectangleF(x, y, size.Width, size.Height)

            ' Draw the label text on the page using the font and specified position
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Create a new PdfFileLinkAnnotation object with the bounds and file path
            Dim annotation As New PdfFileLinkAnnotation(bounds, "C:\Windows\Notepad.exe")
            annotation.Color = Color.Blue

            ' Add the file link annotation to the page's collection of annotations
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the y-coordinate position for the next annotation
            y = bounds.Bottom

            ' Return the updated y-coordinate position
            Return y
        End Function

        Private Function AddFreeTextAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new PdfTrueTypeFont object with Arial font and size 12
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new PdfStringFormat object
            Dim format As New PdfStringFormat()

            ' Enable measuring trailing spaces in the string format
            format.MeasureTrailingSpaces = True

            ' Set the prompt text for the free text annotation
            Dim prompt As String = "Text Markup: "

            ' Measure the size of the prompt text using the font
            Dim size As SizeF = font.MeasureString(prompt)

            ' Draw the prompt text on the page using the font and specified position
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Calculate the x-coordinate position for subsequent elements based on the width of the prompt text
            Dim x As Single = font.MeasureString(prompt, format).Width

            ' Set the label text for the free text annotation
            Dim label As String = "I'm a text box, not a TV"

            ' Measure the size of the label text using the font
            size = font.MeasureString(label)

            ' Define the bounds for the free text annotation
            Dim bounds As New RectangleF(x, y, size.Width, size.Height)

            ' Draw a rectangle around the free text annotation
            page.Canvas.DrawRectangle(New PdfPen(Color.Blue, 0.1F), bounds)

            ' Draw the label text on the page using the font and specified position
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Set the location for the callout line of the free text annotation
            Dim location As New PointF(bounds.Right + 16, bounds.Top - 16)

            ' Define the bounds for the free text annotation with callout
            Dim annotationBounds As New RectangleF(location, New SizeF(80, 32))

            ' Create a new PdfFreeTextAnnotation object with the bounds and font
            Dim annotation As New PdfFreeTextAnnotation(annotationBounds)

            ' Set the intent for the free text annotation
            annotation.AnnotationIntent = PdfAnnotationIntent.FreeTextCallout

            ' Set the border for the free text annotation
            annotation.Border = New PdfAnnotationBorder(0.5F)

            ' Set the border color for the free text annotation
            annotation.BorderColor = Color.Red

            ' Set the callout lines for the free text annotation
            annotation.CalloutLines = New PointF() {New PointF(bounds.Right, bounds.Top), New PointF(bounds.Right + 8, bounds.Top - 8), location}

            ' Set the color for the free text annotation
            annotation.Color = Color.Yellow

            ' Set the flags for the free text annotation
            annotation.Flags = PdfAnnotationFlags.Locked

            ' Set the font for the free text annotation
            annotation.Font = font

            ' Set the line ending style for the free text annotation
            annotation.LineEndingStyle = PdfLineEndingStyle.OpenArrow

            ' Set the markup text for the free text annotation
            annotation.MarkupText = "Just a joke."

            ' Set the opacity for the free text annotation
            annotation.Opacity = 0.75F

            ' Set the text markup color for the free text annotation
            annotation.TextMarkupColor = Color.Green

            ' Add the free text annotation to the page's collection of annotations
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the y-coordinate position for the next annotation
            y = bounds.Bottom

            ' Return the updated y-coordinate position
            Return y
        End Function

        Private Function AddLineAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new TrueType font object with Arial font and font size 12
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new string format object
            Dim format As New PdfStringFormat()

            ' Enable measuring of trailing spaces in the string format
            format.MeasureTrailingSpaces = True

            ' Define a prompt for the line annotation
            Dim prompt As String = "Line Annotation: "

            ' Measure the size of the prompt using the font
            Dim size As SizeF = font.MeasureString(prompt)

            ' Draw the prompt on the canvas at position (0, y) using the specified font and color
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Calculate the x-coordinate for the next drawing operation
            Dim x As Single = font.MeasureString(prompt, format).Width

            ' Define a label for the line annotation
            Dim label As String = "Line Annotation"

            ' Measure the size of the label using the font
            size = font.MeasureString(label)

            ' Draw the label on the canvas at position (x, y) using the specified font and color
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Define the bounding rectangle for the line annotation
            Dim bounds As New RectangleF(x, y, size.Width, size.Height)

            ' Create an array of integers representing the coordinates of the line points
            Dim linePoints() As Integer = {CInt(Fix(bounds.Left)), CInt(Fix(bounds.Top)), CInt(Fix(bounds.Right)), CInt(Fix(bounds.Bottom))}

            ' Create a new line annotation with the line points and a text description
            Dim annotation As New PdfLineAnnotation(linePoints, "Annotation")

            ' Set the line ending styles for the annotation
            annotation.BeginLineStyle = PdfLineEndingStyle.ClosedArrow
            annotation.EndLineStyle = PdfLineEndingStyle.ClosedArrow

            ' Enable line caption for the annotation
            annotation.LineCaption = True

            ' Set the background color of the annotation to black
            annotation.BackColor = Color.Black

            ' Set the caption type for the annotation to be inline
            annotation.CaptionType = PdfLineCaptionType.Inline

            ' Add the annotation to the page's list of annotations
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the y-coordinate for the next drawing operation
            y = bounds.Bottom

            ' Return the updated y-coordinate
            Return y
        End Function

        Private Function AddTextMarkupAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new TrueType font with Arial, size 12
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new string format
            Dim format As New PdfStringFormat()

            ' Set the MeasureTrailingSpaces property of the format to true
            format.MeasureTrailingSpaces = True

            ' Define the prompt text
            Dim prompt As String = "Highlight incorrect spelling:"

            ' Measure the size of the prompt text using the specified font and format
            Dim size As SizeF = font.MeasureString(prompt, format)

            ' Draw the prompt text on the page's canvas using the specified font, color, and position
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Update the x-coordinate for the next drawing operation
            Dim x As Single = size.Width

            ' Define the label text
            Dim label As String = "demo of annotation"

            ' Draw the label text on the page's canvas using the specified font, color, and position
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Measure the size of the partial text "demo of" using the specified font and format
            size = font.MeasureString("demo of ", format)

            ' Update the x-coordinate for the next drawing operation
            x = x + size.Width

            ' Define the location of the incorrect word
            Dim incorrectWordLocation As New PointF(x, y)

            ' Define the markup text
            Dim markupText As String = "Should be 'annotation'"

            ' Create a new text markup annotation with the markup text, correction, rectangle, and font
            Dim annotation As New PdfTextMarkupAnnotation(markupText, "annotation", New RectangleF(x, y, 100.0F, 100.0F), font)

            ' Set the type of the text markup annotation to "Highlight"
            annotation.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight

            ' Set the color of the text markup annotation to LightSkyBlue
            annotation.TextMarkupColor = Color.LightSkyBlue

            ' Add the annotation to the page's annotations collection
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the y-coordinate for the next drawing operation
            y = y + size.Height

            ' Return the updated y-coordinate
            Return y
        End Function

        Private Function AddPopupAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new TrueType font object with Arial font and font size 12
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new string format object
            Dim format As New PdfStringFormat()

            ' Set the MeasureTrailingSpaces property of the format object to True
            format.MeasureTrailingSpaces = True

            ' Define a prompt string for incorrect spelling markup
            Dim prompt As String = "Markup incorrect spelling: "

            ' Measure the size of the prompt string using the specified font and format
            Dim size As SizeF = font.MeasureString(prompt, format)

            ' Draw the prompt string on the page's canvas using the font and specified coordinates (0, y)
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Update the x-coordinate based on the width of the prompt string
            Dim x As Single = size.Width

            ' Define a label string for annotation demonstration
            Dim label As String = "demo of annotation"

            ' Draw the label string on the page's canvas using the font and updated coordinates (x, y)
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Update the x-coordinate based on the width of the label string
            x = x + font.MeasureString(label, format).Width

            ' Define the markup text for the annotation
            Dim markupText As String = "All words were spelled correctly"

            ' Measure the size of the markup text using the font
            size = font.MeasureString(markupText)

            ' Create a new popup annotation with an empty rectangle and the markup text
            Dim annotation As New PdfPopupAnnotation(New RectangleF(New PointF(x, y), SizeF.Empty), markupText)

            ' Set the icon of the annotation to Paragraph
            annotation.Icon = PdfPopupIcon.Paragraph

            ' Set the Open property of the annotation to True
            annotation.Open = True

            ' Set the color of the annotation to Yellow
            annotation.Color = Color.Yellow

            ' Add the annotation to the page's annotations collection
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the y-coordinate based on the height of the markup text
            y = y + size.Height

            ' Return the updated y-coordinate
            Return y
        End Function

        Private Function AddRubberStampAnnotation(ByVal page As PdfPageBase, ByVal y As Single) As Single
            ' Create a new TrueType font using Arial with a size of 12 points
            Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 12.0F)
            ' =============================================================================

            ' Create a new string format object
            Dim format As New PdfStringFormat()

            ' Set the MeasureTrailingSpaces property of the format object to True
            format.MeasureTrailingSpaces = True

            ' Define a prompt message for incorrect spelling markup
            Dim prompt As String = "Markup incorrect spelling: "

            ' Measure the size of the prompt message using the specified font and format
            Dim size As SizeF = font.MeasureString(prompt, format)

            ' Draw the prompt message on the page's canvas using the font and color
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            ' Update the X-coordinate position for the next drawing operation
            Dim x As Single = size.Width

            ' Define a label for the annotation demonstration
            Dim label As String = "demo of annotation"

            ' Draw the label on the page's canvas using the font and color, starting from the updated X-coordinate position
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)

            ' Update the X-coordinate position again
            x = x + font.MeasureString(label, format).Width

            ' Define the markup text for the annotation
            Dim markupText As String = "Just a draft, not checked."

            ' Measure the size of the markup text using the font
            size = font.MeasureString(markupText)

            ' Create a new rubber stamp annotation with the specified rectangle and markup text
            Dim annotation As New PdfRubberStampAnnotation(New RectangleF(x, y, font.Height, font.Height), markupText)

            ' Set the icon and color properties of the annotation
            annotation.Icon = PdfRubberStampAnnotationIcon.Draft
            annotation.Color = Color.Plum

            ' Add the annotation to the page's list of annotations
            TryCast(page, PdfNewPage).Annotations.Add(annotation)

            ' Update the Y-coordinate position for the next drawing operation
            y = y + size.Height

            ' Return the updated Y-coordinate position
            Return y
        End Function
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
