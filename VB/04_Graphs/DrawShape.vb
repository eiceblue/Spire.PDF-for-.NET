Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawShape
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			' Call the DrawPath method to draw a custom path on the page
			DrawPath(page)

			' Call the DrawSpiro method to draw a Spiro shape on the page
			DrawSpiro(page)

			' Call the DrawRectangle method to draw a rectangle on the page
			DrawRectangle(page)

			' Call the DrawPie method to draw a pie shape on the page
			DrawPie(page)

			' Call the DrawEllipse method to draw an ellipse on the page
			DrawEllipse(page)

			' Save the document to a file named "DrawShape.pdf"
			doc.SaveToFile("DrawShape.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("DrawShape.pdf")
		End Sub

		Private Sub DrawPath(ByVal page As PdfPageBase)
			' Define an array to store points for creating a custom path
			Dim points(4) As PointF

			' Generate the points on a circle with radius 1 using cosine and sine functions
			For i As Integer = 0 To points.Length - 1
				Dim x As Single = CSng(Math.Cos(i * 2 * Math.PI / 5))
				Dim y As Single = CSng(Math.Sin(i * 2 * Math.PI / 5))
				points(i) = New PointF(x, y)
			Next i

			' Create a new PdfPath object
			Dim path As New PdfPath()

			' Add lines to the path connecting the points
			path.AddLine(points(2), points(0))
			path.AddLine(points(0), points(3))
			path.AddLine(points(3), points(1))
			path.AddLine(points(1), points(4))
			path.AddLine(points(4), points(2))

			' Save the current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a pen with color DeepSkyBlue and thickness 0.02 points
			Dim pen As New PdfPen(Color.DeepSkyBlue, 0.02F)

			' Create a brush with color CadetBlue
			Dim brush1 As PdfBrush = New PdfSolidBrush(Color.CadetBlue)

			' Scale and translate the coordinate system for drawing the path
			page.Canvas.ScaleTransform(50.0F, 50.0F)
			page.Canvas.TranslateTransform(5.0F, 1.2F)

			' Draw the path outline using the specified pen
			page.Canvas.DrawPath(pen, path)

			' Translate the coordinate system for the next operation
			page.Canvas.TranslateTransform(2.0F, 0F)

			' Set the fill mode of the path to alternate
			path.FillMode = PdfFillMode.Alternate

			' Draw the path with the specified pen and brush using the alternate fill mode
			page.Canvas.DrawPath(pen, brush1, path)

			' Translate the coordinate system for the next operation
			page.Canvas.TranslateTransform(2.0F, 0F)

			' Set the fill mode of the path to winding
			path.FillMode = PdfFillMode.Winding

			' Draw the path with the specified pen and brush using the winding fill mode
			page.Canvas.DrawPath(pen, brush1, path)

			' Create a linear gradient brush with colors Red and Blue
			Dim brush2 As New PdfLinearGradientBrush(New PointF(-2, 0), New PointF(2, 0), Color.Red, Color.Blue)

			' Translate the coordinate system for the next operation
			page.Canvas.TranslateTransform(-4.0F, 2.0F)

			' Set the fill mode of the path to alternate
			path.FillMode = PdfFillMode.Alternate

			' Draw the path with the specified pen and gradient brush using the alternate fill mode
			page.Canvas.DrawPath(pen, brush2, path)

			' Create a radial gradient brush with colors Red and Blue
			Dim brush3 As New PdfRadialGradientBrush(New PointF(0F, 0F), 0F, New PointF(0F, 0F), 1.0F, Color.Red, Color.Blue)

			' Translate the coordinate system for the next operation
			page.Canvas.TranslateTransform(2.0F, 0F)

			' Set the fill mode of the path to winding
			path.FillMode = PdfFillMode.Winding

			' Draw the path with the specified pen and radial gradient brush using the winding fill mode
			page.Canvas.DrawPath(pen, brush3, path)

			' Create a tiling brush with a 4x4 rectangle pattern
			Dim brush4 As New PdfTilingBrush(New RectangleF(0, 0, 4.0F, 4.0F))

			' Draw a rectangle using Graphics.DrawRectangle method with brush2 as the brush, starting at (0, 0) and with dimensions of 4f x 4f
			brush4.Graphics.DrawRectangle(brush2, 0, 0, 4.0F, 4.0F)

			' Translate the canvas
			page.Canvas.TranslateTransform(2.0F, 0F)

			' Set the fill mode of the path
			path.FillMode = PdfFillMode.Winding

			' Draw a path on the canvas
			page.Canvas.DrawPath(pen, brush4, path)

			' Restore the graphics state
			page.Canvas.Restore(state)
		End Sub

		Private Sub DrawSpiro(ByVal page As PdfPageBase)
			' Save current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Define a pen with DeepSkyBlue color
			Dim pen As PdfPen = PdfPens.DeepSkyBlue

			' Define variables for the number of points, radii, and distance
			Dim nPoints As Integer = 1000
			Dim r1 As Double = 30
			Dim r2 As Double = 25
			Dim p As Double = 35

			' Initialize coordinates for drawing lines
			Dim x1 As Double = r1 + r2 - p
			Dim y1 As Double = 0
			Dim x2 As Double = 0
			Dim y2 As Double = 0

			' Translate the canvas origin to (100, 100)
			page.Canvas.TranslateTransform(100, 100)

			' Draw a series of lines based on mathematical calculations
			For i As Integer = 0 To nPoints - 1
				Dim t As Double = i * Math.PI / 90
				x2 = (r1 + r2) * Math.Cos(t) - p * Math.Cos((r1 + r2) * t / r2)
				y2 = (r1 + r2) * Math.Sin(t) - p * Math.Sin((r1 + r2) * t / r2)
				page.Canvas.DrawLine(pen, CSng(x1), CSng(y1), CSng(x2), CSng(y2))
				x1 = x2
				y1 = y2
			Next i

			' Restore the previous graphics state
			page.Canvas.Restore(state)
		End Sub

		Private Sub DrawRectangle(ByVal page As PdfPageBase)
			' Save current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a pen with Chocolate color and thickness of 1
			Dim pen As New PdfPen(Color.Chocolate, 1.0F)

			' Draw a rectangle with the specified position and size
			page.Canvas.DrawRectangle(pen, New Rectangle(New Point(20, 310), New Size(150, 120)))

			' Restore the previous graphics state
			page.Canvas.Restore(state)
		End Sub
		Private Sub DrawPie(ByVal page As PdfPageBase)
			' Save current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a pen with DarkRed color and thickness of 2
			Dim pen As New PdfPen(Color.DarkRed, 2.0F)

			' Draw a pie shape on the canvas using the specified pen and parameters
			page.Canvas.DrawPie(pen, 220, 320, 100, 90, 360, 360)

			' Restore the previous graphics state
			page.Canvas.Restore(state)
		End Sub
		Private Sub DrawEllipse(ByVal page As PdfPageBase)
			' Save current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a brush with CadetBlue color
			Dim brush As PdfBrush = New PdfSolidBrush(Color.CadetBlue)

			' Draw an ellipse on the canvas using the specified brush and parameters
			page.Canvas.DrawEllipse(brush, 380, 325, 80, 80)

			' Restore the previous graphics state
			page.Canvas.Restore(state)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
