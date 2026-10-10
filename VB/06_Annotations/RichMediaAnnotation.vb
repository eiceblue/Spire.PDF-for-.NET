Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Multimedia.RichMedia

Namespace RichMediaAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the rich media annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 300, 200)

            ' Create a rich media content and a rich media annotation
            Dim content As PdfRichMediaContent = New PdfRichMediaContent()
            Dim annotation As PdfRichMediaAnnotation = New PdfRichMediaAnnotation(page, rect, content)
            annotation.Content = New PdfRichMediaContent()

            ' Set the annotation properties
            annotation.Color = Color.Green
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.Border.Width = 2f
            annotation.Contents = "Contents"
            annotation.Name = "Name"

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "RichMediaAnnotation.pdf"
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
