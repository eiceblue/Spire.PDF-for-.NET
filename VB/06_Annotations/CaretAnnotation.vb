Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace CaretAnnotation
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
            page.Canvas.DrawString("Caret", font, brush, 100, 100)

            ' Define a rectangle for the caret annotation
            Dim rect As RectangleF = New RectangleF(150, 112, 20, 20)

            ' Create a caret annotation
            Dim annotation As PdfCaretAnnotation = New PdfCaretAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Title = "CaretTest"
            annotation.Contents = "A caret annotation with a paragraph symbol."
            annotation.Name = "CaretName"
            annotation.Subject = "Caret"
            annotation.Color = Color.Red
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.Intent = "ParaCaret"
            annotation.RectangleDifferences = New PdfRectangleDifferences(5, 5, 3, 3)

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "CaretAnnotation.pdf"
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
