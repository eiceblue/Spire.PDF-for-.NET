Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace PageNumberInFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf")

			'Set the margin
			Dim margin As PdfMargins = doc.PageSettings.Margins

			'Draw Page number
			DrawPageNumber(doc, margin, 1, doc.Pages.Count)

			Dim result As String="PageNumberStamp_out.pdf"
			'Save the document
			doc.SaveToFile(result)
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub DrawPageNumber(ByVal doc As PdfDocument, ByVal margin As PdfMargins, ByVal startNumber As Integer, ByVal pageCount As Integer)
			For Each page As PdfPageBase In doc.Pages
				page.Canvas.SetTransparency(0.5f)
				Dim brush As PdfBrush = PdfBrushes.Black
				Dim pen As New PdfPen(brush, 0.75f)
				Dim font As New PdfTrueTypeFont(New Font("Arial", 12f, FontStyle.Italic), True)
				Dim format As New PdfStringFormat(PdfTextAlignment.Right)
				format.MeasureTrailingSpaces = True
				Dim space As Single = font.Height * 0.75f
				Dim x As Single = margin.Left
				Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
				Dim y As Single = page.Canvas.ClientSize.Height - margin.Bottom + space
				page.Canvas.DrawLine(pen, x, y, x + width, y)
				y = y + 1
				Dim numberLabel As String = String.Format("{0} of {1}", startNumber, pageCount)
				startNumber += 1
				page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format)
				page.Canvas.SetTransparency(1)
			Next page
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
