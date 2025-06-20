Imports Spire.Pdf

Namespace PrintPdfDocument
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\PrintPdfDocument.pdf")

			' Create a new instance of PrintDialog object
			Dim dialogPrint As New PrintDialog()

			' Allow printing to a file
			dialogPrint.AllowPrintToFile = True

			' Allow selection of specific pages for printing
			dialogPrint.AllowSomePages = True

			' Set the starting page for printing to the first page
			dialogPrint.PrinterSettings.FromPage = 1

			' Set the ending page for printing to the total number of pages in the document
			dialogPrint.PrinterSettings.ToPage = doc.Pages.Count

			' If the print dialog is shown and the user clicks "OK"
			If dialogPrint.ShowDialog() = DialogResult.OK Then

				' Select the page range based on the settings from the print dialog
				doc.PrintSettings.SelectPageRange(dialogPrint.PrinterSettings.FromPage, dialogPrint.PrinterSettings.ToPage)

				' Set the printer name for printing to the selected printer from the print dialog
				doc.PrintSettings.PrinterName = dialogPrint.PrinterSettings.PrinterName

				' Print the document using the configured settings
				doc.Print()
			End If

			' Close the document after printing
			doc.Close()
		End Sub
	End Class
End Namespace
