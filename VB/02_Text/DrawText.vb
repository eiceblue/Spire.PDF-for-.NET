Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Add a page
			Dim page As PdfPageBase = doc.Pages.Add()

			' Call the DrawText function to draw text on the page
			DrawText(page)

			' Call the AlignText function to align the text on the page
			AlignText(page)

			' Call the AlignTextInRectangle function to align the text within a rectangle on the page
			AlignTextInRectangle(page)

			' Call the TransformText function to transform the text on the page
			TransformText(page)

			' Call the RotateText function to rotate the text on the page
			RotateText(page)

			' Save the document to a file named "DrawText.pdf"
			doc.SaveToFile("DrawText.pdf")

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer("DrawText.pdf")

		End Sub

		Private Sub AlignText(ByVal page As PdfPageBase)
			' Create a font object with Helvetica font family and font size 20
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 20.0F)

			' Create a solid brush with blue color
			Dim brush As New PdfSolidBrush(Color.Blue)

			' Create a string format for left alignment
			Dim leftAlignment As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)

			' Draw the text on the canvas using the specified font, brush, and left alignment
			page.Canvas.DrawString("Left!", font, brush, 0, 20, leftAlignment)
			page.Canvas.DrawString("Left!", font, brush, 0, 50, leftAlignment)

			' Create a string format for right alignment
			Dim rightAlignment As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

			' Draw the text on the canvas using the specified font, brush, and right alignment
			page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 20, rightAlignment)
			page.Canvas.DrawString("Right!", font, brush, page.Canvas.ClientSize.Width, 50, rightAlignment)

			' Create a string format for center alignment
			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)

			' Draw the text on the canvas using the specified font, brush, and center alignment
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, page.Canvas.ClientSize.Width / 2, 40, centerAlignment)

		End Sub

		Private Sub AlignTextInRectangle(ByVal page As PdfPageBase)
			' Create a font object with Helvetica font family and font size 10
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 10.0F)

			' Create a solid brush with blue color
			Dim brush As New PdfSolidBrush(Color.Blue)

			' Create a rectangle
			Dim rctg1 As New RectangleF(0, 70, page.Canvas.ClientSize.Width / 2, 100)

			' Create a rectangle
			Dim rctg2 As New RectangleF(page.Canvas.ClientSize.Width / 2, 70, page.Canvas.ClientSize.Width / 2, 100)

			' Draw a rectangle on the canvas using a light blue brush
			page.Canvas.DrawRectangle(New PdfSolidBrush(Color.LightBlue), rctg1)

			' Draw a rectangle on the canvas using a light sky blue brush
			page.Canvas.DrawRectangle(New PdfSolidBrush(Color.LightSkyBlue), rctg2)

			' Create a string format for left alignment at the top of the rectangle
			Dim leftAlignment As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top)

			' Draw the text inside the first rectangle using the specified font, brush, and left alignment
			page.Canvas.DrawString("Left! Left!", font, brush, rctg1, leftAlignment)

			' Draw the text inside the second rectangle using the specified font, brush, and left alignment
			page.Canvas.DrawString("Left! Left!", font, brush, rctg2, leftAlignment)

			' Create a string format for right alignment at the middle of the rectangle
			Dim rightAlignment As New PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle)

			' Draw the text inside the first rectangle using the specified font, brush, and right alignment
			page.Canvas.DrawString("Right! Right!", font, brush, rctg1, rightAlignment)

			' Draw the text inside the second rectangle using the specified font, brush, and right alignment
			page.Canvas.DrawString("Right! Right!", font, brush, rctg2, rightAlignment)

			' Create a string format for center alignment at the bottom of the rectangle
			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Bottom)

			' Draw the text inside the first rectangle using the specified font, brush, and center alignment
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg1, centerAlignment)

			' Draw the text inside the second rectangle using the specified font, brush, and center alignment
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, rctg2, centerAlignment)
		End Sub

		Private Sub RotateText(ByVal page As PdfPageBase)
			' Save the current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a new font using the Helvetica font family with a size of 10
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 10.0F)

			' Create a solid brush with blue color
			Dim brush As New PdfSolidBrush(Color.Blue)

			' Create a string format object for left alignment and middle vertical alignment
			Dim centerAlignment As New PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)

			' Calculate the x-coordinate for horizontal positioning
			Dim x As Single = page.Canvas.ClientSize.Width / 2

			' Set the y-coordinate for vertical positioning
			Dim y As Single = 380

			' Translate the coordinate system to the specified x and y coordinates
			page.Canvas.TranslateTransform(x, y)

			' Loop 12 times to draw the text with rotation
			For i As Integer = 0 To 11
				' Rotate the canvas by 30 degrees
				page.Canvas.RotateTransform(30)

				' Draw the text at position (20, 0) using the font, brush, and alignment
				page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush, 20, 0, centerAlignment)
			Next i

			' Restore the graphics state
			page.Canvas.Restore(state)
		End Sub

		Private Sub TransformText(ByVal page As PdfPageBase)
			' Save the current graphics state of the page's canvas
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Create a new font using the Helvetica font family with size 18
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 18.0F)

			' Create solid brushes with specified colors (DeepSkyBlue and CadetBlue)
			Dim brush1 As New PdfSolidBrush(Color.DeepSkyBlue)
			Dim brush2 As New PdfSolidBrush(Color.CadetBlue)

			' Translate the coordinate system by moving it 20 units to the right and 200 units down
			page.Canvas.TranslateTransform(20, 200)

			' Scale the coordinate system horizontally by 1 and vertically by 0.6
			page.Canvas.ScaleTransform(1.0F, 0.6F)

			' Skew the coordinate system by -10 degrees horizontally
			page.Canvas.SkewTransform(-10, 0)

			' Draw the specified text at coordinates (0, 0) using the specified font and brush1
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush1, 0, 0)

			' Undo the previous skew transformation by skewing the coordinate system by 10 degrees horizontally
			page.Canvas.SkewTransform(10, 0)

			' Draw the same text as before, but now using brush2
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, 0)

			' Scale the coordinate system vertically by -1 (to flip it vertically)
			page.Canvas.ScaleTransform(1.0F, -1.0F)

			' Draw the same text as before, but now using brush2 and offsetting it vertically by -2 times the font size
			page.Canvas.DrawString("Go! Turn Around! Go! Go! Go!", font, brush2, 0, -2 * 18)

			' Restore the graphics state to the previously saved state, undoing all transformations and other modifications
			page.Canvas.Restore(state)
		End Sub

		Private Sub DrawText(ByVal page As PdfPageBase)
			' Save the current graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Define the text to be drawn
			Dim text As String = "Go! Turn Around! Go! Go! Go!"

			' Define the pen for drawing the outline of the text
			Dim pen As PdfPen = PdfPens.DeepSkyBlue

			' Define the brush for filling the text
			Dim brush As New PdfSolidBrush(Color.White)

			' Define the format for the text string
			Dim format As New PdfStringFormat()

			' Define the font for the text
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 18.0F, PdfFontStyle.Italic)

			' Measure the size of the text string using the specified font and format
			Dim size As SizeF = font.MeasureString(text, format)

			' Define the rectangle for positioning and sizing the text
			Dim rctg As New RectangleF(page.Canvas.ClientSize.Width / 2 + 10, 180, size.Width / 3 * 2, size.Height * 2)

			' Draw the text within the specified rectangle using the font, pen, brush, and format
			page.Canvas.DrawString(text, font, pen, brush, rctg, format)

			' Restore the graphics state
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
