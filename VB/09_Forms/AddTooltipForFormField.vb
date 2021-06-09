Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Fields

Namespace AddTooltipForFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Pdf file path
			Dim input As String = "..\..\..\..\..\..\Data\AddTooltipForFormField.pdf"

			'Open pdf document
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'As for existing pdf, the property needs to be set as true
			doc.AllowCreateForm = True

			'Create a new pdf font
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold)

			'Create a pdf brush
			Dim brush As PdfBrush = PdfBrushes.Black

			Dim x As Single = 50
			Dim y As Single = 590
			Dim tempX As Single = 0

			Dim text As String = "E-mail: "

			'Draw a text into page
			page.Canvas.DrawString(text, font, brush, x, y)

			tempX = font.MeasureString(text).Width + x + 15

			'Create a pdf textbox field
			Dim textbox As New PdfTextBoxField(page, "TextBox")

			'Set the bounds of textbox field
			textbox.Bounds = New RectangleF(tempX, y, 100, 15)

			'Set the border width of textbox field
			textbox.BorderWidth = 0.75f

			'Set the border style of textbox field
			textbox.BorderStyle = PdfBorderStyle.Solid

			'Add the textbox field into pdf document
			doc.Form.Fields.Add(textbox)

			'Add a tooltip for the textbox field
			doc.Form.Fields("TextBox").ToolTip = "Please insert a valid email address"

			Dim output As String = "AddTooltipForFormField.pdf"

			'Save pdf document
			doc.SaveToFile(output)

			'Launch the Pdf file
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
