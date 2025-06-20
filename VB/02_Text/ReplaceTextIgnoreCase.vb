Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports Spire.Pdf.Texts.PdfTextReplaceOptions

Namespace ReplaceTextIgnoreCase
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Load the PDF file
            Dim doc As New PdfDocument()
            doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceTextIgnoreCase.pdf")

            ' Get the first page of the PDF file
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfTextReplacer for the first page
            Dim replacer As New PdfTextReplacer(page)

            ' Set the replace options to ignore case
            Dim [option] As New PdfTextReplaceOptions()
            [option].ReplaceType = ReplaceActionType.IgnoreCase
            replacer.Options = [option]

            ' Replace only the first occurrence of "text" with "This is a test" in this page
            replacer.ReplaceText("text", "This is a test")

            ' Replace all occurrences of "pdf" with "Spire.Pdf for Net" in this page
            replacer.ReplaceAllText("pdf", "Spire.Pdf for Net")

            ' Save the modified document to a file
            doc.SaveToFile("output.pdf", FileFormat.PDF)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer("output.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
