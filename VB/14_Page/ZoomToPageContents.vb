Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ZoomToPageContents
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument object for the original PDF
			Dim doc As New PdfDocument()

			' Load the original PDF file from the specified path
			doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

			' Create a new instance of PdfDocument object for the modified PDF
			Dim newDoc As New PdfDocument()

			' Iterate through each page in the original PDF
			For Each page As PdfPageBase In doc.Pages
				' Add a new page to the modified PDF with A3 size and margins set to 0
				Dim newPage As PdfPageBase = newDoc.Pages.Add(PdfPageSize.A3, New PdfMargins(0, 0))

				' Scale the content of the original page to fit the new page size
				newPage.Canvas.ScaleTransform(newPage.ActualSize.Width / page.ActualSize.Width, (newPage.ActualSize.Height / page.ActualSize.Height))

				' Draw the template of the original page onto the new page at coordinates (0, 0)
				newPage.Canvas.DrawTemplate(page.CreateTemplate(), New PointF(0, 0))
			Next page

			' Specify the filename for the output PDF
			Dim output As String = "ZoomToPageContents_result.pdf"

			' Save the modified PDF document to the output file as PDF format
			newDoc.SaveToFile(output, FileFormat.PDF)

			' Close the modified PDF document
			newDoc.Close()

			' Close the original PDF document
			doc.Close()

			' Launch the Pdf file
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
