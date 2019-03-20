Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Print

Namespace SinglePage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()
			'Load a file
			doc.LoadFromFile("..\..\..\..\..\..\Data\SinglePage.pdf")
			'Indicate whether the page is printed in landscape or portrait orientation
			doc.PrintSettings.Landscape = False
			'Set print page range
			doc.PrintSettings.SelectPageRange(9, 15)
			'Select one page to one paper layout
			doc.PrintSettings.SelectSinglePageLayout(PdfSinglePageScalingMode.CustomScale, True, 100)
			'Set paper margins,measured in hundredths of an inch
			doc.PrintSettings.SetPaperMargins(10, 10, 10, 10)
			'Print document
			doc.Print()
			'Close the document
			doc.Close()
		End Sub
	End Class
End Namespace
