Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddJavaScriptAction
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\FormFieldTemplate.pdf"

            ' Create a new PDF document
            Dim pdf As New PdfDocument()

            ' Load the PDF document from the input file
            pdf.LoadFromFile(input)

            ' Get the first page of the document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Allow form field creation in the document
            pdf.AllowCreateForm = True

            ' Set the font and brush for drawing text
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F, PdfFontStyle.Bold)
            Dim brush As PdfBrush = PdfBrushes.Black

            ' Set the initial coordinates for drawing
            Dim x As Single = 50
            Dim y As Single = 550
            Dim tempX As Single = 0

            ' Define the text to be drawn on the page
            Dim text1 As String = "Enter a number, such as 12345: "

            ' Draw the text onto the page
            page.Canvas.DrawString(text1, font, brush, x, y)

            ' Calculate the X coordinate for the textbox based on the width of the text
            tempX = font.MeasureString(text1).Width + x + 15

            ' Create a textbox form field
            Dim textbox As New PdfTextBoxField(page, "Number-TextBox")
            textbox.Bounds = New RectangleF(tempX, y, 100, 15)
            textbox.BorderWidth = 0.75F
            textbox.BorderStyle = PdfBorderStyle.Solid

            ' Set the JavaScript keystroke action for the textbox
            Dim js As String = PdfJavaScript.GetNumberKeystrokeString(2, 0, 0, 0, "$", True)
            Dim jsAction As New PdfJavaScriptAction(js)
            textbox.Actions.KeyPressed = jsAction

            ' Set the JavaScript format action for the textbox
            js = PdfJavaScript.GetNumberFormatString(2, 0, 0, 0, "$", True)
            jsAction = New PdfJavaScriptAction(js)
            textbox.Actions.Format = jsAction

            ' Add the textbox field to the PDF form
            pdf.Form.Fields.Add(textbox)

            ' Specify the output file path
            Dim output As String = "AddJavaScriptAction_out.pdf"

            ' Save the modified PDF document to the output file
            pdf.SaveToFile(output)

            ' Close the document
            pdf.Close()

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
