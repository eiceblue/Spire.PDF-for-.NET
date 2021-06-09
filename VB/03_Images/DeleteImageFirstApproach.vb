Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DeleteImageFirstApproach
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file
			Dim file As String = "..\..\..\..\..\..\Data\DeleteImage.pdf"

			'Open pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(file)

			'Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			'Delete the first image on the page
			page.DeleteImage(page.ImagesInfo(0).Image)

			Dim result As String = "DeleteImage_out.pdf"

			'Save the document
			pdf.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub

	End Class
End Namespace
