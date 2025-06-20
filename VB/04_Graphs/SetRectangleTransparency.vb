Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace SetRectangleTransparency
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the specified file path
            pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawingTemplate.pdf")

            ' Get the first page of the document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Save the current graphics state of the page's canvas
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Define the coordinates, width, and height for the rectangles to be drawn
            Dim x As Integer = 200
            Dim y As Integer = 300
            Dim width As Integer = 200
            Dim height As Integer = 100

            ' Create a PdfPen object with black color and thickness of 1f
            Dim pen As New PdfPen(Color.Black, 1.0F)

            ' Create a PdfBrush object with red color
            Dim brush As PdfBrush = New PdfSolidBrush(Color.Red)

            ' Create a new PdfBlendMode object
            Dim mode As New PdfBlendMode()

            ' Set the transparency of the page's canvas using the defined blend mode
            page.Canvas.SetTransparency(0.5F, 0.5F, mode)

            ' Draw a rectangle on the page's canvas with the specified pen, brush, and dimensions
            page.Canvas.DrawRectangle(pen, brush, New Rectangle(New Point(x, y), New Size(width, height)))

            ' Update the coordinates for the next rectangle
            x = x + width \ 2
            y = y - height \ 2

            ' Set a different transparency for the page's canvas using the same blend mode
            page.Canvas.SetTransparency(0.2F, 0.2F, mode)

            ' Draw another rectangle on the page's canvas with the updated coordinates and same pen, brush, and dimensions
            page.Canvas.DrawRectangle(pen, brush, New Rectangle(New Point(x, y), New Size(width, height)))

            ' Restore the previously saved graphics state of the page's canvas
            page.Canvas.Restore(state)

            ' Save the modified document
            Dim result As String = "SetRectangleTransparency_out.pdf"
            pdf.SaveToFile(result)

            ' Close the document
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
