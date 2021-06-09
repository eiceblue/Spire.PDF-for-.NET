Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Namespace AddRadioButtonFieldWithOptions
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

			Dim x As Single = 150
			Dim y As Single = 550
			Dim temX As Single = 0
			'Create a pdf radio button list
			Dim radioButton As New PdfRadioButtonListField(page, "RadioButton")
			radioButton.Required = True
			'Add items into radio button list.
			For i As Integer = 0 To 2
				Dim item As New PdfRadioButtonListItem(String.Format("item{0}", i))
				item.BorderWidth = 0.75f
				item.Bounds = New RectangleF(x, y, 15, 15)
				item.BorderColor = Color.Red
				item.ForeColor = Color.Red
				radioButton.Items.Add(item)
				temX = x + 20
				page.Canvas.DrawString(String.Format("Item{0}", i), font, brush, temX, y)
				x = temX + 100
			Next i

			'Add the radio button list field into pdf document
			pdf.Form.Fields.Add(radioButton)

			Dim result As String = "AddRadioButtonFieldWithOptions_out.pdf"

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
