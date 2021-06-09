Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget

Namespace DigitalSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			 'Load a pdf document
			Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"
			Dim doc As New PdfDocument()
		doc.LoadFromFile(input)
			'Load the certificate
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue")

			Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature0")
			signature.Bounds = New RectangleF(New PointF(90,550), New SizeF(270, 90))

			'Load sign image source.
			signature.SignImageSource = PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png")

			'Set the dispay mode of graphics, if not set any, the default one will be applied
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail
			signature.NameLabel = "Signer:"

			signature.Name = "Gary"

			signature.ContactInfoLabel = "ContactInfo:"
			signature.ContactInfo = signature.Certificate.GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, True)

			signature.DateLabel = "Date:"
			signature.Date = Date.Now

			signature.LocationInfoLabel = "Location:"
			signature.LocationInfo = "Chengdu"

			signature.ReasonLabel = "Reason: "
			signature.Reason = "The certificate of this document"

			signature.DistinguishedNameLabel = "DN: "
			signature.DistinguishedName = signature.Certificate.IssuerName.Name

			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges
			signature.Certificated = True

			'Set fonts. if not set, default ones will be applied. 
			signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10f)
			signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

			'Set the sign image layout mode
			signature.SignImageLayout = SignImageLayout.None

			'Save pdf file.
			doc.SaveToFile("DigitalSignature.pdf")
			doc.Close()

			'Launch the file.
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
