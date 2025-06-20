Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddRadioButtonField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\FormFieldTemplate.pdf"

			' Create a new PDF document
			Dim pdf As New PdfDocument()

			' Load the PDF document from the input file
			pdf.LoadFromFile(input)

			' Get the first page of the document
			Dim page As PdfPageBase = pdf.Pages(0)

			' Allow form field creation in the document
			pdf.AllowCreateForm = True

			' Set the font and brush for drawing text
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F, PdfFontStyle.Bold)
			Dim brush As PdfBrush = PdfBrushes.Black

			' Set the initial coordinates for drawing
			Dim x As Single = 50
			Dim y As Single = 550
			Dim tempX As Single = 0

			' Define the text for the radio button field
			Dim text As String = "RadioButton: "

			' Draw the text onto the page
			page.Canvas.DrawString(text, font, brush, x, y)

			' Calculate the X coordinate for the radio button field based on the width of the text
			tempX = font.MeasureString(text).Width + x + 15

			' Create a radio button list form field
			Dim radioButton As New PdfRadioButtonListField(page, "RadioButton")
			radioButton.Required = True

			' Create a radio button item for the field
			Dim fieldItem As New PdfRadioButtonListItem()
			fieldItem.BorderWidth = 0.75F
			fieldItem.Bounds = New RectangleF(tempX, y, 15, 15)

			' Add the radio button item to the radio button field
			radioButton.Items.Add(fieldItem)

			' Add the radio button field to the PDF form
			pdf.Form.Fields.Add(radioButton)

			' Specify the output file path
			Dim result As String = "AddRadioButtonField_out.pdf"

			' Save the modified PDF document to the output file
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			' Launch the Pdf file
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
