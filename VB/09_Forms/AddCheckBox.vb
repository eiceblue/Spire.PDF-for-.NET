Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports System.ComponentModel
Imports System.Text

Namespace AddCheckBox
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim doc As New PdfDocument()
			doc.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

			doc.AllowCreateForm = True

			'Create checkbox
			Dim checkboxField As New PdfCheckBoxField(doc.Pages(0), "fieldID")
			Dim checkboxWidth As Single = 40
			Dim checkboxHeight As Single = 40
			checkboxField.Bounds = New RectangleF(60, 300, checkboxWidth, checkboxHeight)
			checkboxField.BorderWidth = 0.75f
			checkboxField.Checked = True
			checkboxField.Style = PdfCheckBoxStyle.Check
			checkboxField.Required = True

			'Add in form
			doc.Form.Fields.Add(checkboxField)

			Dim result As String = "AddCheckBox-result.pdf"

			'Save to file
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
