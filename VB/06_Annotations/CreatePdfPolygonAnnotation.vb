Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace CreatePdfPolygonAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a Pdf document.
            Dim pdf As PdfDocument = New PdfDocument()

            'Add a new page to it.
            Dim page As PdfPageBase = pdf.Pages.Add()

            'Initialize an instance of PdfPolygonAnnotation, specifying a rectangle and all vertex coordinates which can form a complete shape.
            Dim points As PointF[] = New PointF[] { New PointF(40, 70), New PointF(70, 55), New PointF(100, 70), New PointF(85, 90), New PointF(55, 90), New PointF(40, 70) }
            Dim polygon As PdfPolygonAnnotation = New PdfPolygonAnnotation(page, New RectangleF(40, 55, 60, 35), points)

            'Set the border color, text, border effect and other properties of polygon annotation.
            polygon.Color = Color.PaleVioletRed
            polygon.Contents = "This Is a polygon annotation"
            polygon.Title = "E-ICEBLUE"
            polygon.Subject = "polygon annotation demo"
            polygon.Border.Effect = PdfBorderEffect.Cloudy
            polygon.Border.EffectIntensity = 2
            polygon.ModifiedDate = DateTime.Now

            'Add the annotation to Pdf page and save the document.
            PdfAnnotationCollection.Create(page).Add(polygon)

            Dim result As String = "CreatePdfPolygonAnnotation.pdf"

            'Save the document
            pdf.SaveToFile(result)
            pdf.Close()

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
