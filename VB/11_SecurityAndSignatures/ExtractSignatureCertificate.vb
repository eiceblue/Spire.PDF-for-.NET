Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports Spire.Pdf.Widget
Imports System.ComponentModel
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO

Namespace ExtractSignatureCertificate
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load PDF document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/ExtractSignatureInfo.pdf")
			Dim signatures As New List(Of PdfSignature)()
			Dim form = CType(doc.Form, PdfFormWidget)
			For i As Integer = 0 To form.FieldsWidget.Count - 1
				Dim field = TryCast(form.FieldsWidget(i), PdfSignatureFieldWidget)

				If field IsNot Nothing AndAlso field.Signature IsNot Nothing Then
					'Find signature and add in a list
					Dim signature As PdfSignature = field.Signature
					signatures.Add(signature)
				End If
			Next i

			'Get the first signature
			Dim signatureOne As PdfSignature = signatures(0)
			Dim collection As X509Certificate2Collection = signatureOne.Certificates
			For Each certificate In collection
				Dim cerByte() As Byte = certificate.Export(X509ContentType.Cert)
				Using fileStream As New FileStream("Export.cer", FileMode.Create)
					'Write the data to the file
					For i As Integer = 0 To cerByte.Length - 1
						fileStream.WriteByte(cerByte(i))
					Next i
					fileStream.Seek(0, SeekOrigin.Begin)

					'Read and verify the data   
					For i As Integer = 0 To fileStream.Length - 1
						If cerByte(i) <> fileStream.ReadByte() Then
							fileStream.Close()
						End If
					Next i
				End Using
			Next certificate
			MessageBox.Show("Succeed!")
		End Sub
	End Class
End Namespace
