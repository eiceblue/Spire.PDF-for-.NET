Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Texts

Namespace ExtractHighlightedText
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            'Create a pdf instance
            Dim doc As PdfDocument = New PdfDocument()

            'Load a pdf file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\ExtractHighlightedText.pdf")

            Dim page As PdfPageBase = doc.Pages[0]
            Dim textMarkupAnnotation As PdfTextMarkupAnnotation
            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.AppendLine("Extracted hightlighted text:")
            'Get PdfTextMarkupAnnotationWidget objects
            Dim i As Integer = 0
            While i < page.Annotations.Count
                If PdfAnnotationCollection.Create(page)[i] is PdfTextMarkupAnnotation Then
                    textMarkupAnnotation = PdfAnnotationCollection.Create(page)[i] as PdfTextMarkupAnnotation
                    'Get the highlighted text
                    Dim textExtractor As PdfTextExtractor = New PdfTextExtractor(page)
                    Dim option As PdfTextExtractOptions = New PdfTextExtractOptions()
                    option.ExtractArea = textMarkupAnnotation.Rectangle
                    stringBuilder.AppendLine(textExtractor.ExtractText(option))

                    'Get the highlighted color
                    Dim color As Color = textMarkupAnnotation.Color
                End If
            Next
            Dim result As String = "ExtractHighlightedText.txt"
            File.WriteAllText(result, stringBuilder.ToString())
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
