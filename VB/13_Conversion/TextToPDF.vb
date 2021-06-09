Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace TextToPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Get text from .txt file
			Dim text As String = File.ReadAllText("..\..\..\..\..\..\Data\TextToPdf.txt")

			'Create a pdf document
			Dim doc As New PdfDocument()

			Dim section As PdfSection = doc.Sections.Add()
			Dim page As PdfPageBase = section.Pages.Add()

			'Create a PdfFont
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 11)

			'Set string format
			Dim format As New PdfStringFormat()
			format.LineSpacing = 20f

			Dim brush As PdfBrush = PdfBrushes.Black

			'Set text layout
			Dim textLayout As New PdfTextLayout()
			textLayout.Break = PdfLayoutBreakType.FitPage
			textLayout.Layout = PdfLayoutType.Paginate

			Dim bounds As New RectangleF(New PointF(10, 20), page.Canvas.ClientSize)

			Dim textWidget As New PdfTextWidget(text, font, brush)
			textWidget.StringFormat = format
			textWidget.Draw(page, bounds, textLayout)

			Dim output As String ="TextToPdf.pdf"

			'Save to file
			doc.SaveToFile(output, FileFormat.PDF)

			'Launch the result file
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
