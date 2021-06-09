Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Widget
Imports Spire.Pdf.Security
Imports Spire.Pdf.Graphics

Namespace SignInSignatureField
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load PDF document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile("../../../../../../Data/SignatureField.pdf")

			Dim widgets As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

			For i As Integer = 0 To widgets.FieldsWidget.List.Count - 1
				Dim widget As PdfFieldWidget = TryCast(widgets.FieldsWidget.List(i), PdfFieldWidget)
				If TypeOf widget Is PdfSignatureFieldWidget Then
					'Get the field name
					Dim name As String = widget.Name
					Dim signWidget As PdfSignatureFieldWidget = TryCast(widget, PdfSignatureFieldWidget)

					'Sign with certificate selection in the windows certificate store
					Dim store As New System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser)
					store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly)

					'Manually chose the certificate in the store
					Dim sel As System.Security.Cryptography.X509Certificates.X509Certificate2Collection = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(store.Certificates, Nothing, Nothing, System.Security.Cryptography.X509Certificates.X509SelectionFlag.SingleSelection)

					'Create a certificate using the certificate data from the store
					Dim cert As New PdfCertificate(sel(0).RawData)

					'Create a signature using the signature field
					Dim signature As New PdfSignature(doc, signWidget.Page, cert, name, signWidget)

					'Load sign image source
					signature.SignImageSource = PdfImage.FromFile("../../../../../../Data/E-iceblueLogo.png")

					'Set the dispay mode of graphics, if not set any, the default one will be applied
					signature.GraphicsMode = GraphicMode.SignImageAndSignDetail
					signature.NameLabel = "Signer:"

					signature.Name = sel(0).GetNameInfo(System.Security.Cryptography.X509Certificates.X509NameType.SimpleName, True)

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
				End If
			Next i

			'Save the Pdf document
			Dim output As String = "SignWithSmartCardUsingSignatureField_out.pdf"
			doc.SaveToFile(output)

			'Launch the result file
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
