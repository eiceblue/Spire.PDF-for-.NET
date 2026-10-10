Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace UnderlineAnnotation
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
            page.Canvas.DrawString("Underline", font, brush, 100, 100)

            ' Define a rectangle that covers the text
            Dim rect As RectangleF = New RectangleF(134, 139, 100, 25)

            ' Create an underline annotation
            Dim annotation As PdfUnderlineAnnotation = New PdfUnderlineAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Title = "UnderlineTitle"
            annotation.Contents = "An underline markup annotation."
            annotation.Name = "UnderlineName"
            annotation.Subject = "Underline"
            annotation.Color = Color.Red
            annotation.StrokingOpacity = 0.8f
            annotation.NonstrokingOpacity = 0.8f
            annotation.Intent = "Underline"
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "UnderlineAnnotation.pdf"
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
