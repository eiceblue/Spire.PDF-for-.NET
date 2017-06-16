Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddImageInHeader
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
			Dim headerImage As PdfImage = PdfImage.FromFile(path & "E-iceblue logo.png")

			'draw header image into pages
			For Each page As PdfPageBase In doc.Pages
				page.Canvas.DrawImage(headerImage, New PointF(10, 2))
			Next page

			Dim output As String = "AddImageInHeader.pdf"
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
