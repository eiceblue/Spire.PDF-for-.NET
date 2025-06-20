Imports Spire.Pdf
Imports Spire.Pdf.Texts

Namespace FindAndHighlightText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim pdf As New PdfDocument()

            ' Load the PDF file from the specified path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\FindAndHighlightText.pdf")

            ' Iterate through each page in the document
            For Each page As PdfPageBase In pdf.Pages

                ' Create a new instance of PdfTextFinder for the current page
                Dim finder As New PdfTextFinder(page)

                ' Set the search parameter to match whole word occurrences
                finder.Options.Parameter = TextFindParameter.WholeWord

                ' Find all occurrences of "science" in the current page
                Dim finds As List(Of PdfTextFragment) = finder.Find("science")

                ' Highlight each found occurrence
                For Each find As PdfTextFragment In finds
                    find.HighLight()
                Next find
            Next page

            ' Specify the output file path
            Dim output As String = "FindAndHighlightText_out.pdf"

            ' Save the file
            pdf.SaveToFile(output, FileFormat.PDF)

            ' Close the document
            pdf.Close()

            ' Launch the result file
            PDFDocumentViewer(output)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
