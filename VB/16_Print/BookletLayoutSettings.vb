Imports Spire.Pdf
Imports Spire.Pdf.Print

Namespace BookletLayoutSettings
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of PdfDocument.
            Dim pdf As New PdfDocument()

            ' Load the PDF file from the specified path.
            pdf.LoadFromFile("..\..\..\..\..\..\Data\Sample.pdf")

            ' Check if duplex printing is supported.
            Dim isDuplex As Boolean = pdf.PrintSettings.CanDuplex

            ' If duplex printing is supported, set the booklet layout and binding mode.
            If (isDuplex) Then
                pdf.PrintSettings.SelectBookletLayout(PdfBookletSubsetMode.BothSides, PdfBookletBindingMode.Left)

                ' Print the document.
                pdf.Print()
            End If

            ' Close the PDF document.
            pdf.Close()
        End Sub
    End Class
End Namespace
