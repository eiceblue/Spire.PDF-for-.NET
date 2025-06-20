Imports Spire.Pdf

Namespace IsPDFPortfolio
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified file path
            doc.LoadFromFile("..\..\..\..\..\..\Data\TextBoxSampleB_1.pdf")

            ' Check if the document is a portfolio
            Dim value As Boolean = doc.IsPortfolio

            ' Display a message box indicating whether the document is a portfolio or not
            If value Then
                MessageBox.Show("The document is a portfolio")
            Else
                MessageBox.Show("The document is not a portfolio")
            End If

            ' Close the PDF document
            doc.Close()
        End Sub
    End Class
End Namespace
