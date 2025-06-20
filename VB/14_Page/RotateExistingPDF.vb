Imports Spire.Pdf

Namespace RotateExistingPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim doc As New PdfDocument()

			' Load an existing PDF from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			' Get the first page of the loaded PDF file
			Dim page As PdfPageBase = doc.Pages(0)

			' Get the original rotation angle of the page
			Dim rotation As Integer = CInt(Fix(page.Rotation))

			' Set the rotation angle to rotate the page
			rotation += CInt(Fix(PdfPageRotateAngle.RotateAngle270))

			' Rotate the PDF page based on the new angle
			page.Rotation = CType(rotation, PdfPageRotateAngle)

			' Specify the output file name
			Dim result As String = "RotateExistingPDF_out.pdf"

			' Save the modified document to the output file
			doc.SaveToFile(result)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
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
