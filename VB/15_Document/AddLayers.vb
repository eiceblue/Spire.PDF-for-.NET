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
			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified path
			doc.LoadFromFile("..\..\..\..\..\..\Data\AddLayers.pdf")

			' Access the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Add a new layer to the document with name "red line" and visibility set to On
			Dim layer As PdfLayer = doc.Layers.AddLayer("red line", PdfVisibility.On)

			' Create a graphics context for the layer using the canvas of the page
			Dim pcA As PdfCanvas = layer.CreateGraphics(page.Canvas)

			' Draw a red line on the layer using the graphics context
			pcA.DrawLine(New PdfPen(PdfBrushes.Red, 2), New PointF(100, 350), New PointF(300, 350))

			' Add another layer to the document with name "blue line"
			layer = doc.Layers.AddLayer("blue line")

			' Create a graphics context for the new layer using the canvas of the page
			Dim pcB As PdfCanvas = layer.CreateGraphics(doc.Pages(0).Canvas)

			' Draw a blue line on the new layer using the graphics context
			pcB.DrawLine(New PdfPen(PdfBrushes.Blue, 2), New PointF(100, 400), New PointF(300, 400))

			' Add yet another layer to the document with name "green line"
			layer = doc.Layers.AddLayer("green line")

			' Create a graphics context for the new layer using the canvas of the page
			Dim pcC As PdfCanvas = layer.CreateGraphics(doc.Pages(0).Canvas)

			' Draw a green line on the new layer using the graphics context
			pcC.DrawLine(New PdfPen(PdfBrushes.Green, 2), New PointF(100, 450), New PointF(300, 450))

			' Specify the output file path for the modified document
			Dim output As String = "AddLayers.pdf"

			' Save the modified document to the specified file path
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' View the document
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
