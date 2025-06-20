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
			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\SetZoomFactor.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file
			doc.LoadFromFile(input)

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Create a new PdfDestination object for setting the zoom factor and location
			Dim dest As New PdfDestination(page)

			' Set the mode of the destination to Location
			dest.Mode = PdfDestinationMode.Location

			' Set the location of the destination to (-40, -40) coordinates
			dest.Location = New PointF(-40.0F, -40.0F)

			' Set the zoom factor of the destination to 0.6
			dest.Zoom = 0.6F

			' Create a new PdfGoToAction object with the destination
			Dim gotoAction As New PdfGoToAction(dest)

			' Set the action to be executed after opening the document
			doc.AfterOpenAction = gotoAction

			' Specify the output file name
			Dim output As String = "SetZoomFactor.pdf"

			' Save the modified document to the output file
			doc.SaveToFile(output)

			' Close the PDF document
			doc.Close()

			' Launch the Pdf file
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
