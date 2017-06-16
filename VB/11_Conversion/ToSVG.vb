Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics

Namespace ToSVG
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'pdf file
            Dim file As String = "..\..\..\..\..\..\Data\Sample9.pdf"

            'open pdf document
            Dim doc As New PdfDocument()
            doc.LoadFromFile(file)

            'convert to svg file.
            doc.SaveToFile("Sample9.svg", FileFormat.SVG)
            doc.Close()

            'Launching the svg file.
            System.Diagnostics.Process.Start("Sample9.svg")
        End Sub
    End Class
End Namespace
