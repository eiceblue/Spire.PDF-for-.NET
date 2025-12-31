Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace PageNumberInFooter
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load a multipage PDF file from a specified path
            doc.LoadFromFile("../../../../../../../Data/MultipagePDF.pdf")

            ' Get the margins of the document's page settings
            Dim margin As PdfMargins = doc.PageSettings.Margins

            ' Call a function to draw page numbers on each page of the document
            DrawPageNumber(doc, margin, 1, doc.Pages.Count)

            ' Specify the output file name
            Dim result As String = "PageNumberStamp_out.pdf"

            ' Save the modified document to the specified file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub DrawPageNumber(ByVal doc As PdfDocument, ByVal margin As PdfMargins, ByVal startNumber As Integer, ByVal pageCount As Integer)
            ' Iterate through each page of the document
            For Each page As PdfPageBase In doc.Pages
                ' Set the transparency of the page's canvas to 0.5
                page.Canvas.SetTransparency(0.5F)

                ' Create a black brush and a pen with specified properties
                Dim brush As PdfBrush = PdfBrushes.Black
                Dim pen As New PdfPen(brush, 0.75F)

                ' Create a TrueType font with Arial, 12pt size, and italic style
                Dim font As New PdfTrueTypeFont(New Font("Arial", 12.0F, FontStyle.Italic), True)
                ' =============================================================================
                ' Use the following code for netstandard dlls
                ' =============================================================================
                'Dim font As New PdfTrueTypeFont("Arial", 12.0F, FontStyle.Italic, True)
                ' =============================================================================

                ' Create a string format with right alignment and trailing spaces measurement
                Dim format As New PdfStringFormat(PdfTextAlignment.Right)
                format.MeasureTrailingSpaces = True

                ' Calculate the space between lines based on the font height
                Dim space As Single = font.Height * 0.75F

                ' Set the initial position for drawing the line and text
                Dim x As Single = margin.Left
                Dim width As Single = page.Canvas.ClientSize.Width - margin.Left - margin.Right
                Dim y As Single = page.Canvas.ClientSize.Height - margin.Bottom + space

                ' Draw a line at the bottom of the page
                page.Canvas.DrawLine(pen, x, y, x + width, y)

                ' Increase the y-coordinate by 1 to make space for the text
                y = y + 1

                ' Create the label for the page number using the startNumber and pageCount variables
                Dim numberLabel As String = String.Format("{0} of {1}", startNumber, pageCount)

                ' Increment the startNumber variable
                startNumber += 1

                ' Draw the page number label on the page canvas
                page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format)

                ' Set the transparency of the page's canvas back to 1
                page.Canvas.SetTransparency(1)
            Next page
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
