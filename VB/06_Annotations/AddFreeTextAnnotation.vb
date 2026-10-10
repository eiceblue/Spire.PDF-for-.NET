Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics

Namespace AddFreeTextAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Load the existing PDF document
            Dim doc As PdfDocument = New PdfDocument()
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\AddFreeTextAnnotation.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages[0]

            ' Define a rectangle for the free text annotation
            Dim rect As RectangleF = New RectangleF(0, 300, 100, 80)
            Dim font As PdfFont = New PdfFont(PdfFontFamily.TimesRoman, 20)

            'Add free text annotation
            Dim textAnnotation As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\n  Spire.PDF"
            textAnnotation.Border.Width = 1f

            textAnnotation.Border.Color = Color.Gray
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Slash
            textAnnotation.Color = Color.LightBlue
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 200, 150, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\nHigh Fidelity Pdf file Conversion"
            textAnnotation.Border.Width = 1f

            textAnnotation.Border.Color = Color.LightGoldenrodYellow
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow
            textAnnotation.Color = Color.LightPink
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 280, 280, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\nEasily Manipulate document and Form fields"
            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.Gray
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.Circle
            textAnnotation.Color = Color.LightSkyBlue
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 360, 200, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\nSecurity features"

            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.Pink
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow
            textAnnotation.Color = Color.LightGreen
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            rect = New RectangleF(150, 440, 200, 40)
            font = New PdfFont(PdfFontFamily.Helvetica, 10)
            textAnnotation = New PdfFreeTextAnnotation(page, rect, New PdfDefaultAppearance(font))
            textAnnotation.Contents = "\nExtract data from Pdf documents"

            textAnnotation.Border.Width = 1f
            textAnnotation.Border.Color = Color.OrangeRed
            textAnnotation.CalloutLineEndingStyle = PdfLineEndingStyle.RClosedArrow
            textAnnotation.Color = Color.LightGoldenrodYellow
            textAnnotation.StrokingOpacity = 0.8f
            textAnnotation.RefreshAppearances()
            PdfAnnotationCollection.Create(page).Add(textAnnotation)

            Dim output As String = "AddFreeTextAnnotation.pdf"

            'Save pdf file
            doc.SaveToFile(output)
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
