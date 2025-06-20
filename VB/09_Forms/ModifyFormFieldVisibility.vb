Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Annotations

Namespace ModifyFormFieldVisibility
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the input file path
			Dim input As String = "..\..\..\..\..\..\Data\FormField.pdf"

			' Create a new instance of the PdfDocument class
			Dim pdf As New PdfDocument()

			' Load the PDF document from the specified input file
			pdf.LoadFromFile(input)

			' Get the form widget from the loaded PDF document
			Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

			' Get the first field from the form widget
			Dim field As PdfField = TryCast(form.FieldsWidget.List(0), Spire.Pdf.Fields.PdfField)

			' Set the annotation flags for the field to default
			field.AnnotationFlags = PdfAnnotationFlags.Default

			' Alternatively, you can set the annotation flags to hidden
			'field.AnnotationFlags = Spire.Pdf.Annotations.PdfAnnotationFlags.Hidden; 

			' Specify the output file name for the modified PDF document
			Dim result As String = "ModifyFormFieldVisibility_out.pdf"

			' Save the modified PDF document to the specified output file
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			' Launch the Pdf file
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
