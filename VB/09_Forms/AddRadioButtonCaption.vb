Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddRadioButtonCaption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\RadioButton.pdf"
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			'Get pdf forms
			Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			'Find the radio button field and add capture
			For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
				Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

				If TypeOf field Is PdfRadioButtonListFieldWidget Then
					Dim radioButton As PdfRadioButtonListFieldWidget = TryCast(field, PdfRadioButtonListFieldWidget)
					If radioButton.Name = "RadioButton" Then
						'Get the page
						Dim page As PdfPageBase = radioButton.Page

						'Set capture name
						Dim text As String = "Radio button caption"
						'Set font, pen and brush
						Dim font As New PdfFont(PdfFontFamily.Helvetica, 12f)
						Dim pen As New PdfPen(Color.Red, 0.02f)
						Dim brush As New PdfSolidBrush(Color.Red)
						'Set the capture location
						Dim x As Single = radioButton.Location.X
						Dim y As Single = radioButton.Location.Y - font.MeasureString(text).Height - 10

						'Draw capture
						page.Canvas.DrawString(text, font, pen, brush, x, y)
					End If
				End If
			Next i

			Dim result As String = "AddRadioButtonCaption_out.pdf"

			'Save the document
			pdf.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
