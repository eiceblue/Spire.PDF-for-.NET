Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace DeleteImageSecondApproach
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load the document from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\DeleteImage.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Delete the first image on the page
			page.DeleteImage(0)

			'Save the document
			doc.SaveToFile("Output.pdf")

			'Launch the Pdf file
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
