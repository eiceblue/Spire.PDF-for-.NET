Imports Spire.Pdf

Namespace ToXPS
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\ToXPS.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Convert to xps file.
			doc.SaveToFile("ToXPS-result.xps", FileFormat.XPS)
			doc.Close()

			'Launch the xps file.
			Process.Start("ToXPS-result.xps")
		End Sub
	End Class
End Namespace
