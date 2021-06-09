Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Widget

Namespace FillImageInButtonField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\ButtonField.pdf")

			'Get pdf forms
			Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			'Traverse all the forms
			For i As Integer = 0 To form.FieldsWidget.Count - 1
				'If it is Button field
				If TypeOf form.FieldsWidget(i) Is PdfButtonWidgetFieldWidget Then
					Dim field As PdfButtonWidgetFieldWidget = TryCast(form.FieldsWidget(i), PdfButtonWidgetFieldWidget)
					If field.Name = "Button1" Then
						'Set "true" to fit bounds
						field.IconLayout.IsFitBounds = True

						'Fill the annotation rectangle exactly without its original aspect ratio
						field.IconLayout.ScaleMode = PdfButtonIconScaleMode.Anamorphic

						'Fill an image
						field.SetButtonImage(PdfImage.FromFile("..\..\..\..\..\..\Data\E-logo.png"))
					End If
				End If
			Next i
			'Save to a file
			Dim result As String = "FillImageInButtonField.pdf"
			pdf.SaveToFile(result, Spire.Pdf.FileFormat.PDF)

			'Launch the file
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
