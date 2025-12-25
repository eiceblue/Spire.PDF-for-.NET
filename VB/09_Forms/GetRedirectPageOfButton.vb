Imports System.IO
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Widget

Namespace GetRedirectPageOfButton
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\ButtonJump.pdf")
			'Retrieve form objects from PDF document
			Dim formWidget As PdfFormWidget = CType(doc.Form, PdfFormWidget)
			'Create a StringBuilder object
			Dim stringBuilder As New StringBuilder()
			stringBuilder.AppendLine("btnAction:")
			'Traverse the fields in the form
			For i As Integer = 0 To formWidget.FieldsWidget.Count - 1
				'Attempt to convert the current field to PdfButtonWidgetFieldWidget type
				Dim field = TryCast(formWidget.FieldsWidget(i), PdfButtonWidgetFieldWidget)
				'Obtain the actions triggered by mouse up and mouse down events
				If field.Actions.MouseUp IsNot Nothing AndAlso TypeOf field.Actions.MouseUp Is PdfNamedAction Then
					Dim aaa = CType(field.Actions.MouseUp, PdfNamedAction)
					'Append button names, event types, and operation information to the StringBuilder based on different event and action types
					stringBuilder.AppendLine(formWidget.FieldsWidget(i).Name & "-MouseUp-" & aaa.Destination.ToString())
				ElseIf field.Actions.MouseDown IsNot Nothing AndAlso TypeOf field.Actions.MouseDown Is PdfNamedAction Then

					Dim aaa = CType(field.Actions.MouseDown, PdfNamedAction)
					stringBuilder.AppendLine(formWidget.FieldsWidget(i).Name & "-MouseDown--" & aaa.Destination.ToString())
				ElseIf field.Actions.MouseDown IsNot Nothing AndAlso TypeOf field.Actions.MouseDown Is PdfUriAction Then

					Dim aaa = CType(field.Actions.MouseDown, PdfUriAction)
					stringBuilder.AppendLine(formWidget.FieldsWidget(i).Name & "-MouseDown--" & aaa.Uri.ToString())
				ElseIf field.Actions.MouseUp IsNot Nothing AndAlso TypeOf field.Actions.MouseUp Is PdfUriAction Then
					Dim aaa = CType(field.Actions.MouseUp, PdfUriAction)
					stringBuilder.AppendLine(formWidget.FieldsWidget(i).Name & "-MouseUp-" & aaa.Uri.ToString())
				End If

			Next i
			Dim outputFile As String = "out.txt"
			File.WriteAllText(outputFile, stringBuilder.ToString())
			doc.Dispose()

			'Launch the txt file
			PDFDocumentViewer(outputFile)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
