Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace Overlay
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc1 As New PdfDocument()

			' Load the PDF document from the specified file path
			doc1.LoadFromFile("..\..\..\..\..\..\Data\Overlay1.pdf")

			' Create a new PdfDocument object
			Dim doc2 As New PdfDocument()

			' Load the PDF document from the specified file path
			doc2.LoadFromFile("..\..\..\..\..\..\Data\Overlay2.pdf")

			' Create a PdfTemplate from the first page of doc1
			Dim template As PdfTemplate = doc1.Pages(0).CreateTemplate()

			' Iterate through each page in doc2
			For Each page As PdfPageBase In doc2.Pages
				' Set the transparency of the page's canvas using overlay mode
				page.Canvas.SetTransparency(0.25F, 0.25F, PdfBlendMode.Overlay)

				' Draw the template on the page's canvas at the top-left corner
				page.Canvas.DrawTemplate(template, PointF.Empty)
			Next page

			' Save the modified doc2 as Overlay.pdf
			doc2.SaveToFile("Overlay.pdf")

			' Close the documents
			doc1.Close()
			doc2.Close()

			' Launch the Pdf file
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
