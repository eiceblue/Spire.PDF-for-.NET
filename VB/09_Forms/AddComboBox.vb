Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics
Imports System.ComponentModel
Imports System.Text

Namespace AddComboBox
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

			doc.AllowCreateForm = True

			'Create comboBox
			Dim comboBoxField As New PdfComboBoxField(doc.Pages(0), "Combox1")
			comboBoxField.Bounds = New RectangleF(60, 300, 70, 30)
			comboBoxField.BorderWidth = 0.75f
			comboBoxField.Font = New PdfFont(PdfFontFamily.Helvetica, 9f)
			comboBoxField.Required = True

			'Add items in comboBox
			comboBoxField.Items.Add(New PdfListFieldItem("Apple","itme1"))
			comboBoxField.Items.Add(New PdfListFieldItem("Banana","itme2"))
			comboBoxField.Items.Add(New PdfListFieldItem("Pear", "itme3"))
			comboBoxField.Items.Add(New PdfListFieldItem("Peach", "itme4"))
			comboBoxField.Items.Add(New PdfListFieldItem("Grape", "itme5"))

			'Add in form
			doc.Form.Fields.Add(comboBoxField)

			Dim output As String="AddComboBox-result.pdf"

			'Save to file
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
