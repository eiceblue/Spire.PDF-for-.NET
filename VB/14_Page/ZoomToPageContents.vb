Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ZoomToPageContents
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load Pdf document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			'Create a newDoc
			Dim newDoc As New PdfDocument()

			For Each page As PdfPageBase In doc.Pages
				'Add new page with 'A3' size
				Dim newPage As PdfPageBase = newDoc.Pages.Add(PdfPageSize.A3, New PdfMargins(0,0))

				'Zoom content to the new page
				newPage.Canvas.ScaleTransform(newPage.ActualSize.Width \ page.ActualSize.Width, (newPage.ActualSize.Height \ page.ActualSize.Height))

				'Draw the page to new page
				newPage.Canvas.DrawTemplate(page.CreateTemplate(), New PointF(0, 0))
			Next page

			'Save the Pdf document
			Dim output As String = "ZoomToPageContents_result.pdf"
			newDoc.SaveToFile(output, FileFormat.PDF)

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
