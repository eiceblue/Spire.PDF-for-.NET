Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace InsertSimpleHTMLString
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument
            Dim doc As New PdfDocument()

            ' Add a new page to the document
            Dim page As PdfNewPage = TryCast(doc.Pages.Add(), PdfNewPage)

            ' Specify the HTML string to be inserted
            Dim htmlText As String = "This demo shows how we can insert <u><i>HTML styled text</i></u> to PDF using " & "<font color='#FF4500'>Spire.PDF for .NET</font>. "

            ' Create a PdfFont using the Helvetica font and size 25
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 25)

            ' Create a PdfBrush to set the text color
            Dim brush As PdfBrush = PdfBrushes.Black

            ' Create a PdfHTMLTextElement instance to load and render the HTML text
            Dim richTextElement As New PdfHTMLTextElement(htmlText, font, brush)
            richTextElement.TextAlign = TextAlign.Left

            ' Define the layout format for the HTML text
            Dim format As New PdfMetafileLayoutFormat()
            format.Layout = PdfLayoutType.Paginate
            format.Break = PdfLayoutBreakType.FitPage

            ' Draw the HTML text on the page within the specified rectangle and format
            richTextElement.Draw(page, New RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format)

            ' Save the document to a file
            Dim result As String = "InsertSimpleHTMLString-result.pdf"
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try

        End Sub
    End Class
End Namespace
