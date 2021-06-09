Imports Spire.Pdf
Imports Spire.Pdf.Texts

Namespace ReplaceTextSecond
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Input file path
			Dim input As String = "..\..\..\..\..\..\Data\ReplaceTextInPage.pdf"
			'Create a new PdfDocument
			Dim doc As New PdfDocument()
			' Load pdf file from disk
			doc.LoadFromFile(input)
			' Get the first page of pdf file
			Dim page As PdfPageBase = doc.Pages(0)
			'Create a PdfTextReplacer using the first page
			Dim replacer As New PdfTextReplacer(page)
			'Replace all texts in this page
			replacer.ReplaceAllText("Spire.PDF","E-iceblue")
			'Replace the first found word
			replacer.ReplaceText("Adobe Acrobat", "PDF editors")
			'Output file path
			Dim result As String = "ReplaceTextInPage_out.pdf"
			'Save the document
			doc.SaveToFile(result)
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
