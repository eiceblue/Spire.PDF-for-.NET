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
			' Specify the input PDF file path
			Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			' Specify the output file path for the modified PDF document
			Dim output As String = "externalServicesDesign.pdf"

			' Load a PDF document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			' Load the certificate for digital signature
			Dim cert As New X509Certificate2("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

			' Create a custom PKCS7 signature formatter using the certificate
			Dim customPKCS7SignatureFormatter As New CustomPKCS7SignatureFormatter(cert)

			' Create a new PdfSignature object on the first page of the document with the custom signature formatter
			Dim signature As New PdfSignature(doc, doc.Pages(0), customPKCS7SignatureFormatter, "signature0")

			' Set the bounds (position and size) of the signature field
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(270, 90))

			' Set the graphics mode for display
			signature.GraphicsMode = GraphicMode.SignDetail

			' Set the label and value for the signer's name
			signature.NameLabel = "Signer:"
			signature.Name = "Test"

			' Set the reason for signing
			signature.Reason = "The certificate of this document"

			' Set the label and value for the distinguished name
			signature.DistinguishedNameLabel = "DN: "

			' Set the document permissions for certification
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges

			' Set the font for sign details and sign name
			Dim font As New PdfTrueTypeFont(New Font("Arial", 15.0F))
			signature.SignDetailsFont = font
			signature.SignNameFont = font

			' Set the sign image layout mode
			signature.SignImageLayout = SignImageLayout.None

			' Save the modified PDF document to the specified output file path in PDF format
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

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
