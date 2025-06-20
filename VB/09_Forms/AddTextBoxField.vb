Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddTextBoxField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Define the input file path
            Dim input As String = "..\..\..\..\..\..\Data\FormFieldTemplate.pdf"

            ' Create a new PDF document
            Dim pdf As New PdfDocument()
            pdf.LoadFromFile(input)

            ' Get the first page of the PDF
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Allow the creation of form fields in the PDF
            pdf.AllowCreateForm = True

            ' Define the font and brush for drawing text
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F, PdfFontStyle.Bold)
            Dim brush As PdfBrush = PdfBrushes.Black

            ' Set the initial position for drawing text
            Dim x As Single = 50
            Dim y As Single = 550

            ' Store the current X-coordinate position
            Dim tempX As Single = 0

            ' Define the text to be drawn
            Dim text As String = "TexBox: "

            ' Draw the text on the PDF page
            page.Canvas.DrawString(text, font, brush, x, y)

            ' Calculate the next X-coordinate position
            tempX = font.MeasureString(text).Width + x + 15

            ' Create a new TextBox field
            Dim textbox As New PdfTextBoxField(page, "TextBox")
            textbox.Bounds = New RectangleF(tempX, y, 100, 15)
            textbox.BorderWidth = 0.75F
            textbox.BorderStyle = PdfBorderStyle.Solid

            ' Add the TextBox field to the PDF form
            pdf.Form.Fields.Add(textbox)

            ' Define the output file name
            Dim result As String = "AddTextBoxField_out.pdf"

            ' Save the modified PDF document to a file
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
