Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Namespace SetZoomFactor
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\SetZoomFactor.pdf"

			'Open a pdf document
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)
			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Set pdf destination
			Dim dest As New PdfDestination(page)
			dest.Mode = PdfDestinationMode.Location
			dest.Location = New PointF(-40f, -40f)
			dest.Zoom = 0.6f

			'Set action
			Dim gotoAction As New PdfGoToAction(dest)
			doc.AfterOpenAction = gotoAction

			Dim output As String = "SetZoomFactor.pdf"

			'Save pdf document
			doc.SaveToFile(output)

			'Launch the Pdf file
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
