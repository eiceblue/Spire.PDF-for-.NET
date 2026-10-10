Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace ScreenAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the screen annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 200, 100)

            ' Create a screen annotation
            Dim annotation As PdfScreenAnnotation = New PdfScreenAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Title = "My Screen"
            annotation.Color = Color.Red
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.Border.Width = 2f
            annotation.Border.Style = PdfBorderStyle.Dashed
            annotation.Contents = "Contents"
            annotation.Name = "Name"

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "ScreenAnnotation.pdf"
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
