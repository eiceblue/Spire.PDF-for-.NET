Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawFilledRectangles
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim pdf As New PdfDocument()

			' Load a PDF file from the specified path
			pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawingTemplate.pdf")

			' Get the first page of the PDF document
			Dim page As PdfPageBase = pdf.Pages(0)

			' Save the current graphics state of the page
			Dim state As PdfGraphicsState = page.Canvas.Save()

			' Define the coordinates and dimensions for the rectangle
			Dim x As Integer = 200
			Dim y As Integer = 300
			Dim width As Integer = 200
			Dim height As Integer = 120

			' Create a PDF pen with black color and thickness of 1
			Dim pen As New PdfPen(Color.Black, 1.0F)

			' Create a PDF brush with orange-red color
			Dim brush As PdfBrush = New PdfSolidBrush(Color.OrangeRed)

			' Draw a rectangle on the page using the specified pen and brush, with the defined dimensions
			page.Canvas.DrawRectangle(pen, brush, New Rectangle(New Point(x, y), New Size(width, height)))

			' Restore the previous graphics state of the page
			page.Canvas.Restore(state)

			' Specify the file name for the resulting PDF
			Dim result As String = "DrawFilledRectangles_out.pdf"

			' Save the modified PDF document to the specified file
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			' Launch the Pdf file
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
