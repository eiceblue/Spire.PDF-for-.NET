Imports Spire.Pdf
Imports System.IO
Imports System.Text

Namespace SaveWithProgressNotifier
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf instance
			Dim doc As New PdfDocument()

			'Load from file and get the first page
			doc.LoadFromFile("..\..\..\..\..\..\Data\findText.pdf")

			' Register a custom progress notifier to monitor the save operation's progress
			doc.RegisterProgressNotifier(New CustomProgressNotifier())

			' Save the document to an XPS file
			doc.SaveToFile("SaveWithProgressNotifier_output.xps", FileFormat.XPS)

			' Close the document
			doc.Close()

			Me.Close()

		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try

		End Sub
	End Class
End Namespace

Public Class CustomProgressNotifier
    Implements IProgressNotifier

    Private str As New StringBuilder()

    Public Sub Notify(ByVal progress As Single) Implements IProgressNotifier.Notify
        str.AppendLine("==============Progress: " & progress & "%==============")
        File.WriteAllText("SaveWithProgressNotifier_output.txt", str.ToString())
    End Sub
End Class
