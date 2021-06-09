Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace RearrangePageOrder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_3.pdf")

			'Rearrange the page order
			doc.Pages.ReArrange(New Integer() { 1, 0})

			Dim result As String="RearrangePageOrder-result.pdf"
			'Save to file
			doc.SaveToFile(result, FileFormat.PDF)

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
