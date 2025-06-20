Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports Spire.Pdf.Widget
Imports System.Security.Cryptography.X509Certificates
Imports System.IO

Namespace ExtractSignatureCertificate
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument
            Dim doc As New PdfDocument()

            ' Load a PDF file from the specified path
            doc.LoadFromFile("../../../../../../Data/ExtractSignatureInfo.pdf")

            ' Create a list to store the signatures
            Dim signatures As New List(Of PdfSignature)()

            ' Get the form widget of the document
            Dim form = CType(doc.Form, PdfFormWidget)

            ' Iterate through each field in the form
            For i As Integer = 0 To form.FieldsWidget.Count - 1
                Dim field = TryCast(form.FieldsWidget(i), PdfSignatureFieldWidget)

                ' Check if the field is a signature field and has a signature
                If field IsNot Nothing AndAlso field.Signature IsNot Nothing Then
                    ' Find a signature and add it to the list
                    Dim signature As PdfSignature = field.Signature
                    signatures.Add(signature)
                End If
            Next i

            ' Get the first signature from the list
            Dim signatureOne As PdfSignature = signatures(0)

            ' Get the certificates associated with the first signature
            Dim collection As X509Certificate2Collection = signatureOne.Certificates

            ' Process each certificate in the collection
            For Each certificate In collection
                ' Export the certificate as bytes
                Dim cerByte() As Byte = certificate.Export(X509ContentType.Cert)

                ' Create a file stream to write the certificate data to a file
                Using fileStream As New FileStream("Export.cer", FileMode.Create)
                    ' Write the certificate data to the file
                    For i As Integer = 0 To cerByte.Length - 1
                        fileStream.WriteByte(cerByte(i))
                    Next i
                    fileStream.Seek(0, SeekOrigin.Begin)

                    ' Read and verify the written data
                    For i As Integer = 0 To fileStream.Length - 1
                        If cerByte(i) <> fileStream.ReadByte() Then
                            fileStream.Close()
                        End If
                    Next i
                End Using
            Next certificate

            ' Display a message indicating success
            MessageBox.Show("Succeed!")

            ' Close the PDF document
            doc.Close()
        End Sub
	End Class
End Namespace
