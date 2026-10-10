Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Destinations
Imports Spire.Pdf.General
Imports Spire.Pdf.Interactive.Annotations
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace SetInheritZoomForHyperLink
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim inputFile As String = @"..\..\..\..\..\..\Data\SetInheritZoomForHyperLink.pdf"
            Dim outputFile As String = @"output.pdf"

            ' Load the PDF file
            Dim pdf As PdfDocument = New PdfDocument()
            pdf.LoadFromFile(inputFile)

            ' Get the PdfAnnotationCollection of the first page
            Dim annotations As PdfAnnotationCollection = PdfAnnotationCollection.Create(pdf.Pages[0])

            ' Iterate through each annotation in the collection
            Dim i As Integer = 0
            While i < annotations.Count
                ' Cast the current annotation to a PdfDocumentLinkAnnotationWidget
                Dim anno As PdfLinkAnnotation = annotations[i] as PdfLinkAnnotation

                ' Get the destination of the annotation
                Dim dest As PdfXYZExplicitDestination = anno.Destination as PdfXYZExplicitDestination
                If dest != null Then
                    dest.Zoom = 0
                End If
                Else
                    anno.Destination = New PdfXYZExplicitDestination(((anno.Action as PdfGoToAction).Destination as PdfExplicitDestination).Page, 0, 0, 0)
            Next
        End Sub

            ' Save the modified PDF file to the specified output file
            pdf.SaveToFile(outputFile, FileFormat.PDF)

            ' Close the PDF document
            pdf.Close()

            'Launch the Pdf file
            PDFDocumentViewer(outputFile)
    End Class

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub

End Namespace
