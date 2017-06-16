Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Overlay
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'load two document
			Dim doc1 As New PdfDocument()
			doc1.LoadFromFile("..\..\..\..\..\..\Data\Sample1.pdf")

			Dim doc2 As New PdfDocument()
			doc2.LoadFromFile("..\..\..\..\..\..\Data\Sample3.pdf")

			'Create page template
			Dim template As PdfTemplate = doc1.Pages(0).CreateTemplate()

			For Each page As PdfPageBase In doc2.Pages
				page.Canvas.SetTransparency(0.25f, 0.25f, PdfBlendMode.Overlay)
				page.Canvas.DrawTemplate(template, PointF.Empty)
			Next page

			'Save pdf file.
			doc2.SaveToFile("Overlay.pdf")
			doc1.Close()
			doc2.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("Overlay.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
