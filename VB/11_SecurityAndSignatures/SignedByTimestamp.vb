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
			' Specify the input file path
			Dim inputFile As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the PDF document from the input file path
			doc.LoadFromFile(inputFile)

			' Set the path of the certificate .pfx file
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Load the certificate from the pfx file with the specified password and exportable flag
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue", System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable)

			' Add a signature to the specified position on the first page of the document using the loaded certificate
			Dim signature As New PdfSignature(doc, doc.Pages(0), cert, "signature")
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

			' Configure a timestamp server with the specified URL
			Dim url As String = "https://freetsa.org/tsr"
			signature.ConfigureTimestamp(url)

			' Save the document to the specified output file path in PDF format
			Dim output As String = "result.pdf"
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

			' Launch the file
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
