Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget

Namespace ShowOrHideField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified file
            pdf.LoadFromFile("..\..\..\..\..\..\Data\FormField.pdf")

            ' Iterate through each page of the PDF document
            For c As Integer = 0 To pdf.Pages.Count - 1

                ' Access the form widget of the PDF document
                Dim formWidget As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

                ' Iterate through each field in the form
                For i As Integer = 0 To formWidget.FieldsWidget.List.Count - 1
                    Dim field As PdfField = TryCast(formWidget.FieldsWidget.List(i), PdfField)

                    ' Check if the field is a textbox field
                    If TypeOf field Is PdfTextBoxFieldWidget Then
                        Dim widget As PdfTextBoxFieldWidget = TryCast(field, PdfTextBoxFieldWidget)

                        ' Create a hide action to hide the field on mouse down event
                        Dim hideAction As New PdfHideAction(widget.Name, True)

                        ' Assign the hide action to the mouse down event of the textbox field
                        widget.MouseDown = hideAction
                    End If
                Next i
            Next c

            ' Specify the output file path
            Dim output As String = "ShowOrHideField.pdf"

            ' Save the modified PDF document to the output file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

            ' Launch the Pdf file
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
