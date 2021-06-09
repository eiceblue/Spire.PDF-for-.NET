Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Tables

Namespace FillStrokeText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document and load file from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Define Pdf pen
			Dim pen As New PdfPen(Color.Gray)

			'Save graphics state
			Dim state As PdfGraphicsState = page.Canvas.Save()

			'Rotate page canvas
			page.Canvas.RotateTransform(-20)

			Dim format As New PdfStringFormat()
			format.CharacterSpacing = 5f

			'Draw the string on page
			page.Canvas.DrawString("E-ICEBLUE", New PdfFont(PdfFontFamily.Helvetica, 45f), pen, 0, 500f,format)

			'Restore graphics
			page.Canvas.Restore(state)

			'Save the Pdf file
			Dim output As String = "FillStrokeText_out.pdf"
			doc.SaveToFile(output)
			doc.Close()

			'Launch the Pdf file
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
