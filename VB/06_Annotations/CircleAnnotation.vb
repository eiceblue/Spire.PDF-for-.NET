Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace CircleAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Create a circle annotation with a cloudy border effect
            Dim rect As RectangleF = New RectangleF(100, 100, 150, 150)
            Dim annotation As PdfCircleAnnotation = New PdfCircleAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Title = "CircleWithEffect"
            annotation.Contents = "A circle annotation with a cloudy border effect."
            annotation.Name = "CircleName"
            annotation.Subject = "Circle"
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

            ' Create a second circle annotation with a different interior color
            Dim rect2 As RectangleF = New RectangleF(300, 300, 200, 100)
            Dim annotation2 As PdfCircleAnnotation = New PdfCircleAnnotation(page, rect2)
            annotation2.Title = "Circle2"
            annotation2.Contents = "A circle annotation with a green interior."
            annotation2.Color = Color.Red
            annotation2.InteriorColor = New PdfRGBColor(0, 255, 0)
            annotation2.Border.Width = 2f
            annotation2.RectangleDifferences = New PdfRectangleDifferences(15, 25, 5, 5)
            PdfAnnotationCollection.Create(page).Add(annotation2)
            annotation2.RefreshAppearances()

            ' Save the document
            Dim output As String = "CircleAnnotation.pdf"
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
