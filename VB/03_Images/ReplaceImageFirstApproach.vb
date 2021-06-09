Imports Spire.Pdf
Imports Spire.Pdf.Exporting
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

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

			'Get images of the first page.
			Dim imageInfo() As PdfImageInfo = page.ImagesInfo

			'Replace the first image on the page.
            page.ReplaceImage(imageInfo(0).Image, PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png"))

			Dim result As String = "ReplaceImage_out.pdf"

			'Save the document
			doc.SaveToFile(result)
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
