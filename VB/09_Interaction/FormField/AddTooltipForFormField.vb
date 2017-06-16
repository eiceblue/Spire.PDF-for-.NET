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
			'create a pdf document
			Dim doc As New PdfDocument()

			'add a new page
			Dim page As PdfPageBase = doc.Pages.Add(PdfPageSize.A4, New PdfMargins(0))

			'create a new pdf font
			Dim font As New PdfFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold)

			'create a pdf brush
			Dim brush As PdfBrush = PdfBrushes.Black

			Dim x As Single = 50
			Dim y As Single = 50
			Dim tempX As Single = 0

			Dim text As String = "E-mail: "

			'draw a text into page
			page.Canvas.DrawString(text, font, brush, x, y)

			tempX = font.MeasureString(text).Width + x + 15

			'create a pdf textbox field
			Dim textbox As New PdfTextBoxField(page, "TextBox")

			'set the bounds of textbox field
			textbox.Bounds = New RectangleF(tempX, y, 100, 15)

			'set the border width of textbox field
			textbox.BorderWidth = 0.75f

			'set the border style of textbox field
			textbox.BorderStyle = PdfBorderStyle.Solid

			'add the textbox field into pdf document
			doc.Form.Fields.Add(textbox)

			'add a tooltip for the textbox field
			doc.Form.Fields("TextBox").ToolTip = "Please insert a valid email address"

			Dim output As String = "AddTooltipForFormField.pdf"

			'save pdf document
			doc.SaveToFile(output)

			'Launching the Pdf file
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
