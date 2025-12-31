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
            ' Load the input file path
            Dim input As String = "..\..\..\..\..\..\Data\DigitalSignature.pdf"

            ' Set the output file name
            Dim output As String = "addSelfDefineSignaturePic.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the input file path
            doc.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a new PdfCertificate object with the certificate file path and password
            Dim cert As New PdfCertificate("..\..\..\..\..\..\Data\gary.pfx", "e-iceblue")

            ' Create a new PdfSignature object with the document, page, certificate, and signature name
            Dim signature As New PdfSignature(doc, page, cert, "demo")

            ' Set the bounds for the signature appearance on the page
            signature.Bounds = New RectangleF(50, 600, 200, 200)

            ' Configure custom graphics for the signature appearance using the DrawGraphics method
            signature.ConfigureCustomGraphics(AddressOf DrawGraphics)

            ' Save the modified document to the output file path in PDF format
            doc.SaveToFile(output, FileFormat.PDF)

            ' Close the PDF document
            doc.Close()

            ' Launch the document
            PDFDocumentViewer(output)
        End Sub
        Private Sub DrawGraphics(ByVal g As PdfCanvas)
            ' Create a new PdfTrueTypeFont object using the Arial font with a size of 18 points
            Dim font As New PdfTrueTypeFont(New Font("Arial", 18.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            'Dim font As New PdfTrueTypeFont("Arial", 18.0F, FontStyle.Regular, True)
            ' =============================================================================

            ' Specify the text to be drawn
            Dim text As String = "Signature information"

            ' Determine the height of the text using the font's MeasureString method
            Dim heightY As Single = font.MeasureString(text).Height

            ' Define the starting point for drawing the text as (0, 0)
            Dim point1 As New PointF(0, 0)

            ' Draw the specified text using the font, red color, and starting point
            g.DrawString(text, font, PdfBrushes.Red, point1)

            ' Define the starting point for drawing the image just below the drawn text
            Dim point2 As New PointF(0, heightY + 10)

            ' Draw the image from the specified file using the starting point
            g.DrawImage(PdfImage.FromFile("..\..\..\..\..\..\Data\E-iceblueLogo.png"), point2)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
