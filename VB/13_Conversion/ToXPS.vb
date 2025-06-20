Imports Spire.Pdf

Namespace ToXPS
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF file to be loaded
			Dim file As String = "..\..\..\..\..\..\Data\ToXPS.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(file)

			' Convert the PDF document to XPS file format
			doc.SaveToFile("ToXPS-result.xps", FileFormat.XPS)

			' Close the PDF document
			doc.Close()

			' Launch the xps file
			Process.Start("ToXPS-result.xps")
		End Sub
	End Class
End Namespace
