Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Annotations.Appearance
Namespace AddTextStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\AddTextStamp.pdf"

			' Create a new PdfDocument object
			Dim document As New PdfDocument()

			' Load an existing PDF file from the specified input file path
			document.LoadFromFile(input)

			' Access the first page of the document
			Dim page As PdfPageBase = document.Pages(0)

			' Create a new PdfTemplate object with a specific width and height
			Dim template As New PdfTemplate(125, 55)

			' Create a new PdfTrueTypeFont object with Elephant font, size 10, and italic style
			Dim font1 As New PdfTrueTypeFont(New Font("Elephant", 10.0F, FontStyle.Italic), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font1 As New PdfTrueTypeFont("Elephant", 10.0F, FontStyle.Italic, True)
			' =============================================================================

			' Create a new PdfSolidBrush object with dark red color
			Dim brush As New PdfSolidBrush(Color.DarkRed)

			' Create a new PdfPen object with the defined brush
			Dim pen As New PdfPen(brush)

			' Define the rectangle for drawing the stamp
			Dim rectangle As New RectangleF(New PointF(5, 5), template.Size)

			' Define the corner radius for the stamp rectangle
			Dim CornerRadius As Integer = 20

			' Create a new PdfPath object to define the shape of the stamp
			Dim path As New PdfPath()
			path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90)
			path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90)
			path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
			path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
			path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius \ 2)

			' Draw the defined path onto the template using the pen
			template.Graphics.DrawPath(pen, path)

			' Define the first line of text for the stamp
			Dim s1 As String = "REVISED" & vbLf

			' Define the second line of text for the stamp
			Dim s2 As String = "by E-iceblue at " & Date.Now.ToString("MM dd, yyyy")

			' Draw the first line of text onto the template using font1 and brush
			template.Graphics.DrawString(s1, font1, brush, New PointF(5, 10))

			' Create a new PdfTrueTypeFont object with Lucida Sans Unicode font, size 9, and bold style
			Dim font2 As New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 9.0F, FontStyle.Bold), True)
			' =============================================================================
			' Use the following code for netstandard dlls
			' =============================================================================
			'Dim font2 As New PdfTrueTypeFont("Lucida Sans Unicode", 9.0F, FontStyle.Bold, True)
			' =============================================================================
			' Draw the second line of text onto the template using font2 and brush
			template.Graphics.DrawString(s2, font2, brush, New PointF(2, 30))

			' Create a new PdfRubberStampAnnotation object with the defined rectangle
			Dim stamp As New PdfRubberStampAnnotation(rectangle)

			' Create a new PdfAppearance object for the stamp annotation
			Dim appearance As New PdfAppearance(stamp)

			' Set the appearance of the stamp to use the created template
			appearance.Normal = template

			' Assign the appearance to the stamp annotation
			stamp.Appearance = appearance

			' Add the stamp annotation to the page
            page.Annotations.Add(stamp)

			' Specify the output file name
			Dim output As String = "AddTextStamp.pdf"

			' Save the modified document to a file
			document.SaveToFile(output)

			' Close the document
			document.Close()

			' Launch the file
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
