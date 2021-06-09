Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports System.IO

Namespace CustomDocumentProperties
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\CustomDocumentProperties.pdf"
			Dim doc As New PdfDocument()
			'Load a pdf file from disk
			doc.LoadFromFile(input)

			'Custom document properties
			doc.DocumentInformation.SetCustomerDefined("Company", "E-iceblue")
			doc.DocumentInformation.SetCustomerDefined("Component", "Spire.PDF for .NET")
			doc.DocumentInformation.SetCustomerDefined("Name", "Daisy")
			doc.DocumentInformation.SetCustomerDefined("Team", "SalesTeam")

			'Save to file
			Dim result As String = "CustomDocumentProperties_out.pdf"
			doc.SaveToFile(result, FileFormat.PDF)

			'Launch the file
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
