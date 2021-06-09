Imports System.ComponentModel
Imports System.Text
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
			Dim dialog As New OpenFileDialog()
			dialog.Filter = "PDF document (*.pdf)|*.pdf"
			Dim result As DialogResult = dialog.ShowDialog()
			If result = DialogResult.OK Then
				Try
					Dim pdfFile As String = dialog.FileName

					Dim signatures As New List(Of PdfSignature)()

					'Open a pdf document and get its all signatures
					Using pdf As New PdfDocument()
			pdf.LoadFromFile(pdfFile)
						Dim form As PdfFormWidget = TryCast(pdf.Form, PdfFormWidget)
						For i As Integer = 0 To form.FieldsWidget.Count - 1
							Dim field As PdfSignatureFieldWidget = TryCast(form.FieldsWidget(i), PdfSignatureFieldWidget)
							If field IsNot Nothing AndAlso field.Signature IsNot Nothing Then
								Dim signature As PdfSignature = field.Signature
								signatures.Add(signature)
							End If
						Next i

						'Get the first signature
						Dim signatureOne As PdfSignature = signatures(0)

						'Detect if the pdf document was modified
						Dim modified As Boolean = signatureOne.VerifyDocModified()

						If modified Then
							MessageBox.Show("The document was modified")
						Else
							MessageBox.Show("The document was not modified")
						End If
					End Using
				Catch exe As Exception
					MessageBox.Show(exe.Message, "Spire.Pdf Demo", MessageBoxButtons.OK, MessageBoxIcon.Error)
				End Try
			End If
		End Sub
	End Class
End Namespace