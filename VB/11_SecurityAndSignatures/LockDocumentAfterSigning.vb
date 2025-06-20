Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Namespace LockDocumentAfterSigning
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Load the input file path
			Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file path
			doc.LoadFromFile(input)

			' Load the certificate from the specified pfx file path
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue")

			' Create a new PdfSignature object with the document, first page, certificate, and signature name
			Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature0")

			' Set the bounds of the signature field on the page
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(270, 90))

			' Load the sign image source
			signature.SignImageSource = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")

			' Set the graphics mode for display
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail

			' Set the label for the signer's name
			signature.NameLabel = "Signer:"

			' Set the signer's name
			signature.Name = "Gary"

			' Set the label for the contact information
			signature.ContactInfoLabel = "ContactInfo:"

			' Get the contact information from the certificate and set it
			signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, True)

			' Set the label for the date
			signature.DateLabel = "Date:"

			' Set the current date as the signing date
			signature.Date = Date.Now

			' Set the label for the location
			signature.LocationInfoLabel = "Location:"

			' Set the location information
			signature.LocationInfo = "Chengdu"

			' Set the label for the reason
			signature.ReasonLabel = "Reason: "

			' Set the reason for signing
			signature.Reason = "The certificate of this document"

			' Set the label for the distinguished name
			signature.DistinguishedNameLabel = "DN: "

			' Get the issuer's name from the certificate and set it as the distinguished name
			signature.DistinguishedName = signature.Certificate.IssuerName.Name

			' Set the document permissions for the certification
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges

			' Set the font for the sign details
			signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10.0F)

			' Set the font for the sign name
			signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

			' Set the sign image layout mode
			signature.SignImageLayout = SignImageLayout.None

			' Lock the document after signing
			signature.Lock = True

			' Save the PDF document with the digital signature
			doc.SaveToFile("DigitalSignature.pdf")

			' Close the PDF document
			doc.Close()

			' Launch the file
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
