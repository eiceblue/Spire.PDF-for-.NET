Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports System.IO

Namespace ExtractTextFromSpecificArea
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\ExtractTextFromSpecificArea.pdf"

            ' Create a new instance of PdfDocument
            Dim pdf As New PdfDocument()

            ' Load the PDF file from the specified input path
            pdf.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Create PdfTextExtractOptions and set the extraction area using a rectangle
            Dim options As PdfTextExtractOptions = New PdfTextExtractOptions
            options.ExtractArea = New RectangleF(80, 180, 500, 200)

            ' Create a PdfTextExtractor instance for the page
            Dim pdfTextExtractor As PdfTextExtractor = New PdfTextExtractor(page)

            ' Extract the text from the specified area using the options
            Dim text As String = pdfTextExtractor.ExtractText(options)

            ' Create a StringBuilder instance
            Dim sb As New StringBuilder()

            ' Append the extracted text to the string builder
            sb.AppendLine(text)

            ' Specify the output file path
            Dim result As String = "ExtractText_result.txt"

            ' Write the contents of the string builder to the output file
            File.WriteAllText(result, sb.ToString())

            ' Close the document
            pdf.Close()

            ' Launch the txt file
            Viewer(result)
        End Sub
        Private Sub Viewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
