Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Text
Imports System.Threading.Tasks

Namespace RotateNewPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Create PdfUnitConvertor to convert the unit
			Dim unitCvtr As New PdfUnitConvertor()

			'Setting for page margin
			Dim margin As New PdfMargins()
			margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Bottom = margin.Top
			margin.Left = unitCvtr.ConvertUnits(2.0f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point)
			margin.Right = margin.Left

			'Create PdfSection
			Dim section As PdfSection = doc.Sections.Add()

			'Set "A4" for Pdf page
			section.PageSettings.Size = PdfPageSize.A4

			'Set page margin
			section.PageSettings.Margins = margin

			'Set rotating angle
			section.PageSettings.Rotate = PdfPageRotateAngle.RotateAngle90

			'Add the page
			Dim page As PdfPageBase = section.Pages.Add()

			'Define a PdfBrush
			Dim brush As PdfBrush = PdfBrushes.Black

			'Define a font
			Dim font As New PdfTrueTypeFont(New Font("Arial", 13f, FontStyle.Bold), True)

			'Set the string format 
			Dim format As New PdfStringFormat(PdfTextAlignment.Left)

			'Set the position for drawing 
			Dim x As Single = 0
			Dim y As Single = 50

			'Text string 
			Dim specification As String = "The sample demonstrates how to rotate page when creating a PDF document."

			'Draw text string on page canvas
			page.Canvas.DrawString(specification, font, brush, x, y, format)

			Dim result As String = "RotateNewPDF_out.pdf"

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
