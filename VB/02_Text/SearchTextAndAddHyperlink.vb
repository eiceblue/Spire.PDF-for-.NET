Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Texts

Namespace SearchTextAndAddHyperlink
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the path to the input PDF file
            Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified input file
            doc.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfTextFinder object and specify the search options
            Dim finder As New PdfTextFinder(page)
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase

            ' Find all occurrences of the text "e-iceblue" on the page
            Dim finds As List(Of PdfTextFragment) = finder.Find("e-iceblue")

            ' Specify the URL for the hyperlink
            Dim url As String = "http://www.e-iceblue.com"

            ' Iterate over each found text fragment
            For Each find As PdfTextFragment In finds
                ' Create a PdfUriAnnotation object with the bounds of the found text
                Dim uri As New PdfUriAnnotation(find.Bounds(0))
                uri.Uri = url
                uri.Border = New PdfAnnotationBorder(1.0F)
                uri.Color = Color.Blue

                ' Add the annotation to the page's annotation widget collection
                page.Annotations.Add(uri)
            Next find

            ' Specify the output file name
            Dim result As String = "SearchTextAndAddHyperlink_out.pdf"

            ' Save the modified document to the specified output file
            doc.SaveToFile(result)

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
