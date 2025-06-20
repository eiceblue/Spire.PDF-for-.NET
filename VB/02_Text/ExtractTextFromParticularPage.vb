Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports System.IO
Namespace ExtractTextFromParticularPage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"

            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load the PDF file
            doc.LoadFromFile(input)

            ' Get the first page
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create PdfTextExtractOptions and set it to extract all text
            Dim options As PdfTextExtractOptions = New PdfTextExtractOptions
            options.IsExtractAllText = True

            ' Create a PdfTextExtractor instance for the page
            Dim pdfTextExtractor As PdfTextExtractor = New PdfTextExtractor(page)

            ' Extract the text from the page using the specified options
            Dim text As String = pdfTextExtractor.ExtractText(options)

            ' Specify the output file path
            Dim result As String = Path.GetFullPath("ExtractTextFromParticularPage_out.txt")

            ' Create a TextWriter instance for the output file
            Dim tw As TextWriter = New StreamWriter(result)

            ' Write the extracted text to the output file
            tw.WriteLine(text)

            ' Close the TextWriter
            tw.Close()

            ' Close the document
            doc.Close()

            MessageBox.Show(vbLf & "Text extracted successfully from particular pages of PDF Document." & vbLf & "File saved at " & result)
        End Sub
    End Class
End Namespace
