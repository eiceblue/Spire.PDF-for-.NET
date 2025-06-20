Imports Spire.Pdf

Namespace ToHTML
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF document to be loaded
			Dim file As String = "..\..\..\..\..\..\Data\ToHTML.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(file)

			' Convert the PDF document to an HTML file format
			doc.SaveToFile("ToHTML.html", FileFormat.HTML)

			' Close the PDF document
			doc.Close()

			' Launch the html file
			Process.Start("ToHTML.html")
		End Sub
	End Class
End Namespace
