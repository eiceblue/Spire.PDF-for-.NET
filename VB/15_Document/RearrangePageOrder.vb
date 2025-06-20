Imports Spire.Pdf

Namespace RearrangePageOrder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_3.pdf")

			' Re-arrange the order of pages in the document by specifying the new page order
			doc.Pages.ReArrange(New Integer() {1, 0})

			' Specify the result file path for saving the modified document
			Dim result As String = "RearrangePageOrder-result.pdf"

			' Save the modified document to the result file in PDF format
			doc.SaveToFile(result, FileFormat.PDF)

			' Close the PDF document
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
