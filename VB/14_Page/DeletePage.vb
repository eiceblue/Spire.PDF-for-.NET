Imports Spire.Pdf
Namespace DeletePage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the input PDF file
			Dim input As String = "..\..\..\..\..\..\Data\DeletePage.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(input)

			' Delete the fifth page from the document
			doc.Pages.RemoveAt(4)

			' Specify the output file path for the modified document
			Dim output As String = "DeletePage.pdf"

			' Save the document
			doc.SaveToFile(output)

			' Close the PDF document
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
