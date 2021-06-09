Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Namespace AddRadioButtonField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\FormFieldTemplate.pdf"

			'Open pdf document
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile(input)

			'Get the first page
			Dim page As PdfPageBase = pdf.Pages(0)

			'As for existing pdf, the property needs to be set as true
			pdf.AllowCreateForm = True

			'Create a new pdf font
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold)

			'Create a pdf brush
			Dim brush As PdfBrush = PdfBrushes.Black

			Dim x As Single = 50
			Dim y As Single = 550
			Dim tempX As Single = 0

			Dim text As String = "RadioButton: "

			'Draw a text into page
			page.Canvas.DrawString(text, font, brush, x, y)

			tempX = font.MeasureString(text).Width + x + 15

			'Create a pdf radio button field
			Dim radioButton As New PdfRadioButtonListField(page, "RadioButton")
			radioButton.Required = True
			Dim fieldItem As New PdfRadioButtonListItem()
			fieldItem.BorderWidth = 0.75f
			fieldItem.Bounds = New RectangleF(tempX, y, 15, 15)
			radioButton.Items.Add(fieldItem)

			'Add the radio button field into pdf document
			pdf.Form.Fields.Add(radioButton)

			Dim result As String = "AddRadioButtonField_out.pdf"

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
