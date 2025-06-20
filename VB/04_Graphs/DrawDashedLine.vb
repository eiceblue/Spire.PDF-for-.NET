Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace DrawDashedLine
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PDF document
            Dim pdf As New PdfDocument()

            ' Load an existing PDF from a file
            pdf.LoadFromFile("..\..\..\..\..\..\Data\DrawingTemplate.pdf")

            ' Get the first page of the loaded PDF
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Save the current graphics state of the page's canvas
            Dim state As PdfGraphicsState = page.Canvas.Save()

            ' Set the starting point (x, y) and width for the dashed line
            Dim x As Single = 150
            Dim y As Single = 200
            Dim width As Single = 300

            ' Create a pen with color red and thickness 3f
            Dim pen As New PdfPen(Color.Red, 3.0F)

            ' Set the dash style of the pen to Dash
            pen.DashStyle = PdfDashStyle.Dash

            ' Set the dash pattern for the pen
            pen.DashPattern = New Single() {1, 4, 1}

            ' Draw a dashed line on the page using the pen, starting from (x, y) and extending to (x + width, y)
            page.Canvas.DrawLine(pen, x, y, x + width, y)

            ' Restore the graphics state of the page's canvas
            page.Canvas.Restore(state)

            ' Specify the output file name
            Dim result As String = "DrawDashedLine_out.pdf"

            ' Save the modified PDF document to the output file
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
