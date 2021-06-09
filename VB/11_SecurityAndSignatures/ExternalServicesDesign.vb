Imports System.Security.Cryptography.X509Certificates
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Namespace ExternalServicesDesign
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"
			Dim output As String = "externalServicesDesign.pdf"

			'Load Pdf document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Load certificate
			Dim cert As New X509Certificate2("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

			'Create CustomPKCS7SignatureFormatter 
			Dim customPKCS7SignatureFormatter As New CustomPKCS7SignatureFormatter(cert)
			Dim signature As New PdfSignature(doc, doc.Pages(0), customPKCS7SignatureFormatter, "signature0")
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(270, 90))
			signature.GraphicsMode = GraphicMode.SignDetail
			signature.NameLabel = "Signer:"
			signature.Name = "Test"
			signature.Reason = "The certificate of this document"
			signature.DistinguishedNameLabel = "DN: "
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges
			Dim font As New PdfTrueTypeFont(New Font("Arial", 15f))
			signature.SignDetailsFont = font
			signature.SignNameFont = font
			signature.SignImageLayout = SignImageLayout.None

			'Save pdf file.
			doc.SaveToFile(output, Spire.Pdf.FileFormat.PDF)

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
