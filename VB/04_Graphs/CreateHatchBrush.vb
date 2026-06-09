Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace CreateHatchBrush
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new PDF document
            Dim pdf As PdfDocument = New PdfDocument()

            ' Iterate through all available hatch styles in the PdfHatchStyle enumeration
            For Each type As PdfHatchStyle In Enum.GetValues(GetType(PdfHatchStyle))
                ' Add a new page to the document
                Dim page As PdfPageBase = pdf.Pages.Add()

                ' Get the canvas of the page for drawing operations
                Dim canves As PdfCanvas = page.Canvas

                ' Define the foreground color for the hatch pattern using ARGB values
                Dim foreColor As Color = Color.FromArgb(255, 255, 255, 0)

                ' Define the background color for the hatch pattern using ARGB values
                Dim backColor As Color = Color.FromArgb(255, 78, 167, 46)

                ' Create a new hatch brush with the current style and defined colors
                Dim brush As PdfHatchBrush = New PdfHatchBrush(type, foreColor, backColor)

                ' Draw a rectangle on the canvas using the hatch brush at specified position and size
                canves.DrawRectangle(brush, 100, 100, 300, 200)
            Next

            ' Define the output file path for the PDF
            Dim output As String = "CreateHatchBrush.pdf"

            ' Save the PDF document to the specified file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

            ' Release the resources used by the document
            pdf.Dispose()

            'Launch the Pdf file
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
