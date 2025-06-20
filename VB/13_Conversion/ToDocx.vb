Imports Spire.Pdf

Namespace ToDocx
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF document to be loaded
			Dim file As String = "..\..\..\..\..\..\Data\ToDocx.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(file)

			' Convert the PDF document to a DOCX file format
			doc.SaveToFile("ToDocx.docx", FileFormat.DOCX)

			' Close the PDF document
			doc.Close()

			' Launch the file
			Process.Start("ToDocx.docx")
		End Sub
	End Class
End Namespace
