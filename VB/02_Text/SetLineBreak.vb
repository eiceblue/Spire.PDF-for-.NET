Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SetLineBreak
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a new page to the document with A4 size and margins of 40
            Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(40))

            ' Create a brush using the color black
            Dim brush As New PdfSolidBrush(Color.Black)

            ' Define the text that will be drawn on the page
            Dim text As String = "Spire.PDF for .NET" & vbLf & "A professional PDF library applied to" & " creating, writing, editing, handling and reading PDF files" & " without any external dependencies within .NET" & "( C#, VB.NET, ASP.NET, .NET Core) application."

            ' Append additional text to the existing text
            text &= vbLf & vbCr & "Spire.PDF for Java" & vbLf & "A PDF Java API that enables developers to read, " & "write, convert and print PDF documents" & "in Java applications without using Adobe Acrobat."
            text &= vbLf & vbCr
            text &= "Welcome to evaluate Spire.PDF!"

            ' Define a rectangle where the text will be drawn
            Dim rect As New RectangleF(50, 50, page.Size.Width - 150, page.Size.Height)

            ' Draw the text on the page using the specified font, brush, and rectangle
            page.Canvas.DrawString(text, New PdfFont(PdfFontFamily.Helvetica, 13.0F), brush, rect)

            ' Specify the file name for the resulting PDF document
            Dim result As String = "SetLineBreak_out.pdf"

            ' Save the document to the specified file
            doc.SaveToFile(result)

            ' Launch the Pdf file
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
