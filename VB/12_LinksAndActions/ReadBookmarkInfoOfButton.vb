Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Widget
Imports System.IO

Namespace ReadBookmarkInfoOfButton
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a PDF document
			Dim pdf As New PdfDocument()

			' Load the PDF file from disk
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ReadBookmarkInfoOfButton.pdf")

			Dim formWidget As PdfFormWidget = CType(pdf.Form, PdfFormWidget)
			Dim stringBuilder As New StringBuilder()
			stringBuilder.AppendLine("btnAction:")
			For i As Integer = 0 To formWidget.FieldsWidget.Count - 1
				If TypeOf formWidget.FieldsWidget(i) Is PdfButtonWidgetFieldWidget Then
					Dim field = TryCast(formWidget.FieldsWidget(i), PdfButtonWidgetFieldWidget)
					If field.Actions.MouseUp IsNot Nothing AndAlso TypeOf field.Actions.MouseUp Is PdfNamedAction Then
						Dim aaa = CType(field.Actions.MouseUp, PdfNamedAction)
						stringBuilder.AppendLine(field.Name & "-MouseUp-" & aaa.Destination.ToString())
					ElseIf field.Actions.MouseDown IsNot Nothing AndAlso TypeOf field.Actions.MouseDown Is PdfNamedAction Then
						Dim aaa = CType(field.Actions.MouseDown, PdfNamedAction)
						stringBuilder.AppendLine(field.Name & "-MouseDown--" & aaa.Destination.ToString())
					ElseIf field.Actions.MouseDown IsNot Nothing AndAlso TypeOf field.Actions.MouseDown Is PdfUriAction Then
						Dim aaa = CType(field.Actions.MouseDown, PdfUriAction)
						stringBuilder.AppendLine(field.Name & "-MouseDown--" & aaa.Uri.ToString())
					ElseIf field.Actions.MouseUp IsNot Nothing AndAlso TypeOf field.Actions.MouseUp Is PdfUriAction Then
						Dim aaa = CType(field.Actions.MouseUp, PdfUriAction)
						stringBuilder.AppendLine(field.Name & "-MouseUp-" & aaa.Uri.ToString())
					ElseIf field.Actions.MouseUp IsNot Nothing AndAlso TypeOf field.Actions.MouseUp Is PdfGotoNameAction Then
						Dim aaa = CType(field.Actions.MouseUp, PdfGotoNameAction)
						stringBuilder.AppendLine(field.Name & "-MouseUp-" & aaa.Destination.ToString())
					ElseIf field.Actions.MouseDown IsNot Nothing AndAlso TypeOf field.Actions.MouseDown Is PdfGotoNameAction Then
						Dim aaa = CType(field.Actions.MouseDown, PdfGotoNameAction)
						stringBuilder.AppendLine(field.Name & "-MouseDown-" & aaa.Destination.ToString())
					End If
				End If
			Next i

			Dim result As String = "ReadBookmarkInfoOfButton_out.txt"

			File.WriteAllText(result, stringBuilder.ToString())

			' Close the PDF document
			pdf.Close()

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
