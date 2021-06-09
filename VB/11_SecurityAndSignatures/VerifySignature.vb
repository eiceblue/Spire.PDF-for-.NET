Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports Spire.Pdf.Widget

Namespace VerifySignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			Dim signatures As New List(Of PdfSignature)()

			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\VerifySignature.pdf")

			Dim form = CType(pdf.Form, PdfFormWidget)
			For i As Integer = 0 To form.FieldsWidget.Count - 1
				Dim field = TryCast(form.FieldsWidget(i), PdfSignatureFieldWidget)
				If field IsNot Nothing AndAlso field.Signature IsNot Nothing Then
					Dim signature As PdfSignature = field.Signature
					signatures.Add(signature)
				End If
			Next i

			'Get the first signature
			Dim signatureOne As PdfSignature = signatures(0)

			'Verify signature
			Dim valid As Boolean = signatureOne.VerifySignature()
			If valid Then
				MessageBox.Show("The signature is valid")
			Else
				MessageBox.Show("The signature is invalid")
			End If
		End Sub
	End Class
End Namespace
