Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Graphics

Namespace AddTextStamp
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Specify the file path for the input PDF document
            Dim input As String = "..\\..\\..\\..\\..\\..\\Data\\AddTextStamp.pdf"

            ' Create a new instance of PdfDocument
            Dim document As PdfDocument = New PdfDocument()

            ' Load the PDF document from the specified file path
            document.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = document.Pages[0]

            ' Create a template with specific dimensions to hold the stamp
            Dim template As PdfTemplate = New PdfTemplate(125, 55)

            ' Set the font, brush, and pen for drawing the stamp
            Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Elephant", 10f, FontStyle.Italic), True)
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
             Dim font1 As PdfTrueTypeFont = New PdfTrueTypeFont("Elephant", 10f, PdfFontStyle.Italic, True)
            */
            Dim brush As PdfSolidBrush = New PdfSolidBrush(Color.DarkRed)
            Dim pen As PdfPen = New PdfPen(brush)

            ' Define a rectangle that represents the bounds of the stamp
            Dim rectangle As RectangleF = New RectangleF(New PointF(5, 5), template.Size)

            ' Define the corner radius for the stamp's rounded corners
            Dim CornerRadius As Integer = 20

            ' Create a path for the stamp shape using arcs and lines
            Dim path As PdfPath = New PdfPath()
            path.AddArc(template.GetBounds().X, template.GetBounds().Y, CornerRadius, CornerRadius, 180, 90)
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y, CornerRadius, CornerRadius, 270, 90)
            path.AddArc(template.GetBounds().X + template.Width - CornerRadius, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90)
            path.AddArc(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90)
            path.AddLine(template.GetBounds().X, template.GetBounds().Y + template.Height - CornerRadius, template.GetBounds().X, template.GetBounds().Y + CornerRadius / 2)

            ' Draw the stamp shape on the template
            template.Graphics.DrawPath(pen, path)

            ' Draw the stamp text on the template
            Dim s1 As String = "REVISED\n"
            Dim s2 As String = "by E-iceblue at " + DateTime.Now.ToString("MM dd, yyyy")
            template.Graphics.DrawString(s1, font1, brush, New PointF(5, 10))
            Dim font2 As PdfTrueTypeFont = New PdfTrueTypeFont(New Font("Lucida Sans Unicode", 9f, FontStyle.Bold), True)
            '''///////////////Use the following code for netstandard dlls/////////////////////////
            /*
              Dim font2 As PdfTrueTypeFont = New PdfTrueTypeFont("Lucida Sans Unicod", 9f, PdfFontStyle.Bold, True)
            */
            template.Graphics.DrawString(s2, font2, brush, New PointF(2, 30))

            'Create a rubber stamp
            Dim stamp As PdfRubberStampAnnotation = New PdfRubberStampAnnotation(page, rectangle)
            stamp.Appearances.SetNormalAppearance(New PdfAppearance(template))

            'Draw stamp into page
            PdfAnnotationCollection.Create(page).Add(stamp)

            ' Specify the file name for the modified PDF document
            Dim output As String = "AddTextStamp.pdf"

            ' Save the modified PDF document
            document.SaveToFile(output)

            'Launch the file
            PDFDocumentViewer(output)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
