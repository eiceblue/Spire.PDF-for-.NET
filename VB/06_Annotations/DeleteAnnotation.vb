Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf

Namespace DeleteAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\DeleteAnnotation.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)

			'Remove the first annotation
			doc.Pages(0).AnnotationsWidget.RemoveAt(0)

			Dim output As String = "DeleteAnnotation.pdf"

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
