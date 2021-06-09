Imports System.ComponentModel
Imports System.Text
Imports Spire.Pdf
Imports Spire.Pdf.Graphics
Imports System.IO

Namespace GetViewerPreference
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\PDFTemplate-Az.pdf"
			Dim doc As New PdfDocument()
			' Read a pdf file
			doc.LoadFromFile(input)

			Dim viewer As PdfViewerPreferences = doc.ViewerPreferences

			' Create a StringBuilder object to put the details
			Dim builder As New StringBuilder()

			builder.AppendLine("Whether the documents window position is in the center: ")
			builder.AppendLine("CenterWindow: " & viewer.CenterWindow.ToString())
			builder.AppendLine("Document displaying mode, i.e. show thumbnails, full-screen, show attachment panel: ")
			builder.AppendLine("PageMode: " & viewer.PageMode.ToString())
			builder.AppendLine("The page layout, i.e. single page, one column: ")
			builder.AppendLine("PageLayout: " & viewer.PageLayout.ToString())
			builder.AppendLine("Whether window's title bar should display document title: ")
			builder.AppendLine("DisplayTitle: " & viewer.DisplayTitle.ToString())
			builder.AppendLine("Whether to resize the document's window to fit the size of the firstdisplayed page: ")
			builder.AppendLine("FitWindow:" & viewer.FitWindow.ToString())
			builder.AppendLine("Whether to hide menu bar of the viewer application: ")
			builder.AppendLine("HideMenubar: " & viewer.HideMenubar.ToString())
			builder.AppendLine("Whether to hide tool bar of the viewer application: ")
			builder.AppendLine("HideToolbar: " & viewer.HideToolbar.ToString())
			builder.AppendLine("Whether to hide UI elements like scroll bars and leave only the page contents displayed: ")
			builder.AppendLine("HideWindowUI: " & viewer.HideWindowUI.ToString())

			Dim result As String = "GetViewerPreference_out.txt"

			File.WriteAllText(result, builder.ToString())
			'Launch the result file
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
