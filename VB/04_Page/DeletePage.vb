Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Namespace DeletePage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\Sample3.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'delete the fifth page
			doc.Pages.RemoveAt(4)

			Dim output As String = "DeletePage.pdf"

			'save pdf document
			doc.SaveToFile(output)
			doc.Close()
			'Launch the Pdf file.
			PDFDocumentViewer(output)

		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
