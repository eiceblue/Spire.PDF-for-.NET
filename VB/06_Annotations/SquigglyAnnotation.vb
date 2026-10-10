Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace SquigglyAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Draw a sample text that will be marked by the annotation
            Dim font As PdfFont = New PdfFont(PdfFontFamily.Helvetica, 20f)
            Dim brush As PdfSolidBrush = New PdfSolidBrush(Color.Blue)
            page.Canvas.DrawString("Highlight", font, brush, 100, 100)

            ' Define a rectangle for the squiggly annotation
            Dim rect As RectangleF = New RectangleF(130, 145, 100, 25)

            ' Create a squiggly annotation
            Dim annotation As PdfSquigglyAnnotation = New PdfSquigglyAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Color = Color.Red
            annotation.StrokingOpacity = 0.8f
            annotation.NonstrokingOpacity = 0.5f
            annotation.Intent = "Squiggly"
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.Border.Width = 2f
            annotation.Subject = "Subj"
            annotation.Title = "Title"
            annotation.Contents = "Contents"
            annotation.Name = "Name"
            annotation.ModifiedDate = New DateTime(2024, 1, 15, 10, 30, 0)
            annotation.CreationDate = annotation.ModifiedDate

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "SquigglyAnnotation.pdf"
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
