Imports Spire.Pdf
Imports Spire.Pdf.Texts

Namespace ReplaceTextSecond
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path to the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\ReplaceTextInPage.pdf"

			' Create a new PdfDocument instance
			Dim doc As New PdfDocument()

			' Load the input PDF file
			doc.LoadFromFile(input)

			' Get the first page of the PDF document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a PdfTextReplacer using the first page
			Dim replacer As New PdfTextReplacer(page)

			' Replace all occurrences of "Spire.PDF" with "E-iceblue"
			replacer.ReplaceAllText("Spire.PDF", "E-iceblue")

			' Replace the occurrence of "Adobe Acrobat" with "PDF editors"
			replacer.ReplaceText("Adobe Acrobat", "PDF editors")

			' Specify the output file name
			Dim result As String = "ReplaceTextInPage_out.pdf"

			' Save the modified document to a file
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
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
