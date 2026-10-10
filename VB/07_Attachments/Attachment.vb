Imports System
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Attachments
Imports Spire.Pdf.Graphics

Namespace Attachment
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a pdf document
            Dim doc As PdfDocument = New PdfDocument()

            ' Load the PDF document from a file
            doc.LoadFromFile(@"..\..\..\..\..\..\Data\Attachment.pdf")

            ' Get the first page of the PDF document
            Dim page As PdfPageBase = doc.Pages[0]

            ' Set the initial y-coordinate for positioning elements on the page
            Dim y As Single = 320

            ' Add a title to the page
            Dim brush1 As PdfBrush = PdfBrushes.CornflowerBlue
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 18f, FontStyle.Bold))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 18f, PdfFontStyle.Bold, True)
            */
            Dim format1 As PdfStringFormat = New PdfStringFormat(PdfTextAlignment.Center)
            page.Canvas.DrawString("Attachment", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1)

            ' Update the y-coordinate
            y = y + font1.MeasureString("Attachment", format1).Height
            y = y + 10

            ' Add an attachment to the PDF document
            Dim attachment As PdfAttachment = New PdfAttachment("Header.png")
            attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Header.png")
            attachment.Description = "Page header picture of demo."
            attachment.MimeType = "image/png"
            doc.Attachments.Add(attachment)

            ' Add another attachment to the PDF document
            attachment = New PdfAttachment("Footer.png")
            attachment.Data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Footer.png")
            attachment.Description = "Page footer picture of demo."
            attachment.MimeType = "image/png"
            doc.Attachments.Add(attachment)

            ' Set the initial x-coordinate and font for the labels
            Dim x As Single = 50
            Dim font2 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Arial", 14f, FontStyle.Bold))
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
              Dim font2 As PdfTrueTypeFont = New PdfTrueTypeFont("Arial", 14f, PdfFontStyle.Bold, True)
            */

            ' Add a label and annotation for the Sales Report Chart attachment
            Dim location As PointF = New PointF(x, y)
            Dim label As String = "Sales Report Chart"
            Dim data As Byte[] = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SalesReportChart.png")
            Dim size As SizeF = font2.MeasureString(label)
            Dim bounds As RectangleF = New RectangleF(location, size)
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)

            'Create a PdfAttachmentAnnotation 
            Dim fileSpecification As PdfFileSpecification = New PdfFileSpecification("SalesReportChart.png", data)
            Dim annotation1 As PdfFileAttachmentAnnotation
                = New PdfFileAttachmentAnnotation(page, bounds, fileSpecification)

            annotation1.Color = Color.Teal
            annotation1.Flags = PdfAnnotationFlags.ReadOnly
            annotation1.Icon = PdfFileIcon.Graph
            annotation1.Contents = "Sales Report Chart"
            'Add the annotation1
            PdfAnnotationCollection.Create(page).Add(annotation1)
            y = y + size.Height + 3

            location = New PointF(x, y)
            label = "Science Personification Boston"
            data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\SciencePersonificationBoston.jpg")
            size = font2.MeasureString(label)
            bounds = New RectangleF(location, size)
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)

            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)

            Dim fileSpecification2 As PdfFileSpecification = New PdfFileSpecification("SciencePersonificationBoston.jpg", data)
            Dim annotation2 As PdfFileAttachmentAnnotation
                = New PdfFileAttachmentAnnotation(page, bounds, fileSpecification2)
            annotation2.Color = Color.Orange
            annotation2.Flags = PdfAnnotationFlags.NoZoom
            annotation2.Icon = PdfFileIcon.PushPin
            annotation2.Contents = "SciencePersonificationBoston.jpg, from Wikipedia, the free encyclopedia"
            PdfAnnotationCollection.Create(page).Add(annotation2)
            y = y + size.Height + 2

            location = New PointF(x, y)
            label = "Picture of Science"
            data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\Wikipedia_Science.png")
            size = font2.MeasureString(label)
            bounds = New RectangleF(location, size)
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)
            Dim fileSpecification3 As PdfFileSpecification = New PdfFileSpecification("Wikipedia_Science.png", data)
            Dim annotation3 As PdfFileAttachmentAnnotation
                = New PdfFileAttachmentAnnotation(page, bounds, fileSpecification3)
            annotation3.Color = Color.SaddleBrown
            annotation3.Flags = PdfAnnotationFlags.Locked
            annotation3.Icon = PdfFileIcon.Tag
            annotation3.Contents = "Wikipedia_Science.png, from Wikipedia, the free encyclopedia"
            PdfAnnotationCollection.Create(page).Add(annotation3)
            y = y + size.Height + 2

            location = New PointF(x, y)
            label = "Hawaii Killer Font"
            data = File.ReadAllBytes(@"..\..\..\..\..\..\Data\PT_Serif-Caption-Web-Regular.ttf")
            size = font2.MeasureString(label)
            bounds = New RectangleF(location, size)
            page.Canvas.DrawString(label, font2, PdfBrushes.DarkOrange, bounds)
            bounds = New RectangleF(bounds.Right + 3, bounds.Top, font2.Height / 2, font2.Height)
            Dim fileSpecification4 As PdfFileSpecification = New PdfFileSpecification("PT_Serif-Caption-Web-Regular.ttf", data)
            Dim annotation4 As PdfFileAttachmentAnnotation
                = New PdfFileAttachmentAnnotation(page, bounds, fileSpecification4)
            annotation4.Color = Color.CadetBlue
            annotation4.Flags = PdfAnnotationFlags.NoRotate
            annotation4.Icon = PdfFileIcon.Paperclip
            annotation4.Contents = "PT Serif Caption Font, from http://www.1001freefonts.com"
            PdfAnnotationCollection.Create(page).Add(annotation4)
            y = y + size.Height + 2

            ' Save the PDF document
            doc.SaveToFile("Attachment.pdf")

            ' Close the PDF document
            doc.Close()

            'Launch the Pdf file
            PDFDocumentViewer("Attachment.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

    End Class
End Namespace
