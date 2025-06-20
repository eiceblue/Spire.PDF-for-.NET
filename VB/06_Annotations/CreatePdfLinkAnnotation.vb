Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics

Namespace CreatePdfLinkAnnotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document
            Dim doc As New PdfDocument()

            ' Add a new page to the document
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define the rectangle for the link annotation
            Dim rect As New RectangleF(0, 40, 250, 35)

            ' Specify the file path of the linked PDF file
            Dim filePath As String = "..\..\..\..\..\..\Data\Template_Pdf_3.pdf"

            ' Create a new file link annotation with the specified rectangle and file path
            Dim link As New PdfFileLinkAnnotation(rect, filePath)

            ' Add the file link annotation to the page
            page.Annotations.Add(link)

            ' Create a new free text annotation with the specified rectangle
            Dim text As New PdfFreeTextAnnotation(rect)

            ' Set the text content for the free text annotation
            text.Text = "Click here! This is a link annotation."

            ' Set the font for the free text annotation
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 15)
            text.Font = font

            ' Add the free text annotation to the page
            page.AnnotationsWidget.Add(text)

            ' Save the document to a file
            Dim result As String = "CreatePdfLinkAnnotation_out.pdf"
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
