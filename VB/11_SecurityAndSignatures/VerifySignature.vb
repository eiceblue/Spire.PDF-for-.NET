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
            ' Create a list to store PdfSignature objects.
            Dim signatures As New List(Of PdfSignature)()

            ' Create a new PdfDocument object.
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified file.
            pdf.LoadFromFile("..\..\..\..\..\..\Data\VerifySignature.pdf")

            ' Get the form widget from the document.
            Dim form = CType(pdf.Form, PdfFormWidget)

            ' Iterate through each field in the form.
            For i As Integer = 0 To form.FieldsWidget.Count - 1
                ' Check if the field is a signature field and has a signature.
                Dim field = TryCast(form.FieldsWidget(i), PdfSignatureFieldWidget)
                If field IsNot Nothing AndAlso field.Signature IsNot Nothing Then
                    ' Add the signature to the list.
                    Dim signature As PdfSignature = field.Signature
                    signatures.Add(signature)
                End If
            Next i

            ' Get the first signature from the list.
            Dim signatureOne As PdfSignature = signatures(0)

            ' Verify the signature.
            Dim valid As Boolean = signatureOne.VerifySignature()

            ' Display a message box indicating the result of the signature verification.
            If valid Then
                MessageBox.Show("The signature is valid")
            Else
                MessageBox.Show("The signature is invalid")
            End If

            ' Close the PDF document
            pdf.Close()
        End Sub
    End Class
End Namespace
