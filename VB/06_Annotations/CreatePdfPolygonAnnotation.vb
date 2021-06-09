Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace CreatePdfPolygonAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a Pdf document.
			Dim pdf As New PdfDocument()

			'Add a new page to it.
			Dim page As PdfPageBase = pdf.Pages.Add()

			'Initialize an instance of PdfPolygonAnnotation, specifying all vertex coordinates which can form a complete shape.
			Dim polygon As New PdfPolygonAnnotation(page, New PointF() { New PointF(0, 30), New PointF(30, 15), New PointF(60, 30), New PointF(45, 50), New PointF(15, 50), New PointF(0, 30)})

			'Set the border color, text, border effect and other properties of polygon annotation.
			polygon.Color = Color.PaleVioletRed
			polygon.Text = "This is a polygon annotation"
			polygon.Author = "E-ICEBLUE"
			polygon.Subject = "polygon annotation demo"
			polygon.BorderEffect = PdfBorderEffect.BigCloud
			polygon.ModifiedDate = Date.Now

			'Add the annotation to Pdf page and save the document.
			page.AnnotationsWidget.Add(polygon)

			Dim result As String = "CreatePdfPolygonAnnotation_out.pdf"

			'Save the document
			pdf.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
