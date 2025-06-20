Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.Text

Namespace FillXFAFields
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a Pdf file
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\XFASample.pdf")

			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)
			Dim xfafields As List(Of XfaField) = formWidget.XFAForm.XfaFields

			' Iterate through each XFA field in the form
			For Each xfaField As XfaField In xfafields
				If TypeOf xfaField Is XfaTextField Then
					Dim textField As XfaTextField = TryCast(xfaField, XfaTextField)
					textField.Value = "E-iceblue"
				End If
				If TypeOf xfaField Is XfaDateTimeField Then
					Dim datetimeField As XfaDateTimeField = TryCast(xfaField, XfaDateTimeField)
					datetimeField.Value = Date.Now.ToString()
				End If
				If TypeOf xfaField Is XfaCheckButtonField Then
					Dim checkButtonField As XfaCheckButtonField = TryCast(xfaField, XfaCheckButtonField)
					checkButtonField.Checked = True
				End If
				If TypeOf xfaField Is XfaChoiceListField Then
					Dim choiceListField As XfaChoiceListField = TryCast(xfaField, XfaChoiceListField)
					choiceListField.SelectedItem = choiceListField.Items(0)
					choiceListField.SelectedItems.Add("NewItem")
				End If
				If TypeOf xfaField Is XfaDoubleField Then
					Dim doubleField As XfaDoubleField = TryCast(xfaField, XfaDoubleField)
					doubleField.Value = 2.14
				End If

			Next xfaField

			' Save the result pdf file
			doc.SaveToFile("FillXfaField.pdf", FileFormat.PDF)

			PDFDocumentViewer("FillXfaField.pdf")
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
