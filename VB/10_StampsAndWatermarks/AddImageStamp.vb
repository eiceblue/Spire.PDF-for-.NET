Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Annotations.Appearance

Namespace AddImageStamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\AddImageStamp.pdf"
			Dim document As New PdfDocument()
		document.LoadFromFile(input)
			'Get the first page
			Dim page As PdfPageBase = document.Pages(0)

			'Create a rubber stamp annotation
			Dim loStamp As New PdfRubberStampAnnotation(New RectangleF(New PointF(0, 0), New SizeF(60, 60)))

			'Create an instance of PdfAppearance 
			Dim loApprearance As New PdfAppearance(loStamp)
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\image stamp.jpg")
			Dim template As New PdfTemplate(210, 210)

			'Draw a pdf image into pdf template
			template.Graphics.DrawImage(image, 60, 60)
			loApprearance.Normal = template
			loStamp.Appearance = loApprearance

			'Add the rubber stamp annotation into pdf
			page.AnnotationsWidget.Add(loStamp)

			Dim output As String = "AddImageStamp.pdf"

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
