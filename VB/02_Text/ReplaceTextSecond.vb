Imports System
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Texts

Namespace ReplaceTextSecond
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Input file path
            Dim input As String = @"..\..\..\..\..\..\Data\ReplaceTextInPage.pdf"

            ' Create a new PdfDocument
            Dim doc As PdfDocument = New PdfDocument()

            ' Load the pdf file from disk
            doc.LoadFromFile(input)

            ' Get the first page of the pdf file
            Dim page As PdfPageBase = doc.Pages[0]

            ' Create a PdfTextReplacer using the first page
            Dim replacer As PdfTextReplacer = New PdfTextReplacer(page)

            ' Replace all occurrences of "Spire.PDF" with "E-iceblue" in this page
            replacer.ReplaceAllText("Spire.PDF", "E-iceblue")

            ' Replace the first occurrence of "Adobe Acrobat" with "PDF editors"
            replacer.ReplaceText("Adobe Acrobat", "PDF editors")
            ' replacer.ReplaceText("Adobe Acrobat", "PDF editors", Color.Red);

            ' Output file path
            Dim result As String = "ReplaceTextInPage_out.pdf"

            ' Save the modified document to the output file path
            doc.SaveToFile(result)

            'Launch the Pdf file
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
