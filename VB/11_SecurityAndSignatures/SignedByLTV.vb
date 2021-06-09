Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks
Imports Spire.Pdf
Imports Spire.Pdf.Security
Imports System.Security.Cryptography.X509Certificates
Imports Spire.Pdf.Graphics

Namespace SignedByLTV
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim inputFile As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			'Load a PDF document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(inputFile)

			'Get the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Load a certificate .pfx file
			Dim pfxPath As String = "..\..\..\..\..\..\Data\ComodoSSL.pfx"
			Dim cer As New PdfCertificate(pfxPath, "08100601",X509KeyStorageFlags.Exportable)

			'Add a signature to the specified position
			Dim signature As New PdfSignature(doc, page, cer, "signature")
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(180, 90))

			'set the signature content
			signature.NameLabel = "Digitally signed by:Gary"
			signature.LocationInfoLabel = "Location:"
			signature.LocationInfo = "CN"
			signature.ReasonLabel = "Reason: "
			signature.Reason = "Ensure authenticity"
			signature.ContactInfoLabel = "Contact Number: "
			signature.ContactInfo = "028-81705109"
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail
			signature.SignImageSource = PdfImage.FromFile("..\..\..\..\..\..\Data\logo.png")

			'Configure OCSP which must conform to RFC 2560
			signature.ConfigureHttpOCSP(Nothing, Nothing)

			'Save the PDF file
			Dim outputFile As String = "result.pdf"
			doc.SaveToFile(outputFile, FileFormat.PDF)

			'Launch the file
			PDFDocumentViewer(outputFile)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
