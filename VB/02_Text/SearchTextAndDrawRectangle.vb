Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Texts

Namespace SearchTextAndDrawRectangle
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path to the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified input file
			doc.LoadFromFile(input)

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a PdfTextFinder object and set search options
			Dim finder As New PdfTextFinder(page)
			finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase

			' Find all occurrences of the text "Spire.PDF for .NET" on the page
			Dim finds As List(Of PdfTextFragment) = finder.Find("Spire.PDF for .NET")

			' Iterate over each found text fragment
			For Each find As PdfTextFragment In finds
				' Draw a rectangle with a red pen around the bounds of the found text
				page.Canvas.DrawRectangle(New PdfPen(PdfBrushes.Red, 0.9F), find.Bounds(0))
			Next find

			' Specify the output file name
			Dim result As String = "SearchTextAndDrawRectangle_out.pdf"

			' Save the modified document to the specified output file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
