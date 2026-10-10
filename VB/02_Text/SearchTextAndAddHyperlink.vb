Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Texts

Namespace SearchTextAndAddHyperlink
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim input As String = @"..\..\..\..\..\..\Data\SearchReplaceTemplate.pdf"
            Dim doc As PdfDocument = New PdfDocument()

            ' Read a pdf file
            doc.LoadFromFile(input)

            ' Get the first page of pdf file
            Dim page As PdfPageBase = doc.Pages[0]

            ' Create PdfTextFindCollection object to find all the matched phrases
            Dim finds As PdfTextFinder = New PdfTextFinder(doc.Pages[0])
            finds.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.IgnoreCase
            Dim result As List<PdfTextFragment> = finds.Find("e-iceblue")

            ' hyperlink url
            Dim url As String = "http://www.e-iceblue.com"

            For Each find As PdfTextFragment In result
                Dim rect As RectangleF = New RectangleF(find.Positions[0].X, find.Positions[0].Y, find.Sizes[0].Width, find.Sizes[0].Height)
                ' Create a PdfUriAnnotation object to add hyperlink for the searched text 
                Dim action As PdfURIAction = New PdfURIAction(url)
                Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, rect, action)
                annotation.Border.Width = 1f
                annotation.Color = Color.Blue
                PdfAnnotationCollection.Create(page).Add(annotation)
            Next

            Dim outputFile As String = "SearchTextAndAddHyperlink_out.pdf"

            ' Save the modified document to the output file path
            doc.SaveToFile(outputFile)

            'Launch the Pdf file
            PDFDocumentViewer(outputFile)
        End Sub

        Private Sub PDFDocumentViewer(ByVal fileName As String)
            Try
                System.Diagnostics.Process.Start(fileName)
        Catch
        End Try
        End Sub
    End Class
End Namespace
