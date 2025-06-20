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
			' Load the input file path
			Dim inputFile As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file path
			doc.LoadFromFile(inputFile)

			' Get the first page of the document
			Dim page As PdfPageBase = doc.Pages(0)

			' Set the path of the certificate .pfx file
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Load the certificate from the pfx file with the specified password and exportable flag
			Dim cer As New PdfCertificate(pfxPath, "e-iceblue", X509KeyStorageFlags.Exportable)

			' Add a signature to the specified position on the page
			Dim signature As New PdfSignature(doc, page, cer, "signature")
			signature.Bounds = New RectangleF(New PointF(90, 550), New SizeF(180, 90))

			' Set the content of the signature
			signature.NameLabel = "Digitally signed by: Gary"
			signature.LocationInfoLabel = "Location:"
			signature.LocationInfo = "CN"
			signature.ReasonLabel = "Reason: "
			signature.Reason = "Ensure authenticity"
			signature.ContactInfoLabel = "Contact Number: "
			signature.ContactInfo = "028-81705109"
			signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges
			signature.GraphicsMode = GraphicMode.SignImageAndSignDetail
			signature.SignImageSource = PdfImage.FromFile("..\..\..\..\..\..\Data\logo.png")

			' Configure OCSP (Online Certificate Status Protocol) for the signature
			signature.ConfigureHttpOCSP(Nothing, Nothing)

			' Save the PDF document with the signature to the output file path
			Dim outputFile As String = "result.pdf"
			doc.SaveToFile(outputFile, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

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
