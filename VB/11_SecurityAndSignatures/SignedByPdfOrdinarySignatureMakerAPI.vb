Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.DigitalSignatures
Imports Spire.Pdf.Security

Namespace SignedByPdfOrdinarySignatureMakerAPI
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Add a page to the document
			Dim pdfPage As PdfPageBase = pdf.Pages.Add()

			' Load the certificate from the specified pfx file path with the provided password
			Dim cert As New PdfCertificate("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

			' Create a new PdfOrdinarySignatureMaker object with the document and certificate
			Dim signatureMaker As New PdfOrdinarySignatureMaker(pdf, cert)

			' Set details for the signature
			Dim signature As Spire.Pdf.Interactive.DigitalSignatures.PdfSignature = signatureMaker.Signature
			signature.Name = "E-iceblue"
			signature.ContactInfo = "028-81705109"
			signature.Location = "Chengdu"
			signature.Reason = "The certificate of this document"

			' Create a new instance of PdfSignatureAppearance with the signature
			Dim appearance As New PdfSignatureAppearance(signature)
			appearance.NameLabel = "Signer: "
			appearance.ContactInfoLabel = "ContactInfo: "
			appearance.LocationLabel = "Location: "
			appearance.ReasonLabel = "Reason: "
			appearance.SignatureImage = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")
			appearance.GraphicMode = Interactive.DigitalSignatures.GraphicMode.SignImageAndSignDetail

			' Make the signature on the specified page of the document at the given coordinates with the provided appearance
			signatureMaker.MakeSignature("signName", pdfPage, 100, 600, 200, 100, appearance)

			' Save the document to PDF format using the specified output file path
			Dim result As String = "SignedByPdfOrdinarySignatureMakerAPI_result.pdf"
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
