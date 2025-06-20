Imports Spire.Pdf
Imports Spire.Pdf.Print

Namespace MultiPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\MultiPage.pdf")

			' Configure the print settings to use a multi-page layout with 2 rows and 2 columns,
			' without rotating pages, in horizontal order
			doc.PrintSettings.SelectMultiPageLayout(2, 2, False, PdfMultiPageOrder.Horizontal)

			' Select a page range from page 3 to page 15 for printing
			doc.PrintSettings.SelectPageRange(3, 15)

			' Set the paper margins for printing to 10 units on all sides
			doc.PrintSettings.SetPaperMargins(10, 10, 10, 10)

			' Set the orientation of the printing to portrait (not landscape)
			doc.PrintSettings.Landscape = False

			' Print the document using the configured settings
			doc.Print()

			' Close the document after printing
			doc.Close()
		End Sub
	End Class
End Namespace
