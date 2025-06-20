Imports Spire.Pdf

Namespace SplitPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified path.
			doc.LoadFromFile("..\..\..\..\..\..\Data\SplitPage.pdf")

			' Set the printing orientation to portrait (not landscape).
			doc.PrintSettings.Landscape = False

			' Select a page range with only page 1 for printing.
			doc.PrintSettings.SelectPageRange(1, 1)

			' Select the split page layout for printing.
			doc.PrintSettings.SelectSplitPageLayout()

			' Print the document.
			doc.Print()

			' Close the document after printing.
			doc.Close()
		End Sub
	End Class
End Namespace
