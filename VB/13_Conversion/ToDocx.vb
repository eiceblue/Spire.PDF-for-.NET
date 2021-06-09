Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace ToDocx
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim file As String = "..\..\..\..\..\..\Data\ToDocx.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Convert to docx file.
			doc.SaveToFile("ToDocx.docx", FileFormat.DOCX)
			doc.Close()

			'Launch the file.
			Process.Start("ToDocx.docx")
		End Sub
	End Class
End Namespace
