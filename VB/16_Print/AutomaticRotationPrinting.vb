Imports Spire.Pdf
Imports Spire.Pdf.Print
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Text

Namespace AutomaticRotationPrinting
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PDF document
			Dim doc As New PdfDocument()

			' Load an existing PDF file into the document
			doc.LoadFromFile("..\..\..\..\..\..\Data\MultiPage.pdf")
			'Set up multi page printing layout
			Dim printParameters As PdfMultiPageLayout = doc.PrintSettings.SelectMultiPageLayout(1, 2)
			'Control whether the page automatically rotates to fit the print layout
			printParameters.AutoRotatePages = True
			'Horizontal flipping double-sided printing mode
			doc.PrintSettings.Duplex = Duplex.Horizontal
			' Print the document using the specified settings
			doc.Print()

		End Sub
	End Class
End Namespace
