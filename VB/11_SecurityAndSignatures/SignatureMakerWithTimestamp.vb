Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.DigitalSignatures
Imports System.Security.Cryptography.X509Certificates

Namespace SignatureMakerWithTimestamp
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Load the input pfx file path
			Dim inputFile_pfx As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Set the output file name and path
			Dim output As String = "SignatureMakerWithTimestamp_output.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Append a new page to the document
			doc.AppendPage()

			' Load the X509 certificate from the specified pfx file path with the provided password
			Dim x509 As New X509Certificate2(inputFile_pfx, "e-iceblue")

			' Create a new PdfPKCS7Formatter object with the certificate and disable timestamping
			Dim formatter As New PdfPKCS7Formatter(x509, False)

			' Set the timestamp service for the formatter using the TSAHttpService
			formatter.TimestampService = New TSAHttpService("http://time.certum.pl")

			' Create a new PdfOrdinarySignatureMaker object with the document and formatter
			Dim signatureMaker As New PdfOrdinarySignatureMaker(doc, formatter)

			' Create a new instance of IPdfSignatureAppearance as PdfCustomSignatureAppearance
			Dim signatureAppearance As IPdfSignatureAppearance = New PdfCustomSignatureAppearance()

			' Make the signature on the specified page of the document at the given coordinates with the provided appearance
			signatureMaker.MakeSignature("sign", doc.Pages(0), 100, 100, 100, 100, signatureAppearance)

			' Save the PDF document with the signature to the output file path
			doc.SaveToFile(output, FileFormat.PDF)

			' Close the PDF document
			doc.Close()

			PDFDocumentViewer(output)
		End Sub
		Public Class PdfCustomSignatureAppearance
			Implements IPdfSignatureAppearance
			Public Sub Generate(ByVal g As PdfCanvas) Implements IPdfSignatureAppearance.Generate
				Dim fontSize As Single = 10
				' Create a TrueType font with Arial font family and font size 10
				Dim font As New PdfTrueTypeFont(New Font("Arial", fontSize), True)

				' Draw string
				g.DrawString("E-iceblue", font, PdfBrushes.Red, New PointF(0, 0))
			End Sub
		End Class

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
