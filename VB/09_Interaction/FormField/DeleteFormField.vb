Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Namespace DeleteFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'pdf file 
            Dim input As String = "..\..\..\..\..\..\..\Data\FormField.pdf"

			'open pdf document
			Dim doc As New PdfDocument(input)

			'get pdf form
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'find the particular form field and delete it
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				If TypeOf field Is PdfTextBoxFieldWidget Then
					Dim textbox As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)
					If textbox.Name = "password2" Then
						formWidget.FieldsWidget.Remove(textbox)
					End If
				End If
			Next i
			Dim output As String = "DeleteFormField.pdf"

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
