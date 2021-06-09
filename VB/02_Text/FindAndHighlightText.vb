Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.General.Find

Namespace FindAndHighlightText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load the document from disk
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\FindAndHighlightText.pdf")
			Dim result() As PdfTextFind = Nothing
			For Each page As PdfPageBase In pdf.Pages
				'Find text
				result = page.FindText("science",TextFindParameter.None).Finds
				For Each find As PdfTextFind In result
					'Highlight searched text
					find.ApplyHighLight()
				Next find
			Next page

			Dim output As String = "FindAndHighlightText_out.pdf"
			'Save the document
			pdf.SaveToFile(output, FileFormat.PDF)

			'Launch the result file
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
