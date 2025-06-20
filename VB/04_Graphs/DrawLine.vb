Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawLine
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load an existing PDF file from the specified path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawingTemplate.pdf")

            ' Get the first page of the PDF document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Save the current graphics state
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Define the coordinates and dimensions for the rectangle and lines
            Dim x As Single = 95
            Dim y As Single = 95
            Dim width As Single = 400
            Dim height As Single = 500

            ' Create a pen with black color and thickness of 0.1 points
            Dim pen As New PdfPen(Color.Black, 0.1F)

            ' Create another pen with red color and thickness of 0.1 points
            Dim pen1 As New PdfPen(Color.Red, 0.1F)

            ' Draw a rectangle on the page using the specified pen, coordinates, and dimensions
            page.Canvas.DrawRectangle(pen, x, y, width, height)

            ' Draw a diagonal line from the top-left corner to the bottom-right corner of the rectangle
            page.Canvas.DrawLine(pen1, x, y, x + width, y + height)

            ' Draw a diagonal line from the top-right corner to the bottom-left corner of the rectangle
            page.Canvas.DrawLine(pen1, x + width, y, x, y + height)

            ' Restore the previous graphics state
            page.Canvas.Restore(state)

            ' Set the output file name for the modified PDF
            Dim result As String = "DrawLine_out.pdf"

            ' Save the modified PDF document to the specified path
            pdf.SaveToFile(result)

            ' Close the PDF document
            pdf.Close()

            ' Launch the Pdf file
            PDFDocumentViewer(result)
        End Sub
        Private Sub PDFDocumentViewer(ByVal filename As String)
            Try
                Process.Start(filename)
            Catch
            End Try
        End Sub

    End Class
End Namespace
