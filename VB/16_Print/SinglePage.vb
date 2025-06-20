Imports Spire.Pdf
Imports Spire.Pdf.Print

Namespace SinglePage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified path.
			doc.LoadFromFile("..\..\..\..\..\..\Data\SinglePage.pdf")

			' Set the printing orientation to portrait (not landscape).
			doc.PrintSettings.Landscape = False

			' Select a page range from page 9 to page 15 for printing.
			doc.PrintSettings.SelectPageRange(9, 15)

			' Set the single page layout with custom scaling mode and maintain aspect ratio.
			doc.PrintSettings.SelectSinglePageLayout(PdfSinglePageScalingMode.CustomScale, True, 100)

			' Set the paper margins for printing to 10 units on all sides.
			doc.PrintSettings.SetPaperMargins(10, 10, 10, 10)

			' Print the document.
			doc.Print()

			' Close the document after printing.
			doc.Close()
		End Sub
	End Class
End Namespace
