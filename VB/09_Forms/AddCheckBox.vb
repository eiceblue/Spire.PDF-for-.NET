Imports Spire.Pdf
Imports Spire.Pdf.Fields

Namespace AddCheckBox
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

			' Create a new checkbox field on the first page of the document with a specified field ID
			Dim checkboxField As New PdfCheckBoxField(doc.Pages(0), "fieldID")

			' Set the position and size of the checkbox field
			Dim checkboxWidth As Single = 40
			Dim checkboxHeight As Single = 40
			checkboxField.Bounds = New RectangleF(60, 300, checkboxWidth, checkboxHeight)

			' Set the border width of the checkbox field
			checkboxField.BorderWidth = 0.75F

			' Set the initial checked state of the checkbox field
			checkboxField.Checked = True

			' Set the checkbox style to "Check"
			checkboxField.Style = PdfCheckBoxStyle.Check

			' Set the checkbox field as required
			checkboxField.Required = True

			' Add the checkbox field to the form
			doc.Form.Fields.Add(checkboxField)

			' Specify the output file name
			Dim result As String = "AddCheckBox-result.pdf"

			' Save the modified document to the specified file path
			doc.SaveToFile(result)

			' Close the document
			doc.Close()

			' Launch the Pdf file
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
