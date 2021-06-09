Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace Booklet
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			Dim srcPdf As String = "..\..\..\..\..\..\Data\Booklet.pdf"
			Dim width As Single = PdfPageSize.A4.Width * 2
			Dim height As Single = PdfPageSize.A4.Height
			doc.CreateBooklet(srcPdf, width, height, True)

			'Save pdf file
			doc.SaveToFile("Booklet-result.pdf")
			doc.Close()

			'Launch the Pdf file
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
