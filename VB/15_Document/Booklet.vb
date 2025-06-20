Imports Spire.Pdf

Namespace Booklet
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of the PdfDocument class.
			Dim doc As New PdfDocument()

			' Specify the file path of the source PDF file.
			Dim srcPdf As String = "..\..\..\..\..\..\Data\Booklet.pdf"

			' Set the width of the booklet page to be twice the width of A4 page.
			Dim width As Single = PdfPageSize.A4.Width * 2

			' Set the height of the booklet page to be the same as the height of A4 page.
			Dim height As Single = PdfPageSize.A4.Height

			' Create a booklet from the source PDF file with the specified width and height.
			doc.CreateBooklet(srcPdf, width, height, True)

			' Save the resulting booklet as a new PDF file.
			doc.SaveToFile("Booklet-result.pdf")

			' Close the document.
			doc.Close()

			' Launch the Pdf file.
			PDFDocumentViewer("Booklet-result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
