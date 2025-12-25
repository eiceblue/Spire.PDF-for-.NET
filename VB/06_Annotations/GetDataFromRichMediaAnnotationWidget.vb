Imports System.IO
Imports Spire.Pdf
Imports Spire.Pdf.Annotations
Imports Spire.Pdf.Graphics


Namespace GetDataFromRichMediaAnnotationWidget
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			'Create a pdf instance
			Dim doc As New PdfDocument()

			doc.LoadFromFile("..\..\..\..\..\..\Data\VideoAndAudio.pdf")

			For i As Integer = 0 To doc.Pages.Count - 1
				Dim page As PdfPageBase = doc.Pages(i)
				'Get the annotation collection of the page
				Dim ancoll As PdfAnnotationCollection = page.Annotations
				For j As Integer = 0 To ancoll.Count - 1
					'Convert to Rich Media Annotations
					Dim MediaWidget As PdfRichMediaAnnotationWidget = TryCast(ancoll(j), PdfRichMediaAnnotationWidget)
					'Obtain data from rich media annotations
					Dim data() As Byte = MediaWidget.RichMediaData
					'Obtain names from rich media annotations
					Dim embedFileName As String = MediaWidget.RichMediaName
					'Save Data
					File.WriteAllBytes(embedFileName, data)
					'Launch the Pdf file
					PDFDocumentViewer(embedFileName)
				Next j
			Next i

		End Sub

		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
