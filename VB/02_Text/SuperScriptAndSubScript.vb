Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.AutomaticFields

Namespace SuperScriptAndSubScript
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()
			'Add a page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Set font and brush
			Dim font As New PdfTrueTypeFont(New Font("Arial", 20f))
			Dim brush As New PdfSolidBrush(Color.Black)

			Dim text As String = "Spire.PDF for .NET"

			'Draw Superscript
			DrawSuperscript(page, text, font, brush)

			'Draw Subscript
			DrawSubscript(page, text, font, brush)

			Dim result As String="SuperScriptAndSubScriptInPDF_out.pdf"
			'Save the document
			doc.SaveToFile(result)
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub DrawSuperscript(ByVal page As PdfPageBase, ByVal text As String, ByVal font As PdfTrueTypeFont, ByVal brush As PdfSolidBrush)
			Dim x As Single = 120f
			Dim y As Single = 100f
			page.Canvas.DrawString(text, font, brush, New PointF(x, y))

			'Measure the string
			Dim size As SizeF = font.MeasureString(text)

			'Set the x coordinate of the superscript text
			x += size.Width

			'Instantiate a PdfStringFormat instance
			Dim format As New PdfStringFormat()

			'Set format as superscript
			format.SubSuperScript = PdfSubSuperScript.SuperScript

			'Draw superscript text with format
			text = "Superscript"
			page.Canvas.DrawString(text, font, brush, New PointF(x, y), format)
		End Sub

		Private Sub DrawSubscript(ByVal page As PdfPageBase, ByVal text As String, ByVal font As PdfTrueTypeFont, ByVal brush As PdfSolidBrush)
			Dim x As Single = 120f
			Dim y As Single = 150f
			page.Canvas.DrawString(text, font, brush, New PointF(x, y))

			'Measure the string
			Dim size As SizeF = font.MeasureString(text)

			'Set the x coordinate of the superscript text
			x += size.Width

			'Instantiate a PdfStringFormat instance
			Dim format As New PdfStringFormat()

			'Set format as superscript
			format.SubSuperScript = PdfSubSuperScript.SubScript

			'Draw superscript text with format
			text = "SubScript"
			page.Canvas.DrawString(text, font, brush, New PointF(x, y), format)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
