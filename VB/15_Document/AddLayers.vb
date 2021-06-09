Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics.Layer
Imports Spire.Pdf.Graphics

Namespace AddLayers
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\AddLayers.pdf")

			Dim page As PdfPageBase = doc.Pages(0)

			'create a layer named "red line"
			Dim layer As PdfLayer = doc.Layers.AddLayer("red line",PdfVisibility.On)
			Dim pcA As PdfCanvas = layer.CreateGraphics(page.Canvas)
			pcA.DrawLine(New PdfPen(PdfBrushes.Red, 2), New PointF(100, 350), New PointF(300, 350))

			'create a layer named "blue line"
			layer = doc.Layers.AddLayer("blue line")
			Dim pcB As PdfCanvas = layer.CreateGraphics(doc.Pages(0).Canvas)
			pcB.DrawLine(New PdfPen(PdfBrushes.Blue, 2), New PointF(100, 400), New PointF(300, 400))

			'create a layer named "green line"
			layer = doc.Layers.AddLayer("green line")
			Dim pcC As PdfCanvas = layer.CreateGraphics(doc.Pages(0).Canvas)
			pcC.DrawLine(New PdfPen(PdfBrushes.Green, 2), New PointF(100, 450), New PointF(300, 450))

			Dim output As String = "AddLayers.pdf"

			'save the pdf document
			doc.SaveToFile(output)

			'view the document
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
