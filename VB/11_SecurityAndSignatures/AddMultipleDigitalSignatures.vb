Imports System.Security.Cryptography.X509Certificates
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.DigitalSignatures

Namespace AddMultipleDigitalSignatures
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create PDF document
			Dim document As New PdfDocument()

			'Load the PDF document 
			document.LoadFromFile("..\..\..\..\..\..\Data\AddMultipleSignatures.pdf")

			'Create X509Certificate2
			Dim x509 As New X509Certificate2("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")


			'Create PdfOrdinarySignatureMaker
			Dim signatureMaker As New PdfOrdinarySignatureMaker(document, x509)

			'Set signature appearance
			Dim signatureAppearance As New PdfSignatureAppearance(signatureMaker.Signature)
			signatureAppearance.NameLabel = "Signer:"
			signatureAppearance.ContactInfoLabel = "ContactInfo:"
			signatureAppearance.LocationLabel = "Location:"
			signatureAppearance.ReasonLabel = "Reason:"

			'Set details for the signature1
			Dim signature1 As PdfSignature = signatureMaker.Signature
			signature1.Name = "Tom"
			signature1.ContactInfo = "Tom Tang"
			signature1.Location = "China"
			signature1.Reason = "protect document data"

			'Add the first signature 
			signatureMaker.MakeSignature("Signature1", document.Pages(0), 100, 300, 120, 70, signatureAppearance)


			'Set details for the signature2
			Dim signature2 As PdfSignature = signatureMaker.Signature
			signature2.Name = "Bob"
			signature2.ContactInfo = "Bob Li"
			signature2.Location = "China"
			signature2.Reason = "protect document data"

			'Add the second signature
			signatureMaker.MakeSignature("Signature2", document.Pages(0), 400, 300, 120, 70, signatureAppearance)

			'Save the PDF document
			Dim outpdf As String = "AddMultipleSignatures_result.pdf"
			document.SaveToFile(outpdf, FileFormat.PDF)

			PDFDocumentViewer(outpdf)
		End Sub
		Private Shared Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
