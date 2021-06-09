Imports Spire.Pdf.Graphics
Imports Spire.Pdf.HtmlConverter
Imports Spire.Pdf.HtmlConverter.Qt
Imports System.ComponentModel
Imports System.Text

Namespace HTMLToPDFWithNewPlugin
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Note you need to download Plugin from our website: https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Convert-HTML-to-PDF-with-New-Plugin.html

			ConvertURLToPDF()
			ConvertHtmlStringToPDF()

		End Sub

		Private Sub ConvertURLToPDF()
			'enable javascript
			'load timeout
			'page size
			'page margins
			Spire.Pdf.HtmlConverter.Qt.HtmlConverter.Convert("https://www.e-iceblue.com/", "HTMLtoPDF.pdf", True, 100 * 1000, New SizeF(612, 792), New PdfMargins(0, 0))
		End Sub

		Private Sub ConvertHtmlStringToPDF()
			Dim input As String = "<strong>This is a test for converting HTML string to PDF </strong>" & ControlChars.CrLf & "                 <ul><li>Spire.PDF supports to convert HTML in URL into PDF</li>" & ControlChars.CrLf & "                 <li>Spire.PDF supports to convert HTML string into PDF</li>" & ControlChars.CrLf & "                 <li>With the new plugin</li></ul>"

			Dim outputFile As String = "ToPDF.pdf"

			'enable javascript
			'load timeout
			'page size
			'page margins
			'load from content type
			Spire.Pdf.HtmlConverter.Qt.HtmlConverter.Convert(input, outputFile, True, 10 * 1000, New SizeF(612, 792), New Spire.Pdf.Graphics.PdfMargins(0), LoadHtmlType.SourceCode)
		End Sub
	End Class
End Namespace
