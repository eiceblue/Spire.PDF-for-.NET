Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations

Namespace AddInkAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a PDF document
            Dim pdf As PdfDocument = New PdfDocument()

            ' Add a page to the document
            Dim pdfPage As PdfPageBase = pdf.Pages.Add()

            ' Define the points for the ink annotation
            Dim inkList As System.Collections.Generic.List<PointF[]> = New System.Collections.Generic.List<PointF[]>()
            Dim points As PointF[] = New PointF[] { New PointF(140, 840), New PointF(240, 840), New PointF(240, 740) }
            inkList.Add(points)

            ' Create an ink annotation using the defined points
            Dim ia As PdfInkAnnotation = New PdfInkAnnotation(pdfPage, New RectangleF(140, 740, 100, 100), inkList)

            ' Set properties of the ink annotation such as color, border width, opacity, and text
            ia.Color = Color.Pink
            ia.Border.Width = 12
            ia.StrokingOpacity = 0.3f
            ia.Contents = "e-iceblue"

            ' Add the ink annotation to the page's annotation collection
            PdfAnnotationCollection.Create(pdfPage).Add(ia)

            ' Save the document to PDF format
            Dim result As String = "AddInkAnnotation.pdf"
            pdf.SaveToFile(result)
            pdf.Close()

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
