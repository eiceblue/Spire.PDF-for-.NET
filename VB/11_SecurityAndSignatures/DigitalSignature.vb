Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Namespace DigitalSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Specify the path of the input PDF file to be signed
			Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			' Create a new instance of PdfDocument
			Dim doc As New PdfDocument()

			' Load the input PDF document
			doc.LoadFromFile(input)

			' Specify the path of the PFX certificate file and its password
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue")

			' Create a new signature field on the first page of the document
			Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature0")

			' Define the bounds (position and size) of the signature field
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(270, 90))

			' Set the image source for the signature appearance
			signature.SignImageSource = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")

			' Set the graphics mode for display
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail

			' Set the label and value for the signer's name
			signature.NameLabel = "Signer:"
			signature.Name = "Gary"

			' Set the label and value for the contact information
			signature.ContactInfoLabel = "ContactInfo:"
			signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, True)

			' Set the label and value for the signing date
			signature.DateLabel = "Date:"
			signature.Date = Date.Now

			' Set the label and value for the location
			signature.LocationInfoLabel = "Location:"
			signature.LocationInfo = "Chengdu"

			' Set the label and value for the reason
			signature.ReasonLabel = "Reason: "
			signature.Reason = "The certificate of this document"

			' Set the label and value for the distinguished name
			signature.DistinguishedNameLabel = "DN: "
			signature.DistinguishedName = signature.Certificate.IssuerName.Name

			' Set the permissions for the signed document
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges

			' Enable certification for the digital signature
			signature.Certificated = True

			' Set custom fonts for the signature appearance
			signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10.0F)
			signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

			' Set the layout mode for the sign image
			signature.SignImageLayout = SignImageLayout.None

			' Save the modified PDF document
			doc.SaveToFile("DigitalSignature.pdf")

			' Close the document
			doc.Close()

			'Launch the file
			PDFDocumentViewer("DigitalSignature.pdf")
		End Sub


		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
