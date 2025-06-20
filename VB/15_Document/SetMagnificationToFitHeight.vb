Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.General

Namespace SetMagnificationToFitHeight
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new PdfDocument object
            Dim myPdf As New PdfDocument()

            ' Load an existing PDF document from file
            myPdf.LoadFromFile("..\..\..\..\..\..\Data\SampleB_1.pdf")

            ' Get the first page of the loaded PDF document
            Dim page As PdfPageBase = myPdf.Pages(0)

            ' Create a new destination for the page with a specific location
            Dim dest As New PdfDestination(page, New PointF(-40.0F, -40.0F))

            ' Set the mode of the destination to fit the page vertically
            dest.Mode = PdfDestinationMode.FitV

            ' Create a new GoTo action with the destination
            Dim gotoaction As New PdfGoToAction(dest)

            ' Set the GoTo action as the after open action for the document
            myPdf.AfterOpenAction = gotoaction

            ' Set the page mode of the viewer preferences to use outlines
            myPdf.ViewerPreferences.PageMode = PdfPageMode.UseOutlines

            ' Save the modified document to a new PDF file
            myPdf.SaveToFile("FitHeight.pdf")

            ' Close the document
            myPdf.Close()

            ' Launch the pdf file
            PDFDocumentViewer("FitHeight.pdf")
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub

    End Class
End Namespace
