Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports Spire.Pdf.Graphics

Namespace SignWithSmartCard
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			'Load PDF document from disk
			Dim input As String = "../../../../../../Data/PDFTemplate_HF.pdf"
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Sign with certificate selection in the windows certificate store
			Dim store As New System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser)
			store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly)

			'Manually chose the certificate in the store
			Dim sel As System.Security.Cryptography.X509Certificates.X509Certificate2Collection = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(store.Certificates, Nothing, Nothing, System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection)

			'Create a certificate using the certificate data from the store
			Dim cert As New PdfCertificate(sel(0).RawData)

			Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature0")
			signature.Bounds = New RectangleF(New PointF(250, 660), New SizeF(250, 90))

			'Load sign image source.
			signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

			'Set the dispay mode of graphics, if not set any, the default one will be applied
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail
			signature.NameLabel = "Signer:"

			signature.Name = sel(0).GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName,True)

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

			'Set fonts, if not set, default ones will be applied
			signature.SignDetailsFont = New PdfFont(PdfFontFamily.TimesRoman, 10f)
			signature.SignNameFont = New PdfFont(PdfFontFamily.Courier, 15)

			'Set the sign image layout mode
			signature.SignImageLayout = SignImageLayout.None

			'Save the PDF file
			Dim output As String = "SignWithSmartCardUsingPdfFileSignature_out.pdf"
			doc.SaveToFile(output)
			doc.Close()

			'Launch the Pdf file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
