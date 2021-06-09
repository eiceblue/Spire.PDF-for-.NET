Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SplitAPageIntoMultipage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load Pdf document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Create a new Pdf
			Dim newPdf As New PdfDocument()

			'Remove all the margins
			newPdf.PageSettings.Margins.All = 0

			'Set the page size of new Pdf
			newPdf.PageSettings.Width = page.Size.Width
			newPdf.PageSettings.Height = page.Size.Height \ 2

			'Add a new page
			Dim newPage As PdfPageBase = newPdf.Pages.Add()

			Dim format As New PdfTextLayout()
			format.Break = PdfLayoutBreakType.FitPage
			format.Layout = PdfLayoutType.Paginate

			'Draw the page in the new page
			page.CreateTemplate().Draw(newPage, New PointF(0, 0), format)

			'Save the Pdf document
			Dim output As String = "SplitAPageIntoMultipage_out.pdf"
			newPdf.SaveToFile(output)

			'Launch the document
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
