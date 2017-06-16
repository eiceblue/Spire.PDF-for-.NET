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
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\Sample5.pdf"

			'open a pdf document
			Dim document As New PdfDocument(input)

			'get the first page
			Dim page As PdfPageBase = document.Pages(0)

			'create a rubber stamp annotation
			Dim loStamp As New PdfRubberStampAnnotation(New RectangleF(New PointF(0, 0), New SizeF(60, 60)))

			'create an instance of PdfAppearance 
			Dim loApprearance As New PdfAppearance(loStamp)

            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\..\Data\image stamp.jpg")

			Dim template As New PdfTemplate(160, 160)

			'draw a pdf image into pdf template
			template.Graphics.DrawImage(image, 0, 0)

			loApprearance.Normal = template
			loStamp.Appearance = loApprearance

			'add the rubber stamp annotation into pdf
			page.AnnotationsWidget.Add(loStamp)

			Dim output As String = "AddImageStamp.pdf"

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
