Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace SquareAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Create a square annotation with a cloudy border effect
            Dim rect As RectangleF = New RectangleF(100, 100, 200, 150)
            Dim annotation As PdfSquareAnnotation = New PdfSquareAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Title = "SquareWithEffect"
            annotation.Contents = "A square annotation with a cloudy border effect."
            annotation.Name = "SquareName"
            annotation.Subject = "Square"
            annotation.Color = New PdfRGBColor(128, 0, 128)
            annotation.InteriorColor = New PdfRGBColor(255, 255, 200)
            annotation.Border.Width = 2f
            annotation.Border.Style = PdfBorderStyle.Solid
            annotation.Border.Effect = PdfBorderEffect.Cloudy
            annotation.Border.EffectIntensity = 2
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.RectangleDifferences = New PdfRectangleDifferences(5, 5, 5, 5)

            ' Add the annotation to the page and refresh its appearance
            PdfAnnotationCollection.Create(page).Add(annotation)
            annotation.RefreshAppearances()

            ' Create a second square annotation with a different interior color
            Dim rect2 As RectangleF = New RectangleF(300, 300, 200, 100)
            Dim annotation2 As PdfSquareAnnotation = New PdfSquareAnnotation(page, rect2)
            annotation2.Title = "Square2"
            annotation2.Contents = "A square annotation with a green interior."
            annotation2.Color = Color.Red
            annotation2.InteriorColor = New PdfRGBColor(0, 255, 0)
            annotation2.Border.Width = 2f
            annotation2.RectangleDifferences = New PdfRectangleDifferences(15, 25, 5, 5)
            PdfAnnotationCollection.Create(page).Add(annotation2)
            annotation2.RefreshAppearances()

            ' Save the document
            Dim output As String = "SquareAnnotation.pdf"
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
