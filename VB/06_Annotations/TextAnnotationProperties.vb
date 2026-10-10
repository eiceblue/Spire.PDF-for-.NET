Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace TextAnnotationProperties
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Load old PDF from disk.
            Dim pdf As PdfDocument = New PdfDocument()
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\FreeTextAnnotation.pdf")

            'Get the first page.
            Dim firstPage As PdfPageBase = pdf.Pages[0]

            'Create a new PDF document.
            Dim newPdf As PdfDocument = New PdfDocument()

            'Traverse the annotations of the first page of old PDF
            For Each annotation As PdfAnnotation In PdfAnnotationCollection.Create(firstPage)
                'If it is FreeTextAnnotation
                If annotation is PdfFreeTextAnnotation Then
                    Dim textAnnotation As PdfFreeTextAnnotation = annotation as PdfFreeTextAnnotation

                    'Get its bounds and text
                    Dim rect As var = textAnnotation.Rectangle
                    Dim text As var = textAnnotation.Contents

                    'Add new page for newPdf
                    Dim newPage As PdfPageBase = newPdf.Pages.Add(firstPage.Size)

                    'Add annotation with the same settings as the annotation of old PDF
                    Dim font As PdfFont = New PdfFont(PdfFontFamily.Helvetica, 10)
                    Dim newAnnotation As PdfFreeTextAnnotation = New PdfFreeTextAnnotation(newPage, rect, New PdfDefaultAppearance(font))
                    newAnnotation.Contents = text
                    newAnnotation.CalloutLine = textAnnotation.CalloutLine
                    newAnnotation.CalloutLineEndingStyle = textAnnotation.CalloutLineEndingStyle
                    newAnnotation.RectangleDifferences = textAnnotation.RectangleDifferences
                    newAnnotation.Color = textAnnotation.Color
                    newAnnotation.Intent = PdfFreeTextIntent.FreeTextCallout
                    PdfAnnotationCollection.Create(newPage).Add(newAnnotation)
                End If
            Next

            'Save the document
            Dim result As String = "TextAnnotationProperties.pdf"
            newPdf.SaveToFile(result)
            newPdf.Close()

            'Launch the file.
            DocumentViewer(result)
        End Sub

        Private Sub DocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
