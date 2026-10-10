Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Interactive.Annotations
Imports Spire.Pdf.Texts
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace LaunchFileInNewWindow
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Load an existing PDF document from disk.
            Dim pdf As PdfDocument = New PdfDocument()
            pdf.LoadFromFile(@"..\..\..\..\..\..\Data\DocumentsLinks.pdf")

            'Define the variables
            ' PdfTextFinder[] finds = null;
            Dim test As String[] = { "Spire.PDF" }

            'Traverse the pages
            For Each page As PdfPageBase In pdf.Pages
                Dim finds As PdfTextFinder = New PdfTextFinder(page)
                Dim i As Integer = 0
                While i < test.Length
                    'Find the defined string
                    finds.Options.Parameter = Spire.Pdf.Texts.TextFindParameter.WholeWord
                    Dim result As List<PdfTextFragment> = finds.Find(test[i])

                    'Traverse the finds
                    For Each find As PdfTextFragment In result
                        Dim launchAction As PdfLaunchAction = New PdfLaunchAction(@"..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative)

                        'Set open document in a new window
                        launchAction.NewWindow = True

                        'Add annotation
                        Dim rect As RectangleF = New RectangleF(result.First().Positions[0].X, result.First().Positions[0].Y, result.First().Sizes[0].Width, result.First().Sizes[0].Height)
                        Dim annotation As PdfLinkAnnotation = New PdfLinkAnnotation(page, rect, launchAction)
                        PdfAnnotationCollection.Create(page).Add(annotation)
                    Next
                Next
            Next

            ' Save the modified PDF document to a new file.
            Dim outputFile As String = "LaunchFileInNewWindow.pdf"
            pdf.SaveToFile(outputFile)

            'Launch the file.
            DocumentViewer(outputFile)
        End Sub
        Private Sub DocumentViewer(ByVal filename As String)
            Try
                System.Diagnostics.Process.Start(filename)
        Catch
        End Try
        End Sub
    End Class
End Namespace
