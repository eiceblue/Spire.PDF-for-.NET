Imports Spire.Pdf
Imports System.Drawing.Printing

Namespace PrintWithoutPrintDialog
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Load the PDF file from the specified path.
			doc.LoadFromFile("..\..\..\..\..\..\Data\PrintWithoutPrintDialog.pdf")

			' Set the print controller to use the standard print controller, which bypasses the print dialog.
			doc.PrintSettings.PrintController = New StandardPrintController()

			' Print the document.
			doc.Print()

			' Close the document after printing.
			doc.Close()
		End Sub
	End Class
End Namespace
