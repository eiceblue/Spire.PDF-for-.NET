Imports Spire.Pdf

Namespace InsertEmptyPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load an existing PDF from disk
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			' Insert a blank page as the second page
			doc.Pages.Insert(1)

			' Specify the output file path for the modified PDF
			Dim result As String = "InsertEmptyPage_out.pdf"

			' Save the modified document
			doc.SaveToFile(result)

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