Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Destinations
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace GoToAction
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document.
            Dim pdf As PdfDocument = New PdfDocument()

            ' Add a page to the document.
            Dim page As PdfPageBase = pdf.Pages.Add()

            ' Add an embedded GoToE (Go-To Embedded) action to the PDF.
            EmbeddedGoToAction(pdf, page)

            ' Create an action that jumps to a specific location.
            JumpToSpecificLocationAction(pdf, page)

            ' Save and launch the PDF document.
            pdf.SaveToFile("GoToAction.pdf")

            PDFDocumentViewer("GoToAction.pdf")

        End Sub

        ''' <summary>
        ''' GoToE action
        ''' </summary>
        ''' <param name="pdf"></param>
        Private Shared Sub EmbeddedGoToAction(ByVal pdf As PdfDocument, ByVal page As PdfPageBase)
            ' Add an attachment to the PDF.
            Dim attachment As PdfAttachment = New PdfAttachment(@"..\..\..\..\..\..\Data\GoToAction.pdf")
            pdf.Attachments.Add(attachment)

            ' Specify the text to be displayed on the page.
            Dim text As String = "Test embedded go-to action! Clicking this will open the attached PDF in a New window."

            ' Define the font and dimensions of the text box.
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 13f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
              Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 13f, PdfFontStyle.Regular, True)
            */
            Dim width As Single = 490f
            Dim height As Single = font.Height * 2.2f
            Dim rect As RectangleF = New RectangleF(0, 100, width, height)

            ' Draw the text on the page.
            page.Canvas.DrawString(text, font, PdfBrushes.Black, rect)

            'create a PdfDestination with specific page, location and 200% zoom factor
            'PdfXYZExplicitDestination dest = new PdfXYZExplicitDestination(1, new PointF(0, 842), 2f);

            'create GoToE action with dest
            Dim action As PdfGoToEmbeddedAction = New PdfGoToEmbeddedAction(attachment.FileName, 1, 2f)
            action.NewWindow = True
            Dim annotationRect As RectangleF = New RectangleF(rect.X + 40, rect.Y + 40, rect.Width, rect.Height)
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, annotationRect, action)
            'add the annotation
            PdfAnnotationCollection.Create(page).Add(annotation)

        End Sub

        Private Shared Sub JumpToSpecificLocationAction(ByVal pdf As PdfDocument, ByVal page As PdfPageBase)
            ' Add a new page to the PDF document.
            Dim pagetwo As PdfPageBase = pdf.Pages.Add()

            ' Draw text on the second page.
            pagetwo.Canvas.DrawString("This Is Page Two.",
                                       New PdfFont(PdfFontFamily.Helvetica, 20f),
                                       New PdfSolidBrush(Color.Black),
                                       10, 10)

            'create PdfDestination instance and link to PdfGoToAction
            Dim pageBottomDest As PdfXYZExplicitDestination = New PdfXYZExplicitDestination(pagetwo, 0, 5, 1f)
            Dim action As PdfGoToAction = New PdfGoToAction(pageBottomDest)

            ' Define the font, dimensions, and formatting for a button.
            Dim buttonFont As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 10f, FontStyle.Bold))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim buttonFont As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 10f, PdfFontStyle.Bold, True)
            */
            Dim buttonWidth As Single = 70
            Dim buttonHeight As Single = buttonFont.Height * 1.5f
            Dim format2 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            Dim buttonBounds As RectangleF = New RectangleF(0, 200, buttonWidth, buttonHeight)

            ' Create a rectangle and draw text on the first page.
            page.Canvas.DrawRectangle(PdfBrushes.DarkGray, buttonBounds)
            page.Canvas.DrawString("To Last Page", buttonFont, PdfBrushes.CadetBlue, buttonBounds, format2)

            ' Add the annotation to the first page.
            Dim annotationRect As RectangleF = New RectangleF(buttonBounds.X + 40, buttonBounds.Y + 40, buttonBounds.Width, buttonBounds.Height)
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, annotationRect, action)
            annotation.Border.Width = 0.75f
            annotation.Color = Color.LightGray
            PdfAnnotationCollection.Create(page).Add(annotation)

        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
