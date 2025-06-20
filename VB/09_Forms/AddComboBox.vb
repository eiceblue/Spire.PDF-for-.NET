Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddComboBox
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument instance
			Dim doc As New PdfDocument()

			' Load an existing PDF document from the specified file path
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

			' Enable form creation in the document
			doc.AllowCreateForm = True

			' Create a new combo box field on the first page of the document with a specified field name
			Dim comboBoxField As New PdfComboBoxField(doc.Pages(0), "Combox1")

			' Set the position and size of the combo box field
			comboBoxField.Bounds = New RectangleF(60, 300, 70, 30)

			' Set the border width of the combo box field
			comboBoxField.BorderWidth = 0.75F

			' Set the font for the combo box field
			comboBoxField.Font = New PdfFont(PdfFontFamily.Helvetica, 9.0F)

			' Set the combo box field as required
			comboBoxField.Required = True

			' Add items to the combo box field
			comboBoxField.Items.Add(New PdfListFieldItem("Apple", "item1"))
			comboBoxField.Items.Add(New PdfListFieldItem("Banana", "item2"))
			comboBoxField.Items.Add(New PdfListFieldItem("Pear", "item3"))
			comboBoxField.Items.Add(New PdfListFieldItem("Peach", "item4"))
			comboBoxField.Items.Add(New PdfListFieldItem("Grape", "item5"))

			' Add the combo box field to the form
			doc.Form.Fields.Add(comboBoxField)

			' Specify the output file name
			Dim output As String = "AddComboBox-result.pdf"

			' Save the modified document to the specified file path
			doc.SaveToFile(output)

			' Close the document
			doc.Close()

			' Launch the Pdf file
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
