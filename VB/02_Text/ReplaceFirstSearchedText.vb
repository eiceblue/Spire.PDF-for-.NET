Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Texts

Namespace ReplaceFirstSearchedText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the path to the input PDF file
            Dim input As String = "..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"

            ' Create a new PdfDocument instance
            Dim doc As New PdfDocument()

            ' Load the input PDF file
            doc.LoadFromFile(input)

            ' Get the first page of the PDF document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a PdfTextFinder instance to find text on the page
            Dim finder As New PdfTextFinder(page)

            ' Set the find options to ignore case
            finder.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase

            ' Find the specified text on the page
            Dim finds As List(Of PdfTextFragment) = finder.Find("Spire.PDF for .NET")

            ' Define the new replacement text
            Dim newText As String = "Spire.PDF API"

            ' Get the first found text fragment
            Dim find As PdfTextFragment = finds(0)

            ' Define a brush for text color
            Dim brush As PdfBrush = New PdfSolidBrush(Color.DarkBlue)

            ' Define a font for the new text
            Dim font As New PdfTrueTypeFont(New Font("Arial", 15.0F, FontStyle.Bold))
            ' =============================================================================
            ' Use the following code for netstandard dlls
            ' =============================================================================
            ' Dim font As New PdfTrueTypeFont("Arial", 18,FontStyle.Bold, True)
            ' =============================================================================

            ' Get the bounding rectangle of the first found text
            Dim rec As RectangleF = find.Bounds(0)

            ' Draw a white rectangle to cover the found text
            page.Canvas.DrawRectangle(PdfBrushes.White, rec)

            ' Draw the new text in the rectangle with the defined font and color
            page.Canvas.DrawString(newText, font, brush, rec)

            ' Alternatively, you can use the ApplyRecoverString method to directly replace the old text with newText,
            ' but it only sets the background color and cannot set the font or foreground color.
            ' find.ApplyRecoverString(newText, Color.Gray);

            ' Specify the output file name
            Dim result As String = "ReplaceFirstSearchedText_out.pdf"

            ' Save the modified document to a file
            doc.SaveToFile(result)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
