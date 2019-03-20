Imports Spire.Pdf
Imports System.ComponentModel
Imports System.Text

Namespace PrintPdfDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a document
			Dim doc As New PdfDocument()

			'Load file
			doc.LoadFromFile("..\..\..\..\..\..\Data\PrintPdfDocument.pdf")

			'Set the printer and select the pages you want to print
			Dim dialogPrint As New PrintDialog()
			dialogPrint.AllowPrintToFile = True
			dialogPrint.AllowSomePages = True
			dialogPrint.PrinterSettings.FromPage = 1
			dialogPrint.PrinterSettings.ToPage = doc.Pages.Count

            If dialogPrint.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'print
                doc.PrintSettings.SelectPageRange(dialogPrint.PrinterSettings.FromPage, dialogPrint.PrinterSettings.ToPage)
                doc.PrintSettings.PrinterName = dialogPrint.PrinterSettings.PrinterName
                doc.Print()
            End If
		End Sub
	End Class
End Namespace
