Imports Spire.Pdf
Imports Spire.Pdf.Actions

Namespace GetZoomFactor
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\GetZoomFactor.pdf")

			' Get the "AfterOpenAction" of the document as a PdfGoToAction object
			Dim action As PdfGoToAction = TryCast(doc.AfterOpenAction, PdfGoToAction)

			' Get the zoom factor value from the destination of the action
			Dim zoomvalue As Single = action.Destination.Zoom

			' Display a message box showing the zoom factor of the document
			MessageBox.Show("The zoom factor of the document is " & zoomvalue * 100 & "%.")

			' Close the PDF document
			doc.Close()
		End Sub

	End Class
End Namespace
