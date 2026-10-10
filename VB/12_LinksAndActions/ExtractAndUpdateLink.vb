Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Windows.Forms

Namespace ExtractAndUpdateLink
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

            'Verify whether widgetCollection is not null or not
            If annotations.Count > 0 Then
                'traverse the PdfAnnotationCollection
                For Each pdfAnnotation As PdfAnnotation In annotations
                    'if it is PdfTextWebLinkAnnotationWidget
                    If pdfAnnotation is PdfLinkAnnotation Then

                        'Get the link annotation
                        Dim annotation As PdfLinkAnnotation = pdfAnnotation as PdfLinkAnnotation

                        'Change the url
                        (annotation.Action as PdfURIAction).URI = "http://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html"

                    End If
                Next
            End If

            Dim result As String = "ExtractAndUpdateLink_out.pdf"

            'Save the document
            doc.SaveToFile(result)

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

