Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace AddDifferentHeaders
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load the Pdf from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf")

			Dim header1 As String = "Header 1"
			Dim header2 As String = "Header 2"

			'Define style
			Dim font As New PdfTrueTypeFont(New Font("Arial", 15f, FontStyle.Bold))
			Dim brush As PdfBrush=PdfBrushes.Red
			Dim rect As New RectangleF(New PointF(0,20),New SizeF(doc.PageSettings.Size.Width,50f))
			Dim format As New PdfStringFormat()
			format.Alignment= PdfTextAlignment.Center
			doc.Pages(0).Canvas.DrawString(header1,font,brush,rect,format)

			font = New PdfTrueTypeFont(New Font("Aleo", 15f, FontStyle.Regular))
			brush = PdfBrushes.Black
			format.Alignment = PdfTextAlignment.Left
			doc.Pages(1).Canvas.DrawString(header2, font, brush, rect, format)

			'Save the document
			Dim output As String = "AddingDifferentHeaders_result.pdf"
			doc.SaveToFile(output, FileFormat.PDF)

			'Launch the Pdf
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
