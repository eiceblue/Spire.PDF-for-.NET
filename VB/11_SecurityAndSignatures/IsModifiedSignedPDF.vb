Imports Spire.Pdf.Security
Imports Spire.Pdf.Widget
Imports Spire.Pdf

Namespace IsModifiedSignedPDF
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of OpenFileDialog
            Dim dialog As New OpenFileDialog()

            ' Set the filter to only allow selection of PDF documents
            dialog.Filter = "PDF document (*.pdf)|*.pdf"

            ' Show the dialog and store the result
            Dim result As DialogResult = dialog.ShowDialog()

            ' Check if the user selected a file
            If result = DialogResult.OK Then
                Try
                    ' Get the selected PDF file path
                    Dim pdfFile As String = dialog.FileName

                    ' Create a list to store the signatures
                    Dim signatures As New List(Of PdfSignature)()

                    ' Open the PDF document and retrieve all its signatures
                    Using pdf As New PdfDocument()
                        pdf.LoadFromFile(pdfFile)

                        ' Get the form widget of the document
                        Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)

                        ' Iterate through each field in the form
                        For i As Integer = 0 To form.FieldsWidget.Count - 1
                            Dim field As PdfSignatureFieldWidget = TryCast(form.FieldsWidget(i), PdfSignatureFieldWidget)
                            If field IsNot Nothing AndAlso field.Signature IsNot Nothing Then
                                ' Find a signature and add it to the list
                                Dim signature As PdfSignature = field.Signature
                                signatures.Add(signature)
                            End If
                        Next i

                        ' Get the first signature from the list
                        Dim signatureOne As PdfSignature = signatures(0)

                        ' Detect if the PDF document was modified
                        Dim modified As Boolean = signatureOne.VerifyDocModified()

                        ' Display a message indicating whether the document was modified or not
                        If modified Then
                            MessageBox.Show("The document was modified")
                        Else
                            MessageBox.Show("The document was not modified")
                        End If
                    End Using
                Catch exe As Exception
                    ' Display an error message in case of an exception
                    MessageBox.Show(exe.Message, "Spire.Pdf Demo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub
	End Class
End Namespace