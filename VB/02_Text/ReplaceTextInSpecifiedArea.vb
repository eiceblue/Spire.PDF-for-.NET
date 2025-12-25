Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Texts


Namespace ReplaceTextInSpecifiedArea
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

			' Get all pages of the document
			For i As Integer = 0 To pdf.Pages.Count - 1
				Dim page As PdfPageBase = pdf.Pages(i)

				' Create an instance of PdfTextReplacer to replace text
				Dim replacer As New PdfTextReplacer(page)

				' Set the replacement area for the text replacer
				replacer.Options.SetReplacementArea(New RectangleF(10, 0, 841, 150))

				' Specify the type of replacement to be performed
				replacer.Options.ReplaceType = PdfTextReplaceOptions.ReplaceActionType.WholeWord

				' Replace the text in the document
				replacer.ReplaceAllText("PDF", "Pdf")
			Next i

			Dim result As String = "ReplaceTextInSpecifiedArea_out.pdf"

			' Save the modified document to a file
			pdf.SaveToFile(result)

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
