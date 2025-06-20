Imports Spire.Pdf
Imports Spire.Pdf.Widget

Namespace GetCoordinates
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object.
            Dim doc As New PdfDocument()

            ' Load an existing PDF file from the specified path.
            doc.LoadFromFile("..\..\..\..\..\..\Data\TextBoxSampleB.pdf")

            ' Get the form widget from the loaded document and cast it to a PdfFormWidget object.
            Dim formWidget As PdfFormWidget = TryCast(doc.Form, PdfFormWidget)

            ' Get the textbox field widget named "Text1" from the form widget.
            Dim textbox As PdfTextBoxFieldWidget = TryCast(formWidget.FieldsWidget("Text1"), PdfTextBoxFieldWidget)

            ' Get the location of the textbox field as a PointF object.
            Dim location As PointF = textbox.Location

            ' Display a message box showing the location information of the textbox field.
            MessageBox.Show("The location of the field named " & textbox.Name & " is" & vbLf & " X:" & location.X & "  Y:" & location.Y)

            ' Close the document
            doc.Close()
        End Sub
    End Class
End Namespace
