Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security

Namespace CustomSignature
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"
			Dim output As String = "addSelfDefineSignaturePic.pdf"

			'Load document from disk
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Create the first page
			Dim page As PdfPageBase = doc.Pages(0)

			'Load the certificate
			Dim cert As New PdfCertificate("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

			'Define signatrure
			Dim signature As New PdfSignature(doc, page, cert, "demo")
			signature.Bounds = New RectangleF(50, 600, 200, 200)

			'Custom signature area
			signature.ConfigureCustomGraphics(AddressOf DrawGraphics)

			'Save the document
			doc.SaveToFile(output, FileFormat.PDF)
			PDFDocumentViewer(output)
		End Sub
		Private Sub DrawGraphics(ByVal g As PdfCanvas)
			Dim font As New PdfTrueTypeFont(New Font("Arial", 18f))
			Dim text As String = "Signature information"
			Dim heightY As Single = font.MeasureString(text).Height
			Dim point1 As New PointF(0, 0)
			'Draw string
			g.DrawString(text, font, PdfBrushes.Red, point1)
			Dim point2 As New PointF(0, heightY+10)
			'Draw image
			g.DrawImage(PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png"),point2)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
