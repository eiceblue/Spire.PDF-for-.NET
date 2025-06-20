Imports Spire.Pdf
Imports Spire.Pdf.Comparison

Namespace CompareDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object and load the first PDF document from the specified file path
			Dim pdf1 As New PdfDocument("..\..\..\..\..\..\Data\Template_Pdf_2.pdf")

			' Create a new PdfDocument object and load the second PDF document from the specified file path
			Dim pdf2 As New PdfDocument("..\..\..\..\..\..\Data\Template_Pdf_5.pdf")

			' Create a new PdfComparer object with the two loaded PDF documents
			Dim compare As New PdfComparer(pdf1, pdf2)

			' Set the page ranges to be compared based on the number of pages in each document
			compare.Options.SetPageRanges(0, pdf1.Pages.Count - 1, 0, pdf2.Pages.Count - 1)

			' Compare the two PDF documents and generate a comparison result PDF document
			compare.Compare("CompareDocument-Result.pdf")

			' Close the documents
			pdf1.Close()
			pdf2.Close()

			' Launch the Pdf file
			PDFDocumentViewer("CompareDocument-Result.pdf")
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
