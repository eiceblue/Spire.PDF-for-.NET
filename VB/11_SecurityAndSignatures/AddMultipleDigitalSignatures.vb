Imports System.Security.Cryptography.X509Certificates
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.DigitalSignatures

Namespace AddMultipleDigitalSignatures
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new instance of PdfDocument
			Dim document As New PdfDocument()

			' Load the PDF document from the specified file path
			document.LoadFromFile("..\..\..\..\..\..\Data\AddMultipleSignatures.pdf")

			' Create a new X509Certificate2 object using the PFX certificate file and password
			Dim x509 As New X509Certificate2("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

			' Create a PdfOrdinarySignatureMaker object for the document with the X509 certificate
			Dim signatureMaker As New PdfOrdinarySignatureMaker(document, x509)

			' Create a new PdfSignatureAppearance object for the signature
			Dim signatureAppearance As New PdfSignatureAppearance(signatureMaker.Signature)

			' Set the labels for the signature appearance
			signatureAppearance.NameLabel = "Signer:"
			signatureAppearance.ContactInfoLabel = "ContactInfo:"
			signatureAppearance.LocationLabel = "Location:"
			signatureAppearance.ReasonLabel = "Reason:"

			' Configure the first signature
			Dim signature1 As PdfSignature = signatureMaker.Signature
			signature1.Name = "Tom"
			signature1.ContactInfo = "Tom Tang"
			signature1.Location = "China"
			signature1.Reason = "protect document data"

			' Make the first signature on the specified page at the given position with the provided appearance
			signatureMaker.MakeSignature("Signature1", document.Pages(0), 100, 300, 120, 70, signatureAppearance)

			' Configure the second signature
			Dim signature2 As PdfSignature = signatureMaker.Signature
			signature2.Name = "Bob"
			signature2.ContactInfo = "Bob Li"
			signature2.Location = "China"
			signature2.Reason = "protect document data"

			' Make the second signature on the specified page at the given position with the same appearance
			signatureMaker.MakeSignature("Signature2", document.Pages(0), 400, 300, 120, 70, signatureAppearance)

			' Specify the output file path for the modified PDF document
			Dim outpdf As String = "AddMultipleSignatures_result.pdf"

			' Save the modified PDF document to the specified output file path
			document.SaveToFile(outpdf, FileFormat.PDF)

			' Close the PDF document
			document.Close()

			' Launch the file
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
