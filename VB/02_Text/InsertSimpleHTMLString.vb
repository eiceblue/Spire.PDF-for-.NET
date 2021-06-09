Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace InsertSimpleHTMLString
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Add a new page
			Dim page As PdfNewPage = TryCast(doc.Pages.Add(), PdfNewPage)

			'HTML string
			Dim htmlText As String = "This demo shows how we can insert <u><i>HTML styled text</i></u> to PDF using " & "<font color='#FF4500'>Spire.PDF for .NET</font>. "

			'Render HTML text
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 25)
			Dim brush As PdfBrush = PdfBrushes.Black
			Dim richTextElement As New PdfHTMLTextElement(htmlText, font, brush)
			richTextElement.TextAlign = TextAlign.Left

			'Format Layout
			Dim format As New PdfMetafileLayoutFormat()
			format.Layout = PdfLayoutType.Paginate
			format.Break = PdfLayoutBreakType.FitPage

			'Draw htmlString  
			richTextElement.Draw(page, New RectangleF(0, 20, page.GetClientSize().Width, page.GetClientSize().Height), format)


			Dim result As String = "InsertSimpleHTMLString-result.pdf"
			doc.SaveToFile(result)

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
