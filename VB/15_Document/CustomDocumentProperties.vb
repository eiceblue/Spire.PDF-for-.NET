Imports Spire.Pdf

Namespace CustomDocumentProperties
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            'Define the input file path
            Dim input As String = "..\..\..\..\..\..\Data\CustomDocumentProperties.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the PDF document from the specified input file
            doc.LoadFromFile(input)

            ' Set custom properties in the document information
            doc.DocumentInformation.SetCustomProperty("Company", "E-iceblue")
            doc.DocumentInformation.SetCustomProperty("Component", "Spire.PDF for .NET")
            doc.DocumentInformation.SetCustomProperty("Name", "Daisy")
            doc.DocumentInformation.SetCustomProperty("Team", "SalesTeam")

            ' Define the output file name
            Dim result As String = "CustomDocumentProperties_out.pdf"

            ' Save the modified document to the specified output file in PDF format
            doc.SaveToFile(result, FileFormat.PDF)

            ' Close the document
            doc.Close()

            ' Launch the file
            DocumentViewer(result)
        End Sub

        Private Sub DocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
