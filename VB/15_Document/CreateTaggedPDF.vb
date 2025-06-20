Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Interchange.TaggedPdf

Namespace CreateTaggedPDF
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Add a page to the document
            doc.Pages.Add()

            ' Set the tab order for the first page
            doc.Pages(0).SetTabOrder(TabOrder.Structure)

            ' Create a new PdfTaggedContent object
            Dim taggedContent As New PdfTaggedContent(doc)

            ' Set the language of the tagged content
            taggedContent.SetLanguage("en-US")

            ' Set the title of the tagged content
            taggedContent.SetTitle("test")

            ' Set the PDF/UA-1 identification for accessibility
            taggedContent.SetPdfUA1Identification()

            ' Create a new PdfTrueTypeFont object with Times New Roman font
            Dim font As New PdfTrueTypeFont(New Font("Times New Roman", 10), True)

            ' Create a new PdfSolidBrush object with black color
            Dim brush As New PdfSolidBrush(Color.Black)

            ' Create a PdfStructureElement object of type Document
            Dim article As PdfStructureElement = taggedContent.StructureTreeRoot.AppendChildElement(PdfStandardStructTypes.Document)

            ' Create a PdfStructureElement object of type Paragraph
            Dim paragraph1 As PdfStructureElement = article.AppendChildElement(PdfStandardStructTypes.Paragraph)

            ' Create a PdfStructureElement object of type Span
            Dim span1 As PdfStructureElement = paragraph1.AppendChildElement(PdfStandardStructTypes.Span)

            ' Begin a marked content block for the span on the first page
            span1.BeginMarkedContent(doc.Pages(0))

            ' Create a new PdfStringFormat object with justified alignment
            Dim format As New PdfStringFormat(PdfTextAlignment.Justify)

            ' Draw a string on the first page's canvas with specified font, brush, rectangle, and format
            doc.Pages(0).Canvas.DrawString("Spire.PDF for .NET is a professional PDF API applied to creating, writing, editing, handling and reading PDF files.", font, brush, New Rectangle(40, 0, 480, 80), format)

            ' End the marked content block for the span on the first page
            span1.EndMarkedContent(doc.Pages(0))

            ' Create a PdfStructureElement object of type Paragraph
            Dim paragraph2 As PdfStructureElement = article.AppendChildElement(PdfStandardStructTypes.Paragraph)

            ' Begin a marked content block for the paragraph on the first page
            paragraph2.BeginMarkedContent(doc.Pages(0))

            ' Draw a string on the first page's canvas with specified font, brush, rectangle, and format
            doc.Pages(0).Canvas.DrawString("Spire.PDF for .NET can be applied to easily convert Text, Image, SVG, HTML to PDF and convert PDF to Excel with C#/VB.NET in high quality.", font, brush, New Rectangle(40, 80, 480, 60), format)

            ' End the marked content block for the paragraph on the first page
            paragraph2.EndMarkedContent(doc.Pages(0))

            ' Create a PdfStructureElement object of type Figure
            Dim figure1 As PdfStructureElement = article.AppendChildElement(PdfStandardStructTypes.Figure)

            ' Set the alternative text for figure1
            figure1.Alt = "replacement text1"

            ' Begin a marked content block for figure1 on the first page
            figure1.BeginMarkedContent(doc.Pages(0), Nothing)

            ' Load an image from file
            Dim image As PdfImage = PdfImage.FromFile("..\..\..\..\..\..\Data\E-logo.png")

            ' Draw the image on the first page's canvas at specified position and size
            doc.Pages(0).Canvas.DrawImage(image, New PointF(40, 200), New SizeF(100, 100))

            ' End the marked content block for figure1 on the first page
            figure1.EndMarkedContent(doc.Pages(0))

            ' Create a PdfStructureElement object of type Figure
            Dim figure2 As PdfStructureElement = article.AppendChildElement(PdfStandardStructTypes.Figure)

            ' Set the alternative text for figure2
            figure2.Alt = "replacement text2"

            ' Begin a marked content block for figure2 on the first page
            figure2.BeginMarkedContent(doc.Pages(0), Nothing)

            ' Draw a rectangle on the first page's canvas with black pen and specified rectangle
            doc.Pages(0).Canvas.DrawRectangle(PdfPens.Black, New Rectangle(300, 200, 100, 100))

            ' End the marked content block for figure2 on the first page
            figure2.EndMarkedContent(doc.Pages(0))

            ' Specify the output file name
            Dim result As String = "CreateTaggedFile_result.pdf"

            ' Save the document to the specified file
            doc.SaveToFile(result)

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
