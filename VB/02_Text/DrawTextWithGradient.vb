Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace DrawTextWithGradient
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Add a new page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Create a rectangle
			Dim rect As New Rectangle(New Point(0, 0), New Size(300, 100))

			'Create a brush with gradient
			Dim brush As New PdfLinearGradientBrush(rect, Color.Red, Color.Blue, PdfLinearGradientMode.Horizontal)

			'Create a true type font with size 20f, underline style
			Dim font As New PdfTrueTypeFont(New Font("Arial", 20, FontStyle.Underline))

			'Draw text
			page.Canvas.DrawString("Welcome to E-iceblue!", font, brush, New Point(0, 100))

			Dim result As String="DrawWithGradient-result.pdf"
			'Save to file
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
