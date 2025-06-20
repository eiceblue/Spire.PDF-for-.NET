Imports Spire.Pdf
Imports Spire.Pdf.Fields
Imports Spire.Pdf.Graphics

Namespace AddRadioButtonFieldWithOptions
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

            ' Get the first page of the loaded document
            Dim page As PdfPageBase = pdf.Pages(0)

            ' Enable form field creation in the PDF document
            pdf.AllowCreateForm = True

            ' Create a font for the form field
            Dim font As New PdfFont(PdfFontFamily.Helvetica, 12.0F, PdfFontStyle.Bold)

            ' Set the text color for the form field
            Dim brush As PdfBrush = PdfBrushes.Black

            ' Set the initial position for drawing the form field
            Dim x As Single = 150
            Dim y As Single = 550

            ' Temporary variable to store the updated X position
            Dim temX As Single = 0

            ' Create a radio button list form field
            Dim radioButton As New PdfRadioButtonListField(page, "RadioButton")

            ' Set the radio button list as required
            radioButton.Required = True

            ' Loop to add items to the radio button list
            For i As Integer = 0 To 2
                ' Create a radio button list item
                Dim item As New PdfRadioButtonListItem(String.Format("item{0}", i))

                ' Customize the appearance of the radio button list item
                item.BorderWidth = 0.75F
                item.Bounds = New RectangleF(x, y, 15, 15)
                item.BorderColor = Color.Red
                item.ForeColor = Color.Red

                ' Add the radio button list item to the radio button list
                radioButton.Items.Add(item)

                ' Update the X position for drawing the associated item text
                temX = x + 20

                ' Draw the item text on the page
                page.Canvas.DrawString(String.Format("Item{0}", i), font, brush, temX, y)

                ' Update the X position for the next radio button item
                x = temX + 100
            Next i

            ' Add the radio button list form field to the PDF document
            pdf.Form.Fields.Add(radioButton)

            ' Specify the output file path
            Dim result As String = "AddRadioButtonFieldWithOptions_out.pdf"

            ' Save the modified PDF document to the output file
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
