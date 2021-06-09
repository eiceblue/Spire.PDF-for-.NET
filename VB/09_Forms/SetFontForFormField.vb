Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.Text

Namespace SetFontForFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf document
			Dim doc As New PdfDocument()

			'Load from file
			doc.LoadFromFile("..\..\..\..\..\..\Data\TextBoxSampleB.pdf")

			'Get form fields
			Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			'Get textbox
			Dim textbox As PdfTextBoxFieldWidget = TryCast(formWidget.FieldsWidget("Text1"), PdfTextBoxFieldWidget)

			'Set the font for textbox
			textbox.Font = New PdfTrueTypeFont(New Font("Tahoma", 12), True)

			'Set text
			textbox.Text = "Hello World"

			Dim result As String = "SetFontForFormField-result.pdf"
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
