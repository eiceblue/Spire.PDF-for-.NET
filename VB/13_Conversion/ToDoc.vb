Imports Spire.Pdf

Namespace ToDoc
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF document to be loaded
			Dim file As String = "..\..\..\..\..\..\Data\ToDoc.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(file)

			' Convert the PDF document to a DOC file format
			doc.SaveToFile("ToDoc.doc", FileFormat.DOC)

			' Close the PDF document
			doc.Close()

			' Launch the file
			Process.Start("ToDoc.doc")
		End Sub
	End Class
End Namespace
