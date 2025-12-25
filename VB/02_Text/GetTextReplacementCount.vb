Imports Spire.Pdf
Imports Spire.Pdf.Texts
Imports System.IO

Namespace GetTextReplacementCount
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a PDF document
			Dim pdf As New PdfDocument()

			' Load the PDF file from disk
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ReplaceTextInPage.pdf")

			' Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			' Create an instance of PdfTextReplacer to replace text
			Dim replacer As New PdfTextReplacer(page)

			' Specify the type of replacement to be performed
			replacer.Options.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.WholeWord

			' Replace the text in the document
			Dim count As Integer = replacer.ReplaceAllText("PDF", "Pdf")


			Dim result As String = "GetTextReplacementCount.txt"

			' Save the modified document to a file
			File.WriteAllText(result, "The count of text replacements: " & count)

			' Close the PDF document
			pdf.Close()

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
