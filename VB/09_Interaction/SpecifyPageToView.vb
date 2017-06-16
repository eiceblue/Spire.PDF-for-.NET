Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports Spire.Pdf
Namespace SpecifyPageToView
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\Sample3.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'get the fourth page
			Dim page As PdfPageBase = doc.Pages(3)

			'create a destination
			Dim destination As New PdfDestination(page)

			'create GoToAction instance
			Dim action As New PdfGoToAction(destination)

			'set the action to execute when the document is opened.
			doc.AfterOpenAction = action

			Dim output As String = "SpecifyPageToView.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
