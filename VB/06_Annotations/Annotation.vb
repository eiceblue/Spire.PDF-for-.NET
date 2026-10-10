Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Destinations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Namespace Annotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Set margins for the page
            Dim unitCvtr As PdfUnitConvertor = New PdfUnitConvertor()
            Dim margin As PdfMargins = New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            ' Create a page with specified size and margins
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Add a title to the page
            Dim brush1 As PdfBrush = PdfBrushes.Black
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 13f, FontStyle.Bold | FontStyle.Italic), True)
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 13f, PdfFontStyle.Bold|PdfFontStyle.Italic, True)
            */
            Dim format1 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Left)
            Dim y As Single = 50
            Dim s As String = "The sample demonstrates how to add annotations in PDF document."

            page.Canvas.DrawString(s, font1, brush1, 0, y - 5, format1)
            y = y + font1.MeasureString(s, format1).Height
            y = y + 15

            ' Add various types of annotations to the page
            y = AddDocumentLinkAnnotation(page, y, margin)
            y = y + 6
            y = AddFileLinkAnnotation(page, y, margin)
            y = y + 6
            y = AddFreeTextAnnotation(page, y, margin)
            y = y + 6
            y = AddLineAnnotation(page, y, margin)
            y = y + 6
            y = AddTextMarkupAnnotation(page, y, margin)
            y = y + 6
            y = AddPopupAnnotation(page, y, margin)
            y = y + 6
            y = AddRubberStampAnnotation(page, y,margin)

            ' Save the PDF document to a file
            doc.SaveToFile("Annotation.pdf")
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer("Annotation.pdf")
        End Sub

        ' Add a document link annotation to the page
        Private Function AddDocumentLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Document Link: "
            Dim size As SizeF = font.MeasureString(prompt)

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = font.MeasureString(prompt, format).Width

            Dim dest As PdfXYZExplicitDestination = New PdfXYZExplicitDestination(page, 0, y, 2f)

            Dim label As String = "Click me, Zoom 200%"
            size = font.MeasureString(label)
            Dim bounds As RectangleF = New RectangleF(x, y, size.Width, size.Height)
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            Dim rect As RectangleF = New RectangleF(bounds.X + margin.Left, bounds.Y + margin.Top, bounds.Width, bounds.Height)
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, rect, dest)
            annotation.Color = Color.Blue
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = bounds.Bottom

            Return y
        End Function

        ' Add a file link annotation to the page
        Private Function AddFileLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 16f, PdfFontStyle.Bold, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Launch File: "
            Dim size As SizeF = font.MeasureString(prompt)

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = font.MeasureString(prompt, format).Width

            Dim label As String = @"Launch Notepad.exe"
            size = font.MeasureString(label)
            Dim bounds As RectangleF = New RectangleF(x, y, size.Width, size.Height)
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            Dim rect As RectangleF = New RectangleF(bounds.X + margin.Left, bounds.Y + margin.Top, bounds.Width, bounds.Height)
            Dim action As PdfLaunchAction = New PdfLaunchAction(@"C:\Windows\Notepad.exe")
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, rect, action)

            annotation.Color = Color.Blue
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = bounds.Bottom

            Return y
        End Function

        ' Add a free text annotation to the page
        Private Function AddFreeTextAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Text Markup: "
            Dim size As SizeF = font.MeasureString(prompt)

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = font.MeasureString(prompt, format).Width

            Dim label As String = @"I'm a text box, not a TV"
            size = font.MeasureString(label)
            Dim bounds As RectangleF = New RectangleF(x, y, size.Width, size.Height)
            page.Canvas.DrawRectangle(New PdfPen(Color.Blue, 0.1f), bounds)
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            Dim location As PointF = New PointF(bounds.Right + 16, bounds.Top - 16)
            Dim rect As RectangleF = New RectangleF(location.X + margin.Left, location.Y + margin.Top, 80, 32)
            Dim defaultAppearance As PdfDefaultAppearance = New PdfDefaultAppearance(font, Color.Green)
            Dim annotation As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(page, rect, defaultAppearance)
            annotation.Intent = PdfFreeTextIntent.FreeTextCallout
            annotation.Border.Width = 0.5f
            annotation.Border.Color = Color.Red
            location = New PointF(bounds.Right + 16, bounds.Top - 16)
            annotation.CalloutLine
                = New PointF[] {
                    New PointF(bounds.Right + margin.Left, bounds.Top  + margin.Top),
                    New PointF(bounds.Right + 8 + margin.Left, bounds.Top - 8  + margin.Top),
                    New PointF(location.X + margin.Left, location.Y +  + margin.Top) }
            annotation.Color = Color.Yellow
            annotation.Flags = PdfAnnotationFlags.Locked
            annotation.CalloutLineEndingStyle = PdfLineEndingStyle.OpenArrow
            annotation.Contents = "Just a joke."
            annotation.StrokingOpacity = 0.75f
            annotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = bounds.Bottom

            Return y
        End Function

        ' Add a line annotation to the page
        Private Function AddLineAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Line Annotation: "
            Dim size As SizeF = font.MeasureString(prompt)

            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = font.MeasureString(prompt, format).Width

            Dim label As String = @"Line Anotation"
            size = font.MeasureString(label)
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            Dim bounds As RectangleF = New RectangleF(x, y, size.Width, size.Height)
            Dim rect As RectangleF = New RectangleF(bounds.X + margin.Left, bounds.Y + margin.Top, bounds.Width, bounds.Height)
            Dim linePoints As Integer[] = New Integer[]
                (Integer)rect.Left, (Integer)rect.Top, (Integer)rect.Right, (Integer)rect.Bottom
            Dim annotation As PdfLineAnnotation = New PdfLineAnnotation(page, rect, New PointF(linePoints[0], linePoints[1]), New PointF(linePoints[2], linePoints[3]))
            annotation.Contents = "Annotation"
            annotation.StartingStyle = PdfLineEndingStyle.ClosedArrow
            annotation.EndingStyle = PdfLineEndingStyle.ClosedArrow
            annotation.ShowCaption = True
            annotation.Color = Color.Black
            annotation.CaptionPosition = PdfCaptionPosition.Inline
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = bounds.Bottom

            Return y
        End Function

        ' Add a text markup annotation to the page
        Private Function AddTextMarkupAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Highlight incorrect spelling: "
            Dim size As SizeF = font.MeasureString(prompt, format)
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = size.Width

            Dim label As String = "demo of anotation"
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            size = font.MeasureString("demo of ", format)
            x = x + size.Width
            Dim markupText As String = "Should be 'annotation'"
            Dim annotation As PdfHighlightAnnotation = New PdfHighlightAnnotation(page, New RectangleF(x + margin.Left, y + margin.Top, 50f, 15f))
            annotation.Contents = "anotation"
            annotation.Title = markupText
            annotation.Color = Color.LightSkyBlue
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = y + size.Height

            Return y
        End Function

        ' Add a popup annotation to the page
        Private Function AddPopupAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Markup incorrect spelling: "
            Dim size As SizeF = font.MeasureString(prompt, format)
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = size.Width

            Dim label As String = "demo of annotation"
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            x = x + font.MeasureString(label, format).Width
            Dim markupText As String = "All words were spelled correctly"
            size = font.MeasureString(markupText)
            Dim annotation As PdfPopupAnnotation
                = New PdfPopupAnnotation(page, New RectangleF(New PointF(x + margin.Left, y + margin.Top), SizeF.Empty))
            annotation.Contents = markupText
            annotation.Open = True
            annotation.Color = Color.Yellow
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = y + size.Height

            Return y
        End Function

        ' Add a rubber stamp annotation to the page
        Private Function AddRubberStampAnnotation(ByVal page As PdfPageBase, ByVal y As Single, ByVal margin As PdfMargins) As Single
            ' Set up font and formatting
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Bold, True)
            */
            Dim format As PdfStringFormat = New PdfStringFormat()
            format.MeasureTrailingSpaces = True
            Dim prompt As String = "Markup incorrect spelling: "
            Dim size As SizeF = font.MeasureString(prompt, format)
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)
            Dim x As Single = size.Width

            Dim label As String = "demo of annotation"
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            x = x + font.MeasureString(label, format).Width
            Dim markupText As String = "Just a draft, not checked."
            size = font.MeasureString(markupText)
            Dim annotation As PdfRubberStampAnnotation
                = New PdfRubberStampAnnotation(page, New RectangleF(x + margin.Left, y + margin.Top, font.Height, font.Height))
            annotation.Contents = markupText
            annotation.Icon = PdfStampIcon.Draft
            annotation.Color = Color.Plum
            PdfAnnotationCollection.Create(page).Add(annotation)
            y = y + size.Height

            Return y

        End Function

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
