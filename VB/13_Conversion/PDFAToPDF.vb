Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace PDFAToPDF
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input PDF/A file path
            Dim input As String = "..\..\..\..\..\..\Data\SamplePDFA.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load file from the path
            doc.LoadFromFile(input)

            ' Create a new PDF document and draw content on a new file
            Dim newDoc As New PdfNewDocument()
            newDoc.CompressionLevel = PdfCompressionLevel.None

            ' Iterate through each page of the original document
            For Each page As PdfPageBase In doc.Pages
                Dim size As SizeF = page.Size
                Dim p As PdfPageBase = newDoc.Pages.Add(size, New PdfMargins(0))
                page.CreateTemplate().Draw(p, 0, 0)
            Next page

            ' Specify the output file name for the resulting PDF
            Dim output As String = "PDFAToPdf-result.pdf"

            ' Save the new document as a PDF file
            newDoc.Save(output)

            ' Close the document
            newDoc.Close()
            doc.Close()

            ' Launch the Pdf file
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
