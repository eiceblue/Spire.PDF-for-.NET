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
			'pdf file 
			Dim input As String = "..\..\..\..\..\..\Data\Sample5.pdf"

			'open a pdf document
			Dim doc As New PdfDocument(input)

			'get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'set pdf destination
			Dim dest As New PdfDestination(page)
			dest.Mode = PdfDestinationMode.Location
			dest.Location = New PointF(-40f, -40f)
            dest.Zoom = 0.6F

			'set action
			Dim gotoAction As New PdfGoToAction(dest)
			doc.AfterOpenAction = gotoAction

			Dim output As String = "SetZoomFactor.pdf"

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
