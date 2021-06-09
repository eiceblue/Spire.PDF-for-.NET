Imports Spire.Pdf
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Namespace ToHTMLStream
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim pdf As New PdfDocument()
			'Load file from disk
            pdf.LoadFromFile("..\..\..\..\..\..\..\Data\SampleB_1.pdf")

			Dim ms As New MemoryStream()
			'Save to HTML stream
			pdf.SaveToStream(ms, FileFormat.HTML)
		End Sub
	End Class
End Namespace
