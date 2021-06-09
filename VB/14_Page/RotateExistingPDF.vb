Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace RotateExistingPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load an existing pdf from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			'Get the first page of the loaded PDF file
			Dim page As PdfPageBase = doc.Pages(0)

			'Get the original rotation angle
			Dim rotation As Integer = CInt(Fix(page.Rotation))

			'Set the angle
			rotation += CInt(Fix(PdfPageRotateAngle.RotateAngle270))

			'Rotate the PDF page based on
			page.Rotation = CType(rotation, PdfPageRotateAngle)

			Dim result As String = "RotateExistingPDF_out.pdf"

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
