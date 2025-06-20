Imports Spire.Pdf
Imports Spire.Pdf.ColorSpace
Imports Spire.Pdf.Graphics

Namespace DrawRectangles
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

            ' Create one page
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Save the current graphics state
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Set the location and size of the rectangle
            Dim x As Integer = 130
            Dim y As Integer = 100
            Dim width As Integer = 300
            Dim height As Integer = 400

            ' Create a pen with black color and thickness of 0.1 points
            Dim pen As New PdfPen(Color.Black, 0.1F)

            ' Draw a rectangle on the page using the specified pen and rectangle parameters
            page.Canvas.DrawRectangle(pen, New Rectangle(New Point(x, y), New Size(width, height)))

            ' Adjust the position and dimensions of the next rectangle
            y = y + height - 50
            width = 100
            height = 50

            ' Initialize an instance of PdfSeparationColorSpace with a custom color
            Dim cs As New PdfSeparationColorSpace("MyColor", Color.FromArgb(0, 100, 0, 0))

            ' Create a pen with red color and thickness of 1 point
            Dim pen1 As New PdfPen(Color.Red, 1.0F)

            ' Create a brush with a spot color
            Dim brush As PdfBrush = New PdfSolidBrush(New PdfSeparationColor(cs, 0.1F))

            ' Draw a rectangle on the page using the specified pen, brush, and rectangle parameters
            page.Canvas.DrawRectangle(pen1, brush, New Rectangle(New Point(x, y), New Size(width, height)))

            ' Restore the previous graphics state
            page.Canvas.Restore(state)

            ' Specify the output file name for the modified PDF
            Dim result As String = "DrawRectangles_out.pdf"

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
