Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace CreatePdfLineAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a PDF document.
            Dim document As PdfDocument = New PdfDocument()

            'Add a new page.
            Dim page As PdfPageBase = document.Pages.Add()

            'Create a line annotation.
            Dim linePoints As Integer[] = New Integer[] { 140, 690, 180, 650 }
            Dim rect As RectangleF = New RectangleF(140, 689, 80, 1)
            Dim lineAnnotation As PdfLineAnnotation = New PdfLineAnnotation(page, rect, New PointF(140, 690), New PointF(220, 690))
            lineAnnotation.Contents = "This Is the first line annotation"

            'Set the line border.
            lineAnnotation.Border.Style = Spire.Pdf.Interactive.Annotations.PdfBorderStyle.Solid
            lineAnnotation.Border.Width = 1

            'Set the line intent.
            lineAnnotation.Intent = PdfLineIntent.LineDimension

            'Set the line style.
            lineAnnotation.StartingStyle = PdfLineEndingStyle.Butt
            lineAnnotation.EndingStyle = PdfLineEndingStyle.Diamond

            'Set the line flag.
            lineAnnotation.Flags = PdfAnnotationFlags.None

            'Set the line color.
            lineAnnotation.InteriorColor = New PdfRGBColor(Color.Green)
            lineAnnotation.Color = New PdfRGBColor(Color.Green)

            'Set the leader line.
            lineAnnotation.LeaderLineExtension = 0
            lineAnnotation.LeaderLine = 0

            'Add the line annotation to the page.
            PdfAnnotationCollection.Create(page).Add(lineAnnotation)

            'Create another line annotation.
            linePoints = New Integer[] { 140, 590, 280, 550 }
            rect = New RectangleF(140, 589, 180, 2)
            lineAnnotation = New PdfLineAnnotation(page, rect, New PointF(140, 590), New PointF(320, 590))
            lineAnnotation.Contents = "This Is the second line annotation"
            lineAnnotation.Border.Style = Spire.Pdf.Interactive.Annotations.PdfBorderStyle.Solid
            lineAnnotation.Border.Width = 2
            lineAnnotation.Intent = PdfLineIntent.LineArrow
            lineAnnotation.StartingStyle = PdfLineEndingStyle.Circle
            lineAnnotation.EndingStyle = PdfLineEndingStyle.Diamond
            lineAnnotation.Flags = PdfAnnotationFlags.None
            lineAnnotation.InteriorColor = New PdfRGBColor(Color.Pink)
            lineAnnotation.Color = New PdfRGBColor(Color.Pink)
            lineAnnotation.LeaderLineExtension = 0
            lineAnnotation.LeaderLine = 0
            PdfAnnotationCollection.Create(page).Add(lineAnnotation)

            'Create yet another line annotation.
            linePoints = New Integer[] { 140, 490, 280, 450 }
            rect = New RectangleF(140, 489, 180, 2)
            lineAnnotation = New PdfLineAnnotation(page, rect, New PointF(140, 490), New PointF(320, 490))
            lineAnnotation.Contents = "This Is the third line annotation"
            lineAnnotation.Border.Style = Spire.Pdf.Interactive.Annotations.PdfBorderStyle.Solid
            lineAnnotation.Border.Width = 2
            lineAnnotation.Intent = PdfLineIntent.LineDimension
            lineAnnotation.StartingStyle = PdfLineEndingStyle.None
            lineAnnotation.EndingStyle = PdfLineEndingStyle.None
            lineAnnotation.Flags = PdfAnnotationFlags.None
            lineAnnotation.InteriorColor = New PdfRGBColor(Color.Blue)
            lineAnnotation.Color = New PdfRGBColor(Color.Blue)
            lineAnnotation.LeaderLineExtension = 1
            lineAnnotation.LeaderLine = 1
            PdfAnnotationCollection.Create(page).Add(lineAnnotation)

            Dim result As String = "CreatePdfLineAnnotation.pdf"

            'Save the document.
            document.SaveToFile(result)
            document.Close()

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
