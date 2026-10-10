Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations

Namespace UnknownAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the text annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 200, 100)

            ' Create a text annotation
            Dim annotation As PdfTextAnnotation = New PdfTextAnnotation(page, rect)
            annotation.Contents = "Contents"
            annotation.Name = "Name"
            annotation.Color = Color.Red
            annotation.Border.Width = 1f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the annotation to the page
            PdfAnnotationCollection.Create(page).Add(annotation)

            ' Read the annotations back from the page. Annotation types that
            ' are not recognized by Spire.Pdf are exposed as unknown annotations.
            Dim retrieved As PdfAnnotation = PdfAnnotationCollection.Create(page)[0] as PdfAnnotation

            ' Save the document
            Dim output As String = "UnknownAnnotation.pdf"
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
