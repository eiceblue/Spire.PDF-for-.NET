Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Namespace GetBoundsOfTextMarkupAnnotationWidget
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)

            ' Create a PdfDocument object
            Dim doc As PdfDocument = New PdfDocument()
            ' Load a PDF file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\PdfTextMarkupAnnotation.pdf")

            ' Save the obtained text to a .txt file
            Dim sb As StringBuilder = New StringBuilder()

            ' Loop through each page in the document
            For Each page As PdfPageBase In doc.Pages
                ' Get all annotations on the page
                Dim annotations As PdfAnnotationCollection = page.Annotations
                ' Loop through the annotations
                For Each annotation As PdfAnnotation In annotations
                    ' Check if the annotation is a highlight annotation
                    If annotation is PdfTextMarkupAnnotationWidget highlightAnnotation Then
                        'Get annotation Type
                        If highlightAnnotation.TextMarkupAnnotationType == PdfTextMarkupAnnotationType.Highlight Then
                           Dim i As Integer = 0
                           While i < highlightAnnotation.QuadPoints.Length
                                sb.AppendLine("Point"+ i + " X:" +  highlightAnnotation.QuadPoints[i].X.ToString())
                                sb.AppendLine("Point" + i + " Y:" + highlightAnnotation.QuadPoints[i].Y.ToString())
                           Next

                        End If
                    End If
                Next
            Next
            Dim result As String = "result.txt"
            File.WriteAllText(result, sb.ToString())

            'Launch the file.
            DocumentViewer(result)
        End Sub

        Private Sub DocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
