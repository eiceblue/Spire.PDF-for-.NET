Imports Spire.Pdf

Namespace SplitDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\SplitDocument.pdf")

			' Specify the pattern for naming the split documents
			Dim pattern As String = "SplitDocument-{0}.pdf"

			' Split the document into separate pages using the specified pattern
			doc.Split(pattern)

			' Get the file name of the last page after splitting
			Dim lastPageFileName As String = String.Format(pattern, doc.Pages.Count - 1)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(lastPageFileName)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
