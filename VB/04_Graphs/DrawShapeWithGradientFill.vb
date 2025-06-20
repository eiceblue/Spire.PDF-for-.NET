Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawShapeWithGradientFill
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a new page to the document
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Create a linear gradient brush with colors BlueViolet and DarkBlue, and horizontal gradient mode
            Dim brush1 As New PdfLinearGradientBrush(New Rectangle(New Point(100, 100), New Size(200, 120)), Color.BlueViolet, Color.DarkBlue, PdfLinearGradientMode.Horizontal)

            ' Draw a rectangle on the page using the gradient brush
            page.Canvas.DrawRectangle(brush1, New Rectangle(New Point(100, 100), New Size(200, 120)))

            ' Create a radial gradient brush with colors SkyBlue and DarkBlue, and specified focal points and radii
            Dim brush2 As New PdfRadialGradientBrush(New PointF(200.0F, 400.0F), 100.0F, New PointF(300.0F, 500.0F), 100.0F, Color.SkyBlue, Color.DarkBlue)

            ' Draw an ellipse on the page using the gradient brush
            page.Canvas.DrawEllipse(brush2, New Rectangle(New Point(100, 300), New Size(200, 200)))

            ' Save the document to a file named "DrawShapeWithGradientFill_out.pdf" in PDF format
            Dim result As String = "DrawShapeWithGradientFill_out.pdf"
            doc.SaveToFile(result, FileFormat.PDF)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
