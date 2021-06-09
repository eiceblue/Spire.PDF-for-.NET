Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports System.IO
Namespace GetStyleOfRadioButton
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\GetStyleOfRadioButton.pdf"

			'Open pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			'Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			'Get all form fields
			Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			Dim builder As New StringBuilder()

			Dim num As Integer = 0

			'Loop through all fields
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				'Find the radio button field
				If TypeOf field Is PdfRadioButtonListFieldWidget Then
					num += 1
					Dim radio As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)

					'Get the button style
					Dim buttonStyle As PdfCheckBoxStyle = radio.ButtonStyle
					builder.AppendLine(String.Format("The button style of Radio button {0} is: " & buttonStyle.ToString(),num))
				End If
			Next i

			Dim result As String = "GetStyleOfRadioButton_out.txt"

			'Save the document
			File.WriteAllText(result, builder.ToString())

			'Launch the txt file
			DocumentViewer(result)
		End Sub
		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
