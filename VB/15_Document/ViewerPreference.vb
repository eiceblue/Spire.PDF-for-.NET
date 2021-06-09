Imports Spire.Pdf
Imports Spire.Pdf.Graphics


Namespace ViewerPreference
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load pdf document
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\ViewerPreference.pdf")

			'Set view reference
			doc.ViewerPreferences.CenterWindow = True
			doc.ViewerPreferences.DisplayTitle = False
			doc.ViewerPreferences.FitWindow = False
			doc.ViewerPreferences.HideMenubar = True
			doc.ViewerPreferences.HideToolbar = True
			doc.ViewerPreferences.PageLayout = PdfPageLayout.SinglePage

			'Save pdf file
			doc.SaveToFile("ViewerPreference_result.pdf")
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer("ViewerPreference_result.pdf")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
