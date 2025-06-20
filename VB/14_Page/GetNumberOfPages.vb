Imports Spire.Pdf

Namespace GetNumberOfPages
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a new instance of OpenFileDialog
            Dim dialog As New OpenFileDialog()

            ' Set the filter to display only PDF files
            dialog.Filter = "PDF document (*.pdf)|*.pdf"

            ' Show the dialog and store the result
            Dim result As DialogResult = dialog.ShowDialog()

            ' If the user selects a file and clicks OK
            If result = DialogResult.OK Then
                Try
                    ' Get the selected PDF file path
                    Dim pdfFile As String = dialog.FileName

                    ' Open the PDF document and retrieve its page count
                    Using pdf As New PdfDocument()
                        pdf.LoadFromFile(pdfFile)
                        Dim count As Integer = pdf.Pages.Count
                        MessageBox.Show("The page count of the PDF document is " & count)
                    End Using
                Catch exe As Exception
                    MessageBox.Show(exe.Message, "Spire.Pdf Demo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub
    End Class
End Namespace
