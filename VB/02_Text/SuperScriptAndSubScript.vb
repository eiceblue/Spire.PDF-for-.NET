Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SuperScriptAndSubScript
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

            ' Create a new TrueType font using the Arial font with a size of 20
            Dim font As New PdfTrueTypeFont(New Font("Arial", 20.0F))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            ' Dim font As New PdfTrueTypeFont("Arial", 20.0F, PdfFontStyle.Regular, True)
            ' =============================================================================

            ' Create a new solid brush with black color
            Dim brush As New PdfSolidBrush(Color.Black)

            ' Set the text to be displayed on the page
            Dim text As String = "Spire.PDF for .NET"

            ' Draw the text as superscript on the page using the specified font and brush
            DrawSuperscript(page, text, font, brush)

            ' Draw the text as subscript on the page using the specified font and brush
            DrawSubscript(page, text, font, brush)

            ' Specify the file name for the resulting PDF file
            Dim result As String = "SuperScriptAndSubScriptInPDF_out.pdf"

            ' Save the document to the specified file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub DrawSuperscript(ByVal page As PdfPageBase, ByVal text As String, ByVal font As PdfTrueTypeFont, ByVal brush As PdfSolidBrush)
            ' Define the x-coordinate value as 120.0F
            Dim x As Single = 120.0F

            ' Define the y-coordinate value as 100.0F
            Dim y As Single = 100.0F

            ' Draw the text on the page using the specified font, brush, and position (PointF)
            page.Canvas.DrawString(text, font, brush, New PointF(x, y))

            ' Measure the size of the drawn text using the font
            Dim size As SizeF = font.MeasureString(text)

            ' Increment the x-coordinate value by the width of the drawn text
            x += size.Width

            ' Create a new PdfStringFormat object
            Dim format As New PdfStringFormat()

            ' Set the SubSuperScript property of the format to SuperScript
            format.SubSuperScript = PdfSubSuperScript.SuperScript

            ' Update the text variable with "Superscript"
            text = "Superscript"

            ' Draw the updated text on the page with supercript formatting using the specified font, brush, position (PointF), and format
            page.Canvas.DrawString(text, font, brush, New PointF(x, y), format)
        End Sub

        Private Sub DrawSubscript(ByVal page As PdfPageBase, ByVal text As String, ByVal font As PdfTrueTypeFont, ByVal brush As PdfSolidBrush)
            ' Define x-coordinate value and y-coordinate 
            Dim x As Single = 120.0F
            Dim y As Single = 150.0F

            ' Draw a string on the canvas using the specified text, font, brush, and position
            page.Canvas.DrawString(text, font, brush, New PointF(x, y))

            ' Measure the size of the string using the specified font
            Dim size As SizeF = font.MeasureString(text)

            ' Update the x coordinate by adding the width of the measured string
            x += size.Width

            ' Create a new instance of PdfStringFormat
            Dim format As New PdfStringFormat()

            ' Set the SubSuperScript property of the format to SubScript
            format.SubSuperScript = PdfSubSuperScript.SubScript

            ' Update the value of the text variable to "SubScript"
            text = "SubScript"

            ' Draw another string on the canvas using the updated text, font, brush, position, and format
            page.Canvas.DrawString(text, font, brush, New PointF(x, y), format)
        End Sub
        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
