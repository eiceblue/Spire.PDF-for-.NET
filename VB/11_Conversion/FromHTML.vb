Imports System.Reflection
Imports Spire.Pdf

Namespace FromHTML
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document.
			Dim doc As New PdfDocument()

            Dim url As String = "http://www.e-iceblue.com/"
			doc.LoadFromHTML(url, False, True, True)

			'Save pdf file.
			doc.SaveToFile("FromHTML.pdf")
			doc.Close()

			'Launching the Pdf file.
			PDFDocumentViewer("FromHTML.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
