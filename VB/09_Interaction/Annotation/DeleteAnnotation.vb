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
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\Sample6.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'remove the first annotation
			doc.Pages(0).AnnotationsWidget.RemoveAt(0)

			Dim output As String = "DeleteAnnotation.pdf"

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
