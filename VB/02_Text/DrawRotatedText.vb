Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawRotatedText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles label1.Click, button1.Click, pictureBox1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a page to the document
			Dim page As PdfPageBase = doc.Pages.Add()

			' Create a TrueType font with Arial font family and font size 12
			Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F), True)

			' Create a solid brush with blue color
			Dim brush As New PdfSolidBrush(Color.Blue)

			' Set the text to be drawn
			Dim text As String = "This is a text"

			' Draw the text on the canvas of the page at position (20, 30) using the specified font and brush
			page.Canvas.DrawString(text, font, brush, 20, 30)

			' Draw the text on the canvas of the page at position (20, 150) using the specified font and brush
			page.Canvas.DrawString(text, font, brush, 20, 150)

			' Save the state of the canvas
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a PointF object for rotation point (20, 30)
			Dim point1 As New PointF(20, 30)

			' Rotate the canvas 90 degrees clockwise around the rotation point
			page.Canvas.RotateTransform(90, point1)

			' Draw the rotated text on the canvas using the specified font and brush
			page.Canvas.DrawString(text, font, brush, point1)

			' Restore the canvas state to the saved state
			page.Canvas.Restore(state)

			' To draw a new text with different rotation, initialize a new state by saving the current state
			Dim state2 As PdfGraphicsState = page.Canvas.Save()

			' Create a PointF object for rotation point (20, 150)
			Dim point2 As New PointF(20, 150)

			' Rotate the canvas 90 degrees counterclockwise around the rotation point
			page.Canvas.RotateTransform(-90, point2)

			' Draw the rotated text on the canvas using the specified font and brush
			page.Canvas.DrawString(text, font, brush, point2)

			' Restore the canvas state to the saved state
			page.Canvas.Restore(state2)

			' Specify the output file name for the PDF document
			Dim output As String = "DrawText.pdf"

			' Save the document
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' View the document
			FileViewer(output)
		End Sub

		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub
	End Class
End Namespace
