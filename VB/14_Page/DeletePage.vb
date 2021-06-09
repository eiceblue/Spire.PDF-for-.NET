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
			'Load the document from disk
			Dim input As String = "..\..\..\..\..\..\Data\DeletePage.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Delete the fifth page
			doc.Pages.RemoveAt(4)

			Dim output As String = "DeletePage.pdf"

			'Save the document
			doc.SaveToFile(output)
			doc.Close()

			'Launch the Pdf file
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
