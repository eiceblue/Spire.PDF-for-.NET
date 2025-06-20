Imports Spire.Pdf
Imports Spire.Pdf.Print
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SetPrintingMargins
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the file path of the PDF document to be printed
			Dim filePath As String = "../../../../../../Data/SetPrintingMargins.pdf"

			' Create a new PdfDocument object to work with PDF files
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile(filePath)

			' Set the multi-page layout for printing, with 2 rows and 2 columns, without duplex printing,
			' with horizontal page order, and a margin of 10 points
			doc.PrintSettings.SelectMultiPageLayout(2, 2, False, PdfMultiPageOrder.Horizontal, 10)

			' Select the page range to be printed, from page 1 to page 4
			doc.PrintSettings.SelectPageRange(1, 4)

			' Set the orientation of the print to portrait (non-landscape)
			doc.PrintSettings.Landscape = False

			' Print the document using the selected settings
			doc.Print()

			' Close the document after printing
			doc.Close()
		End Sub
	End Class
End Namespace
