Imports Spire.Pdf
Imports Spire.Pdf.Interactive.DigitalSignatures
Imports Spire.Pdf.Security

Namespace AddValidityCheckMarkToSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Define the path to the PFX file
			Dim pfxPath As String = "..\..\..\..\..\..\Data\gary.pfx"

			' Define the path to the input PDF file
			Dim inputPdf As String = "..\..\..\..\..\..\Data\AddValidityCheckMarkToSignature.pdf"

			' Define the path for the output PDF file
			Dim outputPdf As String = "AddValidityCheckMarkToSignature_result.pdf"

			' Create a new PDF document
			Dim pdf As New PdfDocument()

			' Load the PDF file from disk
			pdf.LoadFromFile(inputPdf)

			' Create a certificate object using the specified PFX file and password
			Dim cert As New PdfCertificate(pfxPath, "e-iceblue")

			' Create a PdfOrdinarySignatureMaker object with the loaded PDF document and the certificate
			Dim signatureMaker As New PdfOrdinarySignatureMaker(pdf, cert)

			' Set Acro6 layers to False
			signatureMaker.SetAcro6Layers(False)

			' Create a signature using the specified name, page index, and coordinates
			signatureMaker.MakeSignature("signName", pdf.Pages(0), 100, 100, 120, 160)

			' Save the modified PDF document to the specified output path in PDF format
			pdf.SaveToFile(outputPdf, FileFormat.PDF)

			' Close the PDF document
			pdf.Close()

			'Open the pdf file
			FileViewer(outputPdf)
		End Sub
		Private Sub FileViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
