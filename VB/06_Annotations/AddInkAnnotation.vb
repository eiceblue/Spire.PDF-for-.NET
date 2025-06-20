Imports Spire.Pdf
Imports Spire.Pdf.Annotations

Namespace AddInkAnnotation
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a new PdfDocument object
			Dim pdf As New PdfDocument()

			' Add a new page to the document
			Dim pdfPage As PdfPageBase = pdf.Pages.Add()

			' Create a list to store ink points
			Dim inkList As New List(Of Integer())()

			' Define the coordinates for an ink point
			Dim intPoints() As Integer = {100, 800, 200, 800, 200, 700}

			' Add the ink points to the ink list
			inkList.Add(intPoints)

			' Create a new PdfInkAnnotation object with the specified ink points
			Dim ia As New PdfInkAnnotation(inkList)

			' Set the color of the ink annotation to Pink
			ia.Color = Color.Pink

			' Set the width of the border of the ink annotation to 12
			ia.Border.Width = 12

			' Set the opacity of the ink annotation to 0.3
			ia.Opacity = 0.3F

			' Set the text content of the ink annotation to "e-iceblue"
			ia.Text = "e-iceblue"

			' Add the ink annotation to the page's collection of annotations
            pdfPage.Annotations.Add(ia)

			' Save the document to a PDF file with the specified result filename
			Dim result As String = "AddInkAnnotation_result.pdf"
			pdf.SaveToFile(result)

			' Close the document
			pdf.Close()

			'Launch the Pdf file
			PDFDocumentViewer(result)
		End Sub
		Private Sub PDFDocumentViewer(ByVal fileName As String)
			Try
				Process.Start(fileName)
			Catch
			End Try
		End Sub

	End Class
End Namespace
