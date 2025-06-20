Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SplitAPageIntoMultipage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified path
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			' Get the first page of the PDF document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a new instance of PdfDocument object for the modified PDF
			Dim newPdf As New PdfDocument()

			' Set the margins of the new PDF document to 0
			newPdf.PageSettings.Margins.All = 0

			' Set the width and height of the new PDF document's page to half of the original page size
			newPdf.PageSettings.Width = page.Size.Width
			newPdf.PageSettings.Height = page.Size.Height / 2

			' Add a new page to the new PDF document
			Dim newPage As PdfPageBase = newPdf.Pages.Add()

			' Create a new instance of PdfTextLayout object for formatting the content
			Dim format As New PdfTextLayout()
			format.Break = PdfLayoutBreakType.FitPage
			format.Layout = PdfLayoutType.Paginate

			' Draw the template of the original page onto the new page, starting at coordinates (0, 0)
			page.CreateTemplate().Draw(newPage, New PointF(0, 0), format)

			' Specify the filename for the output PDF
			Dim output As String = "SplitAPageIntoMultipage_out.pdf"

			' Save the modified PDF document to the output file
			newPdf.SaveToFile(output)

			' Close the modified PDF document
			newPdf.Close()

			' Close the original PDF document
			doc.Close()

			' Launch the document
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
