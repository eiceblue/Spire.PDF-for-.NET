Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General

Namespace SpecifyPageToView
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument class
			Dim doc As New PdfDocument()

			' Load a PDF file from a specified path
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			' Get the first page of the loaded document
			Dim page As PdfPageBase = doc.Pages(1)

			' Create a new destination for the PDF page, specifying its location
			Dim dest As New PdfDestination(page, New PointF(0, 100))

			' Create a new GoTo action with the specified destination
			Dim action As New PdfGoToAction(dest)

			' Set the action to be performed after the document is opened
			doc.AfterOpenAction = action

			' Specify the resulting PDF file name
			Dim result As String = "SpecifyPageToView_out.pdf"

			' Save the modified document to the specified file
			doc.SaveToFile(result)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
