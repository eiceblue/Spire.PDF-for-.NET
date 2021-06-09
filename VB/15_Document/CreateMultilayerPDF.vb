Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.General.Find
Namespace CreateMultilayerPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()

			' Creates a page
			Dim page As PdfPageBase = doc.Pages.Add()

			'Create text
			Dim text As String = "Welcome to evaluate Spire.PDF for .NET !"

			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			Dim brush As New PdfSolidBrush(Color.Black)

			' Defines a font
			Dim font As New PdfTrueTypeFont(New Font("Calibri", 15f, FontStyle.Regular))

			Dim x As Single = 50
			Dim y As Single = 50

			' Draw text layer
			page.Canvas.DrawString(text, font, brush, New PointF(x, y), format)

			Dim size As SizeF = font.MeasureString("Welcome to  evaluate", format)

			Dim size2 As SizeF = font.MeasureString("Spire.PDF for .NET", format)

			' Loads an image 
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\MultilayerImage.png")

			' Draw image layer
			page.Canvas.DrawImage(image, New PointF(x + size.Width, y),size2)

			Dim result As String = "CreateMultilayerPDF_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
