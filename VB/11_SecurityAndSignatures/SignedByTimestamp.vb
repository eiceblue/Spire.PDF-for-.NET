Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security
Imports System.ComponentModel
Imports System.Text
Imports System.Threading.Tasks

Namespace SignedByTimestamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim inputFile As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			'load a PDF document
			Dim doc As New PdfDocument()
			doc.LoadFromFile(inputFile)

			'Load a certificate .pfx file
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue", System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable)

			'Add a signature to the specified position
			Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature")
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(180, 90))

			'Set the signature content
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

			'Configure a timestamp server
			Dim url As String = "https://freetsa.org/tsr"
			signature.ConfigureTimestamp(url)

			'Save to file
			Dim output As String = "result.pdf"
			doc.SaveToFile(output, FileFormat.PDF)

			'Launch the file
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
