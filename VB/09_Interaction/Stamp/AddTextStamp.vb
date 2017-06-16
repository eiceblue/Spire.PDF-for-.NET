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
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\Sample5.pdf"

			'open a pdf document
			Dim document As New PdfDocument(input)

			'get the first page
			Dim page As PdfPageBase = document.Pages(0)

			'create a pdf template
			Dim template As New PdfTemplate(200, 50)
			Dim font1 As New PdfTrueTypeFont(New Font("Elephant", 16f, FontStyle.Italic), True)
			Dim brush As New PdfSolidBrush(Color.DarkRed)
			Dim pen As New PdfPen(brush)
			Dim rectangle As New RectangleF(New PointF(0, 0), template.Size)
			Dim CornerRadius As Integer = 20
			Dim path As New PdfPath()
			path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90)
			path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90)
			path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
			path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
			path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius \ 2)
			template.Graphics.DrawPath(pen, path)

			'draw stamp text
			Dim s1 As String = "REVISED" & vbLf
			Dim s2 As String = "By Jack at " & Date.Now.ToString("HH:mm, MM dd, yyyy")
			template.Graphics.DrawString(s1, font1, brush, New PointF(5, 5))
			Dim font2 As New PdfTrueTypeFont(New Font("Gadugi", 12f, FontStyle.Bold), True)
			template.Graphics.DrawString(s2, font2, brush, New PointF(2, 28))

			'create a rubber stamp
			Dim stamp As New PdfRubberStampAnnotation(rectangle)
			Dim apprearance As New PdfAppearance(stamp)
			apprearance.Normal = template
			stamp.Appearance = apprearance

			'draw stamp into page
			page.AnnotationsWidget.Add(stamp)

			Dim output As String = "AddTextStamp.pdf"

			'save pdf document
			document.SaveToFile(output)

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
