Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace DeleteLayer
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load the document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\DeleteLayer.pdf")

			'Delete the "red line" layer
			doc.Layers.RemoveLayer("red line")

			'Save the document
			doc.SaveToFile("Output.pdf")

			'View the Pdf file
			PDFDocumentViewer("Output.pdf")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
