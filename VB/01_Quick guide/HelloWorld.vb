Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace HelloWorld
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Draw the text
			page.Canvas.DrawString("Hello, World!", New PdfFont(PdfFontFamily.Helvetica, 30f), New PdfSolidBrush(Color.Black), 10, 10)

			'Save pdf file.
			doc.SaveToFile("HelloWorld.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("HelloWorld.pdf")

		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
