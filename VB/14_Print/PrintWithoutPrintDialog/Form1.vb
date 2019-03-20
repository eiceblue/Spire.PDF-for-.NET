Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports System.Drawing.Printing

Namespace PrintWithoutPrintDialog
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a document
			Dim doc As New PdfDocument()

			'Load file
			doc.LoadFromFile("..\..\..\..\..\..\Data\PrintWithoutPrintDialog.pdf")

			'Set the print controller without printing process dialog
			doc.PrintSettings.PrintController = New StandardPrintController()

			'Print all pages with default printer
			doc.Print()
		End Sub
	End Class
End Namespace
