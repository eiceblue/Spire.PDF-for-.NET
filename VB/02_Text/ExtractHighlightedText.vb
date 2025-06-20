Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.Text
Imports System.IO
Imports Spire.Pdf.Texts

Namespace ExtractHighlightedText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load the PDF file from the specified path
            doc.LoadFromFile("..\..\..\..\..\..\Data\ExtractHighlightedText.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Declare variables for text markup annotation and string builder
            Dim textMarkupAnnotation As PdfTextMarkupAnnotationWidget
            Dim stringBuilder As New StringBuilder()

            ' Add a header to the string builder
            stringBuilder.AppendLine("Extracted highlighted text:")

            ' Create a PdfTextExtractor instance for the page
            Dim pdfTextExtractor As New PdfTextExtractor(page)

            ' Iterate through the annotations on the page
            For i As Integer = 0 To page.Annotations.Count - 1

                ' Check if the annotation is a text markup annotation
                If TypeOf page.Annotations(i) Is PdfTextMarkupAnnotationWidget Then

                    ' Cast the annotation to PdfTextMarkupAnnotationWidget
                    textMarkupAnnotation = TryCast(page.Annotations(i), PdfTextMarkupAnnotationWidget)

                    ' Create PdfTextExtractOptions and set the extraction area to the bounds of the annotation
                    Dim pdfTextExtractOptions As New PdfTextExtractOptions()
                    pdfTextExtractOptions.ExtractArea = textMarkupAnnotation.Bounds

                    ' Extract the text using the specified options and append it to the string builder
                    stringBuilder.AppendLine(pdfTextExtractor.ExtractText(pdfTextExtractOptions))

                    ' Get the color of the text markup annotation
                    Dim color As Color = textMarkupAnnotation.TextMarkupColor
                End If
            Next i

            ' Specify the output file path
            Dim result As String = "ExtractHighlightedText.txt"

            ' Write the contents of the string builder to the output file
            File.WriteAllText(result, stringBuilder.ToString())

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
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
