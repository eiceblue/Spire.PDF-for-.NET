Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interactive.Annotations

Namespace WatermarkAnnotation
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim doc As PdfDocument = New PdfDocument()

            ' Add a page
            Dim page As PdfPageBase = doc.Pages.Add()

            ' Define a rectangle for the watermark annotation
            Dim rect As RectangleF = New RectangleF(100, 100, 300, 300)

            ' Create a watermark annotation
            Dim annotation As PdfWatermarkAnnotation = New PdfWatermarkAnnotation(page, rect)

            ' Set the annotation properties
            annotation.Color = Color.Red
            annotation.Flags = PdfAnnotationFlags.Print
            annotation.Contents = "Contents"
            annotation.Name = "Name"

            ' Configure the FixedPrint settings
            Dim fixedPrint As PdfFixedPrint = New PdfFixedPrint()
            fixedPrint.HorizontalTranslation = 50
            fixedPrint.VerticalTranslation = 30
            annotation.FixedPrint = fixedPrint

            ' Set the normal appearance of the annotation
            annotation.Appearances.SetNormalAppearance(CreateAppearance(300, 300))

            ' Add the annotation to the page
            PdfAnnotationCollection.Create(page).Add(annotation)

            ' Save the document
            Dim output As String = "WatermarkAnnotation.pdf"
            doc.SaveToFile(output)
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub

        Private Function CreateAppearance(ByVal width As Single, ByVal height As Single) As PdfAppearance
            ' Create a true type font for the watermark text
            Dim font As System.Drawing.Font = New System.Drawing.Font("Arial", 15)
            Dim trueTypeFont As PdfTrueTypeFont = New PdfTrueTypeFont(font, True)

            ' Create a template with the specified size
            Dim template As PdfTemplate = New PdfTemplate(width, height)

            ' Create a tiling brush and draw the watermark text in it
            Dim size As SizeF = New SizeF(100, 100)
            Dim brush As PdfTilingBrush = New PdfTilingBrush(size)

            brush.Graphics.SetTransparency(0.3f)
            brush.Graphics.Save()
            brush.Graphics.TranslateTransform((Single)brush.Size.Width / 2, (Single)brush.Size.Height / 2)
            brush.Graphics.RotateTransform(-45)
            brush.Graphics.DrawString("watermark", trueTypeFont, PdfBrushes.Gray, 0, 0, New PdfStringFormat(PdfTextAlignment.Center))
            brush.Graphics.Restore()
            brush.Graphics.SetTransparency(1)

            ' Fill the template with the tiling brush
            template.Graphics.DrawRectangle(brush, New RectangleF(0, 0, width, height))

            ' Return the appearance built from the template
            Return new PdfAppearance(template)
        End Function

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
