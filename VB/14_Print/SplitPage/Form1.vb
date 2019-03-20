Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SplitPage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()
			'Load a file
			doc.LoadFromFile("..\..\..\..\..\..\Data\SplitPage.pdf")
			'Indicating whether the page is printed in landscape or portrait orientation.
			doc.PrintSettings.Landscape = False
			'Set print page range
			doc.PrintSettings.SelectPageRange(1, 1)
			'Select split page to multiple paper layout
			doc.PrintSettings.SelectSplitPageLayout()
			'Print document
			doc.Print()
			'Close the document
			doc.Close()
		End Sub
	End Class
End Namespace
