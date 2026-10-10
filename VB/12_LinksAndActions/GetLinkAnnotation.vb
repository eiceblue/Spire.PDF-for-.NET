Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Namespace GetLinkAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a pdf document
            Dim doc As PdfDocument = New PdfDocument()

            'Load file from disk
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\LinkAnnotation.pdf")

            'Get the first page
            Dim page As PdfPageBase = doc.Pages[0]

            'Get the annotation collection
            Dim annotations As PdfAnnotationCollection = PdfAnnotationCollection.Create(page)

            'Create StringBuilder to save 
            Dim content As StringBuilder = New StringBuilder()

            'Verify whether widgetCollection is not null or not
            If annotations.Count > 0 Then
                'traverse the PdfAnnotationCollection
                For Each pdfAnnotation As PdfAnnotation In annotations
                    'if it is PdfTextWebLinkAnnotationWidget
                    If pdfAnnotation is PdfLinkAnnotation Then

                        'Get the Url
                        Dim WebLinkAnnotation As PdfLinkAnnotation = pdfAnnotation as PdfLinkAnnotation
                        Dim url As String = (WebLinkAnnotation.Action as PdfURIAction).URI

                        'Add strings to StringBuilder
                        content.AppendLine("The url of link annotation Is " + url.ToString())
                        content.AppendLine("The text of link annotation Is " + WebLinkAnnotation.Contents.ToString())
                    End If
                Next
            End If

            Dim result As String = "GetLinkAnnotation_out.txt"

            'Save them to a txt file
            File.WriteAllText(result, content.ToString())

            'Launch the file
            DocumentViewer(result)
        End Sub
        Private Sub DocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace