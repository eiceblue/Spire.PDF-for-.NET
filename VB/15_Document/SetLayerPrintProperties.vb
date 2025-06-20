Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Graphics.Layer

Namespace SetLayerPrintProperties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a New PdfDocument object
			Dim pdf As New PdfDocument()

			' Load an existing PDF file from the specified path
			pdf.LoadFromFile("..\..\..\..\..\..\Data\AddLayers.pdf")

			' Get the first page of the loaded PDF document
			Dim page As PdfPageBase = pdf.Pages(0)

			' Add a new layer to the PDF document with the name "red line" and set its visibility to On
			Dim layer As PdfLayer = pdf.Layers.AddLayer("red line", PdfVisibility.On)

			' Set the print state of the layer to Nerver, so it won't be printed
			layer.PrintState = LayerPrintState.Nerver

			' Create a PdfCanvas object for drawing on the layer's graphics using the page's canvas as the base
			Dim pcA As PdfCanvas = layer.CreateGraphics(page.Canvas)

			' Draw a red line with a thickness of 2 units, starting at point (100, 350) and ending at point (300, 350)
			pcA.DrawLine(New PdfPen(PdfBrushes.Red, 2), New PointF(100, 350), New PointF(300, 350))

			' Specify the path where the modified PDF document should be saved
			Dim result As String = "SetLayerPrintProperties_result.pdf"

			' Save the modified PDF document to the specified path
			pdf.SaveToFile(result)

			' Close the PDF document
			pdf.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
