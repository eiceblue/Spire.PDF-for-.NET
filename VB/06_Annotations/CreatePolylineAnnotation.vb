Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations

Namespace CreatePolylineAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Output file
            Dim output As String = "CreatePolylineAnnotation.pdf"
            'Create a pdf document
            Dim pdf As PdfDocument = New PdfDocument()
            'Add a new page
            Dim page As PdfPageBase = pdf.Pages.Add()
            'Create a polyline annotation
            Dim points As PointF[] = New PointF[] { New PointF(40, 100), New PointF(70, 85), New PointF(100, 130), New PointF(130, 120) }
            Dim polyline As PdfPolylineAnnotation = New PdfPolylineAnnotation(page, New RectangleF(40, 85, 90, 45), points)
            'Set properties of polyline
            polyline.Color = Color.PaleVioletRed
            polyline.Contents = "This Is a polygon annotation"
            polyline.Title = "E-ICEBLUE"
            polyline.Subject = "polygon annotation demo"
            polyline.Name = "Test Annotation"
            polyline.Border.Width = 1f
            polyline.Intent = PdfPolyIntent.PolyLineDimension
            polyline.ModifiedDate = DateTime.Now
            'Add the annotation into page
            PdfAnnotationCollection.Create(page).Add(polyline)
            polyline.RefreshAppearances()
            'Save pdf
            pdf.SaveToFile(output, FileFormat.PDF)
            pdf.Close()
            'Launch the Pdf file
            FileViewer(output)
        End Sub
        Private Sub FileViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
