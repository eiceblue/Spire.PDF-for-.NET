Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Security
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Widget

Namespace DigitalSignature
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'Create a pdf document.
            Dim doc As New PdfDocument()

            ' Create one page
            Dim page As PdfPageBase = doc.Pages.Add()

            'Draw the page
            DrawPage(page)

            Dim pfxPath As String = "..\..\..\..\..\..\Data\Demo.pfx"
            Dim cert As New PdfCertificate(pfxPath, "e-iceblue")

            'signature fully 
            Dim signature As New PdfSignature(doc, page, cert, "signature0")
            'invisible signature
            'signature.Bounds = new RectangleF(new PointF(20, 350), new SizeF(200, 100))
            'display signature picture
            'signature.ConfiguerGraphicPath =  @"\signature.jpg"
            'signature.ConfigGraphicType = ConfiguerGraphicType.Picture
            'display signature text
            signature.IsTag = True
            signature.DigitalSignerLable = "Firmado Por:"
            signature.DigitalSigner = "Alex Alvarado"
            signature.ContactInfo = "Harry"
            signature.Date = DateTime.Now

            signature.Certificated = True
            signature.DocumentPermissions = PdfCertificationFlags.AllowFormFill Or PdfCertificationFlags.ForbidChanges

            'create empty signature field
            Dim signature1Field As New PdfSignatureField(page, "signature1")
            signature1Field.Bounds = New RectangleF(New PointF(300, 350), New SizeF(200, 100))
            signature1Field.BorderWidth = 1.0F
            signature1Field.BorderStyle = PdfBorderStyle.Solid
            signature1Field.BorderColor = New PdfRGBColor(System.Drawing.Color.Black)
            signature1Field.HighlightMode = PdfHighlightMode.Outline
            'display picture
            'signature1Field.DrawImage(new PdfBitmap(m_DataDirectory + @"\SpirePdf-815.jpg"), 0, 0)
            doc.Form.Fields.Add(signature1Field)

            'Save pdf file.
            doc.SaveToFile("DigitalSignature.pdf")
            doc.Close()

            ' ---------------------------------------------------------------------------------------

            doc = New PdfDocument("DigitalSignature.pdf")

            'signature empty signature field
            Dim form As PdfFormWidget = TryCast(doc.Form,PdfFormWidget)
            Dim signature1FieldWidget As PdfSignatureFieldWidget = TryCast(form.FieldsWidget("signature1"), PdfSignatureFieldWidget)
            Dim signature1 As New PdfSignature(doc, signature1FieldWidget.Page, cert, signature1FieldWidget.Name, signature1FieldWidget)
            signature1.IsTag = True
            signature1.DigitalSignerLable = "Firmado Por:"
            signature1.DigitalSigner = "Alex Alvarado"
            signature1.ContactInfo = "Harry"
            signature1.Date = DateTime.Now

            'Save pdf file.
            doc.SaveToFile("DigitalSignature.pdf")
            doc.Close()

            'Launching the Pdf file.
            PDFDocumentViewer("DigitalSignature.pdf")
        End Sub

        Private Sub DrawPage(ByVal page As PdfPageBase)
            Dim pageWidth As Single = page.Canvas.ClientSize.Width
            Dim y As Single = 0

            'page header
            Dim pen1 As New PdfPen(Color.LightGray, 1.0F)
            Dim brush1 As PdfBrush = New PdfSolidBrush(Color.LightGray)
            Dim font1 As New PdfTrueTypeFont(New Font("Arial", 8.0F, FontStyle.Italic))
            Dim format1 As New PdfStringFormat(PdfTextAlignment.Right)
            Dim text As String = "Demo of Spire.Pdf"
            page.Canvas.DrawString(text, font1, brush1, pageWidth, y, format1)
            Dim size As SizeF = font1.MeasureString(text, format1)
            y = y + size.Height + 1
            page.Canvas.DrawLine(pen1, 0, y, pageWidth, y)

            'title
            y = y + 5
            Dim brush2 As PdfBrush = New PdfSolidBrush(Color.Black)
            Dim font2 As New PdfTrueTypeFont(New Font("Arial", 16.0F, FontStyle.Bold))
            Dim format2 As New PdfStringFormat(PdfTextAlignment.Center)
            format2.CharacterSpacing = 1.0F
            text = "Summary of Science"
            page.Canvas.DrawString(text, font2, brush2, pageWidth / 2, y, format2)
            size = font2.MeasureString(text, format2)
            y = y + size.Height + 6

            'icon
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\Wikipedia_Science.png")
            page.Canvas.DrawImage(image, New PointF(pageWidth - image.PhysicalDimension.Width, y))
            Dim imageLeftSpace As Single = pageWidth - image.PhysicalDimension.Width - 2
            Dim imageBottom As Single = image.PhysicalDimension.Height + y

            'refenrence content
            Dim font3 As New PdfTrueTypeFont(New Font("Arial", 9.0F))
            Dim format3 As New PdfStringFormat()
            format3.ParagraphIndent = font3.Size * 2
            format3.MeasureTrailingSpaces = True
            format3.LineSpacing = font3.Size * 1.5F
            Dim text1 As String = "(All text and picture from "
            Dim text2 As String = "Wikipedia"
            Dim text3 As String = ", the free encyclopedia)"
            page.Canvas.DrawString(text1, font3, brush2, 0, y, format3)

            size = font3.MeasureString(text1, format3)
            Dim x1 As Single = size.Width
            format3.ParagraphIndent = 0
            Dim font4 As New PdfTrueTypeFont(New Font("Arial", 9.0F, FontStyle.Underline))
            Dim brush3 As PdfBrush = PdfBrushes.Blue
            page.Canvas.DrawString(text2, font4, brush3, x1, y, format3)
            size = font4.MeasureString(text2, format3)
            x1 = x1 + size.Width

            page.Canvas.DrawString(text3, font3, brush2, x1, y, format3)
            y = y + size.Height

            'content
            Dim format4 As New PdfStringFormat()
            text = System.IO.File.ReadAllText("..\..\..\..\..\..\Data\Summary_of_Science.txt")
            Dim font5 As New PdfTrueTypeFont(New Font("Arial", 10.0F))
            format4.LineSpacing = font5.Size * 1.5F
            Dim textLayouter As New PdfStringLayouter()
            Dim imageLeftBlockHeight As Single = imageBottom - y
            Dim result As PdfStringLayoutResult = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
            If result.ActualSize.Height < imageBottom - y Then
                imageLeftBlockHeight = imageLeftBlockHeight + result.LineHeight
                result = textLayouter.Layout(text, font5, format4, New SizeF(imageLeftSpace, imageLeftBlockHeight))
            End If
            For Each line As LineInfo In result.Lines
                page.Canvas.DrawString(line.Text, font5, brush2, 0, y, format4)
                y = y + result.LineHeight
            Next line
            Dim textWidget As New PdfTextWidget(result.Remainder, font5, brush2)
            Dim textLayout As New PdfTextLayout()
            textLayout.Break = PdfLayoutBreakType.FitPage
            textLayout.Layout = PdfLayoutType.Paginate
            Dim bounds As New RectangleF(New PointF(0, y), page.Canvas.ClientSize)
            textWidget.StringFormat = format4
            textWidget.Draw(page, bounds, textLayout)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
