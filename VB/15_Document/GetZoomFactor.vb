Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Actions


Namespace GetZoomFactor
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\GetZoomFactor.pdf")
			Dim action As PdfGoToAction = TryCast(doc.AfterOpenAction, PdfGoToAction)
			Dim zoomvalue As Single = action.Destination.Zoom
			MessageBox.Show("The zoom factor of the document is " & zoomvalue*100 & "%.")
		End Sub

	End Class
End Namespace
