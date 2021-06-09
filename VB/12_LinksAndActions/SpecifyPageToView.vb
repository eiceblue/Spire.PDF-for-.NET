Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SpecifyPageToView
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load file from disk.
			doc.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

			'Create a PdfDestination with specific page, location and 50% zoom factor
			Dim dest As New PdfDestination(2, New PointF(0, 100), 0.5f)

			'Create GoToAction with dest
			Dim action As New PdfGoToAction(dest)

			'Set open action
			doc.AfterOpenAction = action

			Dim result As String = "SpecifyPageToView_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
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
