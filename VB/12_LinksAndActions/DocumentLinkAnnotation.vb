Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Destinations
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace DocumentLinkAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document.
            Dim doc As PdfDocument = New PdfDocument()

            ' Create a PdfUnitConvertor to convert units.
            Dim unitCvtr As PdfUnitConvertor = New PdfUnitConvertor()

            ' Set the page margins.
            Dim margin As PdfMargins = New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            ' Add the first page with specified size and margins.
            Dim page1 As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Define a brush for drawing.
            Dim brush1 As PdfBrush = PdfBrushes.Black

            ' Define a font for text.
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Bold), True)
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Bold, True)
            */

            ' Set the string format for text alignment.
            Dim format1 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Left)

            ' Set the position for drawing text.
            Dim x As Single = 0
            Dim y As Single = 50

            ' Specify the text string.
            Dim specification As String = "The sample demonstrates how to create a local document link in a PDF document."

            ' Draw the text string on the first page.
            page1.Canvas.DrawString(specification, font1, brush1, x, y, format1)

            ' Use MeasureString to get the height of the string.
            y = y + font1.MeasureString(specification, format1).Height + 10

            ' Add the second page with specified size and margins.
            Dim page2 As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            ' Specify the text string for the second page.
            Dim pageContent As String = "This Is the second page!"

            ' Draw the text string on the second page.
            page2.Canvas.DrawString(pageContent, font1, brush1, x, y, format1)

            ' Add a DocumentLinkAnnotation on the first page and link it to the second page.
            AddDocumentLinkAnnotation(doc, 0, 1, y)

            ' Specify the output file name.
            Dim result As String = "DocumentLinkAnnotation_out.pdf"

            ' Save the document to the output file.
            doc.SaveToFile(result)

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Shared Sub AddDocumentLinkAnnotation(ByVal pdf As PdfDocument, ByVal AddPage As Integer, ByVal DestinationPage As Integer, ByVal y As Single)
            ' Define a font for text.
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */

            ' Set the string format for text alignment.
            Dim format As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Left)

            ' Specify the prompt text for the link.
            Dim prompt As String = "Local document Link: "

            'Draw text string on page that
            pdf.Pages[AddPage].Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            'Use MeasureString to get the width of string
            Dim x As Single = font.MeasureString(prompt, format).Width

            'Create a PdfDestination with specific page
            Dim dest As PdfXYZExplicitDestination = New PdfXYZExplicitDestination(pdf.Pages[DestinationPage], 0, y)

            'Set 50% zoom factor
            dest.Zoom = 0.5f

            'Label string
            Dim label As String = "Click here to link the second page."

            'Use MeasureString to get the SizeF of string
            Dim size As SizeF = font.MeasureString(label)

            'Draw label string
            pdf.Pages[AddPage].Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            Dim left As Single = pdf.Pages[AddPage].Section.PageSettings.Margins.Left
            Dim top As Single = pdf.Pages[AddPage].Section.PageSettings.Margins.Top
            'Create a rectangle
            Dim bounds As RectangleF = New RectangleF(x + left, y + top, size.Width, size.Height)
            'Create PdfDocumentLinkAnnotation on the rectangle and link to the destination  
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(pdf.Pages[AddPage], bounds, dest)
            'Set color for annotation
            annotation.Color = Color.Blue

            'Add annotation to the page
            PdfAnnotationCollection.Create(pdf.Pages[AddPage]).Add(annotation)

        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
