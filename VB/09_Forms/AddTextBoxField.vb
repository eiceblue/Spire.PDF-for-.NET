Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddTextBoxField
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

			Dim text As String = "TexBox: "

			'Draw a text into page
			page.Canvas.DrawString(text, font, brush, x, y)

			'Add a textBox field
			tempX = font.MeasureString(text).Width + x + 15
			Dim textbox As New PdfTextBoxField(page, "TextBox")
			textbox.Bounds = New RectangleF(tempX, y, 100, 15)
			textbox.BorderWidth = 0.75f
			textbox.BorderStyle = PdfBorderStyle.Solid
			pdf.Form.Fields.Add(textbox)

			Dim result As String = "AddTextBoxField_out.pdf"

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
