Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Attachments
Imports System.IO

Namespace DeleteAllAttachments
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\Sample7.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'get all attachments
			Dim attachments As PdfAttachmentCollection = doc.Attachments

			'delete all attachments
			attachments.Clear()

			Dim output As String = "DeleteAllAttachments.pdf"

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
