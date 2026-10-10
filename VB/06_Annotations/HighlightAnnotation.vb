Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace HighlightAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Draw some text on the page
            Dim font As PdfFont = New PdfFont(PdfFontFamily.Helvetica, 20f)
            Dim brush As PdfSolidBrush = New PdfSolidBrush(Color.Blue)
            page.Canvas.DrawString("Highlight", font, brush, 100, 100)

            ' Define a rectangle that covers the text
            Dim rect As RectangleF = New RectangleF(135, 140, 90, 25)

            ' Create a highlight annotation
            Dim annotation As PdfHighlightAnnotation = New PdfHighlightAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Title = "HighlightTitle"
            annotation.Contents = "A highlight markup annotation."
            annotation.Name = "HighlightName"
            annotation.Subject = "Highlight"
            annotation.Color = New PdfRGBColor(Color.Yellow)
            annotation.StrokingOpacity = 0.8f
            annotation.NonstrokingOpacity = 0.8f
            annotation.Intent = "Highlight"
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "HighlightAnnotation.pdf"
            doc.SaveToFile(output)
            doc.Close()

            ' Launch the Pdf file
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
