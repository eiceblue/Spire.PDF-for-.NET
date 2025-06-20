Imports Spire.Pdf
Imports Spire.Pdf.Texts

Namespace FindTextInDefineArea
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path.
            Dim input As String = "..\..\..\..\..\..\Data\SampleB_1.pdf"

            ' Specify the output file path.
            Dim output As String = "FindTextInDefinePlace.pdf"

            ' Create a new instance of PdfDocument.
            Dim doc As New PdfDocument()

            ' Load the PDF file from the specified input path.
            doc.LoadFromFile(input)

            ' Define a rectangle representing the search area with parameters: X, Y, Width, and Height.
            Dim rctg As New RectangleF(0, 0, 300, 300)

            ' Get the first page of the document.
            Dim pdfPageBase As PdfPageBase = doc.Pages(0)

            ' Create a new instance of PdfTextFinder for the page.
            Dim finder As New PdfTextFinder(pdfPageBase)

            ' Set the search parameter to match whole word occurrences.
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord

            ' Set the search area to the defined rectangle.
            finder.Options.Area = rctg

            ' Find all occurrences of "Spire" within the defined search area.
            Dim finds As List(Of PdfTextFragment) = finder.Find("Spire")

            ' Find all occurrences of "PDF" within the defined search area.
            Dim findouts As List(Of PdfTextFragment) = finder.Find("PDF")

            ' Highlight each found occurrence of "Spire" with green color.
            For Each find As PdfTextFragment In finds
                find.HighLight(Color.Green)
            Next find

            ' Highlight each found occurrence of "PDF" with yellow color.
            For Each findOut As PdfTextFragment In findouts
                findOut.HighLight(Color.Yellow)
            Next findOut

            ' Save the modified document with highlights to the output file in PDF format.
            doc.SaveToFile(output, FileFormat.PDF)

            ' Close the document.
            doc.Close()

            ' Launch the result file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
