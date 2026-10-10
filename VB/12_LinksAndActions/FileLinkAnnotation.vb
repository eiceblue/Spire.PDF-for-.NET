Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace FileLinkAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a pdf document
            Dim doc As PdfDocument = New PdfDocument()

            'Create PdfUnitConvertor to convert the unit
            Dim unitCvtr As PdfUnitConvertor = New PdfUnitConvertor()

            'Setting for page margin
            Dim margin As PdfMargins = New PdfMargins()
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Bottom = margin.Top
            margin.Left = unitCvtr.ConvertUnits(3f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
            margin.Right = margin.Left

            'Add one page
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, margin)

            'Define a PdfBrush
            Dim brush1 As PdfBrush = PdfBrushes.Black

            'Define a font
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 13f, FontStyle.Bold), True)
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 13f, PdfFontStyle.Bold, True)
            */

            'Set the string format 
            Dim format1 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Left)

            'Set the position for drawing 
            Dim x As Single = 0
            Dim y As Single = 50

            'Text string 
            Dim specification As String = "The sample demonstrates how to create a file link in PDF document."

            'Draw text string on page canvas
            page.Canvas.DrawString(specification, font1, brush1, x, y, format1)

            'Use MeasureString to get the height of string
            y = y + font1.MeasureString(specification, format1).Height + 10

            'Add file link annotation
            AddFileLinkAnnotation(page, y)

            Dim result As String = "FileLinkAnnotation_out.pdf"

            'Save the document
            doc.SaveToFile(result)

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Shared Sub AddFileLinkAnnotation(ByVal page As PdfPageBase, ByVal y As Single)
            'Define a font
            Dim font As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 12f))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 12f, PdfFontStyle.Regular, True)
            */

            'Set the string format 
            Dim format As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Left)

            'Text string
            Dim prompt As String = "Launch a File: "

            'Draw text string on page canvas
            page.Canvas.DrawString(prompt, font, PdfBrushes.DodgerBlue, 0, y)

            'Use MeasureString to get the width of string
            Dim x As Single = font.MeasureString(prompt, format).Width

            'String of file name
            Dim label As String = "Sample.pdf"

            'Use MeasureString to get the SizeF of string
            Dim size As SizeF = font.MeasureString(label)

            'Create a rectangle
            Dim bounds As RectangleF = New RectangleF(x, y, size.Width, size.Height)

            'Draw label string
            page.Canvas.DrawString(label, font, PdfBrushes.OrangeRed, x, y)
            Dim action As PdfLaunchAction = New PdfLaunchAction(@"..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative)

            'Create PdfFileLinkAnnotation on the rectangle and link file "Sample.pdf"
            Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, bounds, action)

            'Set color for annotation
            annotation.Color = Color.Blue

            'Add annotation to the page
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
