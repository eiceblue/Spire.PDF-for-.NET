Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace FillStrokeText
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified file path
            doc.LoadFromFile("../../../../../../Data/PDFTemplate_N.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Create a new PdfPen object with gray color
            Dim pen As New PdfPen(Color.Gray)

            ' Save the current graphics state of the page's canvas
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Rotate the canvas by -20 degrees
            page.Canvas.RotateTransform(-20)

            ' Create a new PdfStringFormat object
            Dim format As New PdfStringFormat()

            ' Set the character spacing to 5
            format.CharacterSpacing = 5.0F

            ' Draw a string "E-ICEBLUE" on the canvas using specified font, pen, position, and format
            page.Canvas.DrawString("E-ICEBLUE", New PdfFont(PdfFontFamily.Helvetica, 45.0F), pen, 0, 500.0F, format)

            ' Restore the graphics state of the canvas to its previous state
            page.Canvas.Restore(state)

            ' Define the output file path
            Dim output As String = "FillStrokeText_out.pdf"

            ' Save the modified document to the output file
            doc.SaveToFile(output)

            ' Close the document
            doc.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(output)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
