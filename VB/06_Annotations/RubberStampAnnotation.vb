Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace RubberStampAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the rubber stamp annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 120, 30)

            ' Create a rubber stamp annotation
            Dim annotation As PdfRubberStampAnnotation = New PdfRubberStampAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Icon = PdfStampIcon.Confidential
            annotation.Intent = PdfStampIntent.Stamp
            annotation.Subject = "Subj"
            annotation.Title = "Title"
            annotation.Contents = "Contents"
            annotation.Name = "Name"
            annotation.Color = New PdfRGBColor(200, 0, 0)
            annotation.Border.Width = 1f
            annotation.Flags = PdfAnnotationFlags.Print

            Dim date As DateTime = New DateTime(2024, 1, 15, 10, 30, 0)
            annotation.CreationDate = date
            annotation.ModifiedDate = date
            annotation.StrokingOpacity = 0.5f
            annotation.NonstrokingOpacity = 0.8f

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "RubberStampAnnotation.pdf"
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
