Imports System.ComponentModel
Imports System.Text
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
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\AddTextStamp.pdf"

			'Open a pdf document
			Dim document As New PdfDocument()
		document.LoadFromFile(input)
			'Get the first page
			Dim page As PdfPageBase = document.Pages(0)

			'Create a pdf template
			Dim template As New PdfTemplate(125, 55)
			Dim font1 As New PdfTrueTypeFont(New Font("Elephant", 10f, FontStyle.Italic), True)
			Dim brush As New PdfSolidBrush(Color.DarkRed)
			Dim pen As New PdfPen(brush)
			Dim rectangle As New RectangleF(New PointF(5, 5), template.Size)
			Dim CornerRadius As Integer = 20
			Dim path As New PdfPath()
			path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90)
			path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90)
			path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
			path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
			path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius \ 2)
			template.Graphics.DrawPath(pen, path)

			'Draw stamp text
			Dim s1 As String = "REVISED" & vbLf
			Dim s2 As String = "by E-iceblue at " & Date.Now.ToString("MM dd, yyyy")
			template.Graphics.DrawString(s1, font1, brush, New PointF(5, 10))
			Dim font2 As New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 9f, FontStyle.Bold), True)
			template.Graphics.DrawString(s2, font2, brush, New PointF(2, 30))

			'Create a rubber stamp
			Dim stamp As New PdfRubberStampAnnotation(rectangle)
			Dim apprearance As New PdfAppearance(stamp)
			apprearance.Normal = template
			stamp.Appearance = apprearance

			'Draw stamp into page
			page.AnnotationsWidget.Add(stamp)

			Dim output As String = "AddTextStamp.pdf"

			'Save pdf document
			document.SaveToFile(output)

			'Launch the file
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
