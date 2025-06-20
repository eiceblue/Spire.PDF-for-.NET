Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace CreatePolylineAnnotation
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

            ' Create a polyline annotation with specified points on the page
            Dim polyline As New PdfPolyLineAnnotation(page, New PointF() {New PointF(0, 60), New PointF(30, 45), New PointF(60, 90), New PointF(90, 80)})

            ' Set the color of the polyline annotation to PaleVioletRed
            polyline.Color = Color.PaleVioletRed

            ' Set the text content of the polyline annotation
            polyline.Text = "This is a polygon annotation"

            ' Set the author name of the polyline annotation
            polyline.Author = "E-ICEBLUE"

            ' Set the subject of the polyline annotation
            polyline.Subject = "polygon annotation demo"

            ' Set the name of the polyline annotation
            polyline.Name = "Test Annotation"

            ' Set the border of the polyline annotation with a width of 1f
            polyline.Border = New PdfAnnotationBorder(1.0F)

            ' Set the modified date of the polyline annotation to current date and time
            polyline.ModifiedDate = Date.Now

            ' Add the polyline annotation to the page's annotation collection
            page.Annotations.Add(polyline)

            ' Specify the output file name for the PDF document
            Dim output As String = "CreatePolylineAnnotation_result.pdf"

            ' Save the PDF document to the specified output file in PDF format
            pdf.SaveToFile(output, FileFormat.PDF)

            ' Close the PDF document
            pdf.Close()

            ' Launch the Pdf file
            FileViewer(output)
        End Sub
        Private Sub FileViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
