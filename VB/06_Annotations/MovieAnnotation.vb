Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace MovieAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the movie annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 300, 200)

            ' Create a file specification that references the movie file
            Dim fileSpec As PdfFileSpecification = New PdfFileSpecification(@"..\..\..\..\..\..\Data\Video.mp4")

            ' Create a movie annotation with the file specification
            Dim annotation As PdfMovieAnnotation = New PdfMovieAnnotation(page, rect, fileSpec)

            ' Set the annotation properties
            annotation.Title = "Movie"
            annotation.Contents = "Movie annotation"
            annotation.Name = "MovieName"
            annotation.Color = Color.Red
            annotation.Border.Width = 2f
            annotation.Flags = PdfAnnotationFlags.Print

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Save the document
            Dim output As String = "MovieAnnotation.pdf"
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
