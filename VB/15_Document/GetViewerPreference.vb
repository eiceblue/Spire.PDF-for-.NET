Imports System.Text
Imports Spire.Pdf
Imports System.IO

Namespace GetViewerPreference
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Specify the input file path
            Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"

            ' Create a new PdfDocument object
            Dim doc As New PdfDocument()

            ' Load the document from the input file
            doc.LoadFromFile(input)

            ' Get the viewer preferences of the document
            Dim viewer As PdfViewerPreferences = doc.ViewerPreferences

            ' Create a StringBuilder object to store the viewer preferences
            Dim builder As New StringBuilder()

            ' Append information about whether the documents window position is in the center
            builder.AppendLine("Whether the document's window position is in the center: ")
            builder.AppendLine("CenterWindow: " & viewer.CenterWindow.ToString())

            ' Append information about the document displaying mode, such as show thumbnails, full-screen, show attachment panel
            builder.AppendLine("Document displaying mode: ")
            builder.AppendLine("PageMode: " & viewer.PageMode.ToString())

            ' Append information about the page layout, such as single page, one column
            builder.AppendLine("The page layout: ")
            builder.AppendLine("PageLayout: " & viewer.PageLayout.ToString())

            ' Append information about whether the window's title bar should display the document title
            builder.AppendLine("Whether the window's title bar should display the document title: ")
            builder.AppendLine("DisplayTitle: " & viewer.DisplayTitle.ToString())

            ' Append information about whether to resize the document's window to fit the size of the first displayed page
            builder.AppendLine("Whether to resize the document's window to fit the size of the first displayed page: ")
            builder.AppendLine("FitWindow: " & viewer.FitWindow.ToString())

            ' Append information about whether to hide the menu bar of the viewer application
            builder.AppendLine("Whether to hide the menu bar of the viewer application: ")
            builder.AppendLine("HideMenubar: " & viewer.HideMenubar.ToString())

            ' Append information about whether to hide the toolbar of the viewer application
            builder.AppendLine("Whether to hide the toolbar of the viewer application: ")
            builder.AppendLine("HideToolbar: " & viewer.HideToolbar.ToString())

            ' Append information about whether to hide UI elements like scroll bars and leave only the page contents displayed
            builder.AppendLine("Whether to hide UI elements like scroll bars and leave only the page contents displayed: ")
            builder.AppendLine("HideWindowUI: " & viewer.HideWindowUI.ToString())

            ' Specify the output file path
            Dim result As String = "GetViewerPreference_out.txt"

            ' Write the contents of the StringBuilder to the output file
            File.WriteAllText(result, builder.ToString())

            ' Close the PDF document
            doc.Close()

            ' Launch the result file
            DocumentViewer(result)
        End Sub

        Private Sub DocumentViewer(ByVal fileName As String)
            Try
                Process.Start(fileName)
            Catch
            End Try
        End Sub
    End Class
End Namespace
