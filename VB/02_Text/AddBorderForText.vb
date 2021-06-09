Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace AddBorderForText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			Dim text As String = "Hello, World!"

			Dim font As New PdfTrueTypeFont(New Font("Times New Roman", 11, FontStyle.Regular),True)
			Dim size As SizeF = font.MeasureString(text)
			Dim brush As New PdfSolidBrush(Color.Black)
			Dim x As Integer = 60
			Dim y As Integer = 300

			'Draw the text on page
			page.Canvas.DrawString(text, font, New PdfSolidBrush(Color.Black), x, y)

			'Draw border for text          
			page.Canvas.DrawRectangle(New PdfPen(brush, 0.5f),New Rectangle(x, y, CInt(size.Width), CInt(size.Height)))

			Dim result As String = "AddBorderForText-result.pdf"
			'save to file
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
