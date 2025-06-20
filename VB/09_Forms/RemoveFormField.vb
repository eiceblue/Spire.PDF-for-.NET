Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Fields
Namespace RemoveFormField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\RemoveFormField.pdf"

            ' Create a new instance of PdfDocument
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified input file
            pdf.LoadFromFile(input)

            ' Access the form widget of the PDF document
            Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

            If formWidget IsNot Nothing Then
                ' Iterate through each field in the form
                For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1

                    ' Case 1: Remove the first form field
                    If i = 0 Then
                        Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

                        ' Remove the field from the form widget
                        formWidget.FieldsWidget.Remove(field)

                        ' Exit the loop since the first field has been removed
                        Exit For
                    End If
                Next i

                ' Clear all fields in the form widget
                ' formWidget.FieldsWidget.Clear()
            End If

            ' Specify the output file path
            Dim output As String = "RemoveFormField_result.pdf"

            ' Save the modified PDF document to the output file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

            ' Launch the Pdf files
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
