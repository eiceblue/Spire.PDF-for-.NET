Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Texts

Namespace LaunchFileInNewWindow
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a New PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load a PDF file from a specified path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\DocumentsLinks.pdf")

            ' Specify an array of strings to search for in the document
            Dim test() As String = {"Spire.PDF"}

            ' Iterate over each page in the document
            For Each page As PdfPageBase In pdf.Pages
                ' Iterate over each element in the "test" array
                For i As Integer = 0 To test.Length - 1
                    ' Create a PdfTextFinder object to find occurrences of the current element in the current page
                    Dim finder As New PdfTextFinder(page)
                    finder.Options.Parameter = TextFindParameter.WholeWord

                    ' Find all instances of the current element
                    Dim finds As List(Of PdfTextFragment) = finder.Find(test(i))

                    ' Iterate over each found text fragment
                    For Each find As PdfTextFragment In finds
                        ' Create a PdfLaunchAction to open a file in a new window
                        Dim launchAction As New PdfLaunchAction("..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative)
                        launchAction.IsNewWindow = True

                        ' Get the bounding rectangle of the found text fragment
                        Dim rect As RectangleF = find.Bounds(0)

                        ' Create a PdfActionAnnotation with the launch action and the bounding rectangle
                        Dim annotation As New PdfActionAnnotation(rect, launchAction)

                        ' Add the annotation to the page's annotation collection
                        TryCast(page, PdfPageWidget).Annotations.Add(annotation)
                    Next find
                Next i
            Next page

            ' Specify the output file name as "LaunchFileInNewWindow.pdf"
            Dim result As String = "LaunchFileInNewWindow.pdf"

            ' Save the modified document to a PDF file
            pdf.SaveToFile(result)

            ' Close the PDF document
            pdf.Close()

            ' Launch the file
            DocumentViewer(result)
        End Sub
        Private Sub DocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
