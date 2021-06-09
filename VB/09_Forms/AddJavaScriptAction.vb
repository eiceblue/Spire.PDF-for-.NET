Imports System.IO
Imports System.Xml.XPath
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.AutomaticFields
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddJavaScriptAction
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

			'Draw a text into page
			Dim text1 As String = "Enter a number, such as 12345: "
			'Draw a text into page
			page.Canvas.DrawString(text1, font, brush, x, y)

			'Add a textBox field 
			tempX = font.MeasureString(text1).Width + x + 15
			Dim textbox As New PdfTextBoxField(page, "Number-TextBox")
			textbox.Bounds = New RectangleF(tempX, y, 100, 15)
			textbox.BorderWidth = 0.75f
			textbox.BorderStyle = PdfBorderStyle.Solid

			'Add a JavaScript action to be performed when uses type a keystroke into a text field
			Dim js As String = PdfJavaScript.GetNumberKeystrokeString(2, 0, 0, 0, "$", True)
			Dim jsAction As New PdfJavaScriptAction(js)
			textbox.Actions.KeyPressed = jsAction

			'Add a JavaScript action to format the value of text field
			js = PdfJavaScript.GetNumberFormatString(2, 0, 0, 0, "$", True)
			jsAction = New PdfJavaScriptAction(js)
			textbox.Actions.Format = jsAction
			pdf.Form.Fields.Add(textbox)

			'Save and launch the result file
			Dim output As String = "AddJavaScriptAction_out.pdf"
			'Save to file
			pdf.SaveToFile(output)

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
