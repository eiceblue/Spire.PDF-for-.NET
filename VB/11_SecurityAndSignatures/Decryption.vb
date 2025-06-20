Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security


Namespace Decryption
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Define the path to the encrypted PDF file
			Dim encryptedPdf As String = "..\..\..\..\..\..\Data\Decryption.pdf"

			' Create a new PdfDocument object
			Dim doc As New PdfDocument()

			' Load the encrypted PDF file and provide the password "test" for decryption
			doc.LoadFromFile(encryptedPdf, "test")

			' Decrypt the PDF document
			doc.Decrypt()

			' Save the decrypted PDF document
			doc.SaveToFile("Decryption.pdf", FileFormat.PDF)

			' Close the PdfDocument object
			doc.Close()

			' Launch the file
			DocumentViewer("Decryption.pdf")
		End Sub

		Private Sub DocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
