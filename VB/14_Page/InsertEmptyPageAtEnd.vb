Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace InsertEmptyPageAtEnd
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load Pdf document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/MultipagePDF.pdf")

			'Add an empty page at the end 
			doc.Pages.Add(PdfPageSize.A4, New PdfMargins(0, 0))

			'Save the Pdf document
			Dim output As String = "InsertEmptyPageAtEnd_result.pdf"
			doc.SaveToFile(output, FileFormat.PDF)

			'Launch the Pdf file
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
