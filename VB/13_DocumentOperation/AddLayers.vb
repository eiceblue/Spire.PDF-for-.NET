Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace AddLayers
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'create a pdf document
			Dim doc As New PdfDocument()

			'add a new page
			Dim page As PdfPageBase = doc.Pages.Add()

			'create a layer named "red line"
			Dim layer As PdfPageLayer = page.PageLayers.Add("red line")
			layer.Graphics.DrawLine(New PdfPen(PdfBrushes.Red, 1), New PointF(0, 100), New PointF(100, 100))

			'create a layer named "blue line"
			layer = page.PageLayers.Add("blue line")
			layer.Graphics.DrawLine(New PdfPen(PdfBrushes.Blue, 1), New PointF(0, 150), New PointF(100, 150))

			'create a layer named "green line"
			layer = page.PageLayers.Add("green line")
			layer.Graphics.DrawLine(New PdfPen(PdfBrushes.Green, 1), New PointF(0, 200), New PointF(100, 200))

			Dim output As String = "AddLayers.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
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
