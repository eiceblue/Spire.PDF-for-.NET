Imports Spire.Pdf

Namespace ToHTML
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\ToHTML.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(file)

			'Convert to html file
			doc.SaveToFile("ToHTML.html", FileFormat.HTML)
			doc.Close()

			'Launching the html file
			Process.Start("ToHTML.html")
		End Sub
	End Class
End Namespace
