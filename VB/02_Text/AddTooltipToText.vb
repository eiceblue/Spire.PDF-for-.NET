Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Fields
Namespace AddTooltipToText
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Create one page
			Dim page As PdfPageBase = doc.Pages.Add()

			page.Canvas.DrawString("Move the mouse cursor over the following text to display a tooltip", New PdfTrueTypeFont(New Font("Arial", 15), True), PdfBrushes.Black, New PointF(10, 20))

			'Define the text and its style
			Dim text1 As String = "Your Office Development Master"
			Dim font1 As New PdfTrueTypeFont(New Font("Arial",18),True)
			Dim sizeF1 As SizeF= font1.MeasureString(text1)
			Dim rec1 As New RectangleF(New Point(100,100), sizeF1)
			'Draw text 
			page.Canvas.DrawString(text1, font1, New PdfSolidBrush(Color.Blue), rec1)

			'Create invisible button on text position
			Dim field1 As New PdfButtonField(page, "field1")
			'Set the bounds and size of field
			field1.Bounds = rec1
			'Set tooltip content
			field1.ToolTip = "E-iceblue Co. Ltd., a vendor of .NET, Java and WPF development components"
			'Set no border for field
			field1.BorderWidth = 0
			'Set backcolor and forcolor for field
			field1.BackColor = Color.Transparent
			field1.ForeColor = Color.Transparent
			field1.LayoutMode = PdfButtonLayoutMode.IconOnly
			field1.IconLayout.IsFitBounds = True

			'Define the text and its style 
			Dim text2 As String = "Spire.PDF"
			Dim font2 As New PdfFont(PdfFontFamily.TimesRoman, 20)
			Dim sizeF2 As SizeF = font2.MeasureString(text2)
			Dim rec2 As New RectangleF(New Point(100, 160), sizeF2)
			'Draw text 
			page.Canvas.DrawString(text2, font2, PdfBrushes.DarkOrange, rec2)

			'Create invisible button on text position
			Dim field2 As New PdfButtonField(page, "field2")
			field2.Bounds = rec2
			field2.ToolTip = "A professional PDF library applied to creating," & "writing, editing, handling and reading PDF files" & "without any external dependencies within .NET" & "( C#, VB.NET, ASP.NET, .NET Core) application."
			field2.BorderWidth = 0
			field2.BackColor = Color.Transparent
			field2.ForeColor = Color.Transparent
			field2.LayoutMode = PdfButtonLayoutMode.IconOnly
			field2.IconLayout.IsFitBounds = True

			'Add the buttons to pdf form
			doc.AllowCreateForm = True
			doc.Form.Fields.Add(field1)
			doc.Form.Fields.Add(field2)

			Dim result As String = "AddTooltipToText_out.pdf"

			'Save the document
			doc.SaveToFile(result)
			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
