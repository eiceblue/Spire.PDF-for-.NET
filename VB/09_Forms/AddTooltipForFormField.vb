Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports Spire.Pdf.Fields

Namespace AddTooltipForFormField
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Set the input file path
            Dim input As String = "..\..\..\..\..\..\Data\AddTooltipForFormField.pdf"

            ' Create a new PDF document
            Dim doc As New PdfDocument()
            doc.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = doc.Pages(0)

            ' Enable form creation in the document
            doc.AllowCreateForm = True

            ' Set the font and brush for drawing text
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F, PdfFontStyle.Bold)
            Dim brush As PdfBrush = PdfBrushes.Black

            ' Set the initial position for drawing text
            Dim x As Single = 50
            Dim y As Single = 590

            ' Store the temporary X position
            Dim tempX As Single = 0

            ' Set the text to be drawn
            Dim text As String = "E-mail: "

            ' Draw the text on the page canvas
            page.Canvas.DrawString(text, font, brush, x, y)

            ' Calculate the updated X position based on the width of the text
            tempX = font.MeasureString(text).Width + x + 15

            ' Create a new textbox field
            Dim textbox As New PdfTextBoxField(page, "TextBox")

            ' Set the bounds (position and size) of the textbox
            textbox.Bounds = New RectangleF(tempX, y, 100, 15)

            ' Set the border properties of the textbox
            textbox.BorderWidth = 0.75F
            textbox.BorderStyle = PdfBorderStyle.Solid

            ' Add the textbox field to the document's form fields collection
            doc.Form.Fields.Add(textbox)

            ' Set the tooltip for the textbox field
            doc.Form.Fields("TextBox").ToolTip = "Please insert a valid email address"

            ' Set the output file path
            Dim output As String = "AddTooltipForFormField.pdf"

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
