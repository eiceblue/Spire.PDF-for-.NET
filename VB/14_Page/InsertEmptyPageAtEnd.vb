Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace InsertEmptyPageAtEnd
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF from disk
			doc.LoadFromFile("../../../../../../Data/MultipagePDF.pdf")

			' Add an empty page at the end
			doc.Pages.Add(PdfPageSize.A4, New PdfMargins(0, 0))

			' Specify the output file path for the modified PDF
			Dim output As String = "InsertEmptyPageAtEnd_result.pdf"

			' Save the modified Pdf document
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the Pdf document
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
