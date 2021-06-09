Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.IO

Namespace GetDocumentProperties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"
			Dim doc As New PdfDocument()
			' Read a pdf file
			doc.LoadFromFile(input)
			' Get document information
			Dim docInfo As PdfDocumentInformation = doc.DocumentInformation

			' Create a StringBuilder object to put the details
			Dim builder As New StringBuilder()
			builder.AppendLine("Author:" & docInfo.Author)
			builder.AppendLine("Creation Date: " & docInfo.CreationDate)
			builder.AppendLine("Keywords: " & docInfo.Keywords)
			builder.AppendLine("Modify Date: " & docInfo.ModificationDate)
			builder.AppendLine("Subject: " & docInfo.Subject)
			builder.AppendLine("Title: " & docInfo.Title)

			Dim result As String = "GetDocumentProperties_out.txt"

			File.WriteAllText(result, builder.ToString())
			'Launch the result file
			DocumentViewer(result)
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
