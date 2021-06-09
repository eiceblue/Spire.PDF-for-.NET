Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Spire.Pdf

Namespace ToPCL
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim input As String = "..\..\..\..\..\..\Data\ToPCL.pdf"

			'Load a PDF file
			Dim doc As New PdfDocument()
			doc.LoadFromFile(input)

			'Save to PCL file
			Dim output As String = "ToPCL_result.pcl"
			doc.SaveToFile(output, FileFormat.PCL)

			'Launch the PCL file
			PDFDocumentViewer(output)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub
	End Class
End Namespace
