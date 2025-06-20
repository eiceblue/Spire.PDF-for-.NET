Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace CreatePdfPolygonAnnotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document object
            Dim pdf As New PdfDocument()

            ' Add a new page to the PDF document
            Dim page As PdfPageBase = pdf.Pages.Add()

            ' Create a polygon annotation with specified points on the page
            Dim polygon As New PdfPolygonAnnotation(page, New PointF() {New PointF(0, 30), New PointF(30, 15), New PointF(60, 30), New PointF(45, 50), New PointF(15, 50), New PointF(0, 30)})

            ' Set the color of the polygon annotation to PaleVioletRed
            polygon.Color = Color.PaleVioletRed

            ' Set the text content of the polygon annotation
            polygon.Text = "This is a polygon annotation"

            ' Set the author name of the polygon annotation
            polygon.Author = "E-ICEBLUE"

            ' Set the subject of the polygon annotation
            polygon.Subject = "polygon annotation demo"

            ' Set the border effect of the polygon annotation to BigCloud
            polygon.BorderEffect = PdfBorderEffect.BigCloud

            ' Set the modified date of the polygon annotation to current date and time
            polygon.ModifiedDate = Date.Now

            ' Add the polygon annotation to the page's annotation collection
            page.Annotations.Add(polygon)

            ' Specify the output file name for the PDF document
            Dim result As String = "CreatePdfPolygonAnnotation_out.pdf"

            ' Save the PDF document to the specified file
            pdf.SaveToFile(result)

            ' Close the PDF document
            pdf.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub
    End Class
End Namespace
