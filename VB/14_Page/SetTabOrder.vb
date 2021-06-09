Imports Spire.Pdf

Namespace SetTabOrder
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Load old PDF from disk.
			Dim pdf As New PdfDocument()
			pdf.LoadFromFile("..\..\..\..\..\..\Data\SetTabOrder.pdf")

			'Set using document structure
			pdf.FileInfo.IncrementalUpdate = False
			Dim page As PdfPageBase = pdf.Pages(0)
			page.SetTabOrder(TabOrder.Structure)

			'Save the file
			Dim result As String = "SetTabOrder_output.pdf"
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
