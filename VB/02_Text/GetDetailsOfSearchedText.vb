Imports System.IO
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Texts

Namespace GetDetailsOfSearchedText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the path of the input PDF file
            Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"

            ' Create a new PdfDocument instance
            Dim doc As New PdfDocument()

            ' Load the PDF file into the document
            doc.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfTextFinder instance to find text on the page
            Dim finder As New PdfTextFinder(page)

            ' Set the find options to ignore case
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase

            ' Find the specified text on the page
            Dim finds As List(Of PdfTextFragment) = finder.Find("Spire.PDF for .NET")

            ' Create a StringBuilder instance to store the details of the searched text
            Dim builder As New StringBuilder()

            ' Iterate through each found text fragment
            For Each find As PdfTextFragment In finds
                ' Add a separator line to the StringBuilder
                builder.AppendLine("==================================================================================")
                ' Add the matched text to the StringBuilder
                builder.AppendLine("Match Text: " & find.Text)
                ' Add the size of the text fragment to the StringBuilder
                builder.AppendLine("Size: " & find.Sizes(0).ToString())
                ' Add the position of the text fragment to the StringBuilder
                builder.AppendLine("Position: " & find.Positions(0).ToString())
                ' Add the line that contains the searched text to the StringBuilder
                builder.AppendLine("The line that contains the searched text: " & find.LineText)
            Next find

            ' Specify the output file name
            Dim result As String = "GetDetailsOfSearchedText_out.txt"

            ' Write the content of the StringBuilder to a text file
            File.WriteAllText(result, builder.ToString())

            ' Close the document
            doc.Close()

            'Launch the result file
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
