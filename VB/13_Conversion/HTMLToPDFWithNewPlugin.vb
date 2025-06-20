Imports Spire.Pdf.Graphics
Imports Spire.Additions.Qt

Namespace HTMLToPDFWithNewPlugin
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Note: You need to download the Plugin from our website: https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Convert-HTML-to-PDF-with-New-Plugin.html

            ' Set the path of the Plugin
            HtmlConverter.PluginPath = "..\..\..\..\..\..\Data\plugins"

            ' Convert URL to PDF
            ConvertURLToPDF()

            ' Convert HTML string to PDF
            ConvertHtmlStringToPDF()
        End Sub

        Private Sub ConvertURLToPDF()
            ' Enable JavaScript
            ' Set load timeout
            ' Set page size
            ' Set page margins
            HtmlConverter.Convert("https://www.e-iceblue.com/", "HTMLtoPDF.pdf", True, 100 * 1000, New SizeF(612, 792), New PdfMargins(0, 0))
        End Sub

        Private Sub ConvertHtmlStringToPDF()
            Dim input As String = "<strong>This is a test for converting HTML string to PDF </strong>" & ControlChars.CrLf & "<ul><li>Spire.PDF supports to convert HTML in URL into PDF</li>" & ControlChars.CrLf & "<li>Spire.PDF supports to convert HTML string into PDF</li>" & ControlChars.CrLf & "<li>With the new plugin</li></ul>"
            Dim outputFile As String = "ToPDF.pdf"

            ' Enable JavaScript
            ' Set load timeout
            ' Set page size
            ' Set page margins
            ' Load from content type
            HtmlConverter.Convert(input, outputFile, True, 10 * 1000, New SizeF(612, 792), New PdfMargins(0), LoadHtmlType.SourceCode)
        End Sub
    End Class
End Namespace
