Imports Spire.Pdf
Imports Spire.Pdf.Widget

Namespace SetExportValueForCheckbox
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Input and output file paths
			Dim input As String = "..\..\..\..\..\..\Data\SetExportValueForCheckbox.pdf"
			Dim result As String = "SetExportValueForCheckbox_result.pdf"

			Dim pdf As New PdfDocument()
			'Load from disk
			pdf.LoadFromFile(input)
			Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)
			Dim count As Integer = 1
			'Traverse all FieldsWidget
			For Each field As PdfFieldWidget In formWidget.FieldsWidget
				'Find the checkbox
				If TypeOf field Is PdfCheckBoxWidgetFieldWidget Then
					Dim checkbox As PdfCheckBoxWidgetFieldWidget = TryCast(field, PdfCheckBoxWidgetFieldWidget)
					'Set export value for checkbox
					checkbox.SetExportValue("True" & (count))
					count += 1
				End If
			Next field
			'Save the pdf file
			pdf.SaveToFile(result, FileFormat.PDF)
			'Show the result file
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
