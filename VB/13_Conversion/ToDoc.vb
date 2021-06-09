Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace ToDoc
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim file As String = "..\..\..\..\..\..\Data\ToDoc.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Convert to doc file.
			doc.SaveToFile("ToDoc.doc", FileFormat.DOC)
			doc.Close()

			'Launch the file.
			Process.Start("ToDoc.doc")
		End Sub
	End Class
End Namespace
