Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddImageInFooter
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim path As String = "..\..\..\..\..\..\Data\"
			'pdf file 
			Dim input As String = path & "Sample4.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'create a pdf image
			Dim footerImage As PdfImage = PdfImage.FromFile(path & "logo2.png")

			Dim x As Single=0
			Dim y As Single=0

			'draw footer image into pages
			For Each page As PdfPageBase In doc.Pages
				x = page.Canvas.ClientSize.Width - footerImage.PhysicalDimension.Width - 10
				y = page.Canvas.ClientSize.Height - footerImage.PhysicalDimension.Height - 10
				page.Canvas.DrawImage(footerImage, New PointF(x, y))
			Next page

			Dim output As String = "AddImageInFooter.pdf"
			'Save pdf file.
			doc.SaveToFile(output)
			doc.Close()

			'Launching the Pdf file.
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
