Imports Spire.Pdf
Imports Spire.Pdf.Actions
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.General.Find
Imports System.IO

Namespace LaunchFileInNewWindow
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\DocumentsLinks.pdf")

			'Define the variables
			Dim finds() As PdfTextFind = Nothing
			Dim test() As String = { "Spire.PDF" }

			'Traverse the pages
			For Each page As PdfPageBase In pdf.Pages
				For i As Integer = 0 To test.Length - 1
					'Find the defined string
					finds = page.FindText(test(i), TextFindParameter.WholeWord).Finds

					'Traverse the finds
					For Each find As PdfTextFind In finds
						Dim launchAction As New PdfLaunchAction("..\..\..\..\..\..\Data\Sample.pdf", PdfFilePathType.Relative)

						'Set open document in a new window
						launchAction.IsNewWindow = True

						'Add annotation
						Dim rect As New RectangleF(find.Position.X, find.Position.Y, find.Size.Width, find.Size.Height)
						Dim annotation As New PdfActionAnnotation(rect, launchAction)
						TryCast(page, PdfPageWidget).AnnotationsWidget.Add(annotation)
					Next find
				Next i
			Next page
			'Save the file
			Dim result As String = "LaunchFileInNewWindow.pdf"
			pdf.SaveToFile(result)

			'Launch the file.
			DocumentViewer(result)
		End Sub
		Private Sub DocumentViewer(ByVal filename As String)
			Try
				Process.Start(filename)
			Catch
			End Try
		End Sub
	End Class
End Namespace
