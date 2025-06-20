Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security
Imports Spire.Pdf.Interactive.DigitalSignatures

Namespace SignWithDetailsAndPictureUsingSignatureMaker
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Define the input file path.
			Dim input As String = "..\..\..\..\..\..\Data\SignWithDetailsAndPictureUsingSignatureMaker.pdf"

			' Define the image file path for the signature.
			Dim imagePath As String = "..\..\..\..\..\..\Data\logo.png"

			' Define the output file path for the signed document.
			Dim result As String = "SignWithDetailsAndPictureUsingSignatureMaker_result.pdf"

			' Define the PFX certificate file path.
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Create a new PdfDocument object.
			Dim doc As New PdfDocument()

			' Load the PDF document from the specified input file.
			doc.LoadFromFile(input)

			' Create a certificate object using the specified PFX file and password.
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue")

			' Create a signature maker object using the loaded document and certificate.
			Dim signatureMaker As New PdfOrdinarySignatureMaker(doc, cert)

			' Get the signature object from the signature maker.
			Dim signature As Spire.Pdf.Interactive.DigitalSignatures.PdfSignature = signatureMaker.Signature

			' Set details for the signature.
			signature.Name = "E-iceblue"
			signature.ContactInfo = "028-81705109"
			signature.Location = "Chengdu"
			signature.Reason = "The certificate of this document"

			' Create a signature appearance object using the signature object.
			Dim appearance As New PdfSignatureAppearance(signature)

			' Set labels for the signature details.
			appearance.NameLabel = "Signer: "
			appearance.ContactInfoLabel = "ContactInfo: "
			appearance.LocationLabel = "Location: "
			appearance.ReasonLabel = "Reason: "

			' Set the picture for the signature.
			appearance.SignatureImage = PdfImage.FromFile(imagePath)
			appearance.GraphicMode = Spire.Pdf.Interactive.DigitalSignatures.GraphicMode.SignImageAndSignDetail

			' Make the signature on the specified page of the document at the given coordinates.
			signatureMaker.MakeSignature("signName", doc.Pages(0), 100, 600, 200, 100, appearance)

			' Save the modified document to the specified output file in PDF format.
			doc.SaveToFile(result, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

			'Show the result file
			FileViewer(result)
		End Sub
		Private Sub FileViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
