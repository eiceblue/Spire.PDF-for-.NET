Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace ReplaceImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\ReplaceImage.pdf")

			'Get the first page.
			Dim page As PdfPageBase = doc.Pages(0)

			'Load a image
			Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")

			'Replace the first image on the page.
			page.ReplaceImage(0, image)

			Dim result As String = "Output.pdf"

			'Save the document
			doc.SaveToFile(result)

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
