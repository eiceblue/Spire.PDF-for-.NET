Imports System
Imports System.Windows.Forms
Imports Spire.Pdf
Imports System.IO
Imports System.Text
Imports Spire.Pdf.Interactive.Annotations

Namespace GetAllAnnotationsFromPage
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)

            'Create a new PDF document.
            Dim pdf As PdfDocument = New PdfDocument()

            'Load the file from disk.
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\Template_Pdf_3.pdf")

            'Get all annotations from the first page.
            Dim annotations As PdfAnnotationCollection = PdfAnnotationCollection.Create(pdf.Pages[0])

            Dim content As StringBuilder = New StringBuilder()

            Dim i As Integer = 0
            While i < annotations.Count
                'A text annotation will attach a popup annotation since they are father-son relationship.
                'The annotation information exists in the text annotation, so here we mask the blank popup annotation.
                If annotations[i] is PdfPopupAnnotation Then
                    Continue
                content.AppendLine("Annotation information: ")
                content.AppendLine("Text: " + annotations[i].Contents)
                Dim modifiedDate As String = annotations[i].ModifiedDate.ToString()
                content.AppendLine("ModifiedDate: " + modifiedDate)
                End If

            Dim result As String = "Result-GetAllAnnotationsFromPage.txt"

            'Save to file.
            File.WriteAllText(result, content.ToString())

            pdf.Close()

            'Launch the file.
            PDFDocumentViewer(result)
            Next

        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
        End Sub
    End Class
