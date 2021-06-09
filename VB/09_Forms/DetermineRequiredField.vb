Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields

Namespace DetermineRequiredField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\DetermineRequiredField.pdf"
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)

			'Get pdf forms
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'Find the particular form field and determine if it marks as required or not
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)
					If textbox.Name = "username" Then
						textbox.Required = True
					End If
					If textbox.Name = "password2" Then
						textbox.Required = False
					End If
				End If
			Next i
			Dim output As String = "DetermineRequiredField.pdf"

			'Save pdf document
			doc.SaveToFile(output)

			'Launch the file
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
